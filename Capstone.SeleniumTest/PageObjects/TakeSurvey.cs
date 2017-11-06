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
    public class TakeSurvey : BasePage
    {
        public TakeSurvey(IWebDriver driver):base(driver, "/Survey/TakeSurvey")
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using ="ParkCode")]
        public IWebElement ParkCode { get; set; }

        [FindsBy(How = How.Name, Using ="Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using ="State")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Name, Using ="ActivityLevel")]
        public IWebElement ActivityLevel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form button")]
        public IWebElement SubmitButton { get; set; }

        public TakeSurveyResult FillForm(string parkCode, string email, string state, string activityLevel)
        {
            SelectElement parkDropDown = new SelectElement(ParkCode);
            parkDropDown.SelectByText(parkCode);

            Email.SendKeys(email.ToString());

            SelectElement stateDropDown = new SelectElement(State);
            stateDropDown.SelectByText(state);

            SelectElement activityLevelDropDown = new SelectElement(ActivityLevel);
            activityLevelDropDown.SelectByText(activityLevel);

            SubmitButton.Click();

            return new TakeSurveyResult(driver);
        }

    }
}
