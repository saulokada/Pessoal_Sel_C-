using System;
using System.Configuration;
using OpenQA.Selenium;
using Selenium.Utils;
using NUnit.Framework;
using Selenium.Utils.BRSuiteObjects;

namespace SeleniumTestProject.PageObjects
{
    class InterfaceObjects
    {
        //Armazenar qual o browser que será utilizado
        private Browser _browser;
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;
        //Armazenar qual o path do browser
        private string _caminhoDriver;

        #region Funções Basicas (Construtor, CarregarPagina e Fechar)

        public InterfaceObjects(Browser browser)
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
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlTelaInterfaceObjects"]);
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
        #endregion

        #region Menu

        #endregion

        #region Screen

        public void alterarScreen(int screen)
        {
            Button btnScreen = new Button(_driver);
            TextBox txtCurrentScreen = new TextBox(_driver);

            if (screen == 1) {
                btnScreen.clicarBotao("btnScreen1");
                Assert.AreEqual(txtCurrentScreen.getTextBoxValue("txtCurrentScreen"), "Graphic1");
            }
            else if (screen == 2) {
                btnScreen.clicarBotao("btnScreen2");
                    Assert.AreEqual(txtCurrentScreen.getTextBoxValue("txtCurrentScreen"), "Graphic2");
            }
            else if (screen == 3) {
                btnScreen.clicarBotao("btnScreen3");
                Assert.AreEqual(txtCurrentScreen.getTextBoxValue("txtCurrentScreen"), "Graphic3");
            }
        }

        #endregion

        #region Tab

        public void alterarTab(int tab)
        {
            Tab tabObject = new Tab(_driver);

            tabObject.alterarAba("Tab1", tab);
        }



        #endregion
    }
}