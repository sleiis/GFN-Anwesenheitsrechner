using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom progress bar control with advanced features such as custom colors, text, and border size.
    /// </summary>
    public class CustomProgressBar : ProgressBar
    {
        // Fields
        private bool seeLabel = true;
        private string labelText = "%";
        private bool maximumValue = false;
        private int fontSize = 10;
        private Color textColor = Color.FromArgb(45, 51, 59);
        private Color barColor = Color.FromArgb(83, 155, 245);
        private FontFamily textFont = new FontFamily("Segoe UI Semibold");
        private int borderSize = 0;

        // Properties
        [Category("1 CustomProgressBar Advance")]
        public FontFamily TextFont
        {
            get => textFont;
            set
            {
                textFont = value;
                Invalidate();
            }
        }

        [Category("1 CustomProgressBar Advance")]
        public string LabelText
        {
            get => labelText;
            set
            {
                labelText = value;
                Invalidate();
            }
        }

        [Category("1 CustomProgressBar Advance")]
        public bool MaximumValue
        {
            get => maximumValue;
            set
            {
                maximumValue = value;
                Invalidate();
            }
        }

        [Category("1 CustomProgressBar Advance")]
        public bool ShowStatus
        {
            get => seeLabel;
            set
            {
                seeLabel = value;
                Invalidate();
            }
        }

        [Category("1 CustomProgressBar Advance")]
        public int FontSize
        {
            get => fontSize;
            set
            {
                fontSize = value;
                Invalidate();
            }
        }

        [Category("1 CustomProgressBar Advance")]
        public Color TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                Invalidate();
            }
        }

        [Category("1 CustomProgressBar Advance")]
        public Color BarColor
        {
            get => barColor;
            set
            {
                barColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomProgressBar"/> class.
        /// </summary>
        public CustomProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// Fixes flickering by enabling double buffering.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return handleParam;
            }
        }

        /// <summary>
        /// Paints the progress bar control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the progress bar
            using (var barBrush = new SolidBrush(BarColor))
            {
                var rec = e.ClipRectangle;
                rec.Width = (int)(rec.Width * ((double)Value / Maximum));
                e.Graphics.FillRectangle(barBrush, 0, 0, rec.Width, rec.Height);
            }

            // Draw the text
            if (seeLabel)
            {
                using (var font = new Font(textFont, fontSize))
                {
                    string text = maximumValue ? $"{Value} {labelText} / {Maximum} {labelText}" : $"{Value} {labelText}";
                    var textSize = e.Graphics.MeasureString(text, font);
                    var textLocation = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2);
                    using (var textBrush = new SolidBrush(TextColor))
                    {
                        e.Graphics.DrawString(text, font, textBrush, textLocation);
                    }
                }
            }

            // Draw the border
            using (var penBorder = new Pen(Color.Black, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}