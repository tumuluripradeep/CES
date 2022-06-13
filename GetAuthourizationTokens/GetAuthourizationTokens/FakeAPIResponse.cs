using GetAuthorizationTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAuthorizationTokens
{
    public class FakeAPIResponse
    {
        public string endPoint { get; protected set; }
        public string data { get; protected set; }

        public WebRequestResponse webRequestResponse;

        public FakeAPIResponse(string endPoint, string data, WebRequestResponse webRequestResponse)
        {
            this.endPoint = endPoint;
            this.data = data;
            this.webRequestResponse = webRequestResponse;

        }


    }

}