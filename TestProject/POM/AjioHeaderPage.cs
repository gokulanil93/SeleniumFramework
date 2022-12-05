using OpenQA.Selenium;
using TestFramework.Utilities.Extensions;

namespace TestProject.POM
{
    public class AjioHeaderPage
    {
        private IWebElement LnkMen => WebDriverHelper.FindElemntByxpath("//a[@title='MEN']");
        private IWebElement LnkClothing => WebDriverHelper.FindElemntByxpath("//li[contains(@data-test,'li-MEN')]//span[contains(text(),'CLOTHING')]");

        /// <summary>
        /// Method to select clothing from under Men section from Header
        /// </summary>
        public void SelectClothing()
        {
            WebElementHelper.Hover(LnkMen);
            LnkClothing.Click();
        }
    }
}
