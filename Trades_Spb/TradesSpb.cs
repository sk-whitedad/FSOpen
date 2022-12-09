using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Diagnostics;

namespace FishingSizes
{
    interface IRowGridSpb
    {
        void AppendRow(RowGridSpb rowgrid, Color colorPrint, string sprad, (int, int) ls);
        int? FiltrTradesLow { get; set; }
        int? FiltrTradesHight { get; set; }
    }

    //процентное соотношение зеленых и красных принтов


    class TradesSpb
    {
        public string Ticker { get; set; }
        public Settings Sett { get; set; }
        public IRowGridSpb RowGrid { get; set; }
        public AlorOrderbookData AlorOrderbookDataL1;
        public string sprad;
        LS_Trade ls_trade;
        (int L, int S) LS;
        private int coeff = 10;

        public TradesSpb(Settings sett, string ticker, IRowGridSpb rowgrid)
        {
            Ticker = ticker.Trim().ToUpper(); ;
            Sett = sett;
            RowGrid = rowgrid;
            sprad = "";
        }

        public async void Subscribe(string ticker)
        {
            Terminal.alorProvider.OnOrderbookReceived += _OrderbookReceived;
            Terminal.alorProvider.OnTradeReceived += _TradesReceived;
            await Terminal.alorProvider.SubscribeOrderbook(ticker);
            await Terminal.alorProvider.SubscribeTrades(ticker);
            ls_trade = new LS_Trade(coeff);
        }

        private void _OrderbookReceived(object sender, AlorOrderbook e)
        {
            var oldsprad = sprad;
            AlorOrderbookDataL1 = e.data;
            sprad = string.Format("{0:f2}", (AlorOrderbookDataL1.asks[0].price - AlorOrderbookDataL1.bids[0].price));
            if (oldsprad != sprad)
            {
                var rowgrid = new RowGridSpb(0, 0, 0, null);
                RowGrid.AppendRow((RowGridSpb)rowgrid, Color.Empty, sprad, LS);
            }
            //Debug.WriteLine($"orderbook received: {e.data.symbol} - {e.data.bids[0].price}");
        }

        private void _TradesReceived(object sender, AlorTrade e)
        {
            var colorPrint = Color.Black;
            var summ = (decimal)(e.data.qty * e.data.price);
            var rowgrid = new RowGridSpb((decimal)(e.data.price), e.data.qty, summ, e.data.time.ToLongTimeString().ToString());
            if (e.data.price > AlorOrderbookDataL1.bids[0].price && e.data.price < AlorOrderbookDataL1.asks[0].price)
            {
                colorPrint = Color.Black;
            }
            if (e.data.price <= AlorOrderbookDataL1.bids[0].price)
            {
                colorPrint = Color.Red;
                LS = ls_trade.LS_Calc(0, e.data.qty);
                
            }
            if (e.data.price >= AlorOrderbookDataL1.asks[0].price)
            {
                colorPrint = Color.Green;
                LS = ls_trade.LS_Calc(e.data.qty, 0);
            }
            RowGrid.AppendRow((RowGridSpb)rowgrid, colorPrint, sprad, LS);
            //Debug.WriteLine($"trade received: {e.data.symbol} - {e.data.price} - {e.data.time} - {e.data.qty}");
        }

        public async void UnsubscribeTrades(string ticker)
        {
            Terminal.alorProvider.OnTradeReceived -= _TradesReceived;
            await Terminal.alorProvider.UnSubscribe(ticker, AlorWsMessageType.Trades);
        }
        public async void UnsubscribeQuotes(string ticker)
        {
            Terminal.alorProvider.OnOrderbookReceived -= _OrderbookReceived;
            await Terminal.alorProvider.UnSubscribe(ticker, AlorWsMessageType.Orderbook);
        }


    }
}
