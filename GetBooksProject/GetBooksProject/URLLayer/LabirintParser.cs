using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GetBooksProject.URLLayer
{
    class LabirintParser : Parser
    {
        public LabirintParser()
        {
            URLRequestPattern = "https://www.labirint.ru/search/{0}/?stype=0{1}";
            PagePattern = "&page={0}";
            PageCountRegexPattern = @"var count_pages = (\d*)";
        }

        protected override List<ProductBook> GetBooksFromPage(string request, int pageNumber)
        {
            List<ProductBook> books = new List<ProductBook>();

            string page = string.Format(PagePattern, pageNumber);
            string url = string.Format(URLRequestPattern, request, page);

            using (WebClient client = new WebClient())
            {
                try
                {
                    string htmlPage = client.DownloadString(url);
                    string pattern = @"<div class=""product-card__price-container"">(\s.*){38}";
                    Regex regex = new Regex(pattern);
                    MatchCollection matches = regex.Matches(htmlPage);

                    foreach (Match match in matches)
                    {
                        books.Add(GetBookFromInfo(match.Value));
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return books;
        }

        private ProductBook GetBookFromInfo(string info)
        {
            string namePattern = @"<!--region Name-->\s*<a href=""(.*)""\s*class=""product-card__name""\s*title=""(.*)""";
            string pricePattern = @"product-card__price-current"" >\s*(.*).</div>";
            string authorPattern = @"product-card__author"">\s*<a href=""(.*)"" title=""(.*)""";

            try
            {
                Regex nameRegex = new Regex(namePattern);
                Regex priceRegex = new Regex(pricePattern);
                Regex authorRegex = new Regex(authorPattern);
                ProductBook book = new ProductBook(nameRegex.Match(info).Groups[2].Value);
                book.PriceMessage = priceRegex.Match(info).Groups[1].Value;
                book.AddAuthor(authorRegex.Match(info).Groups[2].Value);
                book.PriceMessage = nameRegex.Match(info).Groups[1].Value;

                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
