using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace SureAutomation.Pages
{
    class Homepage
    {
        readonly string test_url = "https://sure-qa-challenge.vercel.app/";

        private IWebDriver driver;
        private WebDriverWait wait;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "postalCode")]
        [CacheLookup]
        private IWebElement postalInput;

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Get a quote']")]
        [CacheLookup]
        private IWebElement getQuoteBtn;

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

        public void VerifyGetQuote()
        {
            Assert.IsTrue(getQuoteBtn.Displayed);
            Assert.IsTrue(postalInput.Displayed);
        }

        public void EnterPostal(string postalCode)
        {
            postalInput.SendKeys(postalCode);
        }
        public void ClickSubmit()
        {
            getQuoteBtn.Click();
        }
    }
}