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

        By clickCustomizebtn = By.CssSelector("#Customize_font");
        By clickOnContactsBtn = By.XPath("//a[@id='Contact_font']");
        By clickOnFieldBtn = By.XPath("//a[@id='ContactFields_font']");
        By ClickOnNewBtn = By.CssSelector("input[title='New Contact Custom Fields & Relationships']");
        By ClickOnCheckBox = By.XPath("//input[@id='dtypeB']");
        By ClickNextBtn = By.CssSelector("div[class='pbBottomButtons'] input[title='Next']");
        By enterFieldLbl = By.CssSelector("#MasterLabel");
        By enterFieldName = By.CssSelector("#DeveloperName");
        By ClickOnSave = By.CssSelector("div[class='pbBottomButtons'] input[title='Save']");
        By checkInfoSaved = By.XPath("//a[normalize-space()='Test']");


        public void NavigateToContactsPage()
        {

            waitForelementVisible(clickCustomizebtn);
            getElement(clickCustomizebtn).Click();
            waitForelementVisible(clickOnContactsBtn);
            getElement(clickOnContactsBtn).Click();
            waitForelementVisible(clickOnFieldBtn);
            getElement(clickOnFieldBtn).Click();
        }

        public void CreateContract(string fieldLabel,string fieldName)
        {
            waitForelementVisible(ClickOnNewBtn);
            getElement(ClickOnNewBtn).Click();
            waitForelementVisible(ClickOnCheckBox);
            getElement(ClickOnCheckBox).Click();
            getElement(ClickNextBtn).Click();
            waitForelementVisible(enterFieldLbl);
            getElement(enterFieldLbl).SendKeys(fieldLabel);
            getElement(enterFieldName).SendKeys(fieldName);
            getElement(ClickNextBtn).Click();
            waitForelementVisible(ClickNextBtn);
            getElement(ClickNextBtn).Click();
            
        }

        public void SaveContacts()
        {
            waitForelementVisible(ClickOnSave);
            getElement(ClickOnSave).Click();
        }

        public string VerifiedSavedFieldName()
        {
            waitForelementVisible(checkInfoSaved);
            string text = getText(checkInfoSaved);
            return text;
        }


    }


 
}
