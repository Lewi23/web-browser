using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Web_Browser;


namespace Simple_Web_Browser_Tests
{
    [TestClass]
    public class ManagerTests
    {
        Manager manager;
        History historyManager;

        [TestInitialize]
        public void Setup()
        {
            manager = new Manager();
            historyManager = new History();
        }

        [TestMethod]
        public void valid_url()
        {
            Assert.AreEqual(true, manager.validURL("https://www.google.com/"));
        }

        [TestMethod]
        public void valid_url_empty_string()
        {
            Assert.AreEqual(false, manager.validURL(""));
        }

        [TestMethod]
        public void valid_url_null()
        {
            Assert.AreEqual(false, manager.validURL(null));
        }

        [TestMethod]
        public void reload_page()
        {
            manager.reloadPage();
        }

        [TestMethod]
        public void search_history()
        {
            HistoryItem item1 = new HistoryItem();
            History.historyList.Add(item1);

            manager.searchHistory(0);
        }

        [TestMethod]
        public void search_history_out_of_range()
        {
            manager.searchHistory(int.MaxValue);
        }

        [TestMethod]
        public void search_bookmark()
        {
            BookmarkItem item1 = new BookmarkItem();
            Bookmark.bookmarkList.Add(item1);

            manager.searchBookmark(0);
        }

        [TestMethod]
        public void search_bookmark_out_of_range()
        {
            manager.searchBookmark(int.MaxValue);
        }
     

        [TestMethod]
        public void get_home_url()
        {
            manager.getHomeURL();
        }

        [TestMethod]
        public void set_home_page_empty_url()
        {
            manager.setHomepage("");
        }

        [TestMethod]
        public void set_home_page_null()
        {
            manager.setHomepage(null);
        }

        [TestMethod]
        public void set_home_page()
        {
            manager.setHomepage("https://www.google.com/");
        }

        [TestMethod]
        public void load_website()
        {
            manager.loadWebsite("https://www.google.com/", false);
        }

        [TestMethod]
        public void load_website_empty_url()
        {
            manager.loadWebsite("", false);
        }

        [TestMethod]
        public void load_website_null()
        {
            manager.loadWebsite(null, false);
        }

        [TestMethod]
        public void load_website_http_200()
        {
            manager.loadWebsite("http://httpstat.us/200", false);
        }

        [TestMethod]
        public void load_website_http_400()
        {
            manager.loadWebsite("http://httpstat.us/400", false);
        }

        [TestMethod]
        public void load_website_http_403()
        {
            manager.loadWebsite("http://httpstat.us/403", false);
        }

        [TestMethod]
        public void load_website_http_404()
        {
            manager.loadWebsite("http://httpstat.us/404", false);
        }

        [TestMethod]
        public void get_next_page()
        {
            HistoryItem item1 = new HistoryItem();
            HistoryItem item2 = new HistoryItem();
            History.historyList.Add(item1);
            History.historyList.Add(item2);

            History.pagePointer = 0;

            manager.getNextPage();
        }

        [TestMethod]
        public void get_next_page_out_of_range()
        {
            History.pagePointer = int.MaxValue;

            manager.getNextPage();
        }

        [TestMethod]
        public void get_previous_page()
        {
            HistoryItem item1 = new HistoryItem();
            HistoryItem item2 = new HistoryItem();
            History.historyList.Add(item1);
            History.historyList.Add(item2);

            History.pagePointer = 1;

            manager.getPreviousPage();
        }

        [TestMethod]
        public void get_previous_page_out_of_range()
        {
            History.pagePointer = int.MaxValue;

            manager.getPreviousPage();
        }
    }
}
