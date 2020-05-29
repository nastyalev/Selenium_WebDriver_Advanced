using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{

    class ProductEditing
    {
        private IWebDriver driver;

        public ProductEditing(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductName => driver.FindElement(By.Id("ProductName"));
        private IWebElement UnitPrice => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement QuantityPerUnit => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement UnitsInStock => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement UnitsOnOrder => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement ReorderLevel => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement ButtonSend => driver.FindElement(By.XPath("//*[@type=\"submit\"]"));

        public MainPage CreateProduct()
        {
            new Actions(driver).SendKeys(ProductName, "Fortune cookie").Build().Perform();

            driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/*[@value][text()=\"Confections\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/*[@value][text()=\"Specialty Biscuits, Ltd.\"]")).Click();

            new Actions(driver).Click(UnitPrice).SendKeys("3").Build().Perform();
            new Actions(driver).Click(QuantityPerUnit).SendKeys("10 boxes x 15 pieces").Build().Perform();
            new Actions(driver).Click(UnitsInStock).SendKeys("1").Build().Perform();
            new Actions(driver).Click(UnitsOnOrder).SendKeys("3").Build().Perform();
            new Actions(driver).Click(ReorderLevel).SendKeys("0").Build().Perform();

            new Actions(driver).Click(ButtonSend).Build().Perform();
            return new MainPage(driver);
        }

        public bool GetProductName()
        {
            IWebElement NewProductName = driver.FindElement(By.XPath("//input[@id=\"ProductName\"][@value=\"Fortune cookie\"]"));
            return NewProductName.Displayed;
        }

        public bool GetCategory()
        {
            IWebElement NewCategory = driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/*[@selected][text()=\"Confections\"]"));
            return NewCategory.Displayed;
        }
        public bool GetSupplier()
        {
            IWebElement NewSupplier = driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/*[@selected][text()=\"Specialty Biscuits, Ltd.\"]"));
            return NewSupplier.Displayed;
        }

        public bool GetUnitPrice()
        {
            IWebElement NewUnitPrice = driver.FindElement(By.XPath("//input[@id=\"UnitPrice\"][@value=\"3,0000\"]"));
            return NewUnitPrice.Displayed;
        }

        public bool GetQuantityPerUnit()
        {
            IWebElement NewQuantityPerUnit = driver.FindElement(By.XPath("//input[@id=\"QuantityPerUnit\"][@value=\"10 boxes x 15 pieces\"]"));
            return NewQuantityPerUnit.Displayed;
        }

        public bool GetUnitsInStock()
        {
            IWebElement NewUnitsInStock = driver.FindElement(By.XPath("//input[@id=\"UnitsInStock\"][@value=\"1\"]"));
            return NewUnitsInStock.Displayed;
        }

        public bool GetUnitsOnOrder()
        {
            IWebElement NewUnitsOnOrder = driver.FindElement(By.XPath("//input[@id=\"UnitsOnOrder\"][@value=\"3\"]"));
            return NewUnitsOnOrder.Displayed;
        }

        public bool GetReorderLevel()
        {
            IWebElement NewReorderLevel = driver.FindElement(By.XPath("//input[@id=\"ReorderLevel\"][@value=\"0\"]"));
            return NewReorderLevel.Displayed;
        }
    }
}
