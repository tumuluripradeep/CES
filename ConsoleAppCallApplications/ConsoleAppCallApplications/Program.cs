using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGetExternalAppsData
{
    public class Program
    {
        static void Main(string[] args)
        {
            string jsonContent = BuildJSONContent();
            string IMSTokenEndPoint = "https://ims-na1-stg1.adobelogin.com/ims/token/v1?code=eyJ4NXUiOiJpbXNfbmExLXN0ZzEta2V5LTEuY2VyIiwiYWxnIjoiUlMyNTYifQ.eyJpZCI6IkNSTUR5bmFtaWNzQ2xpZW50Ml9zdGciLCJjbGllbnRfaWQiOiJDUk1EeW5hbWljc0NsaWVudDIiLCJ1c2VyX2lkIjoiQ1JNRHluYW1pY3NDbGllbnQyQEFkb2JlSUQiLCJ0eXBlIjoiYXV0aG9yaXphdGlvbl9jb2RlIiwib3RvIjoiZmFsc2UiLCJleHBpcmVzX2luIjoiMjU5MjAwMDAwMDAwIiwic2NvcGUiOiJyZWFkX2NvdW50cmllc19yZWdpb25zLHN5c3RlbSxhZG1pbl9jcmVhdGVfaW5jcl9hY2NvdW50LHN1cHBvcnRhbnl3YXJlIiwiY3JlYXRlZF9hdCI6IjE1MjE1NTA0NjU1ODQifQ.gD-WWUGdhyH4c_6DyVUWjvq7dIIP3y0bbJQBjNFXA0KXlrPnfAUlBD1HKVfHR9DKMf2N3N2aUeFwaHKudEsbqlqP7wVZd9SVCfDBpZKs_ljPTck7xuS6Rl3uoeVD7oiv96IX7NMserb4jDChePmbS22177Z3nY-lxZGy7MOaKe0Q049EUjO-F5WwQ0I_rGt0m_QH40LJ78tVvesevY0JPeIitAluQpzw-7PMZrPyZFdfJA-MALv4YOC55dpv9qris-LD2KPp0Jf0XBXzG5F_LLKrUrBmFSB8dl2v9Kt-zff9EC8vOdaU-bmgXA3q80NmY98y4Xu6V2M1b6VyFCfcRg&client_secret=ccfcf8d5-05eb-4fb2-a63d-f5d3de9c0169&grant_type=authorization_code&client_id=CRMDynamicsClient2";
            SendMessageToAzureFunction(IMSTokenEndPoint, jsonContent);
        }

        /// <summary>
        /// Method used to send a json content to an azure function endpoint.
        /// </summary>
        /// <param name="azureFunctionEndpoint">Azure Function Endpoint.</param>
        /// <param name="jsonContent">JSON content.</param>
        private static void SendMessageToAzureFunction(string IMSTokenEndPoint, string jsonContent)
        {
            string response = string.Empty;
            bool isSuccess = false;
            HttpStatusCode statusCode = default(HttpStatusCode);
            Exception exception = null;

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(IMSTokenEndPoint),
                Timeout = new TimeSpan(0, 2, 0),
            };
            httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress) { Content = new StringContent(jsonContent, Encoding.UTF8, "application/json") };
            Task<HttpResponseMessage> result = httpClient.SendAsync(request);
            WebRequestResponse webRequestResponse = new WebRequestResponse(response, isSuccess, statusCode, exception);
        }

        private static string BuildJSONContent()
        {
            Console.WriteLine("Enter name of applicatoin you need token of :");
            string systemName = Console.ReadLine();

            ExternalApplication accountMessage = new ExternalApplication
            {
                Name = systemName,
            };
            string jsonContent = JsonConvert.SerializeObject(accountMessage, Formatting.Indented);
            return jsonContent;
        }

        private static string Serialize<T>(T data)
        {
            MemoryStream stream = null;
            try
            {
                string json = string.Empty;
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                stream = new MemoryStream();
                serializer.WriteObject(stream, data);
                stream.Position = 0;
                using (StreamReader sr = new StreamReader(stream))
                {
                    stream = null;
                    json = sr.ReadToEnd();
                    sr.Close();
                }
                return json;
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.InnerException.Message);
            }
            finally
            {
                stream?.Dispose();
            }
        }


        [DataContract]
        public class ExternalApplication
        {
            [DataMember(Name = "name", IsRequired = true)]
            public string Name { get; set; }

        }
    }
}
