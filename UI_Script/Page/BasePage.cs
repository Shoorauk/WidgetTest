using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UI_Script.Helper;

namespace UI_Script.Page
{
    public class BasePage : Base
    {
        private IWebDriver _driver;
        public BasePage(IWebDriver driver):base(driver)
        {
            _driver = driver;
        }

        public override IWebElement getElement(By locator)
        {
            IWebElement element = null;
            try
            {
                element = _driver.FindElement(locator);
            }
            catch (Exception e)
            {
                Console.WriteLine("Locator is not found " + locator.ToString());
                Console.WriteLine(e.Message);


            }

            return element;
        }

        public override string getText(By locator)
        {
             string text =getElement(locator).Text;
            return text;
        }

        public override string getPageTitle()
        {
            return _driver.Title;
        }

        public override void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public override void waitForelementExist(By locator)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);

            }
        }

        public override void waitForelementVisible(By locator)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);

            }
        }

        public void JavaScriptexecutor(By element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", _driver.FindElement(element));

        }
    }
}
