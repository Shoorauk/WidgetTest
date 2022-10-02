

using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


using OpenQA.Selenium.Edge;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.IO;

using TechTalk.SpecFlow;
using UI_Script.Config;
using UI_Script.Helper;
using WebDriverManager.DriverConfigs.Impl;

namespace UI_Script.Hook
{
    [Binding]
    public  class Hooks1
    {
        public WebDriver _driver;
       
        public readonly FeatureContext _featureContext;
        public readonly ScenarioContext _scenarioContext;
        public ExtentTest _currentScenarioName;
        [ThreadStatic]
        public static ExtentTest featureName;
        public static ExtentTest step;
        public static AventStack.ExtentReports.ExtentReports extent;        
        public static ExtentKlovReporter klov;

        //static string  reportPath = "D:\\newgit\\SpecflowFramework\\UI_Script\\Result\\ExtentReport.html";
        static string reportPath= Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Result\\ExtentReport.html";
        
         
        //static string logPath = "D:\\newgit\\SpecflowFramework\\UI_Script\\Result";
        static string logPath = Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Result";
        //static string jsonfilePath = "D:\\newgit\\SpecflowFramework\\UI_Script\\Config\\APIParameters.json";
        //static string jsonfilePath = Directory.GetParent(@"../../../").FullName +
         //   Path.DirectorySeparatorChar + "Config//APIParameters.json";
        public static ConfigSetting configSetting;

        //static string configSettingPath = "D:\\newgit\\SpecflowFramework\\UI_Script\\Config\\configsetting.json";
        public static TemplateConfigurations templateConfigurations { get; set; }
        //private static TemplateConfigurations templateConfigurations;

        static string configSettingPath=Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Config/configsetting.json";

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

            //Json file for parameter
            //using (StreamReader reader = File.OpenText(jsonfilePath))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    templateConfigurations = (TemplateConfigurations)serializer.Deserialize(reader, typeof(TemplateConfigurations));
            //}


            //Reporting 
            var htmlReporter = new ExtentHtmlReporter(reportPath);            
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;            
            extent = new AventStack.ExtentReports.ExtentReports();
            klov = new ExtentKlovReporter();
            extent.AttachReporter(htmlReporter);

            //Logging
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.File(logPath + @"\Logs",
                outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff} |{Level :u3} |{Message} {NewLine}",
                rollingInterval:RollingInterval.Day).CreateLogger();

            string[] files = Directory.GetFiles(logPath);
            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"{file} is deleted.");
            }
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
            // GetDriver();
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver.Driver = new OpenQA.Selenium.Chrome.ChromeDriver();

            //EdgeOptions options = new EdgeOptions();
            //_driver.Driver = new EdgeDriver(options);
            //_currentScenarioName = featureName.CreateNode(context.ScenarioInfo.Title);

            featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(_featureContext.FeatureInfo.Title);

            
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);


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
            //if (context.TestError == null)
            //{
            //    step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            //}
            //else if (context.TestError != null)
            //{

            //    Log.Error("Test Step Failed |  " + context.TestError.Message);
            //    step.Log(Status.Fail, context.StepContext.StepInfo.Text, CaptureScreenShot());
            //}

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                //screenshot in the Base64 format
                var mediaEntity = CaptureScreenShot(_scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }

        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                //ShutDown();
                //string testPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + @"../../").FullName;
                //string taskKillProcess = testPath + "\\drivertaskkiller.cmd";

                _driver.Driver.Quit();
                _driver.Driver.Dispose();

                System.Diagnostics.ProcessStartInfo p;
                p = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/C " + "taskkill /f /im msedgedriver.exe");
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = p;
                proc.Start();
                proc.WaitForExit();
                proc.Close();

                

            }
            catch (Exception)
            {

                return;
            }
          
           
        }

        public MediaEntityModelProvider CaptureScreenShot(string name)
        {
            var screenShot = ((OpenQA.Selenium.ITakesScreenshot)_driver.Driver).GetScreenshot().AsBase64EncodedString;
           
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot,name).Build();
        }

       
    }
}
