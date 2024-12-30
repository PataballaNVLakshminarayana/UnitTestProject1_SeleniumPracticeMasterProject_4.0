using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reactive;
using System.Threading;

namespace UnitTestProject1_SeleniumPracticeMasterProject_4._0
{
    [TestClass]
    public class UnitTestProject1_PracticeMasterProjects
    {
        public static IWebDriver _driver;
        public static ExtentReports _EReports;
        public static TestContext instance;
        public static ExtentTest _test;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        public void CreateExtentReport()
        {
            //var htmlereporter = new ExtentHtmlReporter();
            _EReports = new ExtentReports();
          string  RerportPath = @"D:\ExtentReports\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html";
            var SparkReporter = new ExtentSparkReporter(RerportPath);
            _EReports.AttachReporter(SparkReporter);
            _test=_EReports.CreateTest(TestContext.TestName);
            _EReports.Flush();
        }
        public void CaptureScreenshot(string fileName)
        {
            ITakesScreenshot _Screenshot = (ITakesScreenshot)_driver;
            Screenshot CapturedScreenshot = _Screenshot.GetScreenshot();
            string ScreenshotPath = @"D:\ExtentReports\" + fileName + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            CapturedScreenshot.SaveAsFile(ScreenshotPath);
        }
        [TestMethod]
        public void SeleniumInit()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://adactinhotelapp.com/");
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.Id("username")).SendKeys("nagalakshmin");
            _driver.FindElement(By.Id("password")).SendKeys("l@kshmin");
            _driver.FindElement(By.Id("login")).Click();
            CreateExtentReport();
            CaptureScreenshot("SeleniumPracticeMasterProject_4.0");
            Thread.Sleep(10000);
            _driver.Close();
        }
    }
}
