using definitions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Anwesenheitsrechner
{
    public partial class form_Settings: Form
    {
        form_Main mainform;
        public form_Settings(form_Main form_Main)
        {
            InitializeComponent();
            cb_language.SelectedIndex = form_Main.settings.language;
            mainform = form_Main;
        }

        private void bt_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_save_clicked(object sender, EventArgs e)
        {
            if (form_Main.settings.language != cb_language.SelectedIndex)
            {
                form_Main.settings.language = cb_language.SelectedIndex;
                this.Close();
            }
            else { this.Close(); }
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
                        Entry newEntry = new Entry();
                        newEntry.date = DateTime.Parse(date);
                        if (location.Contains("🏢"))
                        {
                            newEntry.location = 0;
                            newEntry.sickday = false;
                        }
                        else if (location.Contains("🏠"))
                        {
                            newEntry.location = 1;
                            newEntry.sickday = false;
                        }
                        else
                        {
                            newEntry.location = -1;
                            newEntry.sickday = true;
                        }
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
                        Entry newEntry = new Entry();
                        newEntry.date = DateTime.Parse(date);

                        if (location.Contains("🏢"))
                        {
                            newEntry.location = 0;
                            newEntry.sickday = false;
                        }
                        else if (location.Contains("🏠"))
                        {
                            newEntry.location = 1;
                            newEntry.sickday = false;
                        }
                        else
                        {
                            newEntry.location = -1;
                            newEntry.sickday = true;
                        }
                        output.Add(newEntry);

                    }
                }
                mainform.addfromWeb(output);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Fehler beim Parsen der Daten");
            }

        }

        private void rb_changed(Object sender, System.EventArgs e)
        {
            rb_web.Checked = !rb_php.Checked;
        }
    }
}
