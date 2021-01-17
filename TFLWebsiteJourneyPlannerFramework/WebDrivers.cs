using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLWebsiteJourneyPlannerFramework
{
    /// <summary>
    /// To pick the driver from app config and opening the driver
    /// </summary>
    public abstract class WebDrivers
    {
        public virtual IWebDriver GetWebDriverFromAppConfig() {

            string driver = ConfigurationManager.AppSettings.Get("WebDriver");
            string path = AppDomain.CurrentDomain.BaseDirectory;
            switch (driver)
            {
                case "ChromeDriver":
                    ChromeOptions chropt = new ChromeOptions();
                    chropt.AddArguments("start-maximized");
                    chropt.AddArguments("--disable-extensions");
                    chropt.AddArguments("unexpectedAlertBehaviour", "ignore");
                    return new ChromeDriver(path,chropt);

                case "IEDriver":                    
                    return new InternetExplorerDriver();

                case "FirefoxDriver":
                    return new FirefoxDriver();

                case "EdgeDriver":
                    return new EdgeDriver();

                case "SafariDriver":
                    return new SafariDriver();

                default:
                    return null;
            }
        }
    }
}
