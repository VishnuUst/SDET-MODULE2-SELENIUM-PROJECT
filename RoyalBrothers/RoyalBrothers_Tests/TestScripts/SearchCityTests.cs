using HoneyAndSpice_Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RoyalBrothers_Tests.PageObjects;
using RoyalBrothers_Tests.Utilities;
using Serilog;
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
        
        [Category("RegressionTest")]
        public void SeacrhCityTest()
        {
           
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilepath = currDir + "/Logs/log_Royal" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration().
                WriteTo.Console().
                WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            RoyalBrothersHomePage home = new(driver);
            
            Thread.Sleep(3000);
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);

            //IWebElement ele = fluentwait.Until(x=>x.FindElement(By.XPath("//label[text()='Duration']")));
            //Actions actions = new Actions(driver);
            //Action action = () => actions.MoveToElement(ele).Build().Perform();
            //ScrollIntoView(driver, driver.FindElement(By.XPath("(//a[@class='modal-trigger'])[position()=" + id + "]")));


            //Thread.Sleep(5000);

            //Thread.Sleep(5000);
            ////data.InputClickedTime();
            ////Thread.Sleep(5000);

            //Thread.Sleep(5000);

            //Thread.Sleep(2000);

            //Thread.Sleep(3000);

            //Thread.Sleep(5000);
            //  ScreenShots.TakeScreenShot(driver);
            //try
            //{
            //    Log.Information("The Search Bike Page Loaded correctly After selecting City!!!");
            //    test = extent.CreateTest("The Bike Rentals Page Open");
            //    test.Pass("The Bike Rental Page Loaded correctly after selecting the city-Test Pass");
            //    Assert.That(driver.Url.Contains("royal"));
            //}
            //catch (AssertionException)
            //{
            //    Log.Error("The Search Bike Page Loaded Incorrectly After selecting City!!!");
            //    test = extent.CreateTest("The Bike Rental Page Open");
            //    test.Fail("The Bike Rental Page Loaded Incorrectly-Test Failed");
            //}
            if (!driver.Url.Equals("https://www.royalbrothers.com/"))
            {
                driver.Navigate().GoToUrl("https://www.royalbrothers.com/");
            }
            try
            {
                Assert.That(driver.Url.Contains("royal"));
                test = extent.CreateTest("Page success");
                test.Pass("Page success");

            }
            catch (AssertionException)
            {
                test = extent.CreateTest("Page Test");
                test.Fail("Page failed");

            }
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/Royal_InputData.xlsx";

            string? sheetName = "Search Vehicle";
            List<SearchVehicleData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach(var inputdata in excelDataList)
            {
                string? cityname = inputdata.City;
                string? checkinDate = inputdata.PickupDate;
                string? checkinTime = inputdata.PickupTime;
                string? checkoutDate = inputdata.DropoffDate;
                string? checkoutTime = inputdata.DroppoffTime;
                string? location = inputdata.Location;
                string? id = inputdata.Id;
                string? name = inputdata.Name;
                string? email = inputdata.Email;
                string? mobile = inputdata.Mobile;
                string? password = inputdata.Password;
                Console.WriteLine("city"+cityname);
                Console.WriteLine("time"+checkinTime);
                var data = home.SearchCityBox(cityname);
                //ScreenShots.TakeScreenShot(driver);
                Thread.Sleep(2000);

                //try
                //{
                //    Assert.That(driver.Url.Contains(cityname));
                //    Log.Information("Search City test-Pass");
                //    test = extent.CreateTest("Search City Test Report");
                //    test.Pass("The Search City is valid Test-Passed");
                //}
                //catch (AssertionException)
                //{
                //    Log.Error("Search City test-Failed");
                //    test = extent.CreateTest("Search City Test Report");
                //    test.Pass("The Search City is invalid Test-Failed");
                //}
                //Actions actions = new Actions(driver);
                //actions.MoveToLocation(64,87).Build().Perform();  
                //IWebElement elementToScrollTo = driver.FindElement(By.XPath("//span[@class='current']"));
                //Actions actions = new Actions(driver);
                //actions.MoveToElement(elementToScrollTo).Build().Perform();
                //Thread.Sleep(2000);

                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", elementToScrollTo);
                //Thread.Sleep(2000);
                //data.scrollSearchedData();
                //Thread.Sleep(4000);
                data.CheckInVehicle(id);
                Thread.Sleep(3000);

                data.CheckDateInputClickable();
                Thread.Sleep(5000);
                data.DateClicked(checkinDate);
                Thread.Sleep(2000);
                data.TimeClicked(checkinTime);
                Thread.Sleep(5000);
                data.NextDateClickedfunction(id);
                Thread.Sleep(5000);
                data.ToDateClickedFunction(checkoutDate);
                Thread.Sleep(5000);
                data.ToClicked(checkoutTime);
                Thread.Sleep(5000);
               var search = data.SubmitButtonFunction();
                Thread.Sleep(4000);
                search.LocationClick();
                Thread.Sleep(4000);
                search.Locationsend();
                Thread.Sleep(4000);
                search.LocationClicked(location);
                ScreenShots.TakeScreenShot(driver);
                Thread.Sleep(4000);
                try
                {
                    Console.WriteLine(driver.Title);
                    Assert.AreEqual("Search | Royalbrothers.com", driver.Title);
                    Log.Information("Book A vehicle Test-Pass");
                    test = extent.CreateTest("Book Vehicle Test Report");
                    test.Pass("The Book Vehicle  Test-Passed");
                }
                catch (AssertionException)
                {
                    Log.Information("Book A vehicle Test-Fail");
                    test = extent.CreateTest("Book Vehicle Test Report");
                    test.Pass("The Book Vehicle  Test-Failed");
                }
                var book = search.BookButtonClicked();
                book.InputBox(name);
                book.EmailBox(email);
                book.MobileInputs(mobile);
                book.PasswordBox(password);

            }
            Thread.Sleep(5000);
            

        }
    }
}
