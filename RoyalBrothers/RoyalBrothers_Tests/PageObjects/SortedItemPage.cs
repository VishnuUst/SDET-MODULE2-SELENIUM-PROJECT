using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class SortedItemPage
    {
        IWebDriver? driver;
        public SortedItemPage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        public void Actionscroll()
        {
            IWebElement? scrollitempage = driver.FindElement(By.XPath("(//summary[@class='facets__header']//span[@class='facets__selected'])[position()=3]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(scrollitempage).Build().Perform();
        }

        [FindsBy(How = How.XPath,Using = "(//label[@title ='In stock'])[position()=1]")]
        private IWebElement ? Instock { get; set; }
        public void InStockClicked()
        {
            Instock?.Click();
        }
        IWebElement? GetProduct()
        {
            return driver.FindElement(By.XPath("(//div[@class='collection']//child::li[@class='grid__item'])[position()=1]"));

        }
        public string? GetProductName()
        {
            return GetProduct()?.Text;
        }
        public void GetProductNameClicked()
        {
            GetProduct()?.Click();
        }
        [FindsBy(How=How.XPath,Using = "(//div[@class='product-form__buttons']//child::button[@name='add'])[position()=1]")]
        private IWebElement? AddToCart { get; set; }
        public void AddtoCartClick()
        {
            AddToCart?.Click();
        }
        [FindsBy(How=How.XPath,Using = "//input[@class='quantity__input']")]
        private IWebElement? Qty { get; set; }
        public void QtyClick(string qty) 
        { 
            Qty?.SendKeys(qty);
            Qty?.SendKeys(Keys.Enter);
        }
      

       

    }
}
