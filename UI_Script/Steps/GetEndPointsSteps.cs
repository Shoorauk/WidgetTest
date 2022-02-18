using API_Script.Helper;
using API_Script.JsonResponse;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UI_Script.Hook;

namespace API_Script.Steps
{
    [Binding]
    public sealed class GetEndPointsSteps
    {
    
       Dictionary<string, string> _header = new Dictionary<string, string>();
        RestClientHelper _restClientHelper = new RestClientHelper();
        IRestResponse<JsonResponseObject> restResponse { get; set; }

        [Given(@"Get ready all the data")]
        public void GivenGetReadyAllTheData()
        {
            Console.WriteLine("get request start");
        }

        [When(@"execute the get api")]
        public void WhenExecuteTheGetApi(Table table)
        {
            var readValue = Hooks1.templateConfigurations.Mapping.FirstOrDefault(x => x.EndPointRequest.Equals("UPLAND"));
            dynamic data = table.CreateDynamicInstance();
            // _header.Add(Hooks1.configSetting.SessionKey, Hooks1.configSetting.SessionValue);

            _header.Add(readValue.Map.FirstOrDefault().Header.SessionKey, readValue.Map.FirstOrDefault().Header.SessionValue);
           
            restResponse = _restClientHelper.PerformGetRequest<JsonResponseObject>(data.GetUrl, _header);
        }

        [Then(@"Verify the activation point")]
        public void ThenVerifyTheActivationPoint(Table table)
        {
            Assert.AreEqual(500, restResponse.Data.ActivePoints);
        }

        [Then(@"(.*) status code")]
        public void ThenStatusCode(int p0)
        {
            Assert.AreEqual(p0, (int)restResponse.StatusCode);
        }


       

       

    }
}
