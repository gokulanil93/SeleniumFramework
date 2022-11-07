using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestFramework.Config;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.Utilities.Helper
{
    public class BrowserSetUp
    {
        /// <summary>
        /// Method to select browser based on Framework settings
        /// </summary>
        public static void ConfigureBrowser()
        {
            switch (Settings.BrowserType)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    DriverContext.Driver = new ChromeDriver();
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    DriverContext.Driver = new FirefoxDriver();
                    break;
            }
        }
    }
}
