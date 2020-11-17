using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            manager.buildJSONFiles();
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
            try
            {
                manager.reloadPage();
            }
            catch (Exception e)
            {
                Console.Write(e);
                Assert.Fail();
            }

        }

        [TestMethod]
        public void search_history()
        {
            try
            {
                HistoryItem item1 = new HistoryItem();
                History.historyList.Add(item1);

                manager.searchHistory(0);

            } catch(ArgumentOutOfRangeException e)
            {
                Console.Write(e);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void search_history_out_of_range()
        {
           
            try
            {
                manager.searchHistory(int.MaxValue);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }

        [TestMethod]
        public void search_bookmark()
        {
            try
            {
                BookmarkItem item1 = new BookmarkItem();
                Bookmark.bookmarkList.Add(item1);

                manager.searchBookmark(0);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Write(e);
                Assert.Fail();
            }

        }

        [TestMethod]
        public void search_bookmark_out_of_range()
        {
            try
            {
                manager.searchBookmark(int.MaxValue);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
     

        [TestMethod]
        public void get_home_url_persistent()
        {

            try
            {
                manager.getHomeURL();
            } catch (Exception e)
            {
                Console.Write(e);
                Assert.Fail();
            }
            
        }

        [TestMethod]
        public void set_home_page_empty_url()
        {
            try
            {
                manager.setHomepage("");
            }
            catch (Exception e)
            {
                Console.Write(e);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void set_home_page_null()
        {
            try
            {
                manager.setHomepage(null);
            }
            catch (Exception e)
            {
                Console.Write(e);
                Assert.Fail();
            }


        }

        [TestMethod]
        public void set_home_page()
        {
            try
            {
                manager.setHomepage("https://www.google.com/");
            }
            catch (Exception e)
            {
                Console.Write(e);
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task load_website()
        {
            try
            {
                Task.Run(() => manager._loadWebsite("https://www.google.com/", false));
            }
            catch (Exception e)
            {
                Assert.Fail();
                Console.Write(e);
            }
        }

        [TestMethod]
        public async Task load_website_empty_url()
        {
            try
            {
                Task.Run(() => manager._loadWebsite("", false));
            }
            catch (Exception e)
            {
                Assert.Fail();
                Console.Write(e);
            }
        }

        [TestMethod]
        public async Task load_website_null()
        {
            try
            {
                Task.Run(() => manager._loadWebsite(null, false));
            }
            catch (Exception e)
            {
                Assert.Fail();
                Console.Write(e);
            }
        }

        [TestMethod]
        public async Task load_website_http_200()
        {
            try
            {
                Task.Run(() => manager._loadWebsite("http://httpstat.us/200", false));
            }
            catch (Exception e)
            {
                Assert.Fail();
                Console.Write(e);
            }
        }

        [TestMethod]
        public async Task load_website_http_400()
        {
            try
            {
                var result = Task.Run(() => manager._loadWebsite("http://httpstat.us/400", false)).Result;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        [TestMethod]
        public async Task load_website_http_403()
        {
            try
            {
                var result = Task.Run(() => manager._loadWebsite("http://httpstat.us/403", false)).Result;
                Assert.Fail();

            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        [TestMethod]
        public async Task load_website_http_404()
        {
           
            try
            {
                var result = Task.Run(() => manager._loadWebsite("http://httpstat.us/404", false)).Result;
                Assert.Fail();
                
            } catch(Exception e)
            {
                Console.Write(e);
            }

        }

        [TestMethod]
        public void get_next_page()
        {
            HistoryItem item1 = new HistoryItem();
            HistoryItem item2 = new HistoryItem();
            History.historyList.Add(item1);
            History.historyList.Add(item2);

            History.pagePointer = 0;

            try
            {
                manager.getNextPage();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Write(e);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void get_next_page_out_of_range()
        {
            History.pagePointer = int.MaxValue;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => manager.getNextPage());
        }

        [TestMethod]
        public void get_previous_page()
        {
            HistoryItem item1 = new HistoryItem();
            HistoryItem item2 = new HistoryItem();
            History.historyList.Add(item1);
            History.historyList.Add(item2);

            History.pagePointer = 1;

            try
            {
                manager.getPreviousPage();
            } catch(ArgumentOutOfRangeException e)
            {
                Console.Write(e);
                Assert.Fail();
            }
        }

        [TestMethod]
        public void get_previous_page_out_of_range()
        {
            History.pagePointer = int.MaxValue;
            
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => manager.getPreviousPage());
        }
    }
}
