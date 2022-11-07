using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TestFramework.Utilities.Helper;

namespace TestFramework.Utilities.Extensions
{
    public static class WebElementHelper
    {
        /// <summary>
        /// Method to select item from dropdown
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropDownList(this IWebElement element, string value)
        {
            try
            {
                SelectElement el = new SelectElement(element);
                el.SelectByText(value);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("DropDown Selection Failed"));
            }
        }

        /// <summary>
        /// Method to Assert element is present
        /// </summary>
        /// <param name="element"></param>
        public static void AsserElementIsPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element not Present Exeption"));
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        /// <summary>
        /// Method to hover over an element
        /// </summary>
        /// <param name="element"></param>
        public static void Hover(this IWebElement element)
        {
            try
            {
                Actions actions = new Actions(DriverContext.Driver);
                actions.MoveToElement(element).Perform();
                LogHelpers.WriteToFile("Hover over to ", element.ToString(), "is Successful");
            }
            catch (Exception)
            {
                LogHelpers.WriteToFile("Hover over to ", element.ToString(), "is not Successful");
                throw new Exception(string.Format("Action Cannot be performed"));

            }
        }
    }
}
