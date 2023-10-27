using System;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class DBWriter
    {
        protected bool Execute(string request)
        {
            DBAccess access = new DBAccess();
            int affectedLines = 0;

            try
            {
                SQLiteConnection connection = access.GetConnection();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = request;
                    affectedLines = command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                access.Disconnest();
                throw;
            }

            return affectedLines != 0;
        }
    }
}
