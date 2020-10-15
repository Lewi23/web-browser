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
        public string title;
        private string currentURL;
        public string request;

        HTTP test = new HTTP();
        

        //Bookmark & History manager
        Bookmark bookmark = new Bookmark();
        public History history = new History();

        //Write and read to the XML files
        XML<string> homepageXML = new XML<string>();

        // HTTP and web browsing 

        public event EventHandler<RequestCompleteArgs> RequestComplete;

        public Manager()
        {
            currentURL = getHomeURL();
            //historyManager = new History(currentURL);
        }



        public void reloadPage()
        {
            getWebsite(currentURL, false);
        }

        public void getNextPage()
        {
            History.pagePointer++;
            Console.WriteLine("GetNextPage Pointer " + History.pagePointer);
            getWebsite(History.historyList[History.pagePointer].historyURL, false);
        }

        public void getPreviousPage()
        {
            History.pagePointer--;
            Console.WriteLine("GetPreviousPage Pointer " + History.pagePointer);
            getWebsite(History.historyList[History.pagePointer].historyURL, false);
        }

        public void searchHistory(int index)
        {
            getWebsite(History.historyList[index].historyURL, true);
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

        
        

        public string getHomeURL()
        {
            //return homepageXML.getHomePageURI();
            return homepageXML.readXMLToGenericType(Resources.Homepage);
        }

        public void setHomePage(string homepage)
        {
            homepageXML.writeListToXML<string>(homepage, Resources.Homepage);
        }

        

        /// <summary>
        /// return the website
        /// </summary>
        /// <param name="URL">The URL that has been requested</param>
        /// <param name="historyItem"> True (yes the item should be added to history) False (do not add to history) </param>
        public async void getWebsite(String URL, bool historyItem) {

            currentURL = URL;

            try
            {
                // handle this it can throw
                HttpResponseMessage responseMessage = await HTTP.Get(URL);

                if(responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    BrowserResponse browser = new BrowserResponse(responseMessage);
                    result = await browser.getContent();

                    if (historyItem)
                    {
                        history.addToHistory(URL);
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
