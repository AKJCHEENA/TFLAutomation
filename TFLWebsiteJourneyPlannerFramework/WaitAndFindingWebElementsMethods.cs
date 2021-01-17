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

        /// <summary>
        /// To wait and find an element till element is clickable
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static IWebElement WaitAndFindWhenElementIsClickable(IWebDriver driver, By locator)
        { 
            
                var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                webdriverwait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(locator)));
                return driver.FindElement(locator);            
        }
        /// <summary>
        /// To wait and find an element till element is displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static IWebElement WaitAndFindWhenElementIsDisplayed(IWebDriver driver, By locator)
        {

            var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            webdriverwait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElement(locator);

        }

        /// <summary>
        /// To wait and find all the elements till element is clickable
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static List<IWebElement> WaitAndFindWhenElementsAreClickable(IWebDriver driver, By locator)
        {

            var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            webdriverwait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(locator)));
            return driver.FindElements(locator).ToList();
        }

        /// <summary>
        /// To wait and find all the elements till element is displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>

        public static List<IWebElement> WaitAndFindWhenElementsIsDisplayed(IWebDriver driver, By locator)
        {

            var webdriverwait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            webdriverwait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElements(locator).ToList();
        }


        /// <summary>
        /// For scrolling down the current window
        /// </summary>
        /// <param name="driver"></param>
        public static void ScrollDown(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,250)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        /// <summary>
        /// For scrolling up the current window
        /// </summary>
        /// <param name="driver"></param>

        public static void ScrollUp(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,-300)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }        
    }
}
