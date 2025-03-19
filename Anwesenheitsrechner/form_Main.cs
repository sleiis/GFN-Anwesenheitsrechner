using definitions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Windows.Forms;


namespace Anwesenheitsrechner
{
    public partial class form_Main : Form
    {
        public Settings Settings;
        ContextMenuStrip ListContext = new ContextMenuStrip();
        DataHandler DataHandler = new DataHandler();

        public form_Main()
        {
            Settings = DataHandler.readSettings();
            InitializeComponent();

            // Setup ListView Context Menu
            ListContext.Items.Add("bearbeiten").Name = "edit";
            ListContext.Items.Add("löschen").Name = "delete";
            ListContext.Opening += ContexListHandler;
            ListContext.ItemClicked += new ToolStripItemClickedEventHandler(this.ListContext_clicked);
            listView.ContextMenuStrip = ListContext;

            initListView();

        }

        // Setup Functions
        public void initListView()
        {

            listView.Items.Clear();
            int count_entries = int.Parse(DataHandler.readSQL("Select count(*) From Data;").GetValues(0)[0]);

            // Read Data from SQL and add to ListView
            for (int i = 0; i < count_entries; i++)
            {
                NameValueCollection entry = DataHandler.readSQL($"Select Distinct * From Data where rowid = {(i + 1).ToString()};");

                
                ListViewItem.ListViewSubItem sickday = new ListViewItem.ListViewSubItem()
                {
                    Text = ((entry.GetValues(2)[0] == "True") ? "Ja" : "Nein")
                };
                
                var location = new ListViewItem.ListViewSubItem()
                {
                    Text = entry.GetValues(1)[0]
                };
                
                var item = new ListViewItem()
                {
                    Text = DateTime.Parse(entry.GetValues(0)[0]).ToString("D"),
                    SubItems = { location, sickday }
                };

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

            ToolStripItemClickedEventArgs args = e;

            if (args.ClickedItem.Name == "edit")
            {

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
                monthCalendar.SelectionStart = monthCalendar.SelectionEnd = DateTime.Parse(listView.SelectedItems[0].Text);
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

        //Logic Functions
        private void calculateDayRatio()
        {
            int dayCount = 0;
            int homeCount = 0;
            int workCount = 0;
            int sickCount = 0;

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
                if (item.SubItems[2].Text == "Ja")
                {
                    sickCount++;
                }
            }

            double homeRatio = Math.Round((double)homeCount * 100 / dayCount, 2);
            double workRatio = Math.Round((double)workCount * 100 / dayCount, 2);

            if (dayCount == 0) return;
            if (homeCount > 0) stat_total_ho.Text = $"{homeRatio.ToString()} %";
            if (workCount > 0) stat_total_pre.Text = $"{workRatio.ToString()} %";

            if (homeRatio > 49 && workRatio < 51)
            {
                stat_total_ho.ForeColor = System.Drawing.Color.Red;
                stat_total_pre.ForeColor = System.Drawing.Color.Red;
                l_hint.Text = $"Verhältnis überschritten um {Math.Round((((double)homeCount * 100 / dayCount) - 49) / 100 * dayCount,2).ToString()} Tage";
            }
            else
            {
                stat_total_ho.ForeColor = System.Drawing.Color.Green;
                stat_total_pre.ForeColor = System.Drawing.Color.Green;
                l_hint.Text = "";
            }
            double current_sick = Math.Round((double)sickCount * 100 / (dayCount+sickCount), 2);
            double total_sick = Math.Round((double)sickCount * 100 / (Settings.Total_days), 2);

            if (current_sick > 0) l_sickdays_now.Text = $"{current_sick.ToString()} %";
            if (total_sick > 0) l_sickdays_total.Text = $"{total_sick.ToString()} %";

            if (current_sick < 10) l_sickdays_now.ForeColor = System.Drawing.Color.Green;
            else if (current_sick > 10) l_sickdays_now.ForeColor= System.Drawing.Color.Red;
            if (total_sick < 10) l_sickdays_total.ForeColor = System.Drawing.Color.Green;
            else if (total_sick > 10) l_sickdays_total.ForeColor = System.Drawing.Color.Red;

        }

        public void addEntry(Entry entry)
        {
            String date = entry.date.ToString("D");
            if (listView.Items.ContainsKey(date))
            {
                MessageBox.Show("Datum existiert bereits", "Duplikat", MessageBoxButtons.OK);
                return;
            }

            String location = (entry.location == 0) ? "Standort" : "Homeoffice";

            if (entry.sickday) location = "--";

            var item = new ListViewItem(date)
            {
                Name = date
            };
            item.SubItems.Add(location);
            item.SubItems.Add(entry.sickday ? "Ja" : "Nein");

            listView.Items.Add(item);
            DataHandler.writeSQL("INSERT INTO Data (date, location, sickday) VALUES (@date, @location, @sickday)",
                new System.Data.SQLite.SQLiteParameter("@date", entry.date.ToShortDateString()),
                new System.Data.SQLite.SQLiteParameter("@location", location),
                new System.Data.SQLite.SQLiteParameter("@sickday", entry.sickday.ToString()));

            calculateDayRatio();
            listView.Sort();
        }

        public void editEntry(Entry entry)
        {
            String date = entry.date.ToString("D");
            String location = (entry.location == 0) ? "Standort" : "Homeoffice";

            if (entry.sickday) location = "--";

            var item = new ListViewItem(date)
            {
                Name = date
            };
            item.SubItems.Add(location);
            item.SubItems.Add(entry.sickday ? "Ja" : "Nein");

            int index = listView.SelectedItems[0].Index;
            DataHandler.writeSQL($"Update Data Set 'location' = '{location}', 'sickday' = {entry.sickday.ToString()}, 'date' = '{entry.date.ToShortDateString()}' where date = '{DateTime.Parse(listView.Items[index].Text).ToShortDateString()}';");
            listView.Items.RemoveAt(index);
            listView.Items.Insert(index, item);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
