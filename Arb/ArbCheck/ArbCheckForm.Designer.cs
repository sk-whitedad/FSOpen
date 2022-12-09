namespace FishingSizes
{
    partial class ArbCheckForm
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
            this.btGO1 = new System.Windows.Forms.Button();
            this.btGO2 = new System.Windows.Forms.Button();
            this.tbBidUS = new System.Windows.Forms.TextBox();
            this.tbAskSPB = new System.Windows.Forms.TextBox();
            this.tbAskUS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBidSPB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAskSPBvol = new System.Windows.Forms.TextBox();
            this.tbAskUSvol = new System.Windows.Forms.TextBox();
            this.tbBidUSvol = new System.Windows.Forms.TextBox();
            this.tbBidSPBvol = new System.Windows.Forms.TextBox();
            this.btReload = new System.Windows.Forms.Button();
            this.numPriceMost = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btCancelOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPriceMost)).BeginInit();
            this.SuspendLayout();
            // 
            // btGO1
            // 
            this.btGO1.Location = new System.Drawing.Point(134, 77);
            this.btGO1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btGO1.Name = "btGO1";
            this.btGO1.Size = new System.Drawing.Size(239, 37);
            this.btGO1.TabIndex = 1;
            this.btGO1.Text = "STEP 1";
            this.btGO1.UseVisualStyleBackColor = true;
            this.btGO1.Click += new System.EventHandler(this.btGO1_Click);
            // 
            // btGO2
            // 
            this.btGO2.Enabled = false;
            this.btGO2.Location = new System.Drawing.Point(134, 130);
            this.btGO2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btGO2.Name = "btGO2";
            this.btGO2.Size = new System.Drawing.Size(239, 35);
            this.btGO2.TabIndex = 1;
            this.btGO2.Text = "STEP 2";
            this.btGO2.UseVisualStyleBackColor = true;
            this.btGO2.Click += new System.EventHandler(this.btGO2_Click);
            // 
            // tbBidUS
            // 
            this.tbBidUS.Location = new System.Drawing.Point(190, 10);
            this.tbBidUS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbBidUS.Name = "tbBidUS";
            this.tbBidUS.ReadOnly = true;
            this.tbBidUS.Size = new System.Drawing.Size(55, 23);
            this.tbBidUS.TabIndex = 2;
            this.tbBidUS.Click += new System.EventHandler(this.tbBidUS_Click);
            // 
            // tbAskSPB
            // 
            this.tbAskSPB.Location = new System.Drawing.Point(124, 10);
            this.tbAskSPB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAskSPB.Name = "tbAskSPB";
            this.tbAskSPB.Size = new System.Drawing.Size(55, 23);
            this.tbAskSPB.TabIndex = 2;
            this.tbAskSPB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbAskUS
            // 
            this.tbAskUS.Location = new System.Drawing.Point(124, 39);
            this.tbAskUS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAskUS.Name = "tbAskUS";
            this.tbAskUS.Size = new System.Drawing.Size(55, 23);
            this.tbAskUS.TabIndex = 2;
            this.tbAskUS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Аск СПБ -";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(301, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "- Бид US";
            // 
            // tbBidSPB
            // 
            this.tbBidSPB.Location = new System.Drawing.Point(190, 39);
            this.tbBidSPB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbBidSPB.Name = "tbBidSPB";
            this.tbBidSPB.ReadOnly = true;
            this.tbBidSPB.Size = new System.Drawing.Size(55, 23);
            this.tbBidSPB.TabIndex = 2;
            this.tbBidSPB.Click += new System.EventHandler(this.tbBidSPB_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(14, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Аск US -";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(301, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "- Бид СПБ";
            // 
            // tbAskSPBvol
            // 
            this.tbAskSPBvol.Location = new System.Drawing.Point(76, 10);
            this.tbAskSPBvol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAskSPBvol.Name = "tbAskSPBvol";
            this.tbAskSPBvol.Size = new System.Drawing.Size(41, 23);
            this.tbAskSPBvol.TabIndex = 2;
            this.tbAskSPBvol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbAskUSvol
            // 
            this.tbAskUSvol.Location = new System.Drawing.Point(76, 39);
            this.tbAskUSvol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAskUSvol.Name = "tbAskUSvol";
            this.tbAskUSvol.Size = new System.Drawing.Size(41, 23);
            this.tbAskUSvol.TabIndex = 2;
            this.tbAskUSvol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbBidUSvol
            // 
            this.tbBidUSvol.Enabled = false;
            this.tbBidUSvol.Location = new System.Drawing.Point(252, 10);
            this.tbBidUSvol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbBidUSvol.Name = "tbBidUSvol";
            this.tbBidUSvol.Size = new System.Drawing.Size(41, 23);
            this.tbBidUSvol.TabIndex = 2;
            this.tbBidUSvol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbBidSPBvol
            // 
            this.tbBidSPBvol.Enabled = false;
            this.tbBidSPBvol.Location = new System.Drawing.Point(252, 39);
            this.tbBidSPBvol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbBidSPBvol.Name = "tbBidSPBvol";
            this.tbBidSPBvol.Size = new System.Drawing.Size(41, 23);
            this.tbBidSPBvol.TabIndex = 2;
            this.tbBidSPBvol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btReload
            // 
            this.btReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btReload.Location = new System.Drawing.Point(14, 82);
            this.btReload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 30);
            this.btReload.TabIndex = 1;
            this.btReload.Text = "reload";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // numPriceMost
            // 
            this.numPriceMost.DecimalPlaces = 2;
            this.numPriceMost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numPriceMost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPriceMost.Location = new System.Drawing.Point(12, 133);
            this.numPriceMost.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numPriceMost.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numPriceMost.Name = "numPriceMost";
            this.numPriceMost.Size = new System.Drawing.Size(118, 26);
            this.numPriceMost.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(8, 115);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Мост:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btCancelOrder
            // 
            this.btCancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCancelOrder.Location = new System.Drawing.Point(96, 82);
            this.btCancelOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btCancelOrder.Name = "btCancelOrder";
            this.btCancelOrder.Size = new System.Drawing.Size(33, 30);
            this.btCancelOrder.TabIndex = 4;
            this.btCancelOrder.Text = "X";
            this.btCancelOrder.UseVisualStyleBackColor = true;
            this.btCancelOrder.Click += new System.EventHandler(this.btCancelOrder_Click);
            // 
            // ArbCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 180);
            this.Controls.Add(this.btCancelOrder);
            this.Controls.Add(this.numPriceMost);
            this.Controls.Add(this.tbBidSPBvol);
            this.Controls.Add(this.tbAskUSvol);
            this.Controls.Add(this.tbBidUSvol);
            this.Controls.Add(this.tbAskSPBvol);
            this.Controls.Add(this.tbAskUS);
            this.Controls.Add(this.tbAskSPB);
            this.Controls.Add(this.tbBidUS);
            this.Controls.Add(this.tbBidSPB);
            this.Controls.Add(this.btGO2);
            this.Controls.Add(this.btReload);
            this.Controls.Add(this.btGO1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Location = new System.Drawing.Point(100, 100);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(403, 219);
            this.MinimumSize = new System.Drawing.Size(403, 219);
            this.Name = "ArbCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Arb.Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArbCheckForm_FormClosing);
            this.Load += new System.EventHandler(this.ArbCheckForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPriceMost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btGO1;
        private System.Windows.Forms.Button btGO2;
        private System.Windows.Forms.TextBox tbBidUS;
        private System.Windows.Forms.TextBox tbAskSPB;
        private System.Windows.Forms.TextBox tbAskUS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBidSPB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAskSPBvol;
        private System.Windows.Forms.TextBox tbAskUSvol;
        private System.Windows.Forms.TextBox tbBidUSvol;
        private System.Windows.Forms.TextBox tbBidSPBvol;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.NumericUpDown numPriceMost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btCancelOrder;
    }
}