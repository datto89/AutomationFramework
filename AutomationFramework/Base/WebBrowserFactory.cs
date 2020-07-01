using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace AutomationFramework.Base
{
    public class WebBrowserFactory
    {
        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                    
                case BrowserType.Firefox:
                    return new FirefoxDriver();

                case BrowserType.IE:
                    return new InternetExplorerDriver();

                default:
                    throw new NotSupportedException("This driver is not supported!");
            }
        }
    }
}
