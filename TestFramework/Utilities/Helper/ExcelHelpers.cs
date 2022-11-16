using NPOI.XSSF.UserModel;
using System;
using System.IO;

namespace TestFramework.Utilities.Helper
{
    public static class ExcelHelpers
    {
        /// <summary>
        /// Method to Read excel and return data based on the key provided
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ExcelDataModel ExcelReader(string key)
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;

            string location = projectPath + "TestData\\Login.xlsx";
            //Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "TestData\\Login.xlsx");

            XSSFWorkbook excel = new XSSFWorkbook(File.Open(location, FileMode.Open));

            var sheet = excel.GetSheetAt(0);// Selecting the desired sheet
            ExcelDataModel obj = new ExcelDataModel();
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                obj.Key = row.GetCell(0).StringCellValue;
                if (obj.Key == key)
                {
                    obj.ProductName = row.GetCell(1).StringCellValue;
                    //obj.Password = row.GetCell(2).StringCellValue;
                }
            }
            return obj;
        }
    }

    public class ExcelDataModel
    {
        public string Key { get; set; }
        public string ProductName { get; set; }
        //public string Password { get; set; }
    }
}
