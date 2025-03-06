using System;
using System.IO;
using definitions;
using System.Data.SQLite;
using System.Data.Entity;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace Anwesenheitsrechner
{
    internal class DataHandler
    {

        public struct Settings
        {
            public int language;
        }

        enum Language
        {
            Deutsch,
            English
        }

        private String data;
        private Settings settings;
        private SQLiteConnection sqlite_conn;


        public DataHandler()
        {
            sqlite_conn = CreateConnection();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            // Creates Settings Table if it does not exist
            sqlite_cmd.CommandText = "Create Table if not exists Settings (name, value)";
            sqlite_cmd.ExecuteNonQuery();
            // Creates Table for current month if it does not exist
            sqlite_cmd.CommandText = "Create Table if not exists '" + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + "' (date, location, sickday)";
            sqlite_cmd.ExecuteNonQuery();
            // Set default language to German
            sqlite_cmd.CommandText = "Select count(*) From Settings where name='language'";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            if (sqlite_datareader.Read())
            {
                sqlite_datareader.Close();
                sqlite_cmd.CommandText = "Insert into Settings Values ('language', 'Deutsch')";
                sqlite_cmd.ExecuteNonQuery();
            }
            else
            {
                sqlite_datareader.Close();
            }

            readSettings();
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
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
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Settings";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                settings.language = (int)Enum.Parse(typeof(Language), sqlite_datareader.GetString(1));
            }
        }


        private void openSettingsFile(String path)
        {
            if (File.Exists(path))
            {
            }
            else
            {
                Settings settings = new Settings();
            }
            return;
        }

        private void openDataFile(String path)
        {
            if (File.Exists(path))
            {
                data = File.ReadAllText(path);
            }
            else
            {
                return;
            }
            return;
        }


    }
}
