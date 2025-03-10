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
            initDataGridView();
        }

        // Setup Functions
        private void initDataGridView()
        {
            // Setup DataGridView Context Menu
            ListContext.Items.Add("bearbeiten").Name = "edit";
            ListContext.Items.Add("löschen").Name = "delete";
            ListContext.Opening += ContexListHandler;
            ListContext.ItemClicked += new ToolStripItemClickedEventHandler(this.ListContext_clicked);
            listView.ContextMenuStrip = ListContext;

            int EntryCount = int.Parse(DataHandler.readSQL("Select count(*) From Data;").GetValues(0).ElementAt(0));

            // Read Data from SQL and add to DataGridView
            for (int i = 0; i < EntryCount; i++)
            {
                NameValueCollection entry = DataHandler.readSQL($"Select * From Data where rowid = {i + 1};");
                string Date = DateTime.Parse(entry.GetValues(0).ElementAt(0)).ToString("D");
                string location = entry.GetValues(1).ElementAt(0);
                string sickday = (entry.GetValues(2).ElementAt(0)) == "1" ? "Ja" : "Nein";

                listView.Rows.Add(Date, location, sickday);
            }

            calculateDayRatio();

            // Init Column Sorter (Optional)
            listView.Sort(listView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        // Event Functions
        private void bt_vacation_clicked(object sender, EventArgs e)
        {
            Form EntryHolidayForm = new form_vacation(this);
            EntryHolidayForm.Show();
        }

        private void bt_settings_clicked(object sender, EventArgs e)
        {
            Form SettingsForm = new form_Settings(this);
            SettingsForm.Show();
        }

        private void bt_addEntry_clicked(object sender, EventArgs e)
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
                if (listView.SelectedRows.Count > 0)  // Ensure at least one row is selected
                {
                    int index = listView.SelectedRows[0].Index;
                    Form changeEntry = new form_addedit(this, true);
                    MonthCalendar monthCalendar = changeEntry.Controls.Find("mc_dateselect", false)[0] as MonthCalendar;
                    changeEntry.Text = "Eintrag ändern";
                    changeEntry.Controls.Find("bt_add", false)[0].Text = "Ändern";

                    // Populate form based on selected data
                    DataGridViewRow selectedRow = listView.Rows[index];
                    if (selectedRow.Cells[1].Value.ToString() == "Standort")
                    {
                        changeEntry.Controls.Find("rb_pre", false)[0].Select();
                    }
                    else if (selectedRow.Cells[1].Value.ToString() == "Homeoffice")
                    {
                        changeEntry.Controls.Find("rb_ho", false)[0].Select();
                    }
                    else if (selectedRow.Cells[2].Value.ToString() == "Ja")
                    {
                        changeEntry.Controls.Find("cb_sickday", false)[0].Select();
                        changeEntry.Controls.Find("rb_pre", false)[0].Enabled = false;
                        changeEntry.Controls.Find("rb_ho", false)[0].Enabled = false;
                    }

                    monthCalendar.ShowTodayCircle = false;
                    monthCalendar.SelectionStart = DateTime.Parse(selectedRow.Cells[0].Value.ToString());
                    monthCalendar.SelectionEnd = DateTime.Parse(selectedRow.Cells[0].Value.ToString());
                    changeEntry.Show();
                }
            }

            if (args.ClickedItem.Name == "delete")
            {
                deleteEntry(listView.SelectedRows);
                calculateDayRatio();
            }
        }

        private void ContexListHandler(object sender, EventArgs e)
        {
            if (listView.SelectedRows.Count == 0)
            {
                ListContext.Items[0].Enabled = false;
                ListContext.Items[1].Enabled = false;
            }
            else if (listView.SelectedRows.Count == 1)
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
        private void myDialog(string text)
        {
            Form dialog = new Form();
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            dialog.Controls.Add(label);
            dialog.ShowDialog();
        }

        // Logic Functions
        private void calculateDayRatio()
        {
            int dayCount = 0;
            int homeCount = 0;
            int workCount = 0;

            foreach (DataGridViewRow row in listView.Rows)
            {
                if (row.Cells[1].Value.ToString() == "Standort")
                {
                    workCount++;
                    dayCount++;
                }
                if (row.Cells[1].Value.ToString() == "Homeoffice")
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
            string Date = entry.date.ToString("D");
            // Check for duplicate
            foreach (DataGridViewRow row in listView.Rows)
            {
                if (row.Cells[0].Value.ToString() == Date)
                {
                    MessageBox.Show("Datum existiert bereits", "Duplikat", MessageBoxButtons.OK);
                    return;
                }
            }

            string location = (entry.location == 0) ? "Standort" : "Homeoffice";
            if (entry.sickday) location = "--";

            listView.Rows.Add(Date, location, entry.sickday ? "Ja" : "Nein");


            // Insert into SQL database
            listView.Items.Add(item);
            DataHandler.writeSQL("INSERT INTO Data (date, location, sickday) VALUES (@date, @location, @sickday)",
                new System.Data.SQLite.SQLiteParameter("@date", entry.date.ToShortDateString()),
                new System.Data.SQLite.SQLiteParameter("@location", location),
                new System.Data.SQLite.SQLiteParameter("@sickday", entry.sickday.ToString()));

            calculateDayRatio();
        }

        public void editEntry(Entry entry)
        {
            string Date = entry.date.ToString("D");
            string location = (entry.location == 0) ? "Standort" : "Homeoffice";
            if (entry.sickday) location = "--";

            int index = listView.SelectedRows[0].Index;

            // Update selected row
            listView.Rows[index].Cells[0].Value = Date;
            listView.Rows[index].Cells[1].Value = location;
            listView.Rows[index].Cells[2].Value = entry.sickday ? "Ja" : "Nein";

            // Update in the database
            DataHandler.writeSQL($"Update Data Set location = '{location}', sickday = {entry.sickday.ToString()}, date = '{entry.date.ToShortDateString()}' where date = '{DateTime.Parse(listView.Rows[index].Cells[0].Value.ToString()).ToShortDateString()}';");
        }

        public void deleteEntry(DataGridViewSelectedRowCollection rows)
        {
            foreach (DataGridViewRow row in rows)
            {
                string date = row.Cells[0].Value.ToString();
                DataHandler.writeSQL($"Delete From Data where date = '{DateTime.Parse(date).ToShortDateString()}';");
                listView.Rows.Remove(row);
            }
        }

        public void addfromWeb(List<Entry> entries)
        {
            foreach (Entry entry in entries)
            {
                addEntry(entry);
            }
        }

        private void form_Main_Load(object sender, EventArgs e)
        {
            // Code to handle form load if required
        }
    }
}
