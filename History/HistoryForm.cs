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
    public partial class HistoryForm : Form, IRowGridHistory
    {
        BindingList<RowGridHistoryTrade> data; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        public Settings Sett { get; set; }
        string Ticker { get; set; }
        History history;
        public int? FiltrTradesLow { get; set; }
        public int? FiltrTradesHight { get; set; }
        private MethodsDB methodsCoordinates;

        public HistoryForm()
        {
            InitializeComponent();
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            if (Terminal.AlpacaConnected == true)
            {
                btnGetHistory.Enabled= true;
            } else btnGetHistory.Enabled = false;
            var column1 = new DataGridViewColumn
            {
                HeaderText = "ЦЕНА", //текст в шапке
                Name = "price", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGrid.Price),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };

            var column2 = new DataGridViewColumn
            {
                HeaderText = "КОЛ-ВО",
                Name = "quantity",
                DataPropertyName = nameof(RowGrid.Quantity),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 90
            };

            var column3 = new DataGridViewColumn
            {
                HeaderText = "ВРЕМЯ",
                Name = "time",
                DataPropertyName = nameof(RowGrid.Time),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 154
            };

            var column4 = new DataGridViewColumn
            {
                HeaderText = "БИРЖА",
                Name = "exchange",
                DataPropertyName = nameof(RowGrid.Exchange),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 79
            };

            var column5 = new DataGridViewColumn
            {
                HeaderText = "ФЛАГ",
                Name = "flag",
                DataPropertyName = nameof(RowGrid.Flag),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 60
            };

            dgvHistory.Columns.Clear();
            dgvHistory.Columns.Add(column1);
            dgvHistory.Columns.Add(column2);
            dgvHistory.Columns.Add(column3);
            dgvHistory.Columns.Add(column4);
            dgvHistory.Columns.Add(column5);
            dgvHistory.AllowUserToAddRows = false; //запрешаем самому добавлять строки
            dgvHistory.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            data = new BindingList<RowGridHistoryTrade>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvHistory.DataSource = data;
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            
        }

        public void SetStatus(string newStatus, Color color)
        {
            lbStatus.ForeColor = color;
            DoOnUI(() => lbStatus.Text = newStatus);
        }

        private void DoOnUI(Action act)
        {
            if (this.InvokeRequired)
                this.Invoke(act);
            else
                act();
        }

        public void AppendRow(RowGridHistoryTrade rowgrid)
        {
            if (this.InvokeRequired && data != null) // если требуется вызов из главного UI потока
            {
                try
                {
                    this.Invoke((Action)(() =>
                    {
                        data.Insert(0, rowgrid);
                        
                       dgvHistory.Rows[0].DefaultCellStyle.BackColor = Color.White;
                    }
                    )); // передаем функцию, которая будет вызвана в потоке формы
                }
                catch
                {
                }

            }
            else
            {
                data.Insert(0, rowgrid);
          
            }
        }

        private async void BtnGetHistory_Click(object sender, EventArgs e)
        {
            dgvHistory.Rows.Clear();
            var settings = new Settings();
            await settings.LoadSett();
            Sett = settings;
            Ticker = tbTicker.Text.Trim().ToUpper();
            if (Ticker != null && !Sett.AlpacaUses) SubscribeTrades();
            FiltrTradesLow = null;
            FiltrTradesHight = null;
        }

        private void SubscribeTrades()
        {
            if (tbVolMin.Text == "")
            {
                tbVolMin.Text = "1";
            }
            if (tbVolMax.Text == "")
            {
                tbVolMax.Text = "1000000";
            }

            history = new History(Sett, Ticker, this, dtFrom.Value, dtTo.Value, int.Parse(tbVolMin.Text), int.Parse(tbVolMax.Text));
            if (!cbLoadInDB.Checked)
                history.DoSomethingAfterConnect();
            else
                history.DoSomethingAfterConnectDB();

        }

        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
        }
    }
}
