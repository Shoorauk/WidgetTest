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
    public sealed class ContactsSteps
    {
        private WebDriver _driver;
        private ContactsPage _ContactsPage;
        public ContactsSteps(WebDriver driver)
        {
            _driver = driver;
            _ContactsPage = new ContactsPage(_driver.Driver);
        }

       
        [When(@"Create a contracts with correct field label and name")]
        public void WhenCreateAContractsWithCorrectFieldLabelAndName(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _ContactsPage.NavigateToContactsPage();
            _ContactsPage.CreateContract(data.FieldLabel, data.FieldName);

        }

        [When(@"Click on contracts save Button")]
        public void WhenClickOnContractsSaveButton()
        {
            _ContactsPage.SaveContacts();
        }

        [Then(@"contracts customer field should be created")]
        public void ThenContractsCustomerFieldShouldBeCreated()
        {
            Assert.AreEqual("Test", _ContactsPage.VerifiedSavedFieldName());
        }

    }
}
