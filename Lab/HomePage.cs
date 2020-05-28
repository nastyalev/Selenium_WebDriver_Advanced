﻿using NUnit.Framework;
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

        private IWebElement allproducts => driver.FindElement(By.XPath("//*[@href=\"/Product\"]"));

        private IWebElement allcategories => driver.FindElement(By.XPath("//*[@href=\"/Category\"]"));
  
        public MainPage AllProducts()
        {
            new Actions(driver).Click().Click(allproducts).Build().Perform();
            return new MainPage(driver);
        }

        public void GetHomePage()
        {
            IWebElement str = driver.FindElement(By.XPath("//*[text()=\"Home page\"]"));
            String Home_page = str.Text;
            Assert.True(Home_page.Equals("Home page"));
        }
    }
}
