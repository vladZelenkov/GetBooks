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

        public override string GetShortInfo()
        {
            StringBuilder info = new StringBuilder(base.GetShortInfo());
            info.Append("\n" + PriceMessage);
            return info.ToString();
        }

        public override string GetFullInfo()
        {
            StringBuilder info = new StringBuilder(base.GetFullInfo());
            info.Append("\n" + PriceMessage);
            return info.ToString();
        }
    }
}
