using GetBooksProject.Entity;
using System;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class StorageBookPanel : BookPanel
    {
        private Button _change;
        private Button _delete;
        public delegate void ChangeBook(StorageBook book);
        private ChangeBook _changeBook;
        private ChangeBook _deleteBook;

        public StorageBookPanel(Panel panel) : base(panel)
        {
            _change = new Button();
            _delete = new Button();
            SetParameters();
        }

        private void SetParameters()
        {
            _delete.Height = ButtonHeight;
            _delete.Top = Panel.Height - _delete.Height - ButtonIndent;
            _delete.Width = Panel.Width - ButtonIndent;
            _delete.Text = "Удалить";
            _delete.Anchor = AnchorStyles.Bottom;
            _change.Height = ButtonHeight;
            _change.Top = _delete.Top - _change.Height - ButtonIndent;
            _change.Width = Panel.Width - ButtonIndent;
            _change.Text = "Изменить";
            _change.Anchor = AnchorStyles.Bottom;
            _change.MouseClick += ChangeButtonClick;
            _change.Visible = false;
            _delete.Visible = false;
            _delete.MouseClick += DeleteButtonClick;
            Panel.Controls.Add(_delete);
            Panel.Controls.Add(_change);
        }

        public override void SetBook(Book book)
        {
            base.SetBook(book);
            _change.Visible = true;
            _delete.Visible = true;
        }

        public void SetChangeBook(ChangeBook changeBook)
        {
            _changeBook = changeBook;
        }

        public void SetDeleteBook(ChangeBook deleteBook)
        {
            _deleteBook = deleteBook;
        }

        private void ChangeButtonClick(object sender, EventArgs e)
        {
            if (_changeBook != null)
            {
                _changeBook.Invoke((StorageBook)Book);
            }
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (_deleteBook != null)
            {
                _deleteBook.Invoke((StorageBook)Book);
            }
        }
    }
}
