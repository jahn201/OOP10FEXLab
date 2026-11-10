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
    public class QueueMonitorForm : Form
    {
        private static readonly Color BrandRed = Color.FromArgb(200, 16, 46);
        private static readonly Color ScreenBlue = Color.FromArgb(214, 234, 248);

        private FlowLayoutPanel preparingPanel;
        private FlowLayoutPanel servingPanel;

        /// <summary>
        /// Creates the claim monitor and starts listening to the order queue.
        /// </summary>
        public QueueMonitorForm()
        {
            BuildLayout();
            OrderQueue.QueueChanged += OrderQueue_QueueChanged;
            FormClosed += (s, e) => OrderQueue.QueueChanged -= OrderQueue_QueueChanged;
            RefreshQueue();
        }

        private void BuildLayout()
        {
            Text = "Claim Monitor";
            ClientSize = new Size(900, 600);
            StartPosition = FormStartPosition.Manual;
            Location = new Point(40, 40);
            BackColor = ScreenBlue;
            Font = new Font("Segoe UI", 10f);

            Label title = new Label
            {
                Text = "CLAIM MONITOR",
                Dock = DockStyle.Top,
                Height = 70,
                Font = new Font("Segoe UI", 26f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = BrandRed,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label hint = new Label
            {
                Text = "Staff: click a number under PREPARING when it is ready. Click a number under NOW SERVING once it is claimed.",
                Dock = DockStyle.Bottom,
                Height = 30,
                ForeColor = Color.DimGray,
                TextAlign = ContentAlignment.MiddleCenter
            };

            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(10)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60f));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            table.Controls.Add(CreateColumnHeader("PREPARING"), 0, 0);
            table.Controls.Add(CreateColumnHeader("NOW SERVING"), 1, 0);

            preparingPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
            servingPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
            table.Controls.Add(preparingPanel, 0, 1);
            table.Controls.Add(servingPanel, 1, 1);

            Controls.Add(table);
            Controls.Add(hint);
            Controls.Add(title);
        }

        private static Label CreateColumnHeader(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 20f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
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
