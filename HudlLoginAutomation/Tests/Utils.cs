using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public static class Utils
{
    public static void waitForElementToBeVisible(IWebDriver driver, int seconds, By by)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
    }
}