namespace OOP10FEXLab
{
    partial class KioskForm
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.categoryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mealArea = new System.Windows.Forms.Panel();
            this.mealPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.categoryTitle = new System.Windows.Forms.Label();
            this.cartPanel = new System.Windows.Forms.Panel();
            this.cartList = new System.Windows.Forms.ListView();
            this.mealColumn = new System.Windows.Forms.ColumnHeader();
            this.qtyColumn = new System.Windows.Forms.ColumnHeader();
            this.subtotalColumn = new System.Windows.Forms.ColumnHeader();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.dineInRadio = new System.Windows.Forms.RadioButton();
            this.takeOutRadio = new System.Windows.Forms.RadioButton();
            this.paymentLabel = new System.Windows.Forms.Label();
            this.paymentCombo = new System.Windows.Forms.ComboBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.placeOrderButton = new System.Windows.Forms.Button();
            this.cartTitleLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.mealArea.SuspendLayout();
            this.cartPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();

            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(200, 16, 46);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1150, 70);
            this.headerPanel.TabIndex = 0;

            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(20, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(480, 37);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Sarap Express  |  Order and Pay Here";

            this.categoryPanel.AutoScroll = true;
            this.categoryPanel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.categoryPanel.Location = new System.Drawing.Point(0, 70);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Padding = new System.Windows.Forms.Padding(8);
            this.categoryPanel.Size = new System.Drawing.Size(180, 650);
            this.categoryPanel.TabIndex = 1;
            this.categoryPanel.WrapContents = false;

            this.mealArea.Controls.Add(this.mealPanel);
            this.mealArea.Controls.Add(this.categoryTitle);
            this.mealArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mealArea.Location = new System.Drawing.Point(180, 70);
            this.mealArea.Name = "mealArea";
            this.mealArea.Size = new System.Drawing.Size(620, 650);
            this.mealArea.TabIndex = 3;

            this.mealPanel.AutoScroll = true;
            this.mealPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mealPanel.Location = new System.Drawing.Point(0, 45);
            this.mealPanel.Name = "mealPanel";
            this.mealPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mealPanel.Size = new System.Drawing.Size(620, 605);
            this.mealPanel.TabIndex = 1;

            this.categoryTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.categoryTitle.Location = new System.Drawing.Point(0, 0);
            this.categoryTitle.Name = "categoryTitle";
            this.categoryTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.categoryTitle.Size = new System.Drawing.Size(620, 45);
            this.categoryTitle.TabIndex = 0;
            this.categoryTitle.Text = "Menu";
            this.categoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cartPanel.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.cartPanel.Controls.Add(this.cartList);
            this.cartPanel.Controls.Add(this.bottomPanel);
            this.cartPanel.Controls.Add(this.cartTitleLabel);
            this.cartPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.cartPanel.Location = new System.Drawing.Point(800, 70);
            this.cartPanel.Name = "cartPanel";
            this.cartPanel.Padding = new System.Windows.Forms.Padding(10);
            this.cartPanel.Size = new System.Drawing.Size(350, 650);
            this.cartPanel.TabIndex = 2;

            this.cartList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.mealColumn,
                this.qtyColumn,
                this.subtotalColumn});
            this.cartList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartList.FullRowSelect = true;
            this.cartList.HideSelection = false;
            this.cartList.Location = new System.Drawing.Point(10, 50);
            this.cartList.MultiSelect = false;
            this.cartList.Name = "cartList";
            this.cartList.Size = new System.Drawing.Size(330, 350);
            this.cartList.TabIndex = 1;
            this.cartList.UseCompatibleStateImageBehavior = false;
            this.cartList.View = System.Windows.Forms.View.Details;

            this.mealColumn.Text = "Meal";
            this.mealColumn.Width = 170;

            this.qtyColumn.Text = "Qty";
            this.qtyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qtyColumn.Width = 45;

            this.subtotalColumn.Text = "Subtotal";
            this.subtotalColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subtotalColumn.Width = 90;

            this.bottomPanel.Controls.Add(this.dineInRadio);
            this.bottomPanel.Controls.Add(this.takeOutRadio);
            this.bottomPanel.Controls.Add(this.paymentLabel);
            this.bottomPanel.Controls.Add(this.paymentCombo);
            this.bottomPanel.Controls.Add(this.totalLabel);
            this.bottomPanel.Controls.Add(this.removeButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.placeOrderButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(10, 400);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(330, 240);
            this.bottomPanel.TabIndex = 2;

            this.dineInRadio.AutoSize = true;
            this.dineInRadio.Checked = true;
            this.dineInRadio.Location = new System.Drawing.Point(5, 10);
            this.dineInRadio.Name = "dineInRadio";
            this.dineInRadio.Size = new System.Drawing.Size(75, 23);
            this.dineInRadio.TabIndex = 0;
            this.dineInRadio.TabStop = true;
            this.dineInRadio.Text = "Dine In";

            this.takeOutRadio.AutoSize = true;
            this.takeOutRadio.Location = new System.Drawing.Point(120, 10);
            this.takeOutRadio.Name = "takeOutRadio";
            this.takeOutRadio.Size = new System.Drawing.Size(85, 23);
            this.takeOutRadio.TabIndex = 1;
            this.takeOutRadio.Text = "Take Out";

            this.paymentLabel.AutoSize = true;
            this.paymentLabel.Location = new System.Drawing.Point(5, 48);
            this.paymentLabel.Name = "paymentLabel";
            this.paymentLabel.Size = new System.Drawing.Size(70, 19);
            this.paymentLabel.TabIndex = 2;
            this.paymentLabel.Text = "Payment:";

            this.paymentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentCombo.Items.AddRange(new object[] {
                "Cash (pay at counter)",
                "Card",
                "E-Wallet"});
            this.paymentCombo.Location = new System.Drawing.Point(85, 45);
            this.paymentCombo.Name = "paymentCombo";
            this.paymentCombo.Size = new System.Drawing.Size(235, 25);
            this.paymentCombo.TabIndex = 3;

            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.totalLabel.ForeColor = System.Drawing.Color.FromArgb(200, 16, 46);
            this.totalLabel.Location = new System.Drawing.Point(5, 85);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(150, 32);
            this.totalLabel.TabIndex = 4;
            this.totalLabel.Text = "Total: ₱0.00";

            this.removeButton.BackColor = System.Drawing.Color.Gainsboro;
            this.removeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeButton.FlatAppearance.BorderSize = 0;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Location = new System.Drawing.Point(5, 135);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(155, 40);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove Item";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);

            this.cancelButton.BackColor = System.Drawing.Color.Gainsboro;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(165, 135);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(155, 40);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel Order";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);

            this.placeOrderButton.BackColor = System.Drawing.Color.FromArgb(200, 16, 46);
            this.placeOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.placeOrderButton.FlatAppearance.BorderSize = 0;
            this.placeOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.placeOrderButton.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.placeOrderButton.ForeColor = System.Drawing.Color.White;
            this.placeOrderButton.Location = new System.Drawing.Point(5, 185);
            this.placeOrderButton.Name = "placeOrderButton";
            this.placeOrderButton.Size = new System.Drawing.Size(315, 48);
            this.placeOrderButton.TabIndex = 7;
            this.placeOrderButton.Text = "Place Order";
            this.placeOrderButton.UseVisualStyleBackColor = false;
            this.placeOrderButton.Click += new System.EventHandler(this.PlaceOrderButton_Click);

            this.cartTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cartTitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.cartTitleLabel.Location = new System.Drawing.Point(10, 10);
            this.cartTitleLabel.Name = "cartTitleLabel";
            this.cartTitleLabel.Size = new System.Drawing.Size(330, 40);
            this.cartTitleLabel.TabIndex = 0;
            this.cartTitleLabel.Text = "My Order";

            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1150, 720);
            this.Controls.Add(this.mealArea);
            this.Controls.Add(this.categoryPanel);
            this.Controls.Add(this.cartPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "KioskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiosk - Order and Pay Here";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mealArea.ResumeLayout(false);
            this.cartPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.FlowLayoutPanel categoryPanel;
        private System.Windows.Forms.Panel mealArea;
        private System.Windows.Forms.FlowLayoutPanel mealPanel;
        private System.Windows.Forms.Label categoryTitle;
        private System.Windows.Forms.Panel cartPanel;
        private System.Windows.Forms.ListView cartList;
        private System.Windows.Forms.ColumnHeader mealColumn;
        private System.Windows.Forms.ColumnHeader qtyColumn;
        private System.Windows.Forms.ColumnHeader subtotalColumn;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.RadioButton dineInRadio;
        private System.Windows.Forms.RadioButton takeOutRadio;
        private System.Windows.Forms.Label paymentLabel;
        private System.Windows.Forms.ComboBox paymentCombo;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button placeOrderButton;
        private System.Windows.Forms.Label cartTitleLabel;
    }
}
