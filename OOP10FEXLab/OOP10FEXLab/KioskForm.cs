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
    public partial class KioskForm : Form
    {
        private static readonly Color BrandRed = Color.FromArgb(200, 16, 46);
        private static readonly Color BrandYellow = Color.FromArgb(255, 199, 44);

        private readonly MealRepository mealRepository = new MealRepository();
        private readonly TransactionRepository transactionRepository = new TransactionRepository();
        private readonly List<OrderItem> cart = new List<OrderItem>();
        private List<Meal> meals = new List<Meal>();

        /// <summary>
        /// Creates the kiosk screen and loads the package meals.
        /// </summary>
        public KioskForm()
        {
            InitializeComponent();
            paymentCombo.SelectedIndex = 0;
            LoadMeals();
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
