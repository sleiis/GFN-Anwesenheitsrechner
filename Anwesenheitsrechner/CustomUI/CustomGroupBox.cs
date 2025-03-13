using Anwesenheitsrechner.CustomUI.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom group box control with advanced features such as custom colors and rounded corners.
    /// </summary>
    public class CustomGroupBox : ContainerControl
    {
        private int W;
        private int H;

        /// <summary>
        /// Gets or sets the base color of the group box.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(37, 35, 63);

        /// <summary>
        /// Gets or sets a value indicating whether to show the text.
        /// </summary>
        public bool ShowText { get; set; } = true;

        private Color _TextColor = Helpers.FlatColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomGroupBox"/> class.
        /// </summary>
        public CustomGroupBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(240, 180);
            Font = new Font("Tahoma", 10);
        }

        /// <summary>
        /// Paints the group box control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateColors();

            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                W = Width - 1;
                H = Height - 1;

                var Base = new Rectangle(8, 8, W - 16, H - 16);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                // Draw base
                using (var GP = Helpers.RoundRec(Base, 8))
                {
                    G.FillPath(new SolidBrush(BaseColor), GP);
                }

                // Draw arrows
                using (var GP2 = Helpers.DrawArrow(28, 2, false))
                {
                    G.FillPath(new SolidBrush(BaseColor), GP2);
                }
                using (var GP3 = Helpers.DrawArrow(28, 8, true))
                {
                    G.FillPath(new SolidBrush(Color.FromArgb(35, 30, 59)), GP3);
                }

                // Draw text if ShowText is true
                if (ShowText)
                {
                    G.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(16, 16, W, H), Helpers.NearSF);
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Updates the colors of the group box based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            _TextColor = colors.Flat;
        }
    }
}