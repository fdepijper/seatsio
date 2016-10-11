using Newtonsoft.Json.Linq;
using PinEvents.SeatsIo.Data;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace PinEvents.SeatsIo
{
    class Connect
    {
        public string Version;
        public string Data;

        private Uri _baseUri;
        private const string MediaType = "application/json";
        public enum Methods
        {
            GET, POST, PATCH, DELETE
        }

        public Connect()
        {
            ConnectData.GetConnectData();
            _baseUri = new Uri(ConnectData.BaseUri);
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }

        public HttpResponseMessage RequestArray(Methods method, string endpoint, JArray data, bool isZipped = false)
        {
            var content = new StringContent(data.ToString(), Encoding.UTF8, MediaType);
            return Request(method, endpoint, content, isZipped);
        }

        public HttpResponseMessage Request(Methods method, string endpoint, JObject data, bool isZipped = false)
        {
            StringContent content = null;
            if (data != null)
                content = new StringContent(data.ToString(), Encoding.UTF8, MediaType);
            return Request(method, endpoint, content, isZipped);
        }

        private HttpResponseMessage Request(Methods method, string endpoint, StringContent data, bool isZipped = false)
        {
            endpoint = _baseUri + endpoint;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint);
            //requestMessage.Headers.Add("Authorization", "Bearer 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");
            //requestMessage.Headers.Add("Authorization", String.Format("Bearer {0}", ConnectData.ApiKey));
            Stream receiveStream;
            StreamReader readStream;
            StringContent content;
            HttpResponseMessage response;
            HttpClientHandler handler = new HttpClientHandler();

            try
            {
                switch (method)
                {
                    case Methods.GET:
                        using (HttpClient client = new HttpClient(handler))
                        {
                            if (isZipped)
                                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                            response = client.SendAsync(requestMessage).Result;
                            receiveStream = response.Content.ReadAsStreamAsync().Result;
                            readStream = new StreamReader(receiveStream, Encoding.UTF8);
                            Data = readStream.ReadToEnd();
                            return response;
                        }
                    case Methods.POST:
                        using (HttpClient client = new HttpClient())
                        {
                            content = data;
                            requestMessage.Method = HttpMethod.Post;
                            if (isZipped)
                                requestMessage.Headers.Add("Accept-Encoding", "gzip,deflate");
                            requestMessage.Content = content;
                            response = client.SendAsync(requestMessage).Result;
                            response.EnsureSuccessStatusCode();
                            receiveStream = response.Content.ReadAsStreamAsync().Result;
                            readStream = new StreamReader(receiveStream, Encoding.UTF8);
                            Data = readStream.ReadToEnd();
                            return response;
                        }
                    case Methods.PATCH:
                        if (isZipped)
                            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                        
                        using (HttpClient client = new HttpClient(handler))
                        {
                            content = data;
                            requestMessage.Method = new HttpMethod("PATCH");
                            if (isZipped)
                                requestMessage.Headers.Add("Accept-Encoding", "gzip,deflate");
                            requestMessage.Content = content;
                            response = client.SendAsync(requestMessage).Result;
                            response.EnsureSuccessStatusCode();
                            receiveStream = response.Content.ReadAsStreamAsync().Result;
                            readStream = new StreamReader(receiveStream, Encoding.UTF8);
                            Data = readStream.ReadToEnd();
                            return response;
                        }
                    case Methods.DELETE:
                        using (HttpClient client = new HttpClient())
                        {
                            return client.DeleteAsync(endpoint).Result;
                        }
                    default:
                        using (HttpClient client = new HttpClient())
                        {
                            response = new HttpResponseMessage();
                            response.StatusCode = HttpStatusCode.MethodNotAllowed;
                            var message = "{\"errors\":[{\"message\":\"Bad method call, supported methods are GET, POST, PATCH and DELETE\"}]}";
                            response.Content = new StringContent(message);
                            return response;
                        }
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage();
                string message;
                message = (ex is HttpRequestException) ? ".NET HttpRequestException" : ".NET Exception";
                message = message + ", raw message: \n\n";
                response.Content = new StringContent(message + ex.Message);
                throw ex;
            }
        }
    }
}
