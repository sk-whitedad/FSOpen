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
using System.Diagnostics;
using System.Windows.Forms;

namespace FishingSizes
{

    public interface IStatusLog
    {
        void SetStatus(string newStatus);
        void AppendLog(string text);
        void ColorTextLog(Color color);
        void ConnectStatus(string filename, ToolStripStatusLabel tsStatus);
    }

    public interface IActivateForm
    {
        void SetActivate(bool activate, string name);
    }


    public class Connecting: Terminal
    {
        public bool FirstConnect;
        readonly IStatusLog StatusLog;

        public Connecting(IStatusLog statusLog)
        {
            StatusLog = statusLog;
            FirstConnect = true;
        }
        public async void SubscribeConnect(IAlpacaDataStreamingClient client)
        {
                    client.OnError += k =>
                    {
                        StatusLog.ColorTextLog(Color.Red);
                        StatusLog.AppendLog("Alpaca API ERROR:" + k.Message);
                        StatusLog.ConnectStatus("NoConnect.png", tsAlpaca);
                    };
                    client.SocketOpened += () =>
                    {
                        StatusLog.ColorTextLog(Color.Lime);
                        StatusLog.AppendLog("Alpaca socket opened.");
                        Terminal.AlpacaConnected = true;
                        //StatusLog.SetStatus("Socket opened.");
                    };
                    client.SocketClosed += async () =>
                    {
                        StatusLog.ColorTextLog(Color.Cyan);
                        StatusLog.AppendLog("Alpaca socket closed.");
                        StatusLog.SetStatus("Alpaca socket closed.");
                        await client.ConnectAndAuthenticateAsync();
                    };
                   client.Connected += (authStatus) =>
                    {
                        if (authStatus == AuthStatus.Authorized)
                        {
                            StatusLog.ConnectStatus("Connect.png", tsAlpaca);
                            StatusLog.ColorTextLog(Color.LightSlateGray);
                            StatusLog.AppendLog($"Alpaca connected with status: {authStatus}");
                            FirstConnect = false;
                        }
                        else
                        {
                            StatusLog.ConnectStatus("NoConnect.png", tsAlpaca);
                            StatusLog.ColorTextLog(Color.LightCoral);
                            StatusLog.AppendLog("Авторизация Alpaca не выполнена!");
                            StatusLog.SetStatus("Authorization Alpaca failed!");
                            Terminal.AlpacaConnected = false;
                        }
                    };
                  await client.ConnectAndAuthenticateAsync();
        }
    }

    public class SubscribeFishing : IDisposable
    {
        public ConcurrentDictionary<string, ITrade> tradeAllTickersO = new ConcurrentDictionary<string, ITrade>();//принт открытия ОС
        public ConcurrentDictionary<string, ITrade> tradeAllTickersM = new ConcurrentDictionary<string, ITrade>();//принт закрытия ОС
        public ConcurrentDictionary<string, IQuote> dataAllTickers = new ConcurrentDictionary<string, IQuote>();
        public ConcurrentDictionary<string, ITrade> tradeAllTickers100 = new ConcurrentDictionary<string, ITrade>();
        public ConcurrentDictionary<string, ITrade> tradeAllTickersX = new ConcurrentDictionary<string, ITrade>();
        public bool FirstConnect;
        readonly IStatusLog StatusLog;
        private readonly Settings Sett;
        private readonly List<string> TickersListConsole = new List<string>();
        public bool disposed = false;
        private IAlpacaDataStreamingClient streamingClient;
        public SubscribeFishing(Settings sett, IStatusLog statusLog)
        {
            Sett = sett;
            StatusLog = statusLog;
            FirstConnect = true;
        }
        public void Dispose()
        {
            disposed = true;
            UnsubscribeAll();
        }
        //Когда авторизация и подключение выполнены успешно подписываемся на потоки данных
        public async void DoSomethingAfterConnect(IAlpacaDataStreamingClient client, Settings settings)
        {
            string[] tickers = settings.TickersList.Split(',');
            streamingClient = client;
            foreach (var ticker in tickers)
            {
                var t = ticker.Trim().ToUpper();
                StatusLog.SetStatus("Подписываемся на тикер - " + t);
                var tradeSub = client.GetTradeSubscription(t);
                var quoteSub = client.GetQuoteSubscription(t);
                if (FirstConnect)
                {
                    tradeSub.Received += TradeReceived;
                    quoteSub.Received += QuoteReceived;
                }
                await client.SubscribeAsync(tradeSub);
                await client.SubscribeAsync(quoteSub);
                Terminal.TickersList.Add(ticker);
                TickersListConsole.Add(ticker);
                await Task.Delay(10);
            }
        }
        //обработчик полученных принтов
        public void TradeReceived(ITrade trade)
        {
            if (disposed)
            {
                Debug.WriteLine($"{ DateTime.Now.ToLongTimeString() } { nameof(TradeReceived) } called after disposing.");
                return;
            }
            //Обработка принтов
            var exch = Sett.Exchange(trade.Exchange);//string преобразованный из полученного символа от пришедшего пакета. Например "D" -> "ARCA" итд.
            string[] exchArr = Sett.Exch.Split(',');//массив string из настроек "ARCA" итд.
            if (Sett.Pair == true)
                TradePair_Q_QD(exch, trade);
            else
            {
                if (Sett.FPrints && String.Join("", trade.Conditions).Contains("F"))
                    TradeNoPair(exch, exchArr, trade);
                if (!Sett.FPrints)
                    TradeNoPair(exch, exchArr, trade);
            }

            if (String.Join("", trade.Conditions).Contains("O"))//ловим принт открытия с символом О
            {
                StatusLog.AppendLog(trade.Symbol + ":  " + trade.Price + "  -  " + trade.Size + "  -  " + exch);
                StatusLog.SetStatus(trade.Symbol + ":  " + trade.Price + "  -  " + trade.Size + "  -  " + exch);
                tradeAllTickersO[trade.Symbol] = trade;
            }
            if (String.Join("", trade.Conditions).Contains("M"))//ловим принт закрытия с символом M
            {
                StatusLog.AppendLog(trade.Symbol + ":  " + trade.Price + "  -  " + trade.Size + "  -  " + exch);
                StatusLog.SetStatus(trade.Symbol + ":  " + trade.Price + "  -  " + trade.Size + "  -  " + exch);
                tradeAllTickersM[trade.Symbol] = trade;
            }
        }
        public async void TradePair_Q_QD(string exch, ITrade trade)
        {
            if (disposed)
            {
                Debug.WriteLine($"{ DateTime.Now.ToLongTimeString() } { nameof(TradePair_Q_QD) } called after disposing.");
                return;
            }

            if (String.Join("", trade.Conditions).Contains("F") && !tradeAllTickers100.ContainsKey(trade.Symbol) && exch == "FINRA" && trade.Size >= Sett.PrintSizeMin && trade.Size <= Sett.PrintSizeMax && trade.Price >= Sett.PriceMin && trade.Price <= Sett.PriceMax)
            {//ловим сайз
                StatusLog.ColorTextLog(Color.Gray);
                //AppendLog("Поймали сайз без сотки " + trade.Symbol +"-"+ trade.Exchange +"-"+ trade.Size +"-"+ trade.Price +"-"+ trade.TimestampUtc.ToString("hh:mm:ss"));
                tradeAllTickersX[trade.Symbol] = trade;
            }

            if (!tradeAllTickersX.ContainsKey(trade.Symbol) && trade.Size == 100 && exch == "NASDAQ" && trade.Price >= Sett.PriceMin && trade.Price <= Sett.PriceMax)
            {//ловим сотку
                StatusLog.ColorTextLog(Color.Gray);
                //AppendLog("Поймали сотку без сайза " + trade.Symbol + "-" + trade.Exchange + "-" + trade.Size + "-" + trade.Price + "-" + trade.TimestampUtc.ToString("hh:mm:ss"));
                tradeAllTickers100[trade.Symbol] = trade;
            }



            if (tradeAllTickersX.ContainsKey(trade.Symbol) && trade.Size == 100 && exch == "NASDAQ" && trade.Price >= Sett.PriceMin && trade.Price <= Sett.PriceMax && trade.Price == tradeAllTickersX[trade.Symbol].Price && tradeAllTickersX[trade.Symbol].TimestampUtc.ToString() == trade.TimestampUtc.ToString())
            {//ловим сотку когда сайз пойман
                tradeAllTickers100[trade.Symbol] = trade;
                if (dataAllTickers.ContainsKey(trade.Symbol))
                {
                    StatusLog.ColorTextLog(PrintColor(trade.Price, dataAllTickers[trade.Symbol]));
                }
                else
                {
                    try
                    {
                        LatestMarketDataRequest DataClientMarcetData = new(trade.Symbol);
                        var quoteTicker = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
                        dataAllTickers[trade.Symbol] = quoteTicker;
                        StatusLog.ColorTextLog(PrintColor(trade.Price, dataAllTickers[trade.Symbol]));
                    }
                    catch
                    {
                        StatusLog.AppendLog("Error data load:" + trade.Symbol);
                        StatusLog.ColorTextLog(Color.Gray);
                    }
                }
                if (Sett.Mute) SystemSounds.Beep.Play();
                StatusLog.AppendLog(tradeAllTickers100[trade.Symbol].Symbol + ":" + Str1(trade.Symbol.Length) + tradeAllTickers100[trade.Symbol].Price + "  -  " + tradeAllTickers100[trade.Symbol].Size + "  -  " + Sett.Exchange(tradeAllTickers100[trade.Symbol].Exchange) + "  -  " + tradeAllTickers100[trade.Symbol].TimestampUtc.ToString("hh:mm:ss") + " : " + tradeAllTickers100[trade.Symbol].Tape + ";        " + String.Join("", tradeAllTickers100[trade.Symbol].Conditions));
                StatusLog.AppendLog(tradeAllTickersX[trade.Symbol].Symbol + ":" + Str1(trade.Symbol.Length) + tradeAllTickersX[trade.Symbol].Price + "  -  " + tradeAllTickersX[trade.Symbol].Size + "  -  " + Sett.Exchange(tradeAllTickersX[trade.Symbol].Exchange) + "  -  " + tradeAllTickersX[trade.Symbol].TimestampUtc.ToString("hh:mm:ss") + " : " + tradeAllTickersX[trade.Symbol].Tape + ";        " + String.Join("", tradeAllTickersX[trade.Symbol].Conditions));
                tradeAllTickersX.TryRemove(trade.Symbol, out ITrade t);
                tradeAllTickers100.TryRemove(trade.Symbol, out t);
            }

            if (String.Join("", trade.Conditions).Contains("F") && tradeAllTickers100.ContainsKey(trade.Symbol) && exch == "FINRA" && trade.Size >= Sett.PrintSizeMin && trade.Size <= Sett.PrintSizeMax && trade.Price == tradeAllTickers100[trade.Symbol].Price && trade.TimestampUtc.ToString() == tradeAllTickers100[trade.Symbol].TimestampUtc.ToString())
            {//ловим сайз когда сотка поймана
                tradeAllTickersX[trade.Symbol] = trade;
                if (dataAllTickers.ContainsKey(trade.Symbol))
                {//если получены данные стакана
                    StatusLog.ColorTextLog(PrintColor(trade.Price, dataAllTickers[trade.Symbol]));
                }
                else
                {//получаем стакан
                    try
                    {
                        LatestMarketDataRequest DataClientMarcetData = new(trade.Symbol);
                        var quoteTicker = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
                        dataAllTickers[trade.Symbol] = quoteTicker;
                        StatusLog.ColorTextLog(PrintColor(trade.Price, dataAllTickers[trade.Symbol]));
                    }
                    catch
                    {
                        StatusLog.AppendLog("Error data load:" + trade.Symbol);
                        StatusLog.ColorTextLog(Color.Gray);
                    }
                }
                if (Sett.Mute) SystemSounds.Beep.Play();
                StatusLog.AppendLog(tradeAllTickers100[trade.Symbol].Symbol + ":" + Str1(trade.Symbol.Length) + tradeAllTickers100[trade.Symbol].Price + "  -  " + tradeAllTickers100[trade.Symbol].Size + "  -  " + Sett.Exchange(tradeAllTickers100[trade.Symbol].Exchange) + "  -  " + tradeAllTickers100[trade.Symbol].TimestampUtc.ToString("hh:mm:ss") + " : " + tradeAllTickers100[trade.Symbol].Tape + ";        " + String.Join("", tradeAllTickers100[trade.Symbol].Conditions));
                StatusLog.AppendLog(tradeAllTickersX[trade.Symbol].Symbol + ":" + Str1(trade.Symbol.Length) + tradeAllTickersX[trade.Symbol].Price + "  -  " + tradeAllTickersX[trade.Symbol].Size + "  -  " + Sett.Exchange(tradeAllTickersX[trade.Symbol].Exchange) + "  -  " + tradeAllTickersX[trade.Symbol].TimestampUtc.ToString("hh:mm:ss") + " : " + tradeAllTickersX[trade.Symbol].Tape + ";        " + String.Join("", tradeAllTickersX[trade.Symbol].Conditions));
                tradeAllTickersX.TryRemove(trade.Symbol, out ITrade t);
                tradeAllTickers100.TryRemove(trade.Symbol, out t);
            }

        }
        public async void TradeNoPair(string exch, string[] exchArr, ITrade trade)
        {
            if (disposed)
            {
                Debug.WriteLine($"{ DateTime.Now.ToLongTimeString() } { nameof(TradeNoPair) } called after disposing.");
                return;
            }

            if (Array.Exists(exchArr, element => element == exch) && trade.Size >= Sett.PrintSizeMin && trade.Size <= Sett.PrintSizeMax && trade.Price >= Sett.PriceMin && trade.Price <= Sett.PriceMax)
            {
                if (Sett.Mute) SystemSounds.Beep.Play();
                if (dataAllTickers.ContainsKey(trade.Symbol))
                {
                    StatusLog.ColorTextLog(PrintColor(trade.Price, dataAllTickers[trade.Symbol]));
                }
                else
                {
                    try
                    {
                        LatestMarketDataRequest DataClientMarcetData = new(trade.Symbol);
                        var quoteTicker = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
                        dataAllTickers[trade.Symbol] = quoteTicker;
                        StatusLog.ColorTextLog(PrintColor(trade.Price, dataAllTickers[trade.Symbol]));
                    }
                    catch
                    {
                        StatusLog.AppendLog("Error data load:" + trade.Symbol);
                        StatusLog.ColorTextLog(Color.Gray);
                    }
                }
                StatusLog.AppendLog(trade.Symbol + ":" + Str1(trade.Symbol.Length) + trade.Price + "  -  " + trade.Size + "  -  " + exch + "  -  " + trade.TimestampUtc.ToString("hh:mm:ss") + " : " + trade.Tape + ";        " + String.Join("", trade.Conditions));
            }

        }
        //запись котировки L1 в dataAllTickers
        public void QuoteReceived(IQuote quote)
        {
            if (disposed)
            {
                Debug.WriteLine($"{ DateTime.Now.ToLongTimeString() } { nameof(QuoteReceived) } called after disposing.");
                return;
            }
            //Обработка котировок
            //следим за сужением спреда
            if (Sett.SpradCheck)
            {
                decimal d_s, s_Old;
                try
                {
                    s_Old = dataAllTickers[quote.Symbol].AskPrice - dataAllTickers[quote.Symbol].BidPrice;
                    var s_New = quote.AskPrice - quote.BidPrice;
                    d_s = s_Old / s_New;
                    if (s_Old >= 0.2m)
                    {
                        if (d_s >= 5 && quote.BidPrice == dataAllTickers[quote.Symbol].BidPrice)
                        {
                            StatusLog.ColorTextLog(Color.Red);
                            StatusLog.AppendLog(quote.Symbol + ": Уменьшен спред аском!  " + s_Old + " --> " + s_New);
                        }
                        if (d_s >= 5 && quote.AskPrice == dataAllTickers[quote.Symbol].AskPrice)
                        {
                            StatusLog.ColorTextLog(Color.Green);
                            StatusLog.AppendLog(quote.Symbol + ": Уменьшен спред бидом!  " + s_Old + " --> " + s_New);
                        }
                        if (d_s <= 0.33m && quote.AskPrice == dataAllTickers[quote.Symbol].AskPrice)
                        {
                            StatusLog.ColorTextLog(Color.Red);
                            StatusLog.AppendLog(quote.Symbol + ": Увеличен спред бидом!  " + s_Old + " --> " + s_New);
                        }
                        if (d_s <= 0.33m && quote.BidPrice == dataAllTickers[quote.Symbol].BidPrice)
                        {
                            StatusLog.ColorTextLog(Color.Green);
                            StatusLog.AppendLog(quote.Symbol + ": Увеличен спред аском!  " + s_Old + " --> " + s_New);
                        }

                    }

                }
                catch
                {

                }


            }
            dataAllTickers[quote.Symbol] = quote;
        }
        public void UnsubscribeAll()
        {
            string[] tikersListArr = new string[TickersListConsole.Count]; ;
            TickersListConsole.CopyTo(tikersListArr);
                foreach (var t in tikersListArr)
                {
                    Unsubscribe(t);
                }
        }
        public async void Unsubscribe(string ticker)
        {
            var tradeSub = Terminal.StreamingClient.GetTradeSubscription(ticker);
            var quoteSub = Terminal.StreamingClient.GetQuoteSubscription(ticker);
            int i = 0;
            foreach (var t in Terminal.TickersList)
            {
                if (t == ticker)//проверка на количество подписок на одином тикере
                {
                    ++i;
                }
            }
            if (i == 1)
            {
                await Terminal.StreamingClient.UnsubscribeAsync(tradeSub);//если одна подписка тогда отписываемся, если больше то не отписываемся но удаляем из списка один экземпляр
                await Terminal.StreamingClient.UnsubscribeAsync(quoteSub);
                tradeSub.Received -= TradeReceived;
                quoteSub.Received -= QuoteReceived;
            }
                
            Terminal.TickersList.Remove(ticker);
            TickersListConsole.Remove(ticker);
            StatusLog.SetStatus("Отписались от тикера - " + ticker);
        }
        public async void Subscribe(string ticker)
        {
            if (!Terminal.TickersList.Contains(ticker))//если тикер уже есть в списке то не подписываемся вторично
            {
                var tradeSub = Terminal.StreamingClient.GetTradeSubscription(ticker);
                tradeSub.Received += TradeReceived;
                await Terminal.StreamingClient.SubscribeAsync(tradeSub);
            }
            
            Terminal.TickersList.Add(ticker);
            TickersListConsole.Add(ticker);
            StatusLog.SetStatus("Подписались на тикер - " + ticker);
        }
        public string Str1(int s)
        {
            string ss = "";
            for (int i = 0; i < (9 - s); i++)
            {
                ss += " ";
            }
            return ss;
        }
        public Color PrintColor(decimal price1, IQuote dataAll)
        {
            Color colorText = Color.White;
            try
            {
                if (price1 == dataAll.BidPrice) colorText = Color.Red;
                if (price1 < dataAll.BidPrice) colorText = Color.LightCoral;
                if (price1 > dataAll.AskPrice) colorText = Color.LightGreen;
                if (price1 == dataAll.AskPrice) colorText = Color.Green;
                if (price1 > dataAll.BidPrice && price1 < dataAll.AskPrice) colorText = Color.White;
            }
            catch
            {
                colorText = Color.Gray;
            }
            return colorText;
        }

    }
}
