using nUnitAutomationTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private WebDriverWait _wait;

        public LogInPage(IWebDriver driver) => this.driver = driver;
        private IWebElement searchBox => driver.FindElement(By.XPath("(//textarea)[1]"));
        private IWebElement ButtonLogIn => driver.FindElement(By.XPath("(//*[@name='btnK'])[2]"));
        private IWebElement SearchButton => driver.FindElement(By.XPath("(//input[@value='Google Search'])[1]"));
        private IWebElement MoreLabel => driver.FindElement(By.XPath("//div/span[contains(text(),'More')]"));

        


        public void Search(string data)
        {
            searchBox.SendKeys(data);
            //ButtonLogIn.Click();

        }

        public void HitSearchButton()
        {
            Thread.Sleep(2000);

            SafeClick(SearchButton);
           

        }

        public void CheckMoreLabel()
        {
            string labelText = MoreLabel.Text;

            if(labelText.Equals("More", StringComparison.OrdinalIgnoreCase))
            {

                Assert.Pass();
            }
            else
            {
                Assert.Fail();
                
            }


        }



        public void SafeClick(IWebElement locator)
        {
            try
            {
                // Wait until the element is clickable
               // IWebElement element = _wait.Until(ExpectedConditions.ElementToBeClickable(locator));

                // Scroll into view if necessary
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", locator);

                // Small pause to let scroll settle (optional)
                Thread.Sleep(200);

                // Try clicking
                locator.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // Fallback: use JavaScript to click
               // IWebElement fallbackElement = driver.FindElement(locator);
              //  ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", fallbackElement);
            }
        }

    }
}
