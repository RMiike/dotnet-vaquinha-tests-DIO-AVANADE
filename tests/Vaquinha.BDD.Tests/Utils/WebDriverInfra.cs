using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Text;

namespace Vaquinha.BDD.Tests.Utils
{
    public class WebDriverInfra
    {
        private string DEFAULT_SETTINGS_DRIVER_SERVICE = @"C:\driver\";
        public IWebDriver _driver { get; private set; }
        public RemoteWebDriver _remoteWebDriver;
        public WebDriverInfra(BrowserType browserType)
        {
            switch( browserType )
            {
                case BrowserType.Chrome:
                    var chromeService = ChromeDriverService.CreateDefaultService(DEFAULT_SETTINGS_DRIVER_SERVICE);
                    chromeService.Port = new Random().Next(64000, 64800);
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArgument("headless");
                    chromeOptions.AddArgument("no-sandbox");
                    chromeOptions.AddArgument("proxy-server='direct://'");
                    chromeOptions.AddArgument("proxy-auto-detect");
                    chromeOptions.AddArgument("proxy-bypass-list=*");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                    CodePagesEncodingProvider.Instance.GetEncoding(437);
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    _driver = new ChromeDriver(chromeService, chromeOptions);
                    break;
                case BrowserType.Firefox:
                    var fireFoxService = FirefoxDriverService.CreateDefaultService(DEFAULT_SETTINGS_DRIVER_SERVICE);
                    fireFoxService.Port = new Random().Next(64000, 64800);
                    fireFoxService.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    CodePagesEncodingProvider.Instance.GetEncoding(437);
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                    FirefoxOptions options = new FirefoxOptions();
                    //options.AddArgument("-headless");
                    options.AddArgument("-safe-mode");
                    options.AddArgument("-ignore-certificate-errors");
                    FirefoxProfile profile = new FirefoxProfile();
                    profile.AcceptUntrustedCertificates = true;
                    profile.AssumeUntrustedCertificateIssuer = false;
                    options.Profile = profile;
                    _driver = new FirefoxDriver(fireFoxService, options);
                    break;
                case BrowserType.Edge:
                    _driver = new EdgeDriver();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
        public IWebDriver GetWebDriver()
        {
            return _driver;
        }
        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        public void Close()
        {
            _driver.Quit();
        }
    }

}
