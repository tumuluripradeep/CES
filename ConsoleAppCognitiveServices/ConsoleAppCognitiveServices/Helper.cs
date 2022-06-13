using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCognitiveServices
{
    public class Helper
    {
        public static RestResponse PerformRestCall(string speechTextResult)
        {
            var restClient = new RestClient(Constants.langTranslationUrl);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Ocp-Apim-Subscription-Key", "9865b285ff534188920ee79b49fae634");
            request.AddHeader("Ocp-Apim-Subscription-Region", "eastus");
            var objectToSerialize = new Objects.Requestobject();
            //objectToSerialize.pro = new List<Item>{new Item { Text = speechTextResult }};
            objectToSerialize.Property1 = new Objects.Class2[] { new Objects.Class2 { Text = speechTextResult } };
            request.AddParameter("application/json", JsonConvert.SerializeObject(objectToSerialize.Property1), ParameterType.RequestBody);
            var response = restClient.Execute(request);
            return response;
        }
    }
}
