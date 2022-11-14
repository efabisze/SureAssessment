using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace HudlLoginAutomation.Pages
{
    class LoginPage
    {
        readonly string test_url = "https://www.hudl.com/login";

        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[class^='styles_questionMarkContainer_']")]
        [CacheLookup]
        private IWebElement questionMarkIcon;

        [FindsBy(How = How.CssSelector, Using = "[class^='styles_backIconContainer_']")]
        [CacheLookup]
        private IWebElement backIcon;

        [FindsBy(How = How.XPath, Using = "//*[@data-qa-id='hudl-logo']")]
        [CacheLookup]
        private IWebElement hudlLogo;
        
        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        private IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "logIn")]
        [CacheLookup]
        private IWebElement signInButton;

        [FindsBy(How = How.ClassName, Using = "uni-form__check-indicator__background")]
        [CacheLookup]
        private IWebElement rememberMeCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@data-qa-id='need-help-link']")]
        [CacheLookup]
        private IWebElement needHelp;

        [FindsBy(How = How.XPath, Using = "//button[@data-qa-id='log-in-with-organization-btn']")]
        [CacheLookup]
        private IWebElement loginWithOrg;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Sign up']")]
        [CacheLookup]
        private IWebElement signUpLink;

        [FindsBy(How = How.XPath, Using = "//p[@class='uni-text']")]
        [CacheLookup]
        private IWebElement loginErrorMsg;

        private By byElementErrorMessage = new ByChained(By.XPath("//p[@class='uni-text']"));

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

        // Returns the search string
        public LoginPage EnterCredentials(string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            return this;

        }

        public LoginPage ClickSignin()
        {
            signInButton.Click();
            return this;

        }
        public void ClickLoginWithOrg()
        {
            loginWithOrg.Click();

        }
        public void ClickNeedHelpLink()
        {
            needHelp.Click();

        }
        public void ClickSignupLink()
        {
            signUpLink.Click();
        }
        public void ClickRememberMe()
        {
            rememberMeCheckbox.Click();
        }
        public void VerifyLoginErrorMessage()
        {
            Utils.waitForElementToBeVisible(driver, 10, byElementErrorMessage);

            Assert.True(questionMarkIcon.Displayed);            
            Assert.True(loginErrorMsg.Displayed);
            Assert.AreEqual(loginErrorMsg.Text,Constants.LOGINERROR);
        }

        public void Login(string username, string password)
        {
            GoToPage();
            EnterCredentials(username, password);

            ClickSignin();
        }
    }
}