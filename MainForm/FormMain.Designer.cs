
namespace FishingSizes
{
    partial class Terminal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setTerminaleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tickerListOptoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fishingSizesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PortfolioMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tinkoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tradesBBOUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradesSPBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.orderTinkoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderIBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsArb = new System.Windows.Forms.ToolStripMenuItem();
            this.apbUSSPBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arbClosePriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsTinkoff = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsIB = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsAlpaca = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTerminaleMenu,
            this.fishingSizesMenu,
            this.PortfolioMenu,
            this.tradersMenu,
            this.HistoryMenu,
            this.tsOrders,
            this.tsArb});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(419, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setTerminaleMenu
            // 
            this.setTerminaleMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsConnectToolStripMenuItem,
            this.tickerListOptoinToolStripMenuItem});
            this.setTerminaleMenu.Name = "setTerminaleMenu";
            this.setTerminaleMenu.Size = new System.Drawing.Size(61, 20);
            this.setTerminaleMenu.Text = "Settings";
            this.setTerminaleMenu.Click += new System.EventHandler(this.setTerminaleMenu_Click);
            // 
            // settingsConnectToolStripMenuItem
            // 
            this.settingsConnectToolStripMenuItem.Name = "settingsConnectToolStripMenuItem";
            this.settingsConnectToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.settingsConnectToolStripMenuItem.Text = "Settings connect";
            this.settingsConnectToolStripMenuItem.Click += new System.EventHandler(this.SetMenu_Click);
            // 
            // tickerListOptoinToolStripMenuItem
            // 
            this.tickerListOptoinToolStripMenuItem.Name = "tickerListOptoinToolStripMenuItem";
            this.tickerListOptoinToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.tickerListOptoinToolStripMenuItem.Text = "Ticker list optoin";
            this.tickerListOptoinToolStripMenuItem.Click += new System.EventHandler(this.TickerListOptoinToolStripMenuItem_Click);
            // 
            // fishingSizesMenu
            // 
            this.fishingSizesMenu.Name = "fishingSizesMenu";
            this.fishingSizesMenu.Size = new System.Drawing.Size(82, 20);
            this.fishingSizesMenu.Text = "FishingSizes";
            this.fishingSizesMenu.Click += new System.EventHandler(this.FishingSizesMenu_Click);
            // 
            // PortfolioMenu
            // 
            this.PortfolioMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tinkoffToolStripMenuItem,
            this.ordersActiveToolStripMenuItem});
            this.PortfolioMenu.Name = "PortfolioMenu";
            this.PortfolioMenu.Size = new System.Drawing.Size(65, 20);
            this.PortfolioMenu.Text = "Portfolio";
            // 
            // tinkoffToolStripMenuItem
            // 
            this.tinkoffToolStripMenuItem.Name = "tinkoffToolStripMenuItem";
            this.tinkoffToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.tinkoffToolStripMenuItem.Tag = "P1";
            this.tinkoffToolStripMenuItem.Text = "Tinkoff";
            this.tinkoffToolStripMenuItem.Click += new System.EventHandler(this.tinkoffToolStripMenuItem_Click);
            // 
            // ordersActiveToolStripMenuItem
            // 
            this.ordersActiveToolStripMenuItem.Name = "ordersActiveToolStripMenuItem";
            this.ordersActiveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.ordersActiveToolStripMenuItem.Text = "Orders active";
            this.ordersActiveToolStripMenuItem.Click += new System.EventHandler(this.ordersActiveToolStripMenuItem_Click);
            // 
            // tradersMenu
            // 
            this.tradersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradesBBOUSToolStripMenuItem,
            this.tradesSPBToolStripMenuItem});
            this.tradersMenu.Name = "tradersMenu";
            this.tradersMenu.Size = new System.Drawing.Size(52, 20);
            this.tradersMenu.Text = "Trades";
            // 
            // tradesBBOUSToolStripMenuItem
            // 
            this.tradesBBOUSToolStripMenuItem.Name = "tradesBBOUSToolStripMenuItem";
            this.tradesBBOUSToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tradesBBOUSToolStripMenuItem.Text = "Trades & BBO US";
            this.tradesBBOUSToolStripMenuItem.Click += new System.EventHandler(this.TradersMenu_Click);
            // 
            // tradesSPBToolStripMenuItem
            // 
            this.tradesSPBToolStripMenuItem.Name = "tradesSPBToolStripMenuItem";
            this.tradesSPBToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tradesSPBToolStripMenuItem.Text = "Trades SPB";
            this.tradesSPBToolStripMenuItem.Click += new System.EventHandler(this.TradesSPBToolStripMenuItem_Click);
            // 
            // HistoryMenu
            // 
            this.HistoryMenu.Name = "HistoryMenu";
            this.HistoryMenu.Size = new System.Drawing.Size(57, 20);
            this.HistoryMenu.Text = "History";
            this.HistoryMenu.Click += new System.EventHandler(this.HistoryMenu_Click);
            // 
            // tsOrders
            // 
            this.tsOrders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderTinkoffToolStripMenuItem,
            this.orderIBToolStripMenuItem});
            this.tsOrders.Name = "tsOrders";
            this.tsOrders.Size = new System.Drawing.Size(54, 20);
            this.tsOrders.Text = "Orders";
            // 
            // orderTinkoffToolStripMenuItem
            // 
            this.orderTinkoffToolStripMenuItem.Name = "orderTinkoffToolStripMenuItem";
            this.orderTinkoffToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.orderTinkoffToolStripMenuItem.Text = "Order Tinkoff";
            this.orderTinkoffToolStripMenuItem.Click += new System.EventHandler(this.OrderTinkoffToolStripMenuItem_Click);
            // 
            // orderIBToolStripMenuItem
            // 
            this.orderIBToolStripMenuItem.Name = "orderIBToolStripMenuItem";
            this.orderIBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.orderIBToolStripMenuItem.Text = "Order IB";
            this.orderIBToolStripMenuItem.Click += new System.EventHandler(this.OrderIBToolStripMenuItem_Click);
            // 
            // tsArb
            // 
            this.tsArb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apbUSSPBToolStripMenuItem,
            this.arbClosePriceToolStripMenuItem});
            this.tsArb.Name = "tsArb";
            this.tsArb.Size = new System.Drawing.Size(38, 20);
            this.tsArb.Text = "Arb";
            // 
            // apbUSSPBToolStripMenuItem
            // 
            this.apbUSSPBToolStripMenuItem.Name = "apbUSSPBToolStripMenuItem";
            this.apbUSSPBToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.apbUSSPBToolStripMenuItem.Text = "Arb US-SPB";
            this.apbUSSPBToolStripMenuItem.Click += new System.EventHandler(this.ApbUSSPBToolStripMenuItem_Click);
            // 
            // arbClosePriceToolStripMenuItem
            // 
            this.arbClosePriceToolStripMenuItem.Name = "arbClosePriceToolStripMenuItem";
            this.arbClosePriceToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.arbClosePriceToolStripMenuItem.Text = "Arb Close price";
            this.arbClosePriceToolStripMenuItem.Click += new System.EventHandler(this.ArbClosePriceToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTinkoff,
            this.tsIB,
            this.tsAlpaca,
            this.tStatusMain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 24);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStrip1.Size = new System.Drawing.Size(419, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsTinkoff
            // 
            this.tsTinkoff.Image = ((System.Drawing.Image)(resources.GetObject("tsTinkoff.Image")));
            this.tsTinkoff.Name = "tsTinkoff";
            this.tsTinkoff.Size = new System.Drawing.Size(64, 20);
            this.tsTinkoff.Text = "Tinkoff";
            // 
            // tsIB
            // 
            this.tsIB.Image = ((System.Drawing.Image)(resources.GetObject("tsIB.Image")));
            this.tsIB.Name = "tsIB";
            this.tsIB.Size = new System.Drawing.Size(37, 20);
            this.tsIB.Text = "IB";
            // 
            // tsAlpaca
            // 
            this.tsAlpaca.Image = ((System.Drawing.Image)(resources.GetObject("tsAlpaca.Image")));
            this.tsAlpaca.Name = "tsAlpaca";
            this.tsAlpaca.Size = new System.Drawing.Size(63, 20);
            this.tsAlpaca.Text = "Alpaca";
            // 
            // tStatusMain
            // 
            this.tStatusMain.Name = "tStatusMain";
            this.tStatusMain.Size = new System.Drawing.Size(0, 20);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(419, 49);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Terminal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Terminal_FormClosing);
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setTerminaleMenu;
        private System.Windows.Forms.ToolStripMenuItem fishingSizesMenu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem tradersMenu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tStatusMain;
        private System.Windows.Forms.ToolStripMenuItem HistoryMenu;
        private System.Windows.Forms.ToolStripMenuItem tsOrders;
        private System.Windows.Forms.ToolStripMenuItem tsArb;
        private System.Windows.Forms.ToolStripMenuItem orderTinkoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderIBToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel tsTinkoff;
        private System.Windows.Forms.ToolStripStatusLabel tsIB;
        public System.Windows.Forms.ToolStripStatusLabel tsAlpaca;
        private System.Windows.Forms.ToolStripMenuItem apbUSSPBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arbClosePriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tickerListOptoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradesBBOUSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradesSPBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PortfolioMenu;
        private System.Windows.Forms.ToolStripMenuItem tinkoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersActiveToolStripMenuItem;
    }
}