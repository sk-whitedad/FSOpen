using Alpaca.Markets;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.ComponentModel;
using FishingSizes.DataBase;


namespace FishingSizes
{
    public partial class ConsoleForm : Form, IStatusLog
    {
        public static Color colorText = Color.LightGreen;
        public Settings Sett { get; set; }
        SubscribeFishing Subscribe;
        public string[] arrDataTicker;
        readonly ConcurrentDictionary<string, IMultiPage<ITrade>> tradeAllTickersMO = new ConcurrentDictionary<string, IMultiPage<ITrade>>();
        private MethodsDB methodsCoordinates;

        public ConsoleForm()
        {
            InitializeComponent();
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            gbFishing.Visible = true;
            var settings = new Settings();
            
            await settings.LoadSett();
                tbTickersList.Text = settings.TickersList;
                tbPrintSizeMin.Text = Convert.ToString(settings.PrintSizeMin);
                tbPrintSizeMax.Text = Convert.ToString(settings.PrintSizeMax);
                chbMute.Checked = settings.Mute;
                chbPair.Checked = settings.Pair;
                chbSprad.Checked = settings.SpradCheck;
                tbPriceMin.Text = Convert.ToString(settings.PriceMin);
                tbPriceMax.Text = Convert.ToString(settings.PriceMax);
                chbFPrints.Checked = settings.FPrints;
                miStart.Enabled = true;
                tbSpradRab.Text = Convert.ToString(settings.SpradRab);
                tStatus.Text = "Load settings..";

            try
            {
                dtOpen.Value = settings.OpenSess;
                dtClose.Value = settings.CloseSess;
            }
            catch { }

            ToolTip ToolBtn = new ToolTip();
            ToolBtn.SetToolTip(this.btnTickerSuscr, "Подписаться на тикер");
            ToolBtn.SetToolTip(this.btnTickerUnSuscr, "Отписаться от тикера");
            if (!String.IsNullOrWhiteSpace(settings.Exch)) tbExch.Text = settings.Exch;
            else
            {
                settings.Exch = tbExch.Text = "FINRA,ARCA,NYSE,NASDAQ";
            }
            Sett = settings;
            Subscribe = new SubscribeFishing(Sett, this);
            rtbConsole.Text = Sett.Exch;
        }

        private void miSettings_Click(object sender, EventArgs e)
        {
            gbFishing.Visible = false;
            gbSettings.Visible = true;
            miStart.Enabled = false;
        }

        private void btnSaveSett_Click(object sender, EventArgs e)
        {
            Sett.TickersList = tbTickersList.Text;
            Sett.Exch = tbExch.Text;
            Sett.PrintSizeMin = Int32.Parse(tbPrintSizeMin.Text);
            Sett.PrintSizeMax = Int32.Parse(tbPrintSizeMax.Text);
            Sett.Mute = chbMute.Checked;
            Sett.Pair = chbPair.Checked;
            Sett.PriceMin = Convert.ToDecimal(tbPriceMin.Text.Replace(".", ","));
            Sett.PriceMax = Convert.ToDecimal(tbPriceMax.Text.Replace(".", ","));
            Sett.OpenSess = dtOpen.Value;
            Sett.CloseSess = dtClose.Value;
            Sett.SpradCheck = chbSprad.Checked;
            Sett.FPrints = chbFPrints.Checked;
            Sett.SpradRab = Convert.ToDecimal(tbSpradRab.Text.Replace(".", ","));
            Sett.SaveSett(Sett);
            tStatus.Text = "Save settings..";
            gbSettings.Visible = false;
            gbFishing.Visible = true;
            miStart.Enabled = true;
        }

        //кнопка старт, запуск получения принтов по настройкам
        private void MiStart_Click(object sender, EventArgs e)
        {
            if (miStart.Text == "Старт")
            {
                Subscribe.disposed = false;
                miStart.Text = "Стоп";
                btnTickerSuscr.Enabled = true;
                btnTickerUnSuscr.Enabled = true;
                Subscribe.DoSomethingAfterConnect(Terminal.StreamingClient, Sett);
                AppendLog("Сканирование запущено.");
            }
            else if (miStart.Text == "Стоп")
            {
                miStart.Text = "Старт";
                btnTickerSuscr.Enabled = false;
                btnTickerUnSuscr.Enabled = false;
                if (Terminal.StreamingClient != null)
                {
                    Subscribe.disposed = true;
                    Subscribe.UnsubscribeAll();
                    colorText = Color.LightCyan;
                    AppendLog("Подписка на данные отключена!");
                    DoOnUI(() => tStatus.Text = "Подписка на данные отключена!");
                }
            }
        }

        //обработчик клика отписки от тикера
        private void BtnTickerUnSuscr_Click(object sender, EventArgs e)
        {
            Subscribe.Unsubscribe(tbTickerSubscr.Text.Trim().ToUpper());
        }
        //обработчик клика подписки на тикер
        private void BtnTickerSuscr_Click(object sender, EventArgs e)
        {
            if (!Sett.AlpacaUses)
            {
                Subscribe.Subscribe(tbTickerSubscr.Text.Trim().ToUpper());
            }
            
        }
        //обработчик клика по строке консоли
        private void RtbConsole_MouseClick(object sender, MouseEventArgs e)
        {
            int cursorPosition = rtbConsole.SelectionStart;
            int lineIndex = rtbConsole.GetLineFromCharIndex(cursorPosition);
            string lineText = rtbConsole.Lines[lineIndex];
            DoOnUI(() => tStatus.Text = "Выбрана строка - " + lineText);
            try
            {
                var str = lineText.Substring(0, lineText.IndexOf(":"));
                Clipboard.SetText(str);
            }
            catch
            {
                DoOnUI(() => tStatus.Text = "Выбрана строка не содержащая данные!");
            }
        }
        //проверка динамики цены от принта открытия
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            ConcurrentDictionary<string, decimal> dict = new ConcurrentDictionary<string, decimal>();
            string[] tickers = Sett.TickersList.Split(',');
            decimal procent1 = Convert.ToDecimal(tbProcent1.Text.Replace(".", ","));
            decimal procent2 = Convert.ToDecimal(tbProcent2.Text.Replace(".", ","));
           
            if (cbCheck.Text == "Открытие ОС")
            {
                foreach (var ticker in tickers)
                {
                    
                    try
                    {
                        var i = Math.Round(Subscribe.dataAllTickers[ticker].BidPrice * 100 / Subscribe.tradeAllTickersO[ticker].Price - 100, 2);//процент роста/падения от цены открытия
                        var spred = Subscribe.dataAllTickers[ticker].AskPrice - Subscribe.dataAllTickers[ticker].BidPrice;
                        //AppendLog("" + connect.dataAllTickers[ticker].BidPrice + " --- " + connect.dataAllTickers[ticker].AskPrice +"----"+ spred);
                        if (i >= procent1 && i <= procent2 && spred <= Sett.SpradRab)
                        {
                            dict[ticker] = i;
                        }
                    }
                    catch
                    {
                        DoOnUI(() => tStatus.Text = ticker + " - не получены рыночные данные!");
                    }
                }
                if (!dict.IsEmpty)
                {
                    colorText = Color.White;
                    AppendLog("--------------------------------------");
                    foreach (var pair in dict.OrderBy(pair => pair.Value))
                    {
                        //AppendLog(pair.Key + "---" + "---" + connect.tradeAllTickersO[pair.Key].Price + "---" + connect.tradeAllTickersM[pair.Key].Price);

                        if (colorText == Color.White)
                        {
                            colorText = Color.LightGray;
                        }
                        else colorText = Color.White;
                        AppendLog(pair.Key + ":" + Str1(pair.Key.Length) + pair.Value + " %");
                    }
                }
                else DoOnUI(() => tStatus.Text = "Не загружены рыночные данные O/M/L1");
            }

            if (cbCheck.Text == "Арбитраж (Закрытие ОС)")
            {

            }
            
            if (cbCheck.Text == "Проверка спреда ПМ")
            {
                foreach (var ticker in tickers)
                {
                    try
                    {
                        var bid_D = Subscribe.tradeAllTickersM[ticker].Price - Subscribe.dataAllTickers[ticker].BidPrice;
                        var ask_D = Subscribe.dataAllTickers[ticker].AskPrice - Subscribe.tradeAllTickersM[ticker].Price;
                        var spred = Subscribe.dataAllTickers[ticker].AskPrice - Subscribe.dataAllTickers[ticker].BidPrice;
                        if (ask_D > bid_D && Subscribe.tradeAllTickersM[ticker].Price <= Sett.PriceMax && Subscribe.tradeAllTickersM[ticker].Price >= Sett.PriceMin && Subscribe.tradeAllTickersM[ticker].Price < Subscribe.dataAllTickers[ticker].AskPrice)
                        {
                            AppendLog(ticker +":" + Str1(ticker.Length) + Subscribe.dataAllTickers[ticker].BidPrice +" ---- "+ Subscribe.dataAllTickers[ticker].AskPrice +"    M - "+ Subscribe.tradeAllTickersM[ticker].Price);
                            dict[ticker] = Math.Round(((ask_D / bid_D) - 1)*100, 0);
                        }
                    }
                    catch
                    {
                        DoOnUI(() => tStatus.Text = ticker + " - не получены рыночные данные!");
                    }
                }
                if (!dict.IsEmpty)
                {
                    colorText = Color.White;
                    AppendLog("--------------------------------------");
                    foreach (var pair in dict.OrderBy(pair => pair.Value))
                    {
                        if (colorText == Color.White)
                        {
                            colorText = Color.LightGray;
                        }
                        else colorText = Color.White;
                        AppendLog(pair.Key + ":" + Str1(pair.Key.Length) + pair.Value + " %");
                    }
                } else DoOnUI(() => tStatus.Text ="Не загружены рыночные данные O/M/L1");
            }

            if (cbCheck.Text == "Динамика за ОС (О-М)")
            {
                foreach (var ticker in tickers)
                {
                    try
                    {
                        var i = Math.Round((100 * Subscribe.tradeAllTickersM[ticker].Price) / Subscribe.tradeAllTickersO[ticker].Price - 100 , 2);//процент роста/падения от цены открытия
                        if (i >= procent1 && i <= procent2)
                        {
                            dict[ticker] = i;
                        }
                    }
                    catch
                    {
                        DoOnUI(() => tStatus.Text = ticker + " - не получены рыночные данные!");
                    }
                }
                if (!dict.IsEmpty)
                {
                    colorText = Color.White;
                    AppendLog("--------------------------------------");
                    foreach (var pair in dict.OrderBy(pair => pair.Value))
                    {
                        if (pair.Value < 0) colorText = Color.LightCoral;
                        if (pair.Value > 0) colorText = Color.LightGreen;
                        if (pair.Value == 0) colorText = Color.LightGray;
                        AppendLog(pair.Key + ":" + Str1(pair.Key.Length) + pair.Value + " %");
                    }
                }
                else DoOnUI(() => tStatus.Text = "Не загружены рыночные данные O/M/L1");
            }
        }
        //получение принтов открытия и закрытия из истории принтов и L1
        private async void btnGetPrintOM_Click(object sender, EventArgs e)
        {
            string[] tickers = Sett.TickersList.Split(',');//преобразование строки тикеров в массив
            DateTime dateFromM = Sett.CloseSess;//время начала считывания принтов закрытия
            DateTime dateFromO = Sett.OpenSess;//время начала считывания принтов открытия

            foreach (var ticker in tickers)
            {
                //получение принтов закрытия
                HistoricalTradesRequest histTradesM = new HistoricalTradesRequest(ticker, dateFromM.ToUniversalTime(), dateFromM.AddMinutes(30));
                try
                {
                    var tradeTickerM = await Terminal.DataClient.GetHistoricalTradesAsync(histTradesM);
                    tradeAllTickersMO[ticker] = tradeTickerM;
                    DoOnUI(() => tStatus.Text = "Получение данных: " + ticker);
                    foreach (var trade in tradeTickerM.Items[ticker])
                    {
                        if (String.Join("", trade.Conditions).Contains("M") && trade.Size >= 5000)
                        {
                            Subscribe.tradeAllTickersM[ticker] = trade;
                            //AppendLog(connect.tradeAllTickersM[ticker].Symbol + "---" + String.Join("", connect.tradeAllTickersM[ticker].Conditions) +"---" + connect.tradeAllTickersM[ticker].Size + "---" + connect.tradeAllTickersM[ticker].Price);
                            break;
                        }
                    }
                }
                catch 
                {
                    AppendLog(ticker + ": Не получен принт M");
                }
                
                

                //получение принтов открытия
                HistoricalTradesRequest histTradesO = new HistoricalTradesRequest(ticker, dateFromO.ToUniversalTime(), dateFromO.AddSeconds(15));
                try
                {
                    var tradeTickerO = await Terminal.DataClient.GetHistoricalTradesAsync(histTradesO);
                    tradeAllTickersMO[ticker] = tradeTickerO;
                    foreach (var trade in tradeTickerO.Items[ticker])
                    {
                        if (String.Join("", trade.Conditions).Contains("O"))
                        {
                            Subscribe.tradeAllTickersO[ticker] = trade;
                            //AppendLog(connect.tradeAllTickersO[ticker].Symbol + "---" + String.Join("", connect.tradeAllTickersO[ticker].Conditions) + "---" + connect.tradeAllTickersO[ticker].Size + "---" + connect.tradeAllTickersO[ticker].Price);
                            break;
                        }
                    }
                }
                catch
                {
                    AppendLog(ticker + ": Не получен принт O");
                }

                try//получение L1
                {
                    if (!Subscribe.dataAllTickers.ContainsKey(ticker))
                    {
                        LatestMarketDataRequest DataClientMarcetData = new(ticker);
                        var quoteTicker = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
                        Subscribe.dataAllTickers[ticker] = quoteTicker;
                        //AppendLog(connect.dataAllTickers[ticker].Symbol + "---" + connect.dataAllTickers[ticker].BidPrice + "---" + connect.dataAllTickers[ticker].AskPrice);
                    }
                }
                catch
                {
                    AppendLog("Данные L1 не получены:" + ticker);
                }
            }
            colorText = Color.LightGray;
            //AppendLog("Котировки L1 успешно записаны в файл.");
            try//запись в файл принтов закрытия
            {
                using (FileStream fs = new FileStream("print_M.json", FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync<ConcurrentDictionary<string, ITrade>>(fs, Subscribe.tradeAllTickersM);
                    AppendLog("Принты закрытия успешно записаны в файл.");
                }
            }
            catch
            {
                DoOnUI(() => tStatus.Text = "Ошибка записи принтов закрытия в файл.");
            }

            try//запись в файл принтов открытия
            {
                using (FileStream fs = new FileStream("print_O.json", FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync<ConcurrentDictionary<string, ITrade>>(fs, Subscribe.tradeAllTickersO);
                    AppendLog("Принты открытия успешно записаны в файл.");
                }
            }
            catch
            {
                DoOnUI(() => tStatus.Text = "Ошибка записи принтов открытия в файл.");
            }

        }
        private string Str1(int s)
        {
            string ss = "";
            for (int i = 0; i < (9 - s); i++)
            {
                ss += " ";
            }
            return ss;
        }
        public void AppendLog(string text)
        {
            if (this.InvokeRequired) // если требуется вызов из главного UI потока
            {
                this.Invoke((Action)(() => AppendLog(text))); // передаем функцию, которая будет вызвана в потоке формы
            }
            else
            {
                TextEdit.AppendText(rtbConsole, "\r\n" + text, colorText);
                rtbConsole.ScrollToCaret();
                rtbConsole.Refresh();
            }
        }
        public void SetStatus(string newStatus)
        {
            DoOnUI(() => tStatus.Text = newStatus);
        }
        public void ColorTextLog(Color color)
        {
            DoOnUI(() => colorText = color);
        }
        private void DoOnUI(Action act)
        {
                if (this.InvokeRequired)
                    this.Invoke(act);
                else
                    act();
        }
        //сохранение принтов в файлы при закрытии формы 
        private async void Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
            try
            {
                using (FileStream fs = new FileStream("print_O.json", FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync<ConcurrentDictionary<string, ITrade>>(fs, Subscribe.tradeAllTickersO);
                }
            }
            catch
            {
            }

            try
            {
                using (FileStream fs = new FileStream("print_M.json", FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync<ConcurrentDictionary<string, ITrade>>(fs, Subscribe.tradeAllTickersM);
                }
            }
            catch
            {
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Subscribe.Dispose();
            base.OnClosing(e);

        }

        public void ConnectStatus(string filename, ToolStripStatusLabel tsStatus)
        {
            
        }
    }
}



//AMEX,BX,NSE,FINRA,MI,MIAX,ISE,EDGA,EDGX,LTSE,CSE,NYSE,ARCA,NASDAQ,NQSC,NQI,ME,IEX,CBOE,OMX,BYX,BZX
  