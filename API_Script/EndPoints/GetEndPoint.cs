using API_Script.Helper;
using API_Script.JsonResponse;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Script.EndPoints
{
    
    public class GetEndPoint
    {

        private string getDemoUrl = "https://www.cheapoair.com/profiles/api/v1/loyalty";
        [Test]
        public void GetDemo()
        {



            //Create the client
            IRestClient restClient = new RestClient();
            //create and execute the Get Request
            IRestRequest restRequest = new RestRequest(getDemoUrl);
            //Pass the header in request
            restRequest.AddHeader("X-SessionToken", "71339fc1f78b480e8669095c5bb67580");
            restRequest.AddHeader("Content-Type", "application/xml");
            restClient.Get(restRequest);
            //jsonresponse 
            IRestResponse<List<JsonResponseObject>> restResponseJson = restClient.Get<List<JsonResponseObject>>(restRequest);
            Console.WriteLine(restResponseJson.Data.Count);
            Console.WriteLine(restResponseJson.Content);
            Console.WriteLine(restResponseJson.Cookies[0].Domain);
            List<JsonResponseObject> data = restResponseJson.Data;
            //JsonResposeObject js = data.
            // //   Find((x) =>
            // //x.ActivePoints == 500
            //);

            foreach (var item in restResponseJson.Data)
            {
                Assert.AreEqual(500, item.ActivePoints);
            }

            foreach (var item in data)
            {
                Assert.AreEqual(500, item.ActivePoints);
                Assert.AreEqual(500, item.PointsUntilReward);
            }



            //Extract the response
            IRestResponse restResponse = restClient.Get(restRequest);
            Console.WriteLine((int)restResponse.StatusCode);
            Console.WriteLine(restResponse.IsSuccessful);
            Console.WriteLine(restResponse.Content);
            Console.WriteLine(restResponse.ErrorMessage);
            Console.WriteLine(restResponse.Cookies[1].Name);

            Assert.AreEqual(200, (int)restResponse.StatusCode);
        }

        [Test]
      
        public void newAPIGetMethods()
        {

            IRestClient restClient = new RestClient();
            //create and execute the Get Request
            IRestRequest restRequest = new RestRequest()
            {
                Method = Method.GET,
                Resource = getDemoUrl

            };
            restRequest.AddHeader("Content-Type", "application/xml");
            restRequest.AddHeader("X-SessionToken", "71339fc1f78b480e8669095c5bb67580");
            IRestResponse<List<JsonResponseObject>> restResponseJson = restClient.Get<List<JsonResponseObject>>(restRequest);
            Assert.AreEqual(200, (int)restResponseJson.StatusCode);
            Console.WriteLine(restResponseJson.Content);

        }

        [Test]
        public void TestGetWithUsingHelpClass()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                { "X-SessionToken", "71339fc1f78b480e8669095c5bb67580"},
                { "Content-Type", "application/json"}
            };



            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformGetRequest(getDemoUrl, header);
            IRestResponse<JsonResponseObject> restResponse1 = restClientHelper.PerformGetRequest<JsonResponseObject>(getDemoUrl, header);

            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.AreEqual(500, restResponse1.Data.ActivePoints);



        }
    }
}
