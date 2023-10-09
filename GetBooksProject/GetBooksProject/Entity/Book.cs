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
            ImagePath = "Pictures\\defaultBookPicture.png";
            _authors = new List<string>();
            PublishingHouse = string.Empty;
            Year = -1;
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
                bool isRealYear = value > 0 && value <= currentYear;

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
    }
}
