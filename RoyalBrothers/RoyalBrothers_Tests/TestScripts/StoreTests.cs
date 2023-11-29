using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RoyalBrothers_Tests.PageObjects;
using RoyalBrothers_Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.TestScripts
{
    internal class StoreTests : Corecodes
    {
        [Test, Order(2)]
        [TestCase("Trivandrum","Helmet")]
        public void StoreTest(string city,string item)
        {
            RoyalBrothersHomePage home = new(driver);
            var data = home.SearchCityBox(city);
            IWebElement? elem = driver.FindElement(By.XPath("//li[@data-target='dropdown-whats-new']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(elem).Build().Perform();
            Thread.Sleep(3000);
            StorePage storePage = new(driver);
            var datas = storePage.StoreLinkClicked();
            Thread.Sleep(4000);
            datas.SearchButtonClick();
            Thread.Sleep(4000);
            datas.TakeSearchInput(item);
            Thread.Sleep(3000);
            var itenenter = datas.ItemEntered();
            Thread.Sleep(4000);
            itenenter.SortyByButtonClick();
            Thread.Sleep(4000);
            itenenter.SortByListClick();
            Thread.Sleep(4000);

        }
    }
}
