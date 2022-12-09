using System;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Models;
using Tinkoff.Trading.OpenApi.Network;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading;

namespace FishingSizes
{
    class PortfolioTinkoff
    {
        //public Portfolio PortfolioTi { get; set; }
        public IRowGridPortfolio RowGrid { get; set; }
        readonly ConcurrentDictionary<string, string> TickerFIGI = new ConcurrentDictionary<string, string>();
        public CancellationTokenSource cancelTokenSource;
        public CancellationToken token;


        public PortfolioTinkoff(IRowGridPortfolio rowgrid)
        {
            RowGrid = rowgrid;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }

        public void LoadPortfolio()
        {
                Terminal.Context_Ti.StreamingEventReceived += Context_Ti_StreamingEventReceived;
        }

        public async Task SubscribeCandleTi()
        {
            for (int i = 0; i < Terminal.PortfolioTi.Positions.Count; i++)
            {
                TickerFIGI[Terminal.PortfolioTi.Positions[i].Figi] = Terminal.PortfolioTi.Positions[i].Ticker;
                await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.SubscribeCandle(Terminal.PortfolioTi.Positions[i].Figi, CandleInterval.Day));
                Terminal.TickersListCandlesTi.Add(Terminal.PortfolioTi.Positions[i].Ticker);
            }
            UpdateTable();
        }

        private void Context_Ti_StreamingEventReceived(object sender, StreamingEventReceivedEventArgs e)
        {
            if (e.Response.Event == "candle")
            {
                var ore = (CandleResponse)e.Response;
                string _ticker = TickerFIGI[ore.Payload.Figi];
                var price = ore.Payload.Close;
                var summa = Terminal._RowGridPortfolio[_ticker].Summ;
                var profit = (ore.Payload.Close - Terminal._RowGridPortfolio[_ticker].Middle) * Terminal._RowGridPortfolio[_ticker].Count;
                if (_ticker == "USD000UTSTOM")
                {
                    //_ticker = "USD";
                    summa = Math.Round((price * Terminal._RowGridPortfolio[_ticker].Count), 2);
                    profit = Math.Round((price * Terminal._RowGridPortfolio[_ticker].Count) - (Terminal._RowGridPortfolio[_ticker].Middle * Terminal._RowGridPortfolio[_ticker].Count), 2);
                }
                var rowgrid = new RowGridPortfolio(_ticker, Terminal._RowGridPortfolio[_ticker].Count, Terminal._RowGridPortfolio[_ticker].Middle, summa, Math.Abs(Terminal._RowGridPortfolio[_ticker].Block), Math.Round(Terminal._RowGridPortfolio[_ticker].Accessibly), price, profit);
                //Debug.WriteLine($"Сообщение от сокета: {_ticker} : {ore.Payload.Close}");
                Terminal._RowGridPortfolio[_ticker] = rowgrid;
                //Debug.WriteLine($"_RowGridPortfolio: {_ticker} : {_RowGridPortfolio[_ticker].Price} - {_RowGridPortfolio[_ticker].Profit}");
            }
        }

        private async void UpdateTable()
        {
            await Task.Delay(50);
            foreach (var row in Terminal._RowGridPortfolio)
            {
                RowGrid.UpdateRow((RowGridPortfolio)row.Value);
            }
            while (true)
            {
                if (token.IsCancellationRequested)//если закрывем форму то выходим из метода
                {
                    return;
                }
                foreach (var row in Terminal._RowGridPortfolio)   
                {
                    RowGrid.UpdateRow((RowGridPortfolio)row.Value);
                    Debug.WriteLine($"_RowGridPortfolio: {row.Key} : {row.Value} - {row.Value.Profit}");
                }
                await Task.Delay(5000);
            }
        }

        public void SendPortfolioToForm()
        {
            for (int i = 0; i < Terminal.PortfolioTi.Positions.Count; i++)
            {
                string ticker;
                decimal summa;
                decimal access;
                decimal price = 0;
                decimal profit = 0;
                if (Terminal.PortfolioTi.Positions[i].Balance < 0)
                {
                    access = Terminal.PortfolioTi.Positions[i].Balance;
                }else  access = Terminal.PortfolioTi.Positions[i].Balance - Math.Abs(Terminal.PortfolioTi.Positions[i].Blocked);

                ticker = Terminal.PortfolioTi.Positions[i].Ticker;
                summa = Math.Round((Terminal.PortfolioTi.Positions[i].Balance * Terminal.PortfolioTi.Positions[i].AveragePositionPrice.Value), 2);//правильно будет Баланс  умножить на последнюю цену
                var rowgrid = new RowGridPortfolio(ticker, Terminal.PortfolioTi.Positions[i].Balance, Terminal.PortfolioTi.Positions[i].AveragePositionPrice.Value, summa, Math.Abs(Terminal.PortfolioTi.Positions[i].Blocked), access, price, profit);
                Terminal._RowGridPortfolio[ticker] = rowgrid;
                RowGrid.AppendRow((RowGridPortfolio)rowgrid);
            }

            decimal accessRub = Terminal.positionRub.Balance - Terminal.positionRub.Blocked;
            var rowgridRub = new RowGridPortfolio(Terminal.positionRub.Name, Terminal.positionRub.Balance, 0, 0, Terminal.positionRub.Blocked, accessRub, 0, 0);
            RowGrid.AppendRow((RowGridPortfolio)rowgridRub);

        }

        public async Task UnsubscribeCandles()
        {
            for (int i = 0; i < Terminal.PortfolioTi.Positions.Count; i++)
            {
                await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.UnsubscribeCandle(Terminal.PortfolioTi.Positions[i].Figi, CandleInterval.Day));
                Terminal.Context_Ti.StreamingEventReceived -= Context_Ti_StreamingEventReceived;
                Terminal.TickersListCandlesTi.Remove(Terminal.PortfolioTi.Positions[i].Ticker);
            }
        }
    }
}
