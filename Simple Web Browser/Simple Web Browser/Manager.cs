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
    class Manager
    {

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

        public async Task<String> getWebsite(String URL, bool historyItem) {

            currentURL = URL;

            if (!historyItem)
            {
                historyManager.addToHistory(URL);
            }

            try
            {
                HttpResponseMessage responseMessage = await HTTP.Get(URL);
                BrowserResponse browser = new BrowserResponse(responseMessage);
                result = await browser.getContent();
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

                

                this.title = Regex.Match(result, "<title>([^<]*)</title>").Groups[1].Value;
                // if an exception isn't thrown we are 200 OK (I think)
                this.request = "200 OK";

                return result;
        }

     

    }
}
