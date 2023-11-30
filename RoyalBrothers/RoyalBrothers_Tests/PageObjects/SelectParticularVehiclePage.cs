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
    internal class SelectParticularVehiclePage
    {
        IWebDriver? driver;
        public SelectParticularVehiclePage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How=How.XPath,Using = "//input[@class='loc_input'][position()=1]")]
        private IWebElement? LocationClicking {  get; set; }
        public void LocationClick()
        {
            LocationClicking?.Click();
        }
        [FindsBy(How=How.XPath,Using = "//input[@placeholder='Location'][1]")]
        private IWebElement? InputLoc {  get; set; }
        public void Locationsend()
        {
            InputLoc?.SendKeys("Central Railway station (Opp to KSRTC Bus terminal)");
        }
         IWebElement? LocationItemClick(string loc)
        {
            return driver?.FindElement(By.XPath("(//li[@class='location fully_available' and text()='Central Railway station (Opp to KSRTC Bus terminal)'])[position()=1]"));

        }
        public string?LocationCheck(string loc)
        {
            return LocationItemClick(loc)?.Text;
        }
        public void LocationClicked(string loc)
        {
            LocationItemClick(loc)?.Click();
        }
        [FindsBy(How=How.XPath,Using ="//button[text()='Book'][position()=1]")]
        private IWebElement? ButtonData {  get; set; }
        public LogInPage BookButtonClicked()
        {
            ButtonData?.Click();
            return new LogInPage(driver);
        }
    }
}
