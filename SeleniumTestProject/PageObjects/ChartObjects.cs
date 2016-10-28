using System;
using System.Configuration;
using OpenQA.Selenium;
using Selenium.Utils;
using NUnit.Framework;
using Selenium.Utils.BRSuiteObjects;

namespace SeleniumTestProject.PageObjects
{
    class ChartObjects
    {
        //Armazenar qual o browser que será utilizado
        private Browser _browser;
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;
        //Armazenar qual o path do browser
        private string _caminhoDriver;

        #region Funções Basicas (Construtor, CarregarPagina e Fechar)

        public ChartObjects(Browser browser)
        {
            _browser = browser;

            //Tell, don't ask
            _caminhoDriver = CaminhoDoBrowser.PegaCaminho(_browser.ToString());

            //Tell, don't ask
            _driver = WebDriveFactory.ObterWebDriver(_browser, _caminhoDriver);
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(40));
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlTelaChartObjects"]);
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
        #endregion
    }
}