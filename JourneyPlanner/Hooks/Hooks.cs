using JourneyPlanner.Pages;
using JourneyPlanner.Specs.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace JourneyPlanner.Hooks
{
    [Binding]
    public class Hooks
    {
        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="browserDriver"></param>
        /// <param name="specFlowOutputHelper"></param>
        [BeforeScenario()]
        public static void BeforeScenario(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
           
            var journeyplannerPageObjects = new JourneyPlannerPageObjects(browserDriver.Current, specFlowOutputHelper);
            journeyplannerPageObjects.EnsureJourneyPlannerIsOpen();
            journeyplannerPageObjects.ClickAcceptCookies();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="browserDriver"></param>
        [AfterScenario]
        public void AfterScenario(BrowserDriver browserDriver)
        {
            //TODO: implement logic that has to run after executing each scenario
            browserDriver.Dispose();
        }

    }
}
