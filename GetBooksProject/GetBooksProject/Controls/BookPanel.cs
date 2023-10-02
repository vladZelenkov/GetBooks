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
    class BookPanel : Panel
    {
        private Book _book;
        private Label _name;
        private Label _author;
        private Label _price;
        private PictureBox _picture;
        private Button _details;
        private string _defailtPicturePath = "Pictures\\defaultBookPicture.png";


        public BookPanel(Book book, bool isPriceShow)
        {
            _book = book;
            _name = new Label();
            _author = new Label();
            _price = new Label();
            _picture = new PictureBox();
            _details = new Button();
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
            _author.Text = _book.Author;

            if (_book.Price == 0)
            {
                _price.Text = "Нет в продаже";
            }
            else
            {
                _price.Text = _book.Price.ToString() + " руб.";
            }

            if (!IsPriceShow)
            {
                _price.Visible = false;
            }

            SetPicture(_defailtPicturePath);
            SetPictureParameters();
            Controls.Add(_picture);
            AddLabel(_name);
            AddLabel(_author);
            AddLabel(_price);
            SetDetailsButtonParameters();
            Controls.Add(_details);
        }

        private void SetPictureParameters()
        {
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            _picture.Size = new Size(100, 100);
        }

        private void SetDetailsButtonParameters()
        {
            _details.AutoSize = true;
            _details.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            _details.Left = _picture.Width;
            _details.Text = "Подробнее";
            _details.Top = Height - _details.Height;
            _details.BackColor = Color.FromArgb(232, 232, 179);
            _details.FlatStyle = FlatStyle.Flat;
            _details.FlatAppearance.BorderColor = Color.FromArgb(232, 232, 179);
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
                        throw;
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
    }
}
