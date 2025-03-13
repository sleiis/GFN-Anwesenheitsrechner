using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom combo box control with advanced features such as custom colors, border size, and icon.
    /// </summary>
    [DefaultEvent("OnSelectedIndexChanged")]
    public class CustomComboBox : UserControl
    {
        // Fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;

        // Items
        private readonly ComboBox cmbList;
        private readonly Label lblText;
        private readonly Button btnIcon;

        // Events
        public event EventHandler OnSelectedIndexChanged; // Default event

        // Constructor
        public CustomComboBox()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            SuspendLayout();

            // ComboBox: Dropdown list
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += ComboBox_SelectedIndexChanged; // Default event
            cmbList.TextChanged += ComboBox_TextChanged; // Refresh text

            // Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += Icon_Click; // Open dropdown list
            btnIcon.Paint += Icon_Paint; // Draw icon

            // Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(Font.Name, 10F);
            // Attach label events to user control event
            lblText.Click += Surface_Click; // Select combo box
            lblText.MouseEnter += Surface_MouseEnter;
            lblText.MouseLeave += Surface_MouseLeave;

            // User Control
            Controls.Add(lblText); // 2
            Controls.Add(btnIcon); // 1
            Controls.Add(cmbList); // 0
            MinimumSize = new Size(200, 27); // Less than 27 have a glitch
            Size = new Size(200, 27);
            ForeColor = Color.DimGray;
            Padding = new Padding(borderSize); // Border Size
            Font = new Font(Font.Name, 10F);
            base.BackColor = borderColor; // Border Color
            ResumeLayout();
            AdjustComboBoxDimensions();
        }

        // Properties
        // Appearance
        [Category("1 CustomComboBox - Properties")]
        public new Color BackColor
        {
            get => backColor;
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public Color IconColor
        {
            get => iconColor;
            set
            {
                iconColor = value;
                btnIcon.Invalidate(); // Redraw icon
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public Color ListBackColor
        {
            get => listBackColor;
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public Color ListTextColor
        {
            get => listTextColor;
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                base.BackColor = borderColor; // Border Color
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Padding = new Padding(borderSize); // Border Size
                AdjustComboBoxDimensions();
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value; // Optional
            }
        }

        [Category("1 CustomComboBox - Properties")]
        public string Texts
        {
            get => lblText.Text;
            set => lblText.Text = value;
        }

        [Category("1 CustomComboBox - Properties")]
        public ComboBoxStyle DropDownStyle
        {
            get => cmbList.DropDownStyle;
            set
            {
                if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
                    cmbList.DropDownStyle = value;
            }
        }

        // Data
        [Category("1 CustomComboBox - Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items => cmbList.Items;

        [Category("1 CustomComboBox - Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get => cmbList.DataSource;
            set => cmbList.DataSource = value;
        }

        [Category("1 CustomComboBox - Data")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => cmbList.AutoCompleteCustomSource;
            set => cmbList.AutoCompleteCustomSource = value;
        }

        [Category("1 CustomComboBox - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get => cmbList.AutoCompleteSource;
            set => cmbList.AutoCompleteSource = value;
        }

        [Category("1 CustomComboBox - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get => cmbList.AutoCompleteMode;
            set => cmbList.AutoCompleteMode = value;
        }

        [Category("1 CustomComboBox - Data")]
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get => cmbList.SelectedItem;
            set => cmbList.SelectedItem = value;
        }

        [Category("1 CustomComboBox - Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => cmbList.SelectedIndex;
            set => cmbList.SelectedIndex = value;
        }

        [Category("1 CustomComboBox - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get => cmbList.DisplayMember;
            set => cmbList.DisplayMember = value;
        }

        [Category("1 CustomComboBox - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get => cmbList.ValueMember;
            set => cmbList.ValueMember = value;
        }

        // Private methods
        /// <summary>
        /// Adjusts the dimensions of the combo box.
        /// </summary>
        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point(Width - Padding.Right - cmbList.Width, lblText.Bottom - cmbList.Height);
        }

        // Event methods
        /// <summary>
        /// Handles the selected index changed event of the combo box.
        /// </summary>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged?.Invoke(sender, e);
            lblText.Text = cmbList.Text; // Refresh text
        }

        /// <summary>
        /// Draws the icon on the button.
        /// </summary>
        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;

            // Draw arrow down icon
            using (var path = new GraphicsPath())
            using (var pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }

        /// <summary>
        /// Handles the click event of the icon button.
        /// </summary>
        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true; // Open dropdown list
        }

        /// <summary>
        /// Handles the click event of the surface (label).
        /// </summary>
        private void Surface_Click(object sender, EventArgs e)
        {
            OnClick(e);
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                cmbList.DroppedDown = true; // Open dropdown list
            }
        }

        /// <summary>
        /// Handles the text changed event of the combo box.
        /// </summary>
        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text; // Refresh text
        }

        /// <summary>
        /// Handles the mouse leave event of the surface (label).
        /// </summary>
        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        /// <summary>
        /// Handles the mouse enter event of the surface (label).
        /// </summary>
        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        /// <summary>
        /// Handles the resize event of the control.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
