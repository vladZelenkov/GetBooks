using GetBooksProject.Entity;
using System.Collections.Generic;
using System.Net;

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

        protected override List<Book> GetBooksFromPage(string request, int pageNumber)
        {
            List<Book> books = new List<Book>();

            string page = string.Format(PagePattern, pageNumber);
            string url = string.Format(URLRequestPattern, request, page);

            using (WebClient client = new WebClient())
            {
                string htmlPage = client.DownloadString(url);
            }

            return books;
        }
    }
}
