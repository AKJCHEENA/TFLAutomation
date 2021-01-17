using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TFLWebsiteJourneyPlannerFramework
{
  public static class CommonWebElementsMethods
    {
        public static void ClearAndSendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            Thread.Sleep(5000);
        }

        public static void ClickClearAndSendKeys(IWebElement element, string text)
        {
            element.Click();
            Thread.Sleep(2000);
            element.Clear();
            Thread.Sleep(2000);
            element.SendKeys(text);
            Thread.Sleep(2000);
        }

        public static void DoubleClick(IWebElement element)
        {
            element.Click();
            Thread.Sleep(500);
            element.Click();
            Thread.Sleep(500);
        }       
    }
}
