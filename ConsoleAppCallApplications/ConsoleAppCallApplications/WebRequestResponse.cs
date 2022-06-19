using System;
using System.Net;

namespace ConsoleAppGetExternalAppsData
{
    /// <summary>
    /// Base class for WebRequestResponse.
    /// </summary>
    public class CustomWebResponse
    {
        public string response { get; protected set; }
        public bool isSuccess { get; protected set; }
        public Exception exception { get; protected set; }
    }
    /// <summary>
    /// Class to return Http Web Request Response Object
    /// </summary>
    public class WebRequestResponse : CustomWebResponse
    {
        public WebRequestResponse(string response, bool isSuccess, HttpStatusCode statusCode, Exception exception)
        {
            this.response = response;
            this.isSuccess = isSuccess;
            this.statusCode = statusCode;
            this.exception = exception;
        }

        public HttpStatusCode statusCode { get; protected set; }
    }
}
