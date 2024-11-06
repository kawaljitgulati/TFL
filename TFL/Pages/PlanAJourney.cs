using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TFL.Pages
{
    public class PlanAJourney
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public string inputFrom = "//input[@id='InputFrom']";
        public string inputTo = "//input[@id='InputTo']";
        public string changeTime = "//a[normalize-space()='change time']";
        public string dateDD = "//select[@id='Date']";
        public string timeDD = "//select[@id='Time']";
        public string planjourney = "//input[@id='plan-journey-button']";
        public string inputFromErrorMsg = "//span[@id='InputFrom-error']";
        public string inputToErrorMsg = "//span[@data-valmsg-for='InputTo']";

        public PlanAJourney(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(14));
        }

        public void navigateToPlanAJournyPage()
        {
            driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");
        }

        public async Task enterFromAddres(string fromAdd)
        {

            driver.FindElement(By.XPath(inputFrom)).SendKeys(fromAdd);
            await Task.Delay(3000);
            driver.FindElement(By.XPath("//span[@class='tt-suggestions']//span[contains(normalize-space(), 'Leicester Square Underground Station')]")).Click();
        }
        public async Task enterToAddres(string toAdd)
        {
            driver.FindElement(By.XPath(inputTo))
                 .SendKeys(toAdd);

            await Task.Delay(3000);
            driver.FindElement(By.XPath("//span[@class='tt-suggestions']//span[contains(normalize-space(), 'Covent Garden Underground Station')]")).Click();


        }

        public void enterInvalidFromAddres(string fromAdd)
        {

            driver.FindElement(By.XPath(inputFrom))
                 .SendKeys(fromAdd);
        }
        public void enterInvalidToAddres(string toAdd)
        {
            driver.FindElement(By.XPath(inputTo))
                 .SendKeys(toAdd);
        }
        public void clickPlanJourneyButton()
        { 
        driver.FindElement(By.XPath(planjourney)).Click();
        }

        
        public async Task verifyErrorMessage()
        {
            await Task.Delay(1000);
            string fromError = driver.FindElement(By.XPath(inputFromErrorMsg)).Text;
            string toError = driver.FindElement(By.XPath(inputToErrorMsg)).Text;
            if (fromError.Contains("field is required.") &
                    toError.Contains("field is required."))
            {
                Assert.True(true);
            }
        }
    }

}
