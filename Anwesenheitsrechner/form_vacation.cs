using System;
using System.Windows.Forms;

namespace Anwesenheitsrechner
{
    public partial class form_vacation : Form
    {
        form_Main mainform;
        public form_vacation(form_Main form_Main)
        {
            InitializeComponent();
            mainform = form_Main;
        }

        private void Button2_clicked(Object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
