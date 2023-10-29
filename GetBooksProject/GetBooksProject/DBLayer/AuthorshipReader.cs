using System.Collections.Generic;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class AuthorshipReader : DBReader
    {
        public List<int> GetAuthorsId(int bookId)
        {
            string request = $"select author_id from authorship " +
                             $"where book_id = {bookId}";
            List<int> authorsId = (List<int>)Execute(GetAuthorId, request);
            return authorsId;
        }

        private object GetAuthorId(SQLiteCommand command, string request)
        {
            command.CommandText = request;
            List<int> authorsId = new List<int>();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authorsId.Add(reader.GetInt32(0));
                    }
                }
            }

            return authorsId;
        }
    }
}
