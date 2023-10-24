﻿using System;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    abstract class DBReader
    {
        protected object GetForCommand(string commandLine)
        {
            DBAccess access = new DBAccess();
            SQLiteConnection connection = access.GetConnection();
            object result = null;

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = commandLine;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                    result = GetResult(command);
                }

                access.Disconnest();
                return result;
            }
            catch (InvalidOperationException)
            {
                access.Disconnest();
                throw;
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