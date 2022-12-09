using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using IBApi;
using Newtonsoft.Json;
using FishingSizes.DataBase;

namespace FishingSizes
{
    public partial class FormOrdersIB : Form, IQuotesIBOrder
    {
        string Ticker { get; set; }
        decimal Price { get; set; }
        int Lots { get; set; }
        public Settings Sett { get; set; }
        Trades trades;
        BindingList<RowGrid> data;
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pnt);
        private MethodsDB methodsCoordinates;

        public FormOrdersIB()
        {
            InitializeComponent();
            MouseWheel MWhell = new MouseWheel(tbPriceLimit);
            tbPriceLimit.MouseWheel += new MouseEventHandler(MWhell.tbPrice_MouseWheel);
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }
        private async void FormOrdersIB_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            cbTicker.Items.Clear();
            foreach (var item in Terminal.TickerList)
            {
                cbTicker.Items.Add(item);
            }
            cbTicker.SelectedIndex = 0;
            if (Terminal.IB_ApiClient_OnReady)
            {
                Terminal.ApiWrapper.OnReady += ApiClient_OnReady_Order;
                Terminal.ApiWrapper.OnPrintReceived += ApiClient_OnPrintReceived_Order;
            }

            var settings = new Settings();
            await settings.LoadSett();
            Sett = settings;
        }

        public void ApiClient_OnPrintReceived_Order(object sender, (int, HistoricalTickBidAsk[], bool) e)
        {
            Debug.WriteLine($" == ApiClient_OnPrintReceived == : {sender} : {e}");
        }
        public void ApiClient_OnReady_Order(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_OnReady == : {sender} : {e}");
                Terminal.IB_ApiClient_OnReady = true;
            }
        }
        private void ApiClient_NoReady_Order(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_NoReady == : {sender} : {e}");
                Terminal.IB_ApiClient_OnReady = false;
            }
        }


        private async void cbTicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Terminal.TiConnected == true)
            {
                if (Ticker != "" && !Sett.AlpacaUses)
                {
                    if (trades != null)
                    {
                        Debug.WriteLine($"Отписка от тикера через ENTER: {Ticker}");
                        trades.UnsubscribeQuotesNew(Ticker);
                        trades = null;
                    }
                }
                if (cbTicker.Text != "" && !Sett.AlpacaUses)
                {
                    Ticker = cbTicker.Text.Trim().ToUpper();
                    trades = new Trades(Ticker, this);
                    Debug.WriteLine($"Подписка на тикер через ENTER: {Ticker}");
                    lbBid.Text = lbAsk.Text = "-";
                    tbPriceLimit.Text = "0,00";
                    trades.SubscribeQuotes(Ticker);
                    bool i = false;
                    foreach (var item in cbTicker.Items)
                    {
                        if (item.ToString() == Ticker)//проверяем наличие тикера в списке cbTicker.Items
                        {
                            i = true;
                            break;
                        }
                    }
                    if (!i) cbTicker.Items.Insert(0, Ticker);//добавляем тикер в список cbTicker.Items
                }
                if (cbOpenTi.Checked)
                {
                    var ticker = Ticker;
                    var group = 3;
                    await Terminal._websocketserver.SendAll(JsonConvert.SerializeObject(new { ticker, group }));
                }

                tbPriceLimit.Enabled = true;
                numLotsLimit.Enabled = true;
                btBuyLimit.Enabled = true;
                btSellLimit.Enabled = true;
                cbExchange.Enabled = true;
                btCancelAllOrders.Enabled = true;
                btCancelLastOrders.Enabled = true;
            }
        }

        public void AppendQuotes(decimal ask, decimal bid)
        {
            if (this.InvokeRequired) // если требуется вызов из главного UI потока
            {
                this.Invoke((Action)(() => AppendQuotes(ask, bid))); // передаем функцию, которая будет вызвана в потоке формы
            }
            else
            {
                lbBid.Text = bid.ToString();
                lbAsk.Text = ask.ToString();
            }
        }

        private void btBuyLimit_Click(object sender, EventArgs e)
        {
            if (Terminal.IB_ApiClient_OnReady)
            {
                var buy_sell = "BUY";
                var Price = Convert.ToDecimal(tbPriceLimit.Text);
                var exch = cbExchange.Text;
                var vol = Convert.ToInt32(numLotsLimit.Value);
                Terminal.ApiWrapper.OrderPlace(Ticker, buy_sell, vol, Price, exch);
            }
        }
        private void btSellLimit_Click(object sender, EventArgs e)
        {
            if (Terminal.IB_ApiClient_OnReady)
            {
                var buy_sell = "SELL";
                var Price = Convert.ToDecimal(tbPriceLimit.Text);
                var exch = cbExchange.Text;
                var vol = Convert.ToInt32(numLotsLimit.Value);
                Terminal.ApiWrapper.OrderPlace(Ticker, buy_sell, vol, Price, exch);
            }
        }
        private void btCancelLastOrders_Click(object sender, EventArgs e)
        {
            Terminal.ApiWrapper.CancelLastOrder();
        }
        private void btCancelAllOrders_Click(object sender, EventArgs e)
        {
            Terminal.ApiWrapper.CancelOrdersAll();

        }

        private void lbBid_Click(object sender, EventArgs e)
        {
            tbPriceLimit.Text = lbBid.Text;
        }
        private void lbAsk_Click(object sender, EventArgs e)
        {
            tbPriceLimit.Text = lbAsk.Text;
        }

        private void FormOrdersIB_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
            if (trades != null)
            {
                trades.cancelTokenSource.Cancel();
                //trades.cancelTokenSource.Dispose();
                trades.UnsubscribeQuotesNew(Ticker);
            }
        }
    }

}
