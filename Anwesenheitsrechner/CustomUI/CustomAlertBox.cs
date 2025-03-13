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
    /// Custom alert box control for displaying success, error, and info messages.
    /// </summary>
    public class CustomAlertBox : Control
    {
        private int W;
        private int H;
        private string _Text;
        private MouseState State = MouseState.None;
        private int X;
        private Timer withEventsField_T;

        private Timer T
        {
            get => withEventsField_T;
            set
            {
                if (withEventsField_T != null) withEventsField_T.Tick -= T_Tick;
                withEventsField_T = value;
                if (withEventsField_T != null) withEventsField_T.Tick += T_Tick;
            }
        }

        /// <summary>
        /// Enum representing the type of alert.
        /// </summary>
        [Flags]
        public enum _Kind
        {
            Success,
            Error,
            Info
        }

        /// <summary>
        /// Gets or sets the kind of alert.
        /// </summary>
        [Category("Options")]
        public _Kind kind { get; set; }

        /// <summary>
        /// Gets or sets the text of the alert.
        /// </summary>
        [Category("Options")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                if (_Text != null) _Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the alert.
        /// </summary>
        [Category("Options")]
        public new bool Visible
        {
            get => base.Visible == false;
            set => base.Visible = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAlertBox"/> class.
        /// </summary>
        public CustomAlertBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(35, 30, 59);
            Size = new Size(576, 42);
            Location = new Point(10, 61);
            Font = new Font("Tahoma", 10);
            Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Shows the alert with the specified kind, text, and interval.
        /// </summary>
        /// <param name="Kind">The kind of alert.</param>
        /// <param name="Str">The text of the alert.</param>
        /// <param name="Interval">The duration to show the alert in milliseconds.</param>
        public void ShowControl(_Kind Kind, string Str, int Interval)
        {
            kind = Kind;
            Text = Str;
            Visible = true;
            T = new Timer { Interval = Interval, Enabled = true };
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Visible = false;
            T.Enabled = false;
            T.Dispose();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 42;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Visible = false;
        }

        private readonly Color SuccessColor = Color.FromArgb(48, 190, 69);
        private readonly Color SuccessText = Helpers.FlatWhite;
        private readonly Color ErrorColor = Color.FromArgb(233, 95, 98);
        private readonly Color ErrorText = Helpers.FlatWhite;
        private readonly Color InfoColor = Helpers.FlatColor;
        private readonly Color InfoText = Helpers.FlatWhite;

        /// <summary>
        /// Paints the alert box.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                W = Width - 1;
                H = Height - 1;

                var Base = new Rectangle(0, 0, W, H);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                switch (kind)
                {
                    case _Kind.Success:
                        DrawAlert(G, Base, SuccessColor, SuccessText, "ü", new Font("Wingdings", 22));
                        break;
                    case _Kind.Error:
                        DrawAlert(G, Base, ErrorColor, ErrorText, "r", new Font("Marlett", 16));
                        break;
                    case _Kind.Info:
                        DrawAlert(G, Base, InfoColor, InfoText, "¡", new Font("Tahoma", 20, FontStyle.Bold));
                        break;
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        private void DrawAlert(Graphics G, Rectangle Base, Color backgroundColor, Color textColor, string symbol, Font symbolFont)
        {
            G.FillRectangle(new SolidBrush(backgroundColor), Base);
            G.FillEllipse(new SolidBrush(textColor), new Rectangle(8, 9, 24, 24));
            G.FillEllipse(new SolidBrush(backgroundColor), new Rectangle(10, 11, 20, 20));
            G.DrawString(symbol, symbolFont, new SolidBrush(textColor), new Rectangle(7, 7, W, H), Helpers.NearSF);
            G.DrawString(Text, Font, new SolidBrush(textColor), new Rectangle(48, 12, W, H), Helpers.NearSF);
            DrawCloseButton(G, backgroundColor, textColor);
        }

        private void DrawCloseButton(Graphics G, Color backgroundColor, Color textColor)
        {
            G.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 30, H - 29, 17, 17));
            G.DrawString("r", new Font("Marlett", 8), new SolidBrush(backgroundColor), new Rectangle(W - 28, 16, W, H), Helpers.NearSF);

            if (State == MouseState.Over)
            {
                G.DrawString("r", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 28, 16, W, H), Helpers.NearSF);
            }
        }
    }
}