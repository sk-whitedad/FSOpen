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


namespace FishingSizes
{
    interface IRowGridQuotes
    {
        void AppendRowQ(RowGridQuotes rowgridQ);
        void SetSprad(string newSprad);
    }




    class Quotes
    {
        public bool FirstConnect;
        private IAlpacaDataSubscription<IQuote> QuoteSubscription;
        public string Ticker { get; set; }
        public Settings Sett { get; set; }
        public IRowGridQuotes RowGridQuotes { get; set; }


        public Quotes(Settings sett, string ticker, IRowGridQuotes rowgrid)
        {
            Ticker = ticker;
            Sett = sett;
            RowGridQuotes = rowgrid;
            FirstConnect = true;
        }


        //Когда авторизация и подключение выполнены успешно подписываемся на потоки данных
        public async void DoSomethingAfterConnect()
        {
            var t = Ticker.Trim().ToUpper();
            QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(t);
            if (FirstConnect)
            {
                QuoteSubscription.Received += QuoteReceived;
            }
            await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
        }

        //обработчик полученных принтов
        public void QuoteReceived(IQuote quote)
        {
            //Обработка принтов
            var exchBid = Sett.Exchange(quote.BidExchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
            var exchAsk = Sett.Exchange(quote.AskExchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
            var rowgrid = new RowGridQuotes(quote.BidExchange, quote.BidPrice, quote.BidSize * 100, quote.AskSize * 100, quote.AskPrice, quote.AskExchange);
            var sprad = quote.AskPrice - quote.BidPrice;
            RowGridQuotes.AppendRowQ(rowgrid);
            RowGridQuotes.SetSprad(sprad.ToString());

        }

        public async void Unsubscribe(string ticker)
        {
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
            }
            catch
            {
            }
        }

        public async void Subscribe(string ticker)
        {
            try
            {//получаем котировку NBBO по тикеру
                LatestMarketDataRequest DataClientMarcetData = new(ticker);
                var quote = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
                var rowgrid = new RowGridQuotes(quote.BidExchange, quote.BidPrice, quote.BidSize * 100, quote.AskSize * 100, quote.AskPrice, quote.AskExchange);
                var sprad = quote.AskPrice - quote.BidPrice;
                RowGridQuotes.AppendRowQ(rowgrid);
                RowGridQuotes.SetSprad(sprad.ToString());
            }
            catch 
            {
            }

            QuoteSubscription = Terminal.StreamingClient.GetQuoteSubscription(ticker);
            QuoteSubscription.Received += QuoteReceived;
            await Terminal.StreamingClient.SubscribeAsync(QuoteSubscription);
            Terminal.TickersListQuote.Add(ticker);
        }



    }
}
