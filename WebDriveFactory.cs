using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Edge;

namespace Selenium.Utils
{
    //classes responsável em retornar o tipo de webdriver específico
    public static class WebDriveFactory
    {
        //método para implementação da interface entre selenium x browser
        //selenium disponiliza um drive de para conectar o projeto de teste (nunit test) com o navegador
        //é um executavel (não é necessário instalar o .exe para o Fifefox)
        //A partir da versão 47+ do Firefox, é necessário utilizar o driver gecko'Marionette'
        public static IWebDriver ObterWebDriver(

            Browser browser, string caminhoDriver = null)
        {
            IWebDriver webDriver = null;

            switch(browser)
            {
                case Browser.Firefox:               
                    FirefoxDriverService fds = FirefoxDriverService.CreateDefaultService();
                    fds.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    webDriver = new FirefoxDriver(fds);
                    break;
                case Browser.Chrome:
                    webDriver = new ChromeDriver(caminhoDriver);
                    break;
                case Browser.InternetExplorer:
                    webDriver = new InternetExplorerDriver(caminhoDriver);
                    break;
                case Browser.PhantomJS:
                    webDriver = new PhantomJSDriver(caminhoDriver);
                    break;
                case Browser.Edge:
                    webDriver = new EdgeDriver();
                    break;
            }
            return webDriver;
        }
    }
}
