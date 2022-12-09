namespace FishingSizes
{
    partial class FormTradesSpb
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbOpenTi = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTicker = new System.Windows.Forms.ComboBox();
            this.dgvTrades = new System.Windows.Forms.DataGridView();
            this.lbSprad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbL = new System.Windows.Forms.Label();
            this.lbS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOpenTi
            // 
            this.cbOpenTi.AutoSize = true;
            this.cbOpenTi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOpenTi.Location = new System.Drawing.Point(10, 38);
            this.cbOpenTi.Margin = new System.Windows.Forms.Padding(4);
            this.cbOpenTi.Name = "cbOpenTi";
            this.cbOpenTi.Size = new System.Drawing.Size(52, 16);
            this.cbOpenTi.TabIndex = 26;
            this.cbOpenTi.Text = "Tinkoff";
            this.cbOpenTi.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "S:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(115, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "L";
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
            this.cbTicker.Location = new System.Drawing.Point(10, 4);
            this.cbTicker.Margin = new System.Windows.Forms.Padding(4);
            this.cbTicker.Name = "cbTicker";
            this.cbTicker.Size = new System.Drawing.Size(87, 23);
            this.cbTicker.TabIndex = 19;
            this.cbTicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTicker_KeyDown);
            // 
            // dgvTrades
            // 
            this.dgvTrades.AllowUserToAddRows = false;
            this.dgvTrades.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTrades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrades.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvTrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTrades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrades.Location = new System.Drawing.Point(0, 64);
            this.dgvTrades.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTrades.Name = "dgvTrades";
            this.dgvTrades.ReadOnly = true;
            this.dgvTrades.RowHeadersWidth = 51;
            this.dgvTrades.RowTemplate.ReadOnly = true;
            this.dgvTrades.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrades.Size = new System.Drawing.Size(286, 397);
            this.dgvTrades.TabIndex = 18;
            // 
            // lbSprad
            // 
            this.lbSprad.AutoSize = true;
            this.lbSprad.Location = new System.Drawing.Point(78, 37);
            this.lbSprad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSprad.Name = "lbSprad";
            this.lbSprad.Size = new System.Drawing.Size(17, 15);
            this.lbSprad.TabIndex = 22;
            this.lbSprad.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(115, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "S";
            // 
            // lbL
            // 
            this.lbL.AutoSize = true;
            this.lbL.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbL.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbL.Location = new System.Drawing.Point(136, 4);
            this.lbL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbL.Name = "lbL";
            this.lbL.Size = new System.Drawing.Size(14, 15);
            this.lbL.TabIndex = 25;
            this.lbL.Text = "0";
            // 
            // lbS
            // 
            this.lbS.AutoSize = true;
            this.lbS.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbS.ForeColor = System.Drawing.Color.Firebrick;
            this.lbS.Location = new System.Drawing.Point(136, 19);
            this.lbS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbS.Name = "lbS";
            this.lbS.Size = new System.Drawing.Size(14, 15);
            this.lbS.TabIndex = 25;
            this.lbS.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(156, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(156, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "%";
            // 
            // FormTradesSpb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.cbOpenTi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTicker);
            this.Controls.Add(this.dgvTrades);
            this.Controls.Add(this.lbSprad);
            this.MaximumSize = new System.Drawing.Size(300, 500);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormTradesSpb";
            this.Text = "SPB Trades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTradesSpb_FormClosing);
            this.Load += new System.EventHandler(this.FormTradesSpb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbOpenTi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbTicker;
        private System.Windows.Forms.DataGridView dgvTrades;
        private System.Windows.Forms.Label lbSprad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbL;
        private System.Windows.Forms.Label lbS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}