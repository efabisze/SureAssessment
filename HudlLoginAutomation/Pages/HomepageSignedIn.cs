using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace HudlLoginAutomation.Pages
{
    class HomepageSignedIn
    {
        readonly string test_url = "https://www.hudl.com/login";

        private IWebDriver driver;
        private WebDriverWait wait;

        public HomepageSignedIn(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".uni-avatar__content-container")]
        [CacheLookup]
        private IWebElement accountIcon;

        // Go to the designated page
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        // Returns the Page Title
        public String GetPageTitle()
        {
            return driver.Title;
        }

        public void VerifyAccountIcon()
        {
            Assert.IsTrue( accountIcon.Displayed);
        }
    }
}