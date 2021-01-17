using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLWebsiteJourneyPlannerFramework;

namespace TFLWebsiteJourneyPlannerDomain
{
    public class JourneyDetailsPage : WebPage
    {
        private By _fromMessagePlanAJourney = By.XPath("//*[@id='plan-a-journey']/div[@class='journey-result-summary']/div[@class='from-to-wrapper']/div[@class='summary-row clearfix']/span[text()='From:']/following::span[@class='notranslate']/strong");
        private By _editJourneyLinkPlanAJourney = By.XPath("//*[@id='plan-a-journey']/div[@class='journey-result-summary']/div[@class='summary-row clearfix']/a/span");
        private By _editPreferenceLinkPlanAJourney = By.XPath("//*[@id='plan-a-journey']/div[@class='travel-preferences clearfix']/div[@class='edit-preferences clearfix']/a");
        private By _quickestTimeTextPlanAJourney = By.XPath("//div[@id='journey-busy-stations-advice']/a");
        private By _journeyPlannerErrorTextPlanAJourney = By.XPath("//li[@class='field-validation-error']");
        private By _hoverToFirstElementInPlanAJourney = By.XPath("//span[@class='stop-name']");
        private By _editedFromPlanAJourney = By.XPath("//*[@id='InputFrom']");
        private By _editedClearFromPlanAJourney = By.XPath("//a[text()='Clear From location']");
        private By _editedToPlanAJourney = By.XPath("//*[@id='InputTo']");
        private By _editedClearToPlanAJourney = By.XPath("//a[text()='Clear To location']");
        private By _updateMyJourney = By.XPath("//*[@id='plan-journey-button']");
        private By _homeButtonMyJourney = By.XPath("//span[text()='Home']");

        public JourneyDetailsPage(IWebDriver driver) : base(driver)
        {

        }

        public string GetFromMessagePlanAJourney()
        {
            var listOfWebElements =WaitAndFindingWebElementsMethods.WaitAndFindWhenElementsIsDisplayed(Driver, _fromMessagePlanAJourney);

             return listOfWebElements[0].Text.Trim(); 
        }

        public string GetToMessagePlanAJourney()
        {
            var listOfWebElements =WaitAndFindingWebElementsMethods.WaitAndFindWhenElementsIsDisplayed(Driver, _fromMessagePlanAJourney);

             return listOfWebElements[1].Text.Trim();
        }

        public JourneyDetailsPage EnterEditedFromFieldInPlanAJourney(string editedFomTextInPlanAJourney)
        {
            int i = 0;
            bool result = int.TryParse(editedFomTextInPlanAJourney, out i);
            WaitAndFindingWebElementsMethods.ScrollUp(Driver);
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _editJourneyLinkPlanAJourney).Click();
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _editedClearFromPlanAJourney).Click();
            var iwebelement = WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _editedFromPlanAJourney);
            CommonWebElementsMethods.ClearAndSendKeys(iwebelement, editedFomTextInPlanAJourney + "  ");
            if (result == false)
            {
                WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _hoverToFirstElementInPlanAJourney).Click();
            }
            return this;
        }

        public JourneyDetailsPage EnterEditedToFieldInPlanAJourney(string editedToTextInPlanAJourney)
        {
            int i = 0;
            bool result = int.TryParse(editedToTextInPlanAJourney, out i);
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _editedClearToPlanAJourney).Click();
            var iwebelement = WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _editedToPlanAJourney);
            CommonWebElementsMethods.ClearAndSendKeys(iwebelement, editedToTextInPlanAJourney + "  ");
            if (result == false)
            {
                WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _hoverToFirstElementInPlanAJourney).Click();
            }
            return this;
        }

        public JourneyDetailsPage ClickOnUpdateJourneyWhenJourneyDetailsAreCorrect()
        {
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _updateMyJourney).Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WaitAndFindingWebElementsMethods.ScrollUp(Driver);
            return this;
        }

        public TFLHtmlPage ClickOnHomeButtonWhenJourneyDetailsAreCorrect()
        {
            WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _homeButtonMyJourney).Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return new TFLHtmlPage(Driver);
        }


        public bool EditJourneyLinkEnabledInPlanAJourney()
        {

            return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _editJourneyLinkPlanAJourney).Enabled;
        }

        public bool EditPreferencesLinkEnabledInPlanAJourney()
        {
            WaitAndFindingWebElementsMethods.ScrollUp(Driver);
            return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsClickable(Driver, _editPreferenceLinkPlanAJourney).Enabled;
        }

        public string GetQuickestTimeTextPlanAJourney
        {
            get { return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsDisplayed(Driver, _quickestTimeTextPlanAJourney).Text.Trim(); }
        }

        public string GetJourneyPlannerErrorTextPlanAJourney
        {
            get { return WaitAndFindingWebElementsMethods.WaitAndFindWhenElementIsDisplayed(Driver, _journeyPlannerErrorTextPlanAJourney).Text.Trim(); }
        }       

    }
}