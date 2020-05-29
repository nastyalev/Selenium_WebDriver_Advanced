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
        private FortuneCookie fortunecookie;
        private string baseUrl;

        private const string HomePage_ = "Home page";
        private const string ProductId_ = "ProductId";
        private const string ProductName_ = "Fortune cookie";

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

            Assert.AreEqual(HomePage_, homepage.GetHomePage());
        }

        [SetUp]
        public void HomePage_MainPage()
        {
            homepage = new HomePage(driver);
            mainpage = homepage.AllProducts();

            Assert.AreEqual(ProductId_, mainpage.GetMainPage());
        }


        [Test]
        public void Test2_AddProduct()
        {
            mainpage = new MainPage(driver);
            productediting = new ProductEditing(driver);
            productediting = mainpage.CreateNew();
            mainpage = productediting.CreateProduct();

            Assert.AreEqual(ProductName_, mainpage.AssertAddProduct());
        }


        [Test]
        public void Test3_OpenAndCheck()
        {
            mainpage = new MainPage(driver);
            fortunecookie = mainpage.GetFortuneCookie();

            Assert.True(fortunecookie.GetProductName());
            Assert.True(fortunecookie.GetCategory());
            Assert.True(fortunecookie.GetSupplier());
            Assert.True(fortunecookie.GetUnitPrice());
            Assert.True(fortunecookie.GetQuantityPerUnit());
            Assert.True(fortunecookie.GetUnitsInStock());
            Assert.True(fortunecookie.GetUnitsOnOrder());
            Assert.True(fortunecookie.GetReorderLevel());
        }

        [Test]
        public void Test4_DeleteProduct()
        {
            mainpage = new MainPage(driver);
            mainpage = mainpage.DeleteFortuneCookie();
        }

        [Test]
        public void Test5_Logout()
        {
            mainpage = new MainPage(driver);
            login = mainpage.Logout();

            Assert.True(login.AssertLogout());
        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
