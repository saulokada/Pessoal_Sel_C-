using NUnit.Framework;
using Selenium.Utils;
using SeleniumTestProject.PageObjects;

namespace SeleniumTestProject.Tests
{
    [TestFixture]
    class AdvancedObjectsTests
    {
        private AdvancedObjects sut;

        [OneTimeSetUp]
        public void Inicializar()
        {
            sut = new AdvancedObjects(Browser.PhantomJS);
            sut.CarregarPagina();
        }
        [OneTimeTearDown]
        public void Finalizar()
        {
            sut.Fechar();
        }

        [Test, Order(1)]
        public void DeveDarPause()
        {
            sut.PausarPlotter();
        }

        [Test, Order(2)]
        public void DeveDarPlay()
        {
            sut.DarPlayNoPlotter();
        }

        [Test, Order(3)]
        public void DeveExibirUmaUnicaEscalaVertical()
        {
            sut.ExibirUnicaEscalaVertical();
        }

        [Test, Order(4)]
        public void DeveExibirMultiplasEscalasVerticais()
        {
            sut.ExibirMultiplaEscalaVertical();
        }

        [Test]
        public void DeveFazerAutoScale()
        {
            sut.FazerAutoScale();
            //Implementar Assert
        }

        [Test,Order(5)]
        public void DeveDesativarDetalhesDasPenas()
        {
            sut.DesativarDetalhes();
            //Implementar Assert
        }

        [Test, Order(6)]
        public void DeveAtivarDetalhesDasPenas()
        {
            sut.AtivarDetalhes();
            //Implementar Assert
        }

        [Test, Order(7)]
        public void DeveAdicionarCursor()
        {
            sut.AdicionarCursor();
        }

        [Test, Order(8)]
        public void DeveRemoverCursor()
        {
            sut.RemoverCursor();
        }

        
    }
}
