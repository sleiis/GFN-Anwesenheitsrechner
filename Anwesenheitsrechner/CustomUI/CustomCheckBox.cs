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
    /// Custom checkbox control with advanced features such as custom styles and state-based color changes.
    /// </summary>
    [DefaultEvent("CheckedChanged")]
    public class CustomCheckBox : Control
    {
        private int W;
        private int H;
        private MouseState State = MouseState.None;
        private bool _Checked;

        /// <summary>
        /// Gets or sets a value indicating whether the checkbox is checked.
        /// </summary>
        public bool Checked
        {
            get => _Checked;
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Occurs when the checked state changes.
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;

        /// <summary>
        /// Represents the method that will handle the <see cref="CheckedChanged"/> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        /// <summary>
        /// Enum representing the style options for the checkbox.
        /// </summary>
        [Flags]
        public enum _Options
        {
            Style1,
            Style2
        }

        /// <summary>
        /// Gets or sets the style options for the checkbox.
        /// </summary>
        [Category("Options")]
        public _Options Options { get; set; }

        /// <summary>
        /// Gets or sets the base color of the checkbox.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the border color of the checkbox.
        /// </summary>
        [Category("Colors")]
        public Color BorderColor { get; set; } = Helpers.FlatColor;

        private readonly Color _TextColor = Helpers.FlatWhite;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCheckBox"/> class.
        /// </summary>
        public CustomCheckBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(35, 30, 59);
            Cursor = Cursors.Hand;
            Font = new Font("Tahoma", 10);
            Size = new Size(112, 22);
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
        /// Handles the click event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClick(EventArgs e)
        {
            _Checked = !_Checked;
            CheckedChanged?.Invoke(this);
            base.OnClick(e);
        }

        /// <summary>
        /// Handles the resize event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 22;
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
        /// Paints the checkbox control.
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

                var Base = new Rectangle(0, 2, Height - 5, Height - 5);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                switch (Options)
                {
                    case _Options.Style1:
                        DrawStyle1(G, Base);
                        break;
                    case _Options.Style2:
                        DrawStyle2(G, Base);
                        break;
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Draws the checkbox in Style1.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        private void DrawStyle1(Graphics G, Rectangle Base)
        {
            G.FillRectangle(new SolidBrush(BaseColor), Base);

            if (State == MouseState.Over || State == MouseState.Down)
            {
                G.DrawRectangle(new Pen(BorderColor), Base);
            }

            if (Checked)
            {
                G.DrawString("ü", new Font("Wingdings", 18), new SolidBrush(BorderColor), new Rectangle(5, 7, H - 9, H - 9), Helpers.CenterSF);
            }

            if (!Enabled)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), Base);
                G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(140, 142, 143)), new Rectangle(20, 2, W, H), Helpers.NearSF);
            }
            else
            {
                G.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(20, 2, W, H), Helpers.NearSF);
            }
        }

        /// <summary>
        /// Draws the checkbox in Style2.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        private void DrawStyle2(Graphics G, Rectangle Base)
        {
            G.FillRectangle(new SolidBrush(BaseColor), Base);

            if (State == MouseState.Over || State == MouseState.Down)
            {
                G.DrawRectangle(new Pen(BorderColor), Base);
                G.FillRectangle(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
            }

            if (Checked)
            {
                G.DrawString("ü", new Font("Wingdings", 18), new SolidBrush(BorderColor), new Rectangle(5, 7, H - 9, H - 9), Helpers.CenterSF);
            }

            if (!Enabled)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(54, 58, 61)), Base);
                G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(48, 119, 91)), new Rectangle(20, 2, W, H), Helpers.NearSF);
            }
            else
            {
                G.DrawString(Text, Font, new SolidBrush(_TextColor), new Rectangle(20, 2, W, H), Helpers.NearSF);
            }
        }

        /// <summary>
        /// Updates the colors of the checkbox based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            BorderColor = colors.Flat;
        }
    }
}