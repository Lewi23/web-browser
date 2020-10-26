namespace Simple_Web_Browser
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.historyBox = new System.Windows.Forms.ListBox();
            this.historySearchButton = new System.Windows.Forms.Button();
            this.deleteHistoryButton = new System.Windows.Forms.Button();
            this.bookmarkBox = new System.Windows.Forms.ListBox();
            this.bookmarkNameEntry = new System.Windows.Forms.TextBox();
            this.bookmarkURLEntry = new System.Windows.Forms.TextBox();
            this.addBookmarkButton = new System.Windows.Forms.Button();
            this.deleteBookmarkButton = new System.Windows.Forms.Button();
            this.searchBookmarkButton = new System.Windows.Forms.Button();
            this.historyLabel = new System.Windows.Forms.Label();
            this.bookmarkLabel = new System.Windows.Forms.Label();
            this.editBookmarkButton = new System.Windows.Forms.Button();
            this.historyRefreshButton = new System.Windows.Forms.Button();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.setHomepageButton = new System.Windows.Forms.Button();
            this.homepageURLBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // historyBox
            // 
            this.historyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.historyBox.FormattingEnabled = true;
            this.historyBox.HorizontalScrollbar = true;
            this.historyBox.ItemHeight = 20;
            this.historyBox.Location = new System.Drawing.Point(12, 163);
            this.historyBox.Name = "historyBox";
            this.historyBox.Size = new System.Drawing.Size(578, 224);
            this.historyBox.TabIndex = 2;
            this.historyBox.SelectedIndexChanged += new System.EventHandler(this.historyBox_SelectedIndexChanged);
            // 
            // historySearchButton
            // 
            this.historySearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.historySearchButton.Location = new System.Drawing.Point(12, 124);
            this.historySearchButton.Name = "historySearchButton";
            this.historySearchButton.Size = new System.Drawing.Size(188, 33);
            this.historySearchButton.TabIndex = 3;
            this.historySearchButton.Text = "Search";
            this.historySearchButton.UseVisualStyleBackColor = true;
            this.historySearchButton.Click += new System.EventHandler(this.historySearchButton_Click);
            // 
            // deleteHistoryButton
            // 
            this.deleteHistoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteHistoryButton.Location = new System.Drawing.Point(406, 123);
            this.deleteHistoryButton.Name = "deleteHistoryButton";
            this.deleteHistoryButton.Size = new System.Drawing.Size(182, 34);
            this.deleteHistoryButton.TabIndex = 5;
            this.deleteHistoryButton.Text = "Delete";
            this.deleteHistoryButton.UseVisualStyleBackColor = true;
            this.deleteHistoryButton.Click += new System.EventHandler(this.deleteHistoryButton_Click);
            // 
            // bookmarkBox
            // 
            this.bookmarkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookmarkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bookmarkBox.FormattingEnabled = true;
            this.bookmarkBox.HorizontalScrollbar = true;
            this.bookmarkBox.ItemHeight = 20;
            this.bookmarkBox.Location = new System.Drawing.Point(12, 522);
            this.bookmarkBox.Name = "bookmarkBox";
            this.bookmarkBox.Size = new System.Drawing.Size(578, 224);
            this.bookmarkBox.TabIndex = 6;
            this.bookmarkBox.SelectedIndexChanged += new System.EventHandler(this.bookmarkBox_SelectedIndexChanged);
            // 
            // bookmarkNameEntry
            // 
            this.bookmarkNameEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bookmarkNameEntry.Location = new System.Drawing.Point(12, 490);
            this.bookmarkNameEntry.Name = "bookmarkNameEntry";
            this.bookmarkNameEntry.Size = new System.Drawing.Size(280, 26);
            this.bookmarkNameEntry.TabIndex = 7;
            this.bookmarkNameEntry.Text = "Bookmark name";
            // 
            // bookmarkURLEntry
            // 
            this.bookmarkURLEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bookmarkURLEntry.Location = new System.Drawing.Point(308, 490);
            this.bookmarkURLEntry.Name = "bookmarkURLEntry";
            this.bookmarkURLEntry.Size = new System.Drawing.Size(280, 26);
            this.bookmarkURLEntry.TabIndex = 8;
            this.bookmarkURLEntry.Text = "Bookmark URL";
            // 
            // addBookmarkButton
            // 
            this.addBookmarkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addBookmarkButton.Location = new System.Drawing.Point(12, 752);
            this.addBookmarkButton.Name = "addBookmarkButton";
            this.addBookmarkButton.Size = new System.Drawing.Size(190, 31);
            this.addBookmarkButton.TabIndex = 9;
            this.addBookmarkButton.Text = "Add";
            this.addBookmarkButton.UseVisualStyleBackColor = true;
            this.addBookmarkButton.Click += new System.EventHandler(this.addBookmarkButton_Click);
            // 
            // deleteBookmarkButton
            // 
            this.deleteBookmarkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteBookmarkButton.Location = new System.Drawing.Point(408, 752);
            this.deleteBookmarkButton.Name = "deleteBookmarkButton";
            this.deleteBookmarkButton.Size = new System.Drawing.Size(182, 31);
            this.deleteBookmarkButton.TabIndex = 10;
            this.deleteBookmarkButton.Text = "Delete";
            this.deleteBookmarkButton.UseVisualStyleBackColor = true;
            this.deleteBookmarkButton.Click += new System.EventHandler(this.deleteBookmarkButton_Click);
            // 
            // searchBookmarkButton
            // 
            this.searchBookmarkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchBookmarkButton.Location = new System.Drawing.Point(12, 453);
            this.searchBookmarkButton.Name = "searchBookmarkButton";
            this.searchBookmarkButton.Size = new System.Drawing.Size(578, 31);
            this.searchBookmarkButton.TabIndex = 11;
            this.searchBookmarkButton.Text = "Search";
            this.searchBookmarkButton.UseVisualStyleBackColor = true;
            this.searchBookmarkButton.Click += new System.EventHandler(this.searchBookmarkButton_Click);
            // 
            // historyLabel
            // 
            this.historyLabel.AutoSize = true;
            this.historyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.historyLabel.Location = new System.Drawing.Point(12, 86);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(80, 26);
            this.historyLabel.TabIndex = 12;
            this.historyLabel.Text = "History";
            // 
            // bookmarkLabel
            // 
            this.bookmarkLabel.AutoSize = true;
            this.bookmarkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bookmarkLabel.Location = new System.Drawing.Point(9, 416);
            this.bookmarkLabel.Name = "bookmarkLabel";
            this.bookmarkLabel.Size = new System.Drawing.Size(122, 26);
            this.bookmarkLabel.TabIndex = 13;
            this.bookmarkLabel.Text = "Bookmarks";
            // 
            // editBookmarkButton
            // 
            this.editBookmarkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.editBookmarkButton.Location = new System.Drawing.Point(208, 752);
            this.editBookmarkButton.Name = "editBookmarkButton";
            this.editBookmarkButton.Size = new System.Drawing.Size(194, 31);
            this.editBookmarkButton.TabIndex = 14;
            this.editBookmarkButton.Text = "Edit";
            this.editBookmarkButton.UseVisualStyleBackColor = true;
            this.editBookmarkButton.Click += new System.EventHandler(this.editBookmarkButton_Click);
            // 
            // historyRefreshButton
            // 
            this.historyRefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.historyRefreshButton.Location = new System.Drawing.Point(206, 124);
            this.historyRefreshButton.Name = "historyRefreshButton";
            this.historyRefreshButton.Size = new System.Drawing.Size(194, 33);
            this.historyRefreshButton.TabIndex = 15;
            this.historyRefreshButton.Text = "Refresh";
            this.historyRefreshButton.UseVisualStyleBackColor = true;
            this.historyRefreshButton.Click += new System.EventHandler(this.historyRefreshButton_Click);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.settingsLabel.Location = new System.Drawing.Point(12, 9);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(91, 26);
            this.settingsLabel.TabIndex = 16;
            this.settingsLabel.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Home page URL:";
            // 
            // setHomepageButton
            // 
            this.setHomepageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setHomepageButton.Location = new System.Drawing.Point(499, 42);
            this.setHomepageButton.Name = "setHomepageButton";
            this.setHomepageButton.Size = new System.Drawing.Size(89, 29);
            this.setHomepageButton.TabIndex = 19;
            this.setHomepageButton.Text = "Set";
            this.setHomepageButton.UseVisualStyleBackColor = true;
            this.setHomepageButton.Click += new System.EventHandler(this.setHomepageButton_Click);
            // 
            // homepageURLBox
            // 
            this.homepageURLBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.homepageURLBox.Location = new System.Drawing.Point(152, 45);
            this.homepageURLBox.Name = "homepageURLBox";
            this.homepageURLBox.Size = new System.Drawing.Size(341, 26);
            this.homepageURLBox.TabIndex = 20;
            this.homepageURLBox.TextChanged += new System.EventHandler(this.homepageURLBox_TextChanged);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 797);
            this.Controls.Add(this.homepageURLBox);
            this.Controls.Add(this.setHomepageButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.historyRefreshButton);
            this.Controls.Add(this.editBookmarkButton);
            this.Controls.Add(this.bookmarkLabel);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.searchBookmarkButton);
            this.Controls.Add(this.deleteBookmarkButton);
            this.Controls.Add(this.addBookmarkButton);
            this.Controls.Add(this.bookmarkURLEntry);
            this.Controls.Add(this.bookmarkNameEntry);
            this.Controls.Add(this.bookmarkBox);
            this.Controls.Add(this.deleteHistoryButton);
            this.Controls.Add(this.historySearchButton);
            this.Controls.Add(this.historyBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox historyBox;
        private System.Windows.Forms.Button historySearchButton;
        private System.Windows.Forms.Button deleteHistoryButton;
        private System.Windows.Forms.ListBox bookmarkBox;
        private System.Windows.Forms.TextBox bookmarkNameEntry;
        private System.Windows.Forms.TextBox bookmarkURLEntry;
        private System.Windows.Forms.Button addBookmarkButton;
        private System.Windows.Forms.Button deleteBookmarkButton;
        private System.Windows.Forms.Button searchBookmarkButton;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.Label bookmarkLabel;
        private System.Windows.Forms.Button editBookmarkButton;
        private System.Windows.Forms.Button historyRefreshButton;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setHomepageButton;
        private System.Windows.Forms.TextBox homepageURLBox;
    }
}