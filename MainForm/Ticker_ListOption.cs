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

namespace FishingSizes
{
    public partial class Ticker_ListOption : UserControl
    {
        public Ticker_ListOption()
        {
            InitializeComponent();
        }


        private void Ticker_ListOption_Load(object sender, EventArgs e)
        {
            lbTickerList.Items.Clear(); 
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            //проверка на существование тикера в списке
            var i = false;
            foreach (var item in lbTickerList.Items)
            {
                Debug.WriteLine($"item  : {item}");
                if (item.ToString() == tbTickerAdd.Text.Trim().ToUpper())
                {
                    Debug.WriteLine($"item---  : {item}");
                    i = true;
                    break;
                }
            }
            if (!i)
            {
                //проверка на существование тикера в списке тикеров тиня
                i = true;
                foreach (var item in Terminal.MarketStocks.Instruments)
                {
                    if (item.Ticker == tbTickerAdd.Text.Trim().ToUpper())
                    {
                        i = false;
                        break;
                    }
                }
            }
            if (!i)
            lbTickerList.Items.Add(tbTickerAdd.Text.Trim().ToUpper());
            
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            //удаление тикеров из списка
            if (lbTickerList.SelectedItem != null)
            {
                lbTickerList.Items.Remove(lbTickerList.SelectedItem);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //сохранение избранных тикеров в файл
            var formWithSett = this.FindForm() as IHasTickerList; // стандартный метод который вернет форму на которой находится контрол
            formWithSett.Sett_tle.MyTickerList.Clear();
            Terminal.TickerList.Clear();
            if (formWithSett != null)
            {
                foreach (var item in lbTickerList.Items)
                {
                    formWithSett.Sett_tle.MyTickerList.Add(item.ToString());
                    Terminal.TickerList.Add(item.ToString());
                }
                formWithSett.Sett_tle.SaveSett(formWithSett.Sett_tle);
                this.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbTickerList.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
