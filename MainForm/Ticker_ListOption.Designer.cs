namespace FishingSizes
{
    partial class Ticker_ListOption
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbTickerAdd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.lbTickerList = new System.Windows.Forms.ListBox();
            this.btSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbTickerAdd);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btRemove);
            this.groupBox3.Controls.Add(this.btAdd);
            this.groupBox3.Controls.Add(this.lbTickerList);
            this.groupBox3.Location = new System.Drawing.Point(20, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 177);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Список избранных тикеров";
            // 
            // tbTickerAdd
            // 
            this.tbTickerAdd.Location = new System.Drawing.Point(21, 21);
            this.tbTickerAdd.Name = "tbTickerAdd";
            this.tbTickerAdd.Size = new System.Drawing.Size(125, 20);
            this.tbTickerAdd.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(84, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "all clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(119, 47);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(27, 27);
            this.btRemove.TabIndex = 17;
            this.btRemove.Text = "-";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(86, 47);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(27, 27);
            this.btAdd.TabIndex = 17;
            this.btAdd.Text = "+";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // lbTickerList
            // 
            this.lbTickerList.FormattingEnabled = true;
            this.lbTickerList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTickerList.Location = new System.Drawing.Point(19, 47);
            this.lbTickerList.Name = "lbTickerList";
            this.lbTickerList.Size = new System.Drawing.Size(59, 121);
            this.lbTickerList.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(20, 209);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(78, 27);
            this.btSave.TabIndex = 17;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 27);
            this.button2.TabIndex = 17;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ticker_ListOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.groupBox3);
            this.Name = "Ticker_ListOption";
            this.Size = new System.Drawing.Size(416, 302);
            this.Load += new System.EventHandler(this.Ticker_ListOption_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btAdd;
        public System.Windows.Forms.ListBox lbTickerList;
        private System.Windows.Forms.TextBox tbTickerAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
