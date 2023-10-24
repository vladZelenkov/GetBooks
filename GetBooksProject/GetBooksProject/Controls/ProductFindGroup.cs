using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class ProductFindGroup : FindGroup
    {
        public ProductFindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox) : base(findButton, conditionBox, reuestBox) { }

        protected override void SetOptions()
        {
            SearchOptions.Add("Labirint", findOnLabirint);
            Dictionary<string, ButtonClick>.KeyCollection keys = SearchOptions.Keys;

            foreach (string key in keys)
            {
                Condition.Items.Add(key);
            }

            Condition.SelectedIndex = 0;
        }

        private void findOnLabirint(object sender, EventArgs e)
        {
            Form1.SetMessage("Labirint");
        }
    }
}
