using System;
using System.Collections.Generic;
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

        }


    }
}
