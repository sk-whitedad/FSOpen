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


namespace FishingSizes
{
    interface IRowGridHistory
    {
        void AppendRow(RowGridHistoryTrade rowgrid);
        int? FiltrTradesLow { get; set; }
        int? FiltrTradesHight { get; set; }
        void SetStatus(string newStatus, Color color);
    }




    class History
    {
        public string Ticker { get; set; }
        public Settings Sett { get; set; }
        public IRowGridHistory RowGridHisrory { get; set; }
        public IQuote Quote { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int VolMin { get; set; }
        public int VolMax { get; set; }

        public History(Settings sett, string ticker, IRowGridHistory rowgrid, DateTime dateFrom, DateTime dateTo, int volMin, int volMax)
        {
            Ticker = ticker;
            Sett = sett;
            RowGridHisrory = rowgrid;
            DateFrom = dateFrom.AddHours(-3);
            DateTo = dateTo.AddHours(-3);
            VolMin = volMin;
            VolMax = volMax;
        }

        public async void DoSomethingAfterConnect()
        {
            PrintHandlerDB prthandlerDB = new();
            DateTime time = DateFrom;
            var t = Ticker.Trim().ToUpper();
            if (DateFrom < DateTo)
            {
                var histTrades = new HistoricalTradesRequest(t, DateFrom, DateTo);
                var tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
                var i = 0;
                Color color;
                do
                {
                    foreach (var trades in tradeTicker.Items)
                    {
                        foreach (var trade in trades.Value)
                        {
                            if (trade.Size >= VolMin && trade.Size <= VolMax)
                            {
                                var exch = Sett.Exchange(trade.Exchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
                                var rowgrid = new RowGridHistoryTrade(trade.Price, trade.Size, trade.TimestampUtc.ToLocalTime().ToString(), exch, String.Join("", trade.Conditions));
                                RowGridHisrory.AppendRow(rowgrid);
                            }
                            i++;
                        }
                    }
                    if (tradeTicker.NextPageToken != null)
                    {
                        histTrades.Pagination.Token = tradeTicker.NextPageToken;
                        tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
                    }
                    if (i > 19000)
                    {
                        color = Color.Red;
                        RowGridHisrory.SetStatus("Предел обработки 20000 принтов.", color);
                        break;
                    }
                    color = Color.Green;
                    RowGridHisrory.SetStatus("Обработано " + i.ToString() + " строк.", color);

                } while (tradeTicker.NextPageToken != null);
            }
        }
       
        public async void DoSomethingAfterConnectDB()
        {
            PrintHandlerDB prthandlerDB = new();
            DateTime time = DateFrom;
            var t = Ticker.Trim().ToUpper();
            if (DateFrom < DateTo)
            {
                var histTrades = new HistoricalTradesRequest(t, DateFrom, DateTo);
                var tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
                var i = 0;
                Color color;
                do
                {
                    foreach (var trades in tradeTicker.Items)
                    {
                        foreach (var trade in trades.Value)
                        {
                            if (trade.Size >= VolMin && trade.Size <= VolMax)
                            {
                                var exch = Sett.Exchange(trade.Exchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
                                prthandlerDB.ReceivingPrints(trade);
                            }
                            i++;
                        }
                    }
                    if (tradeTicker.NextPageToken != null)
                    {
                        histTrades.Pagination.Token = tradeTicker.NextPageToken;
                        tradeTicker = await Terminal.DataClient.GetHistoricalTradesAsync(histTrades);
                    }
                    color = Color.Green;
                    RowGridHisrory.SetStatus("Обработано " + i.ToString() + " строк.", color);

                } while (tradeTicker.NextPageToken != null);
            }
        }

    }
}
