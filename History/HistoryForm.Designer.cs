
namespace FishingSizes
{
    partial class HistoryForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbLoadInDB = new System.Windows.Forms.CheckBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGetHistory = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVolMax = new System.Windows.Forms.TextBox();
            this.tbTicker = new System.Windows.Forms.TextBox();
            this.tbVolMin = new System.Windows.Forms.TextBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbLoadInDB);
            this.splitContainer1.Panel1.Controls.Add(this.lbStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetHistory);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbVolMax);
            this.splitContainer1.Panel1.Controls.Add(this.tbTicker);
            this.splitContainer1.Panel1.Controls.Add(this.tbVolMin);
            this.splitContainer1.Panel1.Controls.Add(this.dtTo);
            this.splitContainer1.Panel1.Controls.Add(this.dtFrom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvHistory);
            this.splitContainer1.Size = new System.Drawing.Size(559, 519);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbLoadInDB
            // 
            this.cbLoadInDB.AutoSize = true;
            this.cbLoadInDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbLoadInDB.Location = new System.Drawing.Point(389, 48);
            this.cbLoadInDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbLoadInDB.Name = "cbLoadInDB";
            this.cbLoadInDB.Size = new System.Drawing.Size(84, 16);
            this.cbLoadInDB.TabIndex = 18;
            this.cbLoadInDB.Text = "загрузка в БД";
            this.cbLoadInDB.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.Black;
            this.lbStatus.Location = new System.Drawing.Point(289, 17);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(12, 15);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Статус:";
            // 
            // btnGetHistory
            // 
            this.btnGetHistory.Enabled = false;
            this.btnGetHistory.Location = new System.Drawing.Point(246, 73);
            this.btnGetHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGetHistory.Name = "btnGetHistory";
            this.btnGetHistory.Size = new System.Drawing.Size(293, 27);
            this.btnGetHistory.TabIndex = 4;
            this.btnGetHistory.Text = "Получить";
            this.btnGetHistory.UseVisualStyleBackColor = true;
            this.btnGetHistory.Click += new System.EventHandler(this.BtnGetHistory_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Объемы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Период:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тикер:";
            // 
            // tbVolMax
            // 
            this.tbVolMax.Location = new System.Drawing.Point(172, 75);
            this.tbVolMax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbVolMax.Name = "tbVolMax";
            this.tbVolMax.Size = new System.Drawing.Size(67, 23);
            this.tbVolMax.TabIndex = 2;
            this.tbVolMax.Text = "1000000";
            // 
            // tbTicker
            // 
            this.tbTicker.Location = new System.Drawing.Point(80, 14);
            this.tbTicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbTicker.Name = "tbTicker";
            this.tbTicker.Size = new System.Drawing.Size(135, 23);
            this.tbTicker.TabIndex = 2;
            this.tbTicker.Text = "TSLA";
            // 
            // tbVolMin
            // 
            this.tbVolMin.Location = new System.Drawing.Point(80, 75);
            this.tbVolMin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbVolMin.Name = "tbVolMin";
            this.tbVolMin.Size = new System.Drawing.Size(67, 23);
            this.tbVolMin.TabIndex = 2;
            this.tbVolMin.Text = "1";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTo.Location = new System.Drawing.Point(240, 44);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtTo.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtTo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(135, 23);
            this.dtTo.TabIndex = 1;
            this.dtTo.Value = new System.DateTime(2022, 11, 6, 0, 0, 0, 0);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtFrom.Location = new System.Drawing.Point(80, 44);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtFrom.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtFrom.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(135, 23);
            this.dtFrom.TabIndex = 0;
            this.dtFrom.Value = new System.DateTime(2022, 11, 6, 0, 0, 0, 0);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(0, 3);
            this.dgvHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowTemplate.ReadOnly = true;
            this.dgvHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.Size = new System.Drawing.Size(555, 403);
            this.dgvHistory.TabIndex = 2;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 519);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HistoryForm";
            this.Text = "History data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistoryForm_FormClosing);
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVolMax;
        private System.Windows.Forms.TextBox tbTicker;
        private System.Windows.Forms.TextBox tbVolMin;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetHistory;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbLoadInDB;
    }
}