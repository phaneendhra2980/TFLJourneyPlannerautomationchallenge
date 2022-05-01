using JourneyPlanner.Pages;
using JourneyPlanner.Specs.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Assist;

namespace JourneyPlanner.Steps
{
    [Binding]
    public class ValidJourneyPlannerSteps
    {
        //Page Object for Journey Planner
        private readonly JourneyPlannerPageObjects journeyPlannerPageObjects;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public ValidJourneyPlannerSteps(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            journeyPlannerPageObjects = new JourneyPlannerPageObjects(browserDriver.Current, _specFlowOutputHelper);

        }

        [Given(@"I have entered locations")]
        public void GivenIHaveEnteredlocations(Table table)
        {
            dynamic locations = table.CreateInstance<Locations>();
           
            journeyPlannerPageObjects.EnterFrom(locations.FromLocation);
            journeyPlannerPageObjects.EnterTo(locations.ToLocation);

        }
        
       
       
        
        [Then(@"I should see valid Journey results and a valid journey can be planned")]
        public void ThenIShouldSeeValidJourneyResultsAndAValidJourneyCanBePlanned()
        {
            journeyPlannerPageObjects.VerifyFromLabelisdisplayed();
            journeyPlannerPageObjects.VerifyToLabelisdisplayed();
            journeyPlannerPageObjects.VerifyLeavingLabelisdisplayed();
        }
        
        
    }
}
