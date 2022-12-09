namespace FishingSizes
{
    partial class FormActivOrders
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
            this.flpListBox = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpListBox
            // 
            this.flpListBox.AutoScroll = true;
            this.flpListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpListBox.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpListBox.Location = new System.Drawing.Point(0, 0);
            this.flpListBox.Margin = new System.Windows.Forms.Padding(0);
            this.flpListBox.Name = "flpListBox";
            this.flpListBox.Size = new System.Drawing.Size(281, 401);
            this.flpListBox.TabIndex = 1;
            this.flpListBox.WrapContents = false;
            // 
            // FormActivOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 401);
            this.Controls.Add(this.flpListBox);
            this.Name = "FormActivOrders";
            this.Text = "Активные ордера";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormActivOrders_FormClosing);
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpListBox;
    }
}