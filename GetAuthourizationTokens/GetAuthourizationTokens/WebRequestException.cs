using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetAuthorizationTokens
{
    /// <summary>
    /// Custom exception classes derived from the Exception class.
    /// </summary>
    public class WebRequestException : Exception
    {
        public WebRequestException()
        {
        }
        public WebRequestException(string message) : base(message)
        {
        }

        public WebRequestException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            this.statusCode = statusCode;
        }
        public HttpStatusCode statusCode;
    }
}
