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
            ClickOnButton(clickLogin);
            SendText(crmUsername, userName);
            SendText(crmPassword, password);
            ClickOnButton(SubmitBtn);
            ClickOnButton(closeligtingPage);
            ClickOnButton(clickSendBtn);
            ClickOnButton(clickSetupBtn);
            Serilog.Log.Debug("check the value of locator url {0} ,username {username},password {password}", url, userName, password);
            

         }

        public void NavigateToAccount()
        {
            ClickOnButton(clickCustomizebtn);
            ClickOnButton(clickOnAccounts);
            ClickOnButton(ClickOnField);
        }

        public void OpenAccount(string fieldLable,string fieldName)
        {

            ClickOnButton(ClickOnNewBtn);
            ClickOnButton(ClickOnCheckBox);
            ClickOnButton(ClickNextBtn);
            SendText(enterFieldLbl, fieldLable);
            SendText(enterFieldName, fieldName);
            ClickOnButton(ClickNextBtn);
            ClickOnButton(ClickNextBtn);



        }

        public void SaveAccountInfo()
        {
            ClickOnButton(ClickOnSave);
        }

        public string AccoutSaved()
        {
            waitForelementVisible(checkInfoSaved);
            return getText(checkInfoSaved);
        }
    }
}
