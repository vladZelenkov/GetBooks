using GetBooksProject.Entity;
using GetBooksProject.XMLLayer;
using System.Drawing;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class BookPanel
    {
        protected Panel Panel;
        protected PictureBox Picture;
        protected Label Info;
        protected Book Book;

        public BookPanel(Panel panel)
        {
            Panel = panel;
            Picture = new PictureBox();
            Info = new Label();
            SetPanelParameters();
        }

        protected int ButtonHeight { get; } = 30;
        protected int ButtonIndent { get; } = 2;

        private void SetPanelParameters()
        {
            Panel.AutoScroll = true;
            SetPictureParameters();
            SetInfoParameters();
        }

        private void SetPictureParameters()
        {
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
            Picture.Height = Panel.Width;
            Picture.Dock = DockStyle.Top;
            Panel.Controls.Add(Picture);
        }

        private void SetInfoParameters()
        {
            int indent = 5;
            Info.Top = Picture.Height + indent;
            Info.Left = indent;
            Info.AutoSize = true;
            Info.MaximumSize = new Size(Panel.Width - indent * 2, 0);
            Info.Text = string.Empty;
            Info.Anchor = AnchorStyles.Top;
            Panel.Controls.Add(Info);
        }

        public virtual void SetBook(Book book)
        {
            Form1.SetPicture(Picture, book.ImagePath);
            Info.Text = book.GetFullInfo();
            Book = book;
        }

        public virtual void Clear()
        {
            Info.Text = string.Empty;
            string defaultImage = XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            Picture.Load(defaultImage);
            Book = null;
        }
    }
}
