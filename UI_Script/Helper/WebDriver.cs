using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using UI_Script.Page;
using WebDriverManager.DriverConfigs.Impl;

namespace UI_Script.Helper
{
    public class WebDriver
    {
        public IWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }


        public IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                string browser = "Edge";
                switch (browser)
                {
                    case "chrome":
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        Driver = new ChromeDriver();
                        break;
                    case "Edge":
                        EdgeOptions edgeOption = new EdgeOptions();
                        Driver = new EdgeDriver(edgeOption);
                        break;
                }
            }
            return Driver;
        }

        public void ShutDown()
        {
            if (Driver != null)
            {


                Driver.Quit();
                Driver.Dispose();

                System.Diagnostics.ProcessStartInfo p;
                p = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/C " + "taskkill /f /im msedgedriver.exe");
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = p;
                proc.Start();
                proc.WaitForExit();
                proc.Close();

            }
        }




    }
}
