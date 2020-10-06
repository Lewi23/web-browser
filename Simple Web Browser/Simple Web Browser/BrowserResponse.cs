using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Simple_Web_Browser
{

    class BrowserResponse
    {

        private HttpResponseMessage response;

        public BrowserResponse(HttpResponseMessage response)
        {
            this.response = response;
        }
        public async Task<string> getContent()
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
