
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.myBooksTabPage = new System.Windows.Forms.TabPage();
            this.findBooksTabPage = new System.Windows.Forms.TabPage();
            this.myBooksFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.findBooksFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.myBooksTabPage.SuspendLayout();
            this.findBooksTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.myBooksTabPage);
            this.tabControl1.Controls.Add(this.findBooksTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // myBooksTabPage
            // 
            this.myBooksTabPage.Controls.Add(this.myBooksFlowLayoutPanel);
            this.myBooksTabPage.Location = new System.Drawing.Point(4, 22);
            this.myBooksTabPage.Name = "myBooksTabPage";
            this.myBooksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.myBooksTabPage.Size = new System.Drawing.Size(888, 436);
            this.myBooksTabPage.TabIndex = 0;
            this.myBooksTabPage.Text = "Мои книги";
            this.myBooksTabPage.UseVisualStyleBackColor = true;
            // 
            // findBooksTabPage
            // 
            this.findBooksTabPage.Controls.Add(this.findBooksFlowLayoutPanel);
            this.findBooksTabPage.Location = new System.Drawing.Point(4, 22);
            this.findBooksTabPage.Name = "findBooksTabPage";
            this.findBooksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.findBooksTabPage.Size = new System.Drawing.Size(888, 436);
            this.findBooksTabPage.TabIndex = 1;
            this.findBooksTabPage.Text = "Найти книги";
            this.findBooksTabPage.UseVisualStyleBackColor = true;
            // 
            // myBooksFlowLayoutPanel
            // 
            this.myBooksFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myBooksFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.myBooksFlowLayoutPanel.Name = "myBooksFlowLayoutPanel";
            this.myBooksFlowLayoutPanel.Size = new System.Drawing.Size(882, 430);
            this.myBooksFlowLayoutPanel.TabIndex = 0;
            // 
            // findBooksFlowLayoutPanel
            // 
            this.findBooksFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findBooksFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.findBooksFlowLayoutPanel.Name = "findBooksFlowLayoutPanel";
            this.findBooksFlowLayoutPanel.Size = new System.Drawing.Size(882, 430);
            this.findBooksFlowLayoutPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 462);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "GetBooks";
            this.tabControl1.ResumeLayout(false);
            this.myBooksTabPage.ResumeLayout(false);
            this.findBooksTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage myBooksTabPage;
        private System.Windows.Forms.TabPage findBooksTabPage;
        private System.Windows.Forms.FlowLayoutPanel myBooksFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel findBooksFlowLayoutPanel;
    }
}

