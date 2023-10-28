using System.Collections.Generic;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class PublishingHouseReader : DBReader
    {
        public List<string> GetAllPublishingHouses()
        {
            string request = "select name from publishing_houses";
            List<string> houses = (List<string>)Execute(GetPublishingHouses, request);
            return houses;
        }

        public bool IsExist(string publishingHouse, out int id)
        {
            string request = $"select id from publishing_houses" +
                             $"where name = '{publishingHouse}'";
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

        private object GetPublishingHouses(SQLiteCommand command, string request)
        {
            command.CommandText = request;
            List<string> houses = new List<string>();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string house = reader.GetString(0);
                        houses.Add(house);
                    }
                }
            }

            return houses;
        }
    }
}
