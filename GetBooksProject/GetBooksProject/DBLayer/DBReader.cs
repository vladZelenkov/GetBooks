using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class DBReader
    {
        public List<StorageBook> GetBooks(SQLiteConnection connection)
        {
            List<StorageBook> books = new List<StorageBook>();

            try
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"select * from full_books_info";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DataRowCollection rows = table.Rows;

                    foreach (DataRow row in rows)
                    {
                        int id = row.Field<int>("id");
                        string author = row.Field<string>("author");

                        if (IsBookExist(id, books, out int index))
                        {
                            books[index].AddAuthor(author);
                        }
                        else
                        {
                            string name = row.Field<string>("name");
                            string publishingHouse = row.Field<string>("publishing_house");
                            int year = row.Field<int>("year");
                        }
                    }

                    return books;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsBookExist(int id, List<StorageBook> books, out int index)
        {
            bool isExist = false;
            int i = 0;
            index = -1;

            while (isExist == false && books.Count != i)
            {
                if (books[i].Id == id)
                {
                    isExist = true;
                    index = i;
                }
                else
                {
                    i++;
                }
            }

            return isExist;
        }
    }
}
