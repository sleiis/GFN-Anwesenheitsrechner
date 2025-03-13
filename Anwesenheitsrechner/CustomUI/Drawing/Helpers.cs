using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI.Drawing
{
    /// <summary>
    /// Provides helper methods for custom UI drawing.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Gets the flat color used in the UI.
        /// </summary>
        public static Color FlatColor { get; } = Color.FromArgb(22, 96, 253);

        /// <summary>
        /// Gets the flat white color used in the UI.
        /// </summary>
        public static Color FlatWhite { get; } = Color.FromArgb(255, 252, 255);

        /// <summary>
        /// Gets the string format for near alignment.
        /// </summary>
        public static readonly StringFormat NearSF = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near
        };

        /// <summary>
        /// Gets the string format for center alignment.
        /// </summary>
        public static readonly StringFormat CenterSF = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        /// <summary>
        /// Creates a rounded rectangle path.
        /// </summary>
        /// <param name="rectangle">The rectangle to round.</param>
        /// <param name="curve">The curve radius.</param>
        /// <returns>A <see cref="GraphicsPath"/> representing the rounded rectangle.</returns>
        public static GraphicsPath RoundRec(Rectangle rectangle, int curve)
        {
            var path = new GraphicsPath();
            var arcRectangleWidth = curve * 2;
            path.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
            path.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
            path.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0, 90);
            path.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90, 90);
            path.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return path;
        }

        /// <summary>
        /// Creates a rounded rectangle path with customizable corners.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle.</param>
        /// <param name="y">The y-coordinate of the rectangle.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        /// <param name="r">The radius of the corners.</param>
        /// <param name="tl">Whether the top-left corner is rounded.</param>
        /// <param name="tr">Whether the top-right corner is rounded.</param>
        /// <param name="br">Whether the bottom-right corner is rounded.</param>
        /// <param name="bl">Whether the bottom-left corner is rounded.</param>
        /// <returns>A <see cref="GraphicsPath"/> representing the rounded rectangle.</returns>
        public static GraphicsPath RoundRect(float x, float y, float w, float h, double r = 0.3, bool tl = true, bool tr = true, bool br = true, bool bl = true)
        {
            var path = new GraphicsPath();
            var d = Math.Min(w, h) * (float)r;
            var xw = x + w;
            var yh = y + h;

            if (tl) path.AddArc(x, y, d, d, 180, 90);
            else path.AddLine(x, y, x, y);

            if (tr) path.AddArc(xw - d, y, d, d, 270, 90);
            else path.AddLine(xw, y, xw, y);

            if (br) path.AddArc(xw - d, yh - d, d, d, 0, 90);
            else path.AddLine(xw, yh, xw, yh);

            if (bl) path.AddArc(x, yh - d, d, d, 90, 90);
            else path.AddLine(x, yh, x, yh);

            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Draws an arrow.
        /// </summary>
        /// <param name="x">The x-coordinate of the arrow.</param>
        /// <param name="y">The y-coordinate of the arrow.</param>
        /// <param name="flip">Whether to flip the arrow.</param>
        /// <returns>A <see cref="GraphicsPath"/> representing the arrow.</returns>
        public static GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            var path = new GraphicsPath();
            var w = 12;
            var h = 6;

            if (flip)
            {
                path.AddLine(x + 1, y, x + w + 1, y);
                path.AddLine(x + w, y, x + h, y + h - 1);
            }
            else
            {
                path.AddLine(x, y + h, x + w, y + h);
                path.AddLine(x + w, y + h, x + h, y);
            }

            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Gets the color scheme of a control from a parent <see cref="CustomSkin"/>.
        /// </summary>
        /// <param name="control">The control to get the color scheme from.</param>
        /// <returns>A <see cref="CustomColors"/> object representing the color scheme.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the control is null.</exception>
        public static CustomColors GetColors(Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            var colors = new CustomColors();

            while (control != null && control.GetType() != typeof(CustomSkin))
                control = control.Parent;

            if (control is CustomSkin skin)
                colors.Flat = skin.FlatColor;

            return colors;
        }
    }
}