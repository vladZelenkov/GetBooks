using System;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    abstract class DBReader
    {
        protected delegate object GetResult(SQLiteCommand command, string request);

        protected object Execute(GetResult getResult, string request)
        {
            DBAccess access = new DBAccess();
            access.OpenMode = "ReadOnly";
            object result = null;

            try
            {
                SQLiteConnection connection = access.GetConnection();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    if (getResult != null)
                    {
                        result = getResult.Invoke(command, request);
                    }
                }

                access.Disconnest();
                return result;
            }
            catch (Exception)
            {
                access.Disconnest();
                throw;
            }
        }
    }
}