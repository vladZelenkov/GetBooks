using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
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

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string author = reader.GetString(2);

                                if (IsBookExist(id, books, out int index))
                                {
                                    books[index].AddAuthor(author);
                                }
                                else
                                {
                                    string name = reader.GetString(1);
                                    string publishingHouse = reader.GetString(3);
                                    int year = reader.GetInt32(4);
                                    StorageBook book = new StorageBook(id, name);
                                    book.AddAuthor(author);
                                    book.PublishingHouse = publishingHouse;
                                    book.Year = year;
                                    books.Add(book);
                                }
                            }
                        }
                    }
                }

                return books;
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