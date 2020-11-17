using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Web_Browser;

namespace Simple_Web_Browser_Tests
{
    [TestClass]
    public class BookmarkTests
    {
     
        Bookmark bookmarkManager;
        Manager manager;

        [TestInitialize]
        public void Setup()
        {
            bookmarkManager = new Bookmark();


            new XDocument(
                     new XElement("ArrayOfBookmarkItem")
                 )
             .Save("C:Bookmarks.xml");

        }

        [TestMethod]
        public void add_bookmark()
        {
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");

            Assert.AreEqual(1, Bookmark.bookmarkList.Count);
        }

        [TestMethod]
        public void add_two_bookmarks_with_same_name()
        {
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");
            bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");

            Assert.AreEqual(2, Bookmark.bookmarkList.Count);
        }

        [TestMethod]
        public void add_null_bookmark()
        {
            bookmarkManager.addBookmark(null, null);
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
            try
            {
                bookmarkManager.addBookmark("BBC", "https://www.bbc.co.uk/");
                bookmarkManager.addBookmark("Google", "https://www.google.com/");
                bookmarkManager.deleteBookmark(int.MaxValue);
                Assert.Fail();

            } catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }

        [TestMethod]
        public void delete_when_bookmark_is_empty()
        {
            try
            {
                bookmarkManager.deleteBookmark(int.MaxValue);
                Assert.Fail();

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
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
            try
            {
                bookmarkManager.editBookmark(int.MaxValue, "Search Engine", "https://www.google.com/");
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }

        [TestMethod]
        public void edit_bookmark_empty_bookmark_name()
        {

            bookmarkManager.addBookmark("Google", "https://www.google.com/");
            bookmarkManager.editBookmark(0, "", "https://www.google.com/");

            Assert.AreEqual("", Bookmark.bookmarkList[0].bookmarkName);
        }

        [TestMethod]
        public void edit_bookmark_empty_bookmark_url()
        {
            bookmarkManager.addBookmark("Google", "https://www.google.com/");
            bookmarkManager.editBookmark(0, "Google", "");

            Assert.AreEqual("", Bookmark.bookmarkList[0].bookmarkURL);
        }

        [TestMethod]
        public void edit_bookmark_name_to_null()
        {
            bookmarkManager.addBookmark("Google", "https://www.google.com/");
            bookmarkManager.editBookmark(0, null, "https://www.google.com/");

            Assert.AreEqual(null, Bookmark.bookmarkList[0].bookmarkName);
        }

        [TestMethod]
        public void edit_bookmark_url_to_null()
        {
            bookmarkManager.addBookmark("Google", "https://www.google.com/");
            bookmarkManager.editBookmark(0, "Google", null);

            Assert.AreEqual(null, Bookmark.bookmarkList[0].bookmarkURL);
        }
     
    }
}
