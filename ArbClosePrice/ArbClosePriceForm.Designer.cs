namespace FishingSizes
{
    partial class ArbClosePriceForm
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
            this.btTest = new System.Windows.Forms.Button();
            this.btSearchArb = new System.Windows.Forms.Button();
            this.numProcentDelta = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBlackList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProcentDelta)).BeginInit();
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
            this.dgvArb.Location = new System.Drawing.Point(-3, 31);
            this.dgvArb.MultiSelect = false;
            this.dgvArb.Name = "dgvArb";
            this.dgvArb.ReadOnly = true;
            this.dgvArb.RowTemplate.ReadOnly = true;
            this.dgvArb.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvArb.Size = new System.Drawing.Size(571, 282);
            this.dgvArb.TabIndex = 2;
            this.dgvArb.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArb_CellMouseDoubleClick);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(401, 4);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(73, 20);
            this.btTest.TabIndex = 3;
            this.btTest.Text = "reload data";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // btSearchArb
            // 
            this.btSearchArb.Location = new System.Drawing.Point(480, 4);
            this.btSearchArb.Name = "btSearchArb";
            this.btSearchArb.Size = new System.Drawing.Size(79, 20);
            this.btSearchArb.TabIndex = 4;
            this.btSearchArb.Text = "search arb";
            this.btSearchArb.UseVisualStyleBackColor = true;
            this.btSearchArb.Click += new System.EventHandler(this.btSearchArb_Click);
            // 
            // numProcentDelta
            // 
            this.numProcentDelta.DecimalPlaces = 2;
            this.numProcentDelta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numProcentDelta.Location = new System.Drawing.Point(328, 4);
            this.numProcentDelta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numProcentDelta.Name = "numProcentDelta";
            this.numProcentDelta.Size = new System.Drawing.Size(48, 20);
            this.numProcentDelta.TabIndex = 5;
            this.numProcentDelta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numProcentDelta.ValueChanged += new System.EventHandler(this.numProcentDelta_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "%";
            // 
            // cbBlackList
            // 
            this.cbBlackList.FormattingEnabled = true;
            this.cbBlackList.Location = new System.Drawing.Point(246, 4);
            this.cbBlackList.Name = "cbBlackList";
            this.cbBlackList.Size = new System.Drawing.Size(76, 21);
            this.cbBlackList.TabIndex = 7;
            this.cbBlackList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBlackList_KeyDown);
            // 
            // ArbClosePriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 307);
            this.Controls.Add(this.cbBlackList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numProcentDelta);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btSearchArb);
            this.Controls.Add(this.dgvArb);
            this.Name = "ArbClosePriceForm";
            this.Text = "Arbitrage from the closing price";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArbClosePriceForm_FormClosing);
            this.Load += new System.EventHandler(this.ArbClosePriceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProcentDelta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArb;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Button btSearchArb;
        private System.Windows.Forms.NumericUpDown numProcentDelta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBlackList;
    }
}