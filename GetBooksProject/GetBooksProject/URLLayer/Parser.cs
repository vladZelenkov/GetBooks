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
        protected string _request = string.Empty;

        protected string WebSite { get; set; }
        protected string URLRequestPattern { get; set; }
        protected string PagePattern { get; set; }
        protected string PageCountRegexPattern { get; set; }

        /// <summary>
        /// Получает книги с определенного сайта по запросу
        /// </summary>
        /// <returns>Список книг, либо пустой список</returns>
        public List<ProductBook> GetBooks(int page)
        {
            if (_request != string.Empty)
            {
                List<ProductBook> books = new List<ProductBook>();

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        books.AddRange(GetBooksFromPage(_request, page));
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
            else
            {
                throw new Exception("Не установлен запрос");
            }
        }

        protected abstract List<ProductBook> GetBooksFromPage(string request, int pageNumber);

        public int GetPageCount(string request)
        {
            if (request != string.Empty)
            {
                _request = request;
                string url = string.Format(URLRequestPattern, WebSite, request, "");

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

            return 0;
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
