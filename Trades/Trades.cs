using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alpaca.Markets;
using System.Drawing;
using System.Collections.Concurrent;
using System.Media;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

namespace FishingSizes
{
    interface IRowGrid
    {
        void AppendRow(RowGrid rowgrid, Color colorPrint, (int, int) ls);
        void AppendRowQ(RowGridQuotes rowgridQ);
        
        int? FiltrTradesLow { get; set; }
        int? FiltrTradesHight { get; set; }
        void SetSprad(string newSprad);
    }

    interface IQuotesIBOrder
    {
        void AppendQuotes(decimal ask, decimal bid);
    }
    interface ISPB_US_Term
    {
        void AppendQuotes(decimal ask, decimal bid);
        void SetStatus(string newStatus);
    }




    class Trades
    {
        public bool FirstConnect;
        private IAlpacaDataSubscription<ITrade> TradeSubscription;
        private IAlpacaDataSubscription<IQuote> QuoteSubscription;
        public string Ticker { get; set; }
        public Settings Sett { get; set; }
        public IRowGrid RowGrid { get; set; }
        public IQuote Quote { get; set; }
        public IQuote QuoteOld { get; set; }
        public IQuotesIBOrder IquoteIB { get; set; }
        public ISPB_US_Term Spb_Us_Term { get; set; }
        public CancellationTokenSource cancelTokenSource;
        public CancellationToken token;
        LS_Trade ls_trade;
        (int L, int S) LS;
        private int coeff = 1000;
        private int vol_print_LS = 1000;

        public Trades(Settings sett, string ticker, IRowGrid rowgrid)
        {
            Ticker = ticker.Trim().ToUpper(); ;
            Sett = sett;
            RowGrid = rowgrid;
            FirstConnect = true;
        }
        public Trades(string ticker, IQuotesIBOrder iquoteIB)
        {
            Ticker = ticker.Trim().ToUpper();
            IquoteIB = iquoteIB;
            FirstConnect = true;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }
        public Trades(string ticker, ISPB_US_Term ispb_us_term)
        {
            Ticker = ticker.Trim().ToUpper();
            Spb_Us_Term = ispb_us_term;
            FirstConnect = true;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            Debug.WriteLine($"Начало работы");

        }
        //Когда авторизация и подключение выполнены успешно подписываемся на потоки данных
        public async void DoSomethingAfterConnect()
        {
             var t = Ticker.Trim().ToUpper();
            TradeSubscription = Terminal.StreamingClient.GetTradeSubscription(t);
            QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(t);
            if (FirstConnect)
            {
                TradeSubscription.Received += TradeReceived;
                QuoteSubscription.Received += QuoteReceived;
            }
             await Terminal.StreamingClient.SubscribeAsync(TradeSubscription);
             //await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
        }

        //обработчик полученных принтов
        public void TradeReceived(ITrade trade)
        {
            var colorPrint = Color.Black;
            //установка цвета принта
            if (Quote != null)
            {
                if (trade.Price > Quote.BidPrice && trade.Price < Quote.AskPrice)
                {
                    colorPrint = Color.Black;
                }
                if (trade.Price == Quote.BidPrice)
                {
                    colorPrint = Color.DarkRed;
                    if (trade.Exchange == "N" || trade.Exchange == "P" || trade.Exchange == "Q")//принты только насдак арка и нюс
                    {
                        if (trade.Size < vol_print_LS)
                        {
                            LS = ls_trade.LS_Calc(0, (int)trade.Size);//расчет процентного соотношения цветных принтов
                        }
                    }
                }
                if (trade.Price == Quote.AskPrice)
                {
                    colorPrint = Color.Green;
                    if (trade.Exchange == "N" || trade.Exchange == "P" || trade.Exchange == "Q")
                    {
                        if (trade.Size < vol_print_LS)
                        {
                            LS = ls_trade.LS_Calc((int)trade.Size, 0);//расчет процентного соотношения цветных принтов
                        }
                    }
                }
                if (trade.Price < Quote.BidPrice)
                {
                    colorPrint = Color.DeepPink;
                    if (trade.Exchange == "N" || trade.Exchange == "P" || trade.Exchange == "Q")
                    {
                        if (trade.Size < vol_print_LS)
                        {
                            LS = ls_trade.LS_Calc(0, (int)trade.Size);//расчет процентного соотношения цветных принтов
                        }
                    }
                }
                if (trade.Price > Quote.AskPrice)
                {
                    colorPrint = Color.DarkCyan;
                    if (trade.Exchange == "N" || trade.Exchange == "P" || trade.Exchange == "Q")
                    {
                        if (trade.Size < vol_print_LS)
                        {
                            LS = ls_trade.LS_Calc((int)trade.Size, 0);//расчет процентного соотношения цветных принтов
                        }
                    }
                }
            }
            
            //Обработка принтов
            string seconds()//добавление секунд к принтам, так как они поступают без них
            {
                var s = DateTime.UtcNow.Second.ToString();
                if (s.Length == 1)
                {
                    s = "0" + s;
                }
                return s;
            } 
            var exch = Sett.Exchange(trade.Exchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
            var time = trade.TimestampUtc.ToLocalTime().ToShortTimeString() + ":" + seconds();
            
            if (RowGrid.FiltrTradesLow == null && RowGrid.FiltrTradesHight == null)//если поля фильтра пустые
            {
                var rowgrid = new RowGrid(trade.Price, trade.Size, time, exch, String.Join("", trade.Conditions));
                RowGrid.AppendRow((RowGrid)rowgrid, colorPrint, LS);
                //Debug.WriteLine($"Сообщение 1: {RowGrid.FiltrTradesLow} : {RowGrid.FiltrTradesHight}");
            }
            if (trade.Size >= RowGrid.FiltrTradesLow && trade.Size <= RowGrid.FiltrTradesHight)//если выставлены оба фильтра размера принтов
            {
                var rowgrid = new RowGrid(trade.Price, trade.Size, time, exch, String.Join("", trade.Conditions));
                RowGrid.AppendRow((RowGrid)rowgrid, colorPrint, LS);
                //Debug.WriteLine($"Сообщение 2: {RowGrid.FiltrTradesLow} : {RowGrid.FiltrTradesHight}");
            }
            if (trade.Size >= RowGrid.FiltrTradesLow && RowGrid.FiltrTradesHight == null)//если выставлен минимальный размер принта
            {
                var rowgrid = new RowGrid(trade.Price, trade.Size, time, exch, String.Join("", trade.Conditions));
                RowGrid.AppendRow((RowGrid)rowgrid, colorPrint, LS);
                //Debug.WriteLine($"Сообщение 3: {RowGrid.FiltrTradesLow} : {RowGrid.FiltrTradesHight}");
            }
            if (RowGrid.FiltrTradesLow == null && trade.Size <= RowGrid.FiltrTradesHight)//если выставлен максимальный размер принта
            {
                var rowgrid = new RowGrid(trade.Price, trade.Size, time, exch, String.Join("", trade.Conditions));
                RowGrid.AppendRow((RowGrid)rowgrid, colorPrint, LS);
                //Debug.WriteLine($"Сообщение 4: {RowGrid.FiltrTradesLow} : {RowGrid.FiltrTradesHight}");
            }
            
            Debug.WriteLine($"Принт: {trade.Price} : {trade.Size} : {trade.TimestampUtc}");
        }

        //обработчик полученных котировок
        public void QuoteReceived(IQuote quote)
        {
            //Обработка котировок NBBO
            Quote = quote;
            if (QuoteOld == null)
            {
                QuoteOld = quote;
            }
            if (quote.BidPrice != QuoteOld.BidPrice || quote.AskPrice != QuoteOld.AskPrice || quote.BidSize != QuoteOld.BidSize || quote.AskSize != QuoteOld.AskSize)
            {
                //Обработка принтов
                //            var exchBid = Sett.Exchange(quote.BidExchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
                //            var exchAsk = Sett.Exchange(quote.AskExchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
                var rowgrid = new RowGridQuotes(quote.BidExchange, quote.BidPrice, quote.BidSize * 100, quote.AskSize * 100, quote.AskPrice, quote.AskExchange);
                var sprad = quote.AskPrice - quote.BidPrice;
                RowGrid.AppendRowQ(rowgrid);
                RowGrid.SetSprad(sprad.ToString());
            }
            QuoteOld = quote;
        }
        public void QuoteIBOrder_Received(IQuote quote)
        {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                Quote = quote;
                IquoteIB.AppendQuotes(quote.AskPrice, quote.BidPrice);
        }
        public void QuoteReceived_SPB_US_Term(IQuote quote)
        {
                if (token.IsCancellationRequested)
                {
                    Debug.WriteLine($"IsCancellationRequested {token.IsCancellationRequested}");
                    return;
                }
                Quote = quote;
                Spb_Us_Term.AppendQuotes(quote.AskPrice, quote.BidPrice);
        }
        //отписка от потока данных
        public async Task UnsubscribeTrades(string ticker)
        {
            try
            {
                int i = 0;
                foreach (var t in Terminal.TickersList)
                {
                    if (t == ticker)
                    {
                        ++i;
                    }
                }
                if(i == 1)
                {
                    await Terminal.StreamingClient.UnsubscribeAsync(TradeSubscription);
                    TradeSubscription.Received -= TradeReceived;
                }
                Terminal.TickersList.Remove(ticker);
            }
            catch 
            {
            }
        }
        public async Task UnsubscribeQuotes(string ticker)
        {
            Debug.WriteLine($"Список TickersListQuote до отписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
            try
            {
                int i = 0;
                foreach (var t in Terminal.TickersListQuote)
                {
                    if (t == ticker)
                    {
                        ++i;
                    }
                }
                if (i == 1)
                {
                    await Terminal.StreamingClient.UnsubscribeAsync(QuoteSubscription);
                    QuoteSubscription.Received -= QuoteReceived;
                }
                Terminal.TickersListQuote.Remove(ticker);
                Debug.WriteLine($"Список TickersListQuote после отписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");

            }
            catch
            {
            }
        }
        public async void UnsubscribeQuotesNew(string ticker)
        {
            try
            {
                Debug.WriteLine($"Список TickersListQuote до отписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
                await Terminal.StreamingClient.UnsubscribeAsync(QuoteSubscription);
                QuoteSubscription.Received -= QuoteIBOrder_Received;
                Terminal.TickersListQuote.Remove(ticker);
                Debug.WriteLine($"Список TickersListQuote после отписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
            }
            catch
            {
            }
        }
        public async void UnsubscribeQuotes_SPB_US_Term(string ticker)
        {
            try
            {
                Debug.WriteLine($"Список TickersListQuote до отписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
                await Terminal.StreamingClient.UnsubscribeAsync(QuoteSubscription);
                QuoteSubscription.Received -= QuoteReceived_SPB_US_Term;
                Terminal.TickersListQuote.Remove(ticker);
                Debug.WriteLine($"Список TickersListQuote после отписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
            }
            catch
            {
            }
        }
        //подписка на поток данных
        public async void Subscribe(string ticker)
        {
            Debug.WriteLine($"Список TickersListQuote до подписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
            Ticker = ticker;
            try
            {//получаем котировку NBBO по тикеру
                //var quote = new LatestMarketDataRequest(ticker);
                LatestMarketDataRequest DataClientMarcetData = new(Ticker);
                var quote = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
                if (quote != null)
                {
                    var rowgrid = new RowGridQuotes(quote.BidExchange, quote.BidPrice, quote.BidSize * 100, quote.AskSize * 100, quote.AskPrice, quote.AskExchange);
                    var sprad = quote.AskPrice - quote.BidPrice;
                    RowGrid.AppendRowQ(rowgrid);
                    RowGrid.SetSprad(sprad.ToString());
                    var hourOpenOS = new DateTime(DateTime.UtcNow.AddHours(-4).Year, DateTime.UtcNow.AddHours(-4).Month, DateTime.UtcNow.AddHours(-4).Day, 9, 30, 00);
                    var hourCloseOS = new DateTime(DateTime.UtcNow.AddHours(-4).Year, DateTime.UtcNow.AddHours(-4).Month, DateTime.UtcNow.AddHours(-4).Day, 16, 00, 00);
                    if (DateTime.UtcNow.AddHours(-4) > hourOpenOS && DateTime.UtcNow.AddHours(-4) > hourCloseOS)
                    {
                        GetHistoryPrints();
                    }
                }
            }
            catch
            {
            }
                TradeSubscription = Terminal.StreamingClient.GetTradeSubscription(ticker);
                QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(ticker);
                TradeSubscription.Received += TradeReceived;
                QuoteSubscription.Received += QuoteReceived;
                await Terminal.StreamingClient.SubscribeAsync(TradeSubscription);
                await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
                Terminal.TickersList.Add(ticker);
                Terminal.TickersListQuote.Add(ticker);
            ls_trade = new LS_Trade(coeff);
            Debug.WriteLine($"Список TickersListQuote после подписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
        }

        public async void SubscribeQuotes(string ticker)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            Debug.WriteLine($"Список TickersListQuote до подписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
            LatestMarketDataRequest DataClientMarcetData = new(ticker);

            var quote = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
            IquoteIB.AppendQuotes(quote.AskPrice, quote.BidPrice);
            QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(ticker);
            QuoteSubscription.Received += QuoteIBOrder_Received;
            await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
            Terminal.TickersListQuote.Add(ticker);
            Debug.WriteLine($"Список TickersListQuote после подписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
        }

        public async void SubscribeQuotes_SPB_US_Term(string ticker)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            Debug.WriteLine($"Список TickersListQuote до подписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
            LatestMarketDataRequest DataClientMarcetData = new(ticker);
            var quote = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
            Spb_Us_Term.AppendQuotes(quote.AskPrice, quote.BidPrice);
            QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(ticker);
            QuoteSubscription.Received += QuoteReceived_SPB_US_Term;
            await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
            Terminal.TickersListQuote.Add(ticker);
            Debug.WriteLine($"Список TickersListQuote после подписки {JsonSerializer.Serialize(Terminal.TickersListQuote)}");
        }

        public async void GetHistoryPrints()
        {
            List<RowGrid> rowGridList;
            DateTime DateTo = DateTime.UtcNow;
            int k = -1;
            do
            {
                rowGridList = await ParcePrints(DateTo, k);
                k = k - 10;
            } while (rowGridList.Count < 100);
 
            //выводим в таблицу строки из rowGridList
            Color color = Color.Gray;
            foreach (var rowgrid in rowGridList)
               {

                  RowGrid.AppendRow(rowgrid, color, LS);
               }
        }

        async Task <List<RowGrid>> ParcePrints(DateTime DateTo, int k)
        {
            List<RowGrid> rowGridList = new List<RowGrid>();
            var histTrades = new HistoricalTradesRequest(Ticker, DateTo.AddMinutes(k), DateTo);
            var tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
            var i = 1;

            do
            {
                foreach (var trades in tradeTicker.Items)
                {
                    foreach (var trade in trades.Value)
                    {
                        var exch = Sett.Exchange(trade.Exchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
                        var rowgrid = new RowGrid(trade.Price, trade.Size, trade.TimestampUtc.ToLocalTime().ToString(), exch, String.Join("", trade.Conditions));
                        rowGridList.Add(rowgrid);
                        i++;
                    }
                }
                if (tradeTicker.NextPageToken != null)
                {
                    histTrades.Pagination.Token = tradeTicker.NextPageToken;
                    tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
                }
            } while (tradeTicker.NextPageToken != null);


            if (i > 100)
            {
                List<RowGrid> rowGridList1 = new List<RowGrid>();
                for (int j = 0; j < 100; j++)
                {
                    rowGridList1.Add(rowGridList[rowGridList.Count - (100 - j)]);
                }
                return rowGridList1;
            }else  return rowGridList;
        }

    }
}
