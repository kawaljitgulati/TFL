using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TFL.Pages
{
    public class JourneyResults
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public string cyclingTime = "//a[@class='journey-box cycling']//div/strong";
        public string walkingTime = "//a[@class='journey-box walking']//div/strong";
        public string editPreferences = "//button[normalize-space()='Edit preferences']";
        public string leastCheckBox = "//label[normalize-space()='Routes with least walking']";
        public string updateJ = "//div[@id='more-journey-options']//div//input[contains(@value,'Update journey')]";
        public string leastTime = "//div[contains(@class,'content clearfix expanded no-map')]//span[@class='time-units']/..";
        public string viweDetailsBtn = "//button[contains(.,'View details')]";
        public string accessInfo = "//div[@class='access-information'] [a[contains(@data-title, 'Up stairs')] and a[contains(@data-title, 'Up lift')] and a[contains(@data-title, 'Level walkway')]]";
        public string invalidDestinationError = "//li[contains(normalize-space(), \"Sorry, we can't find a journey\")]";


        public JourneyResults(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(14));
        }


        public async Task verifyWalkingAndCyclingTime()
        {
            await Task.Delay(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement cyclingTimeText = driver.FindElement(By.XPath(cyclingTime));
            wait.Until(d => cyclingTimeText.Displayed);
            IWebElement walkingTimeText = driver.FindElement(By.XPath(walkingTime));
            wait.Until(d => walkingTimeText.Displayed);

            double cyclingTimeNumber;
            double walkingTimeNumber;

            bool isCyclingTimeNumeric = double.TryParse(cyclingTimeText.Text, out cyclingTimeNumber);
            bool isWalkingTimeNumeric = double.TryParse(walkingTimeText.Text, out walkingTimeNumber);

            Assert.IsTrue(isCyclingTimeNumeric && isWalkingTimeNumeric);
        }



        public async Task clickEditPreferences()
        {
            await Task.Delay(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            IWebElement editP = driver.FindElement(By.XPath(editPreferences));
            wait.Until(d => editP.Displayed);
            editP.Click();
        }


        public async Task checkedRoutesWithLeastWalkingCheckbox()
        {
            await Task.Delay(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            IWebElement leastCheck = driver.FindElement(By.XPath(leastCheckBox));
            wait.Until(d => leastCheck.Displayed);
            leastCheck.Click();
        }

        public void clickUpdateJourneyButton()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));

            IWebElement uj = driver.FindElement(By.XPath(updateJ));
            wait.Until(d => uj.Displayed);
            uj.Click();
        }

        public async Task verifyLeastWalkingTime()
        {
            await Task.Delay(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            IWebElement leastTimeTextele = driver.FindElement(By.XPath(leastTime));
            wait.Until(d => leastTimeTextele.Displayed);
            string leastTimeText = leastTimeTextele.Text;
            var match = System.Text.RegularExpressions.Regex.Match(leastTimeText, @"\d+");
            Assert.IsTrue(match.Success);
        }

        public async Task clickOnTheViewDetailsButton()
        {
            await Task.Delay(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(14));
            IWebElement viweD = driver.FindElement(By.XPath(viweDetailsBtn));
            wait.Until(d => viweD.Displayed);
            viweD.Click();
        }

        public async Task verifyAccessInformationAtCoventGardenUndergroundStation()
        {
            await Task.Delay(4000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            IWebElement aI = driver.FindElement(By.XPath(accessInfo));
            wait.Until(d => aI.Displayed);
            Boolean a = aI.Displayed;
            Assert.IsTrue(a);
        }

        public async Task verifyinvalidjourneyadd()
        {
            await Task.Delay(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));

            IWebElement error = driver.FindElement(By.XPath(invalidDestinationError));
            wait.Until(d => error.Displayed);


            string val = error.Text;
            StringAssert.Contains("Sorry, we can't find a journey", val);
        }
    }
}
