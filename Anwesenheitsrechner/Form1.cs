using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using definitions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Anwesenheitsrechner
{
    public partial class Form1 : Form
    {
        private DateTime currentDate = new DateTime();
        public static Entry entry;
        ContextMenuStrip ListContext = new ContextMenuStrip();

        public Form1()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            year_select.SelectedIndex = (currentDate.Year) - 2024;
            month_select.SelectedIndex = (currentDate.Month) - 1;
            ListContext.Items.Add("bearbeiten");
            ListContext.Opening += checkListSelection;
            ListContext.ItemClicked += ListContext_Click;
            ListContext.Items.Add("löschen");
            listView.ContextMenuStrip = ListContext;

        }

        private void ListContext_Click(object sender, EventArgs e)
        {
            ContextMenuStrip item = sender as ContextMenuStrip;
            ToolStripItemClickedEventArgs args = e as ToolStripItemClickedEventArgs;

            if (args.ClickedItem.Text == "bearbeiten")
            {
                if (listView.SelectedItems.Count == 0)
                {

                }
            }


        }

        private void checkListSelection(object sender, EventArgs e)
        {

                if (listView.SelectedItems.Count == 0)
                {
                    ListContext.Items[0].Enabled = false;
                    ListContext.Items[1].Enabled = false;
            }
                else
                {
                ListContext.Items[0].Enabled = true;
                ListContext.Items[1].Enabled = true;
            }

        }

        private void myDialog()
        {
            Form dialog = new Form();
            Label text = new Label();
            text.Text = "";
            text.AutoSize = true;
            dialog.Controls.Add(text);
            dialog.ShowDialog();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Form EntryWorkForm = new Form2();
            EntryWorkForm.Show();
            EntryWorkForm.FormClosed += EntryWorkForm_FormClosed;

        }

        private void EntryWorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            String Date = entry.date.ToString("D");
            String index = entry.date.Day.ToString();
            String location;
            if (entry.isSet)
            {
                if (entry.location == 0)
                {
                    location = "Standort";
                }
                else
                {
                    location = "Homeoffice";
                }
                entry.isSet = false;
            }
            else
            {
                return;
            }
            var item = new ListViewItem(index);  
            item.SubItems.Add(Date);
            item.SubItems.Add(location);
            listView.Items.Add(item);
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
