using System;
using System.Collections.Generic;

namespace OOP10FEXLab
{
    /// <summary>
    /// Shared order queue between the kiosk and the queue monitor.
    /// Orders move from Preparing to Now Serving, then leave the queue once claimed.
    /// </summary>
    public static class OrderQueue
    {
        private static readonly List<int> preparing = new List<int>();
        private static readonly List<int> nowServing = new List<int>();

        public static event EventHandler QueueChanged;

        public static IList<int> Preparing
        {
            get { return preparing.AsReadOnly(); }
        }

        public static IList<int> NowServing
        {
            get { return nowServing.AsReadOnly(); }
        }

        /// <summary>
        /// Adds a newly placed order to the Preparing list.
        /// </summary>
        public static void AddOrder(int orderNumber)
        {
            if (!preparing.Contains(orderNumber) && !nowServing.Contains(orderNumber))
            {
                preparing.Add(orderNumber);
                OnQueueChanged();
            }
        }

        /// <summary>
        /// Moves an order from Preparing to Now Serving.
        /// </summary>
        public static void MarkAsReady(int orderNumber)
        {
            if (preparing.Remove(orderNumber))
            {
                nowServing.Add(orderNumber);
                OnQueueChanged();
            }
        }

        /// <summary>
        /// Removes an order from Now Serving once the customer claims it.
        /// </summary>
        public static void MarkAsClaimed(int orderNumber)
        {
            if (nowServing.Remove(orderNumber))
            {
                OnQueueChanged();
            }
        }

        private static void OnQueueChanged()
        {
            EventHandler handler = QueueChanged;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }
    }
}
