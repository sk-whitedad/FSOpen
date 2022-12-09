using System.Windows.Forms;
namespace FishingSizes
{
    partial class PortfolioForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortfolioForm));
            this.dgvPortfolio = new System.Windows.Forms.DataGridView();
            this.cmContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsCreateOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsActiveOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHistoryOrders = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortfolio)).BeginInit();
            this.cmContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPortfolio
            // 
            this.dgvPortfolio.AllowUserToAddRows = false;
            this.dgvPortfolio.AllowUserToDeleteRows = false;
            this.dgvPortfolio.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPortfolio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPortfolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPortfolio.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvPortfolio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPortfolio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvPortfolio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPortfolio.ContextMenuStrip = this.cmContextMenu;
            this.dgvPortfolio.Location = new System.Drawing.Point(1, 2);
            this.dgvPortfolio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPortfolio.Name = "dgvPortfolio";
            this.dgvPortfolio.ReadOnly = true;
            this.dgvPortfolio.RowHeadersWidth = 51;
            this.dgvPortfolio.RowTemplate.ReadOnly = true;
            this.dgvPortfolio.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPortfolio.Size = new System.Drawing.Size(614, 262);
            this.dgvPortfolio.TabIndex = 6;
            this.dgvPortfolio.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPortfolio_CellDoubleClick);
            this.dgvPortfolio.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPortfolio_CellMouseDown);
            // 
            // cmContextMenu
            // 
            this.cmContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCreateOrder,
            this.tsActiveOrders,
            this.tsHistoryOrders});
            this.cmContextMenu.Name = "cmContextMenu";
            this.cmContextMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // tsCreateOrder
            // 
            this.tsCreateOrder.Name = "tsCreateOrder";
            this.tsCreateOrder.Size = new System.Drawing.Size(180, 22);
            this.tsCreateOrder.Text = "Создать заявку";
            this.tsCreateOrder.Click += new System.EventHandler(this.tsCreateOrder_Click);
            // 
            // tsActiveOrders
            // 
            this.tsActiveOrders.Name = "tsActiveOrders";
            this.tsActiveOrders.Size = new System.Drawing.Size(180, 22);
            this.tsActiveOrders.Text = "Активные заявки";
            this.tsActiveOrders.Click += new System.EventHandler(this.tsActiveOrders_Click);
            // 
            // tsHistoryOrders
            // 
            this.tsHistoryOrders.Name = "tsHistoryOrders";
            this.tsHistoryOrders.Size = new System.Drawing.Size(180, 22);
            this.tsHistoryOrders.Text = "История операций";
            this.tsHistoryOrders.Click += new System.EventHandler(this.tsHistoryOrders_Click);
            // 
            // PortfolioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 262);
            this.Controls.Add(this.dgvPortfolio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PortfolioForm";
            this.Text = "Portfolio Tinkoff";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PortfolioForm_FormClosing);
            this.Load += new System.EventHandler(this.PortfolioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortfolio)).EndInit();
            this.cmContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button btGO1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPortfolio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPortfolio;
        private ContextMenuStrip cmContextMenu;
        private ToolStripMenuItem tsCreateOrder;
        private ToolStripMenuItem tsActiveOrders;
        private ToolStripMenuItem tsHistoryOrders;
    }
}