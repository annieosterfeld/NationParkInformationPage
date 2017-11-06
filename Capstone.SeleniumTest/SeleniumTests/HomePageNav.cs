using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Capstone.SeleniumTest.PageObjects;

namespace Capstone.SeleniumTest.SeleniumTests
{
    [TestClass]
    public class HomePageNav
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
        public void ClickParkImage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Navigate();

            ParkDetail parkDetail = homePage.ClickImage();

            Assert.AreEqual("img", parkDetail.Id.TagName);
        }
    }
}
