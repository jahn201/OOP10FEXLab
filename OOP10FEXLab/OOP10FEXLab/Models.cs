using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP10FEXLab
{
    /// <summary>
    /// A package meal that can be ordered from the kiosk.
    /// </summary>
    public class Meal
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }

    /// <summary>
    /// One meal in the customer's cart together with how many were ordered.
    /// </summary>
    public class OrderItem
    {
        public Meal Meal { get; set; }
        public int Quantity { get; set; }

        public decimal Subtotal
        {
            get { return Meal.Price * Quantity; }
        }
    }

    /// <summary>
    /// A completed kiosk order that is saved to the transactions record.
    /// </summary>
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderType { get; set; }
        public string PaymentMethod { get; set; }
        public List<OrderItem> Items { get; set; }

        /// <summary>
        /// Creates an empty order.
        /// </summary>
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public decimal Total
        {
            get { return Items.Sum(i => i.Subtotal); }
        }
    }
}
