using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GetBooksProject.URLLayer
{
    abstract class Parser
    {
        protected string URLRequestPattern { get; set; }
        protected string PagePattern { get; set; }
        protected string PageCountRegexPattern { get; set; }

        /// <summary>
        /// Получает книги с определенного сайта по запросу
        /// </summary>
        /// <param name="request">Поисковой запрос</param>
        /// <returns>Список книг, либо пустой список</returns>
        public List<Book> GetBooks(string request)
        {
            List<Book> books = new List<Book>();

            using (WebClient client = new WebClient())
            {
                try
                {
                    int page = GetPageCount(request);

                    for (int i = 1; i < page; i++)
                    {
                        books.AddRange(GetBooksFromPage(request, i));
                    }

                }
                catch (WebException)
                {
                    Form1.SetMessage("Ошибка соединения");
                }
                catch (Exception)
                {
                    Form1.SetMessage("Необработанное исключение");
                }
            }

            if (books.Count == 0)
            {
                Form1.SetMessage("По данному запросу ничего не найдено");
            }

            return books;
        }

        protected abstract List<Book> GetBooksFromPage(string request, int pageNumber);

        private int GetPageCount(string request)
        {
            string url = string.Format(URLRequestPattern, request, "");

            using (WebClient client = new WebClient())
            {
                try
                {
                    string htmlPage = client.DownloadString(url);
                    Regex pageCountRegex = new Regex(PageCountRegexPattern);
                    Match pageCountMatch = pageCountRegex.Match(htmlPage);

                    if (pageCountMatch.Groups.Count != 0)
                    {
                        if (int.TryParse(pageCountMatch.Groups[1].Value, out int pageCount))
                        {
                            return pageCount;
                        }
                    }

                    return 1;
                }
                catch (WebException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected string Decoding(string sourceText)
        {
            Encoding utf8 = Encoding.Default;
            byte[] bText = utf8.GetBytes(sourceText);
            utf8 = Encoding.UTF8;
            string resultText = utf8.GetString(bText);
            return resultText;
        }
    }
}
