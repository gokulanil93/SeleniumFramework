using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TestFramework.Config;
using TestFramework.Utilities.Helper;

namespace TestFramework.Utilities.Extensions
{
    public static class WebDriverBase
    {
        /// <summary>
        /// Method to Initialise browser with the help of framework settings and navigate to URL
        /// </summary>
        public static void OpenBrowser()
        {
            BrowserSetUp.ConfigureBrowser();
            DriverContext.Driver.Navigate().GoToUrl(Settings.URL);
            DriverContext.Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Method to close browser by quiting the webdriver instance
        /// </summary>
        public static void CloseBrowser()
        {
            DriverContext.Driver.Quit();
        }

        /// <summary>
        /// generic method to handle implicit wait 
        /// </summary>
        public static void ImplicitWait()
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        }

        /// <summary>
        /// Method to find an element using any given locator after verifying visibility of element using explicit wait
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        public static void ExplicitWait(string type, string value, int timeSpan)
        {
            if (type == "xpath")
            {
                WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(timeSpan));
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(value))));
            }
        }
    }
}
