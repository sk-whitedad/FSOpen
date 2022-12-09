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
using Tinkoff.Trading.OpenApi.Network;
using Tinkoff.Trading.OpenApi.Models;

namespace FishingSizes
{
    public partial class LimitOrderActiv : UserControl
    {
        public LimitOrderActiv()
        {
            InitializeComponent();
        }

        private async void btDel_Click(object sender, EventArgs e)
        {
            if (btDel.Text == "Cancel")
            {
                tbPriceLimit.Visible = false;
                numLotsLimit.Visible = false;
                btDel.Text = "Del";
                return;
            }

            if (btDel.Text == "Del")
            {
                Control control = (btDel.Parent).Parent;
                control.Controls.Remove(btDel.Parent);
                btDel.Parent.Dispose();
                for (int i = 0; i < FormActivOrders.ActivOrdersList.Count; i++)
                {
                    if (btDel.Tag.ToString() == FormActivOrders.ActivOrdersList[i].OrderId)
                    {
                        await Terminal.Context_Ti.CancelOrderAsync(FormActivOrders.ActivOrdersList[i].OrderId, null);
                        FormActivOrders.ActivOrdersList.RemoveAt(i);
                    }
                }
            }
        }

        private async void btEditOrder_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            Control control = (button.Parent).Parent;
            var ticker = lbTicker.Text;
            if (btEditOrder.Text == "Save")
            {
                for (int i = 0; i < FormActivOrders.ActivOrdersList.Count; i++)
                {
                    if (btEditOrder.Tag.ToString() == FormActivOrders.ActivOrdersList[i].OrderId)
                    {
                        await Terminal.Context_Ti.CancelOrderAsync(FormActivOrders.ActivOrdersList[i].OrderId, null);
                        TinkoffMy Ti = new TinkoffMy(ticker);
                        await Ti.LimitOrder(ticker, (int)numLotsLimit.Value, FormActivOrders.ActivOrdersList[i].Operation, Convert.ToDecimal(tbPriceLimit.Text));
                        var order = new Order(Ti.OrderID[Ti.OrderID.Count -1], FormActivOrders.ActivOrdersList[i].Figi, FormActivOrders.ActivOrdersList[i].Operation, FormActivOrders.ActivOrdersList[i].Status, (int)numLotsLimit.Value, FormActivOrders.ActivOrdersList[i].ExecutedLots, FormActivOrders.ActivOrdersList[i].Type, Convert.ToDecimal(tbPriceLimit.Text));
                        FormActivOrders.ActivOrdersList.RemoveAt(i);
                        FormActivOrders.ActivOrdersList.Add(order);
                        btDel.Tag = Ti.OrderID[Ti.OrderID.Count - 1];
                        btEditOrder.Tag = Ti.OrderID[Ti.OrderID.Count - 1];
                        lbPrice.Text = tbPriceLimit.Text;
                        lbVol.Text = numLotsLimit.Value.ToString();
                        btEditOrder.Text = "Edit";
                        btDel.Text = "Del";
                        tbPriceLimit.Visible = false;
                        numLotsLimit.Visible = false;
                        
                    }
                }
                return;
            }

            if (btEditOrder.Text == "Edit")
            {
                tbPriceLimit.Visible = true;
                numLotsLimit.Visible = true;
                tbPriceLimit.Text = lbPrice.Text;
                numLotsLimit.Value = int.Parse(lbVol.Text);
                btEditOrder.Text = "Save";
                btDel.Text = "Cancel";
            }
        }
    }
}
