using OpenQA.Selenium;

namespace Vaquinha.BDD.Tests.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;

        //public HomePage(RemoteWebDriver driver)
        //{
        //    _driver = driver;
        //}
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement btnDoar => _driver.FindElement(By.XPath("//a[contains(@class,'btn btn-yellow')]"));
        public IWebElement txtLogo => _driver.FindElement(By.ClassName("vaquinha-logo"));

        public void ClicarBtnDoar() => btnDoar.Click();


    }
}
