using Anwesenheitsrechner.CustomUI.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom list box control with advanced features such as custom colors and owner-drawn items.
    /// </summary>
    public class CustomListBox : Control
    {
        private ListBox listBox;

        /// <summary>
        /// Gets or sets the items in the list box.
        /// </summary>
        [Category("Options")]
        public string[] Items
        {
            get => listBox.Items.Cast<string>().ToArray();
            set
            {
                listBox.Items.Clear();
                listBox.Items.AddRange(value);
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected item.
        /// </summary>
        [Category("Colors")]
        public Color SelectedColor { get; set; } = Helpers.FlatColor;

        /// <summary>
        /// Gets the selected item in the list box.
        /// </summary>
        public string SelectedItem => listBox.SelectedItem?.ToString();

        /// <summary>
        /// Gets the selected index in the list box.
        /// </summary>
        public int SelectedIndex => listBox.SelectedIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomListBox"/> class.
        /// </summary>
        public CustomListBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            listBox = new ListBox
            {
                DrawMode = DrawMode.OwnerDrawFixed,
                ScrollAlwaysVisible = false,
                HorizontalScrollbar = false,
                BorderStyle = BorderStyle.None,
                BackColor = BaseColor,
                ForeColor = Color.White,
                Location = new Point(3, 3),
                Font = new Font("Tahoma", 8),
                ItemHeight = 20,
                IntegralHeight = false
            };
            listBox.DrawItem += DrawItem;

            Controls.Add(listBox);
            Size = new Size(131, 101);
            BackColor = BaseColor;
        }

        /// <summary>
        /// Clears all items in the list box.
        /// </summary>
        public void Clear()
        {
            listBox.Items.Clear();
        }

        /// <summary>
        /// Clears the selected items in the list box.
        /// </summary>
        public void ClearSelected()
        {
            for (int i = listBox.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox.Items.Remove(listBox.SelectedItems[i]);
            }
        }

        /// <summary>
        /// Adds a range of items to the list box.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddRange(object[] items)
        {
            listBox.Items.AddRange(items);
        }

        /// <summary>
        /// Adds a single item to the list box.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(object item)
        {
            listBox.Items.Add(item);
        }

        /// <summary>
        /// Handles the draw item event to customize the appearance of the list box items.
        /// </summary>
        private void DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var itemText = " " + listBox.Items[e.Index].ToString();
            var itemBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(SelectedColor), itemBounds);
                e.Graphics.DrawString(itemText, new Font("Tahoma", 8), Brushes.White, itemBounds.X, itemBounds.Y + 2);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 53, 55)), itemBounds);
                e.Graphics.DrawString(itemText, new Font("Tahoma", 8), Brushes.White, itemBounds.X, itemBounds.Y + 2);
            }
        }

        /// <summary>
        /// Handles the creation of the control.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(listBox))
            {
                Controls.Add(listBox);
            }
        }

        /// <summary>
        /// Paints the list box control.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateColors();

            using (var B = new Bitmap(Width, Height))
            using (var G = Graphics.FromImage(B))
            {
                var Base = new Rectangle(0, 0, Width, Height);

                G.SmoothingMode = SmoothingMode.HighQuality;
                G.PixelOffsetMode = PixelOffsetMode.HighQuality;
                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                G.Clear(BackColor);

                // Set list box size
                listBox.Size = new Size(Width - 6, Height - 2);

                // Draw base
                G.FillRectangle(new SolidBrush(BaseColor), Base);

                base.OnPaint(e);
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
            }
        }

        /// <summary>
        /// Updates the colors of the list box based on the parent control.
        /// </summary>
        private void UpdateColors()
        {
            var colors = Helpers.GetColors(this);
            SelectedColor = colors.Flat;
        }

        private readonly Color BaseColor = Color.FromArgb(24, 22, 43);
    }
}