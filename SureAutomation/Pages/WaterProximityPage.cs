using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace SureAutomation.Pages
{
    class WaterProximityPage
    {
        readonly string test_url = "https://sure-qa-challenge.vercel.app/water-proximity";

        private IWebDriver driver;
        private WebDriverWait wait;

        public WaterProximityPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        [CacheLookup]
        private IWebElement nextButton;

        private By byNextButton = new ByChained(By.XPath("//button[@type='submit']"));


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



        public WaterProximityPage ClickProximityOption(string prox)
        {
            string Xpath = "//span[normalize-space()='"+prox+"']";
            driver.FindElement(By.XPath(Xpath)).Click();

            return this;

        }

        public WaterProximityPage ClickNext()
        {
            Utils.waitForElementToBeVisible(driver, 10, byNextButton);
            Thread.Sleep(2000);
            nextButton.Click();
            return this;

        }

    }
}