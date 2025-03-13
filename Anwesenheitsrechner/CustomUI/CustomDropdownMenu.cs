using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom color table for the dropdown menu.
    /// </summary>
    public class MenuColorTable : ProfessionalColorTable
    {
        // Fields
        private readonly Color backColor;
        private readonly Color leftColumnColor;
        private readonly Color borderColor;
        private readonly Color menuItemBorderColor;
        private readonly Color menuItemSelectedColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuColorTable"/> class.
        /// </summary>
        /// <param name="isMainMenu">Indicates if it is the main menu.</param>
        /// <param name="primaryColor">The primary color.</param>
        public MenuColorTable(bool isMainMenu, Color primaryColor)
        {
            if (isMainMenu)
            {
                backColor = Color.FromArgb(37, 39, 60);
                leftColumnColor = Color.FromArgb(34, 39, 46);
                borderColor = Color.FromArgb(32, 33, 51);
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
            else
            {
                backColor = Color.White;
                leftColumnColor = Color.LightGray;
                borderColor = Color.LightGray;
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
        }

        // Overrides
        public override Color ToolStripDropDownBackground => backColor;
        public override Color MenuBorder => borderColor;
        public override Color MenuItemBorder => menuItemBorderColor;
        public override Color MenuItemSelected => menuItemSelectedColor;
        public override Color ImageMarginGradientBegin => leftColumnColor;
        public override Color ImageMarginGradientMiddle => leftColumnColor;
        public override Color ImageMarginGradientEnd => leftColumnColor;
    }
    /// <summary>
    /// Custom renderer for the dropdown menu.
    /// </summary>
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        // Fields
        private readonly Color primaryColor;
        private readonly Color textColor;
        private readonly int arrowThickness;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRenderer"/> class.
        /// </summary>
        /// <param name="isMainMenu">Indicates if it is the main menu.</param>
        /// <param name="primaryColor">The primary color.</param>
        /// <param name="textColor">The text color.</param>
        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            this.primaryColor = primaryColor;
            arrowThickness = isMainMenu ? 3 : 2;
            this.textColor = textColor == Color.Empty ? (isMainMenu ? Color.Gainsboro : Color.DimGray) : textColor;
        }

        // Overrides
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : textColor;
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            var graph = e.Graphics;
            var arrowSize = new Size(5, 12);
            var arrowColor = e.Item.Selected ? Color.White : primaryColor;
            var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2,
                arrowSize.Width, arrowSize.Height);

            using (var path = new GraphicsPath())
            using (var pen = new Pen(arrowColor, arrowThickness))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + (rect.Height / 2));
                path.AddLine(rect.Right, rect.Top + (rect.Height / 2), rect.Left, rect.Top + rect.Height);
                graph.DrawPath(pen, path);
            }
        }
    }
    /// <summary>
    /// Custom dropdown menu with advanced features such as custom colors and rendering.
    /// </summary>
    public class CustomDropdownMenu : ContextMenuStrip
    {
        // Fields
        private bool isMainMenu;
        private int menuItemHeight = 15;
        private Color menuItemTextColor = Color.Empty; // No color, The default color is set in the MenuRenderer class
        private Color primaryColor = Color.Empty; // No color, The default color is set in the MenuRenderer class
        private Bitmap menuItemHeaderSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDropdownMenu"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public CustomDropdownMenu(IContainer container) : base(container)
        {
        }

        // Properties
        [Category("1 CustomDropdownMenu Advance")]
        public bool IsMainMenu
        {
            get => isMainMenu;
            set => isMainMenu = value;
        }

        [Category("1 CustomDropdownMenu Advance")]
        public int MenuItemHeight
        {
            get => menuItemHeight;
            set => menuItemHeight = value;
        }

        [Category("1 CustomDropdownMenu Advance")]
        public Color MenuItemTextColor
        {
            get => menuItemTextColor;
            set => menuItemTextColor = value;
        }

        [Category("1 CustomDropdownMenu Advance")]
        public Color PrimaryColor
        {
            get => primaryColor;
            set => primaryColor = value;
        }

        // Private methods
        /// <summary>
        /// Loads the menu item height.
        /// </summary>
        private void LoadMenuItemHeight()
        {
            menuItemHeaderSize = new Bitmap(isMainMenu ? 25 : 20, menuItemHeight);

            // Start recursion on the top-level items
            foreach (ToolStripMenuItem menuItemL1 in Items)
            {
                SetMenuItemImage(menuItemL1);
            }
        }

        /// <summary>
        /// Sets the image for the menu item.
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        private void SetMenuItemImage(ToolStripMenuItem menuItem)
        {
            menuItem.ImageScaling = ToolStripItemImageScaling.None;
            if (menuItem.Image == null)
            {
                menuItem.Image = menuItemHeaderSize;
            }

            // Recursively set image for all nested menu items (DropDownItems)
            foreach (ToolStripMenuItem subMenuItem in menuItem.DropDownItems)
            {
                SetMenuItemImage(subMenuItem);
            }
        }

        // Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                Renderer = new MenuRenderer(isMainMenu, primaryColor, menuItemTextColor);
                LoadMenuItemHeight();
            }
        }
    }
}
