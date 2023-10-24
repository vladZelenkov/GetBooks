using GetBooksProject.DBLayer;
using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class StorageFindGroup : FindGroup
    {

        public StorageFindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox, FlowLayoutPanel display, BookPanel bookDisplay) :
            base(findButton, conditionBox, reuestBox, display, bookDisplay)
        { }

        protected override void SetOptions()
        {
            _searchOptions.Add("Название", findForName);
            _searchOptions.Add("Автор", findForAuthor);
            _searchOptions.Add("Издательство", findForPublishingHouse);
            _searchOptions.Add("Год", findForYear);
            Dictionary<string, ButtonClick>.KeyCollection keys = _searchOptions.Keys;

            foreach (string key in keys)
            {
                _condition.Items.Add(key);
            }

            _condition.SelectedIndex = 0;
        }

        private void ShowResult(List<StorageBook> books)
        {
            _slabDisplay.Controls.Clear();

            if (books.Count == 0)
            {
                Form1.SetMessage("По вашему запросу ничего не найдено");
            }
            else
            {
                foreach (StorageBook book in books)
                {
                    _slabDisplay.Controls.Add(new BookSlab(book, _bookDisplay));
                }
            }
        }

        private void findForName(object sender, EventArgs e)
        {
            BookReader reader = new BookReader();
            string request = _request.Text;

            if (request != "")
            {
                ShowResult(reader.GetBooksForName(_request.Text));
            }
        }

        private void findForAuthor(object sender, EventArgs e)
        {
            BookReader reader = new BookReader();
            string request = _request.Text;

            if (request != "")
            {
                ShowResult(reader.GetBooksForAuthor(_request.Text));
            }
        }

        private void findForPublishingHouse(object sender, EventArgs e)
        {
            BookReader reader = new BookReader();
            string request = _request.Text;

            if (request != "")
            {
                ShowResult(reader.GetBooksForPublishingHouse(_request.Text));
            }
        }

        private void findForYear(object sender, EventArgs e)
        {
            BookReader reader = new BookReader();
            string request = _request.Text;

            if (request != "")
            {
                if (int.TryParse(request, out int year))
                {
                    ShowResult(reader.GetBooksForYear(year));
                }
            }
        }
    }
}
