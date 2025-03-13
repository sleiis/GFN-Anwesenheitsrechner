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
    /// Custom toggle switch control with advanced features such as custom styles and state-based color changes.
    /// </summary>
    [DefaultEvent("CheckedChanged")]
    public class CustomToggle : Control
    {
        private int W;
        private int H;
        private MouseState State = MouseState.None;

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
        /// Enum representing the style options for the toggle switch.
        /// </summary>
        [Flags]
        public enum _Options
        {
            Style1,
            Style2,
            Style3
        }

        /// <summary>
        /// Gets or sets the style options for the toggle switch.
        /// </summary>
        [Category("Options")]
        public _Options Options { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the toggle switch is checked.
        /// </summary>
        [Category("Options")]
        public bool Checked { get; set; } = false;

        private Color BaseColor = Helpers.FlatColor;
        private readonly Color BaseColorRed = Color.FromArgb(220, 85, 96); // Red
        private readonly Color BGColor = Color.FromArgb(233, 95, 98); // Red
        private readonly Color ToggleColor = Color.FromArgb(24, 22, 43); // Dark
        private readonly Color TextColor = Helpers.FlatWhite;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomToggle"/> class.
        /// </summary>
        public CustomToggle()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(76, 33);
            Cursor = Cursors.Hand;
            Font = new Font("Tahoma", 10);
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
        /// Handles the resize event to set the control size.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 76;
            Height = 33;
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
        /// Handles the click event to toggle the checked state.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
            CheckedChanged?.Invoke(this);
        }

        /// <summary>
        /// Paints the toggle switch control.
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
                var Toggle = new Rectangle(Convert.ToInt32(W / 2), 0, 39, H);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                switch (Options)
                {
                    case _Options.Style1:
                        DrawStyle1(G, Base, Toggle);
                        break;
                    case _Options.Style2:
                        DrawStyle2(G, Base, Toggle);
                        break;
                    case _Options.Style3:
                        DrawStyle3(G, Base, Toggle);
                        break;
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Draws the toggle switch in Style1.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        /// <param name="Toggle">The toggle rectangle.</param>
        private void DrawStyle1(Graphics G, Rectangle Base, Rectangle Toggle)
        {
            var GP = Helpers.RoundRec(Base, 7);
            var GP2 = Helpers.RoundRec(Toggle, 6);
            G.FillPath(new SolidBrush(BGColor), GP);
            G.FillPath(new SolidBrush(ToggleColor), GP2);
            G.DrawString("OFF", Font, new SolidBrush(BGColor), new Rectangle(19, 1, W, H), Helpers.CenterSF);

            if (Checked)
            {
                GP = Helpers.RoundRec(new Rectangle(-1, 0, W, H), 6);
                GP2 = Helpers.RoundRec(new Rectangle(Convert.ToInt32(W / 2), 0, 39, H + 1), 6);
                G.FillPath(new SolidBrush(ToggleColor), GP);
                G.FillPath(new SolidBrush(BaseColor), GP2);
                G.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(8, 7, W, H), Helpers.NearSF);
            }
        }

        /// <summary>
        /// Draws the toggle switch in Style2.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        /// <param name="Toggle">The toggle rectangle.</param>
        private void DrawStyle2(Graphics G, Rectangle Base, Rectangle Toggle)
        {
            var GP = Helpers.RoundRec(Base, 6);
            Toggle = new Rectangle(4, 4, 36, H - 8);
            var GP2 = Helpers.RoundRec(Toggle, 4);
            G.FillPath(new SolidBrush(BaseColorRed), GP);
            G.FillPath(new SolidBrush(ToggleColor), GP2);
            G.DrawLine(new Pen(TextColor), 18, 20, 18, 12);
            G.DrawLine(new Pen(TextColor), 22, 20, 22, 12);
            G.DrawLine(new Pen(TextColor), 26, 20, 26, 12);
            G.DrawString("r", new Font("Marlett", 8), new SolidBrush(TextColor), new Rectangle(19, 2, Width, Height), Helpers.CenterSF);

            if (Checked)
            {
                GP = Helpers.RoundRec(Base, 6);
                Toggle = new Rectangle(Convert.ToInt32(W / 2) - 2, 4, 36, H - 8);
                GP2 = Helpers.RoundRec(Toggle, 4);
                G.FillPath(new SolidBrush(BaseColor), GP);
                G.FillPath(new SolidBrush(ToggleColor), GP2);
                G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 12, 20, Convert.ToInt32(W / 2) + 12, 12);
                G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 16, 20, Convert.ToInt32(W / 2) + 16, 12);
                G.DrawLine(new Pen(BGColor), Convert.ToInt32(W / 2) + 20, 20, Convert.ToInt32(W / 2) + 20, 12);
                G.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(TextColor), new Rectangle(8, 7, Width, Height), Helpers.NearSF);
            }
        }

        /// <summary>
        /// Draws the toggle switch in Style3.
        /// </summary>
        /// <param name="G">The graphics object.</param>
        /// <param name="Base">The base rectangle.</param>
        /// <param name="Toggle">The toggle rectangle.</param>
        private void DrawStyle3(Graphics G, Rectangle Base, Rectangle Toggle)
        {
            var GP = Helpers.RoundRec(Base, 16);
            Toggle = new Rectangle(W - 28, 4, 22, H - 8);
            var GP2 = new GraphicsPath();
            GP2.AddEllipse(Toggle);
            G.FillPath(new SolidBrush(ToggleColor), GP);
            G.FillPath(new SolidBrush(BaseColorRed), GP2);
            G.DrawString("OFF", Font, new SolidBrush(BaseColorRed), new Rectangle(-12, 2, W, H), Helpers.CenterSF);

            if (Checked)
            {
                GP = Helpers.RoundRec(Base, 16);
                Toggle = new Rectangle(6, 4, 22, H - 8);
                GP2.Reset();
                GP2.AddEllipse(Toggle);
                G.FillPath(new SolidBrush(ToggleColor), GP);
                G.FillPath(new SolidBrush(BaseColor), GP2);
                G.DrawString("ON", Font, new SolidBrush(BaseColor), new Rectangle(12, 2, W, H), Helpers.CenterSF);
            }
        }

        /// <summary>
        /// Updates the colors of the toggle switch based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            BaseColor = colors.Flat;
        }
    }
}