using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class ProductBookPanel : BookPanel
    {
        private Button _add;
        private Button _visitSite;
        public delegate void AddBook(ProductBook book);
        private AddBook _addBook;

        public ProductBookPanel(Panel panel) : base(panel)
        {
            _add = new Button();
            _visitSite = new Button();
            SetParameters();
        }

        private void SetParameters()
        {
            _add.Width = Panel.Width;
            _add.Height = ButtonHeight;
            _add.Text = "Добавить";
            _add.Top = Panel.Height - ButtonIndent - _add.Height;
            _add.Anchor = AnchorStyles.Bottom;
            _add.Visible = false;
            _add.MouseClick += addBookMouseClick;
            _visitSite.Width = Panel.Width;
            _visitSite.Height = ButtonHeight;
            _visitSite.Text = "Перейти на сайт";
            _visitSite.Top = _add.Top - ButtonIndent - _visitSite.Height;
            _visitSite.Anchor = AnchorStyles.Bottom;
            _visitSite.Visible = false;
            Panel.Controls.Add(_add);
            Panel.Controls.Add(_visitSite);
        }

        public override void SetBook(Book book)
        {
            base.SetBook(book);
            _add.Visible = true;
            _visitSite.Visible = true;
        }

        public void SetAddBook(AddBook addBook)
        {
            _addBook = addBook;
        }

        public void addBookMouseClick(object sender, EventArgs e)
        {
            if (_addBook != null)
            {
                _addBook.Invoke((ProductBook)Book);
            }
        }
    }
}
