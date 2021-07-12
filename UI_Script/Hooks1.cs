

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.IO;
using TechTalk.SpecFlow;
using UI_Script.Config;
using UI_Script.Helper;

namespace UI_Script.Hook
{
    [Binding]
    public  class Hooks1 : WebDriver
    {
        public WebDriver _driver;
       
        public readonly FeatureContext _featureContext;
        public readonly ScenarioContext _scenarioContext;
        public ExtentTest _currentScenarioName;
        [ThreadStatic]
        public static ExtentTest featureName;
        public static ExtentTest step;
        public static AventStack.ExtentReports.ExtentReports extent;
   
        static string  reportPath = "D:\\newgit\\SpecflowFramework\\UI_Script\\Result\\ExtentReport.html";
        static string logPath = "D:\\newgit\\SpecflowFramework\\UI_Script\\Result";

        public static ConfigSetting configSetting;

         static string configSettingPath = "D:\\newgit\\SpecflowFramework\\UI_Script\\Config\\configsetting.json";
     
        //static string configSettingPath=System.IO.Directory.GetParent(@"../../../").FullName +
           // Path.DirectorySeparatorChar + "Config/configsetting.json";

        public Hooks1(WebDriver driver, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

        }
        [BeforeTestRun]
        public static void TestInitilizer()
        {
            //Json File
            configSetting = new ConfigSetting();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configSettingPath);
            IConfigurationRoot configurationRoot = builder.Build();
            configurationRoot.Bind(configSetting);

            //Reporting 
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Logging
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.File(logPath + @"\Logs",
                outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff} |{Level :u3} |{Message} {NewLine}",
                rollingInterval:RollingInterval.Day).CreateLogger();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            featureName = extent.CreateTest(context.FeatureInfo.Title);
            Log.Information("Selecting feature file {0} to run", context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            _driver.Driver = new ChromeDriver();
            _currentScenarioName = featureName.CreateNode(context.ScenarioInfo.Title);
            Log.Information("Selecting feature file {0} to run", context.ScenarioInfo.Title);

        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = _currentScenarioName;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                Log.Error("Test Step Failed |  " + context.TestError.Message);
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        [AfterScenario]
        public void AfterScenario()
        {
           _driver.Driver.Quit();
        }
    }
}
