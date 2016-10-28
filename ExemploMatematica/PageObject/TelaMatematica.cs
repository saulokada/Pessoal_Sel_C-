using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;

namespace ExemploMatematica.Testes
{
    //PAGE OBJECT - classe que faz o encapsulamento das informações sobre
    //elementos da página web de teste
    //provê a reutilização de código
    //desacopla a lógica de testes dos detalhes da implementação
    //centrar as PO em um único folder  (fácil manutenção)


    class TelaMatematica
    {
        //Armazenar qual o browser que será utilizado
        private Browser _browser;
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;
        //Armazenar qual o path do browser
        private string _caminhoDriver;

        public TelaMatematica(Browser browser)
        {
            this._browser = browser;

            //Tell, don't ask
            _caminhoDriver = CaminhoDoBrowser.PegaCaminho(_browser.ToString());

            //Tell, don't ask
            _driver = WebDriveFactory.ObterWebDriver(_browser, _caminhoDriver);
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(40));
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlTelaMatematica"]);
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }

        public void PreencherParcelasSoma(double valor1, double valor2)
        {
            IWebElement parcela1Soma = _driver.FindElement(By.Id("tParcela1"));
            parcela1Soma.SendKeys(valor1.ToString());        

            IWebElement parcela2Soma = _driver.FindElement(By.Id("tParcela2"));
            parcela2Soma.SendKeys(valor2.ToString());
            
        }

        public void ProcessarSoma()
        {
            IWebElement btnSoma = _driver.FindElement(By.Id("bSoma"));

            if (_browser != Browser.InternetExplorer)
                //btnSoma.Submit();
                btnSoma.Click();
            else
                btnSoma.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.Until((d) => d.FindElement(By.ClassName("ExemploSoma")) != null);
        }

        public double ObterResultadoSoma()
        {
            IWebElement ResultadoSoma = _driver.FindElement(By.Id("tSomaResultado"));
            return Convert.ToDouble(ResultadoSoma.GetAttribute("value"));
        }

        public void PreencherParcelasSubtracao(double valor1, double valor2)
        {
            IWebElement minuendo = _driver.FindElement(By.Id("tMinuendo"));
            minuendo.SendKeys(valor1.ToString());

            IWebElement subtraendo = _driver.FindElement(By.Id("tSubtraendo"));
            subtraendo.SendKeys(valor2.ToString());
        }

        public void ProcessarSubtracao()
        {
            IWebElement btnSoma = _driver.FindElement(By.Id("bSubtracao"));

            if (_browser != Browser.InternetExplorer)
                //btnSoma.Submit();
                btnSoma.Click();
            else
                btnSoma.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.Until((d) => d.FindElement(By.ClassName("ExemploSoma")) != null);
        }

        public double ObterResultadoSubtracao()
        {
            IWebElement ResultadoSubtracao = _driver.FindElement(By.Id("tSubtracaoResultado"));
            return Convert.ToDouble(ResultadoSubtracao.GetAttribute("value"));
        }

        public void PreencherParcelasMultiplicacao(double valor1, double valor2)
        {
            IWebElement parcela1Multiplicacao = _driver.FindElement(By.Id("tFator1"));
            parcela1Multiplicacao.SendKeys(valor1.ToString());

            IWebElement parcela2Multiplicacao = _driver.FindElement(By.Id("tFator2"));
            parcela2Multiplicacao.SendKeys(valor2.ToString());
        }

        public void ProcessarMultiplicacao()
        {
            IWebElement btnSoma = _driver.FindElement(By.Id("bMultiplicacao"));

            if (_browser != Browser.InternetExplorer)
                //btnSoma.Submit();
                btnSoma.Click();
            else
                btnSoma.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.Until((d) => d.FindElement(By.ClassName("ExemploSoma")) != null);
        }

        public double ObterResultadoMultiplicacao()
        {
            IWebElement ResultadoMultiplicacao = _driver.FindElement(By.Id("tMultiplicacaoResultado"));
            return Convert.ToDouble(ResultadoMultiplicacao.GetAttribute("value"));
        }

        public void PreencherParcelasDivisao(double valor1, double valor2)
        {
            IWebElement dividendo = _driver.FindElement(By.Id("tDividendo"));
            dividendo.SendKeys(valor1.ToString());

            IWebElement divisor = _driver.FindElement(By.Id("tDivisor"));
            divisor.SendKeys(valor2.ToString());
        }

        public void ProcessarDivisao()
        {
            IWebElement btnSoma = _driver.FindElement(By.Id("bDivisao"));

            if (_browser != Browser.InternetExplorer)
                //btnSoma.Submit();
                btnSoma.Click();
            else
                btnSoma.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.Until((d) => d.FindElement(By.ClassName("ExemploSoma")) != null);
        }

        public double ObterResultadoDivisao()
        {
            IWebElement ResultadoDivisao = _driver.FindElement(By.Id("tDivisaoResultado"));
            return Convert.ToDouble(ResultadoDivisao.GetAttribute("value"));
        }

    }
}
