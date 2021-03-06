﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Helper
{
    public static class WebElementExtension
    {
        public static void EnterText(this IWebElement element,string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static void ClickOn(this IWebElement element)
        {
            var actions = GetActions(element);
            actions.MoveToElement(element)
                .Click(element)
                .Build().Perform();
        }

        private static Actions GetActions(IWebElement element)
        {
            var driver = ((RemoteWebElement)element).WrappedDriver;
            return new Actions(driver);
        }
    }
}
