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
            OpenMode = "ReadWriteCreate";
            string connectionString = $"Data Source={dbPath}; Version=3; Mode={OpenMode}; FailMissing=True";
            _connection.ConnectionString = connectionString;
        }

        public string OpenMode { get; set; }

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
