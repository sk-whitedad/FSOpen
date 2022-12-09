
namespace FishingSizes
{
    partial class ConsoleForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleForm));
            this.btnSaveSett = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.tbSpradRab = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbFPrints = new System.Windows.Forms.CheckBox();
            this.chbSprad = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtClose = new System.Windows.Forms.DateTimePicker();
            this.dtOpen = new System.Windows.Forms.DateTimePicker();
            this.chbPair = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPriceMax = new System.Windows.Forms.TextBox();
            this.tbPriceMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chbMute = new System.Windows.Forms.CheckBox();
            this.tbPrintSizeMax = new System.Windows.Forms.TextBox();
            this.tbPrintSizeMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbExch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTickersList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbFishing = new System.Windows.Forms.GroupBox();
            this.cbCheck = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbProcent2 = new System.Windows.Forms.TextBox();
            this.btnGetPrintOM = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbProcent1 = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnTickerUnSuscr = new System.Windows.Forms.Button();
            this.btnTickerSuscr = new System.Windows.Forms.Button();
            this.tbTickerSubscr = new System.Windows.Forms.TextBox();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miStart = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSettings.SuspendLayout();
            this.gbFishing.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveSett
            // 
            this.btnSaveSett.Location = new System.Drawing.Point(637, 302);
            this.btnSaveSett.Name = "btnSaveSett";
            this.btnSaveSett.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSett.TabIndex = 0;
            this.btnSaveSett.Text = "Применить";
            this.btnSaveSett.UseVisualStyleBackColor = true;
            this.btnSaveSett.Click += new System.EventHandler(this.btnSaveSett_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.CausesValidation = false;
            this.gbSettings.Controls.Add(this.tbSpradRab);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.chbFPrints);
            this.gbSettings.Controls.Add(this.chbSprad);
            this.gbSettings.Controls.Add(this.label14);
            this.gbSettings.Controls.Add(this.label13);
            this.gbSettings.Controls.Add(this.dtClose);
            this.gbSettings.Controls.Add(this.dtOpen);
            this.gbSettings.Controls.Add(this.chbPair);
            this.gbSettings.Controls.Add(this.label10);
            this.gbSettings.Controls.Add(this.label9);
            this.gbSettings.Controls.Add(this.label8);
            this.gbSettings.Controls.Add(this.tbPriceMax);
            this.gbSettings.Controls.Add(this.tbPriceMin);
            this.gbSettings.Controls.Add(this.label7);
            this.gbSettings.Controls.Add(this.chbMute);
            this.gbSettings.Controls.Add(this.tbPrintSizeMax);
            this.gbSettings.Controls.Add(this.tbPrintSizeMin);
            this.gbSettings.Controls.Add(this.label6);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.tbExch);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.tbTickersList);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.btnSaveSett);
            this.gbSettings.Location = new System.Drawing.Point(18, 85);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(734, 334);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Настройки";
            // 
            // tbSpradRab
            // 
            this.tbSpradRab.Location = new System.Drawing.Point(142, 249);
            this.tbSpradRab.Name = "tbSpradRab";
            this.tbSpradRab.Size = new System.Drawing.Size(51, 20);
            this.tbSpradRab.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Рабочий спред не более:";
            // 
            // chbFPrints
            // 
            this.chbFPrints.AutoSize = true;
            this.chbFPrints.Location = new System.Drawing.Point(547, 16);
            this.chbFPrints.Name = "chbFPrints";
            this.chbFPrints.Size = new System.Drawing.Size(112, 17);
            this.chbFPrints.TabIndex = 26;
            this.chbFPrints.Text = "Только F принты";
            this.chbFPrints.UseVisualStyleBackColor = true;
            // 
            // chbSprad
            // 
            this.chbSprad.AutoSize = true;
            this.chbSprad.Location = new System.Drawing.Point(365, 16);
            this.chbSprad.Name = "chbSprad";
            this.chbSprad.Size = new System.Drawing.Size(176, 17);
            this.chbSprad.TabIndex = 25;
            this.chbSprad.Text = "Следить за сужением спреда";
            this.chbSprad.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 229);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Закрытие ОС:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Открытие ОС:";
            // 
            // dtClose
            // 
            this.dtClose.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtClose.Location = new System.Drawing.Point(96, 223);
            this.dtClose.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dtClose.Name = "dtClose";
            this.dtClose.Size = new System.Drawing.Size(86, 20);
            this.dtClose.TabIndex = 22;
            this.dtClose.Value = new System.DateTime(2022, 1, 5, 0, 0, 0, 0);
            // 
            // dtOpen
            // 
            this.dtOpen.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtOpen.Location = new System.Drawing.Point(98, 199);
            this.dtOpen.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dtOpen.Name = "dtOpen";
            this.dtOpen.Size = new System.Drawing.Size(84, 20);
            this.dtOpen.TabIndex = 21;
            this.dtOpen.Value = new System.DateTime(2022, 1, 5, 17, 30, 0, 0);
            // 
            // chbPair
            // 
            this.chbPair.AutoSize = true;
            this.chbPair.Location = new System.Drawing.Point(217, 16);
            this.chbPair.Name = "chbPair";
            this.chbPair.Size = new System.Drawing.Size(140, 17);
            this.chbPair.TabIndex = 20;
            this.chbPair.Text = "Принты по паре Q+QD";
            this.chbPair.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "(включительно)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "(включительно)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "до:";
            // 
            // tbPriceMax
            // 
            this.tbPriceMax.Location = new System.Drawing.Point(152, 155);
            this.tbPriceMax.Name = "tbPriceMax";
            this.tbPriceMax.Size = new System.Drawing.Size(48, 20);
            this.tbPriceMax.TabIndex = 16;
            // 
            // tbPriceMin
            // 
            this.tbPriceMin.Location = new System.Drawing.Point(70, 155);
            this.tbPriceMin.Name = "tbPriceMin";
            this.tbPriceMin.Size = new System.Drawing.Size(49, 20);
            this.tbPriceMin.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Цена от:";
            // 
            // chbMute
            // 
            this.chbMute.AutoSize = true;
            this.chbMute.Checked = true;
            this.chbMute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbMute.Location = new System.Drawing.Point(71, 16);
            this.chbMute.Name = "chbMute";
            this.chbMute.Size = new System.Drawing.Size(140, 17);
            this.chbMute.TabIndex = 13;
            this.chbMute.Text = "Звуковое оповещение";
            this.chbMute.UseVisualStyleBackColor = false;
            // 
            // tbPrintSizeMax
            // 
            this.tbPrintSizeMax.Location = new System.Drawing.Point(152, 124);
            this.tbPrintSizeMax.Name = "tbPrintSizeMax";
            this.tbPrintSizeMax.Size = new System.Drawing.Size(48, 20);
            this.tbPrintSizeMax.TabIndex = 12;
            // 
            // tbPrintSizeMin
            // 
            this.tbPrintSizeMin.Location = new System.Drawing.Point(70, 124);
            this.tbPrintSizeMin.Name = "tbPrintSizeMin";
            this.tbPrintSizeMin.Size = new System.Drawing.Size(49, 20);
            this.tbPrintSizeMin.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "до:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Принты от:";
            // 
            // tbExch
            // 
            this.tbExch.Location = new System.Drawing.Point(70, 90);
            this.tbExch.Name = "tbExch";
            this.tbExch.Size = new System.Drawing.Size(642, 20);
            this.tbExch.TabIndex = 8;
            this.tbExch.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Exchange:";
            // 
            // tbTickersList
            // 
            this.tbTickersList.Location = new System.Drawing.Point(70, 58);
            this.tbTickersList.Name = "tbTickersList";
            this.tbTickersList.Size = new System.Drawing.Size(642, 20);
            this.tbTickersList.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Список бумаг для сканирования:";
            // 
            // gbFishing
            // 
            this.gbFishing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFishing.Controls.Add(this.cbCheck);
            this.gbFishing.Controls.Add(this.label12);
            this.gbFishing.Controls.Add(this.tbProcent2);
            this.gbFishing.Controls.Add(this.btnGetPrintOM);
            this.gbFishing.Controls.Add(this.label11);
            this.gbFishing.Controls.Add(this.tbProcent1);
            this.gbFishing.Controls.Add(this.btnCheck);
            this.gbFishing.Controls.Add(this.btnTickerUnSuscr);
            this.gbFishing.Controls.Add(this.btnTickerSuscr);
            this.gbFishing.Controls.Add(this.tbTickerSubscr);
            this.gbFishing.Controls.Add(this.rtbConsole);
            this.gbFishing.Location = new System.Drawing.Point(12, 27);
            this.gbFishing.Name = "gbFishing";
            this.gbFishing.Size = new System.Drawing.Size(776, 398);
            this.gbFishing.TabIndex = 3;
            this.gbFishing.TabStop = false;
            this.gbFishing.Text = "FishingSizes";
            // 
            // cbCheck
            // 
            this.cbCheck.FormattingEnabled = true;
            this.cbCheck.Items.AddRange(new object[] {
            "Открытие ОС",
            "Арбитраж (Закрытие ОС)",
            "Проверка спреда ПМ",
            "Динамика за ОС (О-М)"});
            this.cbCheck.Location = new System.Drawing.Point(568, 19);
            this.cbCheck.Name = "cbCheck";
            this.cbCheck.Size = new System.Drawing.Size(121, 21);
            this.cbCheck.TabIndex = 10;
            this.cbCheck.Text = "Открытие ОС";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(482, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "-";
            // 
            // tbProcent2
            // 
            this.tbProcent2.Location = new System.Drawing.Point(495, 19);
            this.tbProcent2.Name = "tbProcent2";
            this.tbProcent2.Size = new System.Drawing.Size(33, 20);
            this.tbProcent2.TabIndex = 8;
            this.tbProcent2.Text = "2";
            // 
            // btnGetPrintOM
            // 
            this.btnGetPrintOM.Location = new System.Drawing.Point(360, 17);
            this.btnGetPrintOM.Name = "btnGetPrintOM";
            this.btnGetPrintOM.Size = new System.Drawing.Size(78, 23);
            this.btnGetPrintOM.TabIndex = 7;
            this.btnGetPrintOM.Text = "Get O/M/L1";
            this.btnGetPrintOM.UseVisualStyleBackColor = true;
            this.btnGetPrintOM.Click += new System.EventHandler(this.btnGetPrintOM_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(531, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "%";
            // 
            // tbProcent1
            // 
            this.tbProcent1.Location = new System.Drawing.Point(444, 19);
            this.tbProcent1.Name = "tbProcent1";
            this.tbProcent1.Size = new System.Drawing.Size(33, 20);
            this.tbProcent1.TabIndex = 5;
            this.tbProcent1.Text = "0.8";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(695, 18);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // btnTickerUnSuscr
            // 
            this.btnTickerUnSuscr.Enabled = false;
            this.btnTickerUnSuscr.Location = new System.Drawing.Point(139, 19);
            this.btnTickerUnSuscr.Name = "btnTickerUnSuscr";
            this.btnTickerUnSuscr.Size = new System.Drawing.Size(34, 22);
            this.btnTickerUnSuscr.TabIndex = 3;
            this.btnTickerUnSuscr.Text = "-";
            this.btnTickerUnSuscr.UseVisualStyleBackColor = true;
            this.btnTickerUnSuscr.Click += new System.EventHandler(this.BtnTickerUnSuscr_Click);
            // 
            // btnTickerSuscr
            // 
            this.btnTickerSuscr.Enabled = false;
            this.btnTickerSuscr.Location = new System.Drawing.Point(105, 19);
            this.btnTickerSuscr.Name = "btnTickerSuscr";
            this.btnTickerSuscr.Size = new System.Drawing.Size(34, 22);
            this.btnTickerSuscr.TabIndex = 2;
            this.btnTickerSuscr.Text = "+";
            this.btnTickerSuscr.UseVisualStyleBackColor = true;
            this.btnTickerSuscr.Click += new System.EventHandler(this.BtnTickerSuscr_Click);
            // 
            // tbTickerSubscr
            // 
            this.tbTickerSubscr.Location = new System.Drawing.Point(19, 21);
            this.tbTickerSubscr.Name = "tbTickerSubscr";
            this.tbTickerSubscr.Size = new System.Drawing.Size(80, 20);
            this.tbTickerSubscr.TabIndex = 1;
            // 
            // rtbConsole
            // 
            this.rtbConsole.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rtbConsole.ForeColor = System.Drawing.Color.LightGreen;
            this.rtbConsole.Location = new System.Drawing.Point(24, 58);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(764, 333);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            this.rtbConsole.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RtbConsole_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSettings,
            this.miStart});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miSettings
            // 
            this.miSettings.Name = "miSettings";
            this.miSettings.Size = new System.Drawing.Size(79, 20);
            this.miSettings.Text = "Настройки";
            this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
            // 
            // miStart
            // 
            this.miStart.Name = "miStart";
            this.miStart.Size = new System.Drawing.Size(50, 20);
            this.miStart.Text = "Старт";
            this.miStart.Click += new System.EventHandler(this.MiStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tStatus
            // 
            this.tStatus.Name = "tStatus";
            this.tStatus.Size = new System.Drawing.Size(118, 17);
            this.tStatus.Text = "toolStripStatusLabel1";
            // 
            // ConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbFishing);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConsoleForm";
            this.Text = "FishingSizes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Console_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbFishing.ResumeLayout(false);
            this.gbFishing.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSaveSett;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.GroupBox gbFishing;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripMenuItem miStart;
        private System.Windows.Forms.TextBox tbTickersList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tStatus;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.TextBox tbExch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrintSizeMax;
        private System.Windows.Forms.TextBox tbPrintSizeMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbMute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPriceMax;
        private System.Windows.Forms.TextBox tbPriceMin;
        private System.Windows.Forms.Button btnTickerUnSuscr;
        private System.Windows.Forms.Button btnTickerSuscr;
        private System.Windows.Forms.TextBox tbTickerSubscr;
        private System.Windows.Forms.CheckBox chbPair;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbProcent1;
        private System.Windows.Forms.Button btnGetPrintOM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbProcent2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtClose;
        private System.Windows.Forms.DateTimePicker dtOpen;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbCheck;
        private System.Windows.Forms.CheckBox chbSprad;
        private System.Windows.Forms.CheckBox chbFPrints;
        private System.Windows.Forms.TextBox tbSpradRab;
        private System.Windows.Forms.Label label1;
    }
}

