using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FishingSizes.DataBase;

namespace FishingSizes
{
    interface IRowGridHistoryOrders
    {
        void AppendRow(RowGridHistoryOrders rowgrid);
        void UpdateRow(RowGridHistoryOrders rowgrid);
    }


    public partial class HistoryOrdersForm : Form, IRowGridHistoryOrders
    {
        string Ticker { get; set; }
        BindingList<RowGridHistoryOrders> data; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        HistoryOrders historyorders;
        private MethodsDB methodsCoordinates;

        public HistoryOrdersForm(string ticker)
        {
            InitializeComponent();
            Ticker = ticker;
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private async void HistoryOrdersForm_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            var column1 = new DataGridViewColumn
            {
                HeaderText = "Тикер", //текст в шапке
                Name = "ticker", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridHistoryOrders.Ticker),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 56
            };
            var column2 = new DataGridViewColumn
            {
                HeaderText = "Дата", //текст в шапке
                Name = "date", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridHistoryOrders.Date),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 109
            };
            var column3 = new DataGridViewColumn
            {
                HeaderText = "Кол-во", //текст в шапке
                Name = "vol", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridHistoryOrders.Vol),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 61
            };
            var column4 = new DataGridViewColumn
            {
                HeaderText = "Цена", //текст в шапке
                Name = "price", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridHistoryOrders.Price),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 50
            };
            var column5 = new DataGridViewColumn
            {
                HeaderText = "Сумма", //текст в шапке
                Name = "summ", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridHistoryOrders.Summ),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 65
            };
            var column6 = new DataGridViewColumn
            {
                HeaderText = "Тип", //текст в шапке
                Name = "type", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridHistoryOrders.TypeOrder),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 40
            };
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistoryOrders.Columns.Clear();
            dgvHistoryOrders.Columns.Add(column1);
            dgvHistoryOrders.Columns.Add(column2);
            dgvHistoryOrders.Columns.Add(column3);
            dgvHistoryOrders.Columns.Add(column4);
            dgvHistoryOrders.Columns.Add(column5);
            dgvHistoryOrders.Columns.Add(column6);
            dgvHistoryOrders.AllowUserToAddRows = false; //запрещаем самому добавлять строки
            dgvHistoryOrders.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvHistoryOrders.RowHeadersVisible = false;
            dgvHistoryOrders.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvHistoryOrders.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dgvHistoryOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            data = new BindingList<RowGridHistoryOrders>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvHistoryOrders.DataSource = data;
            dgvHistoryOrders.Rows.Clear();
            dgvHistoryOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.Empty;//отключаем альтернативный стиль строк

            historyorders = new HistoryOrders(this, Ticker);
            await historyorders.LoadHistoryOrders();
            historyorders.SendHistoryToForm();

        }

        public void AppendRow(RowGridHistoryOrders rowgrid)
        {
            if (this.InvokeRequired && data != null) // если требуется вызов из главного UI потока
            {
                this.Invoke((Action)(() =>
                {
                    data.Add(rowgrid);
                    if (rowgrid.TypeOrder == "Buy")
                    {
                        //dgvHistoryOrders.RowsDefaultCellStyle.BackColor = Color.LightGreen;
                        dgvHistoryOrders.Rows[dgvHistoryOrders.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    if (rowgrid.TypeOrder == "Sell")
                    {
                        dgvHistoryOrders.Rows[dgvHistoryOrders.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
                        //dgvHistoryOrders.RowsDefaultCellStyle.BackColor = Color.LightCoral;
                    }

                }
                   )); // передаем функцию, которая будет вызвана в потоке формы
            }
            else
            {
                data.Add(rowgrid);
                if (rowgrid.TypeOrder == "Buy")
                {
                    //dgvHistoryOrders.RowsDefaultCellStyle.BackColor = Color.LightGreen;
                    dgvHistoryOrders.Rows[dgvHistoryOrders.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                if (rowgrid.TypeOrder == "Sell")
                {
                    //dgvHistoryOrders.RowsDefaultCellStyle.BackColor = Color.LightCoral;
                    dgvHistoryOrders.Rows[dgvHistoryOrders.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        public void UpdateRow(RowGridHistoryOrders rowgrid)
        {
            
        }

        private void HistoryOrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
            historyorders.cancelTokenSource.Cancel();
        }
    }
}
