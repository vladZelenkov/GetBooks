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
            WebSite = "https://www.labirint.ru";
            URLRequestPattern = "{0}/search/{1}/?stype=0{2}";
            PagePattern = "&page={0}";
            PageCountRegexPattern = @"var count_pages = (\d*)";
        }

        protected override List<ProductBook> GetBooksFromPage(string request, int pageNumber)
        {
            List<ProductBook> books = new List<ProductBook>();

            string page = string.Format(PagePattern, pageNumber);
            string url = string.Format(URLRequestPattern, WebSite, request, page);

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
                string name = nameRegex.Match(info).Groups[2].Value;
                string author = authorRegex.Match(info).Groups[2].Value;
                string price = priceRegex.Match(info).Groups[1].Value;
                ProductBook book = new ProductBook(Format(Decoding(name)));
                book.PriceMessage = Format(price);
                book.AddAuthor(Decoding(author));
                book.URL = nameRegex.Match(info).Groups[1].Value;

                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string Format(string text)
        {
            text = text.Replace("&thinsp;", " ");
            text = text.Replace("&nbsp;", "");
            text = text.Replace("в‚", "руб");
            text = text.Replace("quot;", "\"");
            return text;
        }
    }
}
