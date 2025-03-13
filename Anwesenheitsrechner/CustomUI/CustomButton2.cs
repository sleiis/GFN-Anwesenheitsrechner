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
    /// Custom button control with advanced features such as rounded corners and state-based color changes.
    /// </summary>
    public class CustomButton2 : Control
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
        /// Initializes a new instance of the <see cref="CustomButton2"/> class.
        /// </summary>
        public CustomButton2()
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
        /// Paints the button control.
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

                var Base = new Rectangle(0, 0, W, H);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                switch (State)
                {
                    case MouseState.None:
                        DrawButton(G, Base, false, false);
                        break;
                    case MouseState.Over:
                        DrawButton(G, Base, true, false);
                        break;
                    case MouseState.Down:
                        DrawButton(G, Base, false, true);
                        break;
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Draws the button based on its state.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        /// <param name="isHovered">Indicates if the button is hovered.</param>
        /// <param name="isPressed">Indicates if the button is pressed.</param>
        private void DrawButton(Graphics G, Rectangle Base, bool isHovered, bool isPressed)
        {
            GraphicsPath GP;
            if (Rounded)
            {
                GP = Helpers.RoundRec(Base, 6);
                G.FillPath(new SolidBrush(BaseColor), GP);
                if (isHovered)
                {
                    G.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), GP);
                }
                if (isPressed)
                {
                    G.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), GP);
                }
                G.DrawString(Text, Font, new SolidBrush(TextColor), Base, Helpers.CenterSF);
            }
            else
            {
                G.FillRectangle(new SolidBrush(BaseColor), Base);
                if (isHovered)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);
                }
                if (isPressed)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);
                }
                G.DrawString(Text, Font, new SolidBrush(TextColor), Base, Helpers.CenterSF);
            }
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