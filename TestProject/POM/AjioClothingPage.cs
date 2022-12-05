using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestFramework.Utilities.Extensions;
using TestFramework.Utilities.Helper;

namespace TestProject.POM
{
    public class AjioClothingPage
    {

        private IWebElement LnkBrand => WebDriverHelper.FindElemntByxpath("//span[normalize-space()='brands']");
        private IWebElement LnkMore => WebDriverHelper.FindElemntByxpath("//span[normalize-space()='brands']/..//following-sibling::div//div[@id='verticalsizegroupformat']");

        private IWebElement CheckBoxAazingLondon => WebDriverHelper.FindElemntByxpath("//span[normalize-space()='Aazing London']/../..");
        private IWebElement BtnApply => WebDriverHelper.FindElemntByxpath("//button[normalize-space()='Apply']");

        private IWebElement FirstProduct => WebDriverHelper.FindElemntByxpath("(//div[@class='imgHolder'])[1]//following-sibling::div[@class='contentHolder']");

        private IWebElement ProductName => WebDriverHelper.FindElemntByxpath("//h2[@class='brand-name']");
        private IWebElement ProductPrice => WebDriverHelper.FindElemntByxpath("//div[@class='prod-sp']");

        /// <summary>
        /// Method to filter out Aazing London from Brands section
        /// </summary>
        public void SelectBrand()
        {
            LnkBrand.Click();
            LnkMore.Click();
            CheckBoxAazingLondon.Click();
            BtnApply.Submit();
        }

        /// <summary>
        /// Method to return product price and description of first product
        /// </summary>
        /// <returns></returns>
        public Tuple<string, int> SelectFirstProductReturnDetails()
        {
            string parentWindowHandle = DriverContext.Driver.CurrentWindowHandle;
            FirstProduct.Click();
            List<string> listOfWindows = DriverContext.Driver.WindowHandles.ToList();
            foreach (var el in listOfWindows)
            {
                if (el != parentWindowHandle)
                    DriverContext.Driver.SwitchTo().Window(el);
            }
            int PriceOfProduct = GenericMethods.ConvertPriceStringToInt(ProductPrice.Text);


            return Tuple.Create(ProductName.Text, PriceOfProduct);
        }

        /// <summary>
        /// Method to verify the price of product is within the range provided 
        /// </summary>
        /// <param name="productPrice"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public bool VerifyPriceRange(float productPrice, double min, double max)
        {
            bool flag = false;
            if (productPrice > min && productPrice < max)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Method to select any product and return product details
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Tuple<string, int> SelectAnyProductReturnDetails(int n)
        {
            string parentWindowHandle = DriverContext.Driver.CurrentWindowHandle;
            WebDriverHelper.FindElemntByxpath($"(//div[@class='imgHolder'])[{n}]//following-sibling::div[@class='contentHolder']").Click();
            
            List<string> listOfWindows = DriverContext.Driver.WindowHandles.ToList();
            foreach (var el in listOfWindows)
            {
                if (el != parentWindowHandle)
                    DriverContext.Driver.SwitchTo().Window(el);
            }
            int PriceOfProduct = GenericMethods.ConvertPriceStringToInt(ProductPrice.Text);

            return Tuple.Create(ProductName.Text, PriceOfProduct);
        }
    }
}
