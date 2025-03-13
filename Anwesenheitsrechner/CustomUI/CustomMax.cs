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
    /// Custom control for maximizing and restoring the window state.
    /// </summary>
    public class CustomMax : Control
    {
        private MouseState State = MouseState.None;
        private int x;

        /// <summary>
        /// Gets or sets the base color of the control.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the text color of the control.
        /// </summary>
        [Category("Colors")]
        public Color TextColor { get; set; } = Color.FromArgb(48, 190, 69);

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMax"/> class.
        /// </summary>
        public CustomMax()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.White;
            Size = new Size(10, 10);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Marlett", 14);
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
        /// Handles the mouse move event.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            x = e.X;
            Invalidate();
        }

        /// <summary>
        /// Handles the click event to toggle the window state between maximized and normal.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            var form = FindForm();
            if (form != null)
            {
                form.WindowState = form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Handles the resize event to set the control size.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(10, 10);
        }

        /// <summary>
        /// Paints the control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                var Base = new Rectangle(0, 0, Width, Height);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                // Draw base
                G.FillRectangle(new SolidBrush(BaseColor), Base);

                // Draw maximize icon (dot as big as the button and centered)
                G.FillEllipse(new SolidBrush(TextColor), new Rectangle(0, 0, Width, Height));

                // Draw hover/down effect
                switch (State)
                {
                    case MouseState.Over:
                        G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
                        break;
                    case MouseState.Down:
                        G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);
                        break;
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }
    }
}