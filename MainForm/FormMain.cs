using Alpaca.Markets;
using FishingSizes.DataBase;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tinkoff.Trading.OpenApi.Models;
using Tinkoff.Trading.OpenApi.Network;



namespace FishingSizes
{

    public partial class Terminal : Form, IHasSettings, IStatusLog, IHasTickerList, IActivateForm
    {
        public static TWSApiWrapper ApiWrapper { get; set; }
        public static bool IB_ApiClient_OnReady = false;
        public static AlorProvider alorProvider { get; set; }
        public Settings Sett { get; set; }
        public TickerListEdit Sett_tle { get; set; }
        public static List<string> TickerList { get; set; }
        public static IAlpacaDataClient DataClient { get; set; }
        public static IAlpacaDataStreamingClient StreamingClient { get; set; }
        public static List<string> TickersList = new List<string>();
        public static List<string> TickersListQuote = new List<string>();
        public static List<string> TickersListQuotesTi = new List<string>();
        public static List<string> TickersListCandlesTi = new List<string>();
        public static ConcurrentDictionary<string, RowGridPortfolio> _RowGridPortfolio = new ConcurrentDictionary<string, RowGridPortfolio>();
        public static PositionRub positionRub { get; set; }
        public static PortfolioCurrencies portfolioCurrencies { get; set; }
        public static Portfolio PortfolioTi { get; set; }
        private Connecting Connect { get; set; }
        private string Token_Ti { get; set; }
        private Connection Connection_Ti { get; set; }
        public static Context Context_Ti { get; set; }
        public static MarketInstrumentList MarketStocks;
        public static bool TiConnected = false;
        public static bool TiSubscribeCheck = false;
        public static bool AlpacaConnected = false;
        public static WebSocketServer _websocketserver;
        private Settings_Control Settings_Control;
        private Ticker_ListOption ticker_ListOption;
        private MethodsDB methodsDB;
        Autentication newForm;
        public static string UserName { get; set; }
        public static string ActiveUser { get; set; }
        public Dictionary<string, Brocker> BrockerSett { get; set; }


        public Terminal()
        {
            this.Enabled = false;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void Terminal_Load(object sender, EventArgs e)
        {
            newForm = new(this);
            newForm.Owner = this;
            newForm.ShowDialog();
        }

        public async void SetActivate(bool activate, string name)
        {
            newForm.Close();
            this.Enabled = activate;
            UserName = name;
            BrockerSett = new Dictionary<string, Brocker>();
            methodsDB = new MethodsDB(this.Name, this.Size, UserName);
            this.Location = methodsDB.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsDB.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            Sett_tle = new TickerListEdit();//объект списка избранных тикеров
            TickerList = new List<string>();
            await Sett_tle.LoadSett();
            foreach (var item in Sett_tle.MyTickerList)
            {
                TickerList.Add(item);
            }
            await ConnectedBrockers();
        }

        private async Task ConnectedBrockers()
        {
            Sett = new Settings();
            await Sett.LoadSett();//загрузка настроек из файла settings.json
            SettingsFromDB();//загрузка настроек в контрол через DB

            //реализация singleton для примера 
            SettingsBrockers settingsBrockers = new SettingsBrockers();
            settingsBrockers.Launch(methodsDB);
            settingsBrockers.SettBrock = SingletonSettingsBrockers.getInstance(methodsDB);
            var sb1 = SingletonSettingsBrockers.getInstance(methodsDB).BrockerSett;//без использования класса SettingsBrockers
            var sb = settingsBrockers.SettBrock.BrockerSett;
            //реализация singleton для примера (далее используем вместо BrockerSett)


            //подключение к Alpaca
            if (BrockerSett["Alpaca"].SecretKey != "" && BrockerSett["Alpaca"].OpenKey != "" && !BrockerSett["Alpaca"].ActivateUses)
            {
                var AlpacaKey = CryptoHelper.Decrypt(BrockerSett["Alpaca"].OpenKey);
                var AlpacaSecret = CryptoHelper.Decrypt(BrockerSett["Alpaca"].SecretKey);
                DataClient = Environments.Live.GetAlpacaDataClient(new SecretKey(AlpacaKey, AlpacaSecret));
                StreamingClient = Environments.Live.GetAlpacaDataStreamingClient(new SecretKey(AlpacaKey, AlpacaSecret));
                Connect = new Connecting(this);
                Connect.SubscribeConnect(StreamingClient);
                tsAlpaca.Image = Image.FromFile("Connect.png");
            }
            else SetStatus("No alpaca api keys!");

            //подключение к Tinkoff
            if (BrockerSett["Tinkoff"].SecretKey != "" && !BrockerSett["Tinkoff"].ActivateUses)
            {
                Token_Ti = CryptoHelper.Decrypt(BrockerSett["Tinkoff"].SecretKey);
                Connection_Ti = ConnectionFactory.GetConnection(Token_Ti);
                Context_Ti = Connection_Ti.Context;
                try
                {
                    MarketStocks = await Context_Ti.MarketStocksAsync();
                    portfolioCurrencies = await Context_Ti.PortfolioCurrenciesAsync();//получаем рублевый баланс
                    for (int i = 0; i < portfolioCurrencies.Currencies.Count; i++)
                    {
                        if (portfolioCurrencies.Currencies[i].Currency.ToString() == "Rub")
                        {
                            positionRub = new PositionRub("RUB", portfolioCurrencies.Currencies[i].Balance, portfolioCurrencies.Currencies[i].Blocked);
                        }
                    }
                    PortfolioTi = await Context_Ti.PortfolioAsync(null);//получение объекта портфеля
                    for (int i = 0; i < PortfolioTi.Positions.Count; i++)//заполнение списка бумаг портфеля
                    {
                        TickersListCandlesTi.Add(PortfolioTi.Positions[i].Ticker);
                    }
                    tsTinkoff.Image = Image.FromFile("Connect.png");
                    TiConnected = true;
                }
                catch
                {
                    //SetStatus("Tinkoff openapi not connection!");
                }
            }
            else SetStatus("No Tinkoff OpenAPI token!");

            //подключение к IB
            if (!BrockerSett["IB"].ActivateUses)
            {
                ApiWrapper = new TWSApiWrapper();
                var ibReseived = new IBReseived();
                ApiWrapper.OnReady += ApiClient_OnReady_Terminal;
                ApiWrapper.NoReady += ApiClient_NoReady_Terminal;
                ApiWrapper.Run("localhost:7497"); // 4002 | 7497
            }
            _websocketserver = new WebSocketServer();
            await _websocketserver.Start();

            //подключение к Алор
            if (!BrockerSett["Alor"].ActivateUses && BrockerSett["Alor"].SecretKey != "")
            {
                alorProvider = new AlorProvider(CryptoHelper.Decrypt(BrockerSett["Alor"].SecretKey));
                await alorProvider.ConnectSocket();
            }

        }

        private void ApiClient_NoReady_Terminal(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_NoReady == : {sender} : {e}");
                SetStatusIcon("NoConnect.png");
                Terminal.IB_ApiClient_OnReady = false;
            }
        }

        public void ApiClient_OnReady_Terminal(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_OnReady == : {sender} : {e}");
                SetStatusIcon("Connect.png");
                Terminal.IB_ApiClient_OnReady = true;
            }
        }

        public void SetStatusIcon(string s)
        {
            if (this.InvokeRequired) // если требуется вызов из главного UI потока
            {
                this.Invoke((Action)(() => SetStatusIcon(s))); // передаем функцию, которая будет вызвана в потоке формы
            }
            else
            {
                tsIB.Image = Image.FromFile(s);
            }
        }

        public void AppendLog(string text)
        {
        }

        public void ConnectStatus(string filename, ToolStripStatusLabel tsStatus)
        {
            DoOnUI(() => tsStatus.Image = Image.FromFile(filename));
        }

        public void SetStatus(string newStatus)
        {
            DoOnUI(() => tStatusMain.Text = newStatus);
        }

        public void ColorTextLog(Color color)
        {
        }

        private void DoOnUI(Action act)
        {
            if (this.InvokeRequired)
                this.Invoke(act);
            else
                act();
        }

        private void HistoryMenu_Click(object sender, EventArgs e)
        {
            HistoryForm newForm = new HistoryForm();
            newForm.Show();
        }

        private void SetMenu_Click(object sender, EventArgs e)
        {
            if (ticker_ListOption != null)
            {
                ticker_ListOption.Visible = false;
                Controls.Remove(ticker_ListOption);
                ticker_ListOption = null;
            }
            Settings_Control = new Settings_Control();
            //SettingsFromDB();//загрузка настроек в контрол через DB
            Settings_Control.tbTokenTinkoff.Text = CryptoHelper.Decrypt(BrockerSett["Tinkoff"].SecretKey);
            Settings_Control.cbTinkoffUses.Checked = BrockerSett["Tinkoff"].ActivateUses;

            Settings_Control.tbTokenAlor.Text = CryptoHelper.Decrypt(BrockerSett["Alor"].SecretKey);
            Settings_Control.cbAlorUses.Checked = BrockerSett["Alor"].ActivateUses;

            Settings_Control.tbKey.Text = CryptoHelper.Decrypt(BrockerSett["Alpaca"].OpenKey);
            Settings_Control.tbSecret.Text = CryptoHelper.Decrypt(BrockerSett["Alpaca"].SecretKey);
            Settings_Control.cbAlpacaUses.Checked = BrockerSett["Alpaca"].ActivateUses;

            Settings_Control.cbIB.Checked = BrockerSett["IB"].ActivateUses;

            Controls.Add(Settings_Control);
        }

        private void SettingsFromDB()//загрузка настроек через DB
        {
            var brockers = methodsDB.LoadDBSettings();
            BrockerSett.Add("Tinkoff", brockers.Find(item => item.Name == "Tinkoff"));
            BrockerSett.Add("Alor", brockers.Find(item => item.Name == "Alor"));
            BrockerSett.Add("Alpaca", brockers.Find(item => item.Name == "Alpaca"));
            BrockerSett.Add("IB", brockers.Find(item => item.Name == "IB"));
        }

        private void SettingsFromJson()//загрузка настроек через файл settings.json (старая версия)
        {
            Settings_Control.tbKey.Text = CryptoHelper.Decrypt(Sett.Key);
            Settings_Control.tbSecret.Text = CryptoHelper.Decrypt(Sett.Secret);
            Settings_Control.tbTokenTinkoff.Text = CryptoHelper.Decrypt(Sett.TokenAPITinkoff);
            Settings_Control.tbTokenAlor.Text = CryptoHelper.Decrypt(Sett.TokenAlor);
            Settings_Control.cbAlpacaUses.Checked = Sett.AlpacaUses;
            Settings_Control.cbTinkoffUses.Checked = Sett.TinkoffUses;
            Settings_Control.cbAlorUses.Checked = Sett.AlorUses;
        }

        private void FishingSizesMenu_Click(object sender, EventArgs e)
        {
            ConsoleForm newForm = new ConsoleForm();
            newForm.Show();
        }

        private void TradersMenu_Click(object sender, EventArgs e)
        {
            FormTrades newForm = new FormTrades();
            newForm.Show();
            newForm.cbTicker.Enabled = true;
        }

        private void QuotesMenu_Click(object sender, EventArgs e)
        {
            QuotesForm newForm = new QuotesForm();
            newForm.Show();
        }

        private void TsOrders_Click(object sender, EventArgs e)
        {
            OrdersForm newForm = new OrdersForm();
            newForm.Show();
        }

        private void OrderTinkoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersForm newForm = new OrdersForm();
            newForm.Show();
        }

        private void OrderIBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrdersIB newForm = new FormOrdersIB();
            newForm.Show();
        }



        private void ApbUSSPBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArbForm newForm = new ArbForm();
            newForm.Show();
        }

        private void ArbClosePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArbClosePriceForm newForm = new ArbClosePriceForm();
            newForm.Show();
        }

        private async void TickerListOptoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings_Control != null)
            {
                Settings_Control.Visible = false;
                Controls.Remove(Settings_Control);
                Settings_Control = null;

            }
            ticker_ListOption = new Ticker_ListOption();
            Controls.Add(ticker_ListOption);
            await Sett_tle.LoadSett();
            foreach (var item in Sett_tle.MyTickerList)
            {
                ticker_ListOption.lbTickerList.Items.Add(item);
            }
        }

        private void TradesSPBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTradesSpb newForm = new FormTradesSpb();
            newForm.Show();
        }

        private void tinkoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PortfolioForm newForm = new PortfolioForm();
            var menuItem = sender as ToolStripMenuItem;

            if (menuItem.Enabled && (string)menuItem.Tag == "P1")
            {
                menuItem.Enabled = false;
                newForm.Show();

                newForm.FormClosing += (s, e) =>
                {
                    menuItem.Enabled = true;
                };
            }
        }

        private void setTerminaleMenu_Click(object sender, EventArgs e)
        {

        }

        private void ordersActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormActivOrders newForm = new FormActivOrders();
            newForm.Show();
        }

        private void Terminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsDB.UpdateBD(UserName, this.Left, this.Top, this.Size);
        }

    }
}
