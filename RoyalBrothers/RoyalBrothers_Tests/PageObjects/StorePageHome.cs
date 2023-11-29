using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class StorePageHome
    {
        IWebDriver? driver;
        public StorePageHome(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using ="//summary[@aria-label='Search our site']")]
        private IWebElement? SearchButton {  get; set; }
        public void SearchButtonClick()
        {
            SearchButton?.Click();
        }
        [FindsBy(How=How.XPath,Using = "//input[@name='q']")]
        private IWebElement?SearchInput { get; set; }
        // "//input[@id='Search-In-Modal-362']"

       
        public void TakeSearchInput(string itemname)
        {
            SearchInput?.SendKeys(itemname);
            
        }
        public SearchedDataPage ItemEntered()
        {
            SearchInput?.SendKeys(Keys.Enter);
            return new  SearchedDataPage(driver);
        }
        
    }
}
