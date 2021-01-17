using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TFLWebsiteJourneyPlannerFramework;

namespace TFLWebsiteJourneyPlannerDomain
{
    public class TFLHtmlPage : WebPage
    {
        private By _fromPlanAJourney = By.XPath("//*[@id='InputFrom']");
        private By _toPlanAJourney = By.XPath("//*[@id='InputTo']");
        private By _planMyJourney = By.XPath("//div[@id='plan-a-journey']/fieldset/input");
        private By _fromPlanAJourneyError = By.XPath("//*[@id='InputFrom-error']");
        private By _toPlanAJourneyError = By.XPath("//*[@id='InputTo-error']");
        private By _quickestTimeTextPlanAJourney = By.XPath("//div[@id='journey-busy-stations-advice']/a");
        private By _hoverToFirstElementInPlanAJourney = By.XPath("//span[@class='stop-name']");
        private By _recentTabPlanMyJourney = By.XPath("//*[@id='jp-recent-tab-home']/a[text()='Recents']");
        private By _sizeOfTripsOnRecentTabPlanMyJourney = By.XPath("//*[@id='jp-recent-content-home-']/a");
        private By _getDetailOfRecentTripsOnRecentTabPlanMyJourney = By.XPath("//*[@id='jp-recent-content-home-']/a[1]");
        public TFLHtmlPage(IWebDriver driver):base(driver)
        {
            
        }

        public TFLHtmlPage EnterFromFieldInPlanAJourney(string fromTextInPlanAJourney)
        {
            int i = 0;
            bool result = int.TryParse(fromTextInPlanAJourney, out i);
            var iwebelement= WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _fromPlanAJourney);
            CommonWebElementsMethods.ClearAndSendKeys(iwebelement, fromTextInPlanAJourney +"  ");            
            if (result==false)
            {
                WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _hoverToFirstElementInPlanAJourney).Click();
            }
            return this;
        }

        public TFLHtmlPage EnterToFieldInPlanAJourney(string toTextInPlanAJourney)
        {
            int i = 0;
            bool result = int.TryParse(toTextInPlanAJourney, out i);
            var iwebelement = WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _toPlanAJourney);
            CommonWebElementsMethods.ClearAndSendKeys(iwebelement, toTextInPlanAJourney + "  ");
            if (result == false)
            {
                WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _hoverToFirstElementInPlanAJourney).Click();
            }
            return this;
        }

        public TFLHtmlPage ClickOnPlanAJourney()
        {
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _planMyJourney).Click();
            return this;
        }


        public TFLHtmlPage ClickOnRecentTabInPlanAJourney()
        {
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _recentTabPlanMyJourney).Click();
            return this;
        }

        public int GetSizeOfTripsOnRecentTabInPlanAJourney()
        {
            return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementsAreClickable(Driver, _sizeOfTripsOnRecentTabPlanMyJourney).Count;
        }

        public string GetDetailsOfRecentTripOnRecentTabInPlanAJourney
        {
            get { return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsDisplayed(Driver, _getDetailOfRecentTripsOnRecentTabPlanMyJourney).Text.Trim(); }
        }
        public JourneyDetailsPage ClickOnPlanAJourneyWhenJourneyDetailsAreCorrect()
        {
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _planMyJourney).Click();
            //WaitAndFindingWebElementsMethods.WaitForLoadingIcon(Driver);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WaitAndFindingWebElementsMethods.ScrollUp(Driver);

            return new JourneyDetailsPage(Driver);
        }        

        public string GetFromErrorMessagePlanAJourney
        {
            get { return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsDisplayed(Driver, _fromPlanAJourneyError).Text.Trim(); }
        }

        public string GetToErrorMessagePlanAJourney
        {
            get { return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsDisplayed(Driver, _toPlanAJourneyError).Text.Trim(); }
        }

    }
}
