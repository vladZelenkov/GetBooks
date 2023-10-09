using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBooksProject.Entity
{
    class ProductBook : Book
    {
        public ProductBook(string name) : base(name)
        {
            PriceMessage = string.Empty;
        }

        public string PriceMessage { get; set; }
    }
}
