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
    public partial class Form2 : Form
    {
        //History historyManager = new History;
        // https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
        // communcatiing between two forms
        private Form1 mainForm = null;

        public Bookmark bookmarkManager = new Bookmark();
        public History1 historyManager = new History1();


        public Form2()
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

        //private void HistoryManager_HistoryItem(object sender, HistoryItemArgs e)
        //{
        //    System.Console.WriteLine("called");
        //}

        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            System.Console.WriteLine("Form2 loaded");

            bookmarkManager.bookmarkItem += BookmarkManager_bookmarkItem;
            historyManager.historyItem += HistoryManager_historyItem;

            historyManager.loadHistory();
            

            // bookmarkManager.loadLocalHisotry();
            bookmarkManager.loadBookmarks();


            /*
            foreach (HistoryItemArgs item in this.mainForm.manager.historyManager.HistoryList)
            {
                string builder = "URL: " + item.pageURL + " | Accessed: " + item.CurrentTime;
                System.Console.WriteLine("Bulder : {0}", builder);
                historyBox.Items.Add(builder);
            }
            //bookmarkManager.bookmarkItem += BookmarkManager_bookmarkItem;
            */
        }

        private void HistoryManager_historyItem(object sender, EventArgs e)
        {
            Console.WriteLine("HISTORY MANAGER EVENT TRIGGERD");
            historyBox.Items.Clear();
            foreach (HistoryItem historyItem in History1.historyList)
            {
                historyBox.Items.Add(historyItem.historyURL + historyItem.accessTime);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.mainForm.resultDisplay.Text = "hello world";

            historyBox.Items.Add("hello");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.mainForm.manager.historyManager.printAllItem();
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
    }
}
