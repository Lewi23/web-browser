using System;
using System.Net;
using System.Net.Http;

namespace Simple_Web_Browser
{
    internal class HttpResponseException : Exception
    {
      
        public HttpResponseException(HttpResponseMessage message)
        {
            switch (message.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    System.Windows.Forms.MessageBox.Show("Bad Request", "Error");
                    break;
                case HttpStatusCode.Forbidden:
                    System.Windows.Forms.MessageBox.Show("Forbidden", "Error");
                    break;
                case HttpStatusCode.NotFound:
                    System.Windows.Forms.MessageBox.Show("Not Found", "Error");
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show(message.StatusCode.ToString(), "Error");
                    break;
            }
        }
    }
}