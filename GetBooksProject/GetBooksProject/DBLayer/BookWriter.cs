using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetBooksProject.DBLayer
{
    class BookWriter : DBWriter
    {
        public bool DeleteBook(int id)
        {
            string request = $"PRAGMA foreign_keys = ON; " +
                             $"delete from books where id = {id}";
            return Execute(request);
        }

        public void ChangeBook(StorageBook book)
        {
            string publishingHouse = "null";
            string year = "null";
            string image = "null";
            string defaultImage = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");

            if (book.PublishingHouse != string.Empty)
            {
                publishingHouse = $"'{book.PublishingHouse}'";
            }

            if (book.Year != 0)
            {
                year = $"{book.Year}";
            }

            if (book.ImagePath != defaultImage && book.ImagePath != string.Empty)
            {
                image = $"'{book.ImagePath}'";
            }

            string bookRequest = $"update books " +
                             $"set name = '{book.Name}' " +
                             $"set publishing_house_id = {publishingHouse}, " +
                             $"publishing_year = {year}, " +
                             $"image_path = {image}" +
                             $"where id = {book.Id}";

            try
            {
                Execute(bookRequest);

                try
                {
                    DeleteExcessAuthorship(book);
                    AddAuthorship(book);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception)
            {
                throw new Exception("Не удалось применить изменения");
            }
        }

        public bool AddAuthorship(int bookId, string bookName, int authorId)
        {
            string request = $"insert into authorship(book_id,book_name,author_id) " +
                             $"values({bookId},'{bookName}',{authorId})";
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
                    try
                    {
                        AddAuthorship(bookId, book.Name, authorId);
                    }
                    catch (Exception)
                    {
                        DeleteBook(bookId);
                        throw new Exception("Нельзя добавить одному автору книги с одинаковым названием");
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeleteExcessAuthorship(StorageBook book)
        {
            List<string> authors = book.GetAuthors();
            List<int> authorsId = new List<int>();

            foreach (string author in authors)
            {
                authorsId.Add(GetAuthorId(author));
            }

            StringBuilder request = new StringBuilder($"delete from authorship " +
                                                      $"where book_id = {book.Id} and author_id not in (");

            for (int i = 0; i < authorsId.Count; i++)
            {
                request.Append(authorsId[i]);

                if (i != authorsId.Count - 1)
                {
                    request.Append(',');
                }
            }

            request.Append(")");

            try
            {
                Execute(request.ToString());
            }
            catch (Exception)
            {
                throw new Exception("Не удалось удалить записи об авторстве");
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

        private void AddAuthorship(StorageBook book)
        {
            List<string> authors = book.GetAuthors();
            List<int> newAuthorsId = new List<int>();

            foreach (string author in authors)
            {
                newAuthorsId.Add(GetAuthorId(author));
            }

            AuthorshipReader reader = new AuthorshipReader();
            List<int> currentAuthorsId;

            try
            {
                currentAuthorsId = reader.GetAuthorsId(book.Id);
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при получении списка авторов книги");
            }

            foreach (int id in newAuthorsId)
            {
                if (currentAuthorsId.Contains(id) == false)
                {
                    try
                    {
                        AddAuthorship(book.Id, book.Name, id);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ошибка при добавлении автора");
                    }
                }
            }
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
