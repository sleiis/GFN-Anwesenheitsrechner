using definitions;
using System;
using System.Windows.Forms;

namespace Anwesenheitsrechner
{
    public partial class form_addedit : Form
    {
        form_Main mainform;
        private bool edit = false;

        public form_addedit(form_Main form_Main, bool edit)
        {
            InitializeComponent();
            mainform = form_Main;
            this.edit = edit;
            if (!edit)
            {
                mc_dateselect.SelectionStart = DateTime.Today;
                mc_dateselect.SelectionEnd = DateTime.Today;
            }
        }

        private void bt_cancel_clicked(Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void bt_add_clicked(Object sender, System.EventArgs e)
        {
            Entry entry = new Entry()
            {
                date = mc_dateselect.SelectionStart,
                sickday = cb_sickday.Checked,
                location = rb_pre.Checked ? 0 : rb_ho.Checked ? 1 : -1
            };

            if (edit) mainform.editEntry(entry);
            else mainform.addEntry(entry);

            this.Close();
        }

        private void rb_Location_changed(Object sender, System.EventArgs e)
        {
            rb_pre.Checked = !rb_ho.Checked;
        }

        private void changed_sickday(object sender, EventArgs e)
        {
            if (cb_sickday.Checked)
            {
                this.rb_pre.Enabled = false;
                this.rb_ho.Enabled = false;
            }
            else
            {
                this.rb_pre.Enabled = true;
                this.rb_ho.Enabled = true;
            }
        }
    }
}
