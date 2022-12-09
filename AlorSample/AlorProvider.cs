using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FishingSizes
{
    public enum AlorWsMessageType
    {
        Trades,
        Orderbook
    }

    public class AlorProvider
    {
        private string _refreshToken;
        private string _jwtToken;
        private DateTimeOffset _lastTokenRefreshTime;
        private Uri _alorWsUri;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private ClientWebSocket _clientWebSocket;
        private bool _started = false;
        private static readonly HttpClient _httpClient = new HttpClient();
        private ConcurrentDictionary<Guid, (AlorWsMessageType messageType, string ticker)> _wsRequests = new ConcurrentDictionary<Guid, (AlorWsMessageType messageType, string ticker)>();

        public AlorProvider(string refreshToken)
        {
            _refreshToken = refreshToken;
            _alorWsUri = new Uri("wss://api.alor.ru/ws");
            _clientWebSocket = new ClientWebSocket();
        }

        public event EventHandler<AlorOrderbook> OnOrderbookReceived;
        public event EventHandler<AlorTrade> OnTradeReceived;

        private async Task CheckJWTToken()
        {
            // срок жизни JWT токена в Алор составляет 30 минут, после этого его надо запрашивать заново
            if (_jwtToken != null && DateTimeOffset.Now.Subtract(_lastTokenRefreshTime).TotalMinutes <= 29)
                return;
            // для получения JWT токена делаем POST-запрос с указанием refresh токена, как указано в документации https://alor.dev/docs
            var response = await _httpClient.PostAsync($"https://oauth.alor.ru/refresh?token={_refreshToken}", null);
            var content = await response.Content.ReadAsStringAsync();
            // в ответ приходит строка вида {"AccessToken":"eyJhbGciOi......EayIbPmig"}
            var resObj = (JObject)JsonConvert.DeserializeObject(content);
            Console.WriteLine($"resObj {resObj}" );
            _jwtToken = resObj["AccessToken"].ToString();
            _lastTokenRefreshTime = DateTimeOffset.Now;
        }

        public async Task ConnectSocket()
        {
            await CheckJWTToken();
            await _clientWebSocket.ConnectAsync(_alorWsUri, _cts.Token);
            if (!_started)
                await Task.Factory.StartNew(ReceiveLoop, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// Метод для отправки сообщения в websocket
        /// </summary>
        /// <param name="data">строка в json или объект, который будет преобразован в json строку</param>
        /// <returns></returns>
        public async Task SendWebsocketMessage(object data)
        {
            string content;

            if (data is string)
                content = data as string;
            else
                content = JsonConvert.SerializeObject(data);

            var contentBytes = Encoding.UTF8.GetBytes(content);

            await _clientWebSocket.SendAsync(new ArraySegment<byte>(contentBytes), WebSocketMessageType.Text, true, _cts.Token);
        }

        //Пример запроса на подписку принтов по TSLA
        //{
        //  "opcode": "AllTradesGetAndSubscribe",
        //  "code": "TSLA",
        //  "exchange": "SPBX",
        //  "delayed": false,
        //  "token": "eyJhbGciOiJ.......4XvV3l-FcVAA",
        //  "guid": "020e9b33-0b7d-4420-a20a-4453d355214a"
        //}
        public async Task SubscribeTrades(string ticker, string exchange = "SPBX")
        {
            await CheckJWTToken();

            var request = new
            {
                opcode = "AllTradesGetAndSubscribe",
                code = ticker,
                exchange = exchange,
                delayed = false,
                token = _jwtToken,
                guid = Guid.NewGuid()
            };
            // запоминаем тип запроса для этого сообщения по guid
            _wsRequests[request.guid] = (AlorWsMessageType.Trades, ticker);

            await SendWebsocketMessage(request);
        }

        public async Task SubscribeOrderbook(string ticker, int depth = 10, string exchange = "SPBX")
        {
            await CheckJWTToken();

            var request = new
            {
                opcode = "OrderBookGetAndSubscribe",
                code = ticker,
                exchange = exchange,
                delayed = false,
                depth = depth,
                format = "Simple",
                token = _jwtToken,
                guid = Guid.NewGuid()
            };
            // запоминаем тип запроса для этого сообщения по guid
            _wsRequests[request.guid] = (AlorWsMessageType.Orderbook, ticker);

            await SendWebsocketMessage(request);
        }

        public async Task UnSubscribe(string ticker, AlorWsMessageType typemessage)
        {
            await CheckJWTToken();

            var guid = _wsRequests.FirstOrDefault(pair => pair.Value == (typemessage, ticker)).Key;
            if (guid != null)
            {
                var request = new
                {
                    opcode = "unsubscribe",
                    token = _jwtToken,
                    guid = guid
                };
                await SendWebsocketMessage(request);
                _wsRequests.TryRemove(guid, out var _);

            }
        }


        private async Task ReceiveLoop()
        {
            var token = _cts.Token;
            ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[8192]);
            WebSocketReceiveResult result = null;

            while (!token.IsCancellationRequested)
            {
                if (_clientWebSocket == null || _clientWebSocket.State != WebSocketState.Open)
                {
                    await Task.Delay(100);
                    continue;
                }

                using (var ms = new MemoryStream())
                {
                    do
                    {
                        result = await _clientWebSocket.ReceiveAsync(buffer, token);
                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                    }
                    while (!result.EndOfMessage);

                    ms.Seek(0, SeekOrigin.Begin);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        using (var reader = new StreamReader(ms, Encoding.UTF8))
                        {
                            var message = reader.ReadToEnd();
                            //Debug.WriteLine($"01/Сообщение от сервера: {message}");

                            var obj = (JToken)JsonConvert.DeserializeObject(message);
                            if (obj["data"] != null)
                            {
                                Guid guid = Guid.Parse(obj["guid"].ToString());
                                TryParseData(guid, message);
                            }
                            else
                            {
                                Debug.WriteLine($"02/Сообщение от сервера: {obj["requestGuid"]} {obj["httpCode"]} {obj["message"]}");
                            }
                        }
                    }
                }
            }
        }

        private void TryParseData(Guid requestGuid, string message)
        {
            //Debug.WriteLine($"03/Сообщение от сервера: {message}");
            if (_wsRequests.TryGetValue(requestGuid, out var alorMessageType))
            {
                switch (alorMessageType.messageType)
                {
                    case AlorWsMessageType.Trades:
                        var trade = JsonConvert.DeserializeObject<AlorTrade>(message);
                        DateTime.SpecifyKind(trade.data.time, DateTimeKind.Utc); // иначе будет считаться что время локальное, в то время как алор шлёт в UTC
                        trade.data.time = trade.data.time.ToLocalTime();
                        OnTradeReceived?.Invoke(this, trade);
                        //Debug.WriteLine($"04/Сообщение от сервера: {trade.guid}");
                        break;
                    case AlorWsMessageType.Orderbook:
                        var orderbook = JsonConvert.DeserializeObject<AlorOrderbook>(message);
                        orderbook.data.symbol = alorMessageType.ticker; // в сообщении от алор нет тикера, но зная guid мы из словаря находит тикер, который соответствует этому guid на этапе подписки
                        // в этом сообщении время приходит числом в формате unix time, выполняем преобразование в локальное время и записываем в свойтсво time
                        orderbook.data.time = DateTime.SpecifyKind(DateTimeOffset.FromUnixTimeMilliseconds(orderbook.data.ms_timestamp).DateTime, DateTimeKind.Utc);
                        orderbook.data.time = orderbook.data.time.ToLocalTime();
                        OnOrderbookReceived?.Invoke(this, orderbook);
                        break;
                }
            }
        }
    }
}

