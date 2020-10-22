﻿using System;
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
        private Browser mainForm = null;

        public Bookmark bookmarkManager = new Bookmark();
        public History historyManager = new History();
        Manager manager = new Manager();
        
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(Form callingForm)
        {
            mainForm = callingForm as Browser;
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
            //for (int i = History.historyList.Count - 1; i > 0; i--)
            foreach(HistoryItem historyItem in History.historyList)
            {
                historyBox.Items.Add("URL: " + historyItem.historyURL + " | Access time: " + historyItem.accessTime);
            }
            //{
            //    historyBox.Items.Add("URL: " + History.historyList[i].historyURL + " | Access time: " + History.historyList[i].accessTime);
            //}

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
                System.Console.WriteLine("trying to delete");
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
            foreach (BookmarkItem bookmark in Bookmark.bookmarkList)
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

        private void setHomepageButton_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.uri.iswellformeduristring?redirectedfrom=MSDN&view=netcore-3.1#System_Uri_IsWellFormedUriString_System_String_System_UriKind_
            if (Uri.IsWellFormedUriString(homepageURLBox.Text, UriKind.Absolute))
            {
                this.mainForm.manager.setHomepage(homepageURLBox.Text);
                setHomepageButton.Enabled = false;
            } else
            {
                System.Windows.Forms.MessageBox.Show("Invalid URL", "Error");
                homepageURLBox.Text = manager.getHomeURL();
                setHomepageButton.Enabled = false;
            }

        }

        private void homepageURLBox_TextChanged(object sender, EventArgs e)
        {
            setHomepageButton.Enabled = true;
        }
    }
}
