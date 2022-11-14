using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace HudlLoginAutomation.Pages
{
    class SignupPage
    {
        readonly string test_url = "https://www.hudl.com/register/signup";

        private IWebDriver driver;
        private WebDriverWait wait;

        public SignupPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='register_athletes_join-a-team']")]
        [CacheLookup]
        private IWebElement joinATeamLink;

        private By byElementJoinTeamLink = new ByChained(By.XPath("//a[@id='register_athletes_join-a-team']"));

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

        public void VerifyJoinATeamLink()
        {
            Utils.waitForElementToBeVisible(driver, 10, byElementJoinTeamLink);
            Assert.True(joinATeamLink.Displayed);
        }

    }
}