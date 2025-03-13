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
    /// Custom tab control with advanced features such as custom colors and state-based color changes.
    /// </summary>
    public class CustomTabControl : TabControl
    {
        private int W;
        private int H;

        /// <summary>
        /// Gets or sets the base color of the tab control.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the active color of the selected tab.
        /// </summary>
        [Category("Colors")]
        public Color ActiveColor { get; set; } = Helpers.FlatColor;

        private readonly Color BGColor = Color.FromArgb(35, 30, 59);

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTabControl"/> class.
        /// </summary>
        public CustomTabControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(35, 30, 59);
            Font = new Font("Tahoma", 10);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(120, 40);
        }

        /// <summary>
        /// Handles the creation of the control to set the tab alignment.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        /// <summary>
        /// Paints the tab control.
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

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BaseColor);

                try
                {
                    SelectedTab.BackColor = BGColor;
                }
                catch
                {
                    // Handle exception if any
                }

                for (int i = 0; i < TabCount; i++)
                {
                    var tabRect = GetTabRect(i);
                    var baseRect = new Rectangle(tabRect.Location.X + 2, tabRect.Location.Y, tabRect.Width, tabRect.Height);

                    if (i == SelectedIndex)
                    {
                        DrawTab(G, baseRect, TabPages[i], true);
                    }
                    else
                    {
                        DrawTab(G, baseRect, TabPages[i], false);
                    }
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Draws a tab with the specified properties.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="baseRect">The base rectangle of the tab.</param>
        /// <param name="tabPage">The tab page to draw.</param>
        /// <param name="isSelected">Indicates if the tab is selected.</param>
        private void DrawTab(Graphics G, Rectangle baseRect, TabPage tabPage, bool isSelected)
        {
            var baseColor = isSelected ? ActiveColor : BaseColor;
            G.FillRectangle(new SolidBrush(baseColor), baseRect);

            if (ImageList != null && tabPage.ImageIndex >= 0 && tabPage.ImageIndex < ImageList.Images.Count)
            {
                var image = ImageList.Images[tabPage.ImageIndex];
                if (image != null)
                {
                    G.DrawImage(image, new Point(baseRect.Location.X + 8, baseRect.Location.Y + 6));
                    G.DrawString("      " + tabPage.Text, Font, Brushes.White, baseRect, Helpers.CenterSF);
                    return;
                }
            }

            G.DrawString(tabPage.Text, Font, Brushes.White, baseRect, Helpers.CenterSF);
        }

        /// <summary>
        /// Updates the colors of the tab control based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            ActiveColor = colors.Flat;
        }
    }
}