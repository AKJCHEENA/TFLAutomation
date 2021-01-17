using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLWebsiteJourneyPlannerFramework
{
    /// <summary>
    /// Base class of any web page
    /// </summary>
   public abstract class WebPage
    {
       protected WebPage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            Actions = new Actions(Driver);
        }

        public string TitleOfThePage()
        {
            return Driver.Title;
        }

        public WebDriverWait Wait { get; set; }
        public Actions Actions { get; set; }
        protected IWebDriver Driver { get; set;}
    }
}
