using GetBooksProject.Entity;
using System;
using System.Collections.Generic;

namespace GetBooksProject.DBLayer
{
    class BookWriter : DBWriter
    {
        public bool DeleteBook(int id)
        {
            string request = $"delete from books where id = {id}";
            return Execute(request);
        }

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

            string request = GetBookRequest(book, bookId);

            List<int> authorsId = new List<int>();
            List<string> authors = book.GetAuthors();

            foreach (string author in authors)
            {
                int id = GetAuthorId(author);

                if (authorsId.Contains(id) == false)
                {
                    authorsId.Add(id);
                }
            }

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

        private string GetBookRequest(Book book, int bookId)
        {
            string publishingHousePattern = string.Empty;
            string publishingHouseValue = string.Empty;
            string yearPattern = string.Empty;
            string yearValue = string.Empty;
            string imagePattern = string.Empty;
            string imageValue = string.Empty;

            if (book.PublishingHouse != string.Empty)
            {
                publishingHousePattern = ",publishing_house_id";
                int publishingHouseId = GetPublishingHouseId(book.PublishingHouse);
                publishingHouseValue = $",'{publishingHouseId}'";
            }

            if (book.Year != 0)
            {
                yearPattern = ",publishing_year";
                yearValue = $",{book.Year}";
            }

            if (book.ImagePath != string.Empty)
            {
                imagePattern = ",image_path";
                imageValue = $",'{book.ImagePath}'";
            }

            string requestInsert = "insert into books(id,name{0}{1}{2}) ";
            string constantValues = "values({0},'{1}'";
            string variableValues = "{0}{1}{2})";
            requestInsert = string.Format(requestInsert, publishingHousePattern, yearPattern, imagePattern);
            constantValues = string.Format(constantValues, bookId, book.Name);
            variableValues = string.Format(variableValues, publishingHouseValue, yearValue, imageValue);
            string request = requestInsert + constantValues + variableValues;

            return request;
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
