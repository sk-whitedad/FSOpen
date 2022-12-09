using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tinkoff.Trading.OpenApi.Network;
using Tinkoff.Trading.OpenApi.Models;
using System.Diagnostics;
using IBApi;
using System.Threading;
using Newtonsoft.Json;
using FishingSizes.DataBase;

namespace FishingSizes
{
    public partial class ArbForm : Form, IRowGridArb
    {
        BindingList<RowGridArb> dataArb; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        public Settings Sett { get; set; }
        ArbMetods Arb;
        public SettingsBlackList settingsBlackList { get; set; }
        private MethodsDB methodsCoordinates;

        //WebSocketServer _websocketserver;
        FormTrades newFormTrades;

        public ArbForm()
        {
            InitializeComponent();
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private async void ArbForm_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            //формирование шапки таблицы
            var columnQ = new DataGridViewColumn
            {
                HeaderText = "ДЕЛЬТА", //текст в шапке
                Name = "delta", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Delta),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 60
            };
            var columnQ1 = new DataGridViewColumn
            {
                HeaderText = "АскСПБ", //текст в шапке
                Name = "askSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Ask_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ2 = new DataGridViewColumn
            {
                HeaderText = "Кол-во", //текст в шапке
                Name = "volaskSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.VolAsk_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 50
            };
            var columnQ3 = new DataGridViewColumn
            {
                HeaderText = "Бид США", //текст в шапке
                Name = "bidUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Bid_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ4 = new DataGridViewColumn
            {
                HeaderText = "Кол-во", //текст в шапке
                Name = "volbidUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.VolBid_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 50
            };
            var columnQ9 = new DataGridViewColumn
            {
                HeaderText = "ММ Бид", //текст в шапке
                Name = "exc_bid", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Exc_Bid),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 40
            };
            var columnQ5 = new DataGridViewColumn
            {
                HeaderText = "Аск США", //текст в шапке
                Name = "askUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Ask_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ6 = new DataGridViewColumn
            {
                HeaderText = "Кол-во", //текст в шапке
                Name = "volaskUS", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.VolAsk_US),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 50
            };
            var columnQ10 = new DataGridViewColumn
            {
                HeaderText = "ММ Аск", //текст в шапке
                Name = "exc_ask", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Exc_Ask),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 40
            };
            var columnQ7 = new DataGridViewColumn
            {
                HeaderText = "Бид СПБ", //текст в шапке
                Name = "bidSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Bid_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 57
            };
            var columnQ8 = new DataGridViewColumn
            {
                HeaderText = "Кол-во", //текст в шапке
                Name = "volbidSPB", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.VolBid_SPB),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 50
            };
            var columnQ11 = new DataGridViewColumn
            {
                HeaderText = "Тикер", //текст в шапке
                Name = "ticker", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridArb.Ticker),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 80
            };

            dgvArb.Columns.Clear();
            dgvArb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvArb.Columns.Add(columnQ11);
            //dgvArb.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvArb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvArb.Columns.Add(columnQ2);
            dgvArb.Columns.Add(columnQ1);
            dgvArb.Columns.Add(columnQ3);
            dgvArb.Columns.Add(columnQ4);
            dgvArb.Columns.Add(columnQ9);
            dgvArb.Columns.Add(columnQ);
            dgvArb.Columns.Add(columnQ10);
            dgvArb.Columns.Add(columnQ6);
            dgvArb.Columns.Add(columnQ5);
            dgvArb.Columns.Add(columnQ7);
            dgvArb.Columns.Add(columnQ8);
            dgvArb.AllowUserToAddRows = false; //запрещаем самому добавлять строки
            dgvArb.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvArb.RowHeadersVisible = false;
            dgvArb.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvArb.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dgvArb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            
            dgvArb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            
            dataArb = new BindingList<RowGridArb>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvArb.DataSource = dataArb;
            var settings = new Settings();
            await settings.LoadSett();
            Sett = settings;

            if (Terminal.IB_ApiClient_OnReady)
            {
                Terminal.ApiWrapper.OnReady += ApiClient_OnReady_Arb;
                Terminal.ApiWrapper.OnPrintReceived += ApiClient_OnPrintReceived_Arb;
                Terminal.ApiWrapper.NoReady += ApiClient_NoReady_Arb;
            }

            settingsBlackList = new SettingsBlackList("black_list.json");
            await settingsBlackList.LoadSett();
            foreach (var item in settingsBlackList.BlackList)
            {
                cbBlackList.Items.Add(item);
            }
        }

        public void ApiClient_OnPrintReceived_Arb(object sender, (int, HistoricalTickBidAsk[], bool) e)
        {
            Debug.WriteLine($" == ApiClient_OnPrintReceived == : {sender} : {e}");
        }
        public void ApiClient_OnReady_Arb(object sender, EventArgs e)
        {
            Debug.WriteLine($" == Сообщение == : {sender} : {e}");
            if (sender is TWSApiWrapper api)
            {
                Debug.WriteLine($" == ApiClient_OnReady == : {sender} : {e}");
                SetStatusIcon("Connect.png");
                Terminal.IB_ApiClient_OnReady = true;

            }
        }
        private void ApiClient_NoReady_Arb(object sender, EventArgs e)
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

        private async void btSearchArb_Click(object sender, EventArgs e)
        {
            dataArb.Clear();
            Arb = new ArbMetods(Sett, this, settingsBlackList.BlackList);
            await Arb.MarketList();
            Arb.SubscribeQuotes();
            btSearchArb.Enabled = false;
        }
        public void AppendRowArb(Packet packet, int count)
        {

            if (this.InvokeRequired && dataArb != null) // если требуется вызов из главного UI потока
            {
                try
                {
                    this.Invoke((Action)(() => {dataArb.Insert(0, packet.rowgrid);})); // передаем функцию, которая будет вызвана в потоке формы
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
                dgvArb.Rows[0].Cells[7].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[8].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[9].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[10].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[11].Style.BackColor = Color.White;
            }
            if (packet.color == Color.LightGreen)
            {
                dgvArb.Rows[0].Cells[1].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[2].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[3].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[4].Style.BackColor = Color.White;
                dgvArb.Rows[0].Cells[5].Style.BackColor = Color.White;
            }
            dgvArb.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
            dgvArb.Rows[0].Cells[6].Style.BackColor = Color.LightSkyBlue;
        }
        public void ClearGrid()
        {
            dataArb.Clear();
        }
        private async void btTest_Click(object sender, EventArgs e)
        {
            foreach (var item in Arb.packetsShort)
            {
                Arb.OrderbookTi[item.rowgrid.Ticker] = await Arb.QuoteOrderbookTi(Arb.FigiGet(item.rowgrid.Ticker));
                Alpaca.Markets.LatestMarketDataRequest DataClientMarcetData = new(item.rowgrid.Ticker);
                Arb.QuotesAlpaca[item.rowgrid.Ticker] = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);

            }
            foreach (var item in Arb.packetsLong)
            {
                Arb.OrderbookTi[item.rowgrid.Ticker] = await Arb.QuoteOrderbookTi(Arb.FigiGet(item.rowgrid.Ticker));
                Alpaca.Markets.LatestMarketDataRequest DataClientMarcetData = new(item.rowgrid.Ticker);
                Arb.QuotesAlpaca[item.rowgrid.Ticker] = await Terminal.DataClient.GetLatestQuoteAsync(DataClientMarcetData);
            }
        }

        private async void dgvArb_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (newFormTrades == null)
            {
                newFormTrades = new FormTrades();
                newFormTrades.Show();
                newFormTrades.FormClosed += newFormTrades_Closing;
            }
            ArbCheckForm arbcheckform = new ArbCheckForm(dgvArb.SelectedCells[0].Value.ToString(), Arb.marketInstruments, cbModeOrders.Checked);
            arbcheckform.Show();
            var ticker = dgvArb.SelectedCells[0].Value.ToString();
            var group = 3;
            await Terminal._websocketserver.SendAll(JsonConvert.SerializeObject(new { ticker, group }));

            await Task.Delay(1000);
            newFormTrades.cbTicker_KeyDownEmulated(dgvArb.SelectedCells[0].Value.ToString(), Arb.marketInstruments);
        }
        private async void ArbForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
            if (Arb != null)
            {
                Arb.cancelTokenSource.Cancel();
                Arb.cancelTokenSource.Dispose();
                await Arb.UnsubcribeAndClose();
                Arb = null;
            }

        }
        private void newFormTrades_Closing(object sender, EventArgs e)
        {
            newFormTrades = null;
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





