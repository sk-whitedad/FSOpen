using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Tinkoff.Trading.OpenApi.Models;
using Tinkoff.Trading.OpenApi.Network;


namespace FishingSizes
{
    class HistoryOrders
    {
        public IRowGridHistoryOrders RowGrid { get; set; }
        public CancellationTokenSource cancelTokenSource;
        public CancellationToken token;
        public List<Operation> Listoperation;
        public string Ticker;
        IEnumerable<Operation> _Listoperation;

        public HistoryOrders(IRowGridHistoryOrders rowgrid, string ticker)
        {
            RowGrid = rowgrid;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            Ticker = ticker;
        }

        public async Task LoadHistoryOrders()
        {
            DateTime DateFrom = new DateTime();
            DateTime DateTo = DateTime.Now;
            string figi = "";

            foreach (var marketstocks in Terminal.MarketStocks.Instruments)
            {
                if (marketstocks.Ticker == Ticker)
                {
                    figi = marketstocks.Figi;
                }
            }
            if (figi == "")
            {
                return;
            }
            Listoperation = await Terminal.Context_Ti.OperationsAsync(DateFrom, DateTo, figi, null);
            _Listoperation = from l in Listoperation
                                 where l.Status.ToString() == "Done" && l.Payment != 0
                                 select l;
            Listoperation = _Listoperation.ToList();

        }

        public void SendHistoryToForm()
        {
            foreach (var item in Listoperation)
            {
                if (item.OperationType.ToString() != "BrokerCommission")
                {
                    var rowgrid = new RowGridHistoryOrders(Ticker, item.Date, item.Quantity, item.Price, item.Payment, item.OperationType.ToString());
                    RowGrid.AppendRow((RowGridHistoryOrders)rowgrid);
                }
            }
        }
    }
}
