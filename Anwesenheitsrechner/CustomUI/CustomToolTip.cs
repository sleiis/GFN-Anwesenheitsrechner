using System.Drawing;
using System.Windows.Forms;

namespace TrionUI.Controls
{
    /// <summary>
    /// Custom tooltip control with advanced features such as custom colors, title, and link support.
    /// </summary>
    public class CustomToolTip : ToolTip
    {
        private Rectangle linkRectangle;

        // Properties
        public Color BackgroundColor { get; set; } = Color.FromArgb(34, 39, 46);
        public Color BorderColor { get; set; } = Color.FromArgb(0, 174, 219);
        public Color TextColor { get; set; } = Color.White;
        public Color TitleColor { get; set; } = Color.Green;
        public Color TitleBackgroundColor { get; set; } = Color.FromArgb(28, 33, 40);
        public int BorderSize { get; set; } = 1;
        public bool LinkEnabled { get; set; } = true;
        public string LinkText { get; set; } = "Read More";
        public Color LinkColor { get; set; } = Color.DodgerBlue;
        public Font TextFont { get; set; } = new Font("Segoe UI Semibold", 10);

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomToolTip"/> class.
        /// </summary>
        public CustomToolTip()
        {
            OwnerDraw = true;
            Draw += OnDraw;
            Popup += OnPopup;
        }

        /// <summary>
        /// Handles the draw event to customize the tooltip appearance.
        /// </summary>
        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            if (IsBalloon)
            {
                DrawBalloonToolTip(e);
            }
            else
            {
                DrawStandardToolTip(e);
            }
        }

        /// <summary>
        /// Handles the popup event to adjust the tooltip size.
        /// </summary>
        private void OnPopup(object sender, PopupEventArgs e)
        {
            using (Graphics g = e.AssociatedControl.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(GetToolTip(e.AssociatedControl), TextFont);
                SizeF linkSize = LinkEnabled ? g.MeasureString(LinkText, TextFont) : new SizeF(0f, 0f);
                SizeF titleSize = g.MeasureString(ToolTipTitle, TextFont);
                e.ToolTipSize = new Size((int)textSize.Width + 10, (int)textSize.Height + 10 + (int)titleSize.Height + (int)linkSize.Height);
            }
        }

        /// <summary>
        /// Draws the standard tooltip.
        /// </summary>
        private void DrawStandardToolTip(DrawToolTipEventArgs e)
        {
            SizeF textSize = e.Graphics.MeasureString(e.ToolTipText, TextFont);
            SizeF titleSize = e.Graphics.MeasureString(ToolTipTitle, TextFont);
            SizeF linkSize = e.Graphics.MeasureString(LinkText, TextFont);

            // Draw the title background
            using (SolidBrush titleBackgroundBrush = new SolidBrush(TitleBackgroundColor))
            {
                e.Graphics.FillRectangle(titleBackgroundBrush, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, (int)titleSize.Height + 5));
            }

            // Draw the bottom border of the title background
            using (Pen borderPen = new Pen(Color.FromArgb(28, 33, 40), 1))
            {
                if (!string.IsNullOrEmpty(ToolTipTitle))
                {
                    int yPosition = e.Bounds.Y + ((int)titleSize.Height + 4);
                    e.Graphics.DrawLine(borderPen, e.Bounds.X, yPosition, e.Bounds.Right, yPosition);
                }
            }

            // Draw the text background
            using (SolidBrush backgroundBrush = new SolidBrush(BackgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, new Rectangle(e.Bounds.X, e.Bounds.Y + (int)titleSize.Height + 5, e.Bounds.Width, e.Bounds.Height - (int)titleSize.Height - 5));
            }

            // Draw the border
            if (BorderSize != 0)
            {
                using (Pen borderPen = new Pen(BorderColor, BorderSize))
                {
                    e.Graphics.DrawRectangle(borderPen, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                }
            }

            // Draw the title
            if (!string.IsNullOrEmpty(ToolTipTitle))
            {
                using (SolidBrush titleBrush = new SolidBrush(TitleColor))
                {
                    e.Graphics.DrawString(ToolTipTitle, new Font(e.Font, FontStyle.Bold), titleBrush, new PointF((textSize.Width / 2) - (titleSize.Width / 2) + 5, 5));
                }
            }

            // Draw the text
            using (SolidBrush textBrush = new SolidBrush(TextColor))
            {
                e.Graphics.DrawString(e.ToolTipText, TextFont, textBrush, e.Bounds.X + 5, e.Bounds.Y + titleSize.Height + 5);

                // Draw the link
                if (LinkEnabled)
                {
                    linkRectangle = new Rectangle(e.Bounds.X + (int)textSize.Width - (int)linkSize.Width - 5, e.Bounds.Y + (int)titleSize.Height + (int)textSize.Height, (int)linkSize.Width + 5, (int)linkSize.Height);
                    using (SolidBrush linkBrush = new SolidBrush(LinkColor))
                    {
                        e.Graphics.DrawString(LinkText, TextFont, linkBrush, linkRectangle.Location);
                    }

                    // Underline the link text
                    using (Pen underlinePen = new Pen(LinkColor))
                    {
                        e.Graphics.DrawLine(underlinePen, linkRectangle.X - 5, linkRectangle.Bottom, linkRectangle.Right - 5, linkRectangle.Bottom);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the balloon tooltip.
        /// </summary>
        private void DrawBalloonToolTip(DrawToolTipEventArgs e)
        {
            Rectangle balloonArea = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);

            // Draw the balloon background
            using (SolidBrush backgroundBrush = new SolidBrush(BackgroundColor))
            {
                e.Graphics.FillEllipse(backgroundBrush, balloonArea);
            }

            // Draw the balloon border
            using (Pen borderPen = new Pen(BorderColor))
            {
                e.Graphics.DrawEllipse(borderPen, balloonArea);
            }

            // Draw the title
            if (!string.IsNullOrEmpty(ToolTipTitle))
            {
                using (SolidBrush titleBrush = new SolidBrush(TitleColor))
                {
                    e.Graphics.DrawString(ToolTipTitle, new Font(e.Font, FontStyle.Bold), titleBrush, new PointF(10, 5));
                }
            }

            // Draw the text
            using (SolidBrush textBrush = new SolidBrush(TextColor))
            {
                e.Graphics.DrawString(e.ToolTipText, e.Font, textBrush, new RectangleF(new PointF(10, 20), e.Bounds.Size));
            }
        }
    }
}
