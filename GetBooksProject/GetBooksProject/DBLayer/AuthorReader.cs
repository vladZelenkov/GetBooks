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

        public bool IsExist(string author, out int id)
        {
            string request = $"select id from authors " +
                             $"where name = '{author}'";
            id = (int)Execute(GetId, request);
            return id != -1;
        }

        private object GetId(SQLiteCommand command, string request)
        {
            command.CommandText = request;
            int id = -1;

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    id = reader.GetInt32(0);
                }
            }

            return id;
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
