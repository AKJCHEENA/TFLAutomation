using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TFLWebsiteJourneyPlannerDomain;
using TFLWebsiteJourneyPlannerFramework;

namespace TFLWebsiteJourneyPlannerSteps.Steps
{
    [Binding]
    public  class VerifyAllPossibleScenariosOnTFLHomePageSteps
    {
        private string _fromTextInPlanAJourney ="";
        private string _toTextInPlanAJourney="";
        private string _editedFomTextInPlanAJourney = "";
        private string _editedToTextInPlanAJourney = "";

        [Given(@"Navigate to home page of the TFL")]
        [Obsolete]
        public void GivenNavigateToHomePageOfTheTFL()
        {
            var driver =(IWebDriver)ScenarioContext.Current.GetBindingInstance(typeof(IWebDriver));
            var tflHtmlPage = new TFLHtmlPage(driver);
            ScenarioContext.Current["TflHtmlPage"] = tflHtmlPage;

        }

        [When(@"Enter any value in ""(.*)"" from field")]
        public void WhenEnterAnyValueInFromField(string fromTextInPlanAJourney)
        {           
            _fromTextInPlanAJourney = fromTextInPlanAJourney == "" ? null : fromTextInPlanAJourney;


            if (_fromTextInPlanAJourney!=null)
            {
                ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").EnterFromFieldInPlanAJourney(_fromTextInPlanAJourney);
            }
        }

        [When(@"Enter any value in ""(.*)"" to field")]
        public void WhenEnterAnyValueInToField(string toTextInPlanAJourney)
        {
           
            _toTextInPlanAJourney = toTextInPlanAJourney == "" ? null : toTextInPlanAJourney;

            if (_toTextInPlanAJourney!=null)
            {
                ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").EnterToFieldInPlanAJourney(_toTextInPlanAJourney);
            }
        }

        [When(@"Widget is unable to plan a journey as incorrect locations ""(.*)"",""(.*)"",""(.*)"",""(.*)"" are entered into the widget on TFL site")]
        public void WhenWidgetIsUnableToPlanAJourneyAsIncorrectLocationsAreEnteredIntoTheWidgetOnTFLSite(string fromTextInPlanAJourney, string toTextInPlanAJourney, string editedFromTextInPlanAJourney, string editedToTextInPlanAJourney)
        {
                _editedFomTextInPlanAJourney = editedFromTextInPlanAJourney == "" ? null : editedFromTextInPlanAJourney;
                _editedToTextInPlanAJourney = editedToTextInPlanAJourney == "" ? null : editedToTextInPlanAJourney;

                ScenarioContext.Current["JourneyDetailsPageHtmlPage"] = ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").ClickOnPlanAJourneyWhenJourneyDetailsAreCorrect();
                var actualFromFieldPlanAJourneyMessage = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetFromMessagePlanAJourney();
                var actualToFieldPlanAJourneyMessage = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetToMessagePlanAJourney();
                var editJourneyLinkEnabledInPlanAJourney = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").EditJourneyLinkEnabledInPlanAJourney();
                var getJourneyPlannerErrorTextPlanAJourney = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetJourneyPlannerErrorTextPlanAJourney;

                Assert.AreEqual(fromTextInPlanAJourney.Trim(), actualFromFieldPlanAJourneyMessage.Trim(), "Plan a journey scenario failed for FROM field" + actualFromFieldPlanAJourneyMessage);
                Assert.AreEqual(toTextInPlanAJourney.Trim(), actualToFieldPlanAJourneyMessage.Trim(), "Plan a journey scenario failed for TO field" + actualToFieldPlanAJourneyMessage);
                Assert.AreEqual(true, editJourneyLinkEnabledInPlanAJourney, "Plan a journey scenario failed for edit journey hyperlink " + editJourneyLinkEnabledInPlanAJourney);
                Assert.AreEqual("Journey planner could not find any results to your search. Please try again", getJourneyPlannerErrorTextPlanAJourney.Trim(), "Unable to Plan a journey scenario failed for incorrect locations, validation message is " + getJourneyPlannerErrorTextPlanAJourney.Trim());
            
                if (_editedFomTextInPlanAJourney != null)
                {
                    ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").EnterEditedFromFieldInPlanAJourney(editedFromTextInPlanAJourney);
                }

                if (_editedToTextInPlanAJourney != null)
                {
                    ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").EnterEditedToFieldInPlanAJourney(editedToTextInPlanAJourney);
                }
        }

        [Then(@"Edit the to and from fields ""(.*)"",""(.*)"" and enter into the widget on TFL site")]
        public void ThenEditTheToAndFromFieldsAndEnterIntoTheWidgetOnTFLSite(string editedFromTextInPlanAJourney, string editedToTextInPlanAJourney)
        {
            _editedFomTextInPlanAJourney = editedFromTextInPlanAJourney == "" ? null : editedFromTextInPlanAJourney;
            _editedToTextInPlanAJourney = editedToTextInPlanAJourney == "" ? null : editedToTextInPlanAJourney;

            if (_editedFomTextInPlanAJourney != null)
            {
                ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").EnterEditedFromFieldInPlanAJourney(editedFromTextInPlanAJourney);
            }

            if (_editedToTextInPlanAJourney != null)
            {
                ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").EnterEditedToFieldInPlanAJourney(editedToTextInPlanAJourney);
            }
        }



        [Then(@"Validate that widget is unable to plan a journey as incorrect locations ""(.*)"",""(.*)"" are entered into the widget on TFL site")]
        public void ThenValidateThatWidgetIsUnableToPlanAJourneyAsIncorrectLocationsAreEnteredIntoTheWidgetOnTFLSite(string fromTextInPlanAJourney, string toTextInPlanAJourney)
        {
            if (fromTextInPlanAJourney=="" && toTextInPlanAJourney=="")
            {
                ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").ClickOnPlanAJourney();

                var actualFromFieldErrorMessage = ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").GetFromErrorMessagePlanAJourney;
                var actualToFieldErrorMessage = ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").GetToErrorMessagePlanAJourney;

                Assert.AreEqual("The From field is required.", actualFromFieldErrorMessage, "Unable to plan a journey scenario failed for FROM field" + actualFromFieldErrorMessage);
                Assert.AreEqual("The To field is required.", actualToFieldErrorMessage, "Unable to plan a journey scenario failed for TO field" + actualToFieldErrorMessage);
            }
            else
            {
                ScenarioContext.Current["JourneyDetailsPageHtmlPage"] = ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").ClickOnPlanAJourneyWhenJourneyDetailsAreCorrect();

                var actualFromFieldPlanAJourneyMessage = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetFromMessagePlanAJourney();
                var actualToFieldPlanAJourneyMessage = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetToMessagePlanAJourney();
                var editJourneyLinkEnabledInPlanAJourney = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").EditJourneyLinkEnabledInPlanAJourney();
                var getJourneyPlannerErrorTextPlanAJourney = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetJourneyPlannerErrorTextPlanAJourney;

                Assert.AreEqual(fromTextInPlanAJourney.Trim(), actualFromFieldPlanAJourneyMessage.Trim(), "Plan a journey scenario failed for FROM field" + actualFromFieldPlanAJourneyMessage);
                Assert.AreEqual(toTextInPlanAJourney.Trim(), actualToFieldPlanAJourneyMessage.Trim(), "Plan a journey scenario failed for TO field" + actualToFieldPlanAJourneyMessage);
                Assert.AreEqual(true, editJourneyLinkEnabledInPlanAJourney, "Plan a journey scenario failed for edit journey hyperlink " + editJourneyLinkEnabledInPlanAJourney);
                Assert.AreEqual("Journey planner could not find any results to your search. Please try again", getJourneyPlannerErrorTextPlanAJourney.Trim(), "Unable to Plan a journey scenario failed for incorrect locations, validation message is " + getJourneyPlannerErrorTextPlanAJourney.Trim());
            }

        }

        [Then(@"Validate that widget is able to plan a journey as correct locations ""(.*)"",""(.*)"",""(.*)"" are entered into the widget on TFL site")]
        public void ThenValidateThatWidgetIsAbleToPlanAJourneyAsCorrectLocationsAreEnteredIntoTheWidgetOnTFLSite(string fromTextInPlanAJourney, string toTextInPlanAJourney, string journeyType)
        {
            if (journeyType.Trim()== "New")
            {
                ScenarioContext.Current["JourneyDetailsPageHtmlPage"] = ScenarioContext.Current.Get<TFLHtmlPage>("TflHtmlPage").ClickOnPlanAJourneyWhenJourneyDetailsAreCorrect();
            }
            else
            {
                ScenarioContext.Current["JourneyDetailsPageHtmlPage"] = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").ClickOnUpdateJourneyWhenJourneyDetailsAreCorrect();
            }

            var actualFromFieldPlanAJourneyMessage = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetFromMessagePlanAJourney();
            var actualToFieldPlanAJourneyMessage = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetToMessagePlanAJourney();
            var editJourneyLinkEnabledInPlanAJourney = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").EditJourneyLinkEnabledInPlanAJourney();
            var getQuickestTimeTextPlanAJourney = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").GetQuickestTimeTextPlanAJourney;

            Assert.AreEqual(fromTextInPlanAJourney.Trim(), actualFromFieldPlanAJourneyMessage.Trim(), "Plan a journey scenario failed for FROM field" + actualFromFieldPlanAJourneyMessage);
            Assert.AreEqual(toTextInPlanAJourney.Trim(), actualToFieldPlanAJourneyMessage.Trim(), "Plan a journey scenario failed for TO field" + actualToFieldPlanAJourneyMessage);
            Assert.AreEqual(true, editJourneyLinkEnabledInPlanAJourney, "Plan a journey scenario failed for edit journey hyperlink " + editJourneyLinkEnabledInPlanAJourney);
            Assert.AreEqual("Find out the quietest times to travel and stations, stops and routes to use.", getQuickestTimeTextPlanAJourney.Trim(), "Plan a journey scenario failed for Quickest Time Text " + getQuickestTimeTextPlanAJourney.Trim());
        }

        [Then(@"Verify the recent tab on plan a journey page contains detail ""(.*)"",""(.*)"" of recently planned journey")]
        public void ThenVerifyTheRecentTabOnPlanAJourneyPageContainsDetailOfRecentlyPlannedJourney(string fromTextInPlanAJourney, string toTextInPlanAJourney)
        {
            ScenarioContext.Current["JourneyDetailsPageRecentTab"] = ScenarioContext.Current.Get<JourneyDetailsPage>("JourneyDetailsPageHtmlPage").ClickOnHomeButtonWhenJourneyDetailsAreCorrect();
            ScenarioContext.Current.Get<TFLHtmlPage>("JourneyDetailsPageRecentTab").ClickOnRecentTabInPlanAJourney();

            var getSizeOfRecentTrips = ScenarioContext.Current.Get<TFLHtmlPage>("JourneyDetailsPageRecentTab").GetSizeOfTripsOnRecentTabInPlanAJourney();
            var expectedDetailOfRecentDetail = fromTextInPlanAJourney+ " to " + toTextInPlanAJourney;
            var actualDetailOfRecentDetail = ScenarioContext.Current.Get<TFLHtmlPage>("JourneyDetailsPageRecentTab").GetDetailsOfRecentTripOnRecentTabInPlanAJourney;

            Assert.IsTrue(getSizeOfRecentTrips > 1, "Recent trips scenario failed as no of recent trips are less than one , size is " + getSizeOfRecentTrips);
            Assert.AreEqual(actualDetailOfRecentDetail.Trim(), expectedDetailOfRecentDetail.Trim(), "Recent trips scenario failed as recent trip actual details is not matching with recent trip expected details, actual details are " +actualDetailOfRecentDetail.Trim());

        }


    }
}
