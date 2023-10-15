using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class BookSlab : Panel
    {
        private Book _book;
        private Label _name;
        private Label _author;
        private Label _price;
        private PictureBox _picture;
        private string _defailtPicturePath;


        public BookSlab(Book book, bool isPriceShow)
        {
            _book = book;
            _name = new Label();
            _author = new Label();
            _price = new Label();
            _picture = new PictureBox();
            _defailtPicturePath = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            IsPriceShow = isPriceShow;
            SetParameters();
        }

        public bool IsPriceShow { get; set; }

        private void SetParameters()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.FromArgb(252, 252, 238);
            AutoSize = true;
            Margin = new Padding(3);
            _name.Text = _book.Name;
            List<string> authors = _book.GetAuthors();
            _author.Text = authors[0];

            for (int i = 1; i < authors.Count; i++)
            {
                _author.Text += ", " + authors[i];
            }

            if (_book is ProductBook)
            {
                ProductBook book = (ProductBook)_book;
                if (book.PriceMessage == string.Empty)
                {
                    _price.Text = "Нет в продаже";
                }
                else
                {
                    _price.Text = book.PriceMessage + " руб.";
                }

                if (!IsPriceShow)
                {
                    _price.Visible = false;
                }
            }

            SetPicture(_defailtPicturePath);
            SetPictureParameters();
            Controls.Add(_picture);
            AddLabel(_name);
            AddLabel(_author);
            AddLabel(_price);
        }

        private void SetPictureParameters()
        {
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            _picture.Size = new Size(100, 100);
        }

        private void AddLabel(Label label)
        {
            int indent = 5;
            Size minSize = new Size();
            minSize.Width = Width;

            label.AutoSize = true;
            label.MinimumSize = minSize;
            label.Margin = new Padding(0, indent, 0, indent);
            int top = 0;

            foreach (Control control in Controls)
            {
                if (control is Label)
                {
                    top += control.Height + indent;
                }
            }

            label.Top = top;
            label.Left = _picture.Width;
            Controls.Add(label);
        }

        public void SetPicture(string path)
        {
            try
            {
                _picture.Image = Image.FromFile(path);
            }
            catch (FileNotFoundException)
            {
                try
                {
                    if (path != _defailtPicturePath)
                    {
                        _picture.Image = Image.FromFile(_defailtPicturePath);
                    }
                    else
                    {
                        Form1.SetMessage($"Изображение {path} не найдено");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            BackColor = Color.FromArgb(255, 248, 168);
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.FromArgb(252, 252, 238);
            Cursor = Cursors.Default;
        }
    }
}
