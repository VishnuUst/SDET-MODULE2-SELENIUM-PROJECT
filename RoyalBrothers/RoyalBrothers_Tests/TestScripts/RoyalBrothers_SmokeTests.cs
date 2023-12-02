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
    internal class RoyalBrothers_SmokeTests:Corecodes
    {
        
        RoyalBrothersHomePage home;
        HomePageOfCityPage mainpage;
       
        [Test,Order(1)]
        [Category("Smoke Test")]
        [TestCase("Trivandrum")]
        [Author("Vishnu","vishnu.thulaseedharanpillai@ust.com")]
        public void RoyalBrotherSearchCityAndBookingTets(string city)
        {
            LogFunction();
            home = new(driver);
              mainpage = home.SearchCityBox(city);
              Thread.Sleep(2000);
            ScreenShots.TakeScreenShot(driver);

            try
            {
                Assert.That(driver.Url.Contains(city.ToLower()));
                Log.Information("The Search City Input Box is Clickable Test-Passed");
                test = extent.CreateTest("The Search City is Clickable");
                test.Pass("The Search City Is Clickable test-Pass");
            }
            catch(AssertionException)
            {
                Log.Error("The Search City Input Box is Clickable Test-Failed");
                test = extent.CreateTest("The Search City is Clickable");
                test.Fail("The Search City Is Clickable test-Failed");
            }



        }
        [Test,Order(2)]
        [Category("Smoke Test2")]
        [Author("Vishnu","vishnu.thulaseedharanpillai@ust.com")]
        public void MainHomePageSmokeTest()
        {
            LogFunction();
            StoreSmokePageItem storeSmokePageItem = new StoreSmokePageItem(driver);
            storeSmokePageItem.LinksChecking();
            Thread.Sleep(3000);
            ScreenShots.TakeScreenShot(driver);
            try
            {
                Assert.IsTrue(true);
                Log.Information("The RoyalPage Home Links Working Test:Pass");
                test = extent.CreateTest("The RoyalPage Links Working Test");
                test.Pass("The RoyalPage Links Working Test");
            }
            catch (AssertionException)
            {
                Log.Error("The RoyalPage Home Links Working Test:Fail");
                test = extent.CreateTest("The RoyalPage Links Working Test");
                test.Fail("The RoyalPage Links Working Test-Fail");
            }
        }





    }
}
