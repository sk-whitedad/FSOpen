using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace FishingSizes
{
    public partial class FormIBOrders : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pnt);
        public static TWSApiWrapper ApiWrapper => ApiProgram.ApiWrapper;

        public FormIBOrders()
        {
            InitializeComponent();
            tbQuantity.MouseWheel += new MouseEventHandler(this.tbQuantity_MouseWheel);
            tbPrice.MouseWheel += new MouseEventHandler(this.tbPrice_MouseWheel);
            MouseWheel += new MouseEventHandler(this.Form1_MouseWheel);
        }

        /// <summary>
        /// Функция для преобразования строки с дробным числом в нужный формат в зависимости от текущих региональных настроек
        /// </summary>
        /// <param name="val">Строка с числом</param>
        /// <returns>Строка с числом с правильным разделителем целой и дробной части</returns>
        private string PrepareDecimal(string val)
        {
            string separator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
            if (separator == ".")
                return val.Replace(",", ".");
            else if (separator == ",")
                return val.Replace(".", ",");
            else
                return val;
        }

        private void placeOrderButtonHandler(object sender, EventArgs e)
        {
            try
            {
                var ticker = tbTicker.Text;
                var quantity = int.Parse(tbQuantity.Text);
                var price = decimal.Parse(PrepareDecimal(tbPrice.Text));
                var exchange = cbExchange.Text;
                var action = (sender as Button).Tag as string; // у кнопки в Tag задаем BUY или SELL чтобы один обработчик был на обе
                //Program.ApiWrapper.OrderPlace(ticker, action, quantity, price, exchange);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Какие-то поля не заполнены или некорректны: " + ex.Message);
            }
            btnCancelLast.Enabled = true;
        }

        private void button_CancelAll(object sender, EventArgs e)
        {
            //Program.ApiWrapper.CancelOrdersAll();
        }

        private void button_CancelLast(object sender, EventArgs e)
        {
            //Program.ApiWrapper.CancelLastOrder();
            btnCancelLast.Enabled = false;
        }
        private void tbPrice_MouseWheel(object sender, MouseEventArgs e)
        {
            if (sender == null && tbQuantity.Focused)
                return;

            if (e.Delta > 0)
                tbPrice.Text = PrepareDecimal((decimal.Parse(PrepareDecimal(tbPrice.Text)) + (decimal)1/100).ToString());
            else
            {
                tbPrice.Text = PrepareDecimal((decimal.Parse(PrepareDecimal(tbPrice.Text)) - (decimal)1/100).ToString());
                if (decimal.Parse(tbPrice.Text) <= 0)
                    tbPrice.Text = "0,01";
            }
        }
        private void tbQuantity_MouseWheel(object sender, MouseEventArgs e)
        {
            if (sender == null && tbPrice.Focused)
                return;

            if (e.Delta > 0)
                tbQuantity.Text = (int.Parse(tbQuantity.Text) + 1).ToString();
            else
            {
                tbQuantity.Text = (int.Parse(tbQuantity.Text) - 1).ToString();
                if (int.Parse(tbQuantity.Text) <= 0)
                    tbQuantity.Text = "1";
            }
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            IntPtr hWnd = WindowFromPoint(Control.MousePosition);
            if (hWnd != IntPtr.Zero)
            {
                Control ctl = Control.FromHandle(hWnd);
                if (ctl == tbQuantity) tbQuantity_MouseWheel(null, e);
                else if (ctl == tbPrice) tbPrice_MouseWheel(null, e);
            }
        }
    }
}
