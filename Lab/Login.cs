using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class Login
    {
        private IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement InputName => driver.FindElement(By.Id("Name"));
        private IWebElement InputPassword => driver.FindElement(By.Id("Password"));
        private IWebElement ButtonSend => driver.FindElement(By.XPath("//*[@type=\"submit\"]"));

        public HomePage Login_()
        {
            new Actions(driver).SendKeys(InputName, "user").Build().Perform();
            new Actions(driver).SendKeys(InputPassword, "user").Build().Perform();
            new Actions(driver).Click().Click(ButtonSend).Build().Perform();

            return new HomePage(driver);
        }
    }
}
