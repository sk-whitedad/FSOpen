using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Network;
using Tinkoff.Trading.OpenApi.Models;
using System.Diagnostics;
using System.Threading;

namespace FishingSizes
{
    public class TinkoffMy
    {
        public string Ticker { get; set; }
        public string Figi { get; set; }
        public List<string> OrderID = new List<string>();
        public List<Order> OrdersList = new List<Order>();
        public CancellationTokenSource cancelTokenSource;
        public CancellationToken token;


        public TinkoffMy(string ticker)
        {
            Ticker = ticker;
            Figi = FigiGet(ticker);
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }

        public string FigiGet(string ticker)//получение Figi по тикеру из коллекции
        {
            foreach (var item in Terminal.MarketStocks.Instruments)
            {
                if (item.Ticker == ticker)
                    return item.Figi;
            }
            return null;
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

        public bool TickerCheck(string ticker)//проверка тикера правильность названия
        {
            foreach (var item in Terminal.MarketStocks.Instruments)
            {
                if (item.Ticker == ticker)
                    return true;
            }
            return false;
        }

       


        public async Task LimitOrder(string ticker, int lots, OperationType type, decimal price)
        {
            try
            {
                LimitOrder limitorder = new LimitOrder(FigiGet(ticker), lots, type, price, null);
                PlacedLimitOrder order = await Terminal.Context_Ti.PlaceLimitOrderAsync(limitorder);
                OrderID.Add(order.OrderId);
                Debug.Print("OrderId = " + OrderID[OrderID.Count-1]);
            }
            catch
            {
            }

        }

        public async void MarketOrder(string ticker, int lots, OperationType type)
        {
            try
            {
                MarketOrder marketorder = new MarketOrder(FigiGet(ticker), lots, type, null);
                PlacedMarketOrder order = await Terminal.Context_Ti.PlaceMarketOrderAsync(marketorder);
                OrderID.Add(order.OrderId);
                Debug.Print("OrderId = " + OrderID[OrderID.Count - 1]);
            }
            catch
            {
            }
        }

        public async void CancelOrders()
        {
            try
            {
                OrdersList = await Terminal.Context_Ti.OrdersAsync();
                foreach (var id in OrdersList)
                {
                   await Terminal.Context_Ti.CancelOrderAsync(id.OrderId);
                   Debug.Print("Cancel OrderId = " + id.OrderId);
                }
            }
            catch
            {
            }
        }

        public void Dispose()
        {
            
        }

    }
}
