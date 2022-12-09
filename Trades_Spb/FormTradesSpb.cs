using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using System.Diagnostics;
using FishingSizes.DataBase;

namespace FishingSizes
{
    public partial class FormTradesSpb : Form, IRowGridSpb
    {
        private BindingList<RowGridSpb> data; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        private TradesSpb trades;
        private Settings Sett { get; set; }
        private string Ticker { get; set; }
        public int? FiltrTradesLow { get; set; }
        public int? FiltrTradesHight { get; set; }
        ResetPrintsForm rstprints;
        private MethodsDB methodsCoordinates;

        public FormTradesSpb()
        {
            InitializeComponent();
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private async void FormTradesSpb_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            cbTicker.Items.Clear();
            foreach (var item in Terminal.TickerList)
                    cbTicker.Items.Add(item);
            //формирование таблицы ленты принтов
            var column1 = new DataGridViewColumn
            {
                HeaderText = "ЦЕНА", //текст в шапке
                Name = "price", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridSpb.Price),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 64
            };
            var column2 = new DataGridViewColumn
            {
                HeaderText = "КОЛ-ВО",
                Name = "quantity",
                DataPropertyName = nameof(RowGridSpb.Quantity),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 61
            };
            var column3 = new DataGridViewColumn
            {
                HeaderText = "СУММА",
                Name = "exchange",
                DataPropertyName = nameof(RowGridSpb.Summ),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 80
            };
            var column4 = new DataGridViewColumn
            {
                HeaderText = "ВРЕМЯ",
                Name = "time",
                DataPropertyName = nameof(RowGridSpb.Time),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 77
            };


            dgvTrades.Columns.Clear();
            dgvTrades.Columns.Add(column1);
            dgvTrades.Columns.Add(column2);
            dgvTrades.Columns.Add(column3);
            dgvTrades.Columns.Add(column4);
            dgvTrades.AllowUserToAddRows = false; //запрешаем самому добавлять строки
            dgvTrades.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvTrades.RowHeadersVisible = false;
            dgvTrades.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            data = new BindingList<RowGridSpb>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvTrades.DataSource = data;
            dgvTrades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            var settings = new Settings();
            await settings.LoadSett();
            Sett = settings;
            FiltrTradesLow = null;
            FiltrTradesHight = null;
            rstprints = new ResetPrintsForm(dgvTrades);//сброс ленты принтов на форме
        }

        public void AppendRow(RowGridSpb rowgrid, Color colorPrint, string sprad, (int, int)ls)
        {
            if (this.InvokeRequired && data != null) // если требуется вызов из главного UI потока
            {
                try
                {
                    this.Invoke((Action)(() =>
                    {
                        if (rowgrid.Time != null)
                        {
                            rstprints.RstPrints();
                            data.Insert(0, rowgrid);
                            dgvTrades.Rows[0].DefaultCellStyle.ForeColor = colorPrint;
                            dgvTrades.Rows[0].DefaultCellStyle.BackColor = Color.White;
                            lbL.Text = ls.Item1.ToString();
                            lbS.Text = ls.Item2.ToString();
                        }
                        else lbSprad.Text = sprad;
                    }
                    )); // передаем функцию, которая будет вызвана в потоке формы
                }
                catch
                {
                }

            }
            else
            {
                if (rowgrid.Time != null)
                {
                    rstprints.RstPrints();
                    data.Insert(0, rowgrid);
                    dgvTrades.Rows[0].DefaultCellStyle.ForeColor = colorPrint;
                    dgvTrades.Rows[0].DefaultCellStyle.BackColor = Color.White;
                    lbL.Text = ls.Item1.ToString();
                    lbS.Text = ls.Item2.ToString();
                }
                else lbSprad.Text = sprad;

            }
        }

        private async void cbTicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !Sett.AlorUses)
            {
                var new_ticker = cbTicker.Text.Trim().ToUpper();
                var old_ticker = Ticker;
                lbL.Text = lbS.Text = "50";
                cbTicker_Subs_Trades_Quotes(new_ticker, old_ticker);
                if (cbOpenTi.Checked)//открытие тикера в ТИ
                {
                    var ticker = Ticker;
                    var group = 3;
                    await Terminal._websocketserver.SendAll(JsonConvert.SerializeObject(new { ticker, group }));
                }
            }
        }

        public void cbTicker_Subs_Trades_Quotes(string new_ticker, string old_ticker)
        {
            if (trades != null)//если форма уже открыта с тикером, то отписываемся от старого тикера
            {
                trades.UnsubscribeQuotes(old_ticker);
                trades.UnsubscribeTrades(old_ticker);
                trades = null;
            }
            if (cbTicker.Text != "")
            {
                Ticker = new_ticker;
                trades = new TradesSpb(Sett, new_ticker, this);
                dgvTrades.Rows.Clear();
                trades.Subscribe(new_ticker);
                bool i = false;
                foreach (var k in cbTicker.Items)
                {
                    if (k.ToString().Contains(new_ticker))//проверяем наличие тикера в списке cbTicker.Items
                    {
                        i = true;
                        break;
                    }
                }
                if (!i) cbTicker.Items.Insert(0, new_ticker);//добавляем тикер в список cbTicker.Items
            }
        }

        private void FormTradesSpb_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
        }
    }
}
