using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TFLWebsiteJourneyPlannerFramework
{
    [Binding]
    public class Hooks : WebDrivers
    {
        private ObjectContainer _objectContainer;
        private string url = ConfigurationManager.AppSettings.Get("Url");

        By cookies_accept = By.XPath("//a[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']");
        By cookies_gotIt = By.XPath("//*[@id='cb-confirmedSettings']/div[@id='cb-buttons']/a");

        public Hooks(ObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        /// <summary>
        /// Before running the scenario this method will take care of all the initialization related to driver and reaching till home page of URL
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {        
                
                IWebDriver driver = GetWebDriverFromAppConfig();

                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                driver.Navigate().GoToUrl(url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(cookies_accept)).Click();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(cookies_accept));
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(cookies_gotIt))).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("window.scrollBy(0,250)");            
           
                _objectContainer.RegisterInstanceAs(driver);


        }
        /// <summary>
        ///  After running the scenario this method will handle the exception and close all the windows
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status==TestStatus.Inconclusive || TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var exception = ScenarioContext.Current.TestError;

                if (exception!=null)
                {
                    Console.WriteLine("Exception for the failed scenario is "+exception.Message.Trim() +" StackTrace: "+ exception.StackTrace);
                }

            }
            _objectContainer.Resolve<IWebDriver>().Quit();
        }
    }
}
