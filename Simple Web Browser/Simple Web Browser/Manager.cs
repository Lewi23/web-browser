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

namespace Simple_Web_Browser
{
    public class Manager
    {

        private string result;
        public string title;
        public string currentURL;
        public string request;

        HTTP test = new HTTP();
        
        public History historyManager;

        //Bookmark & History manager
        Bookmark bookmark = new Bookmark();
        public History1 hm1 = new History1();

        //Write and read to the XML files
        XML<string> homepageXML = new XML<string>();

        // HTTP and web browsing 

        public event EventHandler<RequestCompleteArgs> RequestComplete;

        public Manager()
        {
            currentURL = getHomeURL();
            historyManager = new History(currentURL);
        }

        public void getNextPage()
        {
            History1.pagePointer++;
            getWebsite(History1.historyList[History1.pagePointer].historyURL, false);
        }

        public void getPreviousPage()
        {
            History1.pagePointer--;
            getWebsite(History1.historyList[History1.pagePointer].historyURL, false);
        }

        public void searchBookmark(int index)
        {
            try
            {
                getWebsite(Bookmark.bookmarkList[index].bookmarkURL, true);
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void searchHistory(int index)
        {
            getWebsite(History1.historyList[index].historyURL, true);
        }
        

        public string getHomeURL()
        {
            //return homepageXML.getHomePageURI();
            return homepageXML.readXML(Resources.Homepage);
        }

        public void setHomePage(string homepage)
        {
            homepageXML.writeListToXML<string>(homepage, Resources.Homepage);
        }

        public void loadSelected(int index)
        {
            getWebsite(historyManager.historyURL(index), false);
        }

        /// <summary>
        /// return the website
        /// </summary>
        /// <param name="URL">The URL that has been requested</param>
        /// <param name="historyItem"> True (yes the item should be added to history) False (do not add to history) </param>
        public async void getWebsite(String URL, bool historyItem) {

            currentURL = URL;

            if (historyItem)
            {
                //Console.WriteLine("HISTORY ADDED");
                historyManager.addToHistory(URL);
                hm1.addToHistory(URL);

            }


            HttpResponseMessage responseMessage = await HTTP.Get(URL);
            BrowserResponse browser = new BrowserResponse(responseMessage);
            result = await browser.getContent();
            
            RequestCompleteArgs args = new RequestCompleteArgs();
            args.pageData = result;
            args.title = Regex.Match(result, "<title>([^<]*)</title>").Groups[1].Value;
            args.request = "200 OK"; // need to fix this it's hardcoded
            args.URL = currentURL;
            OnRequestComplete(args);
    
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
