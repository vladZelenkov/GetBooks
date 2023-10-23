using System.Collections;
using System.Collections.Generic;

namespace GetBooksProject.Entity
{
    class Library : IEnumerable
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public Library(List<Book> books)
        {
            _books = books;
        }

        public int Count
        {
            get
            {
                return _books.Count;
            }
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public IEnumerator GetEnumerator()
        {
            return _books.GetEnumerator();
        }
    }
}
