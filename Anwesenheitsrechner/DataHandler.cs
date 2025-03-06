using System;
using System.IO;
using definitions;
using System.Data.SQLite;
using System.Data.Entity;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

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
        private SQLiteCommand sqlite_cmd;


        public DataHandler()
        {
            initDB();
            readSettings();
        }

        public NameValueCollection readSQL(string cmd)
        {
            //List<String> output = new List<string>();
            //output.Clear();
            SQLiteDataReader sqlite_datareader;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = cmd;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            sqlite_datareader.Read();
            NameValueCollection output = sqlite_datareader.GetValues();
            return output;
        }

        public int writeSQL(string cmd)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = cmd;
            try
            {
                sqlite_cmd.ExecuteNonQuery();
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

            sqlite_conn = CreateConnection();
            // Creates Settings Table if it does not exist
            writeSQL("Create Table if not exists Settings (name, value);");

            // Creates Data Table if it does not exist
            writeSQL("Create Table if not exists 'Data' (date date, location varchar(20), sickday bool, ID INTEGER PRIMARY KEY AUTOINCREMENT);");

            // Set default language to German   
            if (int.Parse(readSQL("Select count(*) From Settings where name='language';").GetValues(0).ElementAt(0)) == 0)
            {
                
                writeSQL("Insert into Settings Values ('language', 'Deutsch');");
            }
            writeSQL("Delete from Data where date = '' or date is null;");
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

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Settings;";

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
