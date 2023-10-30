using GetBooksProject.Entity;
using GetBooksProject.URLLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class ShowProductPanel : Panel
    {
        private TabControl _tabControl;
        private Parser _parser;
        private BookPanel _display;

        public ShowProductPanel(int top, int left, int width, int height, BookPanel display)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
            _display = display;
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BorderStyle = BorderStyle.FixedSingle;
        }

        public void Find(Parser parser, string request)
        {
            try
            {
                _parser = parser;
                int pageCount = _parser.GetPageCount(request);
                _tabControl = new TabControl();
                _tabControl.Dock = DockStyle.Fill;

                for (int i = 1; i <= pageCount; i++)
                {
                    _tabControl.TabPages.Add(CreatePage(i.ToString()));
                }

                Controls.Clear();
                _tabControl.SelectedIndex = 0;
                _tabControl.SelectedIndexChanged += SwitchPage;
                SwitchPage(this, new EventArgs());
                FlowLayoutPanel panel = (FlowLayoutPanel)_tabControl.SelectedTab.Controls[0];

                if (panel.Controls.Count != 0)
                {
                    Controls.Add(_tabControl);
                }
                else
                {
                    _tabControl = null;
                    Form1.SetMessage("По данному запросу результатов не найдено");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private TabPage CreatePage(string text)
        {
            TabPage page = new TabPage();
            page.Text = text;
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = System.Drawing.Color.White;
            page.Controls.Add(panel);
            panel.AutoScroll = true;
            return page;
        }

        private void SwitchPage(object sender, EventArgs e)
        {
            int currentPage = _tabControl.SelectedIndex;
            FlowLayoutPanel panel = (FlowLayoutPanel)_tabControl.SelectedTab.Controls[0];

            if (panel.Controls.Count == 0)
            {
                List<ProductBook> books = _parser.GetBooks(currentPage + 1);
                BookSlab[] slabs = new BookSlab[books.Count];

                for (int i = 0; i < slabs.Length; i++)
                {
                    BookSlab slab = new BookSlab(books[i], _display);
                    slab.MouseClick += GetFullInfo;
                    slabs[i] = slab;
                }

                panel.Controls.AddRange(slabs);
            }
        }

        private void GetFullInfo(object sender, EventArgs e)
        {

        }
    }
}
