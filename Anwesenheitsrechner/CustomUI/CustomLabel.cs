using System;
using System.Drawing;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom label control with support for transparent background and default styling.
    /// </summary>
    public class CustomLabel : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLabel"/> class.
        /// </summary>
        public CustomLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Font = new Font("Tahoma", 10);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Handles the text changed event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate(); // Redraw the control when the text changes
        }
    }
}