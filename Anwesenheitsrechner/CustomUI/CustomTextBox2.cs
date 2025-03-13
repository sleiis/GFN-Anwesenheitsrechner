using Anwesenheitsrechner.CustomUI.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlaAnwesenheitsrechner.CustomUItUI
{
    /// <summary>
    /// Custom text box control with advanced features such as custom colors, multiline support, and focus on hover.
    /// </summary>
    [DefaultEvent("TextChanged")]
    public class CustomTextBox2 : Control
    {
        private int W;
        private int H;
        private MouseState State = MouseState.None;
        private readonly TextBox TB;

        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        private int _MaxLength = 32767;
        private bool _ReadOnly;
        private bool _UseSystemPasswordChar;
        private bool _Multiline;

        /// <summary>
        /// Gets or sets the text alignment of the text box.
        /// </summary>
        [Category("Options")]
        public HorizontalAlignment TextAlign
        {
            get => _TextAlign;
            set
            {
                _TextAlign = value;
                if (TB != null) TB.TextAlign = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum length of the text box.
        /// </summary>
        [Category("Options")]
        public int MaxLength
        {
            get => _MaxLength;
            set
            {
                _MaxLength = value;
                if (TB != null) TB.MaxLength = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the text box is read-only.
        /// </summary>
        [Category("Options")]
        public bool ReadOnly
        {
            get => _ReadOnly;
            set
            {
                _ReadOnly = value;
                if (TB != null) TB.ReadOnly = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the text box uses the system password character.
        /// </summary>
        [Category("Options")]
        public bool UseSystemPasswordChar
        {
            get => _UseSystemPasswordChar;
            set
            {
                _UseSystemPasswordChar = value;
                if (TB != null) TB.UseSystemPasswordChar = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the text box is multiline.
        /// </summary>
        [Category("Options")]
        public bool Multiline
        {
            get => _Multiline;
            set
            {
                _Multiline = value;
                if (TB != null)
                {
                    TB.Multiline = value;
                    if (value)
                        TB.Height = Height - 11;
                    else
                        Height = TB.Height + 11;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the text box should focus on hover.
        /// </summary>
        [Category("Options")]
        public bool FocusOnHover { get; set; } = false;

        /// <summary>
        /// Gets or sets the text of the text box.
        /// </summary>
        [Category("Options")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                if (TB != null) TB.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the font of the text box.
        /// </summary>
        [Category("Options")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                if (TB != null)
                {
                    TB.Font = value;
                    TB.Location = new Point(3, 5);
                    TB.Width = Width - 6;
                    if (!_Multiline) Height = TB.Height + 11;
                }
            }
        }

        /// <summary>
        /// Gets or sets the text color of the text box.
        /// </summary>
        [Category("Colors")]
        public Color TextColor { get; set; } = Color.FromArgb(192, 192, 192);

        /// <summary>
        /// Gets or sets the foreground color of the text box.
        /// </summary>
        public override Color ForeColor
        {
            get => TextColor;
            set => TextColor = value;
        }

        private readonly Color _BaseColor = Color.FromArgb(24, 22, 43);
        private Color _BorderColor = Helpers.FlatColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTextBox2"/> class.
        /// </summary>
        public CustomTextBox2()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;

            TB = new TextBox
            {
                Font = new Font("Tahoma", 10),
                Text = Text,
                BackColor = _BaseColor,
                ForeColor = TextColor,
                MaxLength = _MaxLength,
                Multiline = _Multiline,
                ReadOnly = _ReadOnly,
                UseSystemPasswordChar = _UseSystemPasswordChar,
                BorderStyle = BorderStyle.None,
                Location = new Point(5, 5),
                Width = Width - 10,
                Cursor = Cursors.IBeam
            };

            if (_Multiline)
                TB.Height = Height - 11;
            else
                Height = TB.Height + 11;

            TB.TextChanged += OnBaseTextChanged;
            TB.KeyDown += OnBaseKeyDown;
        }

        /// <summary>
        /// Handles the creation of the control.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(TB)) Controls.Add(TB);
        }

        /// <summary>
        /// Handles the text changed event of the base text box.
        /// </summary>
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = TB.Text;
        }

        /// <summary>
        /// Handles the key down event of the base text box.
        /// </summary>
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TB.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                TB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Handles the resize event to adjust the text box size.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            TB.Location = new Point(5, 5);
            TB.Width = Width - 10;

            if (_Multiline)
                TB.Height = Height - 11;
            else
                Height = TB.Height + 11;

            base.OnResize(e);
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }

        /// <summary>
        /// Handles the mouse up event.
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            TB.Focus();
            Invalidate();
        }

        /// <summary>
        /// Handles the mouse enter event.
        /// </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            if (FocusOnHover) TB.Focus();
            Invalidate();
        }

        /// <summary>
        /// Handles the mouse leave event.
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        /// <summary>
        /// Paints the custom text box control.
        /// </summary>
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

                // Update text box colors
                TB.BackColor = _BaseColor;
                TB.ForeColor = TextColor;

                // Draw base
                G.FillRectangle(new SolidBrush(_BaseColor), Base);

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Updates the colors of the text box based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            _BorderColor = colors.Flat;
        }
    }
}