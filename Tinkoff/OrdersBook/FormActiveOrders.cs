using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tinkoff.Trading.OpenApi.Network;
using Tinkoff.Trading.OpenApi.Models;
using System.Collections.Concurrent;
using System.Diagnostics;
using FishingSizes.DataBase;

namespace FishingSizes
{
    public partial class FormActivOrders : Form
    {
        public static List<Order> ActivOrdersList = new();
        string Ticker { get; set; }
        private MethodsDB methodsCoordinates;
        //public ConcurrentDictionary<int, Order> LimitOrderActivList = new ConcurrentDictionary<int, Order>();

        public FormActivOrders()
        {
            InitializeComponent();
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }
        public FormActivOrders(string ticker)
        {
            InitializeComponent();
            Ticker = ticker;
        }

        public async void FormTest_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            ActivOrdersList = await Terminal.Context_Ti.OrdersAsync(null);
            LocalMethod();
            while (true)
            {
                List<Order> _ActivOrdersList = new List<Order>();
                foreach (Order order in ActivOrdersList)
                {
                    _ActivOrdersList.Add(order);
                }
                ActivOrdersList = await Terminal.Context_Ti.OrdersAsync(null);
                Debug.WriteLine($" == Первая == : {ActivOrdersList.Count} : {_ActivOrdersList.Count}");
                for (int i = 0; i < ActivOrdersList.Count; i++)
                {
                    if (_ActivOrdersList.Count > 0 && ActivOrdersList.Count > 0 && ActivOrdersList[i].OrderId != _ActivOrdersList[i].OrderId)
                    {
                        flpListBox.Controls.Clear();
                        LocalMethod();
                        Debug.WriteLine($" == Вторая == : {ActivOrdersList[i].OrderId} : {_ActivOrdersList[i].OrderId}");
                        break;
                    }
                }
                if (ActivOrdersList.Count != _ActivOrdersList.Count)
                {
                    flpListBox.Controls.Clear();
                    LocalMethod();
                    Debug.WriteLine($" == Третья == : {ActivOrdersList.Count} : {_ActivOrdersList.Count}");
                }
                await Task.Delay(5000);
            }

        }
        public async void FormTest_Load(object sender, EventArgs e, string ticker)
        {
            ActivOrdersList = await Terminal.Context_Ti.OrdersAsync(null);
            LocalMethod();
            while (true)
            {
                List<Order> _ActivOrdersList = new List<Order>();
                foreach (Order order in ActivOrdersList)
                {
                    _ActivOrdersList.Add(order);
                }
                ActivOrdersList = await Terminal.Context_Ti.OrdersAsync(null);
                Debug.WriteLine($" == Первая == : {ActivOrdersList.Count} : {_ActivOrdersList.Count}");
                for (int i = 0; i < ActivOrdersList.Count; i++)
                {
                    if (_ActivOrdersList.Count > 0 && ActivOrdersList.Count > 0 && ActivOrdersList[i].OrderId != _ActivOrdersList[i].OrderId)
                    {
                        flpListBox.Controls.Clear();
                        LocalMethod();
                        Debug.WriteLine($" == Вторая == : {ActivOrdersList[i].OrderId} : {_ActivOrdersList[i].OrderId}");
                        break;
                    }
                }
                if (ActivOrdersList.Count != _ActivOrdersList.Count)
                {
                    flpListBox.Controls.Clear();
                    LocalMethod();
                    Debug.WriteLine($" == Третья == : {ActivOrdersList.Count} : {_ActivOrdersList.Count}");
                }
                await Task.Delay(5000);
            }

        }

        public void LocalMethod()
        {
            for (int i = 0; i < ActivOrdersList.Count; i++)
            {
                LimitOrderActiv limitOrderActiv = new LimitOrderActiv();
                limitOrderActiv.Margin = new Padding(1);
                limitOrderActiv.Visible = false;
                for (int k = 0; k < Terminal.MarketStocks.Instruments.Count; k++)
                {
                    if (Terminal.MarketStocks.Instruments[k].Figi == ActivOrdersList[i].Figi && Terminal.MarketStocks.Instruments[k].Ticker == Ticker)
                    {
                        limitOrderActiv.lbTicker.Text = Terminal.MarketStocks.Instruments[k].Ticker;
                        limitOrderActiv.lbPrice.Text = ActivOrdersList[i].Price.ToString();
                        limitOrderActiv.lbVol.Text = ActivOrdersList[i].RequestedLots.ToString();
                        if (ActivOrdersList[i].Operation == OperationType.Buy)
                        {
                            limitOrderActiv.BackColor = Color.PaleGreen;
                            limitOrderActiv.lbTextBaySell.Text = "Покупка по цене:";
                        }
                        if (ActivOrdersList[i].Operation == OperationType.Sell)
                        {
                            limitOrderActiv.BackColor = Color.Salmon;
                            limitOrderActiv.lbTextBaySell.Text = "Продажа по цене:";
                        }
                        limitOrderActiv.btDel.Tag = ActivOrdersList[i].OrderId;
                        limitOrderActiv.btEditOrder.Tag = ActivOrdersList[i].OrderId;
                        limitOrderActiv.Visible = true;
                    }
                }
                flpListBox.Controls.Add(limitOrderActiv);
            }
        }//заполнение формы контролами заявок

        private void FormActivOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
            // methodsCoordinates.UpdateBD(this.Left, this.Top, this.Size);
        }
    }
}
