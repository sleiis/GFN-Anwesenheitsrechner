using definitions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Anwesenheitsrechner
{
    public partial class form_Settings : Form
    {
        private readonly form_Main mainform;
        private Settings settings;
        public form_Settings(form_Main form_Main)
        {
            InitializeComponent();
            mainform = form_Main;
            settings = form_Main.Settings;
            cb_language.SelectedIndex = settings.Language;
        }

        private void bt_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_save_clicked(object sender, EventArgs e)
        {
            if (settings.Language != cb_language.SelectedIndex)
            {
                settings.Language = cb_language.SelectedIndex;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void bt_parse_clicked(object sender, EventArgs e)
        {
            List<Entry> output = new List<Entry>();
            List<String> entries = new List<String>();
            int lastEntry = 0;

            try
            {

                if (rb_web.Checked)
                {
                    entries.AddRange(tb_websiteparse.Text.Split(new string[] { "\n" }, StringSplitOptions.None));
                    for (int i = 0; i < entries.Count; i++)
                    {
                        String date = entries[i].Split(new string[] { "\t" }, StringSplitOptions.None)[0];
                        String location = entries[i].Split(new string[] { "\t" }, StringSplitOptions.None)[1];

                        Entry newEntry = new Entry()
                        {
                            date = DateTime.Parse(date),
                            location = location.Contains("🏢") ? 0 : location.Contains("🏠") ? 1 : -1,
                            sickday = !location.Contains("🏢") && !location.Contains("🏠")
                        };

                        output.Add(newEntry);
                    }
                }

                if (rb_php.Checked)
                {
                    while (lastEntry < (tb_websiteparse.Text.Length - 165))
                    {

                        int start = tb_websiteparse.Text.IndexOf("<tr>", lastEntry);
                        int end = tb_websiteparse.Text.IndexOf("</tr>", (lastEntry + 1)) + 5;

                        String entry = tb_websiteparse.Text.Substring(start, 166);

                        lastEntry = end;

                        entries.Add(entry);

                    }

                    for (int i = 0; i < entries.Count; i++)
                    {
                        String date = entries[i].Substring(entries[i].IndexOf("<td>"), 14);
                        String location = entries[i].Substring(entries[i].IndexOf("<td>") + 16, 13);

                        date = date.Replace("<td>", "").Replace("<", "").Trim();
                        location = location.Replace("<td>", "").Replace("</td>", "").Trim();

                        Entry newEntry = new Entry()
                        {
                            date = DateTime.Parse(date),
                            location = location.Contains("🏢") ? 0 : location.Contains("🏠") ? 1 : -1,
                            sickday = !location.Contains("🏢") && !location.Contains("🏠")
                        };

                        output.Add(newEntry);

                    }
                }
                mainform.addfromWeb(output);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Parsen der Daten: {ex.Message}");
            }

        }

        private void rb_changed(Object sender, System.EventArgs e)
        {
            rb_web.Checked = !rb_php.Checked;
        }

        private void bt_cleardb_clicked(object sender, EventArgs e)
        {
            DataHandler.clearDB();
            mainform.initListView();
        }
    }
}
