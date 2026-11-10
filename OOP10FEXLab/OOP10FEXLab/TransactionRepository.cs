using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace OOP10FEXLab
{
    /// <summary>
    /// Saves kiosk orders to the transactions record (transactions.txt), one line per ordered meal.
    /// Format per line: OrderNo|DateTime|OrderType|Payment|MealId|MealName|Qty|Price|Subtotal|OrderTotal
    /// </summary>
    public class TransactionRepository
    {
        private const int FirstOrderNumber = 1001;
        private readonly string filePath;

        /// <summary>
        /// Uses transactions.txt beside the running program.
        /// </summary>
        public TransactionRepository()
            : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "transactions.txt"))
        {
        }

        /// <summary>
        /// Uses the given transactions file.
        /// </summary>
        public TransactionRepository(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Returns the next order number, continuing from the last saved transaction.
        /// </summary>
        public int GetNextOrderNumber()
        {
            int last = FirstOrderNumber - 1;

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    int number;
                    string[] parts = line.Split('|');
                    if (int.TryParse(parts[0], out number) && number > last)
                    {
                        last = number;
                    }
                }
            }

            return last + 1;
        }

        /// <summary>
        /// Appends every item of the order to the transactions record.
        /// </summary>
        public void SaveOrder(Order order)
        {
            List<string> lines = new List<string>();

            if (!File.Exists(filePath))
            {
                lines.Add("# OrderNo|DateTime|OrderType|Payment|MealId|MealName|Qty|Price|Subtotal|OrderTotal");
            }

            foreach (OrderItem item in order.Items)
            {
                lines.Add(string.Join("|",
                    order.OrderNumber,
                    order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    order.OrderType,
                    order.PaymentMethod,
                    item.Meal.Id,
                    item.Meal.Name,
                    item.Quantity,
                    item.Meal.Price.ToString("0.00", CultureInfo.InvariantCulture),
                    item.Subtotal.ToString("0.00", CultureInfo.InvariantCulture),
                    order.Total.ToString("0.00", CultureInfo.InvariantCulture)));
            }

            File.AppendAllLines(filePath, lines);
        }
    }
}
