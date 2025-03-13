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
    /// Custom radio button control with advanced features such as custom styles and state-based color changes.
    /// </summary>
    [DefaultEvent("CheckedChanged")]
    public class CustomRadioButton : Control
    {
        private MouseState State = MouseState.None;
        private int W;
        private int H;
        private bool _Checked;

        /// <summary>
        /// Gets or sets a value indicating whether the radio button is checked.
        /// </summary>
        public bool Checked
        {
            get => _Checked;
            set
            {
                _Checked = value;
                InvalidateControls();
                CheckedChanged?.Invoke(this);
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
        /// Enum representing the style options for the radio button.
        /// </summary>
        [Flags]
        public enum _Options
        {
            Style1,
            Style2
        }

        /// <summary>
        /// Gets or sets the style options for the radio button.
        /// </summary>
        [Category("Options")]
        public _Options Options { get; set; }

        /// <summary>
        /// Gets or sets the base color of the radio button.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the border color of the radio button.
        /// </summary>
        [Category("Colors")]
        public Color BorderColor { get; set; } = Helpers.FlatColor;

        /// <summary>
        /// Gets or sets the text color of the radio button.
        /// </summary>
        [Category("Colors")]
        public Color TextColor { get; set; } = Helpers.FlatWhite;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRadioButton"/> class.
        /// </summary>
        public CustomRadioButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            Size = new Size(100, 22);
            BackColor = Color.FromArgb(35, 30, 59);
            Font = new Font("Tahoma", 10);
        }

        /// <summary>
        /// Handles the click event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            base.OnClick(e);
        }

        /// <summary>
        /// Invalidates other radio buttons in the same container.
        /// </summary>
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control control in Parent.Controls)
            {
                if (control is CustomRadioButton radioButton && !ReferenceEquals(control, this))
                {
                    radioButton.Checked = false;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Handles the creation of the control.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
        }

        /// <summary>
        /// Handles the resize event to set the control height.
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
        /// Paints the radio button control.
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
                var Dot = new Rectangle(4, 6, H - 12, H - 12);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                switch (Options)
                {
                    case _Options.Style1:
                        DrawStyle1(G, Base, Dot);
                        break;
                    case _Options.Style2:
                        DrawStyle2(G, Base, Dot);
                        break;
                }

                G.DrawString(Text, Font, new SolidBrush(TextColor), new Rectangle(20, 2, W, H), Helpers.NearSF);

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Draws the radio button in Style1.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        /// <param name="Dot">The dot rectangle.</param>
        private void DrawStyle1(Graphics G, Rectangle Base, Rectangle Dot)
        {
            G.FillEllipse(new SolidBrush(BaseColor), Base);

            if (State == MouseState.Over || State == MouseState.Down)
            {
                G.DrawEllipse(new Pen(BorderColor), Base);
            }

            if (Checked)
            {
                G.FillEllipse(new SolidBrush(BorderColor), Dot);
            }
        }

        /// <summary>
        /// Draws the radio button in Style2.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        /// <param name="Dot">The dot rectangle.</param>
        private void DrawStyle2(Graphics G, Rectangle Base, Rectangle Dot)
        {
            G.FillEllipse(new SolidBrush(BaseColor), Base);

            if (State == MouseState.Over || State == MouseState.Down)
            {
                G.DrawEllipse(new Pen(BorderColor), Base);
                G.FillEllipse(new SolidBrush(Color.FromArgb(118, 213, 170)), Base);
            }

            if (Checked)
            {
                G.FillEllipse(new SolidBrush(BorderColor), Dot);
            }
        }

        /// <summary>
        /// Updates the colors of the radio button based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            BorderColor = colors.Flat;
        }
    }
}