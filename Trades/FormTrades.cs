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
using Tinkoff.Trading.OpenApi.Models;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;
using FishingSizes.DataBase;

namespace FishingSizes
{
    partial class FormTrades : Form, IRowGrid
    {
        BindingList<RowGridQuotes> dataQ; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        BindingList<RowGrid> data; //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
        Trades trades;
        RowGridQuotes RowgridQ { get; set; }
        public Settings Sett { get; set; }
        string Ticker { get; set; }
        DateTime lastPrintAdded = DateTime.MinValue; // время последнего добавления принта
        Queue<(RowGrid row, Color printColor, (int, int) ls)> printQueue = new Queue<(RowGrid row, Color printColor, (int, int) ls)>(); // очередь для временного хранения принтов перед выводом в грид
        int printBufferTime = 500; // время жизни буфера принтов (мс)
        int pps = 0; // принтов в секунду
        int ppsTemp = 0;
        DateTime ppsLastUpdate = DateTime.MinValue;

        System.Windows.Forms.Timer printBufferTimer = new System.Windows.Forms.Timer()
        { // этот таймер каждые 500мс добавляет все принты из очереди в грид, по умолчанию выключен
            Interval = 500,
            Enabled = false
        };
        System.Windows.Forms.Timer quotesBufferTimer = new System.Windows.Forms.Timer()
        { // этот таймер каждые 500мс выводит котировки в стакан, по умолчанию выключен
            Interval = 500,
            Enabled = false
        };
        string NewSprad;
        int pps10 = 0;
        int count = 0;

        public int? FiltrTradesLow { get; set; }
        public int? FiltrTradesHight { get; set; }
        ResetPrintsForm rstprints;
        private MethodsDB methodsCoordinates;

        public FormTrades()
        {
            InitializeComponent();
            printBufferTimer.Tick += PrintBufferTimer_Tick;
            quotesBufferTimer.Tick += QuotesBufferTimer_Tick;
            methodsCoordinates = new MethodsDB(this.Name, this.Size, Terminal.UserName);
        }

        private void QuotesBufferTimer_Tick(object sender, EventArgs e)
        {
            dataQ.Clear();
            dataQ.Insert(0, RowgridQ);
            lbSprad.Text = NewSprad;
            if (count <= 10)
            {
                count++;
                pps10 = pps10 + pps;
            }
            else
            {
                count = 1;
                lbSpeedPrints.Text = (pps10 / 10).ToString();
                pps10 = pps;
            }
        }

        private void PrintBufferTimer_Tick(object sender, EventArgs e)
        {
            AppendRowInternal();
            printBufferTimer.Stop();
        }

        private async void FormTrades_Load(object sender, EventArgs e)
        {
            methodsCoordinates.OpenСhildForm();
            this.Location = methodsCoordinates.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            this.Size = methodsCoordinates.SetSizeFormStart(null);//считываем размеры формы из БД и устанавливаем форму по ним

            cbTicker.Items.Clear();
            foreach (var item in Terminal.TickerList)
            {
                cbTicker.Items.Add(item);
            }

            //this.Location = new Point(1576, 620);
            //формирование стакана BBO
            var columnQ1 = new DataGridViewColumn
            {
                HeaderText = "ММ", //текст в шапке
                Name = "exchBid", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.ExchangeBid),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 33

            };
            var columnQ3 = new DataGridViewColumn
            {
                HeaderText = "БИД", //текст в шапке
                Name = "priceBid", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.PriceBid),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 64
            };
            var columnQ2 = new DataGridViewColumn
            {
                HeaderText = "КОЛ-ВО", //текст в шапке
                Name = "quantityBid", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.QuantityBid),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 62
            };
            var columnQ4 = new DataGridViewColumn
            {
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 12
            };
            var columnQ6 = new DataGridViewColumn
            {
                HeaderText = "КОЛ-ВО", //текст в шапке
                Name = "quantityAsk", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.QuantityAsk),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 62
            };
            var columnQ5 = new DataGridViewColumn
            {
                HeaderText = "АСК", //текст в шапке
                Name = "priceAsk", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.PriceAsk),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 64
            };
            var columnQ7 = new DataGridViewColumn
            {
                HeaderText = "ММ", //текст в шапке
                Name = "exchAsk", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGridQuotes.ExchangeAsk),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 33

            };

            columnQ1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQ2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQ3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQ5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columnQ6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columnQ7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columnQ4.DefaultCellStyle.BackColor = Color.Gray;
            columnQ1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQ2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQ3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQ5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columnQ6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columnQ7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columnQ7.HeaderCell.Style.BackColor = Color.Red;
            dgvQuotes.Columns.Clear();
            dgvQuotes.Columns.Add(columnQ1);
            dgvQuotes.Columns.Add(columnQ2);
            dgvQuotes.Columns.Add(columnQ3);
            dgvQuotes.Columns.Add(columnQ4);
            dgvQuotes.Columns.Add(columnQ5);
            dgvQuotes.Columns.Add(columnQ6);
            dgvQuotes.Columns.Add(columnQ7);
            dgvQuotes.AllowUserToAddRows = false; //запрещаем самому добавлять строки
            dgvQuotes.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvQuotes.RowHeadersVisible = false;
            dgvQuotes.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvQuotes.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dgvQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            dataQ = new BindingList<RowGridQuotes>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvQuotes.DataSource = dataQ;

            //формирование таблицы ленты принтов
            var column1 = new DataGridViewColumn
            {
                HeaderText = "ЦЕНА", //текст в шапке
                Name = "price", //текстовое имя колонки, его можно использовать вместо обращений по индексу
                DataPropertyName = nameof(RowGrid.Price),
                CellTemplate = new DataGridViewTextBoxCell(), //тип нашей колонки
                Width = 64
            };
            var column2 = new DataGridViewColumn
            {
                HeaderText = "КОЛ-ВО",
                Name = "quantity",
                DataPropertyName = nameof(RowGrid.Quantity),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 61
            };
            var column3 = new DataGridViewColumn
            {
                HeaderText = "ВРЕМЯ",
                Name = "time",
                DataPropertyName = nameof(RowGrid.Time),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 76
            };
            var column4 = new DataGridViewColumn
            {
                HeaderText = "БИРЖА",
                Name = "exchange",
                DataPropertyName = nameof(RowGrid.Exchange),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 72
            };
            var column5 = new DataGridViewColumn
            {
                HeaderText = "ФЛАГ",
                Name = "flag",
                DataPropertyName = nameof(RowGrid.Flag),
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 54
            };
            dgvTrades.Columns.Clear();
            dgvTrades.Columns.Add(column1);
            dgvTrades.Columns.Add(column2);
            dgvTrades.Columns.Add(column3);
            dgvTrades.Columns.Add(column4);
            dgvTrades.Columns.Add(column5);
            dgvTrades.AllowUserToAddRows = false; //запрешаем самому добавлять строки
            dgvTrades.AutoGenerateColumns = false; // выключить автоматическую генерацию колонок по источнику данных
            dgvTrades.RowHeadersVisible = false;
            dgvTrades.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            data = new BindingList<RowGrid>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview
            dgvTrades.DataSource = data;
            dgvTrades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            var settings = new Settings();
            await settings.LoadSett();
            Sett = settings;
            FiltrTradesLow = null;
            FiltrTradesHight = null;
            rstprints = new ResetPrintsForm(dgvTrades);//сброс ленты принтов на форме
        }

        private void AppendRowInternal()
        {
            Debug.WriteLine($"PPS {pps}. Сейчас добавим {printQueue.Count} принтов.");
            while (printQueue.Count > 0) // пока в очереди что-то есть, достаем и добавляем в грид
            {
                var (rowgrid, colorPrint, ls) = printQueue.Dequeue();

                if (!cbHightLow.Checked)
                {
                    data.Insert(0, rowgrid);
                    dgvTrades.Rows[0].DefaultCellStyle.ForeColor = colorPrint;
                    dgvTrades.Rows[0].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    if (colorPrint != Color.Black)
                    {
                        data.Insert(0, rowgrid);
                        dgvTrades.Rows[0].DefaultCellStyle.ForeColor = colorPrint;
                        dgvTrades.Rows[0].DefaultCellStyle.BackColor = Color.White;
                    }
                }
                if (printQueue.Count == 0) // выполняем только для последнего элемента в очереди
                {
                    lbL.Text = ls.Item1.ToString();
                    lbS.Text = ls.Item2.ToString();
                    rstprints.RstPrints();
                }
            }
        }

        private void IncrementPps()
        {
            ppsTemp++;

            if (ppsLastUpdate == DateTime.MinValue)
                ppsLastUpdate = DateTime.Now;

            if (DateTime.Now.Subtract(ppsLastUpdate).TotalMilliseconds > 1000)
            {
                pps = ppsTemp;
                ppsTemp = 0;
                ppsLastUpdate = DateTime.Now;
            }
        }

        public void AppendRow(RowGrid rowgrid, Color colorPrint, (int, int) ls)
        {
            // увеличиваем временный счетчик принтов в секунду (а так же обновляется переменная pps если прошло более 1000мс с момента последнего присваения)
            IncrementPps();

            printQueue.Enqueue((rowgrid, colorPrint, ls)); // главное чтобы этот вызов не выполнился параллельно из разных потоков, но принты ведь поступают сюда только из одного подключения, т.ч. должно быть норм

            if (pps > 8 && DateTime.Now.Subtract(lastPrintAdded).TotalMilliseconds < printBufferTime)
            {
                // если с момента добавления последнего принта прошло менее полсекунды, ничего не делаем (но если принты редкие, надо что-то сделать еще)
                // тут можно вызвать таймер, который добавит принт в случае, если следующий принт не поступил
                printBufferTimer.Enabled = true; // даже если вызовем несколько раз подряд, выполнится только 1 раз, что хорошо
                return;
            }

            lastPrintAdded = DateTime.Now;

            if (this.InvokeRequired && data != null) // если требуется вызов из главного UI потока
            {
                try
                {
                    this.Invoke(AppendRowInternal); // передаем функцию, которая будет вызвана в потоке формы
                }
                catch
                {
                }
            }
            else
            {
                AppendRowInternal();
            }
        }
        public void AppendRowQ(RowGridQuotes rowgridQ)
        {
            if (this.InvokeRequired && dataQ != null) // если требуется вызов из главного UI потока
            {
                try
                {
                    this.Invoke((Action)(() =>
                    {
                        if (quotesBufferTimer.Enabled == false)
                        {
                            quotesBufferTimer.Start();
                        }
                        RowgridQ = rowgridQ;
                    })); // передаем функцию, которая будет вызвана в потоке формы

                }
                catch
                {
                }
            }
            else
            {
                if (quotesBufferTimer.Enabled == false)
                {
                    quotesBufferTimer.Start();
                }
                RowgridQ = rowgridQ;
            }
        }
        private async void FormTrades_FormClosing(object sender, FormClosingEventArgs e)
        {
            methodsCoordinates.UpdateBD(Terminal.UserName, this.Left, this.Top, this.Size);
            if (trades != null)
            {
                await trades.UnsubscribeTrades(Ticker);
                await trades.UnsubscribeQuotes(Ticker);
            }

        }

        private async void tbFiltrTradesLow_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            if (!String.IsNullOrWhiteSpace(tbFiltrTradesLow.Text))
            {
                FiltrTradesLow = int.Parse(tbFiltrTradesLow.Text);
            }
            else FiltrTradesLow = null;
        }

        private async void tbFiltrTradesHight_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbFiltrTradesHight.Text))
            {
                await Task.Delay(1000);
                FiltrTradesHight = int.Parse(tbFiltrTradesHight.Text);
            }
            else FiltrTradesHight = null;
        }

        public void SetSprad(string newSprad)
        {
            NewSprad = newSprad;
            //DoOnUI(() => lbSprad.Text = newSprad);
        }

        private void DoOnUI(Action act)
        {
            if (this.InvokeRequired)
                this.Invoke(act);
            else
                act();
        }

        private async void cbTicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var new_ticker = cbTicker.Text.Trim().ToUpper();
                var old_ticker = Ticker;
                cbTicker_Subs_Trades_Quotes(new_ticker, old_ticker);
                if (cbOpenTi.Checked)
                {
                    var ticker = Ticker;
                    var group = 3;
                    await Terminal._websocketserver.SendAll(JsonConvert.SerializeObject(new { ticker, group }));
                }
            }
        }
        public void cbTicker_KeyDownEmulated(string ticker, List<MarketInstrument> marketInstruments)
        {
            var new_ticker = ticker;
            var old_ticker = Ticker;
            cbTicker.Text = ticker;
            cbTicker_Subs_Trades_Quotes(new_ticker, old_ticker);
        }
        public void cbTicker_Subs_Trades_Quotes(string new_ticker, string old_ticker)
        {
            if (trades != null)//если форма уже открыта с тикером, то отписываемся от старого тикера
            {
                trades.UnsubscribeTrades(old_ticker);
                trades.UnsubscribeQuotes(old_ticker);
                trades = null;
                quotesBufferTimer.Stop();
                quotesBufferTimer.Enabled = false;
            }
            if (cbTicker.Text != "")
            {
                Ticker = new_ticker;
                trades = new Trades(Sett, new_ticker, this);
                dgvTrades.Rows.Clear();
                dgvQuotes.Rows.Clear();
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

    }
}
