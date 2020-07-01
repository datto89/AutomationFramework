using AutomationFramework.Base;
using AutomationFramework.Helper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Kolekto.Module
{
    public class LoginModule : ModuleBase
    {
        private const string UsernameId = "i0116";
        private const string PasswordCss = "input[placeholder='Password']";
        private const string SubmitCss = "input.btn-primary";

        public override void InitializeWebDriver(object driver, params IModule[] modules)
        {
            base.InitializeWebDriver(driver, modules);
        }

        public void LogIn(string username,string password)
        {
            FindElementById(UsernameId).EnterText(username);
            FindElementByCssSelector(SubmitCss).ClickOn();
            FindElementByCssSelector(PasswordCss).EnterText(password);
            FindElementByCssSelector(SubmitCss).ClickOn();
            FindElementByCssSelector(SubmitCss).ClickOn();
        }

        public void LogOut()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }
    }
}
