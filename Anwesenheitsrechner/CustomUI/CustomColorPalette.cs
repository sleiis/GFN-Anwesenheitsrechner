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
    /// Custom color palette control for displaying a set of predefined colors.
    /// </summary>
    public class CustomColorPalette : Control
    {
        private int W;
        private int H;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomColorPalette"/> class.
        /// </summary>
        public CustomColorPalette()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(35, 30, 59);
            Size = new Size(160, 80);
            Font = new Font("Tahoma", 12);
        }

        /// <summary>
        /// Handles the resize event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 180;
            Height = 80;
        }

        /// <summary>
        /// Gets or sets the red color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color Red { get; set; } = Color.FromArgb(220, 85, 96);

        /// <summary>
        /// Gets or sets the cyan color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color Cyan { get; set; } = Color.FromArgb(10, 154, 157);

        /// <summary>
        /// Gets or sets the blue color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color Blue { get; set; } = Color.FromArgb(0, 128, 255);

        /// <summary>
        /// Gets or sets the lime green color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color LimeGreen { get; set; } = Color.FromArgb(22, 96, 253);

        /// <summary>
        /// Gets or sets the orange color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color Orange { get; set; } = Color.FromArgb(253, 181, 63);

        /// <summary>
        /// Gets or sets the purple color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color Purple { get; set; } = Color.FromArgb(155, 88, 181);

        /// <summary>
        /// Gets or sets the black color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color Black { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the gray color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color Gray { get; set; } = Color.FromArgb(63, 70, 73);

        /// <summary>
        /// Gets or sets the white color in the palette.
        /// </summary>
        [Category("Colors")]
        public Color White { get; set; } = Helpers.FlatWhite;

        /// <summary>
        /// Paints the color palette control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                W = Width - 1;
                H = Height - 1;

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                // Draw color rectangles
                DrawColorRectangles(G);

                // Draw text
                G.DrawString("Color Palette", Font, new SolidBrush(White), new Rectangle(0, 22, W, H), Helpers.CenterSF);

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Draws the color rectangles in the palette.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        private void DrawColorRectangles(Graphics G)
        {
            var colors = new[] { Red, Cyan, Blue, LimeGreen, Orange, Purple, Black, Gray, White };
            for (int i = 0; i < colors.Length; i++)
            {
                G.FillRectangle(new SolidBrush(colors[i]), new Rectangle(i * 20, 0, 20, 40));
            }
        }
    }
}