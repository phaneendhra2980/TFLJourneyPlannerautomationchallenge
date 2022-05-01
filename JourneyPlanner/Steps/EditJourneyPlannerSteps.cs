using JourneyPlanner.Pages;
using JourneyPlanner.Specs.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace JourneyPlanner.Steps
{
    [Binding]
    public class EditJourneyPlannerSteps
    {
        //Page Object for Journey Planner
        private readonly JourneyPlannerPageObjects journeyPlannerPageObjects;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public EditJourneyPlannerSteps(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            journeyPlannerPageObjects = new JourneyPlannerPageObjects(browserDriver.Current, _specFlowOutputHelper);

        }

        [When(@"I clicked Edit journey")]
        public void WhenIClickedEditJourney()
        {
            journeyPlannerPageObjects.ClickEditJourney();
        }

        [When(@"I edit my Journey")]
        public void WhenIEditMyJourney()
        {
            journeyPlannerPageObjects.ClickEditJourneyPreferences();
            journeyPlannerPageObjects.ClickBus();
            journeyPlannerPageObjects.SelectTimeDropDownValue();
            journeyPlannerPageObjects.ClickNationalrail();
            journeyPlannerPageObjects.ClickRoutewithleastwalkingPreference();
            journeyPlannerPageObjects.ClickSavePreferences();
            journeyPlannerPageObjects.ClickHideJourneyPreferences();
        }

        [When(@"I press Update journey")]
        public void WhenIPressUpdateJourney()
        {
            journeyPlannerPageObjects.UpdateMyJourney();
        }



        [Then(@"I should see valid amended Journey results and a valid journey can be planned")]
        public void ThenIShouldSeeValidAmendedJourneyResultsAndAValidJourneyCanBePlanned()
        {
            journeyPlannerPageObjects.VerifyLeastWalkingLabelisdisplayed();
        }
    }
}
