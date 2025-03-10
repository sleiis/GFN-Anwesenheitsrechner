using definitions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;


namespace Anwesenheitsrechner
{
    public partial class form_Main : Form
    {
        public static Settings settings;
        ContextMenuStrip ListContext = new ContextMenuStrip();
        DataHandler DataHandler = new DataHandler();

        public form_Main()
        {
            DataHandler.readSettings();
            InitializeComponent();
            initListView();

        }

        // Setup Functions
        private void initListView()
        {
            // Setup ListView Context Menu
            ListContext.Items.Add("bearbeiten").Name = "edit";
            ListContext.Items.Add("löschen").Name = "delete";
            ListContext.Opening += ContexListHandler;
            ListContext.ItemClicked += new ToolStripItemClickedEventHandler(this.ListContext_clicked);
            listView.ContextMenuStrip = ListContext;

            int EntryCount = int.Parse(DataHandler.readSQL("Select count(*) From Data;").GetValues(0).ElementAt(0));

            // Read Data from SQL and add to ListView
            for (int i = 0; i < EntryCount; i++)
            {
                NameValueCollection entry = DataHandler.readSQL($"Select Distinct * From Data where rowid = {i + 1};");
                String Date = DateTime.Parse(entry.GetValues(0).ElementAt(0)).ToString("D");
                String location = entry.GetValues(1).ElementAt(0);
                String sickday = (entry.GetValues(2).ElementAt(0)) == "1" ? "Ja" : "Nein";
                var item = new ListViewItem(Date);
                item.SubItems.Add(location);
                item.SubItems.Add(sickday);
                item.Name = Date;
                listView.Items.Add(item);
            }

            calculateDayRatio();

            // Init Column Sorter and Sort
            ListViewItemColumnSorter columnSorter = new ListViewItemColumnSorter();
            listView.ListViewItemSorter = columnSorter;
            listView.Sort();

            listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);


        }


        // Event Functions
        private void bt_vacation_clicked(object sender, System.EventArgs e)
        {
            Form EntryHolidayForm = new form_vacation(this);
            EntryHolidayForm.Show();
        }


        private void bt_settings_clicked(object sender, EventArgs e)
        {
            Form SettingsForm = new form_Settings(this);
            SettingsForm.Show();
        }

        private void bt_addEntry_clicked(object sender, System.EventArgs e)
        {
            Form EntryWorkForm = new form_addedit(this, false);
            EntryWorkForm.Show();

        }

        private void ListContext_clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip item = sender as ContextMenuStrip;
            ToolStripItemClickedEventArgs args = e as ToolStripItemClickedEventArgs;

            if (args.ClickedItem.Name == "edit")
            {

                int index = listView.SelectedItems[0].Index;
                Form changeEntry = new form_addedit(this, true);
                MonthCalendar monthCalendar = changeEntry.Controls.Find("mc_dateselect", false)[0] as MonthCalendar;
                changeEntry.Text = "Eintrag ändern";
                changeEntry.Controls.Find("bt_add", false)[0].Text = "Ändern";

                if (listView.SelectedItems[0].SubItems[1].Text == "Standort")
                {
                    changeEntry.Controls.Find("rb_pre", false)[0].Select();
                }
                else if (listView.SelectedItems[0].SubItems[1].Text == "Homeoffice")
                {
                    changeEntry.Controls.Find("rb_ho", false)[0].Select();
                }
                else if (listView.SelectedItems[0].SubItems[2].Text == "Ja")
                {
                    changeEntry.Controls.Find("cb_sickday", false)[0].Select();
                    changeEntry.Controls.Find("rb_pre", false)[0].Enabled = false;
                    changeEntry.Controls.Find("rb_ho", false)[0].Enabled = false;
                }

                monthCalendar.ShowTodayCircle = false;
                monthCalendar.SelectionStart = DateTime.Parse(listView.SelectedItems[0].Text);
                monthCalendar.SelectionEnd = DateTime.Parse(listView.SelectedItems[0].Text);
                changeEntry.Show();

            }

            if (args.ClickedItem.Name == "delete")
            {
                deleteEntry(listView.SelectedItems);
                calculateDayRatio();
            }



        }

        private void ContexListHandler(object sender, EventArgs e)
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


        // Custom Dialog
        private void myDialog(String text)
        {
            Form dialog = new Form();
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            dialog.Controls.Add(label);
            dialog.ShowDialog();
        }

        //Logic Functions
        private void calculateDayRatio()
        {
            int dayCount = 0;
            int homeCount = 0;
            int workCount = 0;

            foreach (ListViewItem item in listView.Items)
            {
                if (item.SubItems[1].Text == "Standort")
                {
                    workCount++;
                    dayCount++;
                }
                if (item.SubItems[1].Text == "Homeoffice")
                {
                    homeCount++;
                    dayCount++;
                }
            }

            if (dayCount == 0) return;
            if (homeCount > 0) stat_total_ho.Text = (Math.Round((float)homeCount * 100 / dayCount, 2)) + "%";
            if (workCount > 0) stat_total_pre.Text = (Math.Round((float)workCount * 100 / dayCount, 2)) + "%";
        }

        public void addEntry(Entry entry)
        {
            String Date = entry.date.ToString("D");
            if (listView.Items.ContainsKey(Date))
            {
                DialogResult dialogResult = MessageBox.Show("Datum existiert bereits", "Duplikat", MessageBoxButtons.OK);
                return;
            }

            String location;
            bool sickday = false;
            var item = new ListViewItem(Date);


            location = (entry.location == 0) ? "Standort" : "Homeoffice";
            if (entry.sickday == true)
            {
                location = "--";
                sickday = true;
            }

            item.Name = Date;
            item.SubItems.Add(location);
            item.SubItems.Add(sickday ? "Ja" : "Nein");

            listView.Items.Add(item);
            DataHandler.writeSQL($"Insert Into 'Data' (date,location,sickday) Values (' {entry.date.ToShortDateString()}', '{location}', {entry.sickday.ToString()});");

            calculateDayRatio();
            listView.Sort();
        }

        public void editEntry(Entry entry)
        {
            String Date = entry.date.ToString("D");
            String location;
            var item = new ListViewItem(Date);


            location = (entry.location == 0) ? "Standort" : "Homeoffice";
            if (entry.sickday == true) location = "--";

            item.Name = Date;
            item.SubItems.Add(location);
            item.SubItems.Add(entry.sickday ? "Ja" : "Nein");

            int x = listView.SelectedItems[0].Index;
            DataHandler.writeSQL($"Update Data Set 'location' = '{location}', 'sickday' = {entry.sickday.ToString()}, 'date' = '{ entry.date.ToShortDateString()}' where date = '{DateTime.Parse(listView.Items[x].Text).ToShortDateString()}';");
            listView.Items.RemoveAt(x);
            listView.Items.Insert(x, item);
        }

        public void deleteEntry(ListView.SelectedListViewItemCollection items)
        {
            int count = items.Count;
            for (int i = 0; i < count; i++)
            {
                DataHandler.writeSQL($"Delete From Data where date = '{DateTime.Parse(items[0].Text).ToShortDateString()}';");
                listView.Items.Remove(items[0]);
            }
        }

        public void addfromWeb(List<Entry> entries)
        {
            // Parse Web
            foreach (Entry entry in entries)
            {
                addEntry(entry);
            }

            listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /*        private void EntryWorkForm_FormClosed(object sender, FormClosedEventArgs e)
                {
                    if (!entry.isActive) return;
                    String Date = entry.date.ToString("D");
                    if (listView.Items.ContainsKey(Date) && !isChange)
                    {
                        DialogResult dialogResult = MessageBox.Show("Datum existiert bereits", "Duplikat",  MessageBoxButtons.OK);
                        return;
                    }
                    String location;
                    bool sickday = false;
                    var item = new ListViewItem(Date);


                    location = (entry.location == 0) ? "Standort" : "Homeoffice";
                    if (entry.sickday == true)
                    {
                        location = "--";
                        sickday = true;
                    }

                    item.Name = Date;
                    item.SubItems.Add(location);
                    item.SubItems.Add(sickday ? "Ja" : "Nein");


                    if (isChange)
                    {


                    }
                    else
                    {
                        listView.Items.Add(item);
                        DataHandler.writeSQL("Insert Into 'Data' (date,location,sickday) Values ('" + entry.date.ToShortDateString() + "', '" + location + "', " + entry.sickday.ToString() + ");");
                    }

                    entry.isActive = false;

                    calculateDayRatio();
                    listView.Sort();

                    // SQL


                }
        */


    }

}
