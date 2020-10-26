using System;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public partial class menu : Form
    {
        // communcatiing between the two forms (Web Browser and Menu)
        // https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
        private webBrowser mainForm = null;

        Manager manager = new Manager();
        public Bookmark bookmarkManager = new Bookmark();
        public History historyManager = new History();

        /// <summary>
        /// default consturctor
        /// </summary>
        public menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Communcatiing between the two forms (Web Browser and Menu)
        /// </summary>
        /// <param name="callingForm"></param>
        public menu(Form callingForm)
        {
            mainForm = callingForm as webBrowser;
            InitializeComponent();
        }

        /// <summary>
        /// On menu load it loads local hisotry and bookmarks and configures the status of the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Load(object sender, EventArgs e)
        {
            // Link to events
            bookmarkManager.bookmarkItem += BookmarkManager_bookmarkItem;
            historyManager.historyItem += HistoryManager_historyItem;

            historyManager.loadHistory();
            bookmarkManager.loadBookmarks();


            // Disable UI buttons until the user selects an item / or edits an entry
            historySearchButton.Enabled = false;
            deleteHistoryButton.Enabled = false;

            searchBookmarkButton.Enabled = false;
            editBookmarkButton.Enabled = false;
            deleteBookmarkButton.Enabled = false;

            //Hompeage
            homepageURLBox.Text = this.mainForm.manager.getHomeURL();

            if (this.mainForm.manager.getHomeURL() == homepageURLBox.Text)
            {
                setHomepageButton.Enabled = false;
            }

        }

        /// <summary>
        /// Refreshes the history list (triggered by the event in History.cs)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryManager_historyItem(object sender, EventArgs e)
        {
            historyBox.Items.Clear();
            foreach(HistoryItem historyItem in History.historyList)
            {
                historyBox.Items.Add("URL: " + historyItem.historyURL + " | Access time: " + historyItem.accessTime);
            }
        }

        /// <summary>
        /// Searches the selected history item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historySearchButton_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItem != null)
            {
                this.mainForm.manager.searchHistory(historyBox.SelectedIndex);
            }
        }

        /// <summary>
        /// Refreshes history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyRefreshButton_Click(object sender, EventArgs e)
        {
            historyManager.loadHistory();
        }

        /// <summary>
        /// Deletes the selected history item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteHistoryButton_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItem != null)
            {
                historyManager.deleteHistoryItem(historyBox.SelectedIndex);
                deleteHistoryButton.Enabled = false;
                historySearchButton.Enabled = false;
            } 
        }

        /// <summary>
        /// Disables the ability to search or delete a bookmark if no bookmark is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (historyBox.SelectedIndex != -1)
            {
                historySearchButton.Enabled = true;
                deleteHistoryButton.Enabled = true;
            }
        }

        /// <summary>
        /// Refreshes the bookmark list (triggered by the event in Bookmark.cs)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookmarkManager_bookmarkItem(object sender, EventArgs e)
        {
            bookmarkBox.Items.Clear();
            foreach (BookmarkItem bookmark in Bookmark.bookmarkList)
            {
                bookmarkBox.Items.Add(bookmark.bookmarkName);
            }
        }

        /// <summary>
        /// Searches the selected bookmark item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBookmarkButton_Click(object sender, EventArgs e)
        {
            if (bookmarkBox.SelectedItem != null)
            {
                this.mainForm.manager.searchBookmark(bookmarkBox.SelectedIndex);
            }
        }

        /// <summary>
        /// Adds a new bookmark if the URL is valid with values provided via the bookmark entry textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBookmarkButton_Click(object sender, EventArgs e)
        {

            if (this.mainForm.manager.validURL(bookmarkURLEntry.Text))
            {
                bookmarkManager.addBookmark(bookmarkNameEntry.Text, bookmarkURLEntry.Text);
                bookmarkNameEntry.Text = "Bookmark name";
                bookmarkURLEntry.Text = "Bookmark URL";

                bookmarkManager.saveBookmarksLocally();
            } else
            {
                MessageBox.Show("Invalid bookmark URL", "Bookmark Error");
            }
            
            deleteBookmarkButton.Enabled = false;
            searchBookmarkButton.Enabled = false;
            editBookmarkButton.Enabled = false;

        }

        /// <summary>
        /// Updates the bookmark entry textboxes with the selected bookmark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookmarkBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookmarkBox.SelectedIndex != -1)
            {
                editBookmarkButton.Enabled = true;
                deleteBookmarkButton.Enabled = true;
                searchBookmarkButton.Enabled = true;

                bookmarkNameEntry.Text = Bookmark.bookmarkList[bookmarkBox.SelectedIndex].bookmarkName;
                bookmarkURLEntry.Text = Bookmark.bookmarkList[bookmarkBox.SelectedIndex].bookmarkURL;
            }
        }

        /// <summary>
        /// Deletes the selected bookmark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBookmarkButton_Click(object sender, EventArgs e)
        {
            if(bookmarkBox.SelectedItem != null)
            {
                bookmarkManager.deleteBookmark(bookmarkBox.SelectedIndex);
                bookmarkNameEntry.Text = "Bookmark name";
                bookmarkURLEntry.Text = "Bookmark URL";

                deleteBookmarkButton.Enabled = false;
                searchBookmarkButton.Enabled = false;
                editBookmarkButton.Enabled = false;
            }
        }

        /// <summary>
        /// Edits the bookmark to the new value(s) provided via the bookmark entry textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBookmarkButton_Click(object sender, EventArgs e)
        {
            if (this.mainForm.manager.validURL(bookmarkURLEntry.Text))
            {
                if (bookmarkBox.SelectedItem != null)
                {
                    bookmarkManager.editBookmark(bookmarkBox.SelectedIndex, bookmarkNameEntry.Text, bookmarkURLEntry.Text);

                    bookmarkNameEntry.Text = "Bookmark name";
                    bookmarkURLEntry.Text = "Bookmark URL";

                    deleteBookmarkButton.Enabled = false;
                    searchBookmarkButton.Enabled = false;
                    editBookmarkButton.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Invalid bookmark URL", "Bookmark Error");
            }
        }

        /// <summary>
        /// Updates the local home URL if it is valid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setHomepageButton_Click(object sender, EventArgs e)
        {
        
            if (Uri.IsWellFormedUriString(homepageURLBox.Text, UriKind.Absolute))
            {
                this.mainForm.manager.setHomepage(homepageURLBox.Text);
                setHomepageButton.Enabled = false;
            } else
            {
                System.Windows.Forms.MessageBox.Show("Invalid URL");
                homepageURLBox.Text = manager.getHomeURL();
                setHomepageButton.Enabled = false;
            }

        }

        /// <summary>
        /// Disables the set home page button until the user makes a change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homepageURLBox_TextChanged(object sender, EventArgs e)
        {
            setHomepageButton.Enabled = true;
        }
    }
}
