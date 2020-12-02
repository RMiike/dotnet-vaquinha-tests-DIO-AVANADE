using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace Vaquinha.BDD
{
    public class Class1
    {
        private string DEFAULT_SETTINGS_DRIVER_SERVICE = "/usr/share/applications/";

        [Fact]
        public void Iniciar()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(DEFAULT_SETTINGS_DRIVER_SERVICE);
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            driver.Navigate().GoToUrl("www.google.com");
            System.Console.WriteLine("o que está errado");
        }
    }
}
