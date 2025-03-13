using Anwesenheitsrechner.CustomUI.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom tree view control with advanced features such as custom colors and owner-drawn nodes.
    /// </summary>
    public class CustomTreeView : TreeView
    {
        private readonly Color _BaseColor = Color.FromArgb(24, 22, 43);
        private readonly Color _LineColor = Color.FromArgb(25, 27, 29);

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTreeView"/> class.
        /// </summary>
        public CustomTreeView()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            BackColor = _BaseColor;
            ForeColor = Color.White;
            LineColor = _LineColor;
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }

        /// <summary>
        /// Handles the draw node event to customize the appearance of the tree nodes.
        /// </summary>
        /// <param name="e">The draw tree node event arguments.</param>
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            try
            {
                var bounds = new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height);
                var textRect = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width, bounds.Height);
                var textFont = new Font("Tahoma", 8);

                if (e.Node.IsSelected)
                {
                    e.Graphics.FillRectangle(Brushes.Green, bounds);
                    e.Graphics.DrawString(e.Node.Text, textFont, Brushes.Black, textRect, Helpers.NearSF);
                }
                else if (e.Node.Checked)
                {
                    e.Graphics.FillRectangle(Brushes.Green, bounds);
                    e.Graphics.DrawString(e.Node.Text, textFont, Brushes.Black, textRect, Helpers.NearSF);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Red, bounds);
                    e.Graphics.DrawString(e.Node.Text, textFont, Brushes.LimeGreen, textRect, Helpers.NearSF);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            base.OnDrawNode(e);
        }

        /// <summary>
        /// Paints the tree view control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                var baseRect = new Rectangle(0, 0, Width, Height);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                // Draw base
                G.FillRectangle(new SolidBrush(_BaseColor), baseRect);

                // Draw text
                G.DrawString(Text, new Font("Tahoma", 8), Brushes.Black, new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), Helpers.NearSF);

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }
    }
}