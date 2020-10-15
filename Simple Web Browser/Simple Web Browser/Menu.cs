using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public partial class Menu : Form
    {
        //History historyManager = new History;
        // https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
        // communcatiing between two forms
        private Form1 mainForm = null;

        public Bookmark bookmarkManager = new Bookmark();
        public History historyManager = new History();
        
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            bookmarkManager.bookmarkItem += BookmarkManager_bookmarkItem;
            historyManager.historyItem += HistoryManager_historyItem;

            historyManager.loadHistory();
            bookmarkManager.loadBookmarks();


            // Disable UI buttons until the user selects and item
            historySearchButton.Enabled = false;
            deleteHistoryButton.Enabled = false;

            searchBookmarkButton.Enabled = false;
            editBookmarkButton.Enabled = false;
            deleteBookmarkButton.Enabled = false;

            //Hompeage
            homepageURLBox.Text = this.mainForm.manager.getHomeURL(); 

            // Set hompeage

            if(this.mainForm.manager.getHomeURL() == homepageURLBox.Text)
            {
                setHomepageButton.Enabled = false;
            }
        }

        private void HistoryManager_historyItem(object sender, EventArgs e)
        {
            historyBox.Items.Clear();
            //Reversing the list 
            for (int i = History.historyList.Count - 1; i > 0; i--)
            {
                historyBox.Items.Add("URL: " + History.historyList[i].historyURL + " | Access time: " + History.historyList[i].accessTime);
            }

        }

        private void historySearchButton_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItem != null)
            {
                this.mainForm.manager.searchHistory(historyBox.SelectedIndex);
            }
        }

        private void historyRefreshButton_Click(object sender, EventArgs e)
        {
            historyManager.loadHistory();
        }

        private void deleteHistoryButton_Click(object sender, EventArgs e)
        {
            if (historyBox.SelectedItem != null)
            {
                historyManager.deleteHistoryItem(historyBox.SelectedIndex);
                deleteHistoryButton.Enabled = false;
                historySearchButton.Enabled = false;
            } 
        }

        private void historyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (historyBox.SelectedIndex != -1)
            {
                historySearchButton.Enabled = true;
                deleteHistoryButton.Enabled = true;
            }
        }

        private void BookmarkManager_bookmarkItem(object sender, EventArgs e)
        {
            bookmarkBox.Items.Clear();
            foreach (BookmarkArgs bookmark in Bookmark.bookmarkList)
            {
                bookmarkBox.Items.Add(bookmark.bookmarkName);
            }
        }

        private void searchBookmarkButton_Click(object sender, EventArgs e)
        {
            if (bookmarkBox.SelectedItem != null)
            {
                this.mainForm.manager.searchBookmark(bookmarkBox.SelectedIndex);
            }
        }

        private void addBookmarkButton_Click(object sender, EventArgs e)
        { 
            bookmarkManager.addBookmark(bookmarkNameEntry.Text, bookmarkURLEntry.Text);
            bookmarkNameEntry.Text = "Bookmark name";
            bookmarkURLEntry.Text = "Bookmark URL";

            deleteBookmarkButton.Enabled = false;
            searchBookmarkButton.Enabled = false;
            editBookmarkButton.Enabled = false;

            bookmarkManager.saveBookmarksLocally();
        }

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

        private void editBookmarkButton_Click(object sender, EventArgs e)
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
    }
}
