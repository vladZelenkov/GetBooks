﻿using System;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    abstract class DBReader
    {
        protected object Execute(string request)
        {
            DBAccess access = new DBAccess();
            object result = null;

            try
            {
                SQLiteConnection connection = access.GetConnection();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = request;
                    result = GetResult(command);
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

        protected abstract object GetResult(SQLiteCommand command);
    }
}