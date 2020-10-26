using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Web_Browser;

namespace Simple_Web_Browser_Tests
{
    [TestClass]
    public class BookmarkTests
    {
     
        Bookmark bookmarkManager;

        [TestInitialize]
        public void Setup()
        {
            bookmarkManager = new Bookmark();
        }

        [TestMethod]
        public void add_bookmark()
        {
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");

            Assert.AreEqual(1, Bookmark.bookmarkList.Count);
        }

        [TestMethod]
        public void delete_bookmark()
        {
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");
            bookmarkManager.addBookmark("Google", "https://www.google.com/");

            bookmarkManager.deleteBookmark(1);

            Assert.AreEqual(1, Bookmark.bookmarkList.Count);
        }

        [TestMethod]
        public void delete_bookmark_out_of_range()
        {
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");
            bookmarkManager.addBookmark("Google", "https://www.google.com/");

            bookmarkManager.deleteBookmark(int.MaxValue);
        }

        [TestMethod]
        public void edit_bookmark()
        {
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");
            bookmarkManager.addBookmark("Google", "https://www.google.com/");

            bookmarkManager.editBookmark(1, "Search Engine", "https://www.google.com/");

            Assert.AreEqual("Search Engine", Bookmark.bookmarkList[1].bookmarkName);
        }

        [TestMethod]
        public void edit_bookmark_out_of_bounds()
        {
            BookmarkItem item1 = new BookmarkItem();

            Bookmark.bookmarkList.Add(item1);

            bookmarkManager.editBookmark(int.MaxValue, "Test name", "Test URL");

        }

        [TestMethod]
        public void persistent_bookmarks()
        {
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");
            bookmarkManager.addBookmark("Google", "https://www.google.com/");

            // Save our two local bookmark items to persistent storage
            bookmarkManager.saveBookmarksLocally();

            // Overwrite our current in memory bookmark list
            Bookmark.bookmarkList = new List<BookmarkItem>();

            // Reload bookmarks from persistent storage
            Bookmark.bookmarkList = bookmarkManager.loadLocalBookmarks();

            // Checking that bookmarkList has the two elements we added earlier
            Assert.AreEqual(2, Bookmark.bookmarkList.Count);
        }
    }
}
