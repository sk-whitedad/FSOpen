using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBApi;
using System.Diagnostics;
using Newtonsoft.Json;
using FishingSizes.DataBase;

namespace FishingSizes
{
    public partial class ArbClosePriceForm : Form, IRowGridArbClosePrice
    {
        BindingList<RowGridArbClosePrice> dataArb; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        public Settings Sett { get; set; }
        public SettingsClosePrints SettClPrs { get; set; }    
        ArbClosePriseMetods Arb;
        public SettingsBlackList settingsBlackList { get; set; }
        private MethodsDB methodsCoordinates;

        public ArbClosePriceForm()
        {
            InitializeComponent();
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private async void ArbClosePriceForm_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            //формирование шапки таблицы
            var columnQ = new DataGridViewColumn
            {
                HeaderText = "ДЕЛЬТА", //текст в шапке
                Name = "delta", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.Delta),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 60
            };
            var columnQ1 = new DataGridViewColumn
            {
                HeaderText = "А-СПБ", //текст в шапке
                Name = "askSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.Ask_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ2 = new DataGridViewColumn
            {
                HeaderText = "Кол.", //текст в шапке
                Name = "volaskSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.VolAsk_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 42
            };
            var columnQ3 = new DataGridViewColumn
            {
                HeaderText = "Б-США", //текст в шапке
                Name = "bidUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.Bid_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ4 = new DataGridViewColumn
            {
                HeaderText = "Кол.", //текст в шапке
                Name = "volbidUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.VolBid_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 42
            };
            var columnQ9 = new DataGridViewColumn
            {
                HeaderText = "CLOSE", //текст в шапке
                Name = "ClosePrice", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.ClosePrice),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ5 = new DataGridViewColumn
            {
                HeaderText = "А-США", //текст в шапке
                Name = "askUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.Ask_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ6 = new DataGridViewColumn
            {
                HeaderText = "Кол.", //текст в шапке
                Name = "volaskUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.VolAsk_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 42
            };
            var columnQ7 = new DataGridViewColumn
            {
                HeaderText = "Б-СПБ", //текст в шапке
                Name = "bidSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.Bid_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ8 = new DataGridViewColumn
            {
                HeaderText = "Кол.", //текст в шапке
                Name = "volbidSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.VolBid_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 42
            };
            var columnQ11 = new DataGridViewColumn
            {
                HeaderText = "Тикер", //текст в шапке
                Name = "ticker", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArbClosePrice.Ticker),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 56
            };

            dgvArb.Columns.Clear();
            dgvArb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvArb.Columns.Add(columnQ11);
            dgvArb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvArb.Columns.Add(columnQ9);
            dgvArb.Columns.Add(columnQ1);
            dgvArb.Columns.Add(columnQ2);
            dgvArb.Columns.Add(columnQ5);
            dgvArb.Columns.Add(columnQ6);
            dgvArb.Columns.Add(columnQ);
            dgvArb.Columns.Add(columnQ4);
            dgvArb.Columns.Add(columnQ3);
            dgvArb.Columns.Add(columnQ8);
            dgvArb.Columns.Add(columnQ7);
            dgvArb.AllowUserToAddRows = false; //запрещаем самому добавлять строки
            dgvArb.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvArb.RowHeadersVisible = false;
            dgvArb.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvArb.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dgvArb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvArb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            dataArb = new BindingList<RowGridArbClosePrice>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvArb.DataSource = dataArb;
            var settings = new Settings();
            await settings.LoadSett();
            Sett = settings;
            var settclprs = new SettingsClosePrints();
            try
            {
                await settclprs.LoadSett();
            }
            catch 
            {
                Debug.WriteLine($"Ошибка чтения из файла принтов закрытия");
            }
            SettClPrs = settclprs;//принты закрытия
            if (Terminal.IB_ApiClient_OnReady)
            {
                Terminal.ApiWrapper.OnReady += ApiClient_OnReady_Close;
                Terminal.ApiWrapper.OnPrintReceived += ApiClient_OnPrintReceived_Close;
                Terminal.ApiWrapper.NoReady += ApiClient_NoReady_Close;
            }

            settingsBlackList = new SettingsBlackList("black_list_close.json");
            await settingsBlackList.LoadSett();
            foreach (var item in settingsBlackList.BlackList)
            {
                cbBlackList.Items.Add(item);
            }


        }

        public void ApiClient_OnPrintReceived_Close(object sender, (int, HistoricalTickBidAsk[], bool) e)
        {
            Debug.WriteLine($" == ApiClient_OnPrintReceived == : {sender} : {e}");
        }
        public void ApiClient_OnReady_Close(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_OnReady == : {sender} : {e}");
                SetStatusIcon("Connect.png");
                Terminal.IB_ApiClient_OnReady = true;

            }
        }
        private void ApiClient_NoReady_Close(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_NoReady == : {sender} : {e}");
                SetStatusIcon("NoConnect.png");
                Terminal.IB_ApiClient_OnReady = false;
            }
        }
        public void SetStatusIcon(string s)
        {
            //tsIB.Image = Image.FromFile(s);
        }
        //кнопка старта поиска арбы
        private async void btSearchArb_Click(object sender, EventArgs e)
        {
            dataArb.Clear();
            Arb = new ArbClosePriseMetods(Sett, SettClPrs, this, settingsBlackList.BlackList);
            Arb.ProcentDelta = numProcentDelta.Value;
            await Arb.MarketList();
            Arb.SubscribeQuotes();
            btSearchArb.Enabled = false;

        }
        private async void dgvArb_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var ticker = dgvArb.SelectedCells[0].Value.ToString();
            var group = 3;
            await Terminal._websocketserver.SendAll(JsonConvert.SerializeObject(new { ticker, group }));
        }
        public void AppendRowArb(PacketRGA_CL packet, int count)
        {
            if (this.InvokeRequired && dataArb != null) // если требуется вызов из главного UI потока
            {
                try
                {
                    this.Invoke((Action)(() => { dataArb.Insert(0, packet.rowgrid); })); // передаем функцию, которая будет вызвана в потоке формы
                }
                catch
                {
                }
            }
            else
            {
                dataArb.Insert(0, packet.rowgrid);
            }
            dgvArb.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvArb.Rows[0].DefaultCellStyle.BackColor = packet.color;
            dgvArb.DefaultCellStyle.SelectionForeColor = packet.color;
            if (packet.color == Color.LightCoral)
            {
                dgvArb.Rows[0].Cells[4].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[5].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[7].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[8].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[9].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[10].Style.BackColor = Color.White;
                if (packet.rowgrid.Ask_US >= packet.rowgrid.ClosePrice)
                {
                    dgvArb.Rows[0].Cells[4].Style.BackColor = Color.LightGreen;
                }
            }
            dgvArb.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
            dgvArb.Rows[0].Cells[6].Style.BackColor = Color.LightSkyBlue;
            dgvArb.Rows[0].Cells[1].Style.BackColor = Color.LightYellow;
        }
        public void ClearGrid()
        {
            dataArb.Clear();
        }
        private void ArbClosePriceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);

            if (Arb != null)
            {
                Arb.cancelTokenSource.Cancel();
                Arb.cancelTokenSource.Dispose();
                //await Arb.UnsubcribeAndClose();
                Arb = null;
            }
        }
        private void btTest_Click(object sender, EventArgs e)
        {
        }
        private void numProcentDelta_ValueChanged(object sender, EventArgs e)
        {
            Arb.ProcentDelta = numProcentDelta.Value;
        }

        private void cbBlackList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool i = false;
                foreach (var item in cbBlackList.Items)
                {
                    if (item.ToString() == cbBlackList.Text)//проверяем наличие тикера в списке cbTicker.Items
                    {
                        i = true;
                        break;
                    }
                }
                if (!i)
                {
                    var Ticker = cbBlackList.Text.Trim().ToUpper();
                    cbBlackList.Items.Insert(0, Ticker);//добавляем тикер в список cbTicker.Items
                    settingsBlackList.BlackList.Add(Ticker);
                    settingsBlackList.SaveSett(settingsBlackList.BlackList);
                    cbBlackList.Text = String.Empty;
                    if (Arb != null)
                    {
                        Arb.BlackList.Add(Ticker);
                    }

                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (settingsBlackList.BlackList.IndexOf(cbBlackList.Text) > -1)
                {
                    var Ticker = cbBlackList.Text;
                    cbBlackList.Items.Remove(Ticker);
                    settingsBlackList.BlackList.Remove(Ticker);
                    settingsBlackList.SaveSett(settingsBlackList.BlackList);
                    if (Arb != null)
                    {
                        Arb.BlackList.Remove(Ticker);
                    }
                }
            }
        }
  
    }
}
