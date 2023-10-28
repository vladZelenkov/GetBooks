using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class AuthorPanel : Panel
    {
        private List<ComboBox> _authors;
        private List<Button> _closeButtons;
        private ComboBox _topElement;
        private int _shiftPanelTop;
        private Panel _shiftPanel;

        public AuthorPanel(int top, int left, int width, ComboBox topElement, Panel shiftPanel)
        {
            _topElement = topElement;
            Left = left;
            Top = top;
            Width = width;
            AutoSize = true;
            Height = 0;
            _authors = new List<ComboBox>();
            _closeButtons = new List<Button>();
            _shiftPanel = shiftPanel;
            _shiftPanelTop = shiftPanel.Top;
        }

        public void AddAuthor()
        {
            int indent = 5;
            Button close = new Button();
            ComboBox author = new ComboBox();
            close.Height = author.Height;
            close.Width = close.Height;
            author.Left = _topElement.Left;
            author.Width = _topElement.Width;
            object[] authorItems = new object[_topElement.Items.Count];
            _topElement.Items.CopyTo(authorItems, 0);
            author.Items.AddRange(authorItems);
            close.Left = author.Left - close.Width - indent;
            close.Text = "X";
            _authors.Add(author);
            _closeButtons.Add(close);
            close.MouseClick += CloseButtonClick;
            Controls.Add(author);
            Controls.Add(close);
            Relocation();
        }

        private void Relocation()
        {
            int indent = 5;

            for (int i = 0; i < _authors.Count; i++)
            {
                _authors[i].Top = (_authors[i].Height + indent) * i;
                _closeButtons[i].Top = (_authors[i].Height + indent) * i;
            }

            _shiftPanel.Top = _shiftPanelTop + _authors.Count * (_topElement.Height + indent);
        }

        public void Clear()
        {
            for (int i = 0; i < _authors.Count; i++)
            {
                Controls.Remove(_authors[i]);
                Controls.Remove(_closeButtons[i]);
            }

            _authors.Clear();
            _closeButtons.Clear();
            Relocation();
        }

        public void SetAuthors(List<string> authors)
        {
            if (authors.Count > 0)
            {
                for (int i = 0; i < authors.Count; i++)
                {
                    if (i == 0)
                    {
                        _topElement.Text = authors[i];
                    }
                    else
                    {
                        AddAuthor();
                        _authors[i - 1].Text = authors[i];
                    }
                }
            }
        }

        public List<string> GetAuthors()
        {
            List<string> authors = new List<string>();

            if (_topElement.Text != "")
            {
                authors.Add(_topElement.Text);
            }

            foreach (ComboBox author in _authors)
            {
                if (author.Text != "")
                {
                    authors.Add(author.Text);
                }
            }

            return authors;
        }

        private void CloseButtonClick(object sendler, EventArgs e)
        {
            Button close = (Button)sendler;

            for (int i = 0; i < _closeButtons.Count; i++)
            {
                if (close.Equals(_closeButtons[i]))
                {
                    Controls.Remove(_closeButtons[i]);
                    Controls.Remove(_authors[i]);
                    _authors.RemoveAt(i);
                    _closeButtons.RemoveAt(i);
                    Relocation();
                }
            }
        }
    }
}
