using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace UnitTestProject1_SeleniumPracticeMasterProject_4._0
{
    [TestClass]
    public class UnitTestProject1_PracticeMasterProjects
    {
        public static IWebDriver _driver;

        //public object ScreenshotImageFormate { get; private set; }

        public void SeleniumInit()
        {
            _driver = new ChromeDriver();
            //_driver = chromedriver;
            //return _driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        //public void GetScreenshotFileName()
        //{
        //    var screenshotPath= @"D:\ExtentReports\screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        //}

       
        public void CaptrureScreenshots(string _fileName)
        {
            try
            {
                //var ScreenshotImageFormat;
                // Cast the driver to ITakesScreenshot
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)_driver;

                // Capture the screenshot
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                // Define the path where the screenshot will be saved
                //string screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), _fileName);
                string screenshotPath = @"D:\ExtentReports\screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

                //object ScreenshotImageFormat = null;
                // Save the screenshot to the specified location
                screenshot.SaveAsFile(screenshotPath);

                Console.WriteLine("Screenshot saved at: " + screenshotPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error taking screenshot: " + e.Message);
            }
        }
        [TestMethod]
        public void TestMethod()
        {
            try
            {
                SeleniumInit();
                // Open a website for testing
                _driver.Navigate().GoToUrl("https://www.example.com");

                // Take a screenshot after performing some actions
                CaptrureScreenshots("test_screenshot.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test failed: " + ex.Message);
                CaptrureScreenshots("error_screenshot.png");
            }
            finally
            {
                // Close the browser
                _driver.Quit();
            }
        }
        [TestMethod]
        public static void TestExecution()
        {
            UnitTestProject1_PracticeMasterProjects test = new UnitTestProject1_PracticeMasterProjects();
            test.SeleniumInit();
            test.TestMethod();
        }
    }
}
