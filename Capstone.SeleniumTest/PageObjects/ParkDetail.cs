using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Capstone.SeleniumTest.PageObjects
{
    public class ParkDetail : BasePage
    {
        public ParkDetail(IWebDriver driver)
            :base(driver, "/Home/ParkDetail")
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using ="parkdetailimage")]
        public IWebElement Id { get; set; }
    }
}
