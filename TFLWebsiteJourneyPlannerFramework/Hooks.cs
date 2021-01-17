using BoDi;
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

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = GetWebDriverFromAppConfig();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementToBeClickable(cookies_accept)).Click();
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(cookies_accept));
                System.Threading.Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(cookies_gotIt))).Click();
                System.Threading.Thread.Sleep(2000);
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("window.scrollBy(0,250)");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            _objectContainer.RegisterInstanceAs(driver);


        }

        [AfterScenario]
        public void AfterScenario()
        {
            _objectContainer.Resolve<IWebDriver>().Quit();
        }
    }
}
