namespace FishingSizes
{
    partial class LimitOrderActiv
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTicker = new System.Windows.Forms.Label();
            this.btEditOrder = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.lbTextBaySell = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbTextVol = new System.Windows.Forms.Label();
            this.lbVol = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPriceLimit = new System.Windows.Forms.TextBox();
            this.numLotsLimit = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numLotsLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTicker
            // 
            this.lbTicker.AutoSize = true;
            this.lbTicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTicker.ForeColor = System.Drawing.Color.Black;
            this.lbTicker.Location = new System.Drawing.Point(12, 10);
            this.lbTicker.Name = "lbTicker";
            this.lbTicker.Size = new System.Drawing.Size(35, 15);
            this.lbTicker.TabIndex = 0;
            this.lbTicker.Text = "TSLA";
            // 
            // btEditOrder
            // 
            this.btEditOrder.BackColor = System.Drawing.Color.LightGray;
            this.btEditOrder.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btEditOrder.Location = new System.Drawing.Point(189, 45);
            this.btEditOrder.Name = "btEditOrder";
            this.btEditOrder.Size = new System.Drawing.Size(30, 21);
            this.btEditOrder.TabIndex = 1;
            this.btEditOrder.Text = "Edit";
            this.btEditOrder.UseVisualStyleBackColor = false;
            this.btEditOrder.Click += new System.EventHandler(this.btEditOrder_Click);
            // 
            // btDel
            // 
            this.btDel.BackColor = System.Drawing.Color.LightGray;
            this.btDel.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btDel.Location = new System.Drawing.Point(222, 45);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(30, 21);
            this.btDel.TabIndex = 1;
            this.btDel.Text = "Del";
            this.btDel.UseVisualStyleBackColor = false;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // lbTextBaySell
            // 
            this.lbTextBaySell.AutoSize = true;
            this.lbTextBaySell.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTextBaySell.ForeColor = System.Drawing.Color.Black;
            this.lbTextBaySell.Location = new System.Drawing.Point(13, 31);
            this.lbTextBaySell.Name = "lbTextBaySell";
            this.lbTextBaySell.Size = new System.Drawing.Size(108, 15);
            this.lbTextBaySell.TabIndex = 0;
            this.lbTextBaySell.Text = "Покупка по цене:";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbPrice.ForeColor = System.Drawing.Color.Black;
            this.lbPrice.Location = new System.Drawing.Point(127, 31);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(45, 15);
            this.lbPrice.TabIndex = 0;
            this.lbPrice.Text = "250,00";
            // 
            // lbTextVol
            // 
            this.lbTextVol.AutoSize = true;
            this.lbTextVol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTextVol.ForeColor = System.Drawing.Color.Black;
            this.lbTextVol.Location = new System.Drawing.Point(12, 50);
            this.lbTextVol.Name = "lbTextVol";
            this.lbTextVol.Size = new System.Drawing.Size(79, 15);
            this.lbTextVol.TabIndex = 0;
            this.lbTextVol.Text = "Количество:";
            // 
            // lbVol
            // 
            this.lbVol.AutoSize = true;
            this.lbVol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbVol.ForeColor = System.Drawing.Color.Black;
            this.lbVol.Location = new System.Drawing.Point(127, 50);
            this.lbVol.Name = "lbVol";
            this.lbVol.Size = new System.Drawing.Size(14, 15);
            this.lbVol.TabIndex = 0;
            this.lbVol.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(151, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Лимитный ордер";
            // 
            // tbPriceLimit
            // 
            this.tbPriceLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPriceLimit.Location = new System.Drawing.Point(127, 27);
            this.tbPriceLimit.Margin = new System.Windows.Forms.Padding(4);
            this.tbPriceLimit.MaxLength = 10;
            this.tbPriceLimit.Name = "tbPriceLimit";
            this.tbPriceLimit.Size = new System.Drawing.Size(55, 20);
            this.tbPriceLimit.TabIndex = 9;
            this.tbPriceLimit.Text = "0,00";
            this.tbPriceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPriceLimit.Visible = false;
            this.tbPriceLimit.WordWrap = false;
            // 
            // numLotsLimit
            // 
            this.numLotsLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numLotsLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numLotsLimit.Location = new System.Drawing.Point(127, 49);
            this.numLotsLimit.Margin = new System.Windows.Forms.Padding(4);
            this.numLotsLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLotsLimit.Name = "numLotsLimit";
            this.numLotsLimit.Size = new System.Drawing.Size(55, 20);
            this.numLotsLimit.TabIndex = 10;
            this.numLotsLimit.ThousandsSeparator = true;
            this.numLotsLimit.Visible = false;
            // 
            // LimitOrderActiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.numLotsLimit);
            this.Controls.Add(this.tbPriceLimit);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btEditOrder);
            this.Controls.Add(this.lbVol);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbTextVol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTextBaySell);
            this.Controls.Add(this.lbTicker);
            this.Name = "LimitOrderActiv";
            this.Size = new System.Drawing.Size(256, 72);
            ((System.ComponentModel.ISupportInitialize)(this.numLotsLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbTicker;
        public System.Windows.Forms.Button btEditOrder;
        public System.Windows.Forms.Button btDel;
        public System.Windows.Forms.Label lbTextBaySell;
        public System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbTextVol;
        public System.Windows.Forms.Label lbVol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPriceLimit;
        private System.Windows.Forms.NumericUpDown numLotsLimit;
    }
}
