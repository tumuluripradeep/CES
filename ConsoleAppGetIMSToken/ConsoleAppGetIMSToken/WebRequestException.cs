using System;
using System.Net;
using System.Runtime.Serialization;

namespace ConsoleAppGetIMSToken
{
    [Serializable]
    internal class WebRequestException : Exception
    {
        private string v;
        private HttpStatusCode statusCode;
        private Exception exception;

        public WebRequestException()
        {
        }

        public WebRequestException(string message) : base(message)
        {
        }

        public WebRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public WebRequestException(string v, HttpStatusCode statusCode, Exception exception)
        {
            this.v = v;
            this.statusCode = statusCode;
            this.exception = exception;
        }

        protected WebRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}