using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP10FEXLab
{
    /// <summary>
    /// Claim monitor that shows order numbers being prepared and order numbers now serving.
    /// Staff click a number in Preparing when it is ready, and in Now Serving once it is claimed.
    /// </summary>
    public partial class QueueMonitorForm : Form
    {
        private static readonly Color BrandRed = Color.FromArgb(200, 16, 46);

        /// <summary>
        /// Creates the claim monitor and starts listening to the order queue.
        /// </summary>
        public QueueMonitorForm()
        {
            InitializeComponent();
            OrderQueue.QueueChanged += OrderQueue_QueueChanged;
            FormClosed += (s, e) => OrderQueue.QueueChanged -= OrderQueue_QueueChanged;
            RefreshQueue();
        }

        private void OrderQueue_QueueChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                BeginInvoke(new Action(RefreshQueue));
            }
            else
            {
                RefreshQueue();
            }
        }

        private void RefreshQueue()
        {
            FillPanel(preparingPanel, OrderQueue.Preparing, Color.Black, OrderQueue.MarkAsReady);
            FillPanel(servingPanel, OrderQueue.NowServing, BrandRed, OrderQueue.MarkAsClaimed);
        }

        private static void FillPanel(FlowLayoutPanel panel, IList<int> orderNumbers, Color color, Action<int> onClick)
        {
            panel.SuspendLayout();
            while (panel.Controls.Count > 0)
            {
                panel.Controls[0].Dispose();
            }

            foreach (int orderNumber in orderNumbers)
            {
                int number = orderNumber;
                Label label = new Label
                {
                    Text = number.ToString(),
                    Font = new Font("Segoe UI", 28f, FontStyle.Bold),
                    ForeColor = color,
                    AutoSize = false,
                    Size = new Size(150, 60),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(6),
                    Cursor = Cursors.Hand
                };
                label.Click += (s, e) => onClick(number);
                panel.Controls.Add(label);
            }

            panel.ResumeLayout();
        }
    }
}
