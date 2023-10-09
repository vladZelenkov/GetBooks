using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBooksProject.Entity
{
    class StorageBook : Book
    {
        public StorageBook(int id, string name) : base(name)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
