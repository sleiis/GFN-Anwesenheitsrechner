using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using definitions;

namespace Anwesenheitsrechner
{
    public partial class Form1 : Form
    {
        private DateTime currentDate = new DateTime();
        public static Entry entry;
        public static bool isChange;
        ContextMenuStrip ListContext = new ContextMenuStrip();
        DataHandler DataHandler = new DataHandler();

        public Form1()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            ListContext.Items.Add("bearbeiten");
            ListContext.Opening += checkListSelection;
            ListContext.ItemClicked += new ToolStripItemClickedEventHandler(this.ListContext_Click);
            ListContext.Items.Add("löschen");
            listView.ContextMenuStrip = ListContext;
            DataHandler.readSettings();
            initListView();
            listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void initListView()
        {
            int EntryCount = int.Parse(DataHandler.readSQL("Select count(*) From Data;").GetValues(0).ElementAt(0));
            for (int i = 0; i < EntryCount; i++)
            {
                NameValueCollection entry = DataHandler.readSQL("Select * From Data where rowid=" + (i + 1) + ";");
                String Date = DateTime.Parse(entry.GetValues(0).ElementAt(0)).ToString("D");
                String location = entry.GetValues(1).ElementAt(0);
                String sickday = (entry.GetValues(2).ElementAt(0)) == "1" ? "Ja" : "Nein";
                var item = new ListViewItem(Date);
                item.SubItems.Add(location);
                item.SubItems.Add(sickday);
                listView.Items.Add(item);
            }
            calculateRatio();

            ListViewItemColumnSorter columnSorter = new ListViewItemColumnSorter();
            listView.ListViewItemSorter = columnSorter;

            listView.Sort();
            listView.ListViewItemSorter = null;

        }

        private void calculateRatio()
        {
            int Count = 0;
            int homeCount = 0;
            int workCount = 0;

            foreach (ListViewItem item in listView.Items)
            {
                //myDialog(item.SubItems[2].Text);
                if (item.SubItems[1].Text == "Standort")
                {
                    workCount++;
                    Count++;
                }
                if (item.SubItems[1].Text == "Homeoffice")
                {
                    homeCount++;
                    Count++;
                }
            }

            if (Count == 0) return;

            if (homeCount > 0) stat_total_ho.Text = (Math.Round((float)homeCount * 100/ Count,2)) + "%";
            if (workCount > 0) stat_total_pre.Text = (Math.Round((float)workCount * 100 / Count,2)) + "%";
            //label11.Text = ((workCount / Count) * 100).ToString() + "%";
        }

        private void ListContext_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip item = sender as ContextMenuStrip;
            ToolStripItemClickedEventArgs args = e as ToolStripItemClickedEventArgs;

            if (args.ClickedItem.Text == "bearbeiten")
            {
                /*
                int index = listView.SelectedItems[0].Index;
                Form changeEntry = new Form2(index, true);
                MonthCalendar monthCalendar = changeEntry.Controls.Find("monthCalendar1", false)[0] as MonthCalendar;
                changeEntry.Text = "Eintrag ändern";
                changeEntry.Controls.Find("Button1", false)[0].Text = "Ändern";
                entry.location = (listView.SelectedItems[0].SubItems[1].Text == "Standort") ? 0 : 1;
                entry.index = index;
                //myDialog(listView.SelectedItems[0].SubItems[1].Text);
                entry.date = DateTime.Parse(listView.SelectedItems[0].SubItems[0].Text);
                monthCalendar.ShowTodayCircle = false;
                monthCalendar.SelectionStart = entry.date.Date;
                monthCalendar.SelectionEnd = entry.date.Date;
                changeEntry.FormClosed += EntryWorkForm_FormClosed;
                changeEntry.Show();
                */
                DialogResult dialogResult = MessageBox.Show("Noch nicht implementiert", "Entwicklernachricht", MessageBoxButtons.OK);

            }
            if (args.ClickedItem.Text == "löschen")
            {
                DataHandler.writeSQL("Delete From Data where date = '" + listView.SelectedItems[0].SubItems[0].Text + "';");
                listView.Items.RemoveAt(listView.SelectedItems[0].Index);
                calculateRatio();
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
            Form EntryWorkForm = new Form2(listView.Columns[1].Index, false);
            EntryWorkForm.Show();
            EntryWorkForm.FormClosed += EntryWorkForm_FormClosed;

        }

        private void EntryWorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            String Date = entry.date.ToString("D");
            String location;
            bool sickday = false;
            

            if (entry.location == 0)
            {
                location = "Standort";
            }
            else
            {
                location = "Homeoffice";
            }
            if (entry.sickday == true)
            {
                location = "--";
                sickday = true;
            }

            var item = new ListViewItem(Date);
            item.SubItems.Add(location);
            item.SubItems.Add(sickday ? "Ja" : "Nein");
            //listView.Items.Remove(listView.FindItemWithText(index.ToString()));
            //myDialog(index.ToString());
            if (isChange)
            {
                //int x = listView.SelectedItems[0].Index;
                //listView.Items.RemoveAt(x);
                //listView.Items.Insert(x, item);

            }
            else
            {
                listView.Items.Add(item);
                //myDialog(listView.Items[index].SubItems[0].Text);
            }


            //listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //listView.Columns[2].Width = 50;
            calculateRatio();
            ListViewItemColumnSorter columnSorter = new ListViewItemColumnSorter();
            listView.ListViewItemSorter = columnSorter;

            listView.Sort();
            listView.ListViewItemSorter = null;

            // SQL
            
            DataHandler.writeSQL("Insert Into 'Data' (date,location,sickday) Values ('" + entry.date.ToShortDateString() + "', '" + location + "', " + entry.sickday.ToString() + ");");
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            Form EntryHolidayForm = new Form3();
            EntryHolidayForm.Show();
        }

        public class ListViewItemColumnSorter : IComparer
        {
            public int curColumn = 0;
            public bool int_mode = false;
            public int Compare(object x, object y)
            {
                string a = ((ListViewItem)x).SubItems[curColumn].Text;
                string b = ((ListViewItem)y).SubItems[curColumn].Text;
                if (int_mode)
                    return int.Parse(a) - int.Parse(b);
                else
                    return DateTime.Compare(DateTime.Parse(a), DateTime.Parse(b));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
