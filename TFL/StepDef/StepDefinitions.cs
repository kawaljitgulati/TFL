using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using TFL.Pages;
using OpenQA.Selenium;

namespace TFL.StepDef
{
    [Binding]
    public class StepDefinitions
    {
        public static IWebDriver driver;
        private PlanAJourney planAJourney;
        public JourneyResults journeyResult;
        public static string acceptAllcookies = "//strong[normalize-space()='Accept all cookies']";
        
        public static void firstTimeAcceptCookies()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement acceptCookiesButton = driver.FindElement(By.XPath(acceptAllcookies));
            wait.Until(d => acceptCookiesButton.Enabled);
            acceptCookiesButton.Click();
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            firstTimeAcceptCookies();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            planAJourney = new PlanAJourney(driver);
            journeyResult = new JourneyResults(driver);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Quit();
        }

        [Given(@"I have navigated to the TFL journey planner")]
        public void GivenIHaveNavigatedToTheTFLJourneyPlanner()
        {
            planAJourney.navigateToPlanAJournyPage();
        }

        [When(@"I enter '([^']*)' in the From field")]
        public async Task WhenIEnterInTheFromField(string FromText)
        {
            await planAJourney.enterFromAddres(FromText);
        }

        [When(@"I enter '([^']*)' in the To field")]
        public async Task WhenIEnterInTheToField(string ToText)
        {
            await planAJourney.enterToAddres(ToText);
        }

        [When(@"I enter invalid '([^']*)' in the From field")]
        public void WhenIEnterInvalidInTheFromField(string FromText)
        {
            planAJourney.enterInvalidFromAddres(FromText);
        }
        [When(@"I enter invalid '([^']*)' in the To field")]
        public void WhenIEnterInvalidInTheToField(string ToText)
        {
            planAJourney.enterInvalidToAddres(ToText);
        }

        [When(@"I click the Plan My Journey button")]
        public void WhenIClickThePlanMyJourneyButton()
        {
            planAJourney.clickPlanJourneyButton();
        }

        [Then(@"I should see walking and cycling time")]
        public async Task ThenIShouldSeeTheJourneyResults()
        {
            await journeyResult.verifyWalkingAndCyclingTime();
        }

        [When(@"I click on the Edit preferences dropdown")]
        public async Task WhenIClickOnTheEditPreferencesDropdown()
        {
            await journeyResult.clickEditPreferences();
        }

        [When(@"I checked Routes with least walking checkbox")]
        public async Task WhenICheckedRoutesWithLeastWalkingCheckbox()
        {
            await journeyResult.checkedRoutesWithLeastWalkingCheckbox();
        }

        [When(@"I click on the Update journey button")]
        public void WhenIClickOnTheUpdateJourneyButton()
        {
            journeyResult.clickUpdateJourneyButton();
        }

        [Then(@"I should see least walking time")]
        public async Task ThenIShouldSeeLeastWalkingTime()
        {
            await journeyResult.verifyLeastWalkingTime();
        }

        [When(@"I click on the View details button")]
        public async Task WhenIClickOnTheViewDetailsButton()
        {
            await journeyResult.clickOnTheViewDetailsButton();
        }

        [Then(@"I should see access information at Covent Garden Underground Station")]
        public async Task ThenIShouldSeeAccessInformationAtCoventGardenUndergroundStation()
        {
            await journeyResult.verifyAccessInformationAtCoventGardenUndergroundStation();
        }


        [Then(@"I should see an error message")]
        public async Task ThenIShouldSeeAnErrorMessage()
        {
            await journeyResult.verifyinvalidjourneyadd();
            
        }

        [Then(@"I should see a message indicating missing locations")]
        public async Task ThenIShouldSeeAMessageIndicatingMissingLocations()
        {
            await planAJourney.verifyErrorMessage();
        }
    }
}
