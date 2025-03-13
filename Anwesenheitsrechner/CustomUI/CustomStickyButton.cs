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
    /// Custom sticky button control with advanced features such as custom colors, rounded corners, and state-based color changes.
    /// </summary>
    public class CustomStickyButton : Control
    {
        private int W;
        private int H;
        private MouseState State = MouseState.None;

        /// <summary>
        /// Gets or sets the base color of the button.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Helpers.FlatColor;

        /// <summary>
        /// Gets or sets the text color of the button.
        /// </summary>
        [Category("Colors")]
        public Color TextColor { get; set; } = Helpers.FlatWhite;

        /// <summary>
        /// Gets or sets a value indicating whether the button has rounded corners.
        /// </summary>
        [Category("Options")]
        public bool Rounded { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomStickyButton"/> class.
        /// </summary>
        public CustomStickyButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(106, 32);
            BackColor = Color.Transparent;
            Font = new Font("Tahoma", 12);
            Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }

        /// <summary>
        /// Handles the mouse up event.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Handles the mouse enter event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Handles the mouse leave event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        /// <summary>
        /// Handles the resize event to set the control height.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Height = 32; // Uncomment if you want to fix the height
        }

        /// <summary>
        /// Handles the creation of the control.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            // Size = new Size(112, 32); // Uncomment if you want to set a default size
        }

        /// <summary>
        /// Gets the connected sides of the button.
        /// </summary>
        /// <returns>An array of booleans indicating the connected sides.</returns>
        private bool[] GetConnectedSides()
        {
            var connectedSides = new bool[4];

            foreach (Control control in Parent.Controls)
            {
                if (control is CustomStickyButton button && !ReferenceEquals(control, this) && Rect.IntersectsWith(button.Rect))
                {
                    var angle = Math.Atan2(Left - button.Left, Top - button.Top) * 2 / Math.PI;
                    if (angle / 1 == angle)
                    {
                        connectedSides[(int)angle + 1] = true;
                    }
                }
            }

            return connectedSides;
        }

        /// <summary>
        /// Gets the rectangle representing the button's bounds.
        /// </summary>
        private Rectangle Rect => new Rectangle(Left, Top, Width, Height);

        /// <summary>
        /// Paints the button control.
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

                var connectedSides = GetConnectedSides();
                var roundedBase = Helpers.RoundRect(0, 0, W, H, 0.3, !(connectedSides[2] || connectedSides[1]), !(connectedSides[1] || connectedSides[0]), !(connectedSides[3] || connectedSides[0]), !(connectedSides[3] || connectedSides[2]));
                var baseRect = new Rectangle(0, 0, W, H);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                switch (State)
                {
                    case MouseState.None:
                        DrawButton(G, roundedBase, baseRect, BaseColor, TextColor, false);
                        break;
                    case MouseState.Over:
                        DrawButton(G, roundedBase, baseRect, BaseColor, TextColor, true, Color.FromArgb(20, Color.White));
                        break;
                    case MouseState.Down:
                        DrawButton(G, roundedBase, baseRect, BaseColor, TextColor, true, Color.FromArgb(20, Color.Black));
                        break;
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Draws the button with the specified properties.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="roundedBase">The rounded base path.</param>
        /// <param name="baseRect">The base rectangle.</param>
        /// <param name="baseColor">The base color.</param>
        /// <param name="textColor">The text color.</param>
        /// <param name="isHoveredOrPressed">Indicates if the button is hovered or pressed.</param>
        /// <param name="overlayColor">The overlay color for hover or press state.</param>
        private void DrawButton(Graphics G, GraphicsPath roundedBase, Rectangle baseRect, Color baseColor, Color textColor, bool isHoveredOrPressed, Color? overlayColor = null)
        {
            if (Rounded)
            {
                G.FillPath(new SolidBrush(baseColor), roundedBase);
                if (isHoveredOrPressed && overlayColor.HasValue)
                {
                    G.FillPath(new SolidBrush(overlayColor.Value), roundedBase);
                }
            }
            else
            {
                G.FillRectangle(new SolidBrush(baseColor), baseRect);
                if (isHoveredOrPressed && overlayColor.HasValue)
                {
                    G.FillRectangle(new SolidBrush(overlayColor.Value), baseRect);
                }
            }

            G.DrawString(Text, Font, new SolidBrush(textColor), baseRect, Helpers.CenterSF);
        }

        /// <summary>
        /// Updates the colors of the button based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            BaseColor = colors.Flat;
        }
    }
}