using System;
using System.Drawing;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    public class CustomLabel : Label
    {
        protected override void OnTextChanged( EventArgs e )
        {
            base.OnTextChanged( e );
            Invalidate();
        }

        public CustomLabel()
        {
            SetStyle( ControlStyles.SupportsTransparentBackColor, true );
            Font = new Font( "Tahoma", 10 );
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Text = Text;
        }
    }
}