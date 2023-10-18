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
        private AuthorPanel _authorPanel;

        public Form1()
        {
            InitializeComponent();
            _infoLabel = informLable;
            _myBookPanel = new BookPanel(storageBookPanel);
            int authorPanelTop = authorComboBox.Top + authorComboBox.Height + 5;
            _authorPanel = new AuthorPanel(authorPanelTop, 0, authorComboBox, shiftedPanel);
            changePanel.Controls.Add(_authorPanel);
            addedPictureBox.Image = Image.FromFile(XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture"));
        }

        private void addBookPanelButton_Click(object sender, EventArgs e)
        {
            Book book = new Book("Сиротки");
            book.AddAuthor("Мария Вой");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (imageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    addedPictureBox.Image = Image.FromFile(imageOpenFileDialog.FileName);
                }
                catch (Exception)
                {
                    SetMessage("Не удалось загрузить изображение");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _authorPanel.AddAuthor();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _authorPanel.Clear();
            nameTextBox.Text = string.Empty;
            authorComboBox.Text = string.Empty;
            publishingHouseComboBox.Text = string.Empty;
            yearTextBox.Text = string.Empty;
            addedPictureBox.Image = Image.FromFile(XMLLayer.XMLPathReader.GetInstance().GetPath("defaultBookPicture"));
        }
    }
}
