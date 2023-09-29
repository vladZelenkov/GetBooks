using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
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

        public BookPanel(Book book, bool isPriceShow)
        {
            _book = book;
            _name = new Label();
            _author = new Label();
            _price = new Label();
            IsPriceShow = isPriceShow;
            SetParameters();
        }

        public bool IsPriceShow { get; set; }

        private void SetParameters()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BorderStyle = BorderStyle.FixedSingle;
            _name.Name = "nameLabel";
            _author.Name = "authorLabel";
            _price.Name = "priceLabel";
            _name.Text = _book.Name;
            _author.Text = _book.Author;
            //добавить Price в класс Book
            _price.Visible = false;
            AddLabel(_name);
            AddLabel(_author);
            AddLabel(_price);
        }

        private void AddLabel(Label label)
        {
            int indent = 5;
            System.Drawing.Size minSize = new System.Drawing.Size();
            minSize.Width = Width;

            label.AutoSize = true;
            label.MinimumSize = minSize;
            label.Margin = new Padding(0, indent, 0, indent);
            int top = 0;

            foreach (Control control in Controls)
            {
                top += control.Height + indent;
            }

            label.Top = top;
            Controls.Add(label);
        }
    }
}
