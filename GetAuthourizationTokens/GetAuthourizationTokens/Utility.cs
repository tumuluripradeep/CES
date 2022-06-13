/// <summary>
/// Utility class to define all the common methods used across all the Plugins and Custom Actions
/// </summary>
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using Microsoft.Xrm.Sdk.Messages;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk.WebServiceClient;
using Microsoft.Crm.Sdk.Messages;

namespace GetAuthorizationTokens
{
    public class Utility
    {
        //List to hold fake responses to handle FakeXrmEasy unit test cases.
        public static List<FakeAPIResponse> fakeAPIResponses = null;
        /// <summary>
        /// Generic execute multiple declaration
        /// </summary>
        /// <returns></returns>
        public static ExecuteMultipleRequest ExecuteMulipleDeclaration()
        {
            return new ExecuteMultipleRequest() { Requests = new OrganizationRequestCollection(), Settings = new ExecuteMultipleSettings() { ContinueOnError = true, ReturnResponses = true } };
        }

        /// <summary>
        /// Function to retrieve system settings by Group and Key
        /// </summary>
        public static string GetSystemSettings(string groupName, string key, IOrganizationService service, ITracingService tracingService)
        {
            string strValue = null;
            try
            {
                var orgRequest = new OrganizationRequest()
                {
                    RequestName = Constants.CONSTANT_ACTION_GETSYSTEMSETTINGSAPI
                };
                orgRequest.Parameters.Add(GetSystemSettingsParameters.INPARAM_KEY, key);
                orgRequest.Parameters.Add(GetSystemSettingsParameters.INPARAM_GROUP, groupName);
                OrganizationResponse orgResponse = service.Execute(orgRequest);
                if (orgResponse?.Results?.Keys != null)
                {
                    if (orgResponse.Results.ContainsKey(GetSystemSettingsParameters.OUTPARAM_RESULT))
                    {
                        List<SystemSettingResponse> sysSettingCln = JsonHelper.Deserialize<List<SystemSettingResponse>>(orgResponse.Results[GetSystemSettingsParameters.OUTPARAM_RESULT]?.ToString());
                        strValue = sysSettingCln?.FirstOrDefault()?.value;
                    }
                }
            }
            catch (Exception ex)
            {
                tracingService?.Trace($"Error: An error occured in GetSystemSettings method. Error Details: {ex.Message}");
            }
            return strValue;
        }

        /// <summary>
        /// Function to retrieve all system settings by Group
        /// </summary>
        public static Dictionary<string, string> GetSystemSettings(string groupName, IOrganizationService service, ITracingService tracingService)
        {
            tracingService.Trace("Retreiving System Settings for Group: {0}", groupName);
            Dictionary<string, string> settings = new Dictionary<string, string>();
            try
            {
                var orgRequest = new OrganizationRequest()
                {
                    RequestName = Constants.CONSTANT_ACTION_GETSYSTEMSETTINGSAPI
                };
                orgRequest.Parameters.Add(GetSystemSettingsParameters.INPARAM_GROUP, groupName);
                OrganizationResponse orgResponse = service.Execute(orgRequest);
                if (orgResponse?.Results?.Keys != null)
                {
                    if (orgResponse.Results.ContainsKey(GetSystemSettingsParameters.OUTPARAM_RESULT))
                    {
                        List<SystemSettingResponse> sysSettingCln = JsonHelper.Deserialize<List<SystemSettingResponse>>(orgResponse.Results[GetSystemSettingsParameters.OUTPARAM_RESULT]?.ToString());
                        settings = sysSettingCln?.ToDictionary(k => k.key, v => v.value);
                    }
                }
            }
            catch (Exception ex)
            {
                tracingService?.Trace($"Error: An error occured in GetSystemSettings method. Error Details: {ex.Message}");
            }
            return settings;
        }

        /// <summary>
        /// Function to retrieve all system settings by Key(s)
        /// </summary>
        public static Dictionary<string, string> GetSystemSettings(IOrganizationService service, ITracingService tracingService, params string[] keys)
        {
            tracingService.Trace("Retreiving System Settings for Group: {0}", string.Join(",", keys));
            Dictionary<string, string> settings = new Dictionary<string, string>();
            try
            {
                var orgRequest = new OrganizationRequest()
                {
                    RequestName = Constants.CONSTANT_ACTION_GETSYSTEMSETTINGSAPI
                };
                orgRequest.Parameters.Add(GetSystemSettingsParameters.INPARAM_KEY, string.Join(",", keys));
                OrganizationResponse orgResponse = service.Execute(orgRequest);
                if (orgResponse?.Results?.Keys != null)
                {
                    if (orgResponse.Results.ContainsKey(GetSystemSettingsParameters.OUTPARAM_RESULT))
                    {
                        List<SystemSettingResponse> sysSettingCln = JsonHelper.Deserialize<List<SystemSettingResponse>>(orgResponse.Results[GetSystemSettingsParameters.OUTPARAM_RESULT]?.ToString());
                        settings = sysSettingCln?.ToDictionary(k => k.key, v => v.value);
                    }
                }
            }
            catch (Exception ex)
            {
                tracingService?.Trace($"Error: An error occured in GetSystemSettings method. Error Details: {ex.Message}");
            }

            return settings;
        }

        /// <summary>
        /// To encrypt text provided
        /// </summary>
        /// <param name="text">Text to be encrypted</param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            string EncryptionKey = Constants.CONSTANT_DECRYPTKEY;

            byte[] clearBytes = Encoding.Unicode.GetBytes(text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    text = Convert.ToBase64String(ms.ToArray());
                }
            }
            return text;
        }

        private static byte[] xorWithKey(byte[] a, byte[] key)
        {
            byte[] output = new byte[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                output[i] = (byte)(a[i] ^ key[i % key.Length]);
            }
            return output;
        }

        public static string EncryptGuid(string id)
        {
            byte[] key = Encoding.UTF8.GetBytes(Constants.CONSTANT_MILOENCRYPTKEY);
            byte[] text = Encoding.UTF8.GetBytes(id);

            byte[] encodedString = xorWithKey(text, key);
            return Convert.ToBase64String(encodedString);
        }

        public static string GetMD5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash. 
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes and create a string. 
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data and format each one as a hexadecimal string. 
                for (int i = 0; i < (data.Length); i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Function to decrypt values
        /// </summary>
        /// <param name="cipherText">Encrypted Text</param>
        /// <returns>Returns decrypted text value</returns>
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = Constants.CONSTANT_DECRYPTKEY;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        #region Get IMS Tokens
        /// <summary>
        /// Checks existing IMS Token's expiry date and returns it if valid. Otherwise, generates new IMS Token using Refresh Token or by using Client ID and Code. Creates/Updates CRM IMS Token record with IMS Token, Refresh Token and IMS Token Expiry DateTime.
        /// </summary>
        /// <returns></returns>
        public static string GetIMSToken()
        {
            try
            {
                #region Connect D365
                //Connect D365
                var organizationUrl = "https://adobe-sbx16.crm.dynamics.com/";
                string api = "https://adobe-sbx16.api.crm.dynamics.com/api/data/v9.2/";
                AuthenticationParameters ap = AuthenticationParameters.CreateFromResourceUrlAsync(new Uri(api)).Result;
                var creds = new ClientCredential("a94f6256-a141-4dba-a3bf-f5632d37182a", "Ndq7Q~YCOLdP5xZXVkT3tmZLdZJQK7gv0umpo"); //Non Prod App User
                AuthenticationContext authContext = new AuthenticationContext(ap.Authority);
                var token = authContext.AcquireTokenAsync(ap.Resource, creds).Result.AccessToken;
                var service = new OrganizationWebProxyClient(GetServiceUrl(organizationUrl), false);

                using (service)
                {
                    service.HeaderToken = token;
                    var request = new OrganizationRequest()
                    {
                        RequestName = "WhoAmI"
                    };
                    var response = service.Execute(new WhoAmIRequest()) as WhoAmIResponse;
                }
                #endregion

                Utility utility = new Utility();
                string clientId, clientSecret, code, imsEndpointUrl = string.Empty;
                Dictionary<string, string> systemSettings;
                Token imsToken = null;
                Entity imsrecord = null;

                #region Get Existing Non-Expired Token
                // Try and retreive any existing IMS token records.

                QueryExpression query = new QueryExpression(Constants.ENTITY_IMSTOKEN);
                query.TopCount = 1;
                query.ColumnSet = new ColumnSet(new string[] { EntityAttributes.IMSTOKEN_ATTR_EXPIRESON, EntityAttributes.IMSTOKEN_ATTR_ACCESSTOKEN,
                                                               EntityAttributes.IMSTOKEN_ATTR_REFRESHTOKEN, EntityAttributes.COMMON_ATTR_MODIFIEDON });
                query.Orders.Add(new OrderExpression(EntityAttributes.COMMON_ATTR_MODIFIEDON, OrderType.Descending));
                var ImsTokenRecords = service.RetrieveMultiple(query);

                #endregion

                if ((ImsTokenRecords != null) && (ImsTokenRecords.Entities != null) && (ImsTokenRecords.Entities.Count > 0))
                {
                    imsrecord = ImsTokenRecords.Entities[0];
                }
                // If atleast one "IMS Token" record is present
                if (imsrecord != null)
                { 
                    //  Check if the CRM "IMS Token" entity has an access token that has not expired.
                    DateTime expiresOn = imsrecord.GetAttributeValue<DateTime>(EntityAttributes.IMSTOKEN_ATTR_EXPIRESON);
                    if (expiresOn.ToUniversalTime() > DateTime.UtcNow)
                    {
                        string existingIMSToken = imsrecord.GetAttributeValue<string>(EntityAttributes.IMSTOKEN_ATTR_ACCESSTOKEN);
                        if (!string.IsNullOrWhiteSpace(existingIMSToken))
                        {
                            return existingIMSToken;
                        }
                    }

                    #region Refresh Token Call
                    //  Retrieve the IMS System Settings necessary.
                    
                    EntityCollection sysSettingsCol = ConfigurationHelper.Instance.GetSettingsByGroup(Constants.CONSTANT_IMSGROUP, service);
                    systemSettings = new Dictionary<string, string>();
                    if (sysSettingsCol.Entities.Count > 0)
                    {
                        systemSettings = sysSettingsCol.Entities.ToDictionary(k => k.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_KEY), v => v.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_LONGVALUE));
                    }
                    clientId = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_CLIENTID];
                    clientSecret = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_CLIENTSECRETE];
                    clientSecret = Decrypt(clientSecret);
                    code = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_CODE];
                    imsEndpointUrl = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_TOKENENDPOINT];
                    string refreshToken = imsrecord.GetAttributeValue<string>(EntityAttributes.IMSTOKEN_ATTR_REFRESHTOKEN);

                    if (!string.IsNullOrWhiteSpace(refreshToken))
                    {
                        
                        string EndpointUrl = imsEndpointUrl + "grant_type=refresh_token&refresh_token=" + refreshToken + "&client_id=" + clientId + "&client_secret=" + clientSecret;

                        WebRequestResponse response = MakeHttpWebRequest(EndpointUrl, string.Empty, Constants.CONSTANT_REQUESTMETHODPOST, null, service,  "text/json");

                        if (response.isSuccess)
                        {
                            imsToken = JsonHelper.JsonDeserialize<Token>(response.response);
                        }
                        else
                        {
                            
                            imsToken = utility.GenerateNewToken(imsEndpointUrl, code, clientSecret, clientId, service);
                        }
                    }
                    else
                    {
                       
                        imsToken = utility.GenerateNewToken(imsEndpointUrl, code, clientSecret, clientId, service);
                    }

                    #endregion
                }
                else
                {
                    // If No IMS Token records exist, then create a new one.
                    
                    //  Retrieve the IMS System Settings necessary.
                    
                    EntityCollection sysSettingsCol = ConfigurationHelper.Instance.GetSettingsByGroup(Constants.CONSTANT_IMSGROUP, service);
                    systemSettings = new Dictionary<string, string>();
                    if (sysSettingsCol.Entities.Count > 0)
                    {
                        systemSettings = sysSettingsCol.Entities.ToDictionary(k => k.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_KEY), v => v.GetAttributeValue<string>(EntityAttributes.SYSTEMSETTINGS_ATTR_LONGVALUE));
                    }
                    clientId = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_CLIENTID];
                    clientSecret = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_CLIENTSECRETE];
                    clientSecret = Utility.Decrypt(clientSecret);
                    code = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_CODE];
                    imsEndpointUrl = systemSettings[EntityAttributes.SYSTEMSETTINGS_DATA_TOKENENDPOINT];
                    //Generate New IMS Token
                    imsToken = utility.GenerateNewToken(imsEndpointUrl, code, clientSecret, clientId, service);
                }

                return utility.UpsertIMSToken(imsToken, imsrecord, service);
            }
            catch (WebRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("error occured while getting IMS Token" + ex.Message);
            }
            finally
            {
                
            }
        }
        static private Uri GetServiceUrl(string organizationUrl)
        {
            return new Uri(organizationUrl + @"/XRMServices/2011/Organization.svc/web?SdkClientVersion=9.1");
        }

        /// <summary>
        /// Generates new IMS Token based on Client ID, Secret and Code.
        /// </summary>
        /// <param name="imsEndpointUrl"></param>
        /// <param name="Code"></param>
        /// <param name="clientSecret"></param>
        /// <param name="clientId"></param>
        /// <param name="service"></param>
        /// <param name="tracingService"></param>
        /// <returns></returns>
        private Token GenerateNewToken(string imsEndpointUrl, string Code, string clientSecret, string clientId, IOrganizationService service)
        {
            
            // If no records exist for "IMS Token" then execute IMS request to retreive an Access Token.                   
            string EndpointUrl = imsEndpointUrl + "code=" + Code + "&client_secret=" + clientSecret + "&grant_type=authorization_code" + "&client_id=" + clientId;

            WebRequestResponse response = MakeHttpWebRequest(EndpointUrl, string.Empty, Constants.CONSTANT_REQUESTMETHODPOST, null, service,  "text/json");

            if (response.isSuccess)
            {
                Token TokenDetails = new Token();
                TokenDetails = JsonHelper.JsonDeserialize<Token>(response.response);
                return TokenDetails;
            }
            else
            {
                
                throw response.exception;
            }
        }

        /// <summary>
        /// Creates or Updates IMS Token entity record with new IMS Token details. Returns IMS Token from IMS Token JSON response.
        /// </summary>
        /// <param name="imsToken"></param>
        /// <param name="imsRecord"></param>
        /// <param name="service"></param>
        /// <param name="tracingService"></param>
        /// <returns></returns>
        private string UpsertIMSToken(Token imsToken, Entity imsRecord, IOrganizationService service)
        {
            if (imsToken == null)
            {
                return string.Empty;
            }
            Entity imsTokenEntity = new Entity(Constants.ENTITY_IMSTOKEN);
            imsTokenEntity.Attributes[EntityAttributes.IMSTOKEN_ATTR_ACCESSTOKEN] = imsToken.access_token;
            imsTokenEntity.Attributes[EntityAttributes.IMSTOKEN_ATTR_REFRESHTOKEN] = imsToken.refresh_token;
            imsTokenEntity.Attributes[EntityAttributes.IMSTOKEN_ATTR_EXPIRESON] = DateTime.UtcNow.AddMilliseconds(imsToken.expires_in);
            
            if (imsRecord != null && imsRecord.Id != Guid.Empty)
            {
                imsTokenEntity.Id = imsRecord.Id;
                service.Update(imsTokenEntity);
                
            }
            else
            {
                service.Create(imsTokenEntity);
                
            }
            return imsToken?.access_token;
        }

        #endregion

        #region Make Web Request

        public static WebRequestResponse MakeHttpWebRequest(string url, string data, string requestMethod, Dictionary<string, string> headers, IOrganizationService orgService,  string contentType = Constants.CONSTANT_CONTENTTYPE_JSON)
        {
            
            if (fakeAPIResponses?.Count > 0)
            {
                
                return GetFakeAPIResponse(url, data);
            }
            
            string response = string.Empty;
            bool isSuccess = false;
            HttpStatusCode statusCode = default(HttpStatusCode);
            Exception exception = null;

            try
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.ConnectionClose = true;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.CONSTANT_CONTENTTYPE_JSON));

                byte[] requestInFormOfBytes = System.Text.Encoding.UTF8.GetBytes(data);
                HttpContent content = new StringContent(data, Encoding.UTF8, contentType);

                if (contentType == "application/x-www-form-urlencoded")
                {
                    requestInFormOfBytes = System.Text.Encoding.ASCII.GetBytes(data);
                    content = new StringContent(data, Encoding.ASCII, contentType);
                }
                content.Headers.ContentLength = requestInFormOfBytes.Length;

                // Add all the Header information
                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                        client.DefaultRequestHeaders.Add(key, headers[key]);
                }

                //tracingService.Trace("Web API Call to {0} Initiated at: {1}", url, DateTime.Now);
                

                //output task: will block the current thread and it will act as a blocking call to the external systems which will fulfill the need for callback methods.
                Task<HttpResponseMessage> result = null;

                // Write the request body for different request methods
                switch (requestMethod)
                {
                    case Constants.CONSTANT_REQUESTMETHODPOST:
                        result = client.PostAsync(new Uri(url), content);
                        break;

                    case Constants.CONSTANT_REQUESTMETHODGET:
                        result = client.GetAsync(url);
                        break;

                    case Constants.CONSTANT_REQUESTMETHODDELETE:
                        result = client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, new Uri(url))
                        {
                            Content = new StringContent(data, Encoding.UTF8, Constants.CONSTANT_CONTENTTYPE_JSON)
                        });
                        break;
                }

                // Try and retrieve the Response
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

            catch (WebException ex)
            {
                exception = ex;
                
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    
                }
               
                foreach (var key in ex.Response.Headers.AllKeys)
                {
                    
                }

            }
            catch (Exception ex)
            {
                exception = ex;
                
            }
            finally
            {
                
            }

            WebRequestResponse webRequestResponse = new WebRequestResponse(response, isSuccess, statusCode, exception);

            return webRequestResponse;

        }

        public static WebRequestResponse MakeHttpWebRequest(string url, MultipartFormDataContent form, string requestMethod, Dictionary<string, string> headers, IOrganizationService service, ITracingService tracingService, string contentType)
        {
            tracingService.Trace("Executing MakeHttpWebRequest ");
            string response = string.Empty;
            bool isSuccess = false;
            HttpStatusCode statusCode = default(HttpStatusCode);
            Exception exception = null;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.ConnectionClose = true;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.CONSTANT_CONTENTTYPE_JSON));

                // Add all the Header information
                if (headers != null)
                {
                    foreach (string key in headers.Keys)
                        client.DefaultRequestHeaders.Add(key, headers[key]);
                }

                tracingService.Trace("Web API Call intiated at: {0}", DateTime.Now);

                //output task: will block the current thread and it will act as a blocking call to the external systems which will fulfill the need for callback methods.
                Task<HttpResponseMessage> result = null;
                // Write the request body for different request methods
                switch (requestMethod)
                {
                    case Constants.CONSTANT_REQUESTMETHODPOST:
                        result = client.PostAsync(new Uri(url), form);
                        break;

                    case Constants.CONSTANT_REQUESTMETHODGET:
                        result = client.GetAsync(url);
                        break;

                    case Constants.CONSTANT_REQUESTMETHODDELETE:
                        result = client.DeleteAsync(url);
                        break;
                }

                // Try and retrieve the Response
                if (result.Result.IsSuccessStatusCode)
                {
                    var responseContent = result.Result.Content;
                    if (responseContent is object)
                    {
                        if ((result.Result.RequestMessage.Method.ToString().Equals(Constants.CONSTANT_REQUESTMETHODGET)) &&
                            (responseContent.Headers.Contains("Content-Disposition")))
                        {
                            byte[] responseStream = responseContent.ReadAsByteArrayAsync().Result;
                            if (responseStream != null)
                            {
                                response = Convert.ToBase64String(responseStream);
                                isSuccess = true;
                                statusCode = result.Result.StatusCode;
                            }
                        }
                        else
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
                }
                else
                {
                    statusCode = result.Result.StatusCode;
                    exception = new WebRequestException("Error in MakeWebRequest", result.Result.StatusCode, new Exception($"{result.Result}"));
                    tracingService.Trace("Error -> {0}", result.Result);
                    result.Result.Dispose();
                }
            }

            catch (WebException ex)
            {
                exception = ex;
                tracingService.Trace("-----Reading Error Response Stream-----");
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    tracingService.Trace("Error Response Stream: {0}", reader.ReadToEnd());
                }
                tracingService.Trace("-----Error Response Header Info-----");
                foreach (var key in ex.Response.Headers.AllKeys)
                {
                    tracingService.Trace("Key: {0} - Value: {1}", key, ex.Response.Headers[key]);
                }

            }
            catch (Exception ex)
            {
                exception = ex;
                tracingService.Trace("Error in MakeWebRequest -> {0}", ex.Message);
            }
            finally
            {
                tracingService.Trace("Web API Call Completed at: {0}", DateTime.Now);
            }

            WebRequestResponse webRequestResponse = new WebRequestResponse(response, isSuccess, statusCode, exception);

            return webRequestResponse;
        }

        #endregion

        /// <summary>
        /// Convert Dictionary to POST String
        /// </summary>
        /// <param name="postVariables"></param>
        /// <returns></returns>
        public static string DictionaryToPostString(Dictionary<string, string> postVariables)
        {
            string postString = "";
            foreach (KeyValuePair<string, string> pair in postVariables)
            {
                postString += System.Uri.EscapeDataString(pair.Key) + "=" +
                    System.Uri.EscapeDataString(pair.Value) + "&";
            }

            return postString;
        }

        /// <summary>
        /// Returns fake response based on URL and request body
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="tracingService"></param>
        /// <returns></returns>
        public static WebRequestResponse GetFakeAPIResponse(string url, string data)
        {
            try
            {
                var matchedAPIResponses = fakeAPIResponses?.FindAll(f => f.endPoint == url);
                if (matchedAPIResponses?.Count > 0)
                {
                    if (matchedAPIResponses.Count == 1)
                    {
                        return fakeAPIResponses[0].webRequestResponse;
                    }
                    else if (!string.IsNullOrWhiteSpace(data))
                    {
                        //find matching by searching for specified key data parameter
                        matchedAPIResponses = fakeAPIResponses?.FindAll(f => f.endPoint == url && data.Contains(f.data));
                        return matchedAPIResponses != null ? matchedAPIResponses[0].webRequestResponse : null;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }
    }
}