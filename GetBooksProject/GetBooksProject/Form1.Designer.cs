﻿
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
            this.storageFindConditionsComboBox = new System.Windows.Forms.ComboBox();
            this.findStorageBookTextBox = new System.Windows.Forms.TextBox();
            this.findStorageBooksButton = new System.Windows.Forms.Button();
            this.storageBookPanel = new System.Windows.Forms.Panel();
            this.storageBooksFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.findBooksTabPage = new System.Windows.Forms.TabPage();
            this.websitesComboBox = new System.Windows.Forms.ComboBox();
            this.findProductBookTextBox = new System.Windows.Forms.TextBox();
            this.findProductsBooksButton = new System.Windows.Forms.Button();
            this.productBookPanel = new System.Windows.Forms.Panel();
            this.addChangeTabPage = new System.Windows.Forms.TabPage();
            this.informPanel = new System.Windows.Forms.Panel();
            this.informLable = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.myBooksTabPage.SuspendLayout();
            this.findBooksTabPage.SuspendLayout();
            this.informPanel.SuspendLayout();
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
            this.myBooksTabPage.Controls.Add(this.storageFindConditionsComboBox);
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
            // storageFindConditionsComboBox
            // 
            this.storageFindConditionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.storageFindConditionsComboBox.FormattingEnabled = true;
            this.storageFindConditionsComboBox.Location = new System.Drawing.Point(440, 3);
            this.storageFindConditionsComboBox.Name = "storageFindConditionsComboBox";
            this.storageFindConditionsComboBox.Size = new System.Drawing.Size(118, 21);
            this.storageFindConditionsComboBox.TabIndex = 3;
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
            this.findStorageBooksButton.Location = new System.Drawing.Point(564, 2);
            this.findStorageBooksButton.Name = "findStorageBooksButton";
            this.findStorageBooksButton.Size = new System.Drawing.Size(76, 23);
            this.findStorageBooksButton.TabIndex = 0;
            this.findStorageBooksButton.Text = "Найти";
            this.findStorageBooksButton.UseVisualStyleBackColor = true;
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
            this.findProductsBooksButton.Location = new System.Drawing.Point(564, 2);
            this.findProductsBooksButton.Name = "findProductsBooksButton";
            this.findProductsBooksButton.Size = new System.Drawing.Size(76, 23);
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
            // addChangeTabPage
            // 
            this.addChangeTabPage.AutoScroll = true;
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.myBooksTabPage.ResumeLayout(false);
            this.myBooksTabPage.PerformLayout();
            this.findBooksTabPage.ResumeLayout(false);
            this.findBooksTabPage.PerformLayout();
            this.informPanel.ResumeLayout(false);
            this.informPanel.PerformLayout();
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
        private System.Windows.Forms.ComboBox storageFindConditionsComboBox;
        private System.Windows.Forms.ComboBox websitesComboBox;
        private System.Windows.Forms.TextBox findProductBookTextBox;
        private System.Windows.Forms.Button findProductsBooksButton;
        private System.Windows.Forms.Panel productBookPanel;
        private System.Windows.Forms.TabPage addChangeTabPage;
        private System.Windows.Forms.Button updateButton;
    }
}

