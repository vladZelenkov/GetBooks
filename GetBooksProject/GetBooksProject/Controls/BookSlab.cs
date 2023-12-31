﻿using GetBooksProject.Entity;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class BookSlab : Panel
    {
        protected Book _book;
        protected Label _shortInfo;
        protected PictureBox _picture;
        protected BookPanel _display;
        protected TransparentPanel _transparentPanel;


        public BookSlab(Book book, BookPanel display)
        {
            _book = book;
            _display = display;
            _shortInfo = new Label();
            _picture = new PictureBox();
            _transparentPanel = new TransparentPanel();
            SetParameters();
        }

        public Book GetBook()
        {
            return _book;
        }

        public void SetBook(Book book)
        {
            _book = book;
            _shortInfo.Text = Format(book.GetShortInfo());
            Form1.SetPicture(_picture, book.ImagePath);
        }

        private void SetParameters()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.FromArgb(252, 252, 238);
            AutoSize = true;
            MinimumSize = new Size(290, 100);

            SetPictureParameters();
            SetInfoParameters();
            ConfigureTransparentPanel();
        }

        private void ConfigureTransparentPanel()
        {
            _transparentPanel.Width = Width;
            _transparentPanel.Height = Height;
            _transparentPanel.Top = 0;
            _transparentPanel.Left = 0;
            _transparentPanel.MouseHover += slab_MouseHover;
            _transparentPanel.MouseLeave += slab_MouseLeave;
            _transparentPanel.MouseClick += slab_MouseClick;
            Controls.Add(_transparentPanel);
            _transparentPanel.BringToFront();
        }

        private void SetInfoParameters()
        {
            int indent = 5;
            _shortInfo.Left = _picture.Width + indent;
            _shortInfo.Top = indent;
            _shortInfo.AutoSize = true;
            _shortInfo.Text = Format(_book.GetShortInfo());
            Controls.Add(_shortInfo);
        }

        private string Format(string infoMessage)
        {
            int length = 30;
            char spliter = ' ';
            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();
            string[] words = infoMessage.Split(spliter);

            for (int i = 0; i < words.Length; i++)
            {
                if (line.Length + words[i].Length > length)
                {
                    result.Append(line.ToString().Trim());
                    result.Append('\n');
                    line.Clear();
                }

                line.Append(words[i]);
                line.Append(spliter);
            }

            result.Append(line.ToString().Trim());

            return result.ToString();
        }

        private void SetPictureParameters()
        {
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            _picture.Size = new Size(Height, Height);
            Form1.SetPicture(_picture, _book.ImagePath);
            Controls.Add(_picture);
        }

        private void slab_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(255, 248, 168);
            Cursor = Cursors.Hand;
        }

        private void slab_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(252, 252, 238);
            Cursor = Cursors.Default;
        }

        protected virtual void slab_MouseClick(object sender, EventArgs e)
        {
            _display.SetBook(_book);
        }
    }
}
