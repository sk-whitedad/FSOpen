namespace FishingSizes
{
    partial class HistoryOrdersForm
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
            this.dgvHistoryOrders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistoryOrders
            // 
            this.dgvHistoryOrders.AllowUserToAddRows = false;
            this.dgvHistoryOrders.AllowUserToDeleteRows = false;
            this.dgvHistoryOrders.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dgvHistoryOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistoryOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistoryOrders.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvHistoryOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistoryOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHistoryOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvHistoryOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoryOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvHistoryOrders.MultiSelect = false;
            this.dgvHistoryOrders.Name = "dgvHistoryOrders";
            this.dgvHistoryOrders.ReadOnly = true;
            this.dgvHistoryOrders.RowHeadersWidth = 51;
            this.dgvHistoryOrders.RowTemplate.ReadOnly = true;
            this.dgvHistoryOrders.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistoryOrders.Size = new System.Drawing.Size(400, 267);
            this.dgvHistoryOrders.TabIndex = 7;
            // 
            // HistoryOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 261);
            this.Controls.Add(this.dgvHistoryOrders);
            this.MaximumSize = new System.Drawing.Size(410, 768);
            this.MinimumSize = new System.Drawing.Size(410, 300);
            this.Name = "HistoryOrdersForm";
            this.Text = "История сделок";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistoryOrdersForm_FormClosing);
            this.Load += new System.EventHandler(this.HistoryOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistoryOrders;
    }
}