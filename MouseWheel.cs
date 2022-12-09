using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;



namespace FishingSizes
{

    public class MouseWheel
    {
        TextBox tbControl { get; set; }
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pnt);

        public MouseWheel(TextBox tbcontrol)
        {
            tbControl = tbcontrol;
        }

        public void tbPrice_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (tbControl.Text != "")
                {
                    tbControl.Text = (decimal.Parse(PrepareDecimal(tbControl.Text)) + 0.01m).ToString();
                    Debug.WriteLine($"Прокрутка мыши ->: {e.Delta} : {tbControl.Text}");
                }
                else tbControl.Text = "0,01";
            }
            else
            {
                if (tbControl.Text != "")
                {
                    tbControl.Text = (decimal.Parse(PrepareDecimal(tbControl.Text)) - 0.01m).ToString();
                    if (decimal.Parse(tbControl.Text) <= 0)
                        tbControl.Text = "0,01";
                    Debug.WriteLine($"Прокрутка мыши <-: {e.Delta} : {tbControl.Text}");
                }else tbControl.Text = "0,01";
            }
        }

        public void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            IntPtr hWnd = WindowFromPoint(Control.MousePosition);
            if (hWnd != IntPtr.Zero)
            {
                Control ctl = Control.FromHandle(hWnd);
                if (ctl == tbControl) tbPrice_MouseWheel(null, e);
            }
        }




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



    }
}
