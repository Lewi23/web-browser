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
        static readonly HttpClient client = new HttpClient();

        public static async Task<HttpResponseMessage> Get(String address)
        {
            return await client.GetAsync(address);
        }
    }
    
        
}
