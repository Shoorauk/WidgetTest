using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Script.Page
{
    public class ContactsPage : BasePage
    {
        public ContactsPage(IWebDriver driver) : base(driver)
        {
        }

        By enterEmail = By.XPath("//input[@id='login']");
        By clickArrow = By.XPath("//i[contains(text(),'')]");
        By checkEmail = By.XPath("//div[normalize-space()='hellotest@yopmail.com']");



        public void NavigateToWebsite(string url)
        {
            GoToUrl(url);
        }


        public void GenerateRandomEmailAddress()
        {
            waitForelementVisible(enterEmail);
            getElement(enterEmail).SendKeys("hellotest");
            getElement(clickArrow).Click();
        }

        public string CreateEmailSuccessfully()
        {
            waitForelementVisible(checkEmail);
            return getText(checkEmail);
        }


    }


 
}
