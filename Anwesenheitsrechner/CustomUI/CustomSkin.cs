using Anwesenheitsrechner.CustomUI.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom skin control for a form with advanced features such as custom colors and draggable header.
    /// </summary>
    public class CustomSkin : ContainerControl
    {
        private int W;
        private int H;
        private bool Cap = false;
        private Point MousePoint = new Point(0, 0);
        private readonly int MoveHeight = 50;

        /// <summary>
        /// Gets or sets the header color of the skin.
        /// </summary>
        [Category("Colors")]
        public Color HeaderColor { get; set; } = Color.FromArgb(24, 22, 43);

        /// <summary>
        /// Gets or sets the base color of the skin.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.FromArgb(35, 30, 59);

        /// <summary>
        /// Gets or sets the border color of the skin.
        /// </summary>
        [Category("Colors")]
        public Color BorderColor { get; set; } = Color.FromArgb(53, 58, 60);

        /// <summary>
        /// Gets or sets the flat color of the skin.
        /// </summary>
        [Category("Colors")]
        public Color FlatColor { get; set; } = Helpers.FlatColor;

        /// <summary>
        /// Gets or sets a value indicating whether the header can maximize the form.
        /// </summary>
        [Category("Options")]
        public bool HeaderMaximize { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSkin"/> class.
        /// </summary>
        public CustomSkin()
        {
            MouseDoubleClick += FormSkin_MouseDoubleClick;
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.White;
            Font = new Font("Tahoma", 12);
        }

        /// <summary>
        /// Handles the mouse down event to enable dragging the form.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MousePoint = e.Location;
            }
        }

        /// <summary>
        /// Handles the mouse double-click event to maximize or restore the form.
        /// </summary>
        private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (HeaderMaximize && e.Button == MouseButtons.Left && new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                var form = FindForm();
                if (form != null)
                {
                    form.WindowState = form.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
                    form.Refresh();
                }
            }
        }

        /// <summary>
        /// Handles the mouse up event to stop dragging the form.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        /// <summary>
        /// Handles the mouse move event to drag the form.
        /// </summary>
        /// <param name="e">The mouse event arguments.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MousePoint.X, MousePosition.Y - MousePoint.Y);
            }
        }

        /// <summary>
        /// Handles the creation of the control to set up the form properties.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            var form = ParentForm;
            if (form != null)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.AllowTransparency = false;
                form.TransparencyKey = Color.Fuchsia;
                form.StartPosition = FormStartPosition.CenterScreen;
                Dock = DockStyle.Fill;
                Invalidate();
            }
        }

        private readonly Color TextColor = Color.FromArgb(234, 234, 234);

        /// <summary>
        /// Paints the custom skin control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                W = Width;
                H = Height;

                var Base = new Rectangle(0, 0, W, H);
                var Header = new Rectangle(0, 0, W, 35);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                // Draw base
                G.FillRectangle(new SolidBrush(BaseColor), Base);

                // Draw header
                G.FillRectangle(new SolidBrush(HeaderColor), Header);

                // Draw text
                G.DrawString(Text, Font, new SolidBrush(TextColor), new Rectangle(10, 9, W, H), Helpers.NearSF);

                // Draw border
                G.DrawRectangle(new Pen(BorderColor), Base);

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }
    }
}