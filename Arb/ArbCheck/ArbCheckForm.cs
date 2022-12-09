using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Concurrent;
using Tinkoff.Trading.OpenApi.Models;
using Alpaca.Markets;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;
using FishingSizes.DataBase;

namespace FishingSizes
{

    public partial class ArbCheckForm : Form
    {
        public string Ticker { get; set; }//тикер
        public Orderbook QuotesTi;//котировки Тиня
        public IQuote QuotesAlpaca;//котировки Альпаки
        public List<MarketInstrument> marketInstruments;//список тикеров 
        private TinkoffMy Tinkoff;
        private int VolTi;//количество закупа арбы
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pnt);
        bool ModeOrders { get; set; }
        bool CheckMost = false;
        private MethodsDB methodsCoordinates;

        public ArbCheckForm(string ticker, List<MarketInstrument> marketinstruments, bool modeorders)
        {
            InitializeComponent();
            Ticker = ticker;
            marketInstruments = marketinstruments;
            ModeOrders = modeorders;
            Tinkoff = new TinkoffMy(Ticker);
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }
        private void ArbCheckForm_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            btGO2.Text = Ticker;
            LoadQuotes();
        }
        private async void LoadQuotes()
        {
            await GetQuotesTi();
            if (QuotesTi != null && QuotesTi.Asks.Count > 0 && QuotesTi.Bids.Count > 0)
            {
                tbAskSPB.Text = QuotesTi.Asks[0].Price.ToString();
                tbAskSPBvol.Text = QuotesTi.Asks[0].Quantity.ToString();
                tbBidSPB.Text = QuotesTi.Bids[0].Price.ToString();
                tbBidSPBvol.Text = QuotesTi.Bids[0].Quantity.ToString();
            }
            LatestMarketDataRequest DataClientMarcetData = new(Ticker);
            QuotesAlpaca = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
            if (QuotesAlpaca != null)
            {
                tbAskUS.Text = QuotesAlpaca.AskPrice.ToString();
                tbAskUSvol.Text = (QuotesAlpaca.AskSize * 100).ToString();
                tbBidUS.Text = QuotesAlpaca.BidPrice.ToString();
                tbBidUSvol.Text = (QuotesAlpaca.BidSize * 100).ToString();
            }

            if (QuotesTi.Asks.Count > 0)
            {
                if (QuotesTi.Asks[0].Price < QuotesAlpaca.BidPrice)//тут исключение когда нет стакана тиня на индекс
                {
                    var delta_1 = QuotesAlpaca.BidPrice - QuotesTi.Asks[0].Price;
                    if (delta_1 >= SetProfit(QuotesTi.Asks[0].Price))
                    {
                        var q = QuotesAlpaca.BidPrice - QuotesTi.Bids[0].Price;//разница между бидами
                        var s = QuotesAlpaca.BidPrice - 0.19m;
                        if (q <= 0.2m)
                        {
                            numPriceMost.Value = QuotesTi.Bids[0].Price + 0.01m;
                            btGO1.Text = "Low-Спред" + delta_1.ToString();
                        }
                        else if(q > 0.2m && s < QuotesTi.Asks[0].Price)
                        {
                            numPriceMost.Value = QuotesAlpaca.BidPrice - 0.19m;
                            btGO1.Text = "Big-Спред" + delta_1.ToString();
                        }else if (s >= QuotesTi.Asks[0].Price)
                        {
                            numPriceMost.Value = QuotesTi.Bids[0].Price + 0.01m;
                            btGO1.Text = "Crush-Спред" + delta_1.ToString();
                        }


                        btGO1.BackColor = Color.LightGreen;
                        
                        btGO1.Enabled = true;
                        btGO2.Enabled = true;
                    }
                    else
                    {
                        btGO1.BackColor = Color.LightCoral;
                        btGO1.Text = "Sprad is low!";
                        btGO1.Enabled = false;
                        numPriceMost.Value = QuotesTi.Bids[0].Price + 0.01m;
                    }
                }
                else
                {
                    btGO1.BackColor = Color.LightCoral;
                    btGO1.Text = "NO Arbitrage!";
                    btGO1.Enabled = false;
                    numPriceMost.Value = QuotesTi.Bids[0].Price + 0.01m;
                }

            }
            else
            {
                tbAskSPB.Text = "0.00";
                tbAskSPBvol.Text = "0";
                tbBidSPB.Text = "0.00";
                tbBidSPBvol.Text = "0";

                btGO1.BackColor = Color.LightCoral;
                btGO1.Text = "Нет данных стакана!";
                btGO1.Enabled = false;
                btGO2.Enabled = false;
                return;
            }
            
            
        }
        private string PrepareDecimal(string val)//using System.Globalization;
        {
            string separator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
            if (separator == ".")
                return val.Replace(",", ".");
            else if (separator == ",")
                return val.Replace(".", ",");
            else
                return val;
        }
        private void btGO1_Click(object sender, EventArgs e)
        {
            if (Terminal.IB_ApiClient_OnReady)
            {

                if (!ModeOrders)//если по лимитным ордерам в мост
                {
                    if (QuotesTi.Asks[0].Quantity <= 9)
                    {
                        VolTi = Convert.ToInt32(tbAskSPBvol.Text);
                    }
                    else VolTi = 10;
                }
                else//если по рыночным ордерам в мост
                {
                    if (QuotesTi.Asks[0].Quantity <= 5)
                    {
                        VolTi = Convert.ToInt32(tbAskSPBvol.Text);
                    }
                    else VolTi = 5;
                }
                var PriceTiBuy = QuotesTi.Asks[0].Price;
                Tinkoff.LimitOrder(Ticker, VolTi, OperationType.Buy, PriceTiBuy);

            }
        }
        private async void btGO2_Click(object sender, EventArgs e)
        {
            if (Terminal.IB_ApiClient_OnReady)
            {
                if (!ModeOrders)//если по лимитным ордерам продажа в мост
                {
                    var PriceIBMost = numPriceMost.Value;
                    LimitIBOrder(Ticker, "BUY", 1, PriceIBMost, "ISLAND");
                    Debug.WriteLine($"Цена моста: {Ticker} - {PriceIBMost} / 1шт.");
                    Thread.Sleep(3000);
                    await GetQuotesTi();
                    if (QuotesTi.Bids[0].Quantity == 1)
                    {
                        Tinkoff.LimitOrder(Ticker, VolTi, OperationType.Sell, PriceIBMost);
                        Debug.WriteLine($"Цена продажи: {Ticker} - {PriceIBMost} / {VolTi}шт.");
                    }
                    else
                    {
                        btGO2.Text = "ММ встает в бид!";
                    }
                }
                else//если по рыночным ордерам продажа в мост
                {
                    var PriceIBMost = numPriceMost.Value;
                    if (!CheckMost)
                    {
                        LimitIBOrder(Ticker, "BUY", VolTi, PriceIBMost, "ISLAND");
                        CheckMost = true;
                        Thread.Sleep(3000);
                    }
                    await GetQuotesTi();
                    if (QuotesTi.Bids[0].Quantity == 5)
                    {
                        Tinkoff.MarketOrder(Ticker, VolTi, OperationType.Sell);
                    }
                    else
                    {
                        btGO2.Text = "ММ встает в бид!";
                    }

                }

            }
        }

        private void LimitIBOrder(string t, string buy_sell, int q, decimal price, string ex)
        {
            Terminal.ApiWrapper.OrderPlace(t, buy_sell, q, price, ex);
        }
        private async Task GetQuotesTi()//получаем котировки у пустых тикеров
        {
            foreach (var item in marketInstruments)
            {
                if (item.Ticker == Ticker)
                {
                    QuotesTi = await Terminal.Context_Ti.MarketOrderbookAsync(item.Figi, 1);
                    return;
                }
            }
        }
        private async void btReload_Click(object sender, EventArgs e)
        {
            var group = 3;
            var ticker = Ticker;
            await Terminal._websocketserver.SendAll(JsonConvert.SerializeObject(new { ticker, group }));
            LoadQuotes();
        }
        private decimal SetProfit(decimal price)
        {
            decimal profit = Math.Round(price * 0.0005m + 0.02m, 2);
            return profit;
        }

        private void btCancelOrder_Click(object sender, EventArgs e)
        {
            Terminal.ApiWrapper.CancelLastOrder();
            CheckMost = false;
        }

        private void tbBidUS_Click(object sender, EventArgs e)
        {
            numPriceMost.Value = QuotesAlpaca.BidPrice;
        }

        private void tbBidSPB_Click(object sender, EventArgs e)
        {
            numPriceMost.Value = QuotesTi.Bids[0].Price + 0.01m;
        }

        private void ArbCheckForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
        }
    }
}




