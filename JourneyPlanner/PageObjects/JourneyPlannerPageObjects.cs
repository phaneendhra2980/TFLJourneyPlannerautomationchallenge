using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow.Infrastructure;

namespace JourneyPlanner.Pages
{
    public class JourneyPlannerPageObjects
    {
        //The URL of the JourneyPlanner to be opened in the browser
        private const string JourneyPlannerUrl = "https://tfl.gov.uk/plan-a-journey/";
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        #region Locators
        private IWebElement PlanMyJourneyElement => _webDriver.FindElement(By.Id("plan-journey-button"));
        private IWebElement RecentsTabElement => _webDriver.FindElement(By.Id("jp-recent-tab-jp"));
        private IWebElement RecentJourneysElement => _webDriver.FindElement(By.XPath("//a[@class='plain-button journey-item']"));
        private IWebElement JourneyElement => _webDriver.FindElement(By.ClassName("plain-button journey-"));
        private IWebElement TurnoffRecentsElement => _webDriver.FindElement(By.ClassName("turn-off-recents"));
        private IWebElement FrommErrorElement => _webDriver.FindElement(By.XPath("//span[@id='InputFrom-error']"));
        private IWebElement ToErrorElement => _webDriver.FindElement(By.XPath("//span[@id='InputTo-error']"));
        private IWebElement FromLabelElement => _webDriver.FindElement(By.XPath("//span[text()='From:']"));
        private IWebElement ToLabelElement => _webDriver.FindElement(By.XPath("//span[text()='To:']"));
        private IWebElement LeavingLabelElement => _webDriver.FindElement(By.XPath("//span[text()='Leaving:']"));
        private IWebElement FromElement => _webDriver.FindElement(By.Id("InputFrom"));
        private IWebElement ToElement => _webDriver.FindElement(By.Id("InputTo"));
        private IWebElement NoResultsElement => _webDriver.FindElement(By.CssSelector("#full-width-content > div > div:nth-child(8) > div > div > ul > li"));
        private IWebElement AcceptCookiesElement => _webDriver.FindElement(By.XPath("//button[@class='cb-button cb-right']"));
        private IWebElement AcceptCookiesDoneElement => _webDriver.FindElement(By.XPath("//div[@id='cb-buttons']//button[@onclick='endCookieProcess(); return false;']"));
        private IList<IWebElement> ListElements => _webDriver.FindElements(By.XPath("//span[@role='option']"));
        private IWebElement LeastWalkingElement => _webDriver.FindElement(By.XPath("//h2[@class='jp-result-transport publictransport clearfix']"));
        private IWebElement EditJourneyElement => _webDriver.FindElement(By.ClassName("edit-journey"));
        private IWebElement EditJourneyPreferencesElement => _webDriver.FindElement(By.XPath("//a[@class='toggle-options more-options']"));
        private IWebElement HideJourneyPreferencesElement => _webDriver.FindElement(By.XPath("//a[@class='toggle-options less-options']"));
        private IWebElement DateElement => _webDriver.FindElement(By.Id("Date"));
        private IWebElement TimeElement => _webDriver.FindElement(By.Id("Time"));
        private IWebElement BusElement => _webDriver.FindElement(By.XPath("//label[@for='bus']"));
        private IWebElement NationalrailElement => _webDriver.FindElement(By.XPath("//label[@for='national-rail']"));
        private IWebElement JourneyPreference0Element => _webDriver.FindElement(By.XPath("//label[@for='JourneyPreference_0']"));
        private IWebElement JourneyPreference1Element => _webDriver.FindElement(By.XPath("//label[@for='JourneyPreference_1']"));
        private IWebElement JourneyPreference2Element => _webDriver.FindElement(By.XPath("//label[@for='JourneyPreference_2']"));
        private IWebElement SavePreferencesElement => _webDriver.FindElement(By.XPath("//label[@for='SavePreferences']"));
        private IWebElement AddfavouritesElement => _webDriver.FindElement(By.Id("fav-panel-save"));
        private IWebElement StarElement => _webDriver.FindElement(By.XPath("//div[@id='edit-journey']//div[@class='fav-rainbow-list-link fav-star-off']//span[@class='fav-toggle']"));
        #endregion Locators


        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public JourneyPlannerPageObjects(IWebDriver driver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _webDriver = driver;
        }


        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            Func<IWebDriver, T> condition = driver =>
                            {
                                var result = getResult();
                                if (!isResultAccepted(result))
                                    return default;

                                return result;
                            };
            return wait.Until(condition);

        }

        /// <summary>
        /// Open the JourneyPlanner page in the browser if not opened yet
        /// </summary>
        public void EnsureJourneyPlannerIsOpen()
        {
            
            if (_webDriver.Url != JourneyPlannerUrl)
            {
                _specFlowOutputHelper.WriteLine("Application Url is :" + JourneyPlannerUrl);
                _webDriver.Url = JourneyPlannerUrl;
            }

        }

        /// <summary>
        /// Click Add favourites 
        /// </summary>
        public void ClickonAddFavourites()
        {
            
            ScrollToElement(AddfavouritesElement);
            AddfavouritesElement.Click();
            _specFlowOutputHelper.WriteLine("Add favourites Journey is Clicked");
        }

        /// <summary>
        /// Click on Update My Journey
        /// </summary>
        public void UpdateMyJourney()
        {

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("document.querySelector('input[class=\"primary-button plan-journey-button\"]').click();");
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Click Favourite
        /// </summary>
        public void ClickonStar()
        {
           
            ScrollToElement(StarElement);
            StarElement.Click();
            _specFlowOutputHelper.WriteLine("Favourite is Clicked");
        }

        /// <summary>
        /// Displays A List Of Recently Planned Journeys
        /// </summary>
        public void DisplaysAListOfRecentlyPlannedJourneys()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _webDriver.Navigate().GoToUrl(JourneyPlannerUrl);
            ScrollToElement(RecentsTabElement);
            RecentsTabElement.Click();
            Assert.AreEqual(RecentJourneysElement.Text.Trim(), "Hounslow Central Underground Station to Wembley Central");
            _specFlowOutputHelper.WriteLine("Recent Journeys are displayed: " + RecentJourneysElement.Text.Trim());
            TurnoffRecentsElement.Click();
        }

        /// <summary>
        /// Enter From Location
        /// </summary>
        /// <param name="frmlocation"></param>
        public void EnterFrom(string frmlocation)
        {
            Assert.IsTrue(FromElement.Displayed);
            FromElement.SendKeys(frmlocation);
            Actions builder = new Actions(_webDriver);
            builder.SendKeys(Keys.Tab);
            SelectOptions();
            _specFlowOutputHelper.WriteLine("Entered From Location :" + frmlocation);

        }

        /// <summary>
        /// Enter To Location
        /// </summary>
        /// <param name="tolocation"></param>
        public void EnterTo(string tolocation)
        {
            Assert.IsTrue(ToElement.Displayed);
            ToElement.SendKeys(tolocation);
            Actions builder = new Actions(_webDriver);
            builder.SendKeys(Keys.Tab);
            SelectOptions();
            _specFlowOutputHelper.WriteLine("Entered To Location :" + tolocation);

        }

        /// <summary>
        /// Scrolling to Element
        /// </summary>
        /// <param name="webElement"></param>
        public void ScrollToElement(IWebElement webElement)
        {
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(webElement);
            actions.Perform();
        }

        /// <summary>
        /// Verify if No Results are displayed Message
        /// </summary>
        public void VerifyNoResultsisdisplayed()
        {

            Assert.AreEqual("Sorry, we can't find a journey matching your criteria", NoResultsElement.Text);
            _specFlowOutputHelper.WriteLine("Results Message is :" + NoResultsElement.Text);

        }

        /// <summary>
        /// Verify Least Walking Label is displayed
        /// </summary>
        public void VerifyLeastWalkingLabelisdisplayed()
        {
            Assert.IsTrue(LeastWalkingElement.Displayed);
            Assert.AreEqual("Least walking", LeastWalkingElement.Text);
            _specFlowOutputHelper.WriteLine("Least Walking Label is Present :" + LeastWalkingElement.Text);
        }

        /// <summary>
        /// Verify From Label is displayed
        /// </summary>
        public void VerifyFromLabelisdisplayed()
        {
            Assert.IsTrue(FromLabelElement.Displayed);
            Assert.AreEqual("From:", FromLabelElement.Text);
            _specFlowOutputHelper.WriteLine("From Label is Present :" + FromLabelElement.Text);
        }

        /// <summary>
        /// Verify To Label is displayed
        /// </summary>
        public void VerifyToLabelisdisplayed()
        {
            Assert.IsTrue(ToLabelElement.Displayed);
            Assert.AreEqual("To:", ToLabelElement.Text);
            _specFlowOutputHelper.WriteLine("To Label is Present :" + ToLabelElement.Text);
        }

        /// <summary>
        /// Verify Leaving Label is displayed
        /// </summary>
        public void VerifyLeavingLabelisdisplayed()
        {
            Assert.IsTrue(LeavingLabelElement.Displayed);
            Assert.AreEqual("Leaving:", LeavingLabelElement.Text);
            _specFlowOutputHelper.WriteLine("Leaving Label is Present :" + LeavingLabelElement.Text);
        }

        /// <summary>
        /// Select Location Options
        /// </summary>
        public void SelectOptions()
        {
            //Select Option
            if (ListElements.Count > 0)
            {
                ListElements[0].Click();
            }

        }

        /// <summary>
        /// Click EditJourney
        /// </summary>
        public void ClickEditJourney()
        {
           
            ScrollToElement(EditJourneyElement);
            EditJourneyElement.Click();
            _specFlowOutputHelper.WriteLine("Edit Journey is Clicked");
        }

        /// <summary>
        /// Click Edit Journey Preferences
        /// </summary>
        public void ClickEditJourneyPreferences()
        {
             
            ScrollToElement(EditJourneyPreferencesElement);
            EditJourneyPreferencesElement.Click();
            _specFlowOutputHelper.WriteLine("Edit Journey Preferences is Clicked");
        }

        /// <summary>
        /// Click Hide Journey Preferences
        /// </summary>
        public void ClickHideJourneyPreferences()
        {
            
            ScrollToElement(HideJourneyPreferencesElement);
            HideJourneyPreferencesElement.Click();
            _specFlowOutputHelper.WriteLine("Hide Journey Preferences is Clicked");
        }

        /// <summary>
        /// Click Save Preferences
        /// </summary>
        public void ClickSavePreferences()
        {
           
            SavePreferencesElement.Click();
            _specFlowOutputHelper.WriteLine("Save Preferences is Clicked");
        }

        /// <summary>
        /// Select Date
        /// </summary>
        public void SelectDateDropDownValue()
        {
            //Select Date
            var selectElement = new SelectElement(DateElement);
            selectElement.SelectByText("Tomorrow");
            _specFlowOutputHelper.WriteLine("Date Tommorrow is Selected");
        }

        /// <summary>
        /// Select Time
        /// </summary>
        public void SelectTimeDropDownValue()
        {
            //Select Time
            DateTime currenttime = DateTime.Now.Date;
            currenttime.ToString("%h");
            var selectElement = new SelectElement(TimeElement);
            selectElement.SelectByText(currenttime.ToString("%h") + ":30");
            _specFlowOutputHelper.WriteLine("Time " + currenttime.ToString("%h") + ":30" + "is Selected");
        }

        /// <summary>
        ///  Click Bus
        /// </summary>
        public void ClickBus()
        {
            //Click Bus
            BusElement.Click();
            _specFlowOutputHelper.WriteLine("Bus Option is Selected");
        }

        /// <summary>
        ///  Click Nationalrail
        /// </summary>
        public void ClickNationalrail()
        {
           
            NationalrailElement.Click();
            _specFlowOutputHelper.WriteLine("Nationalrail Option is Selected");
        }

        /// <summary>
        /// Click Fastest Route Preference
        /// </summary>
        public void ClickFastestRoutePreference()
        {
            
            JourneyPreference0Element.Click();
            _specFlowOutputHelper.WriteLine("Fastest Route Preference Option is Selected");
        }

        /// <summary>
        /// Click Route with few changes Preference
        /// </summary>
        public void ClickRoutewithfewchangesPreference()
        {
            
            JourneyPreference1Element.Click();
            _specFlowOutputHelper.WriteLine("Route with few changes Preference Option is Selected");
        }

        /// <summary>
        ///  Click Route with least walking Preference
        /// </summary>
        public void ClickRoutewithleastwalkingPreference()
        {
           
            JourneyPreference2Element.Click();
            _specFlowOutputHelper.WriteLine("Route with least walking Preference Option is Selected");
        }

        /// <summary>
        /// Click on Plan My Journey
        /// </summary>
        public void ClickPlanMyJourney()
        {
            //Click PlanMyJourney 
            PlanMyJourneyElement.Click();
            _specFlowOutputHelper.WriteLine("Plan MyJourney is Clicked");
        }

        /// <summary>
        /// Click AcceptCookies
        /// </summary>
        public void ClickAcceptCookies()
        {
            
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (AcceptCookiesElement.Displayed)
            {
                AcceptCookiesElement.Click();
                _specFlowOutputHelper.WriteLine("Accept Cookies is Clicked");
                _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                AcceptCookiesDoneElement.Click();
                _specFlowOutputHelper.WriteLine("Accept Cookies Done is Clicked");
            }


        }



        /// <summary>
        /// Click on Recent Journeys
        /// </summary>
        public void ClickRecentJourney()
        {
            //Click recent journey 
            JourneyElement.Click();
            _specFlowOutputHelper.WriteLine("Recent Journeys Clicked");
        }

        /// <summary>
        /// Turn off or Clear Recent Journeys
        /// </summary>
        public void ClickTurnoffRecentJourneys()
        {
            //Click Turnoff  or Clear RecentJourneys
            TurnoffRecentsElement.Click();
            _specFlowOutputHelper.WriteLine("Turnoff/Clear Recent Journeys Clicked");
        }

        /// <summary>
        /// Validating Recents Tab is Present or not
        /// </summary>
        public void VerifyRecentsTabisdisplayed()
        {
            Assert.IsTrue(RecentsTabElement.Displayed);
            _specFlowOutputHelper.WriteLine("Recents Tab is :" + RecentsTabElement.Text);
            Assert.AreEqual(RecentsTabElement.Text, "Recents");

        }

        /// <summary>
        /// Validating Recent Journeys Under Recents Tab
        /// </summary>
        public void VerifyRecentsJourneys()
        {
            Assert.IsTrue(JourneyElement.Displayed);
            _specFlowOutputHelper.WriteLine("Recent Journeys are :" + JourneyElement.Text);
            Assert.AreEqual(JourneyElement.Text, "Hounslow Central Underground Station to Wembley Central");

        }

        /// <summary>
        /// Verifying From Error Message
        /// </summary>
        public void VerifFromError()
        {
            Assert.IsTrue(FrommErrorElement.Displayed);
            _specFlowOutputHelper.WriteLine("From Error Message is displaying :" + FrommErrorElement.Text);
            Assert.AreEqual(FrommErrorElement.Text, "The From field is required.");

        }

        /// <summary>
        /// Verifying To Error Message
        /// </summary>
        public void VerifToError()
        {
            Assert.IsTrue(ToErrorElement.Displayed);
            _specFlowOutputHelper.WriteLine("To Error Message is displaying :" + ToErrorElement.Text);
            Assert.AreEqual(ToErrorElement.Text, "The To field is required.");
        }

    }
}
