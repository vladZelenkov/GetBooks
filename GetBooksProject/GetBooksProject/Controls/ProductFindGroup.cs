using GetBooksProject.Entity;
using GetBooksProject.URLLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class ProductFindGroup : FindGroup
    {
        public ProductFindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox, FlowLayoutPanel display, BookPanel bookDisplay) :
            base(findButton, conditionBox, reuestBox, display, bookDisplay)
        { }

        protected override void SetOptions()
        {
            _searchOptions.Add("Labirint", findOnLabirint);
            Dictionary<string, ButtonClick>.KeyCollection keys = _searchOptions.Keys;

            foreach (string key in keys)
            {
                _condition.Items.Add(key);
            }

            _condition.SelectedIndex = 0;
        }

        private void ShowResult(List<ProductBook> books)
        {
            _slabDisplay.Controls.Clear();

            if (books.Count != 0)
            {
                foreach (ProductBook book in books)
                {
                    _slabDisplay.Controls.Add(new BookSlab(book, _bookDisplay));
                }
            }
            else
            {
                Form1.SetMessage("По вашему запросу ничего не найдено");
            }
        }

        private void findOnLabirint(object sender, EventArgs e)
        {
            LabirintParser parser = new LabirintParser();

            string request = _request.Text;

            if (request != string.Empty)
            {
                try
                {
                    List<ProductBook> books = parser.GetBooks(request);
                    ShowResult(books);
                }
                catch (Exception ex)
                {
                    Form1.SetMessage(ex.Message);
                }
            }
        }
    }
}
