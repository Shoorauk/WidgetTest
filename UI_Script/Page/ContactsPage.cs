using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UI_Script.Page
{
    public class ContactsPage : BasePage
    {
        private WebDriver _driver;
        public ContactsPage(IWebDriver driver) : base(driver)
        {
            _driver = (WebDriver)driver;
        }

        //Locators

        By enterEmail = By.XPath("//input[@id='login']");
        By clickArrow = By.XPath("//i[contains(text(),'')]");
        By checkEmail = By.XPath("//div[normalize-space()='hellotest@yopmail.com']");       
        By clickOnExsignin = By.XPath("//input[@id='txtUserName']");
        By enterpassfp = By.XPath("//input[@id='txtPassword']");
        By fpSubmit = By.XPath("//input[@id='btnSignIn']");
        By fpFirstName = By.XPath("//input[@id='txtFirstName']");
        By fpLastName = By.XPath("//input[@id='txtLastName']");
        By fpSelectMonth = By.XPath("//select[@id='ddlMonth']");
        By fpSelectDate = By.XPath("//select[@id='ddlDate']");
        By fpSelectYear = By.XPath("//select[@id='ddlYear']");
        By fpSelectGender = By.XPath("//select[@id='ddlGender']");
        By fpSelectTitle = By.XPath("//select[@id='ddlTitle']");
        By fpSelectCountry = By.XPath("//select[@id='ddlCountryList']");
        By Fpaddress = By.XPath("//input[@id='txtAddressOne']");
        By fpCity = By.XPath("//input[@id='txtCity']");
        By fpSelectState = By.XPath("//select[@id='ddlStatesList']");
        By fpZip = By.XPath("//input[@id='txtZipCode']");
        By fpcontact = By.XPath("//input[@id='txtContactNumber']");
        By submit = By.XPath("//input[@id='saveUserDetails']");
        By welcomeLink = By.XPath("//li[2]//div[1]//div[1]//a[1]//div[1]");
        By myInfoLink = By.XPath("//*[text()='My Information']");
        By welcomeName = By.XPath("//span[@class='firstName user-name']");





        //Methods

        public void NavigateToWebsite(string url)
        {
            GoToUrl(url);
        }

        public void OpenNewUrl(string url)
        {
            OpenUrl(url);
        }
        public void GenerateRandomEmailAddress()
        {
            waitForelementVisible(enterEmail);
            SendText(enterEmail, "hellotest");
            ClickOnButton(clickArrow);
        }

        public string CreateEmailSuccessfully()
        {
            waitForelementVisible(checkEmail);
            return getText(checkEmail);
        }

        public void FillForm()
        {
            ClickOnButton(welcomeLink);
            ClickOnButton(myInfoLink);
            var newWindowHandle = _driver.WindowHandles[1];
            _driver.SwitchTo().Window(newWindowHandle);
            ClearTextField(fpFirstName);
            SendText(fpFirstName, "Hello");
            ClearTextField(fpLastName);
            SendText(fpLastName, "kumar");
            SelectDropDown(fpSelectMonth, "Feb");
            SelectDropDown(fpSelectDate, "03");
            SelectDropDown(fpSelectYear, "1990");
            SelectDropDown(fpSelectGender, "Male");
            SelectDropDown(fpSelectTitle, "Dr");
            ClearTextField(Fpaddress);
            SendText(Fpaddress, "hellostreet");
            ClearTextField(fpCity);
            SendText(fpCity, "houston");
            SelectDropDown(fpSelectState, "Texas");
            ClearTextField(fpZip);
            SendText(fpZip, "10001");
            ClearTextField(fpcontact);
            SendText(fpcontact, "123456789");

        }

        public void Submit()
        {
            JavaScriptexecutorForClick(submit);
            
        }

        public void login()
        {
            SendText(clickOnExsignin,"vishal.malik@fareportal.com");
            SendText(enterpassfp, "fareportal1");
            Thread.Sleep(30);
            ClickOnButton(fpSubmit);
            Thread.Sleep(30);
        }

       public string  SavedDetails()

        {
            
            return getText(welcomeName);
        }




    }


 
}
