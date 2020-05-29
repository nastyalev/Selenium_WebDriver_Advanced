using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Lab
{

    class FortuneCookie
    {
        private IWebDriver driver;

        public FortuneCookie(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductName => driver.FindElement(By.XPath("//input[@id=\"ProductName\"][@value=\"Fortune cookie\"]"));
        private IWebElement Category => driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/*[@selected][text()=\"Confections\"]"));
        private IWebElement Supplier => driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/*[@selected][text()=\"Specialty Biscuits, Ltd.\"]"));
        private IWebElement UnitPrice => driver.FindElement(By.XPath("//input[@id=\"UnitPrice\"][@value=\"3,0000\"]"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.XPath("//input[@id=\"QuantityPerUnit\"][@value=\"10 boxes x 15 pieces\"]"));
        private IWebElement UnitsInStock => driver.FindElement(By.XPath("//input[@id=\"UnitsInStock\"][@value=\"1\"]"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.XPath("//input[@id=\"UnitsOnOrder\"][@value=\"3\"]"));
        private IWebElement ReorderLevel => driver.FindElement(By.XPath("//input[@id=\"ReorderLevel\"][@value=\"0\"]"));

        public bool GetProductName()
        {
            return ProductName.Displayed;
        }

        public bool GetCategory()
        {
            return Category.Displayed;
        }
        public bool GetSupplier()
        {
            return Supplier.Displayed;
        }

        public bool GetUnitPrice()
        {
            return UnitPrice.Displayed;
        }

        public bool GetQuantityPerUnit()
        {
            return QuantityPerUnit.Displayed;
        }

        public bool GetUnitsInStock()
        {
            return UnitsInStock.Displayed;
        }

        public bool GetUnitsOnOrder()
        {
            return UnitsOnOrder.Displayed;
        }

        public bool GetReorderLevel()
        {
            return ReorderLevel.Displayed;
        }
    }
}