
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;
using UI_Script.Helper;

namespace UI_Script.Hook
{
    [Binding]
    public  class Hooks1 : WebDriver
    {
        public WebDriver _driver;
      
        public Hooks1(WebDriver driver, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _driver = driver;
          
        }


    

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            _driver.Driver = new ChromeDriver();
           
        }


        [AfterScenario]
        public void AfterScenario()
        {
           //_driver.Driver.Quit();
        }
    }
}
