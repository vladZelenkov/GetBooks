using System.Collections.Generic;
using System.Data.SQLite;

namespace GetBooksProject.DBLayer
{
    class PublishingHouseReader : DBReader
    {
        public List<string> GetAllPublishingHouses()
        {
            List<string> houses = (List<string>)GetForCommand("select name from publishing_houses");
            return houses;
        }

        protected override object GetResult(SQLiteCommand command)
        {
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
