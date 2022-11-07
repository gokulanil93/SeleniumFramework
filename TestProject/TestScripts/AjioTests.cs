using NUnit.Framework;
using System;
using TestFramework.Utilities.Helper;
using TestFramework.Utilities.Hooks;

namespace TestProject.POM
{
    [TestFixture]
    public class AjioTests : HooksClass
    {
        [Test, Category("Smoke Testing")]
        public void AjioTest()
        {
            AjioHeaderPage ajioHeaderPageObj = new AjioHeaderPage();
            ajioHeaderPageObj.SelectClothing();
            AjioClothingPage ajioClothingPageObj = new AjioClothingPage();
            ajioClothingPageObj.SelectBrand();
            var productDetails = ajioClothingPageObj.SelectFirstProductReturnDetails();
            bool flag = ajioClothingPageObj.VerifyPriceRange(productDetails.Item2, 2000, 900);

            //soft Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExcelHelpers.ExcelReader(TestContext.CurrentContext.Test.Name).ProductName, productDetails.Item1, "Product is different");
                Assert.True(flag, "Price not in Range");
                Console.WriteLine("Test Passed");

            });
        }

        [Test, Category("Regression Testing")]
        public void AjioTestToVerifyThirdProduct()
        {
            AjioHeaderPage ajioHeaderPageObj = new AjioHeaderPage();
            ajioHeaderPageObj.SelectClothing();
            AjioClothingPage ajioClothingPageObj = new AjioClothingPage();
            ajioClothingPageObj.SelectBrand();
            var productDetails = ajioClothingPageObj.SelectAnyProductReturnDetails(3);
            bool flag = ajioClothingPageObj.VerifyPriceRange(productDetails.Item2, 2000, 900);

            //soft Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ExcelHelpers.ExcelReader(TestContext.CurrentContext.Test.Name).ProductName, productDetails.Item1, "Product is different");
                Assert.True(flag, "Price not in Range");
                Console.WriteLine("Test Passed");

            });
        }
    }
}
