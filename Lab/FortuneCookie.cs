using OpenQA.Selenium;

namespace Lab
{

    class FortuneCookie
    {
        private IWebDriver driver;

        public FortuneCookie(IWebDriver driver)
        {
            this.driver = driver;
        }
    }  
}