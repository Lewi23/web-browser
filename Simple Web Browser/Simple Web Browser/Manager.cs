using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Simple_Web_Browser
{
    class Manager
    {

        String result;

        public Manager()
        {
        }

        HTTP test = new HTTP();
        HttpResponseMessage responseMessage;

        private async Task<String> get_data(String URL)
        {
            HttpResponseMessage responseMessage = await HTTP.Get(URL);
            BrowserResponse browser = new BrowserResponse(responseMessage);

            result = await browser.getContent();
            return result;
        }

        public async Task<string> getWebsite(String URL)
        {
            return await get_data(URL);
            //return result;
        }

    }
}
