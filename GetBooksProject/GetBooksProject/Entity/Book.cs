using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBooksProject.Entity
{
    class Book
    {
        private List<string> _authors;
        private int _year;

        public Book(string name)
        {
            Name = name;
            ImagePath = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            _authors = new List<string>();
            PublishingHouse = string.Empty;
            Year = 0;
        }

        public string Name { get; set; }

        public string PublishingHouse { get; set; }

        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                int currentYear = DateTime.Now.Year;
                bool isRealYear = value >= 0 && value <= currentYear;

                if (isRealYear)
                {
                    _year = value;
                }
                else
                {
                    throw new Exception("Установлена неверная дата");
                }
            }
        }

        public string ImagePath { get; set; }

        public void AddAuthor(string author)
        {
            _authors.Add(author);
        }

        public void RemoveAuthor(string author)
        {
            _authors.Remove(author);
        }

        public List<string> GetAuthors()
        {
            List<string> authors = new List<string>();

            foreach (string author in _authors)
            {
                authors.Add(author);
            }

            return authors;
        }

        public virtual string GetFullInfo()
        {
            StringBuilder info = new StringBuilder(GetShortInfo());

            info.AppendLine("\nИздательство: " + PublishingHouse);
            info.Append(Year + "год");

            return info.ToString();
        }

        public virtual string GetShortInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine(Name);

            foreach (string author in _authors)
            {
                info.Append(author);
                info.Append(',');
            }

            info.Remove(info.Length - 1, 1);

            return info.ToString();
        }
    }
}
