using JourneyPlanner.Pages;
using JourneyPlanner.Specs.Drivers;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace JourneyPlanner.Steps
{
    [Binding]
    public class RecentsTabSteps
    {
        //Page Object for Journey Planner
        private readonly JourneyPlannerPageObjects journeyPlannerPageObjects;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public RecentsTabSteps(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            journeyPlannerPageObjects = new JourneyPlannerPageObjects(browserDriver.Current, _specFlowOutputHelper);

        }


       

        [Then(@"widget displays a list of recently planned journeys\.")]
        public void ThenWidgetDisplaysAListOfRecentlyPlannedJourneys_()
        {
            journeyPlannerPageObjects.DisplaysAListOfRecentlyPlannedJourneys();
        }

        



    }
}
