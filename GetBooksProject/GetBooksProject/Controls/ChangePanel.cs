﻿using GetBooksProject.DBLayer;
using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class ChangePanel : Panel
    {
        private TextBox _name;
        private ComboBox _author;
        private AuthorPanel _authors;
        private Button _addAuthor;
        private Button _setImage;
        private Button _clear;
        private Button _change;
        private PictureBox _image;
        private Panel _shiftPanel;
        private ComboBox _publishingHouse;
        private OpenFileDialog _openImage;
        private TextBox _year;
        private Book _book;
        private string _defaultImagePath;
        private ChangeMode _currentChangeMode;

        public ChangePanel(int width, int left)
        {
            Width = width;
            Left = left;
            _name = new TextBox();
            _author = new ComboBox();
            _shiftPanel = new Panel();
            _addAuthor = new Button();
            _setImage = new Button();
            _clear = new Button();
            _change = new Button();
            _image = new PictureBox();
            _openImage = new OpenFileDialog();
            _publishingHouse = new ComboBox();
            _year = new TextBox();
            _defaultImagePath = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            SetParameters();
            clearMouseClick(_clear, new EventArgs());
        }

        private bool IsDefaultImage { get; set; }

        private void SetParameters()
        {
            int indent = 5;
            int buttonHeight = 30;
            Anchor = AnchorStyles.Top;
            AutoSize = true;
            //name
            Label nameLabel = new Label();
            nameLabel.Text = "Название";
            nameLabel.Top = indent;
            nameLabel.Left = indent;
            _name.Width = Width / 4 * 3;
            _name.Left = Width - _name.Width - indent;
            _name.Top = indent;
            //author
            Label authorLabel = new Label();
            authorLabel.Top = _name.Bottom + indent;
            authorLabel.Text = "Автор";
            authorLabel.Left = indent;
            _author.Top = _name.Bottom + indent;
            _author.Width = _name.Width;
            _author.Left = _name.Left;
            _author.IntegralHeight = false;
            _author.MaxDropDownItems = 8;
            //shiftPanel
            _shiftPanel.Top = _author.Bottom + indent;
            _shiftPanel.Width = Width;
            _shiftPanel.Left = 0;
            _shiftPanel.AutoSize = true;
            //addAuthor
            _addAuthor.Top = 0;
            _addAuthor.Left = _name.Left;
            _addAuthor.Text = "Добавить автора";
            _addAuthor.Width = _name.Width;
            _addAuthor.Height = buttonHeight;
            _shiftPanel.Controls.Add(_addAuthor);
            //authors
            _authors = new AuthorPanel(_author.Bottom + indent, 0, Width, _author, _shiftPanel);
            _addAuthor.MouseClick += addAuthorMouseClick;
            Controls.Add(_authors);
            //publishingHouse
            Label publishingHouseLabel = new Label();
            publishingHouseLabel.Top = _addAuthor.Bottom + indent;
            publishingHouseLabel.Left = indent;
            publishingHouseLabel.Text = "Издательство";
            _shiftPanel.Controls.Add(publishingHouseLabel);
            _publishingHouse.Top = _addAuthor.Bottom + indent;
            _publishingHouse.Width = _name.Width;
            _publishingHouse.Left = _name.Left;
            _publishingHouse.IntegralHeight = false;
            _publishingHouse.MaxDropDownItems = 8;
            _shiftPanel.Controls.Add(_publishingHouse);
            //year
            Label yearLabel = new Label();
            yearLabel.Top = _publishingHouse.Bottom + indent;
            yearLabel.Left = indent;
            yearLabel.Text = "Год издания";
            _shiftPanel.Controls.Add(yearLabel);
            _year.Top = _publishingHouse.Bottom + indent;
            _year.Left = _name.Left;
            _year.Width = _name.Width / 2;
            _shiftPanel.Controls.Add(_year);
            //setImage
            _setImage.Top = _year.Bottom + indent;
            _setImage.Width = Width / 2;
            _setImage.Left = _year.Left;
            _setImage.Height = buttonHeight;
            _setImage.MouseClick += setImageMouseClick;
            _shiftPanel.Controls.Add(_setImage);
            //image
            _image.Top = _setImage.Bottom + indent;
            _image.Left = _setImage.Left;
            _image.Width = _setImage.Width;
            _image.Height = _image.Width;
            _image.SizeMode = PictureBoxSizeMode.Zoom;
            _image.BorderStyle = BorderStyle.FixedSingle;
            _shiftPanel.Controls.Add(_image);
            //clear
            _clear.Top = _image.Bottom + indent;
            _clear.Left = indent;
            _clear.Width = Width / 2 - indent * 2;
            _clear.Text = "Очистить";
            _clear.Height = buttonHeight;
            _clear.MouseClick += clearMouseClick;
            _shiftPanel.Controls.Add(_clear);
            //change
            _change.Top = _clear.Top;
            _change.Width = _clear.Width;
            _change.Left = Width - indent - _change.Width;
            _change.Height = buttonHeight;
            _change.MouseClick += addBookMouseClick;
            _change.Text = "Добавить";
            _currentChangeMode = ChangeMode.Add;
            _shiftPanel.Controls.Add(_change);

            Controls.Add(nameLabel);
            Controls.Add(authorLabel);
            Controls.Add(_name);
            Controls.Add(_author);
            Controls.Add(_shiftPanel);
        }

        public void SetPublishingHouses(List<string> houses)
        {
            _publishingHouse.Items.Clear();

            foreach (string house in houses)
            {
                _publishingHouse.Items.Add(house);
            }
        }

        public void SetBook(Book book)
        {
            clearMouseClick(_clear, new EventArgs());
            _book = book;
            _name.Text = _book.Name;
            _publishingHouse.Text = book.PublishingHouse;

            if (book.Year != 0)
            {
                _year.Text = book.Year.ToString();
            }

            _authors.SetAuthors(book.GetAuthors());
            SetImage(book.ImagePath);

            switch (book)
            {
                case StorageBook storageBook:
                    SwitchChangeMode(ChangeMode.Change);
                    break;

                case ProductBook productBook:
                    SwitchChangeMode(ChangeMode.Add);
                    break;
            }
        }

        private void SetImage(string path)
        {
            Form1.SetPicture(_image, path);
            IsDefaultImage = path == _defaultImagePath || path == string.Empty;

            if (IsDefaultImage)
            {
                _setImage.Text = "Выбрать изображение";
            }
            else
            {
                _setImage.Text = "Убрать изображение";
            }

        }

        private void SwitchChangeMode(ChangeMode mode)
        {
            if (_currentChangeMode != mode)
            {
                switch (mode)
                {
                    case ChangeMode.Add:
                        _change.MouseClick -= changeBookMouseClick;
                        _change.MouseClick += addBookMouseClick;
                        _change.Text = "Добавить";
                        _currentChangeMode = ChangeMode.Add;
                        break;

                    case ChangeMode.Change:
                        _change.MouseClick -= addBookMouseClick;
                        _change.MouseClick += changeBookMouseClick;
                        _change.Text = "Изменить";
                        _currentChangeMode = ChangeMode.Change;
                        break;
                }
            }
        }

        public void SetAuthors(List<string> authors)
        {
            _author.Items.Clear();

            foreach (string author in authors)
            {
                _author.Items.Add(author);
            }
        }

        private void addAuthorMouseClick(object sender, EventArgs e)
        {
            _authors.AddAuthor();
        }

        private void setImageMouseClick(object sender, EventArgs e)
        {
            if (IsDefaultImage)
            {
                if (_openImage.ShowDialog() == DialogResult.OK)
                {
                    SetImage(_openImage.FileName);
                }
            }
            else
            {
                SetImage(_defaultImagePath);
            }

        }

        private bool IsDataCorrect()
        {
            string name = _name.Text;
            string textYear = _year.Text;
            bool isDataCorrect = true;

            if (name == string.Empty)
            {
                isDataCorrect = false;
                Form1.SetMessage("Неверный ввод: Заполните поле \"Название\"");

                if (textYear != "")
                {
                    if (int.TryParse(textYear, out int publishingYear) == false)
                    {
                        isDataCorrect = false;
                        Form1.SetMessage("Неверный ввод: Неверное значение в поле \"Год издания\"");
                    }
                }
            }

            return isDataCorrect;
        }

        private void changeBookMouseClick(object sender, EventArgs e)
        {
            if (IsDataCorrect())
            {
                string name = _name.Text;
                StorageBook book = new StorageBook(((StorageBook)_book).Id, name);
                book.PublishingHouse = _publishingHouse.Text;
                int.TryParse(_year.Text, out int year);
                book.Year = year;
                book.ImagePath = _image.ImageLocation;
                List<string> authors = _authors.GetAuthors();

                foreach (string author in authors)
                {
                    book.AddAuthor(author);
                }

                try
                {
                    BookWriter writer = new BookWriter();
                    writer.ChangeBook(book);
                    Form1.SetMessage("Изменения внесены");
                }
                catch (Exception ex)
                {
                    Form1.SetMessage(ex.Message);
                }
            }
        }

        private void addBookMouseClick(object sender, EventArgs e)
        {
            if (IsDataCorrect())
            {
                string name = _name.Text;
                string textYear = _year.Text;
                Book book = new Book(name);
                int.TryParse(textYear, out int year);
                book.Year = year;
                List<string> authors = _authors.GetAuthors();
                string publishingHouse = _publishingHouse.Text;
                string imagePath = _image.ImageLocation;

                foreach (string author in authors)
                {
                    book.AddAuthor(author);
                }

                if (publishingHouse != "")
                {
                    book.PublishingHouse = publishingHouse;
                }


                if (imagePath != _defaultImagePath)
                {
                    book.ImagePath = imagePath;
                }

                BookWriter writer = new BookWriter();

                try
                {
                    if (writer.AddBook(book))
                    {
                        Form1.SetMessage($"Успешно: Книга {book.Name} добавлена в библиотеку");
                    }
                    else
                    {
                        Form1.SetMessage("Не удалось добавить книгу");
                    }
                }
                catch (Exception ex)
                {
                    Form1.SetMessage(ex.Message);
                }
            }
        }

        public void Clear(StorageBook book)
        {
            if (_book is StorageBook)
            {
                if (book.Id == ((StorageBook)_book).Id)
                {
                    clearMouseClick(_clear, new EventArgs());
                }
            }
        }

        private void clearMouseClick(object sender, EventArgs e)
        {
            _authors.Clear();
            _book = null;
            _name.Text = string.Empty;
            _author.Text = string.Empty;
            _publishingHouse.Text = string.Empty;
            _year.Text = string.Empty;
            SetImage(_defaultImagePath);
            SwitchChangeMode(ChangeMode.Add);
        }
    }
}
