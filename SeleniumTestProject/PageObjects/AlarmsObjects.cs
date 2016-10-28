using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;
using Selenium.Utils.BRSuiteObjects;
using System;
using System.Configuration;
using System.Threading;

namespace SeleniumTestProject.PageObjects
{
    public class AlarmsObjects
    {
        //Armazenar qual o browser que será utilizado
        private Browser _browser;
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;
        //Armazenar qual o path do browser
        private string _caminhoDriver;

        public AlarmsObjects(Browser browser)
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
            //testando tela Trend
            //_driver.Navigate().GoToUrl("http://localhost/selenium_phisuite/trend.html");
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlTelaAlarmsObjects"]);

        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }

        #region Alarm Online

        public string estadoAlarme(int linha)
        {
            Alarm objAlarm = new Alarm(_driver);

            return objAlarm.estadoAlarme("tblAlarm1", linha);
        }

        public void selecionarLinhaAlarme(int linha)
        {
            Alarm objAlarm = new Alarm(_driver);

            objAlarm.selecionarLinhaAlarme("tblAlarm1", linha);
        }

        public void ackAlarme(int linha)
        {
            Alarm objAlarm = new Alarm(_driver);

            objAlarm.ackAlarme("tblAlarm1", linha);
        }

        public void ackAlarme(int linha, string tipoAlarme)
        {
            Alarm objAlarm = new Alarm(_driver);

            objAlarm.ackAlarme("tblAlarm1", linha, tipoAlarme);
        }

        public void alterarAlarme(string alarme, int valor)
        {
            TextBox txtAlarme = new TextBox(_driver);

            txtAlarme.clearTextBox("txtAlm" + alarme);
            txtAlarme.setTextBoxValue("txtAlm" + alarme, valor);
        }

        public bool existeAlarme(string tipoAlarme)
        {
            Alarm objAlarm = new Alarm(_driver);

            return objAlarm.existeAlarme("tblAlarm1", tipoAlarme);
        }

        public int encontrarLinhaAlarme(string tipoAlarme)
        {
            Alarm objAlarm = new Alarm(_driver);

            return objAlarm.encontrarLinhaAlarme("tblAlarm1", tipoAlarme);
        }

        public void testeComAlarmes()
        {
            alterarAlarme("LoLo", -1001);
            alterarAlarme("Lo", -1001);
            alterarAlarme("Hi", 1001);
            alterarAlarme("HiHi", 1001);

            if (estadoAlarme(encontrarLinhaAlarme("LoLo")) == "alarmado" &&
                estadoAlarme(encontrarLinhaAlarme("Lo")) == "alarmado" &&
                estadoAlarme(encontrarLinhaAlarme("Hi")) == "alarmado" &&
                estadoAlarme(encontrarLinhaAlarme("HiHi")) == "alarmado")
            {
                ackAlarme(encontrarLinhaAlarme("LoLo"), "LoLo");
                ackAlarme(encontrarLinhaAlarme("Lo"), "Lo");
                ackAlarme(encontrarLinhaAlarme("Hi"), "Hi");
                ackAlarme(encontrarLinhaAlarme("HiHi"), "Hi");
            }
            else
                Assert.Fail();
            alterarAlarme("LoLo", 0);
            alterarAlarme("Lo", 0);
            alterarAlarme("Hi", 0);
            alterarAlarme("HiHi", 0);
            if (existeAlarme("LoLo") == true &&
                existeAlarme("Lo") == true &&
                existeAlarme("Hi") == true &&
                existeAlarme("HiHi") == true)
                Assert.Fail();

            alterarAlarme("Deviation", 15);
            if (estadoAlarme(encontrarLinhaAlarme("Deviation")) == "alarmado")
                ackAlarme(encontrarLinhaAlarme("Deviation"), "Deviation");
            else
                Assert.Fail();
            Thread.Sleep(7500);
            if (existeAlarme("Deviation") == true)
                Assert.Fail();

            alterarAlarme("Freeze", 15);
            if (estadoAlarme(encontrarLinhaAlarme("Freeze")) == "retornado")
                ackAlarme(encontrarLinhaAlarme("Freeze"), "Freeze");
            else
                Assert.Fail();
            if (existeAlarme("Freeze") == true)
                Assert.Fail();

            alterarAlarme("WatchDog", 15);
            if (estadoAlarme(encontrarLinhaAlarme("WatchDog")) == "retornado")
                ackAlarme(encontrarLinhaAlarme("WatchDog"), "WatchDog");
            else
                Assert.Fail();
            if (existeAlarme("WatchDog") == true)
                Assert.Fail();
        }

        #endregion

        #region Alarm History

        public void contarAlarmes(string tipoAlarme)
        {
            Alarm objAlarme = new Alarm(_driver);

            objAlarme.contarAlarmes("tblAlarmHistory", tipoAlarme);
        }

        #endregion
    }
}
