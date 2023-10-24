using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    abstract class FindGroup
    {
        protected Button _find;
        protected ComboBox _condition;
        protected TextBox _request;
        protected FlowLayoutPanel _slabDisplay;
        protected BookPanel _bookDisplay;
        protected delegate void ButtonClick(object sender, EventArgs e);
        protected Dictionary<string, ButtonClick> _searchOptions;

        public FindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox, FlowLayoutPanel slabDisplay, BookPanel bookDisplay)
        {
            _find = findButton;
            _condition = conditionBox;
            _request = reuestBox;
            _slabDisplay = slabDisplay;
            _bookDisplay = bookDisplay;
            _searchOptions = new Dictionary<string, ButtonClick>();
            _find.MouseClick += findButtonClick;
            _condition.DropDownStyle = ComboBoxStyle.DropDownList;
            SetOptions();
        }

        abstract protected void SetOptions();

        private void findButtonClick(object sender, EventArgs e)
        {
            if (_condition.SelectedItem != null)
            {
                string currentItem = _condition.SelectedItem.ToString();

                if (_searchOptions[currentItem] != null)
                {
                    _searchOptions[currentItem].Invoke(sender, e);
                }
            }
        }
    }
}
