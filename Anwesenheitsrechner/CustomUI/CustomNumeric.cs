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
    /// Custom numeric control with advanced features such as custom colors and value range.
    /// </summary>
    public class CustomNumeric : Control
    {
        private int W;
        private int H;
        private MouseState State = MouseState.None;
        private int x;
        private int y;
        private long _Value;
        private long _Min;
        private long _Max;
        private bool isEditing;

        /// <summary>
        /// Gets or sets the value of the numeric control.
        /// </summary>
        public long Value
        {
            get => _Value;
            set
            {
                if (value <= _Max && value >= _Min)
                {
                    _Value = value;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value of the numeric control.
        /// </summary>
        public long Maximum
        {
            get => _Max;
            set
            {
                if (value > _Min)
                {
                    _Max = value;
                }
                if (_Value > _Max)
                {
                    _Value = _Max;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum value of the numeric control.
        /// </summary>
        public long Minimum
        {
            get => _Min;
            set
            {
                if (value < _Max)
                {
                    _Min = value;
                }
                if (_Value < _Min)
                {
                    _Value = _Min;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the base color of the control.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the button color of the control.
        /// </summary>
        [Category("Colors")]
        public Color ButtonColor { get; set; } = Helpers.FlatColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomNumeric"/> class.
        /// </summary>
        public CustomNumeric()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("Tahoma", 10);
            BackColor = Color.FromArgb(35, 30, 59);
            ForeColor = Color.White;
            _Min = 0;
            _Max = 9999999;
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
            Cursor = e.X < Width - 23 ? Cursors.IBeam : Cursors.Hand;
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (x > Width - 21 && x < Width - 3)
            {
                if (y < 15)
                {
                    if (Value + 1 <= _Max)
                    {
                        _Value += 1;
                    }
                }
                else
                {
                    if (Value - 1 >= _Min)
                    {
                        _Value -= 1;
                    }
                }
            }
            else
            {
                isEditing = !isEditing;
                Focus();
            }

            Invalidate();
        }

        /// <summary>
        /// Handles the key press event.
        /// </summary>
        /// <param name="e">The key press event arguments.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (isEditing)
                {
                    _Value = Convert.ToInt64(_Value.ToString() + e.KeyChar.ToString());
                }
                if (_Value > _Max)
                {
                    _Value = _Max;
                }
                Invalidate();
            }
            catch
            {
                // Handle exception
            }
        }

        /// <summary>
        /// Handles the key down event.
        /// </summary>
        /// <param name="e">The key event arguments.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Back)
            {
                Value = 0;
            }
        }

        /// <summary>
        /// Handles the resize event to set the control height.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 30;
        }

        /// <summary>
        /// Paints the numeric control.
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
                G.Clear(BackColor);

                // Draw base
                G.FillRectangle(new SolidBrush(BaseColor), Base);
                G.FillRectangle(new SolidBrush(ButtonColor), new Rectangle(Width - 24, 0, 24, H - 1));

                // Draw add button
                G.DrawString("5", new Font("Marlett", 11), Brushes.White, new Point(Width - 12, 8), Helpers.CenterSF);
                // Draw subtract button
                G.DrawString("6", new Font("Marlett", 11), Brushes.White, new Point(Width - 12, 22), Helpers.CenterSF);

                // Draw value text
                G.DrawString(Value.ToString(), Font, Brushes.White, new Rectangle(5, 1, W, H), new StringFormat { LineAlignment = StringAlignment.Center });

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Updates the colors of the numeric control based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            ButtonColor = colors.Flat;
        }
    }
}