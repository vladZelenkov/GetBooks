using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBooksProject.Entity
{
    class Book
    {

        public Book(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string PublishingHouse { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }
    }
}
