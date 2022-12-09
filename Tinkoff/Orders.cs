using System;
using System.Drawing;
using System.Windows.Forms;
using Tinkoff.Trading.OpenApi.Models;
using Tinkoff.Trading.OpenApi.Network;
using System.Diagnostics;
using Newtonsoft.Json;

namespace FishingSizes
{
    public partial class OrdersForm : Form, IDisposable
    {
        string Ticker { get; set; }
        decimal Price { get; set; }
        int Lots { get; set; }
        

        TinkoffMy Ti;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pnt);

        public OrdersForm()
        {
            InitializeComponent();
            MouseWheel MWhell = new MouseWheel(tbPriceLimit);
            tbPriceLimit.MouseWheel += new MouseEventHandler(MWhell.tbPrice_MouseWheel);
            //MouseWheel += new MouseEventHandler(MWhell.Form1_MouseWheel);
        }
        public OrdersForm(string ticker)
        {
            InitializeComponent();
            MouseWheel MWhell = new MouseWheel(tbPriceLimit);
            tbPriceLimit.MouseWheel += new MouseEventHandler(MWhell.tbPrice_MouseWheel);
            Ticker = ticker;
            cbTicker_KeyDown();
        }


        private void Context_Ti_StreamingEventReceived(object sender, StreamingEventReceivedEventArgs e)
        {
            if (Ti != null && this != null)
            {
                if (e.Response.Event == "orderbook")
                {
                    var ore = (OrderbookResponse)e.Response;
                    if (Ti.Figi == ore.Payload.Figi)
                    {
                        if (ore.Payload.Bids[0][0] != decimal.Parse(lbBid.Text))
                        {
                            DoOnUI(() => lbBid.Text = (ore.Payload.Bids[0][0]).ToString());
                        }

                        if (ore.Payload.Asks[0][0] != decimal.Parse(lbAsk.Text))
                        {
                            DoOnUI(() => lbAsk.Text = (ore.Payload.Asks[0][0]).ToString());
                            DoOnUI(() => lbDostupnoBuy.Text = (((int)Math.Round(Terminal.positionRub.Balance / ore.Payload.Asks[0][0])).ToString()));
                        }
                        Debug.WriteLine($"Сообщение от сокета по тикеру: {Ti.Ticker} : {ore.Payload.Figi}");
                    }
                }
            }

        }

        private async void btBuyLimit_Click(object sender, EventArgs e)
        {
            if (cbTicker.Text != "" && numLotsLimit.Value > 0 && tbPriceLimit.Text != "")
            {
                Price = decimal.Parse(tbPriceLimit.Text);
                Lots = Decimal.ToInt32(numLotsLimit.Value);
                await Ti.LimitOrder(Ticker, Lots, OperationType.Buy, Price);
                foreach (var form in Application.OpenForms)
                {
                    if (form is FormActivOrders newForm)
                        newForm.FormTest_Load(sender, e);
                }
            }
        }

        private async void btSellLimit_Click(object sender, EventArgs e)
        {
            if (cbTicker.Text != "" && numLotsLimit.Value > 0 && tbPriceLimit.Text != "")
            {
                Price = decimal.Parse(tbPriceLimit.Text);
                Lots = Decimal.ToInt32(numLotsLimit.Value);
                await Ti.LimitOrder(Ticker, Lots, OperationType.Sell, Price);
                foreach (var form in Application.OpenForms)
                {
                    if (form is FormActivOrders newForm)
                        newForm.FormTest_Load(sender, e);
                }
            }
        }

        private void btBuyMarket_Click(object sender, EventArgs e)
        {
            if (cbTicker.Text != "" && numLotsMarket.Value > 0)
            {
                Lots = Decimal.ToInt32(numLotsMarket.Value);
                Ti.MarketOrder(Ticker, Lots, OperationType.Buy);
                if (cbRandomVol.Checked)
                {
                    Random rnd = new Random();
                    numLotsMarket.Value = (decimal)rnd.Next(1, 20);
                }
            }
        }

        private void btSellMarket_Click(object sender, EventArgs e)
        {
            if (cbTicker.Text != "" && numLotsMarket.Value > 0)
            {
                Lots = Decimal.ToInt32(numLotsMarket.Value);
                Ti.MarketOrder(Ticker, Lots, OperationType.Sell);
            }
        }

        private void btCancelOrders_Click(object sender, EventArgs e)
        {
            Ti.CancelOrders();
        }

        private void tbPriceLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && (((sender as TextBox).Text.IndexOf(',') > -1) || ((sender as TextBox).Text.Length == 0)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                if (((sender as TextBox).Text.IndexOf(',') > -1) || ((sender as TextBox).Text.Length == 0))
                {
                    e.Handled = true;
                }
                else e.KeyChar = ',';
            }
            if (((sender as TextBox).Text == "0") && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((sender as TextBox).Text.IndexOf(',')  > -1)
            {
                if ((sender as TextBox).Text.IndexOf(',') < (sender as TextBox).SelectionStart)
                {
                    if ((sender as TextBox).Text.Length - (sender as TextBox).Text.IndexOf(',') >= 3)
                    {
                        Debug.Print($"Cancel OrderId = {(sender as TextBox).Text.Length} : {(sender as TextBox).Text.IndexOf(',')} : {(sender as TextBox).SelectionStart}");
                        e.Handled = true;
                    }
                }
            }



        }

        private void tbPriceLimit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Text = "";
        }

        private void numLotsMarket_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (sender as NumericUpDown).Value = 1;
        }

        private void numLotsLimit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (sender as NumericUpDown).Value = 1;
        }
 
        private void DoOnUI(Action act)
        {
            if (this.InvokeRequired)
                this.Invoke(act);
            else
                act();
        }

        private void lbBid_Click(object sender, EventArgs e)
        {
            if (tabOrders.SelectedIndex == 0)
            {
                tbPriceLimit.Text = lbBid.Text;
            }
        }

        private void lbAsk_Click(object sender, EventArgs e)
        {
            if (tabOrders.SelectedIndex == 0)
            {
                tbPriceLimit.Text = lbAsk.Text;
            }
        }
        
        //нажатие Enter после ввода тикерв
        private async void cbTicker_KeyDown(object sender, KeyEventArgs e)
        {
            //await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.SubscribeOrderbook("BBG0016XJ8S0", 1));
            if (e.KeyCode == Keys.Enter && Terminal.TiConnected == true)
            {
                        //await Task.Delay(2000);
                if (cbTicker.Text != "")
                {
                    Terminal.Context_Ti.StreamingEventReceived += Context_Ti_StreamingEventReceived;
                    Terminal.TiSubscribeCheck = true;
                    var oldTicker = Ticker;
                    Terminal.TickersListQuotesTi.Remove(Ticker);
                    Ticker = cbTicker.Text.Trim().ToUpper();
                    Terminal.TickersListQuotesTi.Add(Ticker);
                    Ti = new TinkoffMy(Ticker);
                    if (oldTicker != "")
                    {//отписываемся от потока по старому тикеру
                        int i = 0;
                        foreach (var t in Terminal.TickersListQuotesTi)
                        {
                            if (t == Ticker)
                            {
                                ++i;
                            }
                        }
                        if (i == 1)
                        {
                            //отписываемся
                            await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.UnsubscribeOrderbook(Ti.FigiGet(Ticker), 1));
                        }
                    }
                    if (Ti.TickerCheck(Ticker))//проверка введенного тикера на соответствие названиям инструментов
                    {
                        btBuyLimit.Enabled = true;
                        btSellLimit.Enabled = true;
                        tbPriceLimit.Enabled = true;
                        numLotsLimit.Enabled = true;

                        btBuyMarket.Enabled = true;
                        btSellMarket.Enabled = true;
                        numLotsMarket.Enabled = true;
                        btCancelOrders.Enabled = true;
                        //подписываемся на поток котировок глубиной 1 для нового тикера
                        await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.SubscribeOrderbook(Ti.FigiGet(Ti.Ticker), 1));
                        //Debug.WriteLine($"TickersListQuotesTi: {JsonSerializer.Serialize(Terminal.TickersListQuotesTi)}  Ti: {JsonSerializer.Serialize(Ti)} oldTicker =  {oldTicker}");
                        lbPortfolioVol.Text = "0";
                        for (int i = 0; i < Terminal.PortfolioTi.Positions.Count; i++)
                        {
                            if (Terminal.PortfolioTi.Positions[i].Ticker == Ticker)
                            {
                                lbPortfolioVol.Text = Terminal.PortfolioTi.Positions[i].Balance.ToString();
                            }
                        }
                        lbDostupnoSell.Text = lbPortfolioVol.Text;
                    }
                }
                else
                {
                    btBuyLimit.Enabled = false;
                    btSellLimit.Enabled = false;
                    tbPriceLimit.Enabled = false;
                    numLotsLimit.Enabled = false;

                    btBuyMarket.Enabled = false;
                    btSellMarket.Enabled = false;
                    numLotsMarket.Enabled = false;
                    btCancelOrders.Enabled = false;
                }
                if (cbOpenTi.Checked)
                {
                    var ticker = Ticker;
                    var group = 3;
                    await Terminal._websocketserver.SendAll(JsonConvert.SerializeObject(new { ticker, group }));
                }


            }
        }
        private async void cbTicker_KeyDown()
        {
            

                    Terminal.Context_Ti.StreamingEventReceived += Context_Ti_StreamingEventReceived;
                    Terminal.TiSubscribeCheck = true;
                    cbTicker.Text = Ticker;
                    Terminal.TickersListQuotesTi.Add(Ticker);
                    Ti = new TinkoffMy(Ticker);

                    if (Ti.TickerCheck(Ticker))//проверка введенного тикера на соответствие названиям инструментов
                    {
                        btBuyLimit.Enabled = true;
                        btSellLimit.Enabled = true;
                        tbPriceLimit.Enabled = true;
                        numLotsLimit.Enabled = true;

                        btBuyMarket.Enabled = true;
                        btSellMarket.Enabled = true;
                        numLotsMarket.Enabled = true;
                        btCancelOrders.Enabled = true;
                        //подписываемся на поток котировок глубиной 1 для нового тикера
                        await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.SubscribeOrderbook(Ti.FigiGet(Ti.Ticker), 1));
                        //Debug.WriteLine($"TickersListQuotesTi: {JsonSerializer.Serialize(Terminal.TickersListQuotesTi)}  Ti: {JsonSerializer.Serialize(Ti)} oldTicker =  {oldTicker}");
                        lbPortfolioVol.Text = "0";
                        for (int i = 0; i < Terminal.PortfolioTi.Positions.Count; i++)
                        {
                            if (Terminal.PortfolioTi.Positions[i].Ticker == Ticker)
                            {
                                lbPortfolioVol.Text = Terminal.PortfolioTi.Positions[i].Balance.ToString();
                            }
                        }
                        lbDostupnoSell.Text = lbPortfolioVol.Text;
                    }
              




            
        }

        private async void OrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Ti != null)
            {
                Debug.WriteLine($"CloseForm - Ticker: {Ticker}  Ti: {Ti}");
                int i = 0;
                foreach (var t in Terminal.TickersListQuotesTi)
                {
                    if (t == Ticker)
                    {
                        ++i;
                    }
                }
                if (i == 1)
                {
                    //отписываемся
                    await Terminal.Context_Ti.SendStreamingRequestAsync(StreamingRequest.UnsubscribeOrderbook(Ti.FigiGet(Ticker), 1));
                    Ti = null;
                }
                Terminal.TickersListQuotesTi.Remove(Ticker);
                if (Terminal.TickersListQuotesTi.Count == 0)//если закрываем последнее окно то отписываемся от сообщений от Ти сокета
                {
                    Terminal.Context_Ti.StreamingEventReceived -= Context_Ti_StreamingEventReceived;
                    Terminal.TiSubscribeCheck = false;
                }
            }
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            cbTicker.Items.Clear();
            foreach (var item in Terminal.TickerList)
            {
                cbTicker.Items.Add(item);
            }

        }

        private void lbPortfolioVol_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Terminal.PortfolioTi.Positions.Count; i++)
            {
                if (Terminal.PortfolioTi.Positions[i].Ticker == Ticker)
                {
                    if (tabOrders.SelectedTab.Text == "LimitOrder")
                    {
                        numLotsLimit.Value = Terminal.PortfolioTi.Positions[i].Balance;
                    }
                    if (tabOrders.SelectedTab.Text == "MarketOrder")
                    {
                        numLotsMarket.Value = Terminal.PortfolioTi.Positions[i].Balance;
                    }

                }
            }
        }
    }
}
