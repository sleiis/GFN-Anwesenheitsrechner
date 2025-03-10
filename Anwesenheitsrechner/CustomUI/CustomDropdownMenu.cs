﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    public class MenuColorTable : ProfessionalColorTable
    {
        //Fields
        private readonly Color backColor;
        private readonly Color leftColumnColor;
        private readonly Color borderColor;
        private readonly Color menuItemBorderColor;
        private readonly Color menuItemSelectedColor;
        //Constructor
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
        //Overrides
        public override Color ToolStripDropDownBackground { get { return backColor; } }
        public override Color MenuBorder { get { return borderColor; } }
        public override Color MenuItemBorder { get { return menuItemBorderColor; } }
        public override Color MenuItemSelected { get { return menuItemSelectedColor; } }
        public override Color ImageMarginGradientBegin { get { return leftColumnColor; } }
        public override Color ImageMarginGradientMiddle { get { return leftColumnColor; } }
        public override Color ImageMarginGradientEnd { get { return leftColumnColor; } }
    }
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        //Fields
        private readonly Color primaryColor;
        private readonly Color textColor;
        private readonly int arrowThickness;
        //Constructor
        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            this.primaryColor = primaryColor;
            if (isMainMenu)
            {
                arrowThickness = 3;
                if (textColor == Color.Empty) //Set Default Color
                    this.textColor = Color.Gainsboro;
                else//Set custom text color 
                    this.textColor = textColor;
            }
            else
            {
                arrowThickness = 2;
                if (textColor == Color.Empty) //Set Default Color
                    this.textColor = Color.DimGray;
                else//Set custom text color
                    this.textColor = textColor;
            }
        }
        //Overrides
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : textColor;
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            //Fields
            var graph = e.Graphics;
            var arrowSize = new Size(5, 12);
            var arrowColor = e.Item.Selected ? Color.White : primaryColor;
            var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2,
                arrowSize.Width, arrowSize.Height);
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(arrowColor, arrowThickness))
            {
                //Drawing
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + (rect.Height / 2));
                path.AddLine(rect.Right, rect.Top + (rect.Height / 2), rect.Left, rect.Top + rect.Height);
                graph.DrawPath(pen, path);
            }
        }
    }
    public class CustomDropdownMenu : ContextMenuStrip
    {
        //Fields
        private bool isMainMenu;
        private int menuItemHeight = 15;
        private Color menuItemTextColor = Color.Empty; //No color, The default color is set in the MenuRenderer class
        private Color primaryColor = Color.Empty; //No color, The default color is set in the MenuRenderer class
        private Bitmap menuItemHeaderSize;
        //Constructor
        public CustomDropdownMenu(IContainer container) : base(container)
        {
        }
        //Properties
        //Optionally, hide the properties in the toolbox to avoid the problem of displaying and/or 
        //saving control property changes in the designer at design time in Visual Studio.
        //If the problem I mention does not occur you can expose the properties and manipulate them from the toolbox.
        //[Browsable(false)]
        [Category("1 CustomDropdownMenu Advance")]
        public bool IsMainMenu
        {
            get { return isMainMenu; }
            set { isMainMenu = value; }
        }
        //[Browsable(false)]
        [Category("1 CustomDropdownMenu Advance")]
        public int MenuItemHeight
        {
            get { return menuItemHeight; }
            set { menuItemHeight = value; }
        }
        //[Browsable(false)]
        [Category("1 CustomDropdownMenu Advance")]
        public Color MenuItemTextColor
        {
            get { return menuItemTextColor; }
            set { menuItemTextColor = value; }
        }
        //[Browsable(false)]
        [Category("1 CustomDropdownMenu Advance")]
        public Color PrimaryColor
        {
            get { return primaryColor; }
            set { primaryColor = value; }
        }
        //Private methods
        private void LoadMenuItemHeight()
        {
            if (isMainMenu)
                menuItemHeaderSize = new Bitmap(25, menuItemHeight);
            else
                menuItemHeaderSize = new Bitmap(20, menuItemHeight);

            // Start recursion on the top-level items
            foreach (ToolStripMenuItem menuItemL1 in this.Items)
            {
                SetMenuItemImage(menuItemL1);
            }
        }

        private void SetMenuItemImage(ToolStripMenuItem menuItem)
        {
            // Set image for the current menu item (using the regular null check)
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

        //Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode == false)
            {
                this.Renderer = new MenuRenderer(isMainMenu, primaryColor, menuItemTextColor);
                LoadMenuItemHeight();
            }
        }
    }
}
