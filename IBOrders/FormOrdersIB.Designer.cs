namespace FishingSizes
{
    partial class FormOrdersIB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrdersIB));
            this.lbAsk = new System.Windows.Forms.Label();
            this.btCancelLastOrders = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lbBid = new System.Windows.Forms.Label();
            this.cbTicker = new System.Windows.Forms.ComboBox();
            this.tabOrders = new System.Windows.Forms.TabControl();
            this.tabLimitOrder = new System.Windows.Forms.TabPage();
            this.cbExchange = new System.Windows.Forms.ComboBox();
            this.tbPriceLimit = new System.Windows.Forms.TextBox();
            this.numLotsLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btBuyLimit = new System.Windows.Forms.Button();
            this.btSellLimit = new System.Windows.Forms.Button();
            this.tabMarketOrder = new System.Windows.Forms.TabPage();
            this.tbPriceMarket = new System.Windows.Forms.TextBox();
            this.numLotsMarket = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btBuyMarket = new System.Windows.Forms.Button();
            this.btSellMarket = new System.Windows.Forms.Button();
            this.btCancelAllOrders = new System.Windows.Forms.Button();
            this.cbOpenTi = new System.Windows.Forms.CheckBox();
            this.tabOrders.SuspendLayout();
            this.tabLimitOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotsLimit)).BeginInit();
            this.tabMarketOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotsMarket)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAsk
            // 
            this.lbAsk.AutoSize = true;
            this.lbAsk.Location = new System.Drawing.Point(180, 27);
            this.lbAsk.Name = "lbAsk";
            this.lbAsk.Size = new System.Drawing.Size(40, 13);
            this.lbAsk.TabIndex = 10;
            this.lbAsk.Text = "000.00";
            this.lbAsk.Click += new System.EventHandler(this.lbAsk_Click);
            // 
            // btCancelLastOrders
            // 
            this.btCancelLastOrders.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelLastOrders.Enabled = false;
            this.btCancelLastOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancelLastOrders.Location = new System.Drawing.Point(229, 3);
            this.btCancelLastOrders.Name = "btCancelLastOrders";
            this.btCancelLastOrders.Size = new System.Drawing.Size(63, 21);
            this.btCancelLastOrders.TabIndex = 13;
            this.btCancelLastOrders.Text = "Cancel Last";
            this.btCancelLastOrders.UseVisualStyleBackColor = false;
            this.btCancelLastOrders.Click += new System.EventHandler(this.btCancelLastOrders_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(164, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "B : A";
            // 
            // lbBid
            // 
            this.lbBid.AutoSize = true;
            this.lbBid.Location = new System.Drawing.Point(137, 27);
            this.lbBid.Name = "lbBid";
            this.lbBid.Size = new System.Drawing.Size(40, 13);
            this.lbBid.TabIndex = 12;
            this.lbBid.Text = "000.00";
            this.lbBid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbBid.Click += new System.EventHandler(this.lbBid_Click);
            // 
            // cbTicker
            // 
            this.cbTicker.FormattingEnabled = true;
            this.cbTicker.Items.AddRange(new object[] {
            "AIV",
            "ANGI",
            "APLE",
            "BEN",
            "BKR",
            "CCXI",
            "CRSR",
            "CTRA",
            "DELL",
            "DK",
            "DNOW",
            "EQT",
            "ETRN",
            "EXEL",
            "FNKO",
            "FOLD",
            "FTCI",
            "HA",
            "HBAN",
            "HBI",
            "HFC",
            "HWM",
            "IONS",
            "IOVA",
            "KIM",
            "LTHM",
            "LUMN",
            "MDRX",
            "MGY",
            "MQ",
            "MRC",
            "MTG",
            "MUR",
            "NKTR",
            "NLSN",
            "NOV",
            "NTNX",
            "NWS",
            "OI",
            "OII",
            "PAGS",
            "PBF",
            "PBI",
            "PEAK",
            "PRAX",
            "RF",
            "RRC",
            "SFM",
            "TGNA",
            "TWNK",
            "UNM",
            "WRK",
            "WU",
            "YEXT",
            "ZUO"});
            this.cbTicker.Location = new System.Drawing.Point(7, 15);
            this.cbTicker.Name = "cbTicker";
            this.cbTicker.Size = new System.Drawing.Size(101, 21);
            this.cbTicker.TabIndex = 9;
            this.cbTicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTicker_KeyDown);
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.tabLimitOrder);
            this.tabOrders.Controls.Add(this.tabMarketOrder);
            this.tabOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabOrders.Location = new System.Drawing.Point(3, 42);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.SelectedIndex = 0;
            this.tabOrders.Size = new System.Drawing.Size(357, 145);
            this.tabOrders.TabIndex = 8;
            // 
            // tabLimitOrder
            // 
            this.tabLimitOrder.BackColor = System.Drawing.Color.Transparent;
            this.tabLimitOrder.Controls.Add(this.cbExchange);
            this.tabLimitOrder.Controls.Add(this.tbPriceLimit);
            this.tabLimitOrder.Controls.Add(this.numLotsLimit);
            this.tabLimitOrder.Controls.Add(this.label2);
            this.tabLimitOrder.Controls.Add(this.label1);
            this.tabLimitOrder.Controls.Add(this.btBuyLimit);
            this.tabLimitOrder.Controls.Add(this.btSellLimit);
            this.tabLimitOrder.Location = new System.Drawing.Point(4, 22);
            this.tabLimitOrder.Name = "tabLimitOrder";
            this.tabLimitOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabLimitOrder.Size = new System.Drawing.Size(349, 119);
            this.tabLimitOrder.TabIndex = 0;
            this.tabLimitOrder.Text = "LimitOrder";
            // 
            // cbExchange
            // 
            this.cbExchange.Enabled = false;
            this.cbExchange.FormattingEnabled = true;
            this.cbExchange.Items.AddRange(new object[] {
            "ISLAND",
            "SMART",
            "ARCA"});
            this.cbExchange.Location = new System.Drawing.Point(87, 12);
            this.cbExchange.Name = "cbExchange";
            this.cbExchange.Size = new System.Drawing.Size(175, 21);
            this.cbExchange.TabIndex = 10;
            this.cbExchange.Text = "ISLAND";
            // 
            // tbPriceLimit
            // 
            this.tbPriceLimit.Enabled = false;
            this.tbPriceLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPriceLimit.Location = new System.Drawing.Point(87, 39);
            this.tbPriceLimit.MaxLength = 10;
            this.tbPriceLimit.Name = "tbPriceLimit";
            this.tbPriceLimit.Size = new System.Drawing.Size(81, 26);
            this.tbPriceLimit.TabIndex = 8;
            this.tbPriceLimit.Text = "0,00";
            this.tbPriceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numLotsLimit
            // 
            this.numLotsLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numLotsLimit.Enabled = false;
            this.numLotsLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numLotsLimit.Location = new System.Drawing.Point(181, 39);
            this.numLotsLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLotsLimit.Name = "numLotsLimit";
            this.numLotsLimit.Size = new System.Drawing.Size(81, 26);
            this.numLotsLimit.TabIndex = 6;
            this.numLotsLimit.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "КОЛ-ВО";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ЦЕНА";
            // 
            // btBuyLimit
            // 
            this.btBuyLimit.BackColor = System.Drawing.Color.PaleGreen;
            this.btBuyLimit.Enabled = false;
            this.btBuyLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btBuyLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btBuyLimit.Location = new System.Drawing.Point(23, 80);
            this.btBuyLimit.Name = "btBuyLimit";
            this.btBuyLimit.Size = new System.Drawing.Size(146, 30);
            this.btBuyLimit.TabIndex = 1;
            this.btBuyLimit.Text = "BUY";
            this.btBuyLimit.UseVisualStyleBackColor = false;
            this.btBuyLimit.Click += new System.EventHandler(this.btBuyLimit_Click);
            // 
            // btSellLimit
            // 
            this.btSellLimit.BackColor = System.Drawing.Color.Salmon;
            this.btSellLimit.Enabled = false;
            this.btSellLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSellLimit.Location = new System.Drawing.Point(180, 80);
            this.btSellLimit.Name = "btSellLimit";
            this.btSellLimit.Size = new System.Drawing.Size(151, 30);
            this.btSellLimit.TabIndex = 0;
            this.btSellLimit.Text = "SELL";
            this.btSellLimit.UseVisualStyleBackColor = false;
            this.btSellLimit.Click += new System.EventHandler(this.btSellLimit_Click);
            // 
            // tabMarketOrder
            // 
            this.tabMarketOrder.Controls.Add(this.tbPriceMarket);
            this.tabMarketOrder.Controls.Add(this.numLotsMarket);
            this.tabMarketOrder.Controls.Add(this.label12);
            this.tabMarketOrder.Controls.Add(this.label14);
            this.tabMarketOrder.Controls.Add(this.label16);
            this.tabMarketOrder.Controls.Add(this.label17);
            this.tabMarketOrder.Controls.Add(this.btBuyMarket);
            this.tabMarketOrder.Controls.Add(this.btSellMarket);
            this.tabMarketOrder.Location = new System.Drawing.Point(4, 22);
            this.tabMarketOrder.Name = "tabMarketOrder";
            this.tabMarketOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabMarketOrder.Size = new System.Drawing.Size(349, 119);
            this.tabMarketOrder.TabIndex = 1;
            this.tabMarketOrder.Text = "MarketOrder";
            this.tabMarketOrder.UseVisualStyleBackColor = true;
            // 
            // tbPriceMarket
            // 
            this.tbPriceMarket.Enabled = false;
            this.tbPriceMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPriceMarket.Location = new System.Drawing.Point(87, 12);
            this.tbPriceMarket.MaxLength = 10;
            this.tbPriceMarket.Name = "tbPriceMarket";
            this.tbPriceMarket.Size = new System.Drawing.Size(81, 26);
            this.tbPriceMarket.TabIndex = 16;
            this.tbPriceMarket.Text = "0,00";
            this.tbPriceMarket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numLotsMarket
            // 
            this.numLotsMarket.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numLotsMarket.Enabled = false;
            this.numLotsMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numLotsMarket.Location = new System.Drawing.Point(181, 12);
            this.numLotsMarket.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLotsMarket.Name = "numLotsMarket";
            this.numLotsMarket.Size = new System.Drawing.Size(81, 26);
            this.numLotsMarket.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "КОЛ-ВО";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Сумма:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Доступно:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(46, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "ЦЕНА";
            // 
            // btBuyMarket
            // 
            this.btBuyMarket.BackColor = System.Drawing.Color.PaleGreen;
            this.btBuyMarket.Enabled = false;
            this.btBuyMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btBuyMarket.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btBuyMarket.Location = new System.Drawing.Point(23, 41);
            this.btBuyMarket.Name = "btBuyMarket";
            this.btBuyMarket.Size = new System.Drawing.Size(146, 30);
            this.btBuyMarket.TabIndex = 5;
            this.btBuyMarket.Text = "BUY";
            this.btBuyMarket.UseVisualStyleBackColor = false;
            // 
            // btSellMarket
            // 
            this.btSellMarket.BackColor = System.Drawing.Color.Salmon;
            this.btSellMarket.Enabled = false;
            this.btSellMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSellMarket.Location = new System.Drawing.Point(180, 41);
            this.btSellMarket.Name = "btSellMarket";
            this.btSellMarket.Size = new System.Drawing.Size(151, 30);
            this.btSellMarket.TabIndex = 4;
            this.btSellMarket.Text = "SELL";
            this.btSellMarket.UseVisualStyleBackColor = false;
            // 
            // btCancelAllOrders
            // 
            this.btCancelAllOrders.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelAllOrders.Enabled = false;
            this.btCancelAllOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancelAllOrders.Location = new System.Drawing.Point(295, 3);
            this.btCancelAllOrders.Name = "btCancelAllOrders";
            this.btCancelAllOrders.Size = new System.Drawing.Size(61, 21);
            this.btCancelAllOrders.TabIndex = 13;
            this.btCancelAllOrders.Text = "Cancel All";
            this.btCancelAllOrders.UseVisualStyleBackColor = false;
            this.btCancelAllOrders.Click += new System.EventHandler(this.btCancelAllOrders_Click);
            // 
            // cbOpenTi
            // 
            this.cbOpenTi.AutoSize = true;
            this.cbOpenTi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbOpenTi.Location = new System.Drawing.Point(231, 26);
            this.cbOpenTi.Name = "cbOpenTi";
            this.cbOpenTi.Size = new System.Drawing.Size(106, 16);
            this.cbOpenTi.TabIndex = 14;
            this.cbOpenTi.Text = "открывать в Tinkoff";
            this.cbOpenTi.UseVisualStyleBackColor = true;
            // 
            // FormOrdersIB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 186);
            this.Controls.Add(this.cbOpenTi);
            this.Controls.Add(this.lbAsk);
            this.Controls.Add(this.btCancelAllOrders);
            this.Controls.Add(this.btCancelLastOrders);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbBid);
            this.Controls.Add(this.cbTicker);
            this.Controls.Add(this.tabOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(378, 225);
            this.Name = "FormOrdersIB";
            this.Text = "Orders IB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrdersIB_FormClosing);
            this.Load += new System.EventHandler(this.FormOrdersIB_Load);
            this.tabOrders.ResumeLayout(false);
            this.tabLimitOrder.ResumeLayout(false);
            this.tabLimitOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotsLimit)).EndInit();
            this.tabMarketOrder.ResumeLayout(false);
            this.tabMarketOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotsMarket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAsk;
        private System.Windows.Forms.Button btCancelLastOrders;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbBid;
        private System.Windows.Forms.ComboBox cbTicker;
        private System.Windows.Forms.TabControl tabOrders;
        private System.Windows.Forms.TabPage tabLimitOrder;
        private System.Windows.Forms.TextBox tbPriceLimit;
        private System.Windows.Forms.NumericUpDown numLotsLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBuyLimit;
        private System.Windows.Forms.Button btSellLimit;
        private System.Windows.Forms.TabPage tabMarketOrder;
        private System.Windows.Forms.TextBox tbPriceMarket;
        private System.Windows.Forms.NumericUpDown numLotsMarket;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btBuyMarket;
        private System.Windows.Forms.Button btSellMarket;
        private System.Windows.Forms.Button btCancelAllOrders;
        private System.Windows.Forms.ComboBox cbExchange;
        private System.Windows.Forms.CheckBox cbOpenTi;
    }
}