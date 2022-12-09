namespace FishingSizes
{
    partial class Settings_Control
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
            this.tbSecret = new System.Windows.Forms.TextBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSett = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAlpacaUses = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTinkoffUses = new System.Windows.Forms.CheckBox();
            this.tbTokenTinkoff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbAlorUses = new System.Windows.Forms.CheckBox();
            this.tbTokenAlor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbIB = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSecret
            // 
            this.tbSecret.Location = new System.Drawing.Point(92, 112);
            this.tbSecret.Margin = new System.Windows.Forms.Padding(4);
            this.tbSecret.Name = "tbSecret";
            this.tbSecret.Size = new System.Drawing.Size(309, 23);
            this.tbSecret.TabIndex = 8;
            this.tbSecret.UseSystemPasswordChar = true;
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(92, 71);
            this.tbKey.Margin = new System.Windows.Forms.Padding(4);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(309, 23);
            this.tbKey.TabIndex = 7;
            this.tbKey.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Secret:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key:";
            // 
            // btnSaveSett
            // 
            this.btnSaveSett.Location = new System.Drawing.Point(315, 458);
            this.btnSaveSett.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveSett.Name = "btnSaveSett";
            this.btnSaveSett.Size = new System.Drawing.Size(88, 23);
            this.btnSaveSett.TabIndex = 9;
            this.btnSaveSett.Text = "Применить";
            this.btnSaveSett.UseVisualStyleBackColor = true;
            this.btnSaveSett.Click += new System.EventHandler(this.btnSaveSett_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAlpacaUses);
            this.groupBox1.Location = new System.Drawing.Point(10, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(405, 138);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки Alpaca";
            // 
            // cbAlpacaUses
            // 
            this.cbAlpacaUses.AutoSize = true;
            this.cbAlpacaUses.Location = new System.Drawing.Point(83, 106);
            this.cbAlpacaUses.Margin = new System.Windows.Forms.Padding(4);
            this.cbAlpacaUses.Name = "cbAlpacaUses";
            this.cbAlpacaUses.Size = new System.Drawing.Size(158, 19);
            this.cbAlpacaUses.TabIndex = 12;
            this.cbAlpacaUses.Text = "Не использовать Alpaca";
            this.cbAlpacaUses.UseVisualStyleBackColor = true;
            this.cbAlpacaUses.CheckedChanged += new System.EventHandler(this.cbAlpacaUses_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTinkoffUses);
            this.groupBox2.Controls.Add(this.tbTokenTinkoff);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(10, 194);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(405, 91);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки Tinkoff";
            // 
            // cbTinkoffUses
            // 
            this.cbTinkoffUses.AutoSize = true;
            this.cbTinkoffUses.Location = new System.Drawing.Point(78, 63);
            this.cbTinkoffUses.Margin = new System.Windows.Forms.Padding(4);
            this.cbTinkoffUses.Name = "cbTinkoffUses";
            this.cbTinkoffUses.Size = new System.Drawing.Size(179, 19);
            this.cbTinkoffUses.TabIndex = 13;
            this.cbTinkoffUses.Text = "Не использовать Тинькофф";
            this.cbTinkoffUses.UseVisualStyleBackColor = true;
            this.cbTinkoffUses.CheckedChanged += new System.EventHandler(this.cbTinkoffUses_CheckedChanged);
            // 
            // tbTokenTinkoff
            // 
            this.tbTokenTinkoff.Location = new System.Drawing.Point(78, 32);
            this.tbTokenTinkoff.Margin = new System.Windows.Forms.Padding(4);
            this.tbTokenTinkoff.Name = "tbTokenTinkoff";
            this.tbTokenTinkoff.Size = new System.Drawing.Size(315, 23);
            this.tbTokenTinkoff.TabIndex = 11;
            this.tbTokenTinkoff.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Token:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 458);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbAlorUses);
            this.groupBox3.Controls.Add(this.tbTokenAlor);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(10, 303);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(405, 86);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройки Alor";
            // 
            // cbAlorUses
            // 
            this.cbAlorUses.AutoSize = true;
            this.cbAlorUses.Location = new System.Drawing.Point(78, 63);
            this.cbAlorUses.Margin = new System.Windows.Forms.Padding(4);
            this.cbAlorUses.Name = "cbAlorUses";
            this.cbAlorUses.Size = new System.Drawing.Size(151, 19);
            this.cbAlorUses.TabIndex = 13;
            this.cbAlorUses.Text = "Не использовать Алор";
            this.cbAlorUses.UseVisualStyleBackColor = true;
            this.cbAlorUses.CheckedChanged += new System.EventHandler(this.cbAlorUses_CheckedChanged);
            // 
            // tbTokenAlor
            // 
            this.tbTokenAlor.Location = new System.Drawing.Point(78, 32);
            this.tbTokenAlor.Margin = new System.Windows.Forms.Padding(4);
            this.tbTokenAlor.Name = "tbTokenAlor";
            this.tbTokenAlor.Size = new System.Drawing.Size(315, 23);
            this.tbTokenAlor.TabIndex = 11;
            this.tbTokenAlor.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Token:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbIB);
            this.groupBox4.Location = new System.Drawing.Point(10, 397);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(405, 53);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Настройки Interactive Brockers";
            // 
            // cbIB
            // 
            this.cbIB.AutoSize = true;
            this.cbIB.Location = new System.Drawing.Point(79, 24);
            this.cbIB.Margin = new System.Windows.Forms.Padding(4);
            this.cbIB.Name = "cbIB";
            this.cbIB.Size = new System.Drawing.Size(225, 19);
            this.cbIB.TabIndex = 13;
            this.cbIB.Text = "Не использовать Interactive Brockers";
            this.cbIB.UseVisualStyleBackColor = true;
            // 
            // Settings_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSaveSett);
            this.Controls.Add(this.tbSecret);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings_Control";
            this.Padding = new System.Windows.Forms.Padding(11);
            this.Size = new System.Drawing.Size(466, 519);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbSecret;
        public System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSett;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tbTokenTinkoff;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox cbAlpacaUses;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox tbTokenAlor;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox cbAlorUses;
        public System.Windows.Forms.CheckBox cbTinkoffUses;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.CheckBox cbIB;
    }
}
