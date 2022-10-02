
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UI_Script.Helper;
using UI_Script.Hook;
using UI_Script.Page;

namespace UI_Script.Steps
{
    [Binding]
    public sealed class WidgetSteps
    {

        private WidgetPage _widgePage;

        public WidgetSteps(WebDriver driver)
        {
            //_driver = driver;
            _widgePage = new WidgetPage(driver.Driver);

        }

        [Given(@"Navigate to plan journey widget")]
        public void GivenNavigateToPlanJourneyWidget()
        {
            _widgePage.NavigateWidgetPage(Hooks1.configSetting.BaseUrl);
        }

        [When(@"Enter  the from and to location")]
        public void WhenEnterTheFromAndToLocation(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _widgePage.EnterLocation(data.fromLocation, data.toLocation);

        }

        [When(@"Click on plan my journey button")]
        public void WhenClickOnPlanMyJourneyButton()
        {
            _widgePage.ClickOnJourneyButton();
        }

        [Then(@"Navigate to journey result page")]
        public void ThenNavigateToJourneyResultPage()
        {
            _widgePage.NavigateJourneyResult();
        }


        [Then(@"From and to location should be same same as enter in plan journey page")]
        public void ThenFromAndToLocationShouldBeSameSameAsEnterInPlanJourneyPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _widgePage.ValidateFromAndTo(data.from, data.to);
        }

        [Then(@"Validation message should be displayed")]
        public void ThenValidationMessageShouldBeDisplayed(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _widgePage.WidgetValidationMessage(data.From, data.To);
        }

        [When(@"Change the arrival time")]
        public void WhenChangeTheArrivalTime()
        {
            _widgePage.ChangeArrivingTime();
        }

        [Then(@"Validation the arriving time journey result page")]
        public void ThenValidationTheArrivingTimeJourneyResultPage()
        {
            _widgePage.ValidateTheTime();
        }

        [When(@"Click on edit journey button")]
        public void WhenClickOnEditJourneyButton()
        {
            _widgePage.EditJourney();
        }

        [When(@"switch the from and to location")]
        public void WhenSwitchTheFromAndToLocation()
        {
            _widgePage.SwitchFromTO();
        }

        [When(@"Click on update journey button")]
        public void WhenClickOnUpdateJourneyButton()
        {
            _widgePage.UpdateJourney();
        }

        [Then(@"Validate the switch from and to location")]
        public void ThenValidateTheSwitchFromAndToLocation(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _widgePage.ValidateFromAndTo(data.from,data.to);
        }
        [When(@"Click on journey plan and click on recent button")]
        public void WhenClickOnJourneyPlanAndClickOnRecentButton()
        {
            _widgePage.BackToRecentTab();
        }

        [Then(@"Recent search should be displayed")]
        public void ThenRecentSearchShouldBeDisplayed()
        {
            _widgePage.RecentSearch();
        }

        [Then(@"Validation message should be displayed ""(.*)""")]
        public void ThenValidationMessageShouldBeDisplayed(string ValidationMsg)
        {
            _widgePage.IncorrectJourneyValidation(ValidationMsg);
        }

        [When(@"Enter  the from and to location for test")]
        public void WhenEnterTheFromAndToLocationForTest(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _widgePage.EnterIncorrectLocation(data.fromLocation, data.toLocation);
        }




    }
}
