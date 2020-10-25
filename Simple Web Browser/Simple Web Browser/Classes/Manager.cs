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
    public class Manager
    {

        private string result;
        private string currentURL;
       
        public event EventHandler<RequestCompleteArgs> RequestComplete;

        Bookmark bookmarkManager = new Bookmark();
        History historyManager = new History();
        XML<string> XMLManager = new XML<string>();
        HTTP http = new HTTP();
        setHomepage getHomepage = new setHomepage();



        public Manager()
        {

        }
        
        public bool validURL(string URL)
        {
            return Uri.IsWellFormedUriString(URL, UriKind.Absolute);
        }

        /// <summary>
        /// Calls get website with the current URL to reload the page
        /// </summary>
        public void reloadPage()
        {
            getWebsite(currentURL, false);
        }

        public void getNextPage()
        {
            try
            {
                History.pagePointer++;
                getWebsite(History.historyList[History.pagePointer].historyURL, false);
            } catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void getPreviousPage()
        {
            try
            {
                History.pagePointer--;
                getWebsite(History.historyList[History.pagePointer].historyURL, false);
            } catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void searchHistory(int index)
        {

            try
            {
                getWebsite(History.historyList[index].historyURL, true);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void searchBookmark(int index)
        {
            try
            {
                getWebsite(Bookmark.bookmarkList[index].bookmarkURL, true);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string getHomeURL()
        {
            if (XMLManager.readXML(Resources.Homepage) == "")
            {

                do
                {
                    getHomepage.ShowDialog();
                // Keep asking for valid input until we get a 'valid' website
                } while (!validURL(getHomepage.homepageURLBox.Text));

                
                XMLManager.writeToXML<string>(getHomepage.homepageURLBox.Text, Resources.Homepage);

            }

            return XMLManager.readXML(Resources.Homepage);
        }

        public void setHomepage(string homepage)
        {
            XMLManager.writeToXML<string>(homepage, Resources.Homepage);
        }

        /// <summary>
        /// return the website
        /// </summary>
        /// <param name="URL">The URL that has been requested</param>
        /// <param name="historyItem"> True (yes the item should be added to history) False (do not add to history) </param>
        public async void getWebsite(String URL, bool historyItem) {

            // Set the currentURL to the last loaded webpage
            currentURL = URL;

            try
            {
                HttpResponseMessage responseMessage = await HTTP.Get(URL);

                if(responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    BrowserResponse browser = new BrowserResponse(responseMessage);
                    result = await browser.getContent();

                    if (historyItem)
                    {
                        historyManager.addToHistory(URL);
                    }

                    RequestCompleteArgs args = new RequestCompleteArgs();
                    args.pageData = result;
                    args.title = Regex.Match(result, "<title>([^<]*)</title>").Groups[1].Value;
                    args.request = responseMessage.StatusCode.ToString(); // need to fix this it's hardcoded
                    args.URL = currentURL;
                    OnRequestComplete(args);

                } else {
                    throw new HttpResponseException(responseMessage);
                }

            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
    
        }

        protected virtual void OnRequestComplete(RequestCompleteArgs e)
        {
            EventHandler<RequestCompleteArgs> handler = RequestComplete;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    public class RequestCompleteArgs : EventArgs
    {
        public string pageData { get; set; }
        public string title { get; set; }
        public string request { get; set; }
        public string URL { get; set; }
    }

}
