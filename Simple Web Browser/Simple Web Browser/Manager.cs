using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Simple_Web_Browser
{
    class Manager
    {

        private string result;
        public string title;
        public string currentURL;
        public string request;

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
