using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class AuthorReader : DBReader
    {
        public List<string> GetAllAuthors()
        {
            List<string> authors = (List<string>)Execute("select name from authors");
            return authors;
        }

        protected override object GetResult(SQLiteCommand command)
        {
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
