namespace FishingSizes
{
    partial class OrdersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersForm));
            this.tabOrders = new System.Windows.Forms.TabControl();
            this.tabLimitOrder = new System.Windows.Forms.TabPage();
            this.tbPriceLimit = new System.Windows.Forms.TextBox();
            this.numLotsLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDostupnoSell = new System.Windows.Forms.Label();
            this.lbDostupnoBuy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btBuyLimit = new System.Windows.Forms.Button();
            this.btSellLimit = new System.Windows.Forms.Button();
            this.tabMarketOrder = new System.Windows.Forms.TabPage();
            this.cbRandomVol = new System.Windows.Forms.CheckBox();
            this.tbPriceMarket = new System.Windows.Forms.TextBox();
            this.numLotsMarket = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btBuyMarket = new System.Windows.Forms.Button();
            this.btSellMarket = new System.Windows.Forms.Button();
            this.btCancelOrders = new System.Windows.Forms.Button();
            this.cbTicker = new System.Windows.Forms.ComboBox();
            this.lbBid = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbAsk = new System.Windows.Forms.Label();
            this.cbOpenTi = new System.Windows.Forms.CheckBox();
            this.lbPortfolioVol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabOrders.SuspendLayout();
            this.tabLimitOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotsLimit)).BeginInit();
            this.tabMarketOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLotsMarket)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.tabLimitOrder);
            this.tabOrders.Controls.Add(this.tabMarketOrder);
            this.tabOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabOrders.Location = new System.Drawing.Point(0, 58);
            this.tabOrders.Margin = new System.Windows.Forms.Padding(4);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.SelectedIndex = 0;
            this.tabOrders.Size = new System.Drawing.Size(416, 143);
            this.tabOrders.TabIndex = 0;
            // 
            // tabLimitOrder
            // 
            this.tabLimitOrder.BackColor = System.Drawing.Color.Transparent;
            this.tabLimitOrder.Controls.Add(this.tbPriceLimit);
            this.tabLimitOrder.Controls.Add(this.numLotsLimit);
            this.tabLimitOrder.Controls.Add(this.label2);
            this.tabLimitOrder.Controls.Add(this.lbDostupnoSell);
            this.tabLimitOrder.Controls.Add(this.lbDostupnoBuy);
            this.tabLimitOrder.Controls.Add(this.label1);
            this.tabLimitOrder.Controls.Add(this.btBuyLimit);
            this.tabLimitOrder.Controls.Add(this.btSellLimit);
            this.tabLimitOrder.Location = new System.Drawing.Point(4, 22);
            this.tabLimitOrder.Margin = new System.Windows.Forms.Padding(4);
            this.tabLimitOrder.Name = "tabLimitOrder";
            this.tabLimitOrder.Padding = new System.Windows.Forms.Padding(4);
            this.tabLimitOrder.Size = new System.Drawing.Size(408, 117);
            this.tabLimitOrder.TabIndex = 0;
            this.tabLimitOrder.Text = "LimitOrder";
            // 
            // tbPriceLimit
            // 
            this.tbPriceLimit.Enabled = false;
            this.tbPriceLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbPriceLimit.Location = new System.Drawing.Point(102, 11);
            this.tbPriceLimit.Margin = new System.Windows.Forms.Padding(4);
            this.tbPriceLimit.MaxLength = 10;
            this.tbPriceLimit.Name = "tbPriceLimit";
            this.tbPriceLimit.Size = new System.Drawing.Size(94, 26);
            this.tbPriceLimit.TabIndex = 8;
            this.tbPriceLimit.Text = "0,00";
            this.tbPriceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPriceLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPriceLimit_KeyPress);
            this.tbPriceLimit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbPriceLimit_MouseDoubleClick);
            // 
            // numLotsLimit
            // 
            this.numLotsLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numLotsLimit.Enabled = false;
            this.numLotsLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numLotsLimit.Location = new System.Drawing.Point(211, 11);
            this.numLotsLimit.Margin = new System.Windows.Forms.Padding(4);
            this.numLotsLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLotsLimit.Name = "numLotsLimit";
            this.numLotsLimit.Size = new System.Drawing.Size(94, 26);
            this.numLotsLimit.TabIndex = 6;
            this.numLotsLimit.ThousandsSeparator = true;
            this.numLotsLimit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.numLotsLimit_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "КОЛ-ВО";
            // 
            // lbDostupnoSell
            // 
            this.lbDostupnoSell.AutoSize = true;
            this.lbDostupnoSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDostupnoSell.Location = new System.Drawing.Point(212, 84);
            this.lbDostupnoSell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDostupnoSell.Name = "lbDostupnoSell";
            this.lbDostupnoSell.Size = new System.Drawing.Size(25, 12);
            this.lbDostupnoSell.TabIndex = 2;
            this.lbDostupnoSell.Text = "1000";
            this.lbDostupnoSell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDostupnoBuy
            // 
            this.lbDostupnoBuy.AutoSize = true;
            this.lbDostupnoBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbDostupnoBuy.Location = new System.Drawing.Point(102, 84);
            this.lbDostupnoBuy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDostupnoBuy.Name = "lbDostupnoBuy";
            this.lbDostupnoBuy.Size = new System.Drawing.Size(25, 12);
            this.lbDostupnoBuy.TabIndex = 2;
            this.lbDostupnoBuy.Text = "1000";
            this.lbDostupnoBuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ЦЕНА";
            // 
            // btBuyLimit
            // 
            this.btBuyLimit.BackColor = System.Drawing.Color.PaleGreen;
            this.btBuyLimit.Enabled = false;
            this.btBuyLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btBuyLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btBuyLimit.Location = new System.Drawing.Point(102, 45);
            this.btBuyLimit.Margin = new System.Windows.Forms.Padding(4);
            this.btBuyLimit.Name = "btBuyLimit";
            this.btBuyLimit.Size = new System.Drawing.Size(96, 35);
            this.btBuyLimit.TabIndex = 1;
            this.btBuyLimit.Text = "BUY";
            this.btBuyLimit.UseVisualStyleBackColor = false;
            this.btBuyLimit.Click += new System.EventHandler(this.btBuyLimit_Click);
            // 
            // btSellLimit
            // 
            this.btSellLimit.BackColor = System.Drawing.Color.Salmon;
            this.btSellLimit.Enabled = false;
            this.btSellLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btSellLimit.Location = new System.Drawing.Point(210, 45);
            this.btSellLimit.Margin = new System.Windows.Forms.Padding(4);
            this.btSellLimit.Name = "btSellLimit";
            this.btSellLimit.Size = new System.Drawing.Size(95, 35);
            this.btSellLimit.TabIndex = 0;
            this.btSellLimit.Text = "SELL";
            this.btSellLimit.UseVisualStyleBackColor = false;
            this.btSellLimit.Click += new System.EventHandler(this.btSellLimit_Click);
            // 
            // tabMarketOrder
            // 
            this.tabMarketOrder.Controls.Add(this.cbRandomVol);
            this.tabMarketOrder.Controls.Add(this.tbPriceMarket);
            this.tabMarketOrder.Controls.Add(this.numLotsMarket);
            this.tabMarketOrder.Controls.Add(this.label12);
            this.tabMarketOrder.Controls.Add(this.label14);
            this.tabMarketOrder.Controls.Add(this.label16);
            this.tabMarketOrder.Controls.Add(this.label17);
            this.tabMarketOrder.Controls.Add(this.btBuyMarket);
            this.tabMarketOrder.Controls.Add(this.btSellMarket);
            this.tabMarketOrder.Location = new System.Drawing.Point(4, 22);
            this.tabMarketOrder.Margin = new System.Windows.Forms.Padding(4);
            this.tabMarketOrder.Name = "tabMarketOrder";
            this.tabMarketOrder.Padding = new System.Windows.Forms.Padding(4);
            this.tabMarketOrder.Size = new System.Drawing.Size(408, 117);
            this.tabMarketOrder.TabIndex = 1;
            this.tabMarketOrder.Text = "MarketOrder";
            this.tabMarketOrder.UseVisualStyleBackColor = true;
            // 
            // cbRandomVol
            // 
            this.cbRandomVol.AutoSize = true;
            this.cbRandomVol.Location = new System.Drawing.Point(5, 7);
            this.cbRandomVol.Name = "cbRandomVol";
            this.cbRandomVol.Size = new System.Drawing.Size(15, 14);
            this.cbRandomVol.TabIndex = 17;
            this.cbRandomVol.UseVisualStyleBackColor = true;
            // 
            // tbPriceMarket
            // 
            this.tbPriceMarket.Enabled = false;
            this.tbPriceMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbPriceMarket.Location = new System.Drawing.Point(102, 14);
            this.tbPriceMarket.Margin = new System.Windows.Forms.Padding(4);
            this.tbPriceMarket.MaxLength = 10;
            this.tbPriceMarket.Name = "tbPriceMarket";
            this.tbPriceMarket.Size = new System.Drawing.Size(94, 26);
            this.tbPriceMarket.TabIndex = 16;
            this.tbPriceMarket.Text = "0,00";
            this.tbPriceMarket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numLotsMarket
            // 
            this.numLotsMarket.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numLotsMarket.Enabled = false;
            this.numLotsMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numLotsMarket.Location = new System.Drawing.Point(211, 14);
            this.numLotsMarket.Margin = new System.Windows.Forms.Padding(4);
            this.numLotsMarket.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLotsMarket.Name = "numLotsMarket";
            this.numLotsMarket.Size = new System.Drawing.Size(94, 26);
            this.numLotsMarket.TabIndex = 15;
            this.numLotsMarket.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.numLotsMarket_MouseDoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(308, 29);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "КОЛ-ВО";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 106);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Сумма:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 84);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Доступно:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(53, 29);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "ЦЕНА";
            // 
            // btBuyMarket
            // 
            this.btBuyMarket.BackColor = System.Drawing.Color.PaleGreen;
            this.btBuyMarket.Enabled = false;
            this.btBuyMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btBuyMarket.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btBuyMarket.Location = new System.Drawing.Point(27, 47);
            this.btBuyMarket.Margin = new System.Windows.Forms.Padding(4);
            this.btBuyMarket.Name = "btBuyMarket";
            this.btBuyMarket.Size = new System.Drawing.Size(171, 35);
            this.btBuyMarket.TabIndex = 5;
            this.btBuyMarket.Text = "BUY";
            this.btBuyMarket.UseVisualStyleBackColor = false;
            this.btBuyMarket.Click += new System.EventHandler(this.btBuyMarket_Click);
            // 
            // btSellMarket
            // 
            this.btSellMarket.BackColor = System.Drawing.Color.Salmon;
            this.btSellMarket.Enabled = false;
            this.btSellMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btSellMarket.Location = new System.Drawing.Point(210, 47);
            this.btSellMarket.Margin = new System.Windows.Forms.Padding(4);
            this.btSellMarket.Name = "btSellMarket";
            this.btSellMarket.Size = new System.Drawing.Size(176, 35);
            this.btSellMarket.TabIndex = 4;
            this.btSellMarket.Text = "SELL";
            this.btSellMarket.UseVisualStyleBackColor = false;
            this.btSellMarket.Click += new System.EventHandler(this.btSellMarket_Click);
            // 
            // btCancelOrders
            // 
            this.btCancelOrders.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCancelOrders.Enabled = false;
            this.btCancelOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCancelOrders.Location = new System.Drawing.Point(284, 4);
            this.btCancelOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btCancelOrders.Name = "btCancelOrders";
            this.btCancelOrders.Size = new System.Drawing.Size(129, 28);
            this.btCancelOrders.TabIndex = 7;
            this.btCancelOrders.Text = "Cancel Orders";
            this.btCancelOrders.UseVisualStyleBackColor = false;
            this.btCancelOrders.Click += new System.EventHandler(this.btCancelOrders_Click);
            // 
            // cbTicker
            // 
            this.cbTicker.FormattingEnabled = true;
            this.cbTicker.Items.AddRange(new object[] {
            "APLE",
            "ARMK",
            "BKR",
            "BLMN",
            "CNX",
            "COLD",
            "ELAN",
            "IOVA",
            "MDRX",
            "NKTR",
            "PD",
            "PRTS",
            "TGNA",
            "VIRT",
            "ZWS"});
            this.cbTicker.Location = new System.Drawing.Point(4, 8);
            this.cbTicker.Margin = new System.Windows.Forms.Padding(4);
            this.cbTicker.Name = "cbTicker";
            this.cbTicker.Size = new System.Drawing.Size(117, 23);
            this.cbTicker.TabIndex = 3;
            this.cbTicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTicker_KeyDown);
            // 
            // lbBid
            // 
            this.lbBid.AutoSize = true;
            this.lbBid.Location = new System.Drawing.Point(162, 22);
            this.lbBid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBid.Name = "lbBid";
            this.lbBid.Size = new System.Drawing.Size(13, 15);
            this.lbBid.TabIndex = 4;
            this.lbBid.Text = "0";
            this.lbBid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbBid.Click += new System.EventHandler(this.lbBid_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(183, 4);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "B : A";
            // 
            // lbAsk
            // 
            this.lbAsk.AutoSize = true;
            this.lbAsk.Location = new System.Drawing.Point(213, 22);
            this.lbAsk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAsk.Name = "lbAsk";
            this.lbAsk.Size = new System.Drawing.Size(13, 15);
            this.lbAsk.TabIndex = 4;
            this.lbAsk.Text = "0";
            this.lbAsk.Click += new System.EventHandler(this.lbAsk_Click);
            // 
            // cbOpenTi
            // 
            this.cbOpenTi.AutoSize = true;
            this.cbOpenTi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOpenTi.Location = new System.Drawing.Point(286, 34);
            this.cbOpenTi.Margin = new System.Windows.Forms.Padding(4);
            this.cbOpenTi.Name = "cbOpenTi";
            this.cbOpenTi.Size = new System.Drawing.Size(106, 16);
            this.cbOpenTi.TabIndex = 16;
            this.cbOpenTi.Text = "открывать в Tinkoff";
            this.cbOpenTi.UseVisualStyleBackColor = true;
            // 
            // lbPortfolioVol
            // 
            this.lbPortfolioVol.AutoSize = true;
            this.lbPortfolioVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbPortfolioVol.Location = new System.Drawing.Point(67, 38);
            this.lbPortfolioVol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPortfolioVol.Name = "lbPortfolioVol";
            this.lbPortfolioVol.Size = new System.Drawing.Size(10, 12);
            this.lbPortfolioVol.TabIndex = 2;
            this.lbPortfolioVol.Text = "0";
            this.lbPortfolioVol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPortfolioVol.Click += new System.EventHandler(this.lbPortfolioVol_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(4, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "В портфеле:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(413, 187);
            this.Controls.Add(this.cbOpenTi);
            this.Controls.Add(this.lbAsk);
            this.Controls.Add(this.btCancelOrders);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbPortfolioVol);
            this.Controls.Add(this.lbBid);
            this.Controls.Add(this.cbTicker);
            this.Controls.Add(this.tabOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(431, 233);
            this.Name = "OrdersForm";
            this.Text = "Tinkoff Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrdersForm_FormClosing);
            this.Load += new System.EventHandler(this.OrdersForm_Load);
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

        private System.Windows.Forms.TabControl tabOrders;
        private System.Windows.Forms.TabPage tabLimitOrder;
        private System.Windows.Forms.TabPage tabMarketOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBuyLimit;
        private System.Windows.Forms.Button btSellLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTicker;
        private System.Windows.Forms.Label lbBid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbAsk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btBuyMarket;
        private System.Windows.Forms.Button btSellMarket;
        private System.Windows.Forms.NumericUpDown numLotsLimit;
        private System.Windows.Forms.NumericUpDown numLotsMarket;
        private System.Windows.Forms.Button btCancelOrders;
        private System.Windows.Forms.TextBox tbPriceLimit;
        private System.Windows.Forms.TextBox tbPriceMarket;
        private System.Windows.Forms.CheckBox cbOpenTi;
        private System.Windows.Forms.CheckBox cbRandomVol;
        private System.Windows.Forms.Label lbDostupnoSell;
        private System.Windows.Forms.Label lbDostupnoBuy;
        private System.Windows.Forms.Label lbPortfolioVol;
        private System.Windows.Forms.Label label4;
    }
}