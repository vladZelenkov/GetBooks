using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    abstract class FindGroup
    {
        protected Button Find;
        protected ComboBox Condition;
        protected TextBox Request;
        protected delegate void ButtonClick(object sender, EventArgs e);
        protected Dictionary<string, ButtonClick> SearchOptions;

        public FindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox)
        {
            Find = findButton;
            Condition = conditionBox;
            Request = reuestBox;
            SearchOptions = new Dictionary<string, ButtonClick>();
            Find.MouseClick += findButtonClick;
            Condition.DropDownStyle = ComboBoxStyle.DropDownList;
            SetOptions();
        }

        abstract protected void SetOptions();

        private void findButtonClick(object sender, EventArgs e)
        {
            if (Condition.SelectedItem != null)
            {
                string currentItem = Condition.SelectedItem.ToString();

                if (SearchOptions[currentItem] != null)
                {
                    SearchOptions[currentItem].Invoke(sender, e);
                }
            }
        }
    }
}
