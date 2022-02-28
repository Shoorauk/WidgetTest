using API_Script.Helper;
using API_Script.JsonResponse;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using UI_Script.Hook;

namespace UI_Script.Steps
{
    [Binding]
    public sealed class PostEndPointSteps
    {
        Dictionary<string, string> _header = new Dictionary<string, string>();
        RestClientHelper _restClientHelper = new RestClientHelper();
        
        IRestResponse<PostRequestBody> restResponse { get; set; }

        

        [When(@"Execute the post API")]
        public void WhenExecuteThePostAPI(Table table)
        {
            dynamic data = table.CreateDynamicInstance();          

            _header.Add(Hooks1.configSetting.SessionKey, Hooks1.configSetting.SessionValue);
            restResponse = _restClientHelper.PerformPostRequest<PostRequestBody>(data.PostURL, _header, new PostRequestBody() { FirstName = "Oscar", MiddleName = "Cano", LastName = "Test", Title = "1", TSARedress = "XYZ", PassportIssuingCountryCode = "US", Gender = "1", DOB = "01/01/1982" }, DataFormat.Json);



        }

        [Then(@"Status should be (.*)")]
        public void ThenStatusShouldBe(int p0)
        {
            Assert.AreEqual(p0, (int)restResponse.StatusCode);

            JArray jArray = JArray.Parse(restResponse.Content);
            foreach (var item in jArray.Children<JObject>())
            {
                foreach (JProperty property in item.Properties())
                {
                    if (property.Value.ToString() == "Oscar")
                    {
                        Assert.Pass("Response First name is match");
                    }
                    else
                    {
                        Assert.Fail("First name is not match");
                    }
                   
                }

            }
        }





        public PostRequestBody GetPostBodyObject()
        {
            PostRequestBody body = new PostRequestBody();

            body.FirstName = "Oscar";
            body.MiddleName = "Cano";
            body.LastName = "Test";
            body.Title = "1";
            body.TSARedress = "XYZ";
            body.PassportIssuingCountryCode = "US";
            body.Gender = "1";
            body.DOB = "01/01/1982";
            return body;
        }

    }
}
