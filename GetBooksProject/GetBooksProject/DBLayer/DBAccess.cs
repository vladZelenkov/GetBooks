using System;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class DBAccess
    {
        private SQLiteConnection _connection;

        public DBAccess()
        {
            _connection = new SQLiteConnection();
            string dbPath = XMLLayer.XMLPathReader.GetInstance().GetPath("libraryDB");
            string openMode = "ReadOnly";
            string connectionString = $"Data Source={dbPath}; Mode={openMode}; FailMissing=True";
            _connection.ConnectionString = connectionString;
        }

        public SQLiteConnection GetConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }

                return _connection;
            }
            catch (SQLiteException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Disconnest()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
