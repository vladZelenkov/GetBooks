using GetBooksProject.Controls;
using GetBooksProject.DBLayer;
using GetBooksProject.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GetBooksProject
{
    public partial class Form1 : Form
    {
        private static Label _infoLabel;
        private StorageBookPanel _storageBookPanel;
        private ProductBookPanel _productBookPanel;
        private ChangePanel _changePanel;
        private StorageFindGroup _storageFindGroup;
        private ProductFindGroup _productFindGroup;

        public Form1()
        {
            InitializeComponent();
            _infoLabel = informLable;
            _storageBookPanel = new StorageBookPanel(storageBookPanel);
            _storageBookPanel.SetChangeBook(ChangeBook);
            _productBookPanel = new ProductBookPanel(productBookPanel);
            _productBookPanel.SetAddBook(AddBook);
            _changePanel = new ChangePanel(addChangeTabPage.Width / 2, addChangeTabPage.Width / 4);
            _storageFindGroup = new StorageFindGroup(findStorageBooksButton,
                storageFindConditionsComboBox, findStorageBookTextBox,
                storageBooksFlowLayoutPanel, _storageBookPanel);
            _productFindGroup = new ProductFindGroup(findProductsBooksButton,
                websitesComboBox, findProductBookTextBox,
                productBooksFlowLayoutPanel, _productBookPanel);
            updateButton.MouseClick += Form1_Load;
            addChangeTabPage.Controls.Add(_changePanel);
        }

        private void findProductsBooksButton_Click(object sender, EventArgs e)
        {
            ProductBook book = new ProductBook("Сиротки");
            book.AddAuthor("Мария Вой");
            book.AddAuthor("Александр Пушкин");
            book.PriceMessage = "100 руб";
            book.PublishingHouse = "ООО Издательство \"Эксмо\"";
            book.Year = 2022;
            BookSlab bookPanel = new BookSlab(book, _productBookPanel);
            FlowLayoutPanel panel = storageBooksFlowLayoutPanel;
            bookPanel.Size = new Size(panel.Width - panel.Margin.Left - SystemInformation.VerticalScrollBarWidth, 0);
            productBooksFlowLayoutPanel.Controls.Add(bookPanel);
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
            tabControl1.SelectedTab = addChangeTabPage;
            _changePanel.SetBook(book);
        }

        private void AddBook(ProductBook book)
        {
            tabControl1.SelectedTab = addChangeTabPage;
            _changePanel.SetBook(book);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            storageBooksFlowLayoutPanel.Controls.Clear();

            BookReader bookReader = new BookReader();

            try
            {
                List<StorageBook> books = bookReader.GetAllBooks();

                foreach (StorageBook book in books)
                {
                    BookSlab slab = new BookSlab(book, _storageBookPanel);
                    storageBooksFlowLayoutPanel.Controls.Add(slab);
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }

            AuthorReader authorReader = new AuthorReader();

            try
            {
                List<string> authors = authorReader.GetAllAuthors();
                _changePanel.SetAuthors(authors);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }
    }
}
