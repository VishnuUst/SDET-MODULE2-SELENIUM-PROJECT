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
    internal class StoreSmokePageItem
    {
        IWebDriver ?driver;
        public StoreSmokePageItem(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        public void LinksChecking()
        {
            IWebElement tariff = driver.FindElement(By.XPath("//li[@class='hide-on-med-and-down']//child::a[text()='Tariff']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(tariff).Build().Perform();
            IWebElement Whatsnew = driver.FindElement(By.XPath("//li[@data-target='dropdown-whats-new']"));
            Actions actionsone = new Actions(driver);
            actionsone.MoveToElement(Whatsnew).Build().Perform();
            IWebElement offer = driver.FindElement(By.XPath("//li[@class='hide-on-med-and-down offer-hide']//child::a[text()='Offers']"));
            Actions actionsoffer = new Actions(driver);
            actionsoffer.MoveToElement(offer).Build().Perform();
        }

    }
}
