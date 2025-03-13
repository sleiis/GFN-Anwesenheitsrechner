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
    /// Custom progress bar control with advanced features such as custom colors, patterns, and balloon display.
    /// </summary>
    public class CustomProgressBar2 : Control
    {
        private int W;
        private int H;
        private int _Value = 0;
        private int _Maximum = 100;

        /// <summary>
        /// Gets or sets the maximum value of the progress bar.
        /// </summary>
        [Category("Control")]
        public int Maximum
        {
            get => _Maximum;
            set
            {
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current value of the progress bar.
        /// </summary>
        [Category("Control")]
        public int Value
        {
            get => _Value;
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show a pattern on the progress bar.
        /// </summary>
        public bool Pattern { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to show a balloon with the progress value.
        /// </summary>
        public bool ShowBalloon { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to show a percent sign with the progress value.
        /// </summary>
        public bool PercentSign { get; set; } = false;

        /// <summary>
        /// Gets or sets the color of the progress bar.
        /// </summary>
        [Category("Colors")]
        public Color ProgressColor { get; set; } = Helpers.FlatColor;

        /// <summary>
        /// Gets or sets the darker color of the progress bar pattern.
        /// </summary>
        [Category("Colors")]
        public Color DarkerProgress { get; set; } = Color.FromArgb(23, 148, 92);

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomProgressBar2"/> class.
        /// </summary>
        public CustomProgressBar2()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(35, 30, 59);
            Height = 42;
        }

        /// <summary>
        /// Handles the resize event to set the control height.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 42;
        }

        /// <summary>
        /// Handles the creation of the control.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 42;
        }

        /// <summary>
        /// Increments the progress bar value by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to increment.</param>
        public void Increment(int amount)
        {
            Value += amount;
        }

        private readonly Color _BaseColor = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Paints the progress bar control.
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

                var Base = new Rectangle(0, 24, W, H);
                var percent = (float)_Value / _Maximum;
                var iValue = (int)(percent * Width);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                // Draw base
                G.FillRectangle(new SolidBrush(_BaseColor), Base);

                // Draw progress
                G.FillRectangle(new SolidBrush(ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1));

                if (Pattern)
                {
                    // Draw pattern
                    using (var HB = new HatchBrush(HatchStyle.Plaid, DarkerProgress, ProgressColor))
                    {
                        G.FillRectangle(HB, new Rectangle(0, 24, iValue - 1, H - 1));
                    }
                }

                if (ShowBalloon)
                {
                    // Draw balloon
                    var Balloon = new Rectangle(iValue - 18, 0, 34, 16);
                    using (var GP2 = Helpers.RoundRec(Balloon, 4))
                    {
                        G.FillPath(new SolidBrush(_BaseColor), GP2);
                    }

                    // Draw arrow
                    using (var GP3 = Helpers.DrawArrow(iValue - 9, 16, true))
                    {
                        G.FillPath(new SolidBrush(_BaseColor), GP3);
                    }

                    // Draw value text
                    var text = PercentSign ? $"{Value}%" : Value.ToString();
                    var wOffset = PercentSign ? iValue - 15 : iValue - 11;
                    G.DrawString(text, new Font("Tahoma", 10), new SolidBrush(ProgressColor), new Rectangle(wOffset, -2, W, H), Helpers.NearSF);
                }

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Updates the colors of the progress bar based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            ProgressColor = colors.Flat;
        }
    }
}