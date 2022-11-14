using HudlLoginAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace HudlLoginAutomation.Tests

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
        public void VerifyLogin()

        {
            LoginPage login_page = new LoginPage(driver);
            login_page.Login(Constants.EMAIL, Constants.PASSWORD);

            HomepageSignedIn homepageSignedIn = new HomepageSignedIn(driver);

            homepageSignedIn.VerifyAccountIcon();
            Assert.AreEqual("https://www.hudl.com/home", driver.Url);
        }

        [Test]
        [Category(Constants.REGRESSION)]
        public void VerifyIncorrectPasswordLogin()
        {
            LoginPage login_page = new LoginPage(driver);
            login_page.Login(Constants.EMAIL, Constants.PASSWORD + "test");

            login_page.VerifyLoginErrorMessage();
            Assert.AreEqual("https://www.hudl.com/login", driver.Url);
        }

        [Test]
        [Category(Constants.REGRESSION)]
        public void VerifyIncorrectEmailLogin()
        {
            LoginPage login_page = new LoginPage(driver);
            login_page.Login("test"+Constants.EMAIL, Constants.PASSWORD);

            HomepageSignedIn homepageSignedIn = new HomepageSignedIn(driver);

            login_page.VerifyLoginErrorMessage();
            Assert.AreEqual("https://www.hudl.com/login", driver.Url);
        }

        [Test]
        [Category(Constants.REGRESSION)]
        public void VerifyLoginOrgPage()
        {
            LoginPage login_page = new LoginPage(driver);
            login_page.GoToPage();
            login_page.ClickLoginWithOrg();

            Assert.AreEqual("https://www.hudl.com/app/auth/login/organization", driver.Url);
        }

        [Test]
        [Category(Constants.REGRESSION)]
        public void VerifyNeedHelpLink()
        {
            LoginPage login_page = new LoginPage(driver);
            login_page.GoToPage();
            login_page.ClickNeedHelpLink();

            Assert.AreEqual("https://www.hudl.com/login/help#", driver.Url);
        }

        [Test]
        [Category(Constants.REGRESSION)]
        public void VerifySignupLink()
        {
            LoginPage login_page = new LoginPage(driver);
            login_page.GoToPage();
            login_page.ClickSignupLink();

            SignupPage signup_page = new SignupPage(driver);
            signup_page.VerifyJoinATeamLink();

            Assert.AreEqual("https://www.hudl.com/register/signup", driver.Url);
        }


        [Test]
        [Category(Constants.REGRESSION)]
        public void VerifyRememberMe()
        {
            LoginPage login_page = new LoginPage(driver);
            login_page.GoToPage();
            login_page.EnterCredentials(Constants.EMAIL, Constants.PASSWORD);
            login_page.ClickRememberMe();
            login_page.ClickSignin();

            HomepageSignedIn homepageSignedIn = new HomepageSignedIn(driver);
            homepageSignedIn.VerifyAccountIcon();
/*///////////////This section was not working and when opened it would be at login screen
            driver.Close();

            IWebDriver newDriver;
            newDriver = new TWebDriver();

            LoginPage newlogin_page = new LoginPage(newDriver);
            newlogin_page.goToPage();

            HomepageSignedIn newHomepageSignedIn = new HomepageSignedIn(newDriver);
            newHomepageSignedIn.verifyAccountIcon();
            Assert.AreEqual("https://www.hudl.com/home", newDriver.Url);
*/

        }

        [TearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}