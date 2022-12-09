
namespace FishingSizes
{
    partial class QuotesForm
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
            this.dgvQuotes = new System.Windows.Forms.DataGridView();
            this.cbTicker = new System.Windows.Forms.ComboBox();
            this.lbSprad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuotes
            // 
            this.dgvQuotes.AllowUserToAddRows = false;
            this.dgvQuotes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvQuotes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuotes.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvQuotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQuotes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvQuotes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuotes.Location = new System.Drawing.Point(0, 31);
            this.dgvQuotes.Name = "dgvQuotes";
            this.dgvQuotes.ReadOnly = true;
            this.dgvQuotes.RowTemplate.ReadOnly = true;
            this.dgvQuotes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuotes.Size = new System.Drawing.Size(403, 69);
            this.dgvQuotes.TabIndex = 1;
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
            this.cbTicker.Location = new System.Drawing.Point(2, 3);
            this.cbTicker.Name = "cbTicker";
            this.cbTicker.Size = new System.Drawing.Size(101, 21);
            this.cbTicker.TabIndex = 2;
            this.cbTicker.TextChanged += new System.EventHandler(this.CbTicker_TextChanged);
            // 
            // lbSprad
            // 
            this.lbSprad.AutoSize = true;
            this.lbSprad.Location = new System.Drawing.Point(189, 11);
            this.lbSprad.Name = "lbSprad";
            this.lbSprad.Size = new System.Drawing.Size(0, 13);
            this.lbSprad.TabIndex = 3;
            // 
            // QuotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 99);
            this.Controls.Add(this.lbSprad);
            this.Controls.Add(this.cbTicker);
            this.Controls.Add(this.dgvQuotes);
            this.Name = "QuotesForm";
            this.Text = "Quotes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuotesForm_FormClosing);
            this.Load += new System.EventHandler(this.QuotesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuotes;
        private System.Windows.Forms.ComboBox cbTicker;
        private System.Windows.Forms.Label lbSprad;
    }
}