using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class HomePageOfCityPage
    {
        IWebDriver? driver;
        public HomePageOfCityPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        /* [FindsBy(How = How.XPath,Using = "(//a[@class='modal-trigger'])[position()=1]]")]*/
        /* private IWebElement?SignUpClick{ get; set; }*/
        IWebElement GetVehicleSelection(string id)
        {
            return driver.FindElement(By.XPath("(//a[@class='modal-trigger'])[position()=" + id + "]"));
        }
        public string? GetVehicleSet(string id)
        {
            return GetVehicleSelection(id)?.Text;
        }
        public void CheckInVehicle(string id)
        {
            GetVehicleSelection(id)?.Click();
        }
        [FindsBy(How = How.XPath,Using ="(//div[@class='input-container'])[position()=1]")]
        private IWebElement? DateInput {  get; set; }
        public void CheckDateInputClickable()
        {
            DateInput?.Click();
        }
        IWebElement ? FromDateClicked(string id)
        {
            return driver.FindElement(By.XPath("//td[@role='presentation']//following::div[text()='29']//ancestor::tr[1]"));
        }
        public string?GetDateClick(string id)
        {
            return FromDateClicked(id)?.Text;
        }
        public void DateClicked(string id)
        {
           FromDateClicked(id)?.Click();
        }
        IWebElement? FromTimeClicked(string id)
        {
            return driver.FindElement(By.XPath("(//li[@class='picker__list-item'])[position()=5]"));
        }
        public string? GetTimeClick(string id)
        {
            return FromTimeClicked(id)?.Text;
        }
        public void TimeClicked(string id)
        {
            FromTimeClicked(id)?.Click();
        }
    }
}
