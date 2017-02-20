using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    /// <summary>
    /// Class for handling generic HTTP API interactions
    /// </summary>
    public class Http
    {
        /// <summary>
        /// Connection timeout in milliseconds
        /// </summary>
        private const int ConnectionTimeout = 61000;

        /// <summary>
        /// JSON header value
        /// </summary>
        private const string ApplicationJson = "application/json";

        /// <summary>
        /// Service key
        /// </summary>
        private readonly string _serviceKey;

        /// <summary>
        /// Authenticated
        /// </summary>
        private readonly bool _authenticated;

        /// <summary>
        /// Constructor
        /// </summary>
        public Http()
        {
            _authenticated = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceKey">The authorization key for the service</param>
        public Http(string serviceKey)
        {
            _serviceKey = serviceKey;
            _authenticated = true;
        }

        /// <summary>
        /// Perform a GET request
        /// </summary>
        internal TO Get<TO>(string api)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Get, null, _authenticated);
            return SendRequest<TO>(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        internal void Post(string api, object item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Post, item, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Perform a PUT request
        /// </summary>
        internal void Put(string api, object item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Put, item, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        internal TO Post<TI, TO>(string api, TI item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Post, item, _authenticated);
            return SendRequest<TO>(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        internal TO Put<TI, TO>(string api, TI item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Put, item, _authenticated);
            return SendRequest<TO>(request);
        }

        /// <summary>
        /// Perform a DELETE request
        /// </summary>
        public void Delete(string api)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Delete, null, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Handle an incoming request
        /// </summary>
        /// <typeparam name="TO"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public TO HandleRequest<TO>(HttpRequest request)
        {
            if (request.HttpMethod != "POST")
            {
                throw new WorldpayException("Invalid request");
            }

            return HandleResponse<TO>(request.InputStream);
        }

        #region helpers

        private HttpWebRequest CreateRequest(string api, RequestMethod method, object data, bool authorize)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(api);
            request.Accept = ApplicationJson;
            request.Timeout = ConnectionTimeout;

            switch (method)
            {
                case RequestMethod.Get:
                    request.Method = WebRequestMethods.Http.Get;
                    break;
                case RequestMethod.Post:
                    request.Method = WebRequestMethods.Http.Post;
                    break;
                case RequestMethod.Put:
                    request.Method = WebRequestMethods.Http.Put;
                    break;
                case RequestMethod.Delete:
                    request.Method = "DELETE";
                    break;
                default:
                    throw new NotSupportedException(String.Format("Request method {0} not supported", method.ToString()));
            }

            if (authorize)
            {
                request.Headers.Add(HttpRequestHeader.Authorization, _serviceKey);
            }

            try
            {
                if (data != null)
                {
                    request.ContentType = ApplicationJson;
                    string serializedData = JsonConvert.SerializeObject(data);
                    byte[] bytes = Encoding.UTF8.GetBytes(serializedData);
                    request.ContentLength = bytes.Length;

                    using (Stream outputStream = request.GetRequestStream())
                    {
                        outputStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (WebException exc)
            {               
                throw new WebException("Error with request " + request.RequestUri, exc);
            }

            return request;
        }

        private void SendRequest(HttpWebRequest request)
        {
            try
            {
                using (var response = request.GetResponse())
                {
                    // NO action to take
                }
            }
            catch (WebException exc)
            {
                HandleError(exc);
            }
        }

        private T SendRequest<T>(HttpWebRequest request)
        {
            try
            {
                using (var response = request.GetResponse())
                {
                    return HandleResponse<T>(response.GetResponseStream());
                }
            }
            catch (WebException exc)
            {
                HandleError(exc);
                return default(T);
            }
        }

        private T HandleResponse<T>(Stream responseStream)
        {
            using (var reader = new StreamReader(responseStream))
            {
                var serializer = new JsonSerializer();
                serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
                return (T)serializer.Deserialize(new JsonTextReader(reader), typeof(T));
            }
        }

        private void HandleError(WebException exc)
        {
            using (var reader = new StreamReader(exc.Response.GetResponseStream()))
            {
                ApiError error = null;
                try
                {
                    string content = reader.ReadToEnd();
                    error = JsonConvert.DeserializeObject<ApiError>(content);
                }
                catch (Exception)
                {
                    throw exc;
                }
                throw new WorldpayException(error, "API error: " + error.message);
            }
        }

        #endregion

    }
}
