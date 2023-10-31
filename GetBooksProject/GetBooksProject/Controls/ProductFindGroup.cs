using GetBooksProject.URLLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class ProductFindGroup : FindGroup
    {
        public static Parser CurrentParser;

        public ProductFindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox, ShowProductPanel display) :
            base(findButton, conditionBox, reuestBox, display)
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
            string request = _request.Text;

            if (request != string.Empty)
            {
                try
                {
                    ShowProductPanel showDisplay = (ShowProductPanel)_slabDisplay;
                    LabirintParser parser = new LabirintParser();
                    showDisplay.Find(parser, request);
                    CurrentParser = parser;
                }
                catch (Exception ex)
                {
                    Form1.SetMessage(ex.Message);
                }
            }
        }
    }
}
