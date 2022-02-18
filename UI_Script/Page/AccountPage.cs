using OpenQA.Selenium;


namespace UI_Script.Page
{
    
    public class AccountPage : BasePage
    {
        By clickLogin = By.XPath("//*[text()='Sign in']");
        By crmUsername = By.XPath("//input[@name='email']");
        By clickContinue = By.XPath("//input[@id='continue']");
        By crmPassword = By.XPath("//input[@name='password']");
        By SubmitBtn = By.XPath("//input[@id='signInSubmit']");
        By checkInfoSaved = By.XPath("//*[text()='Hello, rashmi']");





        public AccountPage(IWebDriver driver) : base(driver)
        {

        }


        public void NavigateToAmazone(string url)
        {
            GoToUrl(url);
        }


        public void LoginCRM(string userName, string password)
        {

            waitForelementExist(clickLogin);
            JavaScriptexecutorForClick(clickLogin);
            waitForelementVisible(crmUsername);
            getElement(crmUsername).SendKeys(userName);
            waitForelementVisible(clickContinue);
            getElement(clickContinue).Click();
            getElement(crmPassword).SendKeys(password);



        }

        public void ClickonSubmitBtn()
        {
            getElement(SubmitBtn).Click();
        }



        public string AccoutSaved()
        {
            waitForelementVisible(checkInfoSaved);
            return getText(checkInfoSaved);
        }
    }
}
