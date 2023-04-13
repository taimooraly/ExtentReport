using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ExtentReport_001
{
    [TestClass]
    public class TestExecution : ExtentReport
    {
        #region Setup and Cleanup

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            LogReport("TestReport");
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }

        [TestInitialize()]
        public void TestInit()
        {
            // Add Method into Report
            exParentTest = extentReports.CreateTest(TestContext.TestName);           
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            
        }

        #endregion

        [TestMethod]
        public void TestCase_Login_001()
        {
            IWebDriver driver = new ChromeDriver();
            
            // Add Login Step inside Test Method
            exChildTest = ExtentReport.exParentTest.CreateNode("Login");

            OpenUrl(driver, "https://adactinhotelapp.com/");
            Write(driver, By.Id("username"), "AmirImam");
            Write(driver, By.Id("password"), "AmirImam");
            Click(driver, By.Id("login"));


            driver.Close();
            
        }

        [TestMethod]
        public void TestCase_LoginSearch_002()
        {          

            IWebDriver driver = new ChromeDriver();

            // Add Login Step inside Test Method
            exChildTest = ExtentReport.exParentTest.CreateNode("Login");

            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("AmirImam");
            driver.FindElement(By.Id("password")).SendKeys("AmirImam");
            driver.FindElement(By.Id("login")).Click();

            // Add Search Step inside Test Method
            exChildTest = ExtentReport.exParentTest.CreateNode("Search");
            driver.FindElement(By.Id("location")).SendKeys("Sydney");
            driver.FindElement(By.Id("Submit")).Click();

            driver.Close();
        }

        [TestMethod]
        public void TestCase_Login_003()
        {
            IWebDriver driver = new ChromeDriver();

            // Add Login Step inside Test Method
            exChildTest = ExtentReport.exParentTest.CreateNode("Login");

            OpenUrl(driver, "https://adactinhotelapp.com/");
            Write(driver, By.Id("username"), "AmirImam");
            Write(driver, By.Id("password"), "AmirImam");
            Click(driver, By.Id("login"));

            // Add Login Step inside Test Method
            exChildTest = ExtentReport.exParentTest.CreateNode("Search");
            Write(driver, By.Id("location"), "Sydney");
            Click(driver, By.Id("Submit"));

            driver.Close();

        }
    }
}
