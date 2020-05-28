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

        private const string ProductName_ = "Fortune cookie";
        private const string Category_ = "Confections";
        private const string Supplier_ = "Specialty Biscuits, Ltd.";
        private const string UnitPrice_ = "3,0000";
        private const string QuantityPerUnit_ = "10 boxes x 15 pieces";
        private const string UnitsInStock_ = "1";
        private const string UnitsOnOrder_ = "3";
        private const string ReorderLevel_ = "0";



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

            homepage.GetHomePage();
        }

        [SetUp]
        public void HomePage_MainPage()
        {
            homepage = new HomePage(driver);
            mainpage = homepage.AllProducts();

            mainpage.GetMainPage();
        }


        [Test]
        public void Test2_AddProduct()
        {
            mainpage = new MainPage(driver);
            productediting = new ProductEditing(driver);
            productediting = mainpage.CreateNew();
            mainpage = productediting.CreateProduct();

            mainpage.AssertAddProduct();
        }


        [Test]
        public void Test3_OpenAndCheck()
        {
            mainpage = new MainPage(driver);
            fortunecookie = mainpage.GetFortuneCookie();

            fortunecookie.GetProductName();
            fortunecookie.GetCategory();
            fortunecookie.GetSupplier();
            fortunecookie.GetUnitPrice();
            fortunecookie.GetQuantityPerUnit();
            fortunecookie.GetUnitsInStock();
            fortunecookie.GetUnitsOnOrder();
            fortunecookie.GetReorderLevel();
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

            login.AssertLogout();
        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}