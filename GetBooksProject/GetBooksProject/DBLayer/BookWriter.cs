using GetBooksProject.Entity;
using System;
using System.Collections.Generic;

namespace GetBooksProject.DBLayer
{
    class BookWriter : DBWriter
    {
        public bool AddBook(Book book)
        {
            BookReader reader = new BookReader();
            int bookId;

            try
            {
                bookId = reader.GetLastId() + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            List<int> authorsId = new List<int>();
            List<string> authors = book.GetAuthors();

            foreach (string author in authors)
            {
                authorsId.Add(GetAuthorId(author));
            }

            int publishingHouseId = GetPublishingHouseId(book.PublishingHouse);
            string request = $"insert into books(id,name,publishing_house_id,publishing_year,image_path) " +
                             $"values({bookId},{book.Name},{publishingHouseId},{book.Year},{book.ImagePath})";

            if (Execute(request))
            {
                foreach (int authorId in authorsId)
                {
                    if (AddAuthorship(bookId, authorId) == false)
                    {
                        throw new Exception("Не удалось добавить автора");
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddAuthorship(int bookId, int authorId)
        {
            string request = $"insert into authorship(book_id,author_id) " +
                             $"values({bookId},{authorId})";
            return Execute(request);
        }

        public bool AddAuthor(string author)
        {
            string request = $"insert into authors(name) " +
                             $"values('{author}')";
            return Execute(request);
        }

        public bool AddPublishingHouse(string house)
        {
            string request = $"insert into publishing_houses(name) " +
                             $"values('{house}')";
            return Execute(request);
        }

        private int GetAuthorId(string author)
        {
            AuthorReader reader = new AuthorReader();

            if (reader.IsExist(author, out int id))
            {
                return id;
            }
            else
            {
                AddAuthor(author);

                if (reader.IsExist(author, out int newId))
                {
                    return newId;
                }
            }

            throw new Exception("Не удалось завершить операцию: GetAuthorId");
        }

        private int GetPublishingHouseId(string house)
        {
            PublishingHouseReader reader = new PublishingHouseReader();

            if (reader.IsExist(house, out int id))
            {
                return id;
            }
            else
            {
                AddPublishingHouse(house);

                if (reader.IsExist(house, out int newId))
                {
                    return newId;
                }
            }

            throw new Exception("Не удалось завершить операцию: GetPublishingHouseId");
        }
    }
}
