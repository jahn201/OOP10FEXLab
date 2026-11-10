namespace OOP10FEXLab
{
    partial class QueueMonitorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.hintLabel = new System.Windows.Forms.Label();
            this.queueTable = new System.Windows.Forms.TableLayoutPanel();
            this.preparingHeaderLabel = new System.Windows.Forms.Label();
            this.servingHeaderLabel = new System.Windows.Forms.Label();
            this.preparingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.servingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.queueTable.SuspendLayout();
            this.SuspendLayout();

            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(200, 16, 46);
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(900, 70);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "CLAIM MONITOR";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.hintLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hintLabel.ForeColor = System.Drawing.Color.DimGray;
            this.hintLabel.Location = new System.Drawing.Point(0, 570);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(900, 30);
            this.hintLabel.TabIndex = 2;
            this.hintLabel.Text = "Staff: click a number under PREPARING when it is ready. Click a number under NOW SERVING once it is claimed.";
            this.hintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.queueTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.queueTable.ColumnCount = 2;
            this.queueTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.queueTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.queueTable.Controls.Add(this.preparingHeaderLabel, 0, 0);
            this.queueTable.Controls.Add(this.servingHeaderLabel, 1, 0);
            this.queueTable.Controls.Add(this.preparingPanel, 0, 1);
            this.queueTable.Controls.Add(this.servingPanel, 1, 1);
            this.queueTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queueTable.Location = new System.Drawing.Point(0, 70);
            this.queueTable.Name = "queueTable";
            this.queueTable.Padding = new System.Windows.Forms.Padding(10);
            this.queueTable.RowCount = 2;
            this.queueTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.queueTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.queueTable.Size = new System.Drawing.Size(900, 500);
            this.queueTable.TabIndex = 1;

            this.preparingHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preparingHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.preparingHeaderLabel.Name = "preparingHeaderLabel";
            this.preparingHeaderLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.preparingHeaderLabel.TabIndex = 0;
            this.preparingHeaderLabel.Text = "PREPARING";
            this.preparingHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.servingHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servingHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.servingHeaderLabel.Name = "servingHeaderLabel";
            this.servingHeaderLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.servingHeaderLabel.TabIndex = 1;
            this.servingHeaderLabel.Text = "NOW SERVING";
            this.servingHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.preparingPanel.AutoScroll = true;
            this.preparingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preparingPanel.Name = "preparingPanel";
            this.preparingPanel.TabIndex = 2;

            this.servingPanel.AutoScroll = true;
            this.servingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servingPanel.Name = "servingPanel";
            this.servingPanel.TabIndex = 3;

            this.BackColor = System.Drawing.Color.FromArgb(214, 234, 248);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.queueTable);
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Location = new System.Drawing.Point(40, 40);
            this.Name = "QueueMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Claim Monitor";
            this.queueTable.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.TableLayoutPanel queueTable;
        private System.Windows.Forms.Label preparingHeaderLabel;
        private System.Windows.Forms.Label servingHeaderLabel;
        private System.Windows.Forms.FlowLayoutPanel preparingPanel;
        private System.Windows.Forms.FlowLayoutPanel servingPanel;
    }
}
