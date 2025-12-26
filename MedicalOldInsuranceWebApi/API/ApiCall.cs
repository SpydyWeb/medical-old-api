using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using InsuranceAPIs.Models.Configuration_Objects;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using InsuranceAPIs.Logger;
using System.Security.Policy;
using Domain.Models;

namespace InsuranceAPIs.API
{
    public class ApiCall
    {
        #region ApiCall
        public static T ExcutePostAPI<T>(object request, string apiMethod, string apiUrl, string token = null, string authType = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
            try
            {
                using (var client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add(string.IsNullOrEmpty(authType) ? "oAuth" : authType, token);
                    }
                    client.BaseAddress = new Uri(apiUrl);
                    client.Timeout = TimeSpan.FromSeconds(5000);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string obj = JsonConvert.SerializeObject(request);
                    //var responseMessage = client.PostAsJsonAsync("User/UserAuthentication", (object)loginRequest).Result;
                    var responseMessage = client.PostAsJsonAsync(apiMethod, request).Result;

                    string res = responseMessage.Content.ReadAsStringAsync().Result.Trim();
                    ErrorHandler.APIWriteLog("API", apiUrl + apiMethod, JsonConvert.SerializeObject(request), JsonConvert.SerializeObject(Deserilize<T>(res)));
                    return Deserilize<T>(res);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.APIWriteError(ex, apiUrl + apiMethod, JsonConvert.SerializeObject(request), "API");
                //throw;
                return Deserilize<T>("");
            }
        }

        public static T Deserilize<T>(string json)
        {
            try
            {
                T resultValue = JsonConvert.DeserializeObject<T>(json);

                return (T)Convert.ChangeType(resultValue, typeof(T));
            }
            catch (Exception)
            {
                JObject jsonObject = JObject.Parse(json);
                //var abc = JsonConvert.DeserializeObject(json);
                JArray jsonArray = new JArray(jsonObject);
                string jsonArrayString = jsonArray.ToString(Formatting.None);
                return JsonConvert.DeserializeObject<T>(jsonArrayString);
            }

        }
        #endregion


        public static T ExecuteGetApi<T>(string request, string apiUrl, string token = null)
        {

            //apiLink = apiUrl;
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("ApiKey", token);
                }

                string messageUrlParams = "?" + request;

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(messageUrlParams).Result;
                ErrorHandler.APIWriteLog("API", apiUrl, JsonConvert.SerializeObject(request), JsonConvert.SerializeObject(Deserilize<T>(response.Content.ReadAsStringAsync().Result)));
                return Deserialize<T>(response.Content.ReadAsStringAsync().Result);
            }
        }

        private static T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                JObject jsonObject = JObject.Parse(json);
                //var abc = JsonConvert.DeserializeObject(json);
                JArray jsonArray = new JArray(jsonObject);
                string jsonArrayString = jsonArray.ToString(Formatting.None);
                return JsonConvert.DeserializeObject<T>(jsonArrayString);
            }

        }

        //public static T ExecuteDeleteAPI<T>(object request, string apiLink)
        //{
        //    HttpClient client = new HttpClient();
        //    client.Timeout = TimeSpan.FromSeconds(300);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    string jsonContent = JsonConvert.SerializeObject(request);

        //    apiLink = ConfigurationManager.AppSettings["ApiURL"].ToString() + apiLink;

        //    HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Delete, apiLink)
        //    {
        //        Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
        //    };

        //    HttpResponseMessage resultAll = client.SendAsync(webRequest).Result; // Use SendAsync instead of Send
        //    resultAll.EnsureSuccessStatusCode(); // Ensure the request was successful

        //    string res = resultAll.Content.ReadAsStringAsync().Result.Trim();
        //    //ErrorHandler.APIWriteLog("API", ConfigurationManager.AppSettings["ApiURL"].ToString() + apiLink, JsonConvert.SerializeObject(request), JsonConvert.SerializeObject(Deserilize<T>(resultAll.Content.ReadAsStringAsync().Result)));
        //    return Deserilize<T>(res);

        //}     

        public static T ExcuteGetAPISME<T>(string request, string apiUrl, string apimethod, string token = null, string authType = null)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13; ;
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

                string apiLink = apiUrl + apimethod;
                string messageUrlParams = "";
                using (HttpClient client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add(authType, token);
                    }
                    switch (apimethod)
                    {
                        case "GenerateToken":
                            client.DefaultRequestHeaders.Add("KeyValue", request);
                            break;
                        case "GetCRCalimRatio":
                            client.DefaultRequestHeaders.Add("PolichiHolderId", request);
                            break;
                        case "Policy/Delete":
                            apiLink = apiLink + request;
                            break;
                        default:
                            messageUrlParams = request;
                            break;
                    }
                    //string sendObj = JsonConvert.SerializeObject(request);
                    //string obj = Helpers.Encrypt(JsonConvert.SerializeObject(request)).Replace("+", "_");

                    client.BaseAddress = new Uri(apiLink);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync(messageUrlParams).Result;
                    ErrorHandler.APIWriteLog("API", apiLink, messageUrlParams, JsonConvert.SerializeObject(Deserilize<T>(response.Content.ReadAsStringAsync().Result)));
                    return Deserialize<T>(response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.APIWriteError(ex, apiUrl + apimethod, JsonConvert.SerializeObject(request), apimethod);
                //throw;
                return Deserilize<T>("");
            }
        }

        public static T ExcutePentaAPI<T>(object requestData, string apiMethod, string apiUrl, string tokenUrl, string username, string password)
        {
            try
            {
                string token = "";
                var tokenRequest = new PentaTokenRequest
                {
                    username = username,
                    password = password
                };

                using (var client = new HttpClient())
                {
                    // Get Token
                    var tokenContent = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");

                    var tokenResponse = client.PostAsync(tokenUrl, tokenContent).Result;
                    var tokenResponseBody = tokenResponse.Content.ReadAsStringAsync().Result;

                    if (!tokenResponse.IsSuccessStatusCode)
                        throw new Exception("Token API failed: " + tokenResponseBody);

                    var tokenObj = JsonConvert.DeserializeObject<PentatokenResponse>(tokenResponseBody);
                    token = tokenObj?.access_token;

                    if (string.IsNullOrEmpty(token))
                        throw new Exception("Token is empty");

                    // Main API call
                    using (var apiClient = new HttpClient())
                    {
                        string apiFullUrl = apiUrl + apiMethod;

                        apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        var apiContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                        var apiResponse = apiClient.PostAsync(apiFullUrl, apiContent).Result;
                        var apiResponseBody = apiResponse.Content.ReadAsStringAsync().Result;

                        if (!apiResponse.IsSuccessStatusCode)
                            throw new Exception("API returned error: " + apiResponseBody);

                        return JsonConvert.DeserializeObject<T>(apiResponseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExcutePentaAPI failed: " + ex.Message, ex);
            }
        }
    }
}
