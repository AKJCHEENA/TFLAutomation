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
        /// <summary>
        /// To clear the text box and enter the keys
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void ClearAndSendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
            Thread.Sleep(5000);
        }

        /// <summary>
        /// To click, clear and enter the keys in the text box
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void ClickClearAndSendKeys(IWebElement element, string text)
        {
            element.Click();
            Thread.Sleep(2000);
            element.Clear();
            Thread.Sleep(2000);
            element.SendKeys(text);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// To double click the web element
        /// </summary>
        /// <param name="element"></param>
        public static void DoubleClick(IWebElement element)
        {
            element.Click();
            Thread.Sleep(500);
            element.Click();
            Thread.Sleep(500);
        }       
    }
}
