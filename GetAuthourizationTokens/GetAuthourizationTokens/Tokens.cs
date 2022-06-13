using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Xrm.Sdk;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.WebServiceClient;
using Microsoft.Crm.Sdk.Messages;

namespace GetAuthorizationTokens
{
    public static class Tokens
    {
        [FunctionName("GetAuthorizationTokens")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0).Value;
            string accessKey_Token= string.Empty;

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();name = data?.name;       
                switch (name)
                {
                    case "AzureCognitiveServices":
                        
                        break;
                    case "IMS":
                        accessKey_Token = Utility.GetIMSToken();
                        break;
                    case "MILO":
                        
                        break;
                    case "Coveo":
                        
                        break;
                }
            }

            return accessKey_Token == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, accessKey_Token);
        }
    }
}
