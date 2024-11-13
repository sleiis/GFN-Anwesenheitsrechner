﻿using definitions;
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
        private int index;
        bool isChange;
        Entry entry;
        public Form2(int index, bool isChange)
        {
            InitializeComponent();
            this.index = index;
            this.isChange = isChange;
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
            if (!isChange)
            {
                Form1.EntryListCount++;
            }
            transferEntry();
            this.Close();
        }

        private void handleCheckList(Object sender, System.EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }
        public void transferEntry()
        {
            {
                entry.index = index;
                entry.date = monthCalendar1.SelectionStart;
                entry.isVacation = false;
                entry.isHoliday = false;
                entry.isWork = true;
                entry.location = (radioButton1.Checked == true) ? 0 : 1;
            }
            Form1.entry = this.entry;
        }

    }
}
