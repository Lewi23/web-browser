using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Policy;

namespace Simple_Web_Browser
{
    class Manager
    {

        private string result;
        public string currentURL;
        HTTP test = new HTTP();

        XML homepage = new XML("Data");

        public Manager()
        {
            currentURL = getHomeURL();
        }

  
        public string getHomeURL()
        {
            return homepage.getHomePageURI();
        }

        public async Task<String> getWebsite(String URL) {

                currentURL = URL;   

                HttpResponseMessage responseMessage = await HTTP.Get(URL);
                BrowserResponse browser = new BrowserResponse(responseMessage);
                result = await browser.getContent();

                return result;
        }

    }
}
