using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Simple_Web_Browser.Properties;
using System.Collections;
using System.Net;

namespace Simple_Web_Browser
{
    /// <summary>
    /// This class is the control centre for the web browser controlling the main functionality
    /// Responsible for managing the history and bookmarks as well 
    /// </summary>
    public class Manager
    {

        private string result;
        private string currentURL;
        public event EventHandler<RequestCompleteArgs> RequestComplete;

        Bookmark bookmarkManager;
        History historyManager;
        XML<string> XMLManager;
        HTTP http;
        setHomepage getHomepage;
        BrowserResponse browser;

        /// <summary>
        /// Default constructor, instantiates managers
        /// </summary>
        public Manager()
        {
            bookmarkManager = new Bookmark();
            historyManager = new History();
            XMLManager = new XML<string>();
            http = new HTTP();
            getHomepage = new setHomepage();
        }
        
        /// <summary>
        /// Validates a URL
        /// </summary>
        /// <param name="URL">The URL to be checked</param>
        /// <returns>True if a valid url, false otherwise</returns>
        public bool validURL(string URL)
        {
            return Uri.IsWellFormedUriString(URL, UriKind.Absolute);
        }

        /// <summary>
        /// Calls get website with the current URL to reload the page
        /// </summary>
        public void reloadPage()
        {
            loadWebsite(currentURL, false);
        }

        /// <summary>
        /// Gets the previous page from hisotry
        /// </summary>
        public void getNextPage()
        {
            try
            {
                History.pagePointer++;
                loadWebsite(History.historyList[History.pagePointer].historyURL, false);
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Gets the next page from history
        /// </summary>
        public void getPreviousPage()
        {
            try
            {
                History.pagePointer--;
                loadWebsite(History.historyList[History.pagePointer].historyURL, false);
            } catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        /// <summary>
        /// Search a history entry
        /// </summary>
        /// <param name="index">The index of the history element to be searched </param>
        public void searchHistory(int index)
        {
            try
            {
                loadWebsite(History.historyList[index].historyURL, true);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Search a bookmark entry
        /// </summary>
        /// <param name="index">The index of the bookmark element to be searched</param>
        public void searchBookmark(int index)
        {
            try
            {
                loadWebsite(Bookmark.bookmarkList[index].bookmarkURL, true);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// If no home URL has been set it will request this and store it to local storage.
        /// Otherwise it gets the locally stored URL
        /// </summary>
        /// <returns>The home URL the user set</returns>
        public string getHomeURL()
        {
            if (XMLManager.readXML(Resources.Homepage) == "")
            {
                do
                {
                    getHomepage.ShowDialog();
                // Keep asking for valid input until we get a 'valid' website
                } while (!validURL(getHomepage.homepageURLBox.Text));

                // Write the new URL to local storage
                XMLManager.writeToXML<string>(getHomepage.homepageURLBox.Text, Resources.Homepage);
            }

            return XMLManager.readXML(Resources.Homepage);
        }

        /// <summary>
        /// Updates the locally stored home URL
        /// </summary>
        /// <param name="homepage">The new hompeage URL</param>
        public void setHomepage(string homepage)
        {
            XMLManager.writeToXML<string>(homepage, Resources.Homepage);
        }

        /// <summary>
        /// Loads the provided URL (via triggering an event) 
        /// </summary>
        /// <param name="URL">The URL that has been requested</param>
        /// <param name="historyItem"> True (yes the item should be added to history) False (do not add to history) </param>
        public async void loadWebsite(string URL, bool historyItem) {

            // Setting the currentURL to the last loaded webpage
            currentURL = URL;

            try
            {
                HttpResponseMessage httpResponse = await HTTP.Get(URL);

                if(httpResponse.StatusCode == HttpStatusCode.OK)
                {

                    browser = new BrowserResponse(httpResponse);
                    result = await browser.getContent();

                    if (historyItem)
                    {
                        historyManager.addToHistory(URL);
                    }

                    RequestCompleteArgs args = new RequestCompleteArgs();
                    args.pageData = result;
                    // Used the following resource for the regex
                    //https://www.experts-exchange.com/questions/23135727/regular-expression-to-match-title-tag-on-html-page.html
                    args.title = Regex.Match(result, "<title>([^<]*)</title>").Groups[1].Value;
                    args.request = httpResponse.StatusCode.ToString(); 
                    args.URL = currentURL;
                    OnRequestComplete(args);

                } else {
                    throw new HttpResponseException(httpResponse);
                }

            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
    
        }

        /// <summary>
        /// Used to trigger an event in another class when the a page request is completed
        /// </summary>
        /// <param name="e">The args passed to the event</param>
        protected virtual void OnRequestComplete(RequestCompleteArgs e)
        {
            EventHandler<RequestCompleteArgs> handler = RequestComplete;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    /// <summary>
    /// Class used to represent the structure of a completed request
    /// </summary>
    public class RequestCompleteArgs : EventArgs
    {
        public string pageData { get; set; }
        public string title { get; set; }
        public string request { get; set; }
        public string URL { get; set; }
    }

}
