using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitAutomationTests.Utilities
{
    public class DriverFactory
    {
        public static IWebDriver driver;

        public static IWebDriver InitDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;

            
        }

        internal static void QuitDriver()
        {
           driver.Quit();
        }
    }
}
