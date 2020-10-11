using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public class Manager
    {

        public event EventHandler<string> gotUrlEvent;

        private string result;
        public string title;
        public string currentURL;
        public string request;

        HTTP test = new HTTP();
        XML homepageXML = new XML("Data");
        public History historyManager;



        public Manager()
        {
            currentURL = getHomeURL();
            historyManager = new History(currentURL);
        }

        

        public string getHomeURL()
        {
            return homepageXML.getHomePageURI();
        }



        public async void getWebsite(String URL, bool historyItem) {

            currentURL = URL;

            if (!historyItem)
            {
                historyManager.addToHistory(URL);
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

        public event EventHandler<RequestCompleteArgs> RequestComplete;
    }
    public class RequestCompleteArgs : EventArgs
    {
        public string pageData { get; set; }
        public string title { get; set; }
        public string request { get; set; }

        public string URL { get; set; }
    }

}
