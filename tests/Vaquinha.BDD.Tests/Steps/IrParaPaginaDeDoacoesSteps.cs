using FluentAssertions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Vaquinha.BDD.Tests.Pages;
using Vaquinha.BDD.Tests.Utils;

namespace Vaquinha.BDD.Tests.Steps
{
    [Binding]
    public class IrParaPaginaDeDoacoesSteps : Utilitaries
    {
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver _driver;
        HomePage homePage = null;
        DoacaoPage doacaoPage = null;
        public IrParaPaginaDeDoacoesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"que o usuario esteja acessando a pagina home")]
        public void DadoQueOUsuarioEstejaAcessandoAPaginaHome()
        {
            var webDriver = new WebDriverInfra(BrowserType.Firefox);
            _driver = webDriver.GetWebDriver();
            webDriver.NavigateToUrl("https://vaquinha.azurewebsites.net/");


        }

        [Given(@"o usuario pressione o botao Doar agora")]
        public void DadoOUsuarioPressioneOBotaoDoarAgora()
        {
            homePage = new HomePage(_driver);
            homePage.ClicarBtnDoar();
        }

        [Then(@"o sistema apresenta a pagina de doacoes")]
        public void EntaoOSistemaApresentaAPaginaDeDoacoes()
        {
            doacaoPage = new DoacaoPage(_driver);
            doacaoPage.obterTextoBtnDoar().Should().Contain("Doar");

        }

        [Then(@"o sistema apresenta o titulo da pagina de doacoes")]
        public void EntaoOSistemaApresentaOTituloDaPaginaDeDoacoes(Table table)
        {
            var dados = table.Header;
            foreach( var item in dados )
            {

                Console.WriteLine(item);
            }
            Console.WriteLine(table.Rows.ToString());

            Console.WriteLine(table.ToString());
            ScreenShot(_driver);
            _driver.Close();
            _driver.Dispose();
            _driver.Quit();
        }

    }
}
