using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Specialized;

namespace Anwesenheitsrechner
{
    internal class DataHandler
    {

        enum Language
        {
            Deutsch,
            English
        }

        private String data;
        private SQLiteConnection sqlite_conn;
        private SQLiteCommand sqlite_cmd;
        private SQLiteDataReader sqlite_datareader;


        public DataHandler()
        {
            sqlite_conn = CreateConnection();
            initDB();
            readSettings();
        }

        public NameValueCollection readSQL(string cmd)
        {
            try
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = cmd;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();
                NameValueCollection output = sqlite_datareader.GetValues();
                sqlite_datareader.Close();
                return output;
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show("SQL Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK);
                return null;
            }
        }

        public int writeSQL(string cmd, params SQLiteParameter[] parameters)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = cmd;
            try
            {
                using (var sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = cmd;
                    sqlite_cmd.Parameters.AddRange(parameters);
                    return sqlite_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show("SQL Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK);
                return -1;
            }
            return 1;
        }

        void initDB()
        {
            try
            {
                // Creates Settings Table if it does not exist
                writeSQL("Create Table if not exists Settings (name, value);");

                // Creates Data Table if it does not exist
                writeSQL("Create Table if not exists 'Data' (date date, location varchar(20), sickday bool);");

                // Set default language to German   
                if (int.Parse(readSQL("Select count(*) From Settings where name='language';").GetValues(0).ElementAt(0)) == 0)
                {

                    writeSQL("Insert into Settings Values ('language', 'Deutsch');");
                }
                writeSQL("Delete from Data where date = '' or date is null;");
            }
            catch
            {
                DialogResult dialogResult = MessageBox.Show("SQLite Fehler", "Fehler", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        SQLiteConnection CreateConnection()
        {

            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show("Datenbank konnte nicht geöffnet werden. Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK);
                Application.Exit();
            }
            return sqlite_conn;
        }

        public void readSettings()
        {
            SQLiteDataReader sqlite_datareader;
            try
            {

                using (var sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT * FROM Settings;";
                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        sqlite_datareader.Read();
                        return new Settings
                        {
                            Language = (int)Enum.Parse(typeof(Language), sqlite_datareader.GetString(1))
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Lesen der Einstellungen: " + ex.Message, "Fehler", MessageBoxButtons.OK);
            }
            return new Settings {Language = 0};
        }

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    form_Main.settings.language = (int)Enum.Parse(typeof(Language), sqlite_datareader.GetString(1));
                }
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show("Fehler beim Lesen der Einstellungen: " + ex.Message, "Fehler", MessageBoxButtons.OK);
            }
        }

    }
}
