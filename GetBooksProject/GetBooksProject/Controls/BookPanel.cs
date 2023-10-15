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
        private Panel _panel;
        private PictureBox _picture;

        public BookPanel(Panel panel)
        {
            _panel = panel;
            _picture = new PictureBox();
            SetParameters();
        }

        private void SetParameters()
        {
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            _picture.Height = _panel.Width;
            _picture.Dock = DockStyle.Top;
            string defaultImage = XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            _picture.Image = Image.FromFile(defaultImage);
            _panel.Controls.Add(_picture);
        }
    }
}
