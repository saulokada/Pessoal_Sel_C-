using NUnit.Framework;
using Selenium.Utils;
using SeleniumTestProject.PageObjects;

namespace SeleniumTestProject.Tests
{
    [TestFixture]
    public class TestesPhantomJS_Alarmsjects
    {
        private AlarmsObjects _tela;

        [SetUp]
        public void Inicializar()
        {
            _tela = new AlarmsObjects(Browser.Chrome);
            _tela.CarregarPagina();
        }

        [TestCase(2)]
        public void estadoAlarme(int linha)
        {
            _tela.estadoAlarme(linha);
            _tela.Fechar();
        }

        [TestCase(2)]
        public void selecionarLinhaAlarme(int linha)
        {
            _tela.selecionarLinhaAlarme(linha);
            _tela.Fechar();
        }

        [TestCase(2)]
        public void ackAlarme(int linha)
        {
            _tela.ackAlarme(linha);
            _tela.Fechar();
        }

        [TestCase("LoLo", -1001)]
        public void alterarAlarme(string alarme, int valor)
        {
            _tela.alterarAlarme(alarme, valor);
            _tela.Fechar();
        }

        [TestCase("LoLo")]
        public void encontrarLinhaAlarme(string tipoAlarme)
        {
            _tela.encontrarLinhaAlarme(tipoAlarme);
            _tela.Fechar();
        }

        [TestCase()]
        public void testeComAlarmes()
        {
            _tela.testeComAlarmes();
            _tela.Fechar();
        }

        [TestCase("LoLo")]
        public void contarAlarmes(string tipoAlarme)
        {
            _tela.contarAlarmes(tipoAlarme);
            _tela.Fechar();
        }
    }
}