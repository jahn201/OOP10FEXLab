using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    /// <summary>
    /// Self-service ordering kiosk where customers pick package meals, review their order and place it.
    /// </summary>
    public class KioskForm : Form
    {
        private static readonly Color BrandRed = Color.FromArgb(200, 16, 46);
        private static readonly Color BrandYellow = Color.FromArgb(255, 199, 44);

        private readonly MealRepository mealRepository = new MealRepository();
        private readonly TransactionRepository transactionRepository = new TransactionRepository();
        private readonly List<OrderItem> cart = new List<OrderItem>();
        private List<Meal> meals = new List<Meal>();

        private FlowLayoutPanel categoryPanel;
        private FlowLayoutPanel mealPanel;
        private Label categoryTitle;
        private ListView cartList;
        private Label totalLabel;
        private RadioButton dineInRadio;
        private RadioButton takeOutRadio;
        private ComboBox paymentCombo;

        /// <summary>
        /// Creates the kiosk screen and loads the package meals.
        /// </summary>
        public KioskForm()
        {
            BuildLayout();
            LoadMeals();
        }

        private void BuildLayout()
        {
            Text = "Kiosk - Order and Pay Here";
            ClientSize = new Size(1150, 720);
            MinimumSize = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10f);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = BrandRed };
            header.Controls.Add(new Label
            {
                Text = "Sarap Express  |  Order and Pay Here",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            });

            categoryPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                Width = 180,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(8)
            };

            Panel mealArea = new Panel { Dock = DockStyle.Fill };
            mealPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };
            categoryTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 45,
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0)
            };
            mealArea.Controls.Add(mealPanel);
            mealArea.Controls.Add(categoryTitle);

            Panel cartPanel = BuildCartPanel();

            Controls.Add(mealArea);
            Controls.Add(categoryPanel);
            Controls.Add(cartPanel);
            Controls.Add(header);
        }

        private Panel BuildCartPanel()
        {
            Panel cartPanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 350,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            Label cartTitle = new Label
            {
                Text = "My Order",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 16f, FontStyle.Bold)
            };

            cartList = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false,
                HideSelection = false
            };
            cartList.Columns.Add("Meal", 170);
            cartList.Columns.Add("Qty", 45, HorizontalAlignment.Center);
            cartList.Columns.Add("Subtotal", 90, HorizontalAlignment.Right);

            Panel bottom = new Panel { Dock = DockStyle.Bottom, Height = 240 };

            dineInRadio = new RadioButton { Text = "Dine In", Checked = true, Location = new Point(5, 10), AutoSize = true };
            takeOutRadio = new RadioButton { Text = "Take Out", Location = new Point(120, 10), AutoSize = true };

            Label paymentLabel = new Label { Text = "Payment:", Location = new Point(5, 48), AutoSize = true };
            paymentCombo = new ComboBox { Location = new Point(85, 45), Width = 235, DropDownStyle = ComboBoxStyle.DropDownList };
            paymentCombo.Items.AddRange(new object[] { "Cash (pay at counter)", "Card", "E-Wallet" });
            paymentCombo.SelectedIndex = 0;

            totalLabel = new Label
            {
                Text = "Total: ₱0.00",
                Location = new Point(5, 85),
                AutoSize = true,
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = BrandRed
            };

            Button removeButton = CreateButton("Remove Item", new Size(155, 40), Color.Gainsboro, Color.Black);
            removeButton.Location = new Point(5, 135);
            removeButton.Click += RemoveButton_Click;

            Button cancelButton = CreateButton("Cancel Order", new Size(155, 40), Color.Gainsboro, Color.Black);
            cancelButton.Location = new Point(165, 135);
            cancelButton.Click += CancelButton_Click;

            Button placeOrderButton = CreateButton("Place Order", new Size(315, 48), BrandRed, Color.White);
            placeOrderButton.Location = new Point(5, 185);
            placeOrderButton.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            placeOrderButton.Click += PlaceOrderButton_Click;

            bottom.Controls.AddRange(new Control[]
            {
                dineInRadio, takeOutRadio, paymentLabel, paymentCombo,
                totalLabel, removeButton, cancelButton, placeOrderButton
            });

            cartPanel.Controls.Add(cartList);
            cartPanel.Controls.Add(bottom);
            cartPanel.Controls.Add(cartTitle);
            return cartPanel;
        }

        private static Button CreateButton(string text, Size size, Color backColor, Color foreColor)
        {
            Button button = new Button
            {
                Text = text,
                Size = size,
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private void LoadMeals()
        {
            try
            {
                meals = mealRepository.GetAllMeals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the meals: " + ex.Message, "Kiosk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            categoryPanel.Controls.Clear();
            foreach (string category in meals.Select(m => m.Category).Distinct())
            {
                Button button = CreateButton(category, new Size(155, 55), Color.White, Color.Black);
                button.Tag = category;
                button.Click += (s, e) => ShowCategory((string)((Button)s).Tag);
                categoryPanel.Controls.Add(button);
            }

            if (meals.Count > 0)
            {
                ShowCategory(meals[0].Category);
            }
        }

        private void ShowCategory(string category)
        {
            categoryTitle.Text = category;

            foreach (Control control in categoryPanel.Controls)
            {
                control.BackColor = (string)control.Tag == category ? BrandYellow : Color.White;
            }

            mealPanel.SuspendLayout();
            while (mealPanel.Controls.Count > 0)
            {
                mealPanel.Controls[0].Dispose();
            }

            foreach (Meal meal in meals.Where(m => m.Category == category))
            {
                mealPanel.Controls.Add(CreateMealCard(meal));
            }
            mealPanel.ResumeLayout();
        }

        private Button CreateMealCard(Meal meal)
        {
            Button card = CreateButton(meal.Name + Environment.NewLine + "₱" + meal.Price.ToString("N2"),
                new Size(190, 170), Color.White, Color.Black);
            card.FlatAppearance.BorderSize = 1;
            card.FlatAppearance.BorderColor = Color.LightGray;
            card.Margin = new Padding(8);

            Image image = LoadMealImage(meal.ImagePath);
            if (image != null)
            {
                card.Image = image;
                card.ImageAlign = ContentAlignment.TopCenter;
                card.TextAlign = ContentAlignment.BottomCenter;
                card.TextImageRelation = TextImageRelation.ImageAboveText;
            }

            card.Click += (s, e) => AddToCart(meal);
            return card;
        }

        private static Image LoadMealImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return null;
            }

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
            if (!File.Exists(fullPath))
            {
                return null;
            }

            try
            {
                using (Image original = Image.FromFile(fullPath))
                {
                    return new Bitmap(original, new Size(140, 95));
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void AddToCart(Meal meal)
        {
            OrderItem existing = cart.FirstOrDefault(i => i.Meal.Id == meal.Id);
            if (existing == null)
            {
                cart.Add(new OrderItem { Meal = meal, Quantity = 1 });
            }
            else
            {
                existing.Quantity++;
            }

            RefreshCart();
        }

        private void RefreshCart()
        {
            cartList.Items.Clear();
            foreach (OrderItem item in cart)
            {
                ListViewItem row = new ListViewItem(new[]
                {
                    item.Meal.Name,
                    item.Quantity.ToString(),
                    item.Subtotal.ToString("N2")
                });
                row.Tag = item;
                cartList.Items.Add(row);
            }

            totalLabel.Text = "Total: ₱" + cart.Sum(i => i.Subtotal).ToString("N2");
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (cartList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a meal in your order first.", "Kiosk", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrderItem item = (OrderItem)cartList.SelectedItems[0].Tag;
            item.Quantity--;
            if (item.Quantity <= 0)
            {
                cart.Remove(item);
            }

            RefreshCart();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("Cancel this order?", "Kiosk", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cart.Clear();
                RefreshCart();
            }
        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Please add at least one meal to your order.", "Kiosk", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal total = cart.Sum(i => i.Subtotal);
            if (MessageBox.Show("Place this order for ₱" + total.ToString("N2") + "?", "Confirm Order",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            Order order = new Order
            {
                OrderNumber = transactionRepository.GetNextOrderNumber(),
                OrderDate = DateTime.Now,
                OrderType = dineInRadio.Checked ? "Dine In" : "Take Out",
                PaymentMethod = paymentCombo.Text,
                Items = new List<OrderItem>(cart)
            };

            try
            {
                transactionRepository.SaveOrder(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the transaction: " + ex.Message, "Kiosk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderQueue.AddOrder(order.OrderNumber);

            MessageBox.Show("Thank you! Your order number is " + order.OrderNumber + "." + Environment.NewLine +
                "Please watch the claim monitor for your number.", "Order Placed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            cart.Clear();
            RefreshCart();
            dineInRadio.Checked = true;
            paymentCombo.SelectedIndex = 0;
        }
    }
}
