using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Login login;

        private HomePage homepage;
        private MainPage mainpage;
        private ProductEditing productediting;
        private string baseUrl;

        [SetUp]
        public void Setup()
        {
            var service = ChromeDriverService.CreateDefaultService();
            driver = new ChromeDriver();
            baseUrl = "http://localhost:5000";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [SetUp]
        public void Test1_Login()
        {
            login = new Login(driver);
            homepage = login.Login_();

            Assert.True(driver.FindElement(By.XPath("//*[text()=\"Home page\"]")).Displayed);
        }

        [SetUp]
        public void HomePage_MainPage()
        {
            homepage = new HomePage(driver);
            mainpage = homepage.AP();

            Assert.True(driver.FindElement(By.XPath("//*[text()=\"All Products\"]")).Displayed);
        }

        [Test]
        public void Test2_AddProduct()
        {
            mainpage = new MainPage(driver);
            productediting = new ProductEditing(driver);
            productediting = mainpage.CreateNew();
            mainpage = productediting.CreateProduct();

            Assert.True(driver.FindElement(By.XPath("//*[text()=\"Fortune cookie\"]")).Displayed);
        }


        [Test]
        public void Test3_OpenAndCheck()
        {
            mainpage = new MainPage(driver);

            driver.FindElement(By.XPath("//a[@href][text()=\"Fortune cookie\"]")).Click();

            Assert.True(driver.FindElement(By.XPath("//input[@id=\"ProductName\"][@value=\"Fortune cookie\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/*[@selected][text()=\"Confections\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/*[@selected][text()=\"Specialty Biscuits, Ltd.\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//input[@id=\"UnitPrice\"][@value=\"3,0000\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//input[@id=\"QuantityPerUnit\"][@value=\"10 boxes x 15 pieces\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//input[@id=\"UnitsInStock\"][@value=\"1\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//input[@id=\"UnitsOnOrder\"][@value=\"3\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//input[@id=\"ReorderLevel\"][@value=\"0\"]")).Displayed);
        }

        [Test]
        public void Test4_DeleteProduct()
        {
            mainpage = new MainPage(driver);
            mainpage = mainpage.DeletePC();
        }

        [Test]
        public void Test5_Logout()
        {
            mainpage = new MainPage(driver);
            login = mainpage.Logout();

            Assert.True(driver.FindElement(By.XPath("//*[text()=\"Name\"]")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//*[text()=\"Password\"]")).Displayed);
        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}