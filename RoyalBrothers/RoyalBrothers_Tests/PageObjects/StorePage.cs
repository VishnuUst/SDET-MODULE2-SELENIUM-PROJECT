using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Storage;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class StorePage
    {
        IWebDriver? driver;
        public StorePage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath,Using = "(//li[@class='hide-on-med-and-down'])[position()=3]")]
        private IWebElement? StoreLink { get; set; }
        public StorePageHome StoreLinkClicked()
        {
            StoreLink?.Click();
            return new StorePageHome(driver);
        }
    }
}
