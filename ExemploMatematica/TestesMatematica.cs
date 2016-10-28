using System;
using NUnit.Framework;
using Selenium.Utils;
using System.Collections;

namespace ExemploMatematica.Testes
{
    [TestFixtureSource(typeof(BrowsersParaExecucao))]  
    [Ignore("Classe utilizada somente como exemplo, desmarcar 'Ignore' para utilizar")]
    public class TestesMatematica 

    {
        private Browser _browser;
        public TestesMatematica(Browser browser) { this._browser = browser; }

        //system under test
        private TelaMatematica sut;

        

        [OneTimeSetUp]
        public void DeveCarregarBrowser()
        {
            sut = new TelaMatematica(_browser);
        }

        [OneTimeTearDown]
        public void DeveFecharBrowser()
        {
            sut.Fechar();
        }


        [SetUp]                      
        public void DeveCarregarTela()
        {
            sut.CarregarPagina();
        }

        [TestCase(1, 2, 3)]
        public void DeveValidarSoma(double parcela1, double parcela2, double resultado)
        {
            //sut.PreencherParcelasSoma(parcela1, parcela2);
            //sut.ProcessarSoma();
            //double ResultadoSoma = sut.ObterResultadoSoma();

            Assert.AreEqual(resultado, 3);

        }
        
        [TestCase(5, 2, 3)]
        [TestCase(3.5, 2.25, 1.25)]
        [Ignore("Não executar")]
        public void DeveValidarSubtracao(double minuendo, double subtraendo, double resultado)
        {
            sut.PreencherParcelasSubtracao(minuendo, subtraendo);
            sut.ProcessarSubtracao();
            double ResultadoSubtracao = sut.ObterResultadoSubtracao();

            Assert.AreEqual(resultado, ResultadoSubtracao);
        }

        [TestCase(5, 2, 10)]
        [TestCase(1.5, 2.5, 3.75)]
        [Ignore("Não executar")]
        public void DeveValidarMultiplicacao(double fator1, double fator2, double resultado)
        {
            sut.PreencherParcelasMultiplicacao(fator1, fator2);
            sut.ProcessarMultiplicacao();
            double ResultadoMultiplicacao = sut.ObterResultadoMultiplicacao();

            Assert.AreEqual(resultado, ResultadoMultiplicacao);
        }

        [TestCase(6, 2, 3)]
        [TestCase(10, 2.5, 4)]
        [Ignore("Não executar")]
        public void DeveValidarDivisao(double dividendo, double divisor, double resultado)
        {
            sut.PreencherParcelasDivisao(dividendo, divisor);
            sut.ProcessarDivisao();
            double ResultadoDivisao = sut.ObterResultadoDivisao();

            Assert.AreEqual(resultado, ResultadoDivisao);
        }
        
    }

    class BrowsersParaExecucao : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { Browser.InternetExplorer };
            yield return new object[] { Browser.Firefox };
            yield return new object[] { Browser.PhantomJS };
            yield return new object[] { Browser.Chrome };

        }
    }
}