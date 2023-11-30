using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class CheckOutPage
    {
        IWebDriver? driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement? InEmail { get; set; }
        public void InEmailInput(string email)
        {
            InEmail?.Clear();
            
            InEmail?.SendKeys(email);
        }


        [FindsBy(How = How.XPath, Using = "(//input[@name='firstName'])[position()=1]")]
        private IWebElement? first { get; set; }
        public void InFirstInput(string firstname)
        {
            first?.Clear();
            first?.SendKeys(firstname);


        }
        [FindsBy(How = How.XPath, Using = "(//input[@name='lastName'])[position()=1]")]
        private IWebElement? last { get; set; }
        public void InLastInput(string lastname)
        {
            last?.Clear();
            last?.SendKeys(lastname);


        }
    }
}
