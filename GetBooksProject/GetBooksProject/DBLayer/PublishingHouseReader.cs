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
