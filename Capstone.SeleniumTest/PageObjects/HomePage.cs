using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Capstone.SeleniumTest.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
            :base(driver, "/Home/Index")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "homePageImg")]
        public IWebElement Id  { get; set; }

        public ParkDetail ClickImage()
        {
            Id.Click();
            return new ParkDetail(driver);
        }
    }
}
