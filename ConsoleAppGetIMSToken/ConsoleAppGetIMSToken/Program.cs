using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGetIMSToken
{
    class Program
    {

        static void Main(string[] args)
        {
            var IMSToken = GetIMSToken();
            GetCustomerData(IMSToken);
        }

        public static string GetIMSToken()
        {
            var imsToken = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var endPoint = new Uri("https://ims-na1-stg1.adobelogin.com/ims/token/v1?code=eyJ4NXUiOiJpbXNfbmExLXN0ZzEta2V5LTEuY2VyIiwiYWxnIjoiUlMyNTYifQ.eyJpZCI6IkNSTUR5bmFtaWNzQ2xpZW50Ml9zdGciLCJjbGllbnRfaWQiOiJDUk1EeW5hbWljc0NsaWVudDIiLCJ1c2VyX2lkIjoiQ1JNRHluYW1pY3NDbGllbnQyQEFkb2JlSUQiLCJ0eXBlIjoiYXV0aG9yaXphdGlvbl9jb2RlIiwib3RvIjoiZmFsc2UiLCJleHBpcmVzX2luIjoiMjU5MjAwMDAwMDAwIiwic2NvcGUiOiJyZWFkX2NvdW50cmllc19yZWdpb25zLHN5c3RlbSxhZG1pbl9jcmVhdGVfaW5jcl9hY2NvdW50LHN1cHBvcnRhbnl3YXJlIiwiY3JlYXRlZF9hdCI6IjE1MjE1NTA0NjU1ODQifQ.gD-WWUGdhyH4c_6DyVUWjvq7dIIP3y0bbJQBjNFXA0KXlrPnfAUlBD1HKVfHR9DKMf2N3N2aUeFwaHKudEsbqlqP7wVZd9SVCfDBpZKs_ljPTck7xuS6Rl3uoeVD7oiv96IX7NMserb4jDChePmbS22177Z3nY-lxZGy7MOaKe0Q049EUjO-F5WwQ0I_rGt0m_QH40LJ78tVvesevY0JPeIitAluQpzw-7PMZrPyZFdfJA-MALv4YOC55dpv9qris-LD2KPp0Jf0XBXzG5F_LLKrUrBmFSB8dl2v9Kt-zff9EC8vOdaU-bmgXA3q80NmY98y4Xu6V2M1b6VyFCfcRg&client_secret=ccfcf8d5-05eb-4fb2-a63d-f5d3de9c0169&grant_type=authorization_code&client_id=CRMDynamicsClient2");
                    var result = client.PostAsync(endPoint, new StringContent("", Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                    IMSTokenResponseObject IMSTokenResponseObject = JsonConvert.DeserializeObject<IMSTokenResponseObject>(result);
                    imsToken = IMSTokenResponseObject.access_token;
                    Console.WriteLine(imsToken + "\n" + "\n");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return imsToken;
        }




        public static WebRequestResponse PerformHttpCall(string IMSToken, string method)
        {
            string response = string.Empty;
            Task<HttpResponseMessage> result = null;
            bool isSuccess = false;
            HttpStatusCode statusCode = default(HttpStatusCode);
            Exception exception = null;
            CustomerSearchRequest request = new CustomerSearchRequest();
            try
            {
                Console.WriteLine("Enter Customer Email :");
                var customerEmail = Console.ReadLine();

                request.email = customerEmail;
                request.firstName = "";
                request.lastName = "";
                request.imsOrgId = "";
                request.phone = "";
                request.orgName = "";
                request.domain = "";
                request.connectDomain = "";
                request.endUserId = "";
                request.serialNumber = "";
                request.dealRegNumber = "";
                request.orderId = "";
                request.langCode = 0;


                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.ConnectionClose = true;
                string data = JsonConvert.SerializeObject(request, Formatting.Indented);
                byte[] requestInFormOfBytes = System.Text.Encoding.UTF8.GetBytes(data);
                client.DefaultRequestHeaders.Add("x-api-key", "CRMDynamicsClient2");
                client.DefaultRequestHeaders.Add("Authorization", IMSToken);
                result = client.PostAsync(new Uri("https://supportanyware-stage.adobe.io/products_support/organizations/search"), new StringContent(data, Encoding.UTF8, "application/json"));

                if (result.Result.IsSuccessStatusCode)
                {
                    var responseContent = result.Result.Content;
                    if (responseContent is object)
                    {
                        Stream responseStream = responseContent.ReadAsStreamAsync().Result;
                        if (responseStream != null)
                        {
                            StreamReader responseReader = new StreamReader(responseStream);
                            response = responseReader.ReadToEnd();
                            isSuccess = true;
                            statusCode = result.Result.StatusCode;
                            responseReader.Close();
                        }
                        responseStream.Close();
                    }

                }
                else
                {
                    statusCode = result.Result.StatusCode;
                    exception = new WebRequestException("Error in MakeWebRequest", result.Result.StatusCode, new Exception($"{result.Result}"));
                    result.Result.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            WebRequestResponse webRequestResponse = new WebRequestResponse(response, isSuccess, statusCode, exception);
            return webRequestResponse;
        }


        public static void GetCustomerData(string IMSToken)
        {
            try
            {
                WebRequestResponse searchResult = PerformHttpCall(IMSToken, "CustomerSearch");
                List<Organization> orgs = null;
                if (searchResult.isSuccess)
                    orgs = JsonConvert.DeserializeObject<List<Organization>>(searchResult.response);
                CustomerSearchResponse response = new CustomerSearchResponse();
                response.resultRecords = new List<ResultGrid>();
                if (orgs != null)
                {
                    foreach (var org in orgs)
                    {
                        List<Contact> contacts = org.contacts;
                        //If contact doesn't exist then just show the org details
                        if (contacts == null || contacts.Count == 0)
                        {
                            ResultGrid row = new ResultGrid();
                            row.orgId = org.imsOrgId;
                            row.orgName = org.orgName1;
                            row.endUserId = org.endUserId;
                            row.country = org.country;
                            response.resultRecords.Add(row);
                        }
                        else
                        {
                            foreach (var contact in contacts)
                            {
                                ResultGrid row = new ResultGrid();
                                row.name = contact.firstName + " " + contact.lastName;
                                //row.orgId = org.imsOrgId;
                                //row.orgName = org.orgName1;
                                //row.rengaId = contact.rengaId;
                                //row.endUserId = org.endUserId;
                                row.country = org.country;
                                row.type = contact.type;
                                //row.role = contact.role == null ? String.Empty : String.Join(",", contact.role);
                                //row.role = row.role.ToUpper();
                                //row.role = row.role.Replace("ORG_ADMIN", "System Administrator")
                                //                   .Replace("SUPPORT_ADMIN", "Support Administrator")
                                //                   .Replace("DEPLOYMENT_ADMIN", "Deployment Administrator")
                                //                   .Replace("PRODUCT_ADMIN", "Product Administrator")
                                //                   .Replace("LICENSE_ADMIN", "Product Profile Administrator")
                                //                   .Replace("USER_GROUP_ADMIN", "User Group Administrator");
                                row.emailId = contact.email == null ? String.Empty : String.Join(",", contact.email);
                                response.resultRecords.Add(row);
                                Console.WriteLine($"\tNAME: {row.name},\tEMAIL: {row.emailId},\tCOUNTRY: {row.country},\tTYPE: {row.type}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Console.ReadKey();
            Console.WriteLine("Finished");
        }
    }

    #region Customer Object

    [DataContract]
    public class CustomerSearchRequest
    {
        [DataMember(EmitDefaultValue = false)]
        public string email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string firstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string lastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string imsOrgId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string orgName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string phone { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string domain { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string connectDomain { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string endUserId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string serialNumber { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string dealRegNumber { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string orderId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int langCode { get; set; }
    }

    [DataContract]
    public class Organization
    {
        [DataMember(EmitDefaultValue = false)]
        public string endUserId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string imsOrgId { get; set; }


        [DataMember(EmitDefaultValue = false)]
        public string orgName2 { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string orgName1 { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> phone { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Contact> contacts { get; set; }
    }

    [DataContract]
    public class Contact
    {
        [DataMember(EmitDefaultValue = false)]
        public string firstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string lastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string rengaId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> phone { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> role { get; set; }
    }

    [DataContract]
    public class CustomerSearchResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public List<ResultGrid> resultRecords { get; set; }
    }

    [DataContract]
    public class ResultGrid
    {
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string emailId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string orgId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string orgName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string role { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string endUserId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string endUserName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string rengaId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string country { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string type { get; set; }
    }


    public class CustomWebResponse
    {
        public string response { get; protected set; }
        public bool isSuccess { get; protected set; }
        public Exception exception { get; protected set; }
    }
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

    #endregion

    #region JIL Related

    [DataContract]
    public class JILProductResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public string offerId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string organizationId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<fulfillableItems> fulfillableItems { get; set; }
    }

    [DataContract]
    public class fulfillableItems
    {
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string longName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string longDescription { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string cloud { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string fulfillableItemType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public chargingModel chargingModel { get; set; }
    }

    [DataContract]
    public class chargingModel
    {
        [DataMember(EmitDefaultValue = false)]
        public string unit { get; set; }
    }

    #endregion
}
