using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RoyalBrothers_Tests.PageObjects;
using RoyalBrothers_Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.TestScripts
{ 

    [TestFixture]
    internal class SearchCityTests:Corecodes
    {
        [Test,Order(1)]
        [TestCase("Trivandrum","2")]
        [Category("RegressionTest")]
        public void SeacrhCityTest(string city,string id)
        {
            RoyalBrothersHomePage home = new(driver);
            var data=home.SearchCityBox(city);
            Thread.Sleep(3000);
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            //IWebElement ele = fluentwait.Until(x=>x.FindElement(By.XPath("//label[text()='Duration']")));
            //Actions actions = new Actions(driver);
            //Action action = () => actions.MoveToElement(ele).Build().Perform();
            //ScrollIntoView(driver, driver.FindElement(By.XPath("(//a[@class='modal-trigger'])[position()=" + id + "]")));
            data.CheckInVehicle(id);
            data.CheckDateInputClickable();
            Thread.Sleep(5000);
            data.DateClicked(id);
            Thread.Sleep(5000);
            data.TimeClicked(id);
            Thread.Sleep(5000);
            

        }
    }
}
