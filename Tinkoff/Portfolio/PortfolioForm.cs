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
using System.Text.Json;

namespace FishingSizes
{
    interface IRowGridPortfolio
    {
        void AppendRow(RowGridPortfolio rowgridportfolio);
        void UpdateRow(RowGridPortfolio rowgridportfolio);
    }


    public partial class PortfolioForm : Form, IRowGridPortfolio
    {
        BindingList<RowGridPortfolio> data; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        PortfolioTinkoff portfolioTi;
         string Ticker;

        public PortfolioForm()
        {
            InitializeComponent();
        }

        private async void PortfolioForm_Load(object sender, EventArgs e)
        {
            var column1 = new DataGridViewColumn
            {
                HeaderText = "Тикер", //текст в шапке
                Name = "ticker", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Ticker),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };
            var column2 = new DataGridViewColumn
            {
                HeaderText = "Всего", //текст в шапке
                Name = "count", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Count),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 70
            };
            var column3 = new DataGridViewColumn
            {
                HeaderText = "Средняя", //текст в шапке
                Name = "middle", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Middle),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };
            var column4 = new DataGridViewColumn
            {
                HeaderText = "Сумма", //текст в шапке
                Name = "summ", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Summ),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };
            var column5 = new DataGridViewColumn
            {
                HeaderText = "Блок", //текст в шапке
                Name = "block", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Block),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 50
            };
            var column6 = new DataGridViewColumn
            {
                HeaderText = "Доступно", //текст в шапке
                Name = "accessibly", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Accessibly),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 110
            };
            var column7 = new DataGridViewColumn
            {
                HeaderText = "Цена", //текст в шапке
                Name = "price", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Price),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 50
            };
            var column8 = new DataGridViewColumn
            {
                HeaderText = "Доход", //текст в шапке
                Name = "profit", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridPortfolio.Profit),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPortfolio.Columns.Clear();
            dgvPortfolio.Columns.Add(column1);
            dgvPortfolio.Columns.Add(column2);
            dgvPortfolio.Columns.Add(column6);
            dgvPortfolio.Columns.Add(column5);
            dgvPortfolio.Columns.Add(column3);
            dgvPortfolio.Columns.Add(column4);
            dgvPortfolio.Columns.Add(column7);
            dgvPortfolio.Columns.Add(column8);
            dgvPortfolio.AllowUserToAddRows = false; //запрещаем самому добавлять строки
            dgvPortfolio.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvPortfolio.RowHeadersVisible = false;
            dgvPortfolio.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvPortfolio.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dgvPortfolio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            data = new BindingList<RowGridPortfolio>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvPortfolio.DataSource = data;
            dgvPortfolio.Rows.Clear();

            portfolioTi = new PortfolioTinkoff(this);
            portfolioTi.LoadPortfolio();
            portfolioTi.SendPortfolioToForm();
            await portfolioTi.SubscribeCandleTi();
        }

        public void AppendRow(RowGridPortfolio rowgrid)
        {
            if (this.InvokeRequired && data != null) // если требуется вызов из главного UI потока
            {
                this.Invoke((Action)(() =>
                {
                    if (rowgrid.Ticker == "USD000UTSTOM")
                    {
                        rowgrid.Ticker = "USD";
                    }
                    data.Insert(0, rowgrid);
                }
                   )); // передаем функцию, которая будет вызвана в потоке формы
            }
            else
            {
                if (rowgrid.Ticker == "USD000UTSTOM")
                {
                    rowgrid.Ticker = "USD";
                }
                data.Insert(0, rowgrid);
            }
        }

        public void UpdateRow(RowGridPortfolio rowgrid)
        {
            string _ticker;
            if (this.InvokeRequired && data != null) // если требуется вызов из главного UI потока
            {
                
                this.Invoke((Action)(() =>
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        _ticker = data[i].Ticker;
                        if (_ticker == "USD")
                        {
                            _ticker = "USD000UTSTOM";
                        }

                        if (_ticker == rowgrid.Ticker)
                        {
                            if (rowgrid.Profit < 0)
                            {
                                dgvPortfolio[7, i].Style.ForeColor = Color.Red;
                            }
                            if (rowgrid.Profit == 0)
                            {
                                dgvPortfolio[7, i].Style.ForeColor = Color.Black;
                            }
                            if (rowgrid.Profit > 0)
                            {
                                dgvPortfolio[7, i].Style.ForeColor = Color.Green;
                            }
                            dgvPortfolio[7, i].Value = rowgrid.Profit;
                            dgvPortfolio[6, i].Value = rowgrid.Price;
                        }
                    }
                }
                   )); // передаем функцию, которая будет вызвана в потоке формы
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    _ticker = data[i].Ticker;
                    if (_ticker == "USD")
                    {
                        _ticker = "USD000UTSTOM";
                    }

                    if (_ticker == rowgrid.Ticker)
                    {
                        if (rowgrid.Profit < 0)
                        {
                            dgvPortfolio[7, i].Style.ForeColor = Color.Red;
                        }
                        if (rowgrid.Profit == 0)
                        {
                            dgvPortfolio[7, i].Style.ForeColor = Color.Black;
                        }
                        if (rowgrid.Profit > 0)
                        {
                            dgvPortfolio[7, i].Style.ForeColor = Color.Green;
                        }
                        dgvPortfolio[7, i].Value = rowgrid.Profit;
                        dgvPortfolio[6, i].Value = rowgrid.Price;
                    }
                }
            }
        }

        private async void PortfolioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            portfolioTi.cancelTokenSource.Cancel();
            await portfolioTi.UnsubscribeCandles();
        }

        private async void dgvPortfolio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            await portfolioTi.UnsubscribeCandles();
            portfolioTi.LoadPortfolio();
            data.Clear();
            Terminal.PortfolioTi = await Terminal.Context_Ti.PortfolioAsync(null);//получение объекта портфеля
            Terminal.TickersListCandlesTi.Clear();
            for (int i = 0; i < Terminal.PortfolioTi.Positions.Count; i++)//заполнение списка бумаг портфеля
            {
                Terminal.TickersListCandlesTi.Add(Terminal.PortfolioTi.Positions[i].Ticker);
            }

            Terminal.portfolioCurrencies = await Terminal.Context_Ti.PortfolioCurrenciesAsync();//получаем рублевый баланс
            for (int i = 0; i < Terminal.portfolioCurrencies.Currencies.Count; i++)
            {
                if (Terminal.portfolioCurrencies.Currencies[i].Currency.ToString() == "Rub")
                {
                    Terminal.positionRub = new PositionRub("RUB", Terminal.portfolioCurrencies.Currencies[i].Balance, Terminal.portfolioCurrencies.Currencies[i].Blocked);
                }
            }

            portfolioTi.SendPortfolioToForm();
            await portfolioTi.SubscribeCandleTi();
            Debug.WriteLine("Dubble click!");
        }

        private void tsCreateOrder_Click(object sender, EventArgs e)
        {
            OrdersForm newForm = new OrdersForm(Ticker);
            newForm.Show();
        }

        private void dgvPortfolio_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgvControl = sender as DataGridView;
            if (e.Button.ToString() == "Right")
            {
                Ticker = dgvControl.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void tsActiveOrders_Click(object sender, EventArgs e)
        {
            FormActivOrders newForm = new FormActivOrders(Ticker);
            newForm.Show();
        }

        private void tsHistoryOrders_Click(object sender, EventArgs e)
        {
            HistoryOrdersForm newForm = new HistoryOrdersForm(Ticker);
            newForm.Show();
        }
    }
}
