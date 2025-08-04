using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitAutomationTests.Hooks
{
    using AventStack.ExtentReports;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using nUnitAutomationTests.Utilities;

   
        [Binding]
        public class SpecFlowHooks
        {
            // Static for report instance and feature-level logging
            private static ExtentReports _extent;
            private static ExtentTest _feature;

            // Non-static so it's different per scenario
            private static ExtentTest _scenario;

            private IWebDriver _driver;
            private readonly ScenarioContext _scenarioContext;
            private readonly FeatureContext _featureContext;

            public SpecFlowHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
            {
                _scenarioContext = scenarioContext;
                _featureContext = featureContext;
            }

            [BeforeTestRun]
            public static void BeforeTestRun()
            {
                // Create report once before all tests
                _extent = ExtentReportManager.GetExtent();
            }

            [BeforeFeature]
            public static void BeforeFeature(FeatureContext featureContext)
            {
                // Create node for each feature
                _feature = _extent.CreateTest(featureContext.FeatureInfo.Title);
            }

            [BeforeScenario]
            public void BeforeScenario()
            {
                // Create node for each scenario under the feature
                _scenario = _feature.CreateNode(_scenarioContext.ScenarioInfo.Title);

                // Share the test instance to steps if needed
                _scenarioContext["extentTest"] = _scenario;

                // Initialize driver (or use DriverFactory if available)
                _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                _scenarioContext["driver"] = _driver;
            }

            [AfterStep]
            public void AfterStep()
            {
                var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
                var stepText = _scenarioContext.StepContext.StepInfo.Text;

                // Log each step result in the report
                if (_scenarioContext.TestError == null)
                {
                    _scenario.CreateNode(stepType, stepText).Pass("Step passed.");
                }
                else
                {
                    _scenario.CreateNode(stepType, stepText)
                             .Fail(_scenarioContext.TestError.Message);
                }
            }

            [AfterScenario]
            public void AfterScenario()
            {
                // Quit driver after each scenario
                if (_scenarioContext.ContainsKey("driver"))
                {
                    var driver = (IWebDriver)_scenarioContext["driver"];
                    driver.Quit();
                }
            }

            [AfterTestRun]
            public static void AfterTestRun()
            {
                // Finalize the report and write file
                ExtentReportManager.Flush();
            }
        }
    }

