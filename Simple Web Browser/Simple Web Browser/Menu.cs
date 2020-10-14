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
        List<HistoryItem> reversedList;

        public Menu()
        {
            InitializeComponent();
          
            
        }

        private void BookmarkManager_bookmarkItem(object sender, EventArgs e)
        {
            Console.WriteLine("triggered");
            bookmarkBox.Items.Clear();
            foreach (BookmarkArgs bookmark in Bookmark.bookmarkList)
            { 
                bookmarkBox.Items.Add(bookmark.bookmarkName);
            }
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

        }

        private void HistoryManager_historyItem(object sender, EventArgs e)
        {

            historyBox.Items.Clear();
            //reversedList = History.historyList;
            //reversedList.Reverse();
            foreach (HistoryItem historyItem in History.historyList)
            {
                historyBox.Items.Add(historyItem.historyURL + historyItem.accessTime);
            }

        }


        private void historySearch_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine(historyBox.SelectedIndex);
            //Trying to control pointer when we jump around 
            //this.mainForm.manager.historyManager.setIndex(historyBox.SelectedIndex);
            //this.mainForm.manager.loadSelected(historyBox.SelectedIndex + 1);

            this.mainForm.manager.searchHistory(historyBox.SelectedIndex);

        }

        private void deleteHistory_Click(object sender, EventArgs e)
        {
            historyManager.deleteHistoryItem(historyBox.SelectedIndex);
        }

        private void searchBookMarkButton_Click(object sender, EventArgs e)
        {
            this.mainForm.manager.searchBookmark(bookmarkBox.SelectedIndex);
        }

        private void addBookmarkButton_Click(object sender, EventArgs e)
        { 
            bookmarkManager.addBookmark(bookmarkNameEntry.Text, bookmarkURLEntry.Text);
            bookmarkNameEntry.Text = "Bookmark name";
            bookmarkURLEntry.Text = "Bookmark URL";

            bookmarkManager.saveBookmarksLocally();

        }

        private void bookmarkBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // THIS CAN ERROR CLICK BELOW BOOKMARK 
            bookmarkNameEntry.Text = Bookmark.bookmarkList[bookmarkBox.SelectedIndex].bookmarkName;
            bookmarkURLEntry.Text = Bookmark.bookmarkList[bookmarkBox.SelectedIndex].bookmarkURL;
        }

        private void deleteBookmarkButton_Click(object sender, EventArgs e)
        {
            bookmarkManager.deleteBookmark(bookmarkBox.SelectedIndex);
            bookmarkNameEntry.Text = "Bookmark name";
            bookmarkURLEntry.Text = "Bookmark URL";
        }

        private void editBookmarkButton_Click(object sender, EventArgs e)
        {
            bookmarkManager.editBookmark(bookmarkBox.SelectedIndex, bookmarkNameEntry.Text, bookmarkURLEntry.Text);
        }

        private void historyRefreshButton_Click(object sender, EventArgs e)
        {
            historyManager.loadHistory();
        }

        private void historyBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
