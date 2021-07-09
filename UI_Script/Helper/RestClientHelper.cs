using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Script.Helper
{
   public class RestClientHelper
    {
        public IRestClient GetRestClient()
        {
            IRestClient restClient = new RestClient();
            return restClient;
        }

        public IRestRequest GetRestRequest(string url, Dictionary<string, string> header, Method method, Object body, DataFormat dataFormat)
        {
            IRestRequest restRequest = new RestRequest()
            {
                Method = method,
                Resource = url
            };

            foreach (var key in header.Keys)
            {
                restRequest.AddHeader(key, header[key]);
            }
            if (body != null)
            {
                //restRequest.RequestFormat = dataFormat;
                restRequest.AddJsonBody(body);

            }

            return restRequest;
        }

        public IRestResponse SendRequest(IRestRequest restRequest)
        {
            IRestClient restClient = GetRestClient();
            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public IRestResponse<T> SendRequest<T>(IRestRequest restRequest) where T : new()
        {
            IRestClient restClient = GetRestClient();
            IRestResponse<T> restResponse = restClient.Execute<T>(restRequest);

            if (restResponse.ContentType.Equals("application/xml"))
            {
                var deserilization = new RestSharp.Deserializers.DotNetXmlDeserializer();
                restResponse.Data = deserilization.Deserialize<T>(restResponse);
            }

            return restResponse;
        }

        public IRestResponse PerformGetRequest(string url, Dictionary<string, string> header)
        {
            IRestRequest restRequest = GetRestRequest(url, header, Method.GET, null, DataFormat.None);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }
        public IRestResponse<T> PerformGetRequest<T>(string url, Dictionary<string, string> header) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, header, Method.GET, null, DataFormat.None);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }


        public IRestResponse<T> PerformPostRequest<T>(string url, Dictionary<string, string> header, object body, DataFormat dataFormat) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, header, Method.POST, body, dataFormat);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }

        public IRestResponse PerformPostRequest(string url, Dictionary<string, string> header, object body, DataFormat dataFormat)
        {
            IRestRequest restRequest = GetRestRequest(url, header, Method.POST, body, dataFormat);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }
    }
}
