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
            _shiftPanel.Controls.Add(_change);

            Controls.Add(nameLabel);
            Controls.Add(authorLabel);
            Controls.Add(_name);
            Controls.Add(_author);
            Controls.Add(_shiftPanel);
        }

        public void SetBook(Book book)
        {
            clearMouseClick(_clear, new EventArgs());
            _book = book;
            _name.Text = _book.Name;
            _publishingHouse.Text = book.PublishingHouse;
            _year.Text = book.Year.ToString();
            _authors.SetAuthors(book.GetAuthors());

            switch (book)
            {
                case StorageBook storageBook:
                    SetImage(book.ImagePath);
                    _change.Text = "Изменить";
                    break;

                case ProductBook productBook:
                    break;
            }
        }

        private void SetImage(string path)
        {
            try
            {
                _image.Image = Image.FromFile(path);
                IsDefaultImage = path == _defaultImagePath;

                if (IsDefaultImage)
                {
                    _setImage.Text = "Выбрать изображение";
                }
                else
                {
                    _setImage.Text = "Убрать изображение";
                }
            }
            catch (Exception)
            {
                Form1.SetMessage("Не удалось загрузить изображение");
            }
        }

        public void SetAuthors(List<string> authors)
        {
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

        private void clearMouseClick(object sender, EventArgs e)
        {
            _authors.Clear();
            _book = null;
            _name.Text = string.Empty;
            _author.Text = string.Empty;
            _publishingHouse.Text = string.Empty;
            _year.Text = string.Empty;
            SetImage(_defaultImagePath);
            _change.Text = "Добавить";
        }
    }
}
