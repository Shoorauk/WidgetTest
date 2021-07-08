using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UI_Script.Helper;

namespace UI_Script.Page
{
    
    public class AccountPage : BasePage
    {
        By clickLogin = By.CssSelector(".dropdown-toggle.disabled");
        By crmUsername = By.XPath("//input[@id='username']");
        By crmPassword = By.XPath("//input[@id='password']");
        By SubmitBtn = By.XPath("//input[@id='Login']");
        By closeligtingPage = By.XPath("//input[@value='No Thanks']");
        By clickSendBtn = By.XPath("//input[@value='Send to Salesforce']");
        By clickSetupBtn = By.XPath("//a[normalize-space()='Setup']");
        By clickCustomizebtn = By.CssSelector("#Customize_font");
        By clickOnAccounts = By.CssSelector("#Account_font");
        By ClickOnField = By.CssSelector("#AccountFields_font");
        By ClickOnNewBtn = By.CssSelector("input[title='New Account Custom Fields & Relationships']");
        By ClickOnCheckBox = By.CssSelector("label[for='dtypeB']");
        By ClickNextBtn = By.CssSelector("div[class='pbBottomButtons'] input[title='Next']");
        By enterFieldLbl = By.CssSelector("#MasterLabel");
        By enterFieldName = By.CssSelector("#DeveloperName");
        By ClickOnSave = By.CssSelector("div[class='pbBottomButtons'] input[title='Save']");
        By checkInfoSaved = By.XPath("//a[normalize-space()='Test']");

        
        public AccountPage(IWebDriver driver):base(driver)
        {
            
        }

        
        public void LoginCRM(string url,string userName,string password)
        {
            GoToUrl(url);       
            waitForelementExist(clickLogin);          
            JavaScriptexecutor(clickLogin);
            waitForelementVisible(crmUsername);
            getElement(crmUsername).SendKeys(userName);
            getElement(crmPassword).SendKeys(password);
            getElement(SubmitBtn).Click();
            waitForelementExist(closeligtingPage);
            getElement(closeligtingPage).Click();
            waitForelementVisible(clickSendBtn);
            getElement(clickSendBtn).Click();
            waitForelementVisible(clickSetupBtn);
            getElement(clickSetupBtn).Click();

         }

        public void NavigateToAccount()
        {
            waitForelementVisible(clickCustomizebtn);
            getElement(clickCustomizebtn).Click();
            waitForelementVisible(clickOnAccounts);
            getElement(clickOnAccounts).Click();
            waitForelementVisible(ClickOnField);
            getElement(ClickOnField).Click();
        }

        public void OpenAccount(string fieldLable,string fieldName)
        {
            waitForelementVisible(ClickOnNewBtn);
            getElement(ClickOnNewBtn).Click();
            waitForelementVisible(ClickOnCheckBox);
            getElement(ClickOnCheckBox).Click();
            waitForelementVisible(ClickNextBtn);
            getElement(ClickNextBtn).Click();
            waitForelementVisible(enterFieldLbl);
            getElement(enterFieldLbl).SendKeys(fieldLable);
            getElement(enterFieldName).SendKeys(fieldName);
            getElement(ClickNextBtn).Click();
            Thread.Sleep(5000);
            getElement(ClickNextBtn).Click();
         



        }

        public void SaveAccountInfo()
        {
            waitForelementVisible(ClickOnSave);
            getElement(ClickOnSave).Click();
        }

        public string AccoutSaved()
        {
            waitForelementVisible(checkInfoSaved);
            return getText(checkInfoSaved);
        }
    }
}
