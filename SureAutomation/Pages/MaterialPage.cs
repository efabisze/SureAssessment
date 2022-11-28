using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace SureAutomation.Pages
{
    class MaterialPage
    {
        readonly string test_url = "https://sure-qa-challenge.vercel.app/building-material";

        private IWebDriver driver;
        private WebDriverWait wait;

        public MaterialPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@data-testid='submit_cta']")]
        [CacheLookup]
        private IWebElement nextButton;

        private By byNextButton = new ByChained(By.XPath("//button[@data-testid='submit_cta']"));


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

        public MaterialPage ClickMaterialOption(string material)
        {
            string Xpath = "//label[@data-testid='"+material.ToLower()+"']";
            driver.FindElement(By.XPath(Xpath)).Click();
            
            return this;

        }

        public MaterialPage ClickNext()
        {
            Utils.waitForElementToBeVisible(driver, 10, byNextButton);
            nextButton.Click();
            return this;

        }

    /*    public void VerifyLoginErrorMessage()
        {
            Utils.waitForElementToBeVisible(driver, 10, byElementErrorMessage);

            Assert.True(questionMarkIcon.Displayed);            
            Assert.True(loginErrorMsg.Displayed);
            Assert.AreEqual(loginErrorMsg.Text,Constants.LOGINERROR);
        }
    */
    }
}