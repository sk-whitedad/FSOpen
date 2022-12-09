
namespace FishingSizes
{
    public partial class FormTrades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrades));
            this.dgvTrades = new System.Windows.Forms.DataGridView();
            this.cbTicker = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFiltrTradesLow = new System.Windows.Forms.TextBox();
            this.tbFiltrTradesHight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSprad = new System.Windows.Forms.Label();
            this.dgvQuotes = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOpenTi = new System.Windows.Forms.CheckBox();
            this.cbHightLow = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbS = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSpeedPrints = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvTrades.Location = new System.Drawing.Point(2, 123);
            this.dgvTrades.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvTrades.Name = "dgvTrades";
            this.dgvTrades.ReadOnly = true;
            this.dgvTrades.RowHeadersWidth = 51;
            this.dgvTrades.RowTemplate.ReadOnly = true;
            this.dgvTrades.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrades.Size = new System.Drawing.Size(333, 640);
            this.dgvTrades.TabIndex = 0;
            // 
            // cbTicker
            // 
            this.cbTicker.Enabled = false;
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
            this.cbTicker.Location = new System.Drawing.Point(2, 6);
            this.cbTicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbTicker.Name = "cbTicker";
            this.cbTicker.Size = new System.Drawing.Size(117, 23);
            this.cbTicker.TabIndex = 1;
            this.cbTicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTicker_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 2;
            // 
            // tbFiltrTradesLow
            // 
            this.tbFiltrTradesLow.Location = new System.Drawing.Point(200, 6);
            this.tbFiltrTradesLow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbFiltrTradesLow.Name = "tbFiltrTradesLow";
            this.tbFiltrTradesLow.Size = new System.Drawing.Size(42, 23);
            this.tbFiltrTradesLow.TabIndex = 3;
            this.tbFiltrTradesLow.TextChanged += new System.EventHandler(this.tbFiltrTradesLow_TextChanged);
            // 
            // tbFiltrTradesHight
            // 
            this.tbFiltrTradesHight.Location = new System.Drawing.Point(265, 6);
            this.tbFiltrTradesHight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbFiltrTradesHight.Name = "tbFiltrTradesHight";
            this.tbFiltrTradesHight.Size = new System.Drawing.Size(42, 23);
            this.tbFiltrTradesHight.TabIndex = 3;
            this.tbFiltrTradesHight.TextChanged += new System.EventHandler(this.tbFiltrTradesHight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Фильтр, шт:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // lbSprad
            // 
            this.lbSprad.AutoSize = true;
            this.lbSprad.Location = new System.Drawing.Point(54, 40);
            this.lbSprad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSprad.Name = "lbSprad";
            this.lbSprad.Size = new System.Drawing.Size(17, 15);
            this.lbSprad.TabIndex = 3;
            this.lbSprad.Text = "--";
            // 
            // dgvQuotes
            // 
            this.dgvQuotes.AllowUserToAddRows = false;
            this.dgvQuotes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvQuotes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuotes.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvQuotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQuotes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvQuotes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuotes.Location = new System.Drawing.Point(0, -1);
            this.dgvQuotes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvQuotes.Name = "dgvQuotes";
            this.dgvQuotes.ReadOnly = true;
            this.dgvQuotes.RowHeadersWidth = 51;
            this.dgvQuotes.RowTemplate.ReadOnly = true;
            this.dgvQuotes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuotes.Size = new System.Drawing.Size(333, 47);
            this.dgvQuotes.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "S:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvQuotes);
            this.groupBox1.Location = new System.Drawing.Point(2, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(333, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cbOpenTi
            // 
            this.cbOpenTi.AutoSize = true;
            this.cbOpenTi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbOpenTi.Location = new System.Drawing.Point(2, 40);
            this.cbOpenTi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbOpenTi.Name = "cbOpenTi";
            this.cbOpenTi.Size = new System.Drawing.Size(31, 16);
            this.cbOpenTi.TabIndex = 17;
            this.cbOpenTi.Text = "Ti";
            this.cbOpenTi.UseVisualStyleBackColor = true;
            // 
            // cbHightLow
            // 
            this.cbHightLow.AutoSize = true;
            this.cbHightLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbHightLow.Location = new System.Drawing.Point(265, 40);
            this.cbHightLow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbHightLow.Name = "cbHightLow";
            this.cbHightLow.Size = new System.Drawing.Size(67, 16);
            this.cbHightLow.TabIndex = 17;
            this.cbHightLow.Text = "Hight/Low";
            this.cbHightLow.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(172, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "%";
            // 
            // lbS
            // 
            this.lbS.AutoSize = true;
            this.lbS.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbS.ForeColor = System.Drawing.Color.Firebrick;
            this.lbS.Location = new System.Drawing.Point(152, 45);
            this.lbS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbS.Name = "lbS";
            this.lbS.Size = new System.Drawing.Size(14, 15);
            this.lbS.TabIndex = 27;
            this.lbS.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(172, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "%";
            // 
            // lbL
            // 
            this.lbL.AutoSize = true;
            this.lbL.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbL.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbL.Location = new System.Drawing.Point(152, 30);
            this.lbL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbL.Name = "lbL";
            this.lbL.Size = new System.Drawing.Size(14, 15);
            this.lbL.TabIndex = 29;
            this.lbL.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Firebrick;
            this.label7.Location = new System.Drawing.Point(131, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "S";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(131, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "L";
            // 
            // lbSpeedPrints
            // 
            this.lbSpeedPrints.AutoSize = true;
            this.lbSpeedPrints.Location = new System.Drawing.Point(240, 40);
            this.lbSpeedPrints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSpeedPrints.Name = "lbSpeedPrints";
            this.lbSpeedPrints.Size = new System.Drawing.Size(17, 15);
            this.lbSpeedPrints.TabIndex = 32;
            this.lbSpeedPrints.Text = "--";
            // 
            // FormTrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 760);
            this.Controls.Add(this.lbSpeedPrints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbHightLow);
            this.Controls.Add(this.cbOpenTi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFiltrTradesHight);
            this.Controls.Add(this.tbFiltrTradesLow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTicker);
            this.Controls.Add(this.dgvTrades);
            this.Controls.Add(this.lbSprad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(349, 1174);
            this.MinimumSize = new System.Drawing.Size(349, 200);
            this.Name = "FormTrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Trades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTrades_FormClosing);
            this.Load += new System.EventHandler(this.FormTrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrades;
        public System.Windows.Forms.ComboBox cbTicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFiltrTradesLow;
        private System.Windows.Forms.TextBox tbFiltrTradesHight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvQuotes;
        private System.Windows.Forms.Label lbSprad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbOpenTi;
        private System.Windows.Forms.CheckBox cbHightLow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbSpeedPrints;
    }
}