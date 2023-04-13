using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Reflection.Emit;

namespace ExtentReport_001
{
    public class ExtentReport
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;
        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"..\..\TestExecutionReports\" + '_' + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);
        }
        public static void TakeScreenshot(IWebDriver driver , Status status, string stepDetail)
        {
            string path = @"C:\TestExecutionReports\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public void Write(IWebDriver driver, By by, string data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(driver, Status.Pass, "Enter ");
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Enter Failed" + ex);
            }
        }

        public void Click(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(driver, Status.Pass, "Click");
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Click Failed " + ex);
            }
        }

        public void OpenUrl(IWebDriver driver, string url)
        {
            try
            {
                driver.Url = url;
                TakeScreenshot(driver, Status.Pass, "Open url");
            }
            catch (Exception ex)
            {
                TakeScreenshot(driver, Status.Fail, "Open Url Failed " + ex);
            }
        }
    }
}
