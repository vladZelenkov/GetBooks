
namespace GetBooksProject
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.myBooksTabPage = new System.Windows.Forms.TabPage();
            this.updateButton = new System.Windows.Forms.Button();
            this.bookParametersComboBox = new System.Windows.Forms.ComboBox();
            this.findStorageBookTextBox = new System.Windows.Forms.TextBox();
            this.findStorageBooksButton = new System.Windows.Forms.Button();
            this.storageBookPanel = new System.Windows.Forms.Panel();
            this.storageBooksFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.findBooksTabPage = new System.Windows.Forms.TabPage();
            this.websitesComboBox = new System.Windows.Forms.ComboBox();
            this.findProductBookTextBox = new System.Windows.Forms.TextBox();
            this.findProductsBooksButton = new System.Windows.Forms.Button();
            this.productBookPanel = new System.Windows.Forms.Panel();
            this.productBooksFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addChangeTabPage = new System.Windows.Forms.TabPage();
            this.informPanel = new System.Windows.Forms.Panel();
            this.informLable = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.publishingHouseLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.publishingHouseComboBox = new System.Windows.Forms.ComboBox();
            this.imageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.addedPictureBox = new System.Windows.Forms.PictureBox();
            this.addChangeButton = new System.Windows.Forms.Button();
            this.changePanel = new System.Windows.Forms.Panel();
            this.shiftedPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.myBooksTabPage.SuspendLayout();
            this.findBooksTabPage.SuspendLayout();
            this.addChangeTabPage.SuspendLayout();
            this.informPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addedPictureBox)).BeginInit();
            this.changePanel.SuspendLayout();
            this.shiftedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.myBooksTabPage);
            this.tabControl1.Controls.Add(this.findBooksTabPage);
            this.tabControl1.Controls.Add(this.addChangeTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 489);
            this.tabControl1.TabIndex = 0;
            // 
            // myBooksTabPage
            // 
            this.myBooksTabPage.Controls.Add(this.updateButton);
            this.myBooksTabPage.Controls.Add(this.bookParametersComboBox);
            this.myBooksTabPage.Controls.Add(this.findStorageBookTextBox);
            this.myBooksTabPage.Controls.Add(this.findStorageBooksButton);
            this.myBooksTabPage.Controls.Add(this.storageBookPanel);
            this.myBooksTabPage.Controls.Add(this.storageBooksFlowLayoutPanel);
            this.myBooksTabPage.Location = new System.Drawing.Point(4, 22);
            this.myBooksTabPage.Name = "myBooksTabPage";
            this.myBooksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.myBooksTabPage.Size = new System.Drawing.Size(894, 463);
            this.myBooksTabPage.TabIndex = 0;
            this.myBooksTabPage.Text = "Мои книги";
            this.myBooksTabPage.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.Location = new System.Drawing.Point(3, 2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(21, 23);
            this.updateButton.TabIndex = 4;
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // bookParametersComboBox
            // 
            this.bookParametersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bookParametersComboBox.FormattingEnabled = true;
            this.bookParametersComboBox.Location = new System.Drawing.Point(440, 3);
            this.bookParametersComboBox.Name = "bookParametersComboBox";
            this.bookParametersComboBox.Size = new System.Drawing.Size(118, 21);
            this.bookParametersComboBox.TabIndex = 3;
            // 
            // findStorageBookTextBox
            // 
            this.findStorageBookTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findStorageBookTextBox.Location = new System.Drawing.Point(30, 3);
            this.findStorageBookTextBox.Multiline = true;
            this.findStorageBookTextBox.Name = "findStorageBookTextBox";
            this.findStorageBookTextBox.Size = new System.Drawing.Size(414, 21);
            this.findStorageBookTextBox.TabIndex = 2;
            // 
            // findStorageBooksButton
            // 
            this.findStorageBooksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findStorageBooksButton.Location = new System.Drawing.Point(555, 2);
            this.findStorageBooksButton.Name = "findStorageBooksButton";
            this.findStorageBooksButton.Size = new System.Drawing.Size(85, 23);
            this.findStorageBooksButton.TabIndex = 0;
            this.findStorageBooksButton.Text = "Найти";
            this.findStorageBooksButton.UseVisualStyleBackColor = true;
            this.findStorageBooksButton.Click += new System.EventHandler(this.addBookPanelButton_Click);
            // 
            // storageBookPanel
            // 
            this.storageBookPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storageBookPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storageBookPanel.Location = new System.Drawing.Point(645, 3);
            this.storageBookPanel.Name = "storageBookPanel";
            this.storageBookPanel.Size = new System.Drawing.Size(245, 454);
            this.storageBookPanel.TabIndex = 1;
            // 
            // storageBooksFlowLayoutPanel
            // 
            this.storageBooksFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storageBooksFlowLayoutPanel.AutoScroll = true;
            this.storageBooksFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storageBooksFlowLayoutPanel.Location = new System.Drawing.Point(3, 29);
            this.storageBooksFlowLayoutPanel.Name = "storageBooksFlowLayoutPanel";
            this.storageBooksFlowLayoutPanel.Size = new System.Drawing.Size(637, 428);
            this.storageBooksFlowLayoutPanel.TabIndex = 0;
            // 
            // findBooksTabPage
            // 
            this.findBooksTabPage.Controls.Add(this.websitesComboBox);
            this.findBooksTabPage.Controls.Add(this.findProductBookTextBox);
            this.findBooksTabPage.Controls.Add(this.findProductsBooksButton);
            this.findBooksTabPage.Controls.Add(this.productBookPanel);
            this.findBooksTabPage.Controls.Add(this.productBooksFlowLayoutPanel);
            this.findBooksTabPage.Location = new System.Drawing.Point(4, 22);
            this.findBooksTabPage.Name = "findBooksTabPage";
            this.findBooksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.findBooksTabPage.Size = new System.Drawing.Size(894, 463);
            this.findBooksTabPage.TabIndex = 1;
            this.findBooksTabPage.Text = "Найти книги";
            this.findBooksTabPage.UseVisualStyleBackColor = true;
            // 
            // websitesComboBox
            // 
            this.websitesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.websitesComboBox.FormattingEnabled = true;
            this.websitesComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.websitesComboBox.Location = new System.Drawing.Point(440, 3);
            this.websitesComboBox.Name = "websitesComboBox";
            this.websitesComboBox.Size = new System.Drawing.Size(118, 21);
            this.websitesComboBox.TabIndex = 8;
            // 
            // findProductBookTextBox
            // 
            this.findProductBookTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findProductBookTextBox.Location = new System.Drawing.Point(3, 3);
            this.findProductBookTextBox.Multiline = true;
            this.findProductBookTextBox.Name = "findProductBookTextBox";
            this.findProductBookTextBox.Size = new System.Drawing.Size(441, 21);
            this.findProductBookTextBox.TabIndex = 7;
            // 
            // findProductsBooksButton
            // 
            this.findProductsBooksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findProductsBooksButton.Location = new System.Drawing.Point(555, 2);
            this.findProductsBooksButton.Name = "findProductsBooksButton";
            this.findProductsBooksButton.Size = new System.Drawing.Size(85, 23);
            this.findProductsBooksButton.TabIndex = 4;
            this.findProductsBooksButton.Text = "Найти";
            this.findProductsBooksButton.UseVisualStyleBackColor = true;
            // 
            // productBookPanel
            // 
            this.productBookPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productBookPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productBookPanel.Location = new System.Drawing.Point(645, 3);
            this.productBookPanel.Name = "productBookPanel";
            this.productBookPanel.Size = new System.Drawing.Size(245, 454);
            this.productBookPanel.TabIndex = 6;
            // 
            // productBooksFlowLayoutPanel
            // 
            this.productBooksFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productBooksFlowLayoutPanel.AutoScroll = true;
            this.productBooksFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productBooksFlowLayoutPanel.Location = new System.Drawing.Point(3, 29);
            this.productBooksFlowLayoutPanel.Name = "productBooksFlowLayoutPanel";
            this.productBooksFlowLayoutPanel.Size = new System.Drawing.Size(637, 428);
            this.productBooksFlowLayoutPanel.TabIndex = 5;
            // 
            // addChangeTabPage
            // 
            this.addChangeTabPage.AutoScroll = true;
            this.addChangeTabPage.Controls.Add(this.changePanel);
            this.addChangeTabPage.Location = new System.Drawing.Point(4, 22);
            this.addChangeTabPage.Name = "addChangeTabPage";
            this.addChangeTabPage.Size = new System.Drawing.Size(894, 463);
            this.addChangeTabPage.TabIndex = 2;
            this.addChangeTabPage.Text = "Добавить/Изменить";
            this.addChangeTabPage.UseVisualStyleBackColor = true;
            // 
            // informPanel
            // 
            this.informPanel.Controls.Add(this.informLable);
            this.informPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.informPanel.Location = new System.Drawing.Point(0, 490);
            this.informPanel.Name = "informPanel";
            this.informPanel.Size = new System.Drawing.Size(902, 25);
            this.informPanel.TabIndex = 1;
            // 
            // informLable
            // 
            this.informLable.AutoSize = true;
            this.informLable.Location = new System.Drawing.Point(3, 5);
            this.informLable.Name = "informLable";
            this.informLable.Size = new System.Drawing.Size(25, 13);
            this.informLable.TabIndex = 2;
            this.informLable.Text = "Info";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 26);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название";
            // 
            // authorLabel
            // 
            this.authorLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(3, 52);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(37, 13);
            this.authorLabel.TabIndex = 1;
            this.authorLabel.Text = "Автор";
            // 
            // publishingHouseLabel
            // 
            this.publishingHouseLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.publishingHouseLabel.AutoSize = true;
            this.publishingHouseLabel.Location = new System.Drawing.Point(3, 32);
            this.publishingHouseLabel.Name = "publishingHouseLabel";
            this.publishingHouseLabel.Size = new System.Drawing.Size(79, 13);
            this.publishingHouseLabel.TabIndex = 2;
            this.publishingHouseLabel.Text = "Издательство";
            // 
            // yearLabel
            // 
            this.yearLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(3, 61);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(70, 13);
            this.yearLabel.TabIndex = 3;
            this.yearLabel.Text = "Год издания";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nameTextBox.Location = new System.Drawing.Point(93, 23);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(276, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearTextBox.Location = new System.Drawing.Point(93, 58);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(175, 20);
            this.yearTextBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(93, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Добавить автора";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Location = new System.Drawing.Point(93, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 28);
            this.button2.TabIndex = 11;
            this.button2.Text = "Добавить изображение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // authorComboBox
            // 
            this.authorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Location = new System.Drawing.Point(93, 49);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(276, 21);
            this.authorComboBox.TabIndex = 12;
            // 
            // publishingHouseComboBox
            // 
            this.publishingHouseComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.publishingHouseComboBox.FormattingEnabled = true;
            this.publishingHouseComboBox.Location = new System.Drawing.Point(93, 29);
            this.publishingHouseComboBox.Name = "publishingHouseComboBox";
            this.publishingHouseComboBox.Size = new System.Drawing.Size(276, 21);
            this.publishingHouseComboBox.TabIndex = 13;
            // 
            // imageOpenFileDialog
            // 
            this.imageOpenFileDialog.FileName = "openFileDialog1";
            // 
            // addedPictureBox
            // 
            this.addedPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addedPictureBox.Location = new System.Drawing.Point(93, 118);
            this.addedPictureBox.Name = "addedPictureBox";
            this.addedPictureBox.Size = new System.Drawing.Size(175, 175);
            this.addedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addedPictureBox.TabIndex = 14;
            this.addedPictureBox.TabStop = false;
            // 
            // addChangeButton
            // 
            this.addChangeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addChangeButton.Location = new System.Drawing.Point(193, 346);
            this.addChangeButton.Name = "addChangeButton";
            this.addChangeButton.Size = new System.Drawing.Size(176, 32);
            this.addChangeButton.TabIndex = 15;
            this.addChangeButton.Text = "Добавить книгу";
            this.addChangeButton.UseVisualStyleBackColor = true;
            // 
            // changePanel
            // 
            this.changePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.changePanel.AutoSize = true;
            this.changePanel.Controls.Add(this.shiftedPanel);
            this.changePanel.Controls.Add(this.nameLabel);
            this.changePanel.Controls.Add(this.authorLabel);
            this.changePanel.Controls.Add(this.authorComboBox);
            this.changePanel.Controls.Add(this.nameTextBox);
            this.changePanel.Location = new System.Drawing.Point(235, 3);
            this.changePanel.Name = "changePanel";
            this.changePanel.Size = new System.Drawing.Size(372, 460);
            this.changePanel.TabIndex = 16;
            // 
            // shiftedPanel
            // 
            this.shiftedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shiftedPanel.AutoSize = true;
            this.shiftedPanel.Controls.Add(this.clearButton);
            this.shiftedPanel.Controls.Add(this.button2);
            this.shiftedPanel.Controls.Add(this.button1);
            this.shiftedPanel.Controls.Add(this.addChangeButton);
            this.shiftedPanel.Controls.Add(this.publishingHouseComboBox);
            this.shiftedPanel.Controls.Add(this.publishingHouseLabel);
            this.shiftedPanel.Controls.Add(this.yearTextBox);
            this.shiftedPanel.Controls.Add(this.addedPictureBox);
            this.shiftedPanel.Controls.Add(this.yearLabel);
            this.shiftedPanel.Location = new System.Drawing.Point(0, 76);
            this.shiftedPanel.Name = "shiftedPanel";
            this.shiftedPanel.Size = new System.Drawing.Size(372, 381);
            this.shiftedPanel.TabIndex = 17;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clearButton.Location = new System.Drawing.Point(3, 346);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(176, 32);
            this.clearButton.TabIndex = 16;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 515);
            this.Controls.Add(this.informPanel);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "Form1";
            this.Text = "GetBooks";
            this.tabControl1.ResumeLayout(false);
            this.myBooksTabPage.ResumeLayout(false);
            this.myBooksTabPage.PerformLayout();
            this.findBooksTabPage.ResumeLayout(false);
            this.findBooksTabPage.PerformLayout();
            this.addChangeTabPage.ResumeLayout(false);
            this.addChangeTabPage.PerformLayout();
            this.informPanel.ResumeLayout(false);
            this.informPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addedPictureBox)).EndInit();
            this.changePanel.ResumeLayout(false);
            this.changePanel.PerformLayout();
            this.shiftedPanel.ResumeLayout(false);
            this.shiftedPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage myBooksTabPage;
        private System.Windows.Forms.TabPage findBooksTabPage;
        private System.Windows.Forms.FlowLayoutPanel storageBooksFlowLayoutPanel;
        private System.Windows.Forms.Button findStorageBooksButton;
        private System.Windows.Forms.Panel informPanel;
        private System.Windows.Forms.Label informLable;
        private System.Windows.Forms.Panel storageBookPanel;
        private System.Windows.Forms.TextBox findStorageBookTextBox;
        private System.Windows.Forms.ComboBox bookParametersComboBox;
        private System.Windows.Forms.ComboBox websitesComboBox;
        private System.Windows.Forms.TextBox findProductBookTextBox;
        private System.Windows.Forms.Button findProductsBooksButton;
        private System.Windows.Forms.Panel productBookPanel;
        private System.Windows.Forms.FlowLayoutPanel productBooksFlowLayoutPanel;
        private System.Windows.Forms.TabPage addChangeTabPage;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label publishingHouseLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox publishingHouseComboBox;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.OpenFileDialog imageOpenFileDialog;
        private System.Windows.Forms.Button addChangeButton;
        private System.Windows.Forms.PictureBox addedPictureBox;
        private System.Windows.Forms.Panel changePanel;
        private System.Windows.Forms.Panel shiftedPanel;
        private System.Windows.Forms.Button clearButton;
    }
}

