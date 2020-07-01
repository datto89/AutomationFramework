using AutomationFramework.Helper;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace AutomationFramework.Reports
{
    public class Reports
    {
        private static AventStack.ExtentReports.ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;
        public static ExtentTest CurrentTest { get; private set; }

        public static void SetupReport()
        {
            if (extent == null)
            {
                var testOutput = ApplicationSettings.ReportOutput;
                if (!Directory.Exists(testOutput))
                {
                    Directory.CreateDirectory(testOutput);
                }

                var screenshotPath = ApplicationSettings.ReportScreenshotOutput;
                if (!Directory.Exists(screenshotPath))
                {
                    Directory.CreateDirectory(screenshotPath);
                }
                else if (ApplicationSettings.ClearOldScreenshot)
                {
                    var di = new DirectoryInfo(screenshotPath);
                    foreach (var item in di.GetFiles())
                    {
                        item.Delete();
                    }
                }

                htmlReporter = new ExtentHtmlReporter(testOutput);
                htmlReporter.Config.DocumentTitle = "KolektoHuur";
                htmlReporter.Config.ReportName = "Kolekto Test Report";

                extent = new AventStack.ExtentReports.ExtentReports();
                extent.AddSystemInfo("Kolekto Integration",ApplicationSettings.KolektoIntegration);
                extent.AddSystemInfo("Kolekto Staging", ApplicationSettings.KolektoStaging);
                extent.AttachReporter(htmlReporter);
            }
        }

        public static ExtentTest CreateTest(string name,string categories,string description="")
        {
            var test = extent.CreateTest(name, description);

            if (!string.IsNullOrEmpty(categories))
            {
                test.AssignCategory(categories.Split(","));
            }

            CurrentTest = test;
            return test;
        }

        public static void GenerateReport()
        {
            extent.Flush();
        }
    }
}
