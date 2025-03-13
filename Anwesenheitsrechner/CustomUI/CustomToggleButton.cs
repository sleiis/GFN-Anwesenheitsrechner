using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom toggle button control with advanced features such as custom colors and styles.
    /// </summary>
    public class CustomToggleButton : CheckBox
    {
        // Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        // Properties
        [Category("1 CustomToggleButton Advance")]
        public Color OnBackColor
        {
            get => onBackColor;
            set
            {
                onBackColor = value;
                Invalidate(); // Redraw the control when the color changes
            }
        }

        [Category("1 CustomToggleButton Advance")]
        public Color OnToggleColor
        {
            get => onToggleColor;
            set
            {
                onToggleColor = value;
                Invalidate(); // Redraw the control when the color changes
            }
        }

        [Category("1 CustomToggleButton Advance")]
        public Color OffBackColor
        {
            get => offBackColor;
            set
            {
                offBackColor = value;
                Invalidate(); // Redraw the control when the color changes
            }
        }

        [Category("1 CustomToggleButton Advance")]
        public Color OffToggleColor
        {
            get => offToggleColor;
            set
            {
                offToggleColor = value;
                Invalidate(); // Redraw the control when the color changes
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        [Category("1 CustomToggleButton Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get => solidStyle;
            set
            {
                solidStyle = value;
                Invalidate(); // Redraw the control when the style changes
            }
        }

        // Constructor
        public CustomToggleButton()
        {
            MinimumSize = new Size(45, 22);
        }

        // Methods
        /// <summary>
        /// Gets the graphics path for the toggle button.
        /// </summary>
        /// <returns>The graphics path.</returns>
        private GraphicsPath GetFigurePath()
        {
            int arcSize = Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(Width - arcSize - 2, 0, arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Paints the toggle button control.
        /// </summary>
        /// <param name="pevent">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(Parent.BackColor);

            if (Checked) // ON
            {
                // Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());

                // Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                    new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize));
            }
            else // OFF
            {
                // Draw the control surface
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());

                // Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}