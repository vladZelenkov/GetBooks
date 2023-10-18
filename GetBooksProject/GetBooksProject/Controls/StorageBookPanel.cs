using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class StorageBookPanel : BookPanel
    {
        private Button _change;
        private Button _delete;
        private int _buttonHeight;
        public delegate void ChangeBook(StorageBook book);
        private ChangeBook _changeBook;

        public StorageBookPanel(Panel panel) : base(panel)
        {
            _change = new Button();
            _delete = new Button();
            _buttonHeight = 30;
            SetParameters();
        }

        private void SetParameters()
        {
            int indent = 2;
            _delete.Height = _buttonHeight;
            _delete.Top = _panel.Height - _delete.Height - indent;
            _delete.Width = _panel.Width - indent;
            _delete.Text = "Удалить";
            _change.Height = _buttonHeight;
            _change.Top = _panel.Height - _delete.Height - _change.Height - indent;
            _change.Width = _panel.Width - indent;
            _change.Text = "Изменить";
            _change.MouseClick += ChangeButtonClick;
            _change.Visible = false;
            _delete.Visible = false;
            _panel.Controls.Add(_delete);
            _panel.Controls.Add(_change);
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

        private void ChangeButtonClick(object sendler, EventArgs e)
        {
            if (_changeBook != null)
            {
                _changeBook.Invoke((StorageBook)_book);
            }
        }
    }
}
