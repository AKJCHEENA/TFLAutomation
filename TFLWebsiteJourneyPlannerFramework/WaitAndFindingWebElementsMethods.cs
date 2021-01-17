using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TFLWebsiteJourneyPlannerFramework
{
   public static class WaitAndFindingWebElementsMethods
    {

        
        public static IWebElement WaitAndFindWhenElementIsClickable(IWebDriver driver, By locator)
        { 
            
                var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                webdriverwait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(locator)));
                return driver.FindElement(locator);            
        }

        public static IWebElement WaitAndFindWhenElementIsDisplayed(IWebDriver driver, By locator)
        {

            var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            webdriverwait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElement(locator);

        }

        public static List<IWebElement> WaitAndFindWhenElementsAreClickable(IWebDriver driver, By locator)
        {

            var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            webdriverwait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(locator)));
            return driver.FindElements(locator).ToList();
        }

        public static List<IWebElement> WaitAndFindWhenElementsIsDisplayed(IWebDriver driver, By locator)
        {

            var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            webdriverwait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElements(locator).ToList();
        }


        public static void ScrollDown(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,250)");
        }

        public static void ScrollUp(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,-300)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }        
    }
}
