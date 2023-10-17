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
        private Label _shortInfo;
        private PictureBox _picture;
        private BookPanel _display;
        private string _defailtPicturePath;


        public BookSlab(Book book, BookPanel display)
        {
            _book = book;
            _display = display;
            _shortInfo = new Label();
            _picture = new PictureBox();
            _defailtPicturePath = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            SetParameters();
        }

        private void SetParameters()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.FromArgb(252, 252, 238);
            AutoSize = true;
            MinimumSize = new Size(290, 100);
            MouseHover += slab_MouseHover;
            MouseLeave += slab_MouseLeave;
            MouseClick += slab_MouseClick;

            SetPictureParameters();
            SetInfoParameters();
            SetPicture(_defailtPicturePath);
        }

        private void SetInfoParameters()
        {
            int indent = 5;
            _shortInfo.Left = _picture.Width + indent;
            _shortInfo.Top = indent;
            _shortInfo.AutoSize = true;
            _shortInfo.Text = _book.GetShortInfo();
            _shortInfo.MouseHover += slab_MouseHover;
            _shortInfo.MouseLeave += slab_MouseLeave;
            _shortInfo.MouseClick += slab_MouseClick;
            Controls.Add(_shortInfo);
        }

        private void SetPictureParameters()
        {
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            _picture.Size = new Size(100, 100);
            _picture.MouseHover += slab_MouseHover;
            _picture.MouseLeave += slab_MouseLeave;
            _picture.MouseClick += slab_MouseClick;
            Controls.Add(_picture);
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

        private void slab_MouseClick(object sender, EventArgs e)
        {
            _display.SetBook(_book);
        }
    }
}
