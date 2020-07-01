using AutomationFramework.Base;
using AutomationFramework.Helper;
using Kolekto.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kolekto
{
    public class TestBase
    {
        private LoginModule loginModule = new LoginModule();

        public void StartApplication(params IModule[] modules)
        {
            ApplicationSettings applicationSettings = new ApplicationSettings();
            InitializeWebDriver(ApplicationSettings.KolektoIntegration);
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
    }
}
