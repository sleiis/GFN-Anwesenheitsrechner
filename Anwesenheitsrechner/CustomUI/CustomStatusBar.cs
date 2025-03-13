using Anwesenheitsrechner.CustomUI.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom status bar control with advanced features such as custom colors and optional time/date display.
    /// </summary>
    public class CustomStatusBar : Control
    {
        private int W;
        private int H;

        /// <summary>
        /// Gets or sets the base color of the status bar.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the text color of the status bar.
        /// </summary>
        [Category("Colors")]
        public Color TextColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the rectangle color of the status bar.
        /// </summary>
        [Category("Colors")]
        public Color RectColor { get; set; } = Helpers.FlatColor;

        /// <summary>
        /// Gets or sets a value indicating whether to show the time and date.
        /// </summary>
        public bool ShowTimeDate { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomStatusBar"/> class.
        /// </summary>
        public CustomStatusBar()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Tahoma", 8);
            ForeColor = Color.White;
            Size = new Size(Width, 20);
        }

        /// <summary>
        /// Handles the creation of the control to set the dock style.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Dock = DockStyle.Bottom;
        }

        /// <summary>
        /// Handles the text changed event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Gets the current time and date as a string.
        /// </summary>
        /// <returns>The current time and date.</returns>
        public string GetTimeDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// Paints the status bar control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateColors();

            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                W = Width;
                H = Height;

                var Base = new Rectangle(0, 0, W, H);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BaseColor);

                // Draw base
                G.FillRectangle(new SolidBrush(BaseColor), Base);

                // Draw text
                G.DrawString(Text, Font, Brushes.White, new Rectangle(10, 4, W, H), Helpers.NearSF);

                // Draw rectangle
                G.FillRectangle(new SolidBrush(RectColor), new Rectangle(4, 4, 4, 14));

                // Draw time/date
                if (ShowTimeDate)
                {
                    G.DrawString(GetTimeDate(), Font, new SolidBrush(TextColor), new Rectangle(-4, 2, W, H), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Updates the colors of the status bar based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            RectColor = colors.Flat;
        }
    }
}