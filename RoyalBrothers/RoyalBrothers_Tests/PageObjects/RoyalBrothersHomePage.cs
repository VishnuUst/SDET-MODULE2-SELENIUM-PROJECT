using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class RoyalBrothersHomePage
    {
        IWebDriver? driver;
        public RoyalBrothersHomePage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id,Using = "autocomplete-input")]

        private IWebElement? SearchCity {  get; set; }
        
        public HomePageOfCityPage SearchCityBox(string city)
        {
            SearchCity?.SendKeys(city);
            driver.FindElement(By.LinkText(city)).Click();
            return new HomePageOfCityPage(driver);
        }

    }
}
