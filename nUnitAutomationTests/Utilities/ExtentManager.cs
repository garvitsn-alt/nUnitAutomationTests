using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitAutomationTests.Utilities
{
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Reporter;
    using System;
    using System.IO;

    
        public static class ExtentReportManager
        {
            private static ExtentReports _extent;
            private static ExtentHtmlReporter _htmlReporter;

            // Singleton-like getter to ensure one report instance across the whole test run
            public static ExtentReports GetExtent()
            {
                if (_extent == null)
                {
                    // Generate dynamic file name with timestamp
                    string dir = AppDomain.CurrentDomain.BaseDirectory;
                    string reportPath = Path.Combine(dir, "TestReports", $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                    Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

                    // Create the reporter and attach to extent
                    _htmlReporter = new ExtentHtmlReporter(reportPath);
                    _extent = new ExtentReports();
                    _extent.AttachReporter(_htmlReporter);

                    // Optional info shown in report
                    _extent.AddSystemInfo("Environment", "QA");
                    _extent.AddSystemInfo("User", "Garvit Saini");
                }

                return _extent;
            }

            // Flush ensures all logs are written and file is saved
            public static void Flush()
            {
                _extent?.Flush();
            }
        }
    }

