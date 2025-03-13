

using System.Drawing;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom button control that displays a notification count.
    /// </summary>
    public partial class CustomNotificationsButton : Button
    {
        private int notificationCount = 0;

        /// <summary>
        /// Gets or sets the notification count displayed on the button.
        /// </summary>
        public int NotificationCount
        {
            get => notificationCount;
            set
            {
                notificationCount = value;
                Invalidate(); // Redraw the control when the notification count changes
            }
        }

        /// <summary>
        /// Paints the button control and draws the notification count if greater than zero.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the notification count
            if (notificationCount > 0)
            {
                using (Font font = new Font(Font.FontFamily, 9, FontStyle.Bold))
                {
                    string countText = notificationCount > 99 ? "99+" : notificationCount.ToString();
                    SizeF textSize = e.Graphics.MeasureString(countText, font);
                    PointF location = new PointF(ClientRectangle.Width - textSize.Width - 5, 2);

                    // Draw the notification count text
                    e.Graphics.DrawString(countText, font, Brushes.White, location);
                }
            }
        }
    }
}
