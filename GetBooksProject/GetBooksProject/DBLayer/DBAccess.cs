using System;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class DBAccess
    {
        private static string _connectionString = "Data Source=libraryDB.db; Mode=ReadOnly; FailMissing=True";
        private SQLiteConnection _connection;

        public DBAccess()
        {
            _connection = new SQLiteConnection();
            _connection.ConnectionString = _connectionString;
        }

        public SQLiteConnection GetConnect()
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
