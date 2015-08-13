﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System.IO;
using System.Linq;

namespace EPPlusTest
{
    [TestClass]
    public abstract class TestBase
    {
        protected ExcelPackage _pck;        
        protected string _worksheetPath="";
        public TestContext TestContext { get; set; }
        
        [TestInitialize]
        public void InitBase()
        {

            _worksheetPath = AppDomain.CurrentDomain.BaseDirectory + @"\..\..\worksheets";
            if (!Directory.Exists(_worksheetPath))
            {
                Directory.CreateDirectory(_worksheetPath);
            }
            var di=new DirectoryInfo(_worksheetPath);            
            _worksheetPath = di.FullName + "\\";

            _pck = new ExcelPackage();
        }        
        protected void OpenPackage(string name)
        {
            var fi = new FileInfo(_worksheetPath + name);
            _pck = new ExcelPackage(fi);
        }
        protected void SaveWorksheet(string name)
        {
            if (_pck.Workbook.Worksheets.Count == 0) return;
            var fi = new FileInfo(_worksheetPath + name);
            if (fi.Exists)
            {
                fi.Delete();
            }
            _pck.SaveAs(fi);
        }

        /// <returns>The path to the Microsoft Office Clipart directory or an empty string if that isn't found.</returns>
        [Obsolete("Create some clipart")]
        protected string GetClipartPath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
