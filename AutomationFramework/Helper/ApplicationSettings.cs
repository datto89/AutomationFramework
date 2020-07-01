using AutomationFramework.Base;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutomationFramework.Helper
{
    public class ApplicationSettings
    {        
        public ApplicationSettings()
        {
            var config = new ConfigurationBuilder()
             .AddJsonFile("AppConfig.json")
             .Build();

            ActionTimeout = int.Parse(config["ActionTimeoutInSecond"]);
            KolektoIntegration = config["KolektoIntegration"];
            KolektoStaging = config["KolektoStaging"];
            RunOnBrowser = (BrowserType)Enum.Parse(typeof(BrowserType), config["RunOnBrowser"]);
            ReportOutput = config["ReportOutput"];
            ClearOldScreenshot = bool.Parse(config["ClearOldScreenshotsWhenRunning"]);
        }

        public static int ActionTimeout { get; set; }

        public static string KolektoIntegration { get; set; }

        public static string KolektoStaging { get; set; }

        public static BrowserType RunOnBrowser { get; set; }
        public static string ReportOutput { get; set; }
        public static bool ClearOldScreenshot { get; set; }
        public static string ReportScreenshotOutput { get { return Path.Combine(ReportOutput, @"\Screenshot"); } }
    }
}
