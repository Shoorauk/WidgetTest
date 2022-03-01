using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UI_Script.Helper;
using UI_Script.Hook;
using UI_Script.Page;

namespace UI_Script.Steps
{
    [Binding]
    public sealed class AccountSteps
    {
        //private WebDriver _driver;
        private AccountPage _AccountPage;
       

        public AccountSteps(WebDriver driver)
        {
            //_driver = driver;
            _AccountPage = new AccountPage(driver.Driver);

        }
        [Given(@"Navigate to CRM account page")]
        public void GivenNavigateToCRMAccountPage()
        {
            _AccountPage.NavigateToAmazone(Hooks1.configSetting.BaseUrl);

            //_driver.CurrentPage.As<AccountPage>().LoginCRM(loginUrl, data.userid,data.password);
            // _AccountPage.LoginCRM(Hooks1.configSetting.BaseUrl, data.userid, data.password);
            // Serilog.Log.Debug(_AccountPage.LoginCRM(Hooks1.configSetting.BaseUrl, data.userid, data.password));
        }




        [When(@"Sign-in a account with correct field label and name")]
        public void WhenSign_InAAccountWithCorrectFieldLabelAndName(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string decodePassword = _AccountPage.DecodeFrom64(data.password);

            _AccountPage.LoginCRM(data.userid, decodePassword);
        }

        [When(@"Enter (.*) and (.*)")]
        public void WhenEnterAnd(string email_id, string password)
        {
            string decodePassword = _AccountPage.DecodeFrom64(password);
            _AccountPage.LoginCRM(email_id, decodePassword);
        }

        [Then(@"Sign-in different credentials successfully(.*)")]
        public void ThenSign_InDifferentCredentialsSuccessfully(string validationText)
        {
            Assert.AreEqual("Hello," + validationText, _AccountPage.ReadValueFromTextBox("Hello,"+validationText));
        }


        [When(@"Click on save Button")]
        public void WhenClickOnSaveButton()
        {
            _AccountPage.ClickonSubmitBtn();
        }

        [Then(@"Sign-in successfully")]
        public void ThenSign_InSuccessfully()
        {
            
            Assert.AreEqual("Hello, Oscar", _AccountPage.ReadValueFromTextBox("Hello, Oscar"));
            
        }





    }
}
