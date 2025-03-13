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
    /// Custom combo box control with advanced features such as custom drawing and state-based color changes.
    /// </summary>
    public class CustomComboBox2 : ComboBox
    {
        private int W;
        private int H;
        private int _StartIndex = 0;
        private int x;
        private int y;
        private MouseState State { get; set; } = MouseState.None;

        /// <summary>
        /// Gets or sets the hover color of the combo box.
        /// </summary>
        [Category("Colors")]
        public Color HoverColor { get; set; } = Color.FromArgb(22, 96, 253);

        /// <summary>
        /// Gets or sets the start index of the combo box.
        /// </summary>
        private int StartIndex
        {
            get => _StartIndex;
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets the font used for the icon.
        /// </summary>
        public Font IconFont { get; }

        private readonly Color _BaseColor = Color.FromArgb(22, 96, 253);
        private readonly Color _BGColor = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomComboBox2"/> class.
        /// </summary>
        public CustomComboBox2()
        {
            DrawItem += DrawItem_;
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(37, 34, 65);
            ForeColor = Color.White;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Cursor = Cursors.Hand;
            StartIndex = 0;
            ItemHeight = 16;
            Font = new Font("Tahoma", 8, FontStyle.Regular);
            IconFont = new Font("Marlett", 12);
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
        /// Handles the mouse move event.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            x = e.Location.X;
            y = e.Location.Y;
            Invalidate();
            Cursor = e.X < Width - 41 ? Cursors.IBeam : Cursors.Hand;
        }

        /// <summary>
        /// Handles the draw item event.
        /// </summary>
        /// <param name="e">The draw item event arguments.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            Invalidate();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) Invalidate();
        }

        /// <summary>
        /// Handles the click event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Invalidate();
        }

        /// <summary>
        /// Handles the resize event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }

        /// <summary>
        /// Draws the items in the combo box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The draw item event arguments.</param>
        public void DrawItem_(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(HoverColor), e.Bounds); // Selected item
            else
                e.Graphics.FillRectangle(new SolidBrush(_BGColor), e.Bounds); // Not selected

            e.Graphics.DrawString(GetItemText(Items[e.Index]), new Font("Tahoma", 8), Brushes.White,
                new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));

            e.Graphics.Dispose();
        }

        /// <summary>
        /// Paints the combo box control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                W = Width;
                H = Height;

                var Base = new Rectangle(0, 0, W, H);
                var Button = new Rectangle(Convert.ToInt32(W - 30), 0, W, H - 1);
                var GP = new GraphicsPath();

                G.Clear(Color.FromArgb(37, 34, 65));
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                // Base
                G.FillRectangle(new SolidBrush(_BGColor), Base);

                // Button
                GP.Reset();
                GP.AddRectangle(Button);
                G.SetClip(GP);
                G.FillRectangle(new SolidBrush(_BaseColor), Button);
                G.ResetClip();

                // Icon
                G.DrawString("6", IconFont, Brushes.White, new Point(W - 26, 3));

                // Text
                G.DrawString(Text, Font, Brushes.White, new Point(4, 5), Helpers.NearSF);

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }
    }
}