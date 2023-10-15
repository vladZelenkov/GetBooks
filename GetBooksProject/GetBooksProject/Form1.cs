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
        private BookPanel _myBookPanel;

        public Form1()
        {
            InitializeComponent();
            _infoLabel = informLable;
            _myBookPanel = new BookPanel(storageBookPanel);
        }

        private void addBookPanelButton_Click(object sender, EventArgs e)
        {
            Book book = new Book("Сиротки");
            book.AddAuthor("Мария Вой");
            book.PublishingHouse = "ООО Издательство \"Эксмо\"";
            book.Year = 2022;
            BookSlab bookPanel = new BookSlab(book, true);
            FlowLayoutPanel panel = storageBooksFlowLayoutPanel;
            bookPanel.Size = new Size(panel.Width - panel.Margin.Left - SystemInformation.VerticalScrollBarWidth, 0);
            storageBooksFlowLayoutPanel.Controls.Add(bookPanel);
        }

        public static void SetMessage(string message)
        {
            _infoLabel.Text = message;
        }
    }
}
