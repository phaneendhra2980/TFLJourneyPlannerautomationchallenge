using JourneyPlanner.Pages;
using JourneyPlanner.Specs.Drivers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace JourneyPlanner.Steps
{
    [Binding]
    public class InValidJourneyPlannerSteps
    {
        //Page Object for Journey Planner
        private readonly JourneyPlannerPageObjects journeyPlannerPageObjects;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public InValidJourneyPlannerSteps(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            journeyPlannerPageObjects = new JourneyPlannerPageObjects(browserDriver.Current, _specFlowOutputHelper);

        }

        [Given(@"I have entered invalid value into the From Field")]
        public void GivenIHaveEnteredXyzIntoTheFromField()
        {
            journeyPlannerPageObjects.EnterFrom("1234@xyz");
        }
        
        [Given(@"I have entered invalid value into the To Field")]
        public void GivenIHaveEnteredAbcIntoTheToField()
        {
            journeyPlannerPageObjects.EnterTo("78956@abc");
        }
        
        [Then(@"I should see the widget is unable to provide results when an invalid journey is planned\.")]
        public void ThenIShouldSeeTheWidgetIsUnableToProvideResultsWhenAnInvalidJourneyIsPlanned_()
        {
            journeyPlannerPageObjects.VerifyNoResultsisdisplayed();
        }
    }
}
