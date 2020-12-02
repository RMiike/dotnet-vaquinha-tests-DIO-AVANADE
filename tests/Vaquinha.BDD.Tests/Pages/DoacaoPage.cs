using OpenQA.Selenium;

namespace Vaquinha.BDD.Tests.Pages
{
    class DoacaoPage
    {
        private IWebDriver _driver;


        public DoacaoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement btnDoar => _driver.FindElement(By.XPath("//input[@value='Doar']"));
        public string obterTextoBtnDoar() => btnDoar.GetAttribute("value");
    }
}
