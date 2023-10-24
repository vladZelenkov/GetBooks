using GetBooksProject.Entity;
using System.Collections.Generic;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class BookReader : DBReader
    {
        public List<StorageBook> GetAllBooks()
        {
            List<StorageBook> books = (List<StorageBook>)GetForCommand("select * from full_books_info");
            return books;
        }

        public List<StorageBook> GetBooksForName(string name)
        {
            List<StorageBook> books = (List<StorageBook>)GetForCommand($"select * from full_books_info  " +
                                                         $"where book = '{name}'");
            return books;
        }

        public List<StorageBook> GetBooksForAuthor(string author)
        {
            List<StorageBook> books = (List<StorageBook>)GetForCommand($"select * from full_books_info " +
                                                         $"where id in (select id from full_books_info where author = '{author}')");
            return books;
        }

        public List<StorageBook> GetBooksForPublishingHouse(string publishingHouse)
        {
            List<StorageBook> books = (List<StorageBook>)GetForCommand($"select * from full_books_info " +
                                                         $"where publishing_house = '{publishingHouse}'");
            return books;
        }

        public List<StorageBook> GetBooksForYear(int year)
        {
            List<StorageBook> books = (List<StorageBook>)GetForCommand($"select * from full_books_info " +
                                                         $"where yaer = '{year}'");
            return books;
        }

        protected override object GetResult(SQLiteCommand command)
        {
            List<StorageBook> books = new List<StorageBook>();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string author = reader.GetString(2);

                        if (IsBookInList(id, books, out int index))
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

            return books;
        }

        /// <summary>
        /// Находится ли книга в списке
        /// </summary>
        /// <param name="id">Id искомой книги</param>
        /// <param name="books">Список книг</param>
        /// <param name="index">Индекс книги в списке при нахождении, либо -1</param>
        /// <returns>bool: Находится ли книга в списке и ее индекс</returns>
        protected bool IsBookInList(int id, List<StorageBook> books, out int index)
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
