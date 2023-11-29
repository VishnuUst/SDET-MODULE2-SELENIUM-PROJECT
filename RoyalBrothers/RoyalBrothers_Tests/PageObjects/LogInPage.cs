using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.PageObjects
{
    internal class LogInPage
    {
        IWebDriver? driver;
        public LogInPage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id,Using = "user_name")]
        private IWebElement? UserInput {  get; set; }
        public void InputBox(string username)
        {
            UserInput?.SendKeys(username);
        }
        [FindsBy(How = How.XPath, Using = "//input[@id='user_email']")]
        private IWebElement? EmailInput { get; set; }
        public void EmailBox(string email)
        {
            EmailInput?.SendKeys(email);
        }
        [FindsBy(How = How.Id, Using = "signup_phone_no")]
        private IWebElement? MobileInput { get; set; }
        public void MobileInputs(string mob)
        {
            MobileInput?.SendKeys(mob);
        }
        [FindsBy(How = How.XPath,Using = "//input[@id='user_password']")]
        private IWebElement? PasswordInput { get; set; }
        public void PasswordBox(string password)
        {
            PasswordInput?.SendKeys(password);
        }

    }
}
