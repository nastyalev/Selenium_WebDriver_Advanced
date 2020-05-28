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

        public string GetProductName()
        {
            IWebElement ProductName = driver.FindElement(By.XPath("//input[@id=\"ProductName\"][@value=\"Fortune cookie\"]"));
            Assert.True(ProductName.Displayed);
            return ProductName.Text;
        }

        public string GetCategory()
        {
            IWebElement Category = driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/*[@selected][text()=\"Confections\"]"));
            Assert.True(Category.Displayed);
            return Category.Text;
        }
        public string GetSupplier()
        {
            IWebElement Supplier = driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/*[@selected][text()=\"Specialty Biscuits, Ltd.\"]"));
            Assert.True(Supplier.Displayed);
            return Supplier.Text;
        }

        public string GetUnitPrice()
        {
            IWebElement UnitPrice = driver.FindElement(By.XPath("//input[@id=\"UnitPrice\"][@value=\"3,0000\"]"));
            Assert.True(UnitPrice.Displayed);
            return UnitPrice.Text;
        }

        public string GetQuantityPerUnit()
        {
            IWebElement QuantityPerUnit = driver.FindElement(By.XPath("//input[@id=\"QuantityPerUnit\"][@value=\"10 boxes x 15 pieces\"]"));
            Assert.True(QuantityPerUnit.Displayed);
            return QuantityPerUnit.Text;
        }

        public string GetUnitsInStock()
        {
            IWebElement UnitsInStock = driver.FindElement(By.XPath("//input[@id=\"UnitsInStock\"][@value=\"1\"]"));
            Assert.True(UnitsInStock.Displayed);
            return UnitsInStock.Text;
        }

        public string GetUnitsOnOrder()
        {
            IWebElement UnitsOnOrder = driver.FindElement(By.XPath("//input[@id=\"UnitsOnOrder\"][@value=\"3\"]"));
            Assert.True(UnitsOnOrder.Displayed);
            return UnitsOnOrder.Text;
        }

        public string GetReorderLevel()
        {
            IWebElement ReorderLevel = driver.FindElement(By.XPath("//input[@id=\"ReorderLevel\"][@value=\"0\"]"));
            Assert.True(ReorderLevel.Displayed);
            return ReorderLevel.Text;
        }
    }
}