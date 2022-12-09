using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Network;
using Tinkoff.Trading.OpenApi.Models;
using System.Threading;
using System.Collections.Concurrent;
using Alpaca.Markets;
using System.Diagnostics;
using System.Text.Json;
using System.Drawing;
using System.IO;

namespace FishingSizes
{

    interface IRowGridArbClosePrice
    {
        void AppendRowArb(PacketRGA_CL packet, int count);
        void ClearGrid();
    }
    public class PacketRGA_CL : IComparable<PacketRGA_CL>
    {
        public RowGridArbClosePrice rowgrid;
        public Color color { get; set; }
        public PacketRGA_CL(RowGridArbClosePrice rowgrid, Color color)
        {
            this.rowgrid = rowgrid;
            this.color = color;
        }
        public int CompareTo(PacketRGA_CL packet)
        {
            if (packet is null) throw new ArgumentException("Некорректное значение параметра");
            return rowgrid.Delta.CompareTo(packet.rowgrid.Delta);
        }
    }
    class ArbClosePriseMetods
    {
        //string[] BlackList = { "BTI","ARE","BERY","BTAI","CARA","ENR","EWBC","JBL","MD","OIS","WGO","WH","WPC","ZWS" };
        public List<string> BlackList;
        public Settings Sett { get; set; }
        public SettingsClosePrints SettClosePrint { get; set; } 
        public List<MarketInstrument> marketInstruments;
        public IRowGridArbClosePrice RowGridArb1 { get; set; }
        //потоковые объекты
        public ConcurrentDictionary<string, OrderbookPayload> QuotesTinkoff = new ConcurrentDictionary<string, OrderbookPayload>();
        public ConcurrentDictionary<string, IQuote> QuotesAlpaca = new ConcurrentDictionary<string, IQuote>();
        //исторические данные принта закрытия
        public ConcurrentDictionary<string, Decimal> ClosePrice = new ConcurrentDictionary<string, Decimal>();
        public List<PacketRGA_CL> packetsShort1;
        public List<PacketRGA_CL> packetsLong;
        public Decimal ProcentDelta;

        private IAlpacaDataSubscription<IQuote> QuoteSubscription;
        public CancellationTokenSource cancelTokenSource;
        public CancellationToken token;
        public ArbClosePriseMetods(Settings sett, SettingsClosePrints settclprs, IRowGridArbClosePrice rowgrid, List<string> blacklist)
        {
            Terminal.Context_Ti.StreamingEventReceived += QuoteReceivedTinkoff;
            Terminal.TiSubscribeCheck = true;
            BlackList = blacklist;
            Sett = sett;
            SettClosePrint = settclprs;
            marketInstruments = new List<MarketInstrument>();
            RowGridArb1 = rowgrid;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }
        //обработчик полученных котировок nbbo от Tinkoff
        private void QuoteReceivedTinkoff(object sender, StreamingEventReceivedEventArgs e)
        {
            //обработчик сообщений от сокета
            if (e.Response.Event == "orderbook")
            {
                var response = (OrderbookResponse)e.Response;
                var ticker = TickerGet(response.Payload.Figi);
                QuotesTinkoff[ticker] = response.Payload;
            }
        }
        public string TickerGet(string figi)//получение Тикера по figi из коллекции
        {
            foreach (var item in Terminal.MarketStocks.Instruments)
            {
                if (item.Figi == figi)
                    return item.Ticker;
            }
            return null;
        }
        public async Task SubscribeQuoteTinkoff(string figi)//подписка на котировки Tinkoff NBBO
        {
            await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.SubscribeOrderbook(figi, 1));
        }
        public async Task SubscribeQuoteAlpaca(string ticker)//подписка на котировки Alpaca NBBO
        {
            QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(ticker);
            QuoteSubscription.Received += QuoteReceivedAlpaca;
            await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
        }
        //обработчик полученных котировок nbbo от Alpaca
        public void QuoteReceivedAlpaca(IQuote quote)
        {
            QuotesAlpaca[quote.Symbol] = quote;
        }
        public async void SubscribeQuotes()//подписка на котировки
        {
            foreach (var item in marketInstruments)
            {
                await SubscribeQuoteTinkoff(item.Figi);
                await SubscribeQuoteAlpaca(item.Ticker);
                //Debug.WriteLine($"Isin: {item.Isin} : i = {++i}");
            }
            await Task.Delay(5000);//через 5 секунд начинаем сканирование
            GetQuotesAlpaca();
            GetHistoryPrints();
            S();
        }
        private async void GetQuotesAlpaca()//получаем котировки у пустых тикеров
        {
                foreach (var item in marketInstruments)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    if (!QuotesAlpaca.ContainsKey(item.Ticker) && !BlackList.Contains(item.Ticker))
                    {
                        //Debug.WriteLine($"Отсутствует L1 Alpaca: {item.Ticker}");
                        if (item.Ticker.IndexOf("old") == -1 && item.Ticker.IndexOf("@") == -1)
                        {
                            try
                            {
                            LatestMarketDataRequest DataClientMarcetData = new(item.Ticker);
                            QuotesAlpaca[item.Ticker] = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"!!!!!!!!!!!!!!!!!!!Ошибка получения L1 Alpaca: {item.Ticker} - {ex}");
                            }
                            finally
                            {
                                //Debug.WriteLine($"Получили L1 Alpaca: {JsonSerializer.Serialize(QuotesAlpaca[item.Ticker])}");
                            }
                        }
                        Thread.Sleep(100);
                    }
                }
        }
        public async void S()
        {
            while (true)
            {
                RowGridArb1.ClearGrid();
                if (!token.IsCancellationRequested)
                {
                    ArbDeveloper();
                }
                else return;
                await Task.Delay(5000);
            }
        }
        //обработчик арбитража
        public void ArbDeveloper()
        {
            packetsShort1 = new List<PacketRGA_CL>();
            packetsLong = new List<PacketRGA_CL>();
            foreach (var item in marketInstruments)
            {
                var ticker = item.Ticker;
                if (QuotesAlpaca.ContainsKey(ticker) && QuotesTinkoff.ContainsKey(ticker) && ClosePrice.ContainsKey(ticker) && !BlackList.Contains(item.Ticker))//если объекты содержат ключи-тикеры по данному тикеру
                {
                    if (QuotesTinkoff[ticker].Asks.Count > 0 && QuotesTinkoff[ticker].Bids.Count > 0 && ClosePrice[ticker] > 0m)//если объекты содержат биды и аски
                    {
                        //шортовый арб СПБ
                        var delta_1 = 0m;
                        if (QuotesTinkoff[ticker].Asks[0][0] > 10)//берем бумаги если их цена больше 10$ 
                        {
                            delta_1 = ClosePrice[ticker] - QuotesTinkoff[ticker].Asks[0][0];
                        }
                        //если delta_1 больше установленного профита и если аск US снизился не более 10% от цены закрытия
                        if (delta_1 > SetProfit(ClosePrice[ticker]) && CheckAskUS(QuotesAlpaca[ticker].AskPrice, ClosePrice[ticker]))
                        {
                            Color color = Color.LightCoral;
                            V1(ticker, delta_1, item, color, packetsShort1);
                        }
                    }
                }
            }
            //формирование списка арбитражных бумаг
            void V1(string ticker, decimal delta, MarketInstrument instr, Color color, List<PacketRGA_CL> packets)
            {
                var rowgrid = new RowGridArbClosePrice(instr.Ticker, ClosePrice[ticker], QuotesTinkoff[ticker].Asks[0][0], (int)QuotesTinkoff[ticker].Asks[0][1],
                    QuotesAlpaca[ticker].AskPrice, (int)QuotesAlpaca[ticker].AskSize * 100, delta, (int)QuotesAlpaca[ticker].BidSize * 100, QuotesAlpaca[ticker].BidPrice, 
                    (int)QuotesTinkoff[ticker].Bids[0][1], QuotesTinkoff[ticker].Bids[0][0]);
                PacketRGA_CL list = new PacketRGA_CL(rowgrid, color);
                packets.Add(list);
            }
            packetsShort1.Sort();
            foreach (var item in packetsShort1)
            RowGridArb1.AppendRowArb(item, packetsShort1.Count);
        }
        //проверка остался ли аск US рядом с ценой закрытия
        private bool CheckAskUS(Decimal askUS, Decimal close)
        {
            var d = (100 - askUS * 100 / close);
            var d1 = (d * 100 / ProcentDelta);
            if (d1 >= 10)
            {
                return false;
            }
            return true;
        }
        private decimal SetProfit(decimal price)
        {
            decimal profit = Math.Round(price * ProcentDelta / 100, 5);
            return profit;
        }
        public async void GetHistoryPrints()
        {
            DateTime RealDate = DateTime.UtcNow;
            DateTime CloseTimes = new DateTime(RealDate.Year, RealDate.Month, RealDate.Day, 20, 00, 00);
            
            Debug.WriteLine($"День недели: {CloseTimes.DayOfWeek}");
            if (RealDate < CloseTimes)
            {
                CloseTimes = CloseTimes.AddDays(-1);
            }
            if (CloseTimes.DayOfWeek == DayOfWeek.Sunday)
            {
                CloseTimes = CloseTimes.AddDays(-2);
            }
            if (CloseTimes.DayOfWeek == DayOfWeek.Saturday)
            {
                CloseTimes = CloseTimes.AddDays(-1);
            }
            Debug.WriteLine($"День недели: {CloseTimes.DayOfWeek}");
            if (SettClosePrint.DateClosePrints == CloseTimes)
            {
                ClosePrice = SettClosePrint.ClosePrints;
            }
            else
            {
                foreach (var item in marketInstruments)
                {
                    var j = false;
                    var histTrades = new HistoricalTradesRequest(item.Ticker, CloseTimes, CloseTimes.AddMinutes(1));
                    var tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
                    do
                    {
                        foreach (var trades in tradeTicker.Items)
                        {
                            foreach (var trade in trades.Value)
                            {
                                if (String.Join("", trade.Conditions).IndexOf("M") > -1 && trade.Size >= 1000)
                                {
                                    ClosePrice[trade.Symbol] = trade.Price;
                                    Debug.WriteLine($"Получили цену закрытия: {trade.Symbol}: {JsonSerializer.Serialize(ClosePrice[trade.Symbol])}");
                                    j = true;
                                    break;
                                }
                                else ClosePrice[trade.Symbol] = 0.00m;
                            }
                            if (j)
                            {
                                break;
                            }
                        }
                        if (j)
                        {
                            break;
                        }
                        if (tradeTicker.NextPageToken != null)
                        {
                            histTrades.Pagination.Token = tradeTicker.NextPageToken;
                            tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
                        }
                    } while (tradeTicker.NextPageToken != null && !j);
                }
                Debug.WriteLine($"Получили цену закрытия: {JsonSerializer.Serialize(ClosePrice)}");

                //сохраняем принты закрытия в файл
                SettClosePrint.ClosePrints = ClosePrice;
                SettClosePrint.DateClosePrints = CloseTimes;
                SettClosePrint.SaveSett(SettClosePrint);
            }
        }
        public async Task MarketList()//получение списка тикеров на которые подписываемся
        {
            var i = 0;
            foreach (var item in Terminal.MarketStocks.Instruments)
            {
                if (!BlackList.Contains(item.Ticker) && item.Isin.IndexOf("US") != -1 && item.Ticker.IndexOf("old") == -1 && item.Ticker.IndexOf("@") == -1 && item.Type == InstrumentType.Stock && item.Currency == Currency.Usd)
                {
                    marketInstruments.Add(item);
                }
                if (++i >= Terminal.MarketStocks.Instruments.Count) break;
            }
        }

    }
}
