using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UI_Script.Helper;
using UI_Script.Hook;
using UI_Script.Page;

namespace UI_Script.Steps
{
    [Binding]
    public sealed class ContactsSteps
    {
        private WebDriver _driver;
        private ContactsPage _ContactsPage;
        public ContactsSteps(WebDriver driver)
        {
            _driver = driver;
            _ContactsPage = new ContactsPage(_driver.Driver);
        }


        [Given(@"Navigate to yopmail site")]
        public void GivenNavigateToYopmailSite()
        {
            _ContactsPage.NavigateToWebsite(Hooks1.configSetting.yopmailURl);
        }

        [When(@"Enter random email address")]
        public void WhenEnterRandomEmailAddress()
        {
            _ContactsPage.GenerateRandomEmailAddress();
        }

        [Then(@"Email should be generated")]
        public void ThenEmailShouldBeGenerated()
        {
            Assert.AreEqual("hellotest@yopmail.com", _ContactsPage.CreateEmailSuccessfully());
        }
    }
}
