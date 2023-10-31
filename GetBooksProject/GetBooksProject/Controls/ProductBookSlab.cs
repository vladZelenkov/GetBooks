using GetBooksProject.Entity;
using System;

namespace GetBooksProject.Controls
{
    class ProductBookSlab : BookSlab
    {
        public ProductBookSlab(Book book, BookPanel display) : base(book, display)
        {
            _transparentPanel.MouseClick -= slab_MouseClick;
            _transparentPanel.MouseClick += getFullInfo_MouseClick;
            _transparentPanel.MouseClick += slab_MouseClick;
        }

        protected override void slab_MouseClick(object sender, EventArgs e)
        {
            base.slab_MouseClick(sender, e);
        }

        private void getFullInfo_MouseClick(object sender, EventArgs e)
        {
            ProductBook currentBook = (ProductBook)_book;
            ProductBook book = ProductFindGroup.CurrentParser.GetBook(currentBook.URL);
            book.URL = currentBook.URL;
            SetBook(book);
            _transparentPanel.MouseClick -= getFullInfo_MouseClick;
        }
    }
}
