using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Capstone.SeleniumTest.PageObjects
{
    public class TakeSurveyResult: BasePage
    {
        public TakeSurveyResult(IWebDriver driver) : base(driver, "/Survey/TakeSurveyResult")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using="td")]
        public IWebElement Votes { get; set; }
        [FindsBy(How = How.TagName, Using = "td")]
        public IWebElement ParkCode { get; set; }
        [FindsBy(How = How.TagName, Using ="td")]
        public IWebElement ParkName { get; set; }
    }
}
