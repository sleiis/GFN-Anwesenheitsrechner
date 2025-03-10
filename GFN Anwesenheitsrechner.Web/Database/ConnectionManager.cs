using Dapper;
using GFN_Anwesenheitsrechner.Web.Extensions;
using Microsoft.Data.Sqlite;

namespace GFN_Anwesenheitsrechner.Web.Database
{
    public class ConnectionManager
    {
        private static string connectionString { get { return "Data Source=Database/Files/Presence.db"; } }
        private static string sqlFilePath { get { return "Database/Files/CreateTabels.sql"; } }
        private static string dbFilePath { get { return "Database/Files/Presence.db"; } }
        public async Task<bool> IsConnected()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();  // Try opening the connection asynchronously
                    return connection.State == System.Data.ConnectionState.Open;
                }
                catch
                {
                    return false;  // If an exception occurs, return false (e.g., unable to connect)
                }
            }
        }
        // Create the database if not exists

        public static void CreateDatabase()
        {
            string directoryPath = Path.GetDirectoryName(dbFilePath)!;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath); // Create missing folder
            }

            if (!File.Exists(dbFilePath))
            {
                GFNLogger.Log("Creating SQLite database...");

                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    if (File.Exists(sqlFilePath))
                    {
                        string sqlQuery = File.ReadAllText(sqlFilePath);
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = sqlQuery;
                            command.ExecuteNonQuery();
                        }
                        GFNLogger.Log("Database schema applied.");
                    }
                    else
                    {
                        GFNLogger.Log("SQL schema file not found!");
                    }
                }

                GFNLogger.Log("Database created successfully.");
            }
            else
            {
                GFNLogger.Log("Database already exists.");
            }
        }
        // Loads a list of data from the database using the specified SQL query and parameters.
        public async Task<List<T>> LoadDataList<T, U>(string sql, U parameters)
        {
            using (var con = new SqliteConnection(connectionString))
            {
                // Assuming that the parameters are a Dictionary or an object that can be handled by SQLite
                var rows = await Task.Run(() => con.Query<T>(sql, parameters));
                return rows.ToList();
            }
        }

        // Loads a single data item from the database using the specified SQL query and parameters.
        public async Task<T> LoadDataType<T, U>(string sql, U parameters)
        {
            using (var connectionNoList = new SqliteConnection(connectionString))
            {
                // Assuming that parameters are passed as a Dictionary or an object
                var row = await Task.Run(() => connectionNoList.QuerySingleOrDefault<T>(sql, parameters));
                return row!;
            }
        }
        // Saves data to the database using the specified SQL query and parameters.
        public async Task SaveData<T>(string sql, T parameters)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                GFNLogger.Log("Connection string cannot be null or empty.", "ERROR");
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
            }

            if (sql == null)
            {
                GFNLogger.Log("SQL query cannot be null", "ERROR");
                throw new ArgumentNullException(nameof(sql), "SQL query cannot be null.");
            }

            if (parameters == null)
            {
                GFNLogger.Log("Parameters cannot be null.", "ERROR");
                throw new ArgumentNullException(nameof(parameters), "Parameters cannot be null.");
            }

            using (var connectionSave = new SqliteConnection(connectionString))
            {
                try
                {
                    await Task.Run(() => connectionSave.Execute(sql, parameters));
                }
                catch (Exception ex)
                {
                    GFNLogger.Log($"Error occurred: {ex.Message}", "ERROR");
                    throw;
                }
            }
        }
    }
}

