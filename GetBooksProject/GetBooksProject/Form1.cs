using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetBooksProject.Controls;
using GetBooksProject.Entity;

namespace GetBooksProject
{
    public partial class Form1 : Form
    {
        private static Label _infoLabel;
        private StorageBookPanel _myBookPanel;
        private ChangePanel _changePanel;

        public Form1()
        {
            InitializeComponent();
            _infoLabel = informLable;
            _myBookPanel = new StorageBookPanel(storageBookPanel);
            _myBookPanel.SetChangeBook(ChangeBook);
            _changePanel = new ChangePanel(addChangeTabPage.Width / 2, addChangeTabPage.Width / 4);
            addChangeTabPage.Controls.Add(_changePanel);
        }

        private void addBookPanelButton_Click(object sender, EventArgs e)
        {
            Book book = new StorageBook(1, "Сиротки");
            book.AddAuthor("Мария Вой");
            book.AddAuthor("Александр Пушкин");
            book.PublishingHouse = "ООО Издательство \"Эксмо\"";
            book.Year = 2022;
            BookSlab bookPanel = new BookSlab(book, _myBookPanel);
            FlowLayoutPanel panel = storageBooksFlowLayoutPanel;
            bookPanel.Size = new Size(panel.Width - panel.Margin.Left - SystemInformation.VerticalScrollBarWidth, 0);
            storageBooksFlowLayoutPanel.Controls.Add(bookPanel);
        }

        public static void SetMessage(string message)
        {
            _infoLabel.Text = message;
        }

        private void yearTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int currentDate = DateTime.Now.Year;

            if (int.TryParse(textBox.Text, out int value))
            {
                if (value >= 0 && value <= currentDate)
                {
                    textBox.ForeColor = Color.Black;
                }
                else
                {
                    textBox.ForeColor = Color.Red;
                }
            }
            else
            {
                textBox.ForeColor = Color.Red;
            }
        }

        private void ChangeBook(StorageBook book)
        {
            tabControl1.SelectedIndex = 2;
            _changePanel.SetBook(book);
        }
    }
}
