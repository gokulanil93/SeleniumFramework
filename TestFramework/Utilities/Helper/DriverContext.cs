using OpenQA.Selenium;

namespace TestFramework.Utilities.Helper
{
    public static class DriverContext
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver { get => _driver; set => _driver = value; }
    }
}
