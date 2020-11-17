using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace Simple_Web_Browser
{
    /// <summary>
    /// This class is the control centre for the web browser controlling the main functionality
    /// Responsible for managing the history and bookmarks as well 
    /// </summary>
    public class Manager
    {

  
        // create path to homepage xml file 
        string homepagePath = Application.StartupPath + "\\Homepage.xml";

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
        /// Builds the JSON files for storing the persistent data if they do not exisist
        /// </summary>
        public void buildJSONFiles()
        {
            if (!File.Exists(Application.StartupPath + "\\Bookmarks.xml"))
            {
                new XDocument(
                    new XElement("ArrayOfBookmarkItem")
                )
            .Save("Bookmarks.xml");
            }

            if (File.Exists(Application.StartupPath + "\\Homepage.xml"))
            {
                new XDocument(
                new XElement("string")
                )
            .Save("Homepage.xml");
            }

            if (!File.Exists(Application.StartupPath + "\\SearchHistory.xml"))
            {
                new XDocument(
                new XElement("ArrayOfHistoryItem")
            )
            .Save("SearchHistory.xml");
            }
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
            History.pagePointer++;
            loadWebsite(History.historyList[History.pagePointer].historyURL, false);
        }

        /// <summary>
        /// Gets the next page from history
        /// </summary>
        public void getPreviousPage()
        {
            History.pagePointer--;
            loadWebsite(History.historyList[History.pagePointer].historyURL, false);            
        }

        /// <summary>
        /// Search a history entry
        /// </summary>
        /// <param name="index">The index of the history element to be searched </param>
        public void searchHistory(int index)
        {
            loadWebsite(History.historyList[index].historyURL, true);

        }

        /// <summary>
        /// Search a bookmark entry
        /// </summary>
        /// <param name="index">The index of the bookmark element to be searched</param>
        public void searchBookmark(int index)
        {
            loadWebsite(Bookmark.bookmarkList[index].bookmarkURL, true);
        }

        /// <summary>
        /// If no home URL has been set it will request this and store it to local storage.
        /// Otherwise it gets the locally stored URL
        /// </summary>
        /// <returns>The home URL the user set</returns>
        public string getHomeURL()
        {
            if (XMLManager.readXML(homepagePath) == "")
            {
                do
                {
                    getHomepage.ShowDialog();
                    
                    // Keep asking for valid input until we get a 'valid' website
                } while (!validURL(getHomepage.homepageURLBox.Text));

                // Write the new URL to local storage
                XMLManager.writeToXML<string>(getHomepage.homepageURLBox.Text, homepagePath);
            }

            return XMLManager.readXML(homepagePath);
        }

        /// <summary>
        /// Updates the locally stored home URL
        /// </summary>
        /// <param name="homepage">The new hompeage URL</param>
        public void setHomepage(string homepage)
        {
            XMLManager.writeToXML<string>(homepage, homepagePath);
        }


        /// <summary>
        /// Public class to call _loadWebsite(); and handle any http errors
        /// </summary>
        /// <param name="URL">The URL to be loaded</param>
        /// <param name="historyItem">True (yes the item should be added to history) False (do not add to history)</param>
        public async void loadWebsite(string URL, bool historyItem)
        {
            try
            {
                await _loadWebsite(URL, historyItem);
            } catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Loads the provided URL (via triggering an event) 
        /// </summary>
        /// <param name="URL">The URL that has been requested</param>
        /// <param name="historyItem"> True (yes the item should be added to history) False (do not add to history) </param>
        public async Task<bool> _loadWebsite(string URL, bool historyItem) {

            // Setting the currentURL to the last loaded webpage
            currentURL = URL;

            HttpResponseMessage httpResponse = await HTTP.Get(URL);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
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

                    return true;

                }
            else
            {
                // Display the relevant HTTPresponse status code error messageS
                // Error messages from : https://docs.microsoft.com/en-us/dotnet/api/system.net.httpstatuscode?view=netcore-3.1
                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        System.Windows.Forms.MessageBox.Show("The request could not be understood by the server", "400 Bad Request");
                        break;
                    case HttpStatusCode.Forbidden:
                        System.Windows.Forms.MessageBox.Show("The server refuses to fulfill the request", "403 Forbidden");
                        break;
                    case HttpStatusCode.NotFound:
                        System.Windows.Forms.MessageBox.Show("The requested resource does not exist on the server", "404 Not Found");
                        break;
                    default:
                        // Handling all other status codes (apart from 200)
                        System.Windows.Forms.MessageBox.Show(httpResponse.StatusCode.ToString(), "Unhandeled status code");
                        break;
                    }
                }
            //Throws an exception if invalid response
            httpResponse.EnsureSuccessStatusCode();
            // The webpage was not loaded
            return false;
            

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
