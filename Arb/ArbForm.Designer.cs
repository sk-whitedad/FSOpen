namespace FishingSizes
{
    partial class ArbForm
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
            this.dgvArb = new System.Windows.Forms.DataGridView();
            this.btSearchArb = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.cbBlackList = new System.Windows.Forms.ComboBox();
            this.cbModeOrders = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArb)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArb
            // 
            this.dgvArb.AllowUserToAddRows = false;
            this.dgvArb.AllowUserToDeleteRows = false;
            this.dgvArb.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvArb.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArb.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvArb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArb.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvArb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvArb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArb.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArb.Location = new System.Drawing.Point(0, 30);
            this.dgvArb.MultiSelect = false;
            this.dgvArb.Name = "dgvArb";
            this.dgvArb.ReadOnly = true;
            this.dgvArb.RowTemplate.ReadOnly = true;
            this.dgvArb.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvArb.Size = new System.Drawing.Size(654, 291);
            this.dgvArb.TabIndex = 1;
            this.dgvArb.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArb_CellMouseDoubleClick);
            // 
            // btSearchArb
            // 
            this.btSearchArb.Location = new System.Drawing.Point(411, 4);
            this.btSearchArb.Name = "btSearchArb";
            this.btSearchArb.Size = new System.Drawing.Size(228, 20);
            this.btSearchArb.TabIndex = 2;
            this.btSearchArb.Text = "search arb";
            this.btSearchArb.UseVisualStyleBackColor = true;
            this.btSearchArb.Click += new System.EventHandler(this.btSearchArb_Click);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(332, 4);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(73, 20);
            this.btTest.TabIndex = 2;
            this.btTest.Text = "reload data";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // cbBlackList
            // 
            this.cbBlackList.FormattingEnabled = true;
            this.cbBlackList.Location = new System.Drawing.Point(250, 4);
            this.cbBlackList.Name = "cbBlackList";
            this.cbBlackList.Size = new System.Drawing.Size(76, 21);
            this.cbBlackList.TabIndex = 3;
            this.cbBlackList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBlackList_KeyDown);
            // 
            // cbModeOrders
            // 
            this.cbModeOrders.AutoSize = true;
            this.cbModeOrders.Location = new System.Drawing.Point(5, 6);
            this.cbModeOrders.Name = "cbModeOrders";
            this.cbModeOrders.Size = new System.Drawing.Size(107, 17);
            this.cbModeOrders.TabIndex = 4;
            this.cbModeOrders.Text = "set market orders";
            this.cbModeOrders.UseVisualStyleBackColor = true;
            // 
            // ArbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 317);
            this.Controls.Add(this.cbModeOrders);
            this.Controls.Add(this.cbBlackList);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btSearchArb);
            this.Controls.Add(this.dgvArb);
            this.Name = "ArbForm";
            this.Text = "Arbitrage US-SPB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArbForm_FormClosing);
            this.Load += new System.EventHandler(this.ArbForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArb;
        private System.Windows.Forms.Button btSearchArb;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.ComboBox cbBlackList;
        private System.Windows.Forms.CheckBox cbModeOrders;
    }
}