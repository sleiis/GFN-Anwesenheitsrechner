using Anwesenheitsrechner.CustomUI.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom context menu strip with advanced features such as custom colors and rendering.
    /// </summary>
    public class CustomContextMenuStrip : ContextMenuStrip
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomContextMenuStrip"/> class.
        /// </summary>
        public CustomContextMenuStrip()
            : base()
        {
            Renderer = new ToolStripProfessionalRenderer(new TColorTable());
            ShowImageMargin = false;
            ForeColor = Color.White;
            Font = new Font("Tahoma", 8);
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
        /// Paints the context menu strip.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        /// <summary>
        /// Custom color table for the context menu strip.
        /// </summary>
        public class TColorTable : ProfessionalColorTable
        {
            /// <summary>
            /// Gets or sets the background color.
            /// </summary>
            [Category("Colors")]
            public Color BackColor { get; set; } = Color.FromArgb(24, 22, 43);

            /// <summary>
            /// Gets or sets the checked color.
            /// </summary>
            [Category("Colors")]
            public Color CheckedColor { get; set; } = Helpers.FlatColor;

            /// <summary>
            /// Gets or sets the border color.
            /// </summary>
            [Category("Colors")]
            public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

            public override Color ButtonSelectedBorder => BackColor;
            public override Color CheckBackground => CheckedColor;
            public override Color CheckPressedBackground => CheckedColor;
            public override Color CheckSelectedBackground => CheckedColor;
            public override Color ImageMarginGradientBegin => CheckedColor;
            public override Color ImageMarginGradientEnd => CheckedColor;
            public override Color ImageMarginGradientMiddle => CheckedColor;
            public override Color MenuBorder => BorderColor;
            public override Color MenuItemBorder => BorderColor;
            public override Color MenuItemSelected => CheckedColor;
            public override Color SeparatorDark => BorderColor;
            public override Color ToolStripDropDownBackground => BackColor;
        }
    }
}