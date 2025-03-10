using System;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Windows.Forms;
using definitions;

namespace Anwesenheitsrechner
{
    internal class DataHandler
    {

        private SQLiteConnection sqlite_conn;


        public DataHandler()
        {
            initDB();
        }

        public NameValueCollection readSQL(string cmd)
        {

            try
            {
                NameValueCollection output;
                using (var sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = cmd;
                    using (var sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        sqlite_datareader.Read();
                        output = sqlite_datareader.GetValues();
                        sqlite_datareader.Close();
                        return output;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK);
            }
            return new NameValueCollection();
        }

        public int writeSQL(string cmd)
        {
            try
            {
                using (var sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = cmd;
                    return sqlite_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK);
                return -1;
            }
        }

        void initDB()
        {

            sqlite_conn = CreateConnection();
            try
            {
                // Creates Settings Table if it does not exist
                writeSQL("Create Table if not exists Settings (name, value);");

                // Creates Data Table if it does not exist
                writeSQL("Create Table if not exists 'Data' (date date, location varchar(20), sickday bool);");

                // Set default language to German   
                if (int.Parse(readSQL("Select count(*) From Settings where name='language';").GetValues(0)[0]) == 0)
                {
                    writeSQL("Insert into Settings Values ('language', 'Deutsch');");
                }
                writeSQL("Delete from Data where date = '' or date is null;");
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQLite Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK);
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
                MessageBox.Show("Datenbank konnte nicht geöffnet werden. Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK);
                Application.Exit();
            }
            return sqlite_conn;
        }

        public Settings readSettings()
        {


            try
            {
                using (var sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT * FROM Settings;";
                    SQLiteDataReader sqlite_datareader;
                    using (sqlite_datareader = sqlite_cmd.ExecuteReader())
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
            return new Settings
            {
                Language = 0
            };
        }

        public static void clearDB()
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=database.db; Version=3; New=True; Compress=True;"))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Data;";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Löschen der Datenbank: " + ex.Message, "Fehler", MessageBoxButtons.OK);
            }
        }
    }
}
