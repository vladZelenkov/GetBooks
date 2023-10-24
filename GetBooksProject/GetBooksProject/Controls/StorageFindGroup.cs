using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetBooksProject.Controls
{
    class StorageFindGroup : FindGroup
    {
        public StorageFindGroup(Button findButton, ComboBox conditionBox, TextBox reuestBox) : base(findButton, conditionBox, reuestBox) { }

        protected override void SetOptions()
        {
            SearchOptions.Add("Название", findForName);
            SearchOptions.Add("Автор", findForAuthor);
            SearchOptions.Add("Издательство", findForPublishingHouse);
            SearchOptions.Add("Год", findForYear);
            Dictionary<string, ButtonClick>.KeyCollection keys = SearchOptions.Keys;

            foreach (string key in keys)
            {
                Condition.Items.Add(key);
            }

            Condition.SelectedIndex = 0;
        }

        private void findForName(object sender, EventArgs e)
        {
            Form1.SetMessage("Name");
        }

        private void findForAuthor(object sender, EventArgs e)
        {
            Form1.SetMessage("Author");
        }

        private void findForPublishingHouse(object sender, EventArgs e)
        {
            Form1.SetMessage("PublishingHouse");
        }

        private void findForYear(object sender, EventArgs e)
        {
            Form1.SetMessage("Year");
        }
    }
}
