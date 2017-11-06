using System;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Capstone.SeleniumTest.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Capstone.SeleniumTest.SeleniumTests
{
    [TestClass]
    public class TakeSurveyTest
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:55601/");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
        [TestMethod]
        public void TakeSurvey()
        { 
            TakeSurvey takeSurveyPage = new TakeSurvey(driver);
            TakeSurveyResult takeSurveyResultsPage = takeSurveyPage.FillForm("Cuyahoga Valley National Park", "joegriffith@gmail.com", "Ohio", "inactive");

            Assert.AreEqual("GNP", takeSurveyResultsPage.ParkCode.Text);
        }
    }
}
