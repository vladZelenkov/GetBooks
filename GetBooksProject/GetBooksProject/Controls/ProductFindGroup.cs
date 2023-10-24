using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class ProductFindGroup : FindGroup
    {
        public ProductFindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox, FlowLayoutPanel display, BookPanel bookDisplay) :
            base(findButton, conditionBox, reuestBox, display, bookDisplay)
        { }

        protected override void SetOptions()
        {
            _searchOptions.Add("Labirint", findOnLabirint);
            Dictionary<string, ButtonClick>.KeyCollection keys = _searchOptions.Keys;

            foreach (string key in keys)
            {
                _condition.Items.Add(key);
            }

            _condition.SelectedIndex = 0;
        }

        private void findOnLabirint(object sender, EventArgs e)
        {
            Form1.SetMessage("Labirint");
        }
    }
}
