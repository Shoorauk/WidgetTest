using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UI_Script.Page
{
    public class WidgetPage : BasePage
    {
        IWebDriver _driver;
        public WidgetPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        By AcceptCookie = By.XPath("//strong[normalize-space()='Accept all cookies']");
        By CookieDone = By.XPath("//button[@onclick='endCookieProcess(); return false;']");

        By FromLocation = By.XPath("//input[@id='InputFrom']");
        By ToLocation = By.XPath("//input[@id='InputTo']");
        By JourneyBtn = By.XPath("//input[@id='plan-journey-button']");
        By JourneyResultText = By.XPath("//span[@class='jp-results-headline']");
        By ValidateFrom = By.XPath("//div[@class='summary-row clearfix']//span[@class='notranslate']//strong");
        By ValidateTo = By.XPath("//div[@class='from-to-wrapper']//div[2]/span[2]/strong");
        By WidgetFromValidation = By.XPath("//span[contains(text(),'The From field is required.')]");
        By WidgetToValidation = By.XPath("//span[contains(text(),'The To field is required.')]");
        By ChangeTimelink = By.XPath("//a[normalize-space()='change time']");
        By ArrivingLink = By.XPath("//input[@value='arriving']");
        By DayDropDown = By.XPath("//select[@title='Today']");
        By TimeDropDown = By.XPath("//select[@id='Time']");
        By ArrivingTime = By.XPath("//body/div[@id='container']/main[@id='full-width-content']/div[@class='journey-planner-results']/div[@class='r']/div/div[@id='jp-new-content-home-']/form[@id='jp-search-form']/div[@class='journey-form']/div[@class='basic-journey-options clearfix']/div[@id='plan-a-journey']/div[@class='journey-result-summary']/div[@class='summary-row clearfix']/strong[1]");
        By EditJourneyLink = By.XPath("//span[normalize-space()='Edit journey']");
        By SwitchFromToLink = By.XPath("//a[normalize-space()='Switch from and to']");
        By UpdateJourneyBtn = By.XPath("//div[@class='editing']//input[@value='Update journey']");
        By PlanJourneyBack = By.XPath("//ol[@class='breadcrumbs clearfix']//a[normalize-space()='Plan a journey']");
        By RecentBtn = By.XPath("//a[normalize-space()='Recents']");
        By SelectActualSearchfrom = By.XPath("//span[@role='option']//strong");
        By SelectActualSearchTo = By.XPath("//span[@role='option']//strong");
        By RecentSearchJourney = By.XPath("//a[contains(text(),'Birmingham International Rail Station to Camden Ro')]");
        By ValidationError = By.XPath("//div[@class='from-results disambiguation-wrapper clearfix']//div[@class='info-message disambiguation']//span");

        public void IncorrectJourneyValidation(string validationMsg)
        {
            string ActualMessage = _driver.FindElement(ValidationError).Text;
            Assert.AreEqual(validationMsg, ActualMessage);
        }

        public void RecentSearch()
        {
            string ActualSearch = _driver.FindElement(RecentSearchJourney).Text;
            Assert.AreEqual("Birmingham International Rail Station to Camden Road Rail Station", ActualSearch);
        }

        public void BackToRecentTab()
        {
            Thread.Sleep(5000);
            _driver.Navigate().Refresh();
            ClickOnButton(PlanJourneyBack);
            ClickOnButton(RecentBtn);
        }

        public void EditJourney()
        {
            ClickOnButton(EditJourneyLink);
        }

        public void SwitchFromTO()
        {
            ClickOnButton(SwitchFromToLink);
        }

        public void UpdateJourney()
        {
            ClickOnButton(UpdateJourneyBtn);
        }


        public void ValidateTheTime()
        {
            string validateTime = _driver.FindElement(ArrivingTime).Text;
            var onlyTime = validateTime.Substring(validateTime.IndexOf(",") + 1);
            Assert.AreEqual("23:30", onlyTime.Trim());
            
        }

        public void ChangeArrivingTime()
        {
            ClickOnButton(ChangeTimelink);
            ClickOnButton(ArrivingLink);
            SelectDropDown(DayDropDown, "Tomorrow");
            SelectDropDown(TimeDropDown, "23:30");
        }


        public void NavigateWidgetPage(string url)
        {
            GoToUrl(url);
            ClickOnButton(AcceptCookie);
            ClickOnButton(CookieDone);
        }

        public void EnterLocation(string from,string to)
        {
            SendText(FromLocation, from);           
            ClickOnButton(SelectActualSearchfrom);
            SendText(ToLocation, to);
            ClickOnButton(SelectActualSearchTo);
        }

        public void EnterIncorrectLocation(string from, string to)
        {
            SendText(FromLocation, from);           
            SendText(ToLocation, to);
           
        }

        public void ClickOnJourneyButton()
        {
            ClickOnButton(JourneyBtn);
            Thread.Sleep(4000);
        }

        public void NavigateJourneyResult()
        {
            waitForelementExist(JourneyResultText);
            string actualValue = _driver.FindElement(JourneyResultText).Text;
            Assert.AreEqual("Journey results", actualValue);
        }
        public void ValidateFromAndTo(string from, string to)
        {
            waitForelementExist(JourneyResultText);
            string actualFrom = _driver.FindElement(ValidateFrom).Text;
            Thread.Sleep(6000);
            string actualto = _driver.FindElement(ValidateTo).Text;
            Assert.AreEqual(from, actualFrom);
            Assert.AreEqual(to, actualto);
        }

        public void WidgetValidationMessage(string from,string to)
        {
            string ActualFromText = _driver.FindElement(WidgetFromValidation).Text;
            string ActualToText = _driver.FindElement(WidgetToValidation).Text;
            Assert.AreEqual(from, ActualFromText);
            Assert.AreEqual(to, ActualToText);

        }
    }
    
}
