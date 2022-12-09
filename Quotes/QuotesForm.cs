using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alpaca.Markets;
using FishingSizes.DataBase;

namespace FishingSizes
{
    public partial class QuotesForm : Form, IRowGridQuotes
    {
        BindingList<RowGridQuotes> data; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        Quotes quotes;
        public Settings Sett { get; set; }
        string Ticker { get; set; }
        private MethodsDB methodsCoordinates;

        public QuotesForm()
        {
            InitializeComponent();
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private async void QuotesForm_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним


            var column1 = new DataGridViewColumn
            {
                HeaderText = "ММ", //текст в шапке
                Name = "exchBid", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.ExchangeBid),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 40
               
            };
            var column3 = new DataGridViewColumn
            {
                HeaderText = "БИД", //текст в шапке
                Name = "priceBid", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.PriceBid),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };
            var column2 = new DataGridViewColumn
            {
                HeaderText = "КОЛ-ВО", //текст в шапке
                Name = "quantityBid", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.QuantityBid),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 75
            };
            var column4 = new DataGridViewColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 9
            };
            var column6 = new DataGridViewColumn
            {
                HeaderText = "КОЛ-ВО", //текст в шапке
                Name = "quantityAsk", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.QuantityAsk),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 75
            };
            var column5 = new DataGridViewColumn
            {
                HeaderText = "АСК", //текст в шапке
                Name = "priceAsk", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.PriceAsk),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };
            var column7 = new DataGridViewColumn
            {
                HeaderText = "ММ", //текст в шапке
                Name = "exchAsk", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.ExchangeAsk),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 40
                
            };

            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column4.DefaultCellStyle.BackColor = Color.Gray;
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            column2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            column3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            column5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column7.HeaderCell.Style.BackColor = Color.Red;
            dgvQuotes.Columns.Clear();
            dgvQuotes.Columns.Add(column1);
            dgvQuotes.Columns.Add(column2);
            dgvQuotes.Columns.Add(column3);
            dgvQuotes.Columns.Add(column4);
            dgvQuotes.Columns.Add(column5);
            dgvQuotes.Columns.Add(column6);
            dgvQuotes.Columns.Add(column7);
            dgvQuotes.AllowUserToAddRows = false; //запрещаем самому добавлять строки
            dgvQuotes.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvQuotes.RowHeadersVisible = false;
            dgvQuotes.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvQuotes.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dgvQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            data = new BindingList<RowGridQuotes>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvQuotes.DataSource = data;

            var settings = new Settings();
            await settings.LoadSett();
                Sett = settings;
                Ticker = cbTicker.Text.Trim().ToUpper(); ;
                if (Ticker != null) SubscribeQuotes();
        }

        private void SubscribeQuotes()
        {
            quotes = new Quotes(Sett, Ticker, this);
            quotes.DoSomethingAfterConnect();
        }


        public void AppendRowQ(RowGridQuotes rowgridQ)
        {
            if (this.InvokeRequired && data != null) // если требуется вызов из главного UI потока
            {
                try
                {
                    this.Invoke((Action)(() =>
                    {
                        data.Clear();
                        data.Insert(0, rowgridQ);
                    })); // передаем функцию, которая будет вызвана в потоке формы
                    
                }
                catch
                {
                }
            }
            else
            {
                data.Clear();
                data.Insert(0, rowgridQ);
            }
        }

        public void SetSprad(string newSprad)
        {
            DoOnUI(() => lbSprad.Text = newSprad);
        }
        
        private void DoOnUI(Action act)
        {
            if (this.InvokeRequired)
                this.Invoke(act);
            else
                act();
        }

        private void QuotesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
            quotes.Unsubscribe(Ticker);
        }


        private async void CbTicker_TextChanged(object sender, EventArgs e)
        {
            quotes.Unsubscribe(Ticker);
            await Task.Delay(1000);
            Ticker = cbTicker.Text.Trim().ToUpper(); ;
            dgvQuotes.Rows.Clear();
            quotes.Subscribe(Ticker);
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
    }
}
