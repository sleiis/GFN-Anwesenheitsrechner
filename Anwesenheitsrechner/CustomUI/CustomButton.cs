using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom button control with advanced features such as border radius, border size, and notification count.
    /// </summary>
    public class CustomButton : Button
    {
        private int notificationCount = 0;
        private int borderSize = 0;
        private int borderRadius = 0;
        private Color borderColor = Color.PaleVioletRed;

        /// <summary>
        /// Gets or sets the notification count displayed on the button.
        /// </summary>
        [Category("1 CustomButton Advance")]
        public int NotificationCount
        {
            get => notificationCount;
            set
            {
                notificationCount = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border size of the button.
        /// </summary>
        [Category("1 CustomButton Advance")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border radius of the button.
        /// </summary>
        [Category("1 CustomButton Advance")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the button.
        /// </summary>
        [Category("1 CustomButton Advance")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color of the button.
        /// </summary>
        [Category("1 CustomButton Advance")]
        public Color BackgroundColor
        {
            get => BackColor;
            set => BackColor = value;
        }

        /// <summary>
        /// Gets or sets the text color of the button.
        /// </summary>
        [Category("1 CustomButton Advance")]
        public Color TextColor
        {
            get => ForeColor;
            set => ForeColor = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomButton"/> class.
        /// </summary>
        public CustomButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.MediumSlateBlue;
            ForeColor = Color.White;
            Resize += Button_Resize;
        }

        /// <summary>
        /// Gets the graphics path for a rounded rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to round.</param>
        /// <param name="radius">The radius of the corners.</param>
        /// <returns>A <see cref="GraphicsPath"/> representing the rounded rectangle.</returns>
        private static GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Paints the button control.
        /// </summary>
        /// <param name="pevent">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            var rectSurface = ClientRectangle;
            var rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize : 2;

            // Draw the notification count
            if (notificationCount > 0)
            {
                DrawNotificationCount(pevent.Graphics);
            }

            if (borderRadius > 2) // Rounded button
            {
                using (var pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (var pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (var penSurface = new Pen(Parent.BackColor, smoothSize))
                using (var penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Button surface
                    Region = new Region(pathSurface);

                    // Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // Button border
                    if (borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else // Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                Region = new Region(rectSurface);

                if (borderSize >= 1)
                {
                    using (var penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the notification count on the button.
        /// </summary>
        /// <param name="g">The graphics object.</param>
        private void DrawNotificationCount(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the notification ellipse
            using (var brush = new SolidBrush(Color.FromArgb(0, 174, 219)))
            {
                g.FillEllipse(brush, Width - 15, 4, 14, 14);
            }

            // Draw the notification count text
            using (var font = new Font("Segoe UI", notificationCount >= 10 ? 6 : 10, FontStyle.Bold))
            {
                string countText = notificationCount > 99 ? "99+" : notificationCount.ToString();
                var textSize = g.MeasureString(countText, font);
                var textPosition = new PointF(Width - 14 + (13 - textSize.Width) / 2, 5 + (14 - textSize.Height) / 2);
                g.DrawString(countText, font, Brushes.White, textPosition);
            }
        }

        /// <summary>
        /// Handles the creation of the control.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += Container_BackColorChanged;
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
                borderRadius = Height;
        }
    }
}
