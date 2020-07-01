using AutomationFramework.Base;
using AutomationFramework.Helper;
using AutomationFramework.Reports;
using AventStack.ExtentReports.Model;
using Kolekto.Module;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kolekto
{
    public class TestBase
    {
        private LoginModule loginModule = new LoginModule();
        private TestContext TestContext { get; set; }

        protected virtual string TestCatagories => string.Empty;
        protected void StartApplication(params IModule[] modules)
        {
            ApplicationSettings applicationSettings = new ApplicationSettings();
            InitializeReport();            
            InitializeWebDriver(ApplicationSettings.KolektoIntegration);

            Reports.CurrentTest.Info($"{nameof(StartApplication)}");
        }

        public void LogInToSystem(string username,string password)
        {
            loginModule.LogIn(username, password);
        }

        public void LogOut()
        {
            loginModule.LogOut();
        }
        
        private void InitializeWebDriver(string url,params IModule[] modules)
        {
            var driver = WebBrowserFactory.CreateWebDriver(ApplicationSettings.RunOnBrowser);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ApplicationSettings.ActionTimeout);
            driver.Navigate().GoToUrl(url);
            loginModule.InitializeWebDriver(driver);            
            foreach (var module in modules)
            {
                module.InitializeWebDriver(driver);
            }
        }

        private void InitializeReport()
        {
            Reports.SetupReport();
            Reports.CreateTest(TestContext.CurrentContext.Test.Name, TestCatagories);            
        }

        //public override TestResult[] Execute(ITestMethod testMethod)
        //{
        //    TestResult[] testResults = base.Execute(testMethod);

        //    Reports.CurrentTest.Model.Description = description;
        //    foreach (var result in testResults)
        //    {
        //        if (result.Outcome == UnitTestOutcome.Passed)
        //        {
        //            Reports.CurrentTest.Pass(result.Outcome.ToString());
        //        }
        //        else
        //        {
        //            Reports.CurrentTest.Fail($@"<h5 class=""text-fail"">{result.Outcome.ToString()} - {result.TestFailureException.Message} </h5> <pre>{result.TestFailureException.ToString()}</pre>");
        //        }
        //    }

        //    Reports.GenerateReport();

        //    return testResults;
        //}
    }
}
