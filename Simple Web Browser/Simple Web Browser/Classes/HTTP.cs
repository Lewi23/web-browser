using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Simple_Web_Browser
{
    class HTTP
    {
        // Influence taken from
        // https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netcore-3.1

        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Returns the http response message of the provided URL
        /// </summary>
        /// <param name="address"></param>
        /// <returns>The URL to check</returns>
        public static async Task<HttpResponseMessage> Get(string URL)
        {
            return await client.GetAsync(URL);
        }
    }
    
        
}
