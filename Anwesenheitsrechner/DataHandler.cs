using System;
using System.IO;
using definitions;
using System.Data.SQLite;
using System.Data.Entity;
using Microsoft.Data.Sqlite;

namespace Anwesenheitsrechner
{
    internal class DataHandler
    {

        public struct Settings
        {
            public String language;
        }

        private const String dataFilepath = "%documents%/Anwesenheitsrechner/data.json";
        private const String settingsFilepath = "%documents%/Anwesenheitsrechner/settings.json";
        private String data;
        private Settings settings;
        private SQLiteConnection sqlite_conn;


        public DataHandler()
        {
            openSettingsFile(settingsFilepath);
            openDataFile(dataFilepath);
            sqlite_conn = CreateConnection();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "Create Table if not exists Settings (name, value)";
            sqlite_cmd.ExecuteNonQuery();
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

            }
            return sqlite_conn;
        }

        public Settings readSettings()
        {
            Settings setting;
            setting.language = "Deutsch";
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Settings";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                setting.language = sqlite_datareader.GetString(1);
            }


            return setting;
        }

        public Entry[] getEntryList(DateTime TimeRange)
        {
            Entry[] entry = new Entry[31];
            return entry;
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
