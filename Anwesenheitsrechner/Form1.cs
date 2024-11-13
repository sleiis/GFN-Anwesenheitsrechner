using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using definitions;
using DynamicData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Anwesenheitsrechner
{
    public partial class Form1 : Form
    {
        private DateTime currentDate = new DateTime();
        public static Entry entry;
        private Entry[] entryList = new Entry[31];
        public static int EntryListCount = 0;
        ContextMenuStrip ListContext = new ContextMenuStrip();

        public Form1()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            year_select.SelectedIndex = (currentDate.Year) - 2024;
            month_select.SelectedIndex = (currentDate.Month) - 1;
            ListContext.Items.Add("bearbeiten");
            ListContext.Opening += checkListSelection;
            ListContext.ItemClicked += new ToolStripItemClickedEventHandler(this.ListContext_Click);
            ListContext.Items.Add("löschen");
            listView.ContextMenuStrip = ListContext;

        }

        private void ListContext_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip item = sender as ContextMenuStrip;
            ToolStripItemClickedEventArgs args = e as ToolStripItemClickedEventArgs;

            if (args.ClickedItem.Text == "bearbeiten")
            {
                int index = int.Parse(listView.SelectedItems[0].SubItems[0].Text);
                Form changeEntry = new Form2(index, true);
                MonthCalendar monthCalendar = changeEntry.Controls.Find("monthCalendar1", false)[0] as MonthCalendar;
                changeEntry.Text = "Eintrag ändern";
                changeEntry.Controls.Find("Button1", false)[0].Text = "Ändern";
                entry.location = (listView.SelectedItems[0].SubItems[1].Text == "Standort") ? 0 : 1;
                entry.index = index;
                //myDialog(listView.SelectedItems[0].SubItems[1].Text);
                entry.date = DateTime.Parse(listView.SelectedItems[0].SubItems[1].Text);
                monthCalendar.ShowTodayCircle = false;
                monthCalendar.SelectionStart = entry.date.Date;
                monthCalendar.SelectionEnd = entry.date.Date;
                changeEntry.FormClosed += EntryWorkForm_FormClosed;
                changeEntry.Show();
            }


        }

        private void checkListSelection(object sender, EventArgs e)
        {

                if (listView.SelectedItems.Count == 0)
                {
                    ListContext.Items[0].Enabled = false;
                    ListContext.Items[1].Enabled = false;
                }
                else if (listView.SelectedItems.Count == 1)
                {
                    ListContext.Items[0].Enabled = true;
                    ListContext.Items[1].Enabled = true;
                }
                else
                {
                ListContext.Items[0].Enabled = false;
                ListContext.Items[1].Enabled = true;
                }

        }

        private void myDialog(String text)
        {
            Form dialog = new Form();
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            dialog.Controls.Add(label);
            dialog.ShowDialog();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Form EntryWorkForm = new Form2(EntryListCount, false);
            EntryWorkForm.Show();
            EntryWorkForm.FormClosed += EntryWorkForm_FormClosed;

        }

        private void EntryWorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            String Date = entry.date.ToString("D");
            int index = entry.index;
            entryList.Replace(entryList.ElementAt(index), entry);
            String location;
            if (entry.location == 0)
            {
                location = "Standort";
            }
            else
            {
                location = "Homeoffice";
            }

            var item = new ListViewItem(index.ToString());  
            item.SubItems.Add(Date);
            item.SubItems.Add(location);
            //listView.Items.Remove(listView.FindItemWithText(index.ToString()));
            myDialog(index.ToString());
            if (listView.Items.Count == 0)
            {
                listView.Items.Add(item);
            }
            else
            {
                if (listView.Items.Count != index) listView.Items.Remove(listView.SelectedItems[0]);
                listView.Items.Insert(index, item);
                myDialog(listView.Items[index].SubItems[0].Text);
            }

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            Form EntryHolidayForm = new Form3();
            EntryHolidayForm.Show();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
