using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
        //public void scrollSearchedData()
        //{
        //    IWebElement? scrollsession = driver.FindElement(By.XPath("(//div[@id='hourly']//button[text()='BOOK NOW'])[position()=1]"));
        //    Actions actions = new Actions(driver);
        //    actions.MoveToElement(scrollsession).Build().Perform();
        //}
        public IWebElement GetVehicleSelection(string id)
        {
          
            return driver.FindElement(By.XPath("(//a[@class='modal-trigger'])[position()=" + id + "]"));
        }
        public string? GetVehicleSet(string id)
        {
            return GetVehicleSelection(id)?.Text;
        }
       
        public void CheckInVehicle(string id)
        {
            //Actions actions = new Actions(driver);
            //actions.MoveToLocation(364, 1394).Build().Perform();
            //Console.WriteLine(GetVehicleSelection(id).Location);
            GetVehicleSelection(id)?.Click();
        }
        [FindsBy(How = How.XPath,Using ="(//div[@class='input-container'])[position()=1]")]
        private IWebElement? DateInput {  get; set; }
        public void CheckDateInputClickable()
        {
            DateInput?.Click();
        }
        IWebElement ? FromDateClicked(string date)
        {
            return driver.FindElement(By.XPath("(//table[@id='pickup-date-search_table'])//following::div[@aria-label='"+date+"' and contains(@class,'infocus')]"));
        }
        public string?GetDateClick(string date)
        {
            return FromDateClicked(date)?.Text;
        }
        public void DateClicked(string date)
        {
           FromDateClicked(date)?.Click();
        }
        IWebElement? FromTimeClicked(string pickTime)
        {
            ////ul[@class='picker__list'][1]/li[text()='11:30 AM']
            ///(//li[@class='picker__list-item' and text()='"+pickTime+"'])[position()=1]
            return driver.FindElement(By.XPath("//ul[@class='picker__list'][1]/li[text()='"+pickTime+"'][1]"));
        }
        public string? GetTimeClick(string pickTime)
        {
            return FromTimeClicked(pickTime)?.Text;
        }
        public void TimeClicked(string pickTime)
        {
           
            FromTimeClicked(pickTime)?.Click();
        }
        IWebElement? NextDateClicked(string id)
        {
            return driver.FindElement(By.XPath("(//div[@class='picker__nav--next'])[position()=2]"));
        }
        public string? GetNextDateClicked(string id)
        {
            return NextDateClicked(id)?.Text;
        }
        public void NextDateClickedfunction(string id)
        {
            NextDateClicked(id)?.Click();   
        }
        IWebElement? ToDateClicked(string date)
        {
            return driver.FindElement(By.XPath("(//table[@id='dropoff-date-search_table'])//following::div[@aria-label='"+date+"' and contains(@class,'infocus')]"));
        }
        public string? GetToDateClick(string date)
        {
            return ToDateClicked(date)?.Text;
        }
        public void ToDateClickedFunction(string date)
        {
            ToDateClicked(date)?.Click();
        }

        IWebElement? ToTimeClicked(string droptime)
        {
            //(//li[@class='picker__list-item' and text()='"+droptime+"'])[position()=2]
            return driver?.FindElement(By.XPath("//ul[@class='picker__list'][1]/li[text()='"+droptime+"'][1]"));
        }
        public string? ToTimeClick(string droptime)
        {
            return ToTimeClicked(droptime)?.Text;
        }
        public void ToClicked(string droptime )
        {
            ToTimeClicked(droptime)?.Click();
        }
        [FindsBy(How=How.XPath,Using = "(//button[@class='buttonLarge'])[position()=1]")]
        private IWebElement? SubmitButtonClick { get; set; }
        public SelectParticularVehiclePage SubmitButtonFunction()
        {
            SubmitButtonClick?.Click();
            return new SelectParticularVehiclePage(driver);
                 
        }
        
    }
}
