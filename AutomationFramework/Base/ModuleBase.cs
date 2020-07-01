using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Base
{
    public class ModuleBase : SeleniumBase,IModule
    {
        public virtual void InitializeWebDriver(object driver, params IModule[] modules)
        {
            InitialWebDriver(driver as IWebDriver);
            foreach (var module in modules)
            {
                module.InitializeWebDriver(driver);
            }
        }
    }
}
