﻿using GetBooksProject.Controls;
using GetBooksProject.DBLayer;
using GetBooksProject.Entity;
using GetBooksProject.XMLLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GetBooksProject
{
    public partial class Form1 : Form
    {
        private static Label _infoLabel;
        private static string _defailtPicturePath;
        private StorageBookPanel _storageBookPanel;
        private ProductBookPanel _productBookPanel;
        private ChangePanel _changePanel;
        private StorageFindGroup _storageFindGroup;
        private ProductFindGroup _productFindGroup;
        private ShowProductPanel _showProductPanel;

        public Form1()
        {
            InitializeComponent();
            _infoLabel = informLable;
            _defailtPicturePath = XMLPathReader.GetInstance().GetPath("defaultBookPicture");
            _storageBookPanel = new StorageBookPanel(storageBookPanel);
            _storageBookPanel.SetChangeBook(ChangeBook);
            _storageBookPanel.SetDeleteBook(DeleteBook);
            _productBookPanel = new ProductBookPanel(productBookPanel);
            _productBookPanel.SetAddBook(AddBook);
            _changePanel = new ChangePanel(addChangeTabPage.Width / 2, addChangeTabPage.Width / 4);
            _storageFindGroup = new StorageFindGroup(findStorageBooksButton,
                storageFindConditionsComboBox, findStorageBookTextBox,
                storageBooksFlowLayoutPanel, _storageBookPanel);
            _showProductPanel = new ShowProductPanel(storageBooksFlowLayoutPanel.Top,
                storageBooksFlowLayoutPanel.Left, storageBooksFlowLayoutPanel.Width,
                storageBooksFlowLayoutPanel.Height, _productBookPanel);
            _productFindGroup = new ProductFindGroup(findProductsBooksButton,
                websitesComboBox, findProductBookTextBox,
                _showProductPanel);
            updateButton.MouseClick += Update;
            findBooksTabPage.Controls.Add(_showProductPanel);
            addChangeTabPage.Controls.Add(_changePanel);
        }

        public static void SetMessage(string message)
        {
            _infoLabel.Text = message;
        }

        public static void SetPicture(PictureBox picture, string path)
        {
            try
            {
                picture.Load(path);
            }
            catch (Exception)
            {
                try
                {
                    if (path != _defailtPicturePath)
                    {
                        picture.Image = Image.FromFile(_defailtPicturePath);
                    }
                    else
                    {
                        SetMessage($"Изображение {path} не найдено");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
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

        private void DeleteBook(StorageBook book)
        {
            BookWriter writer = new BookWriter();

            if (writer.DeleteBook(book.Id))
            {
                SetMessage($"Книга {book.Name} удалена");
                Update(this, new EventArgs());
                _changePanel.Clear(book);
            }
            else
            {
                SetMessage($"Ошибка при удалении книги {book.Name}");
            }
        }

        private void AddBook(ProductBook book)
        {
            tabControl1.SelectedTab = addChangeTabPage;
            _changePanel.SetBook(book);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Update(sender, e);
        }

        private void Update(object sender, EventArgs e)
        {
            storageBooksFlowLayoutPanel.Controls.Clear();
            _storageBookPanel.Clear();
            List<StorageBook> books = GetBooksFromDB();

            foreach (StorageBook book in books)
            {
                BookSlab slab = new BookSlab(book, _storageBookPanel);
                storageBooksFlowLayoutPanel.Controls.Add(slab);
            }

            _changePanel.SetAuthors(GetAuthorsFromDB());
            _changePanel.SetPublishingHouses(GetPuplishingHousesFormDB());
        }

        private List<string> GetPuplishingHousesFormDB()
        {
            PublishingHouseReader reader = new PublishingHouseReader();
            List<string> houses = new List<string>();

            try
            {
                houses = reader.GetAllPublishingHouses();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }

            return houses;
        }

        private List<StorageBook> GetBooksFromDB()
        {
            BookReader reader = new BookReader();
            List<StorageBook> books = new List<StorageBook>();

            try
            {
                books = reader.GetAllBooks();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }

            return books;
        }

        private List<string> GetAuthorsFromDB()
        {
            AuthorReader reader = new AuthorReader();
            List<string> authors = new List<string>();

            try
            {
                authors = reader.GetAllAuthors();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }

            return authors;
        }
    }
}
