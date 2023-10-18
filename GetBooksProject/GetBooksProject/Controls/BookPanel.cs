using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class BookPanel
    {
        protected Panel _panel;
        protected PictureBox _picture;
        protected Label _info;
        protected Book _book;

        public BookPanel(Panel panel)
        {
            _panel = panel;
            _picture = new PictureBox();
            _info = new Label();
            SetPanelParameters();
        }

        private void SetPanelParameters()
        {
            _panel.AutoScroll = true;
            SetPictureParameters();
            SetInfoParameters();
        }

        private void SetPictureParameters()
        {
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            _picture.Height = _panel.Width;
            _picture.Dock = DockStyle.Top;
            string defaultImage = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            _picture.Image = Image.FromFile(defaultImage);
            _panel.Controls.Add(_picture);
        }

        private void SetInfoParameters()
        {
            int indent = 5;
            _info.Top = _picture.Height + indent;
            _info.Left = indent;
            _info.AutoSize = true;
            _info.MaximumSize = new Size(_panel.Width - indent * 2, 0);
            _info.Text = "book\nauthors\npublichingHouse";
            _panel.Controls.Add(_info);
        }

        public virtual void SetBook(Book book)
        {
            _picture.Image = Image.FromFile(book.ImagePath);
            _info.Text = book.GetFullInfo();
            _book = book;
        }
    }
}
