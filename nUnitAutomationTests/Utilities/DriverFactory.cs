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

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            return driver;

            
        }

        internal static void QuitDriver()
        {
           driver.Quit();
        }
    }
}
