using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace SureAutomation.Pages
{
    class QuotePage
    {
        readonly string test_url = "https://sure-qa-challenge.vercel.app/quote";

        private IWebDriver driver;
        private WebDriverWait wait;

        public QuotePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@data-testid='price_Standard']")]
        [CacheLookup]
        private IWebElement standardPrice;





        [FindsBy(How = How.XPath, Using = "//*[@data-testid='price_Complete']")]
        [CacheLookup]
        private IWebElement completePrice;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Choose Standard']")]
        [CacheLookup]
        private IWebElement standardButton;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Choose Complete']")]
        [CacheLookup]
        private IWebElement completeButton;



        private By byStandardBtn = new ByChained(By.XPath("//span[normalize-space()='Choose Standard']"));
        private By byCompleteBtn = new ByChained(By.XPath("//span[normalize-space()='Choose Complete']"));

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

        public void VerifyStandardPrice(string price)
        {
            Utils.waitForElementToBeVisible(driver, 10, byStandardBtn);
            Assert.True(standardPrice.Displayed);
            Assert.AreEqual(standardPrice.Text, price);

        }
        public void VerifyCompletePrice(string price)
        {
            Utils.waitForElementToBeVisible(driver, 10, byCompleteBtn);
            Assert.True(completePrice.Displayed);
            Assert.AreEqual(completePrice.Text, price);

        }
        public void VerifyStandardButton()
        {
            Utils.waitForElementToBeVisible(driver, 10, byStandardBtn);
            Assert.True(standardPrice.Displayed);

        }
        public void VerifyCompleteButton()
        {
            Utils.waitForElementToBeVisible(driver, 10, byCompleteBtn);
            Assert.True(completePrice.Displayed);
        }
    }
}