using HoneyAndSpice_Tests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RoyalBrothers_Tests.PageObjects;
using RoyalBrothers_Tests.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalBrothers_Tests.TestScripts
{
    [TestFixture]
    internal class StoreTests : Corecodes
    {
       

        [Test, Order(1)]
        [Author("Vishnu T","vishnu.thulaseedharanpillai@ust.com")]
        [Category("Regresion Test")]

        public void StoreTest()
        {
            LogFunction();
            RoyalBrothersHomePage home = new(driver);
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/Royal_InputData.xlsx";

            string? sheetName = "StoreDatas";
            List<StoreData> excelDataList = ExcelUtils.ReadExcelDataStore(excelFilePath, sheetName);
            foreach (var excel in excelDataList)
            {
               if(!driver.Url.Equals("https://www.royalbrothers.com/"))
                {
                     driver.Navigate().GoToUrl("https://www.royalbrothers.com/");
                }
                string? city = excel.City;
                string? item = excel.Item;
                string? sortby = excel.SortBy;

                var data = home.SearchCityBox(city);
                Thread.Sleep(3000);
                //ScreenShots.TakeScreenShot(driver);
                IWebElement? elem = driver.FindElement(By.XPath("//li[@data-target='dropdown-whats-new']"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(elem).Build().Perform();
                Thread.Sleep(3000);
                StorePage storePage = new(driver);
                var datas = storePage.StoreLinkClicked();
                Thread.Sleep(4000);
                Log.Information("StoreLink Clicked");
                datas.SearchButtonClick();
                Thread.Sleep(4000);
                Log.Information("Search Button Clicked");
                datas.TakeSearchInput(item);
                Thread.Sleep(3000);
                var itenenter = datas.ItemEntered();
                Thread.Sleep(4000);
                Log.Information("Item Searched");
                itenenter.SortyByButtonClick();
                Thread.Sleep(4000);
                Log.Information("Item Sorted");
                var sorted = itenenter.SortByListClick(sortby);
                Thread.Sleep(4000);
                sorted.Actionscroll();
                Thread.Sleep(4000);
                sorted.InStockClicked();
                Thread.Sleep(3000);
                sorted.GetProductNameClicked();
                Thread.Sleep(4000);
                ScreenShots.TakeScreenShot(driver);
                sorted.AddtoCartClick();
                Thread.Sleep(3000);
                Log.Information("Add To Cart Clicked");
                sorted.QtyClick(excel.Qty);
                Thread.Sleep(5000);
                CheckOutPage checkOutPage = new CheckOutPage(driver);
                checkOutPage.InEmailInput(excel.Email);
                Thread.Sleep(2000);
                checkOutPage.InFirstInput(excel.FirstName);
                Thread.Sleep(2000);
                checkOutPage.InLastInput(excel.LastName);
                ScreenShots.TakeScreenShot(driver);
                Thread.Sleep(2000);

                
               try
                {
                    Assert.That(driver.Url.Contains("checkouts"));
                    Log.Information("The Search Item And Product Checkout Working - Test Passed");
                    test = extent.CreateTest("The Search And  Store Checkout Scenario");
                    test.Pass("The Search And Checkout store Scenario Test-Pass");

                }
                catch(AssertionException)
                {
                    ScreenShots.TakeScreenShot(driver);
                    Log.Error("The Search Item And Product Checkout Working - Test Failed");
                    test = extent.CreateTest("The Search And Checkout store Scenario");
                    test.Fail("The Search And Checkout Scenario  store Test-Failed");

                }

                //IWebElement? elem = driver.FindElement(By.XPath("//li[@data-target='dropdown-whats-new']"));
                //Actions actions = new Actions(driver);
                //actions.MoveToElement(elem).Build().Perform();
                //Thread.Sleep(3000);
                
            }

        }
       
    }
}
