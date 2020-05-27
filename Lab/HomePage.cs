using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement AllProducts => driver.FindElement(By.XPath("//*[@href=\"/Product\"]"));

        private IWebElement AllCategories => driver.FindElement(By.XPath("//*[@href=\"/Category\"]"));

        public MainPage AP()
        {
            new Actions(driver).Click().Click(AllProducts).Build().Perform();
            return new MainPage(driver);
        }

    }
}
