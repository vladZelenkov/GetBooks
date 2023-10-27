using GetBooksProject.Entity;
using System.Collections.Generic;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class BookReader : DBReader
    {
        private string _defaultImagePath;

        public BookReader()
        {
            _defaultImagePath = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");
        }

        public List<StorageBook> GetAllBooks()
        {
            List<StorageBook> books = (List<StorageBook>)Execute("select * from full_books_info");
            return books;
        }

        public List<StorageBook> GetBooksForName(string name)
        {
            List<StorageBook> books = (List<StorageBook>)Execute($"select * from full_books_info  " +
                                                         $"where lower(book) like '%{name.Trim().ToLower()}%'");
            return books;
        }

        public List<StorageBook> GetBooksForAuthor(string author)
        {
            List<StorageBook> books = (List<StorageBook>)Execute($"select * from full_books_info " +
                                                         $"where id in (select id from full_books_info where lower(author) like('%{author.Trim().ToLower()}%'))");
            return books;
        }

        public List<StorageBook> GetBooksForPublishingHouse(string publishingHouse)
        {
            List<StorageBook> books = (List<StorageBook>)Execute($"select * from full_books_info " +
                                                         $"where lower(publishing_house) like('%{publishingHouse.Trim().ToLower()}%')");
            return books;
        }

        public List<StorageBook> GetBooksForYear(int year)
        {
            List<StorageBook> books = (List<StorageBook>)Execute($"select * from full_books_info " +
                                                         $"where year = '{year}'");
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
                        string author = string.Empty;

                        if (reader.IsDBNull(2) == false)
                        {
                            author = reader.GetString(2);
                        }

                        if (IsBookInList(id, books, out int index))
                        {
                            books[index].AddAuthor(author);
                        }
                        else
                        {
                            string name = reader.GetString(1);
                            string publishingHouse = string.Empty;
                            int year = 0;
                            string image = _defaultImagePath;

                            if (reader.IsDBNull(3) == false)
                            {
                                publishingHouse = reader.GetString(3);
                            }

                            if (reader.IsDBNull(4) == false)
                            {
                                year = reader.GetInt32(4);
                            }

                            if (reader.IsDBNull(5) == false)
                            {
                                image = reader.GetString(5);
                            }

                            StorageBook book = new StorageBook(id, name);

                            if (author != string.Empty)
                            {
                                book.AddAuthor(author);
                            }

                            book.PublishingHouse = publishingHouse;
                            book.Year = year;
                            book.ImagePath = image;
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
