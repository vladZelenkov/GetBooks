using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Net;
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
                ProductBook book = new ProductBook(Format(DecodingUTF8(name)));
                book.PriceMessage = Format(price);
                book.AddAuthor(DecodingUTF8(author));
                book.URL = WebSite + nameRegex.Match(info).Groups[1].Value;

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
            text = text.Replace("в‚", " руб");
            text = text.Replace("quot;", "\"");
            return text;
        }

        public override ProductBook GetBook(string url)
        {
            string namePattern = @"og:title"" content=""(.*)""";
            string authorPattern = @"data-event-label=""author""\s*data-event-content=""(.*)""";
            string pubHousePattern = @"data-event-label=""publisher"" data-event-content=""(.*)"">(.*)</a>,";
            string yearPattern = @"data-event-label=""publisher"" data-event-content=""(.*)"">(.*)</a>, (\d*) ";
            string imagePattern = @"<div id=""product-image"">\s*.*\s*.*data-src=""(.*)""  height";
            string pricePattern = @"price"":(\d*)";
            string totalPricePattern = @"""totalPrice"":(\d*)";
            Regex nameRegex = new Regex(namePattern);
            Regex authorRegex = new Regex(authorPattern);
            Regex pubHousRegex = new Regex(pubHousePattern);
            Regex yearRegex = new Regex(yearPattern);
            Regex imageRegex = new Regex(imagePattern);
            Regex priceRegex = new Regex(pricePattern);
            Regex totalPriceRegex = new Regex(totalPricePattern);

            using (WebClient client = new WebClient())
            {
                try
                {
                    string htmlPage = client.DownloadString(url);
                    Match pubHouseMatch = pubHousRegex.Match(htmlPage);
                    Match imageMatch = imageRegex.Match(htmlPage);
                    Match nameMatch = nameRegex.Match(htmlPage);
                    Match authorMatch = authorRegex.Match(htmlPage);
                    Match priceMatch = priceRegex.Match(htmlPage);
                    Match totalPriceMatch = totalPriceRegex.Match(htmlPage);
                    Match yearMatch = yearRegex.Match(htmlPage);

                    string name = DecodingUTF8(nameMatch.Groups[1].Value);
                    ProductBook book = new ProductBook(Format(name));

                    string author = DecodingUTF8(authorMatch.Groups[1].Value);
                    book.AddAuthor(Format(author));

                    string publishingHouse = DecodingUTF8(pubHouseMatch.Groups[1].Value);
                    book.PublishingHouse = Format(publishingHouse);
                    string yearText = yearMatch.Groups[3].Value;

                    if (int.TryParse(yearText, out int year))
                    {
                        book.Year = year;
                    }

                    book.PriceMessage = priceMatch.Groups[1].Value;

                    if (totalPriceMatch.Success)
                    {
                        book.PriceMessage = totalPriceMatch.Groups[1].Value;
                    }

                    book.PriceMessage += " руб";
                    string imagePath = DecodingUTF8(imageMatch.Groups[1].Value);
                    book.ImagePath = imagePath;
                    return book;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка при получении данных о книге");
                }
            }
        }
    }
}
