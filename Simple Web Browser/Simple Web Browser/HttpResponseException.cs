using System;
using System.Net;
using System.Net.Http;

namespace Simple_Web_Browser
{
    internal class HttpResponseException : Exception
    {
        public HttpResponseException(HttpResponseMessage message)
        {
            // Error messages from : https://docs.microsoft.com/en-us/dotnet/api/system.net.httpstatuscode?view=netcore-3.1
            switch (message.StatusCode)
            { 
                case HttpStatusCode.BadRequest:
                    System.Windows.Forms.MessageBox.Show("The request could not be understood by the server", "400 Bad Request");
                    break;
                case HttpStatusCode.Forbidden:
                    System.Windows.Forms.MessageBox.Show("The server refuses to fulfill the request", "403 Forbidden");
                    break;
                case HttpStatusCode.NotFound:
                    System.Windows.Forms.MessageBox.Show("The requested resource does not exist on the server", "404 Not Found");
                    break;
                default:
                    // Handling all other status codes (apart from 200)
                    System.Windows.Forms.MessageBox.Show(message.StatusCode.ToString(), "Unhandeled status code");
                    break;
            }
        }
    }
}