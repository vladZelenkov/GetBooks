﻿using GetBooksProject.Entity;
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
        public delegate void ChangeBook(StorageBook book);
        private ChangeBook _changeBook;

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

        private void ChangeButtonClick(object sender, EventArgs e)
        {
            if (_changeBook != null)
            {
                _changeBook.Invoke((StorageBook)Book);
            }
        }
    }
}