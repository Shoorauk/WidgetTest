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

        [Given(@"I am form page")]
        public void GivenIAmFormPage()
        {
            _ContactsPage.NavigateToWebsite(Hooks1.configSetting.testForm);
        }

        [When(@"Enter all mandatory details")]
        public void WhenEnterAllMandatoryDetails()
        {
           
            _ContactsPage.login();
           // _ContactsPage.OpenNewUrl(Hooks1.configSetting.formURL);
            _ContactsPage.FillForm();
        }

        [When(@"Click on submit button")]
        public void WhenClickOnSubmitButton()
        {
            _ContactsPage.Submit();
        }

        [Then(@"Form submit successfully")]
        public void ThenFormSubmitSuccessfully()
        {
            Assert.AreEqual(_ContactsPage.SavedDetails(), "Hello kumar's Account");
        }

    }
}
