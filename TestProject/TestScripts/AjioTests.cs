using NUnit.Framework;
using System;
using TestFramework.Utilities.Helper;
using TestFramework.Utilities.Hooks;

namespace TestProject.POM
{
    [TestFixture]
    public class AjioTests : HooksClass
    {
        [Test, Category("Smoke Testing"), Retry(2)]
        public void AjioTest()
        {
            ExcelDataModel excelDataModelObj = ExcelHelpers.ExcelReader(TestContext.CurrentContext.Test.Name);
            AjioHeaderPage ajioHeaderPageObj = new AjioHeaderPage();
            ajioHeaderPageObj.SelectClothing();
            AjioClothingPage ajioClothingPageObj = new AjioClothingPage();
            ajioClothingPageObj.SelectBrand();
            var productDetails = ajioClothingPageObj.SelectFirstProductReturnDetails();
            bool flag = ajioClothingPageObj.VerifyPriceRange(productDetails.Item2, excelDataModelObj.Min, excelDataModelObj.Max);

            //soft Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(excelDataModelObj.ProductName, productDetails.Item1, "Product is different");
                Assert.True(flag, "Price not in Range");
                Console.WriteLine("Test Passed");
            });
        }

        [Test, Category("Regression Testing"), Retry(2)]
        public void AjioTestToVerifyThirdProduct()
        {
            ExcelDataModel excelDataModelObj = ExcelHelpers.ExcelReader(TestContext.CurrentContext.Test.Name);
            AjioHeaderPage ajioHeaderPageObj = new AjioHeaderPage();
            ajioHeaderPageObj.SelectClothing();
            AjioClothingPage ajioClothingPageObj = new AjioClothingPage();
            ajioClothingPageObj.SelectBrand();
            var productDetails = ajioClothingPageObj.SelectAnyProductReturnDetails(3);
            bool flag = ajioClothingPageObj.VerifyPriceRange(productDetails.Item2, excelDataModelObj.Min, excelDataModelObj.Max);

            //soft Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(excelDataModelObj.ProductName, productDetails.Item1, "Product is different");
                Assert.True(flag, "Price not in Range");
                Console.WriteLine("Test Passed");
            });
        }
    }
}
