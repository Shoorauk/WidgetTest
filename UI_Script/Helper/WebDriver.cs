using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using UI_Script.Page;

namespace UI_Script.Helper
{
    public class WebDriver
    {
        public IWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }
    }
}
