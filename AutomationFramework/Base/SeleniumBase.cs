using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using WaitHelper = SeleniumExtras.WaitHelpers;

namespace AutomationFramework.Base
{
    public class SeleniumBase
    {
        protected IWebDriver WebDriver { get; private set; }

        protected IJavaScriptExecutor JsExecute { get; private set; }

        protected void InitialWebDriver(IWebDriver driver)
        {
            WebDriver = driver;
            JsExecute = (IJavaScriptExecutor)WebDriver;
        }

        protected IWebElement FindElement(By locator)
        {
            return WebDriver.FindElement(locator);
        }

        protected IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return WebDriver.FindElements(locator);
        }

        protected IWebElement FindElementById(string id)
        {
            try
            {
                return FindElement(By.Id(id));
            }
            catch 
            {
                return null;
            }
        }

        protected IWebElement FindElementByName(string name)
        {
            try
            {
                return FindElement(By.Name(name));
            }
            catch
            {
                return null;
            }
        }

        protected IWebElement FindElementByClassName(string className)
        {
            try
            {
                return FindElement(By.ClassName(className));
            }
            catch
            {
                return null;
            }
        }

        protected IWebElement FindElementByXPath(string xPath)
        {
            try
            {
                return FindElement(By.XPath(xPath));
            }
            catch
            {
                return null;
            }
        }

        protected IWebElement FindElementByCssSelector(string css)
        {
            try
            {
                return FindElement(By.CssSelector(css));
            }
            catch
            {
                return null;
            }
        }

        protected void CloseTab()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }

        /// <summary>
        /// Wait until element is clickable. Default timeout is 3 seconds.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        protected IWebElement WaitUntilElementClickable(IWebElement element, TimeSpan? timeout = null)
        {
            if (timeout == null) { timeout = TimeSpan.FromSeconds(5); }
            
            WebDriverWait wait = new WebDriverWait(WebDriver, timeout.Value);

            var defaultTimeout = WebDriver.Manage().Timeouts().ImplicitWait;
            WebDriver.Manage().Timeouts().ImplicitWait = timeout.Value;

            try
            {
                return wait.Until(WaitHelper.ExpectedConditions.ElementToBeClickable(element));
            }
            catch
            {
                return null;
            }
            finally
            {
                WebDriver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            }
        }
    }
}
