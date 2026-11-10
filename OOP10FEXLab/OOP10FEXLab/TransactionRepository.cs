using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using MySql.Data.MySqlClient;

namespace OOP10FEXLab
{
    /// <summary>
    /// Saves kiosk orders to the transactions record: the database table transactions_tbl,
    /// plus a local copy in transactions.txt that also keeps the order numbers.
    /// </summary>
    public class TransactionRepository
    {
        private const int FirstOrderNumber = 1001;
        private readonly string filePath;

        private const string GroupMembers = "Members: Monsalud, SURNAME2, SURNAME3";

        /// <summary>
        /// Uses transactions.txt beside the running program for the local copy.
        /// </summary>
        public TransactionRepository()
            : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "transactions.txt"))
        {
        }

        /// <summary>
        /// Uses the given file for the local copy.
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
        /// Saves the order to transactions_tbl (one row per package ordered), then to the local file.
        /// Nothing is saved to the database unless every row succeeds.
        /// </summary>
        public void SaveOrder(Order order)
        {
            SaveToDatabase(order);
            SaveToFile(order);
        }

        private static void SaveToDatabase(Order order)
        {
            const string sql = "INSERT INTO transactions_tbl (package_name, transaction_date) VALUES (@pkg, @date)";

            DatabaseConnection database = DatabaseConnection.CreateDefault();
            using (MySqlConnection connection = database.CreateConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    foreach (OrderItem item in order.Items)
                    {
                        for (int i = 0; i < item.Quantity; i++)
                        {
                            using (MySqlCommand command = new MySqlCommand(sql, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@pkg", item.Meal.Name + "\n" + GroupMembers);
                                command.Parameters.AddWithValue("@date", order.OrderDate);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private void SaveToFile(Order order)
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
