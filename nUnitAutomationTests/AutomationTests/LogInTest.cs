using nUnitAutomationTests.Pages;
using nUnitAutomationTests.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitAutomationTests.AutomationTests
{
    public class LogInTest
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {

            driver = DriverFactory.InitDriver();
        }

        [Test]
        public void LogInValidate()
        {
            driver.Navigate().GoToUrl("https://www.google.com");

            var loginPage = new LogInPage(driver);
            
            loginPage.Search("student");

            string actualUrl = driver.Url;

      

        }

        [TearDown]
        public void TearDown() {
        
            driver.Dispose();
        }



    }
}
