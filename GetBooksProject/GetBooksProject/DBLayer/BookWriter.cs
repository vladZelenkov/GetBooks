using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBooksProject.DBLayer
{
    class BookWriter : DBWriter
    {
        public bool AddBook(Book book)
        {
            string request = "";
            return Execute(request);
        }
    }
}
