using System.Collections.Generic;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class AuthorReader : DBReader
    {
        public List<string> GetAllAuthors()
        {
            string request = "select name from authors";
            List<string> authors = (List<string>)Execute(GetAuthors, request);
            return authors;
        }

        private object GetAuthors(SQLiteCommand command, string request)
        {
            command.CommandText = request;
            List<string> authors = new List<string>();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string author = reader.GetString(0);
                        authors.Add(author);
                    }
                }
            }

            return authors;
        }
    }
}
