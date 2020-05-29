using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab
{
    class MainPage
    {
        //главная страница (AllProducts)
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Main_page => driver.FindElement(By.XPath("//*[text()=\"ProductId\"]"));
        private IWebElement product => driver.FindElement(By.XPath("//*[text()=\"Fortune cookie\"]"));

        public ProductEditing CreateNew()
        {
            new Actions(driver).Click(driver.FindElement(By.XPath("//*[@href=\"/Product/Create\"]"))).Build().Perform();
            return new ProductEditing(driver);
        }

        public MainPage DeleteFortuneCookie()
        {
            new Actions(driver).Click(driver.FindElement(By.XPath("//*[text()=\"Fortune cookie\"]//..//..//a[text()=\"Remove\"]"))).Build().Perform();
            driver.SwitchTo().Alert().Accept();
            return new MainPage(driver);
        }

        public Login Logout()
        {
            new Actions(driver).Click(driver.FindElement(By.XPath("//*[@href=\"/Account/Logout\"]"))).Build().Perform();
            return new Login(driver);
        }

        public FortuneCookie GetFortuneCookie()
        {
            new Actions(driver).Click(driver.FindElement(By.XPath(" //*[text()=\"Fortune cookie\"]/../..//../*[text()=\"Edit\"]"))).Build().Perform();
            return new FortuneCookie(driver);
        }

        public string GetMainPage()
        {
            return Main_page.Text;
        }

        public string AssertAddProduct()
        {
            return product.Text;
        }
    }
}
