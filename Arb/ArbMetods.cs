using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Network;
using Tinkoff.Trading.OpenApi.Models;
using System.Diagnostics;
using System.Drawing;
using Alpaca.Markets;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading;

namespace FishingSizes
{
    interface IRowGridArb
    {
        void AppendRowArb(Packet packet, int count);
        void ClearGrid();
    }

    public class Packet: IComparable<Packet>
    {
        public RowGridArb rowgrid;
        public Color color { get; set; }
        public Packet(RowGridArb rowgrid, Color color)
        {
            this.rowgrid = rowgrid;
            this.color = color;
        }
        public int CompareTo(Packet packet)
        {
            if (packet is null) throw new ArgumentException("Некорректное значение параметра");
            return rowgrid.Delta.CompareTo(packet.rowgrid.Delta);
        }
    }

    class ArbMetods
    {
        //string[] BlackList = { "WTTR","BTI","APAM","CMC","HOG","FOLD","LCII", "PBH","DOCS","BIG","AXGN","BTAI","TPTX","SPG","RIVN","POST","MRO","SQSP","FGEN","WH","ADSK","CHWY","AOS","NEM", "LPSN","TRHC","DK","ENR","CUBE","MMC","JJSF","APEI","QCOM", "LPLA","STRA", "BAH", "LEG", "GLW", "VRTX", "MCD", "OI", "MA", "ZY", "VHR", "VIR", "YUMC", "BBY", "QRVO", "ZWS", "JBL", "ICPT", "S", "CHEF", "OIS", "VUZI", "TSLA", "AAPL", "EWBC", "EVRG", "TMUS", "AMTI", "LVS", "CVM", "YY", "ARE", "STAG", "WPC", "DNKN", "MINI", "LKOD@GS", "TCS", "OGZD@GS", "SERV", "HIIQ", "SSA@GS", "BFYT", "KSPI@GS", "VIE", "CY", "FTR", "AVP", "M", "SCCO", "COTY" };
        public List<string> BlackList;
        public List<MarketInstrument> marketInstruments;
        public IRowGridArb RowGridArb1 { get; set; }
        public Settings Sett { get; set; }
        private IAlpacaDataSubscription<IQuote> QuoteSubscription;
        public ConcurrentDictionary<string, IQuote> QuotesAlpaca = new ConcurrentDictionary<string, IQuote>();
        //потоковый объект
        public ConcurrentDictionary<string, OrderbookPayload> QuotesTinkoff = new ConcurrentDictionary<string, OrderbookPayload>();
        //объект по запросу котировок
        public ConcurrentDictionary<string, Orderbook> OrderbookTi = new ConcurrentDictionary<string, Orderbook>();
        public CancellationTokenSource cancelTokenSource;
        public CancellationToken token;
        public List<Packet> packetsShort;
        public List<Packet> packetsLong;


        public ArbMetods(Settings sett, IRowGridArb rowgrid, List<string> blacklist)
        {
                Terminal.Context_Ti.StreamingEventReceived += QuoteReceivedTinkoff;
                Terminal.TiSubscribeCheck = true;
            BlackList = blacklist;  
            Sett = sett;
            marketInstruments = new List<MarketInstrument>();
            RowGridArb1 = rowgrid;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
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
        public string FigiGet(string ticker)//получение FIGI по тикеру из коллекции
        {
            foreach (var item in Terminal.MarketStocks.Instruments)
            {
                if (item.Ticker == ticker)
                    return item.Figi;
            }
            return null;
        }

        public async Task SubscribeQuoteAlpaca(string ticker)//подписка на котировки Alpaca NBBO
        {
            QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(ticker);
            QuoteSubscription.Received += QuoteReceivedAlpaca;
            await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
        }
        public async Task SubscribeQuoteTinkoff(string figi)//подписка на котировки Tinkoff NBBO
        {
            await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.SubscribeOrderbook(figi, 1));
        }
        public async Task<Orderbook> QuoteOrderbookTi(string figi)//получение котировки NBBO Тинокофф
        {
            return await Terminal.Context_Ti.MarketOrderbookAsync(figi, 1);
        }
        private async void GetQuotesTi()//получаем котировки у пустых тикеров
        {
            foreach (var item in marketInstruments)
            {
                if (!QuotesTinkoff.ContainsKey(item.Ticker))
                {
                    //Debug.WriteLine($"Нет стакана: {item.Ticker}");
                    if (item.Ticker.IndexOf("old") == -1)
                    {
                        OrderbookTi[item.Ticker] = await QuoteOrderbookTi(item.Figi);
                        //Debug.WriteLine($"Получили стакан: {JsonSerializer.Serialize(OrderbookTi[item.Ticker])}");
                    }
                    await Task.Delay(600);
                }
            }
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

        public async void SubscribeQuotes()//подписка на котировки с фильтрами NBBO
        {
            var i = 0;
            foreach (var item in marketInstruments)
            {
                    await SubscribeQuoteTinkoff(item.Figi);
                    await SubscribeQuoteAlpaca(item.Ticker);
                    //Debug.WriteLine($"Isin: {item.Isin} : i = {++i}");
            }
            await Task.Delay(5000);
            //GetQuotesTi();
            GetQuotesAlpaca();
            S();
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

        //обработчик полученных котировок nbbo от Tinkoff
        private void QuoteReceivedTinkoff(object sender, StreamingEventReceivedEventArgs e)
        {
            //обработчик сообщений от сокета
            if (e.Response.Event == "orderbook")
            {
                var response = (OrderbookResponse)e.Response;
                var ticker =  TickerGet(response.Payload.Figi);
                QuotesTinkoff[ticker] = response.Payload;
            }
        }
        //обработчик полученных котировок nbbo от Alpaca
        public void QuoteReceivedAlpaca(IQuote quote)
        {
            QuotesAlpaca[quote.Symbol] = quote;
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
                await Task.Delay(3000);
            }   
        }
        //обработчик арбитража
        public void ArbDeveloper()
        {
            packetsShort = new List<Packet>();
            packetsLong = new List<Packet>();

            foreach (var item in marketInstruments)
            {
                var ticker = item.Ticker;
                if (QuotesTinkoff.ContainsKey(item.Ticker))
                {
                    //Debug.WriteLine($"QuotesTinkoff: {ticker} - {JsonSerializer.Serialize(QuotesTinkoff[ticker])}");
                }
                if (QuotesAlpaca.ContainsKey(item.Ticker))
                {
                    //Debug.WriteLine($"QuotesAlpaca: {ticker} - {JsonSerializer.Serialize(QuotesAlpaca[ticker])}");
                }

                if (QuotesAlpaca.ContainsKey(item.Ticker) && QuotesTinkoff.ContainsKey(item.Ticker) && !BlackList.Contains(item.Ticker))
                {

                    if (QuotesTinkoff[item.Ticker].Asks.Count > 0 && QuotesTinkoff[ticker].Bids.Count > 0)
                    {
                        //шортовый арб
                        //var delta_1 = QuotesAlpaca[ticker].BidPrice - QuotesTinkoff[ticker].Asks[0][0];
                        var delta_1 = 0m;
                        if (QuotesTinkoff[ticker].Asks[0][0] < 250 && QuotesTinkoff[ticker].Asks[0][0] > 0 && (QuotesTinkoff[ticker].Asks[0][0] - QuotesTinkoff[ticker].Bids[0][0]) >= 0.03m)
                        {
                            //delta_1 = Math.Round((QuotesAlpaca[ticker].BidPrice * 100 / QuotesTinkoff[ticker].Asks[0][0] - 100), 2); 
                            delta_1 = QuotesAlpaca[ticker].BidPrice - QuotesTinkoff[ticker].Asks[0][0];
                        }
                        

                        if (delta_1 >= SetProfit(QuotesTinkoff[ticker].Asks[0][0]))
                        {
                            if (QuotesTinkoff[ticker].Bids.Count > 0 && QuotesTinkoff[ticker].Asks.Count > 0)
                            {
                                //Debug.WriteLine($"Шортовый арбитраж {ticker} : {delta_1} : {QuotesAlpaca[ticker].BidPrice} : Isin - {item.Isin} : Figi - {item.Figi}");
                                Color color = Color.LightCoral;
                                V1(ticker, delta_1, item, color, packetsShort);
                            }
                        }
                    }

                    if (QuotesTinkoff[item.Ticker].Asks.Count > 0 && QuotesTinkoff[ticker].Bids.Count > 0)
                    {
                        //лонговый арб
                        //var delta_2 = QuotesTinkoff[ticker].Bids[0][0] - QuotesAlpaca[ticker].AskPrice;
                        var delta_2 = 0m;
                        if (QuotesAlpaca[ticker].AskPrice > 0 && (QuotesTinkoff[ticker].Asks[0][0] - QuotesTinkoff[ticker].Bids[0][0]) >= 0.03m)
                        {
                            //delta_2 = Math.Round((QuotesTinkoff[ticker].Bids[0][0] * 100 / QuotesAlpaca[ticker].AskPrice - 100), 2);
                            delta_2 = QuotesTinkoff[ticker].Bids[0][0] - QuotesAlpaca[ticker].AskPrice;
                        }
                       
                        if (delta_2 >= SetProfit(QuotesAlpaca[ticker].AskPrice))
                        {
                            if (QuotesTinkoff[ticker].Bids.Count > 0 && QuotesTinkoff[ticker].Asks.Count > 0)
                            {
                                //Debug.WriteLine($"Лонговый арбитраж {ticker} : {delta_2} : {QuotesAlpaca[ticker].BidPrice} : Isin - {item.Isin} : Figi - {item.Figi}");
                                Color color = Color.LightGreen;
                                V1(ticker, delta_2, item, color, packetsLong);
                            }
                        }
                    }
                }
            }

            void V1(string ticker, decimal delta, MarketInstrument instr, Color color, List<Packet> packets)
            {
                var rowgrid = new RowGridArb(instr.Ticker, (int)QuotesTinkoff[ticker].Asks[0][1], QuotesTinkoff[ticker].Asks[0][0],
                    QuotesAlpaca[ticker].BidPrice, (int)QuotesAlpaca[ticker].BidSize * 100, QuotesAlpaca[ticker].BidExchange, delta, QuotesAlpaca[ticker].AskExchange,
                    (int)QuotesAlpaca[ticker].AskSize * 100, QuotesAlpaca[ticker].AskPrice, QuotesTinkoff[ticker].Bids[0][0], (int)QuotesTinkoff[ticker].Bids[0][1]);
                Packet list = new Packet(rowgrid, color);
                packets.Add(list);
            }

            //итерация и отправка в форму созданного пакета с арбитражами
            
            packetsLong.Sort();
            foreach (var item in packetsLong) 
            RowGridArb1.AppendRowArb(item, packetsLong.Count);

            packetsShort.Sort();
            foreach (var item in packetsShort)
            RowGridArb1.AppendRowArb(item, packetsShort.Count);

        }
        //закрытие окна и отписка
        public async Task UnsubcribeAndClose()
        {
            Terminal.TiSubscribeCheck = false;
            foreach (var item in marketInstruments)
            {
                //отписываемся от котировок Alpaca
                var quoteSub = Terminal.StreamingClient.GetQuoteSubscription(item.Ticker);
                await Terminal.StreamingClient.UnsubscribeAsync(quoteSub);
                quoteSub.Received -= QuoteReceivedAlpaca;
                //Debug.WriteLine($"Отписались Alpaca: {item.Ticker}");
                //отписываемся от Тинькофф котировок
                await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.UnsubscribeOrderbook(item.Figi, 1));
                //Debug.WriteLine($"Отписались Tinkoff: {item.Ticker}");
                Thread.Sleep(5);
            }
        }
        //установка величины профита арбитража
        private decimal SetProfit(decimal price)
        {
            decimal profit = Math.Round(price * 0.0005m + 0.02m, 2);
            return profit;
        }
    }
}

