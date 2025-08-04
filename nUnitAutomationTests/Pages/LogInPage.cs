using nUnitAutomationTests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitAutomationTests.Pages
{
    public class LogInPage 
    {
        private IWebDriver driver;
        public LogInPage(IWebDriver driver) => this.driver = driver;
        private IWebElement searchBox => driver.FindElement(By.XPath("(//textarea)[1]"));
        private IWebElement ButtonLogIn => driver.FindElement(By.XPath("(//*[@name='btnK'])[2]"));




        public void Search(string data)
        {
            searchBox.SendKeys(data);
            ButtonLogIn.Click();

        }

    }
}
