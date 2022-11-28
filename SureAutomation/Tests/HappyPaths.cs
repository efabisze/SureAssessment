using SureAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.DevTools.V105.Runtime;

namespace SureAutomation.Tests

{

    [TestFixture(typeof(ChromeDriver))]
//    [TestFixture(typeof(InternetExplorerDriver))]
  //  [TestFixture(typeof(FirefoxDriver))]
    public class SeleniumTest<TWebDriver> where TWebDriver : IWebDriver, new()

    {

        private IWebDriver driver;

        [SetUp]
        public void Setup()

        {
            this.driver = new TWebDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        [Category(Constants.REGRESSION)]
        public void VerifySticksCloseToWaterQuote()

        {

            Homepage homepageSignedIn = new Homepage(driver);
            homepageSignedIn.GoToPage();
            homepageSignedIn.VerifyGetQuote();
            homepageSignedIn.EnterPostal("12345");
            homepageSignedIn.ClickSubmit();

            MaterialPage materialPage= new MaterialPage(driver);
            materialPage.ClickMaterialOption("Straw");
            materialPage.ClickNext();

            WaterProximityPage waterProximityPage = new WaterProximityPage(driver);
            waterProximityPage.ClickProximityOption("Yes");
            waterProximityPage.ClickNext();

            QuotePage quotePage= new QuotePage(driver);
            quotePage.VerifyStandardButton();
            quotePage.VerifyStandardPrice("$246");
            quotePage.VerifyCompleteButton();
            quotePage.VerifyCompletePrice("$410");
            
        }

        [TearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}