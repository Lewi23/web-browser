﻿using System.Threading.Tasks;
using System.Net.Http;


namespace Simple_Web_Browser
{
    /// <summary>
    /// This class is responsible for getting the contents of a webpage 
    /// </summary>
    class BrowserResponse
    {

        // Influence taken from
        // https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netcore-3.1

        private HttpResponseMessage response;

        /// <summary>
        /// Constructor setting the response field
        /// </summary>
        /// <param name="response">The HTTP response message</param>
        public BrowserResponse(HttpResponseMessage response)
        {
            this.response = response;
        }

        /// <summary>
        /// Returns the webpage content as a string
        /// </summary>
        /// <returns>A string containing the web page content</returns>
        public async Task<string> getContent()
        {
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
