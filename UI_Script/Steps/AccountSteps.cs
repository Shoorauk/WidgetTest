using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UI_Script.Helper;
using UI_Script.Page;

namespace UI_Script.Steps
{
    [Binding]
    public sealed class AccountSteps
    {
        private WebDriver _driver;
        private AccountPage _AccountPage;
        string loginUrl = "https://www.salesforce.com/";

        public AccountSteps(WebDriver driver)
        {
            _driver = driver;
            _AccountPage = new AccountPage(_driver.Driver);

        }
        [Given(@"Navigate to CRM account page")]
        public void GivenNavigateToCRMAccountPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            //_driver.CurrentPage.As<AccountPage>().LoginCRM(loginUrl, data.userid,data.password);
            _AccountPage.LoginCRM(loginUrl, data.userid, data.password);
        }

        [When(@"Create a account with correct field label and name")]
        public void WhenCreateAAccountWithCorrectFieldLabelAndName(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _AccountPage.NavigateToAccount();
            _AccountPage.OpenAccount(data.FieldLabel, data.FieldName);
        }

        [When(@"Click on save Button")]
        public void WhenClickOnSaveButton()
        {
            _AccountPage.SaveAccountInfo();
        }

        [Then(@"Account customer field should be created")]
        public void ThenAccountCustomerFieldShouldBeCreated()
        {
            Assert.AreEqual("Test", _AccountPage.AccoutSaved());
        }

    }
}
