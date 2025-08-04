using nUnitAutomationTests.Pages;
using nUnitAutomationTests.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace nUnitAutomationTests.SpecFlowTests.Steps
{
    [Binding]
    public class SearchFeatureStepDefinitions
    {

        IWebDriver driver;
        LogInPage loginPage;

      /*  public SearchFeatureStepDefinitions(ScenarioContext context)
        {
            // Retrieve driver shared from Hook
            driver = (IWebDriver)context["driver"];
        }*/


        [BeforeScenario]
        public void InitDriver() => driver = DriverFactory.InitDriver();

        [AfterScenario]
        public void CleanUp() => DriverFactory.QuitDriver();


        [Given(@"I launch the website")]
        public void GivenILaunchTheWebsite()
        {
            driver.Navigate().GoToUrl("https://www.google.com");

        }

        [When(@"I put data ""([^""]*)"" in search")]
        public void WhenIPutDataInSearch(string city)
        {
            loginPage = new LogInPage(driver);
            loginPage.Search(city);



            loginPage.HitSearchButton();
        }

        [Then(@"I should see some results")]
        public void ThenIShouldSeeSomeResults()
        {
            Console.WriteLine("Pass");

            loginPage.CheckMoreLabel();
        }
    }
}
