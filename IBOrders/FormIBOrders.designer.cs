
namespace FishingSizes
{
    partial class FormIBOrders
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBUY = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTicker = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbExchange = new System.Windows.Forms.ComboBox();
            this.btnSELL = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnCancelLast = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBUY
            // 
            this.btnBUY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBUY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBUY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBUY.Location = new System.Drawing.Point(207, 132);
            this.btnBUY.Margin = new System.Windows.Forms.Padding(0);
            this.btnBUY.Name = "btnBUY";
            this.btnBUY.Size = new System.Drawing.Size(69, 33);
            this.btnBUY.TabIndex = 0;
            this.btnBUY.Tag = "BUY";
            this.btnBUY.Text = "BUY";
            this.btnBUY.UseVisualStyleBackColor = false;
            this.btnBUY.Click += new System.EventHandler(this.placeOrderButtonHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тикер:";
            // 
            // tbTicker
            // 
            this.tbTicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tbTicker.Location = new System.Drawing.Point(259, 18);
            this.tbTicker.Name = "tbTicker";
            this.tbTicker.Size = new System.Drawing.Size(61, 23);
            this.tbTicker.TabIndex = 2;
            this.tbTicker.Text = "COTY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Цена:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Кол-во:";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tbPrice.Location = new System.Drawing.Point(259, 46);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(61, 23);
            this.tbPrice.TabIndex = 2;
            this.tbPrice.Text = "5.00";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tbQuantity.Location = new System.Drawing.Point(259, 74);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(61, 23);
            this.tbQuantity.TabIndex = 2;
            this.tbQuantity.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Биржа:";
            // 
            // cbExchange
            // 
            this.cbExchange.AutoCompleteCustomSource.AddRange(new string[] {
            "ISLAND",
            "ARCA",
            "SMART"});
            this.cbExchange.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbExchange.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbExchange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbExchange.FormattingEnabled = true;
            this.cbExchange.Items.AddRange(new object[] {
            "ISLAND",
            "ARCA",
            "SMART"});
            this.cbExchange.Location = new System.Drawing.Point(255, 103);
            this.cbExchange.Name = "cbExchange";
            this.cbExchange.Size = new System.Drawing.Size(65, 21);
            this.cbExchange.TabIndex = 3;
            this.cbExchange.Text = "ISLAND";
            // 
            // btnSELL
            // 
            this.btnSELL.BackColor = System.Drawing.Color.Red;
            this.btnSELL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSELL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSELL.Location = new System.Drawing.Point(278, 132);
            this.btnSELL.Margin = new System.Windows.Forms.Padding(0);
            this.btnSELL.Name = "btnSELL";
            this.btnSELL.Size = new System.Drawing.Size(68, 33);
            this.btnSELL.TabIndex = 0;
            this.btnSELL.Tag = "SELL";
            this.btnSELL.Text = "SELL";
            this.btnSELL.UseVisualStyleBackColor = false;
            this.btnSELL.Click += new System.EventHandler(this.placeOrderButtonHandler);
            // 
            // btnCancelLast
            // 
            this.btnCancelLast.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelLast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelLast.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelLast.Location = new System.Drawing.Point(207, 168);
            this.btnCancelLast.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancelLast.Name = "btnCancelLast";
            this.btnCancelLast.Size = new System.Drawing.Size(138, 23);
            this.btnCancelLast.TabIndex = 0;
            this.btnCancelLast.Text = "CANCEL LAST";
            this.btnCancelLast.UseVisualStyleBackColor = false;
            this.btnCancelLast.Click += new System.EventHandler(this.button_CancelLast);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.BackColor = System.Drawing.Color.DarkGray;
            this.btnCancelAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelAll.Location = new System.Drawing.Point(207, 195);
            this.btnCancelAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(138, 23);
            this.btnCancelAll.TabIndex = 0;
            this.btnCancelAll.Text = "CANCEL ALL";
            this.btnCancelAll.UseVisualStyleBackColor = false;
            this.btnCancelAll.Click += new System.EventHandler(this.button_CancelAll);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(255, 237);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(37, 13);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "Status";
            this.lbStatus.Visible = false;
            // 
            // FormIBOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 279);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.cbExchange);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnCancelLast);
            this.Controls.Add(this.btnSELL);
            this.Controls.Add(this.btnBUY);
            this.Name = "FormIBOrders";
            this.Text = "IB Orders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBUY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbExchange;
        private System.Windows.Forms.Button btnSELL;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnCancelLast;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Label lbStatus;
    }
}

