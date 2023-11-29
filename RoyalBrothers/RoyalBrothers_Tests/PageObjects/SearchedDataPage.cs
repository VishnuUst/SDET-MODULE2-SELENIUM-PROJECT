using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class SearchedDataPage
    {
        IWebDriver? driver;
        public SearchedDataPage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using = "//summary[@class='facets__summary']")]
        private IWebElement?SortyBy { get; set; }
        public void SortyByButtonClick()
        {
            SortyBy?.Click();

        }
        [FindsBy(How=How.XPath,Using = "//ul[@role='list']//child::span[text()='Price, low to high']")]
        private IWebElement?SortByList { get; set; }
        public void SortByListClick()
        {
            SortByList?.Click();
        }
    }
}
