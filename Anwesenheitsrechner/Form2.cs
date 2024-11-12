using definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anwesenheitsrechner
{
    public partial class Form2 : Form
    {
        DateTime selectedDate;
        private bool isFilled = false;
        Entry entry;
        public Form2()
        {
            InitializeComponent();
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
        }

        private void Button2_clicked(Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Button1_clicked(Object sender, System.EventArgs e)
        {
            isFilled = true;
            transferEntry();
            this.Close();
        }

        private void handleCheckList(Object sender, System.EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }
        public void transferEntry()
        {
            if (isFilled)
            {
                entry.isSet = true;
                entry.date = selectedDate;
                entry.isVacation = false;
                entry.isHoliday = false;
                entry.isWork = true;
                entry.location = (radioButton1.Checked == true) ? 0 : 1;
            }
            Form1.entry = this.entry;
        }
    }
}
