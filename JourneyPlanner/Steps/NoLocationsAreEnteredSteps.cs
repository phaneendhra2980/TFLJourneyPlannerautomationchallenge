using JourneyPlanner.Pages;
using JourneyPlanner.Specs.Drivers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace JourneyPlanner.Steps
{
    [Binding]
    public class NoLocationsAreEnteredSteps
    {
        //Page Object for Journey Planner
        private readonly JourneyPlannerPageObjects journeyPlannerPageObjects;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public NoLocationsAreEnteredSteps(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            journeyPlannerPageObjects = new JourneyPlannerPageObjects(browserDriver.Current, _specFlowOutputHelper);

        }

        [When(@"I press Plan my Journey")]
        public void WhenIPressPlanMyJourney()
        {
            journeyPlannerPageObjects.ClickPlanMyJourney();
        }
        
        [Then(@"widget is unable to plan a journey if no locations are entered into the widget\.")]
        public void ThenWidgetIsUnableToPlanAJourneyIfNoLocationsAreEnteredIntoTheWidget_()
        {
            journeyPlannerPageObjects.VerifFromError();
            journeyPlannerPageObjects.VerifToError();
        }
    }
}
