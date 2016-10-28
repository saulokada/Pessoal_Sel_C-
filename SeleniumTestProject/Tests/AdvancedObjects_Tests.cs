using NUnit.Framework;
using Selenium.Utils;
using SeleniumTestProject.PageObjects;

namespace SeleniumTestProject.Tests
{
    [TestFixture]
    public class AdvancedObjects_Tests
    {
        private AdvancedObjects sut;

        [OneTimeSetUp]
        public void Inicializar()
        {
            sut = new AdvancedObjects(Browser.InternetExplorer);
            sut.CarregarPagina();
            sut.ArmazenarPlotter();
        }
        [OneTimeTearDown]
        public void Fechar()
        {
            sut.Fechar();
        }

        #region MTV 
        
        
        [TestCase(0)]
        public void selecionarLinhaMTV(int linha)
        {
            sut.selecionarLinhaMTV(linha);
            sut.Fechar();
        }

        [TestCase(0)]
        public void getColumnNameMTV(int linha)
        {
            sut.getColumnNameMTV(linha);
            sut.Fechar();
        }

        [TestCase(0)]
        public void getColumnValueMTV(int linha)
        {
            sut.getColumnValueMTV(linha);
            sut.Fechar();
        }

        [TestCase(0, 999)]
        public void setColumnValueMTV(int linha, int valor)
        {
            sut.setColumnValueMTV(linha, valor);
            sut.Fechar();
        }

        [TestCase(1)]
        public void moveUp(int linha)
        {
            sut.moveUpMTV(linha);
            sut.Fechar();
        }

        [TestCase(0)]
        public void moveDown(int linha)
        {
            sut.moveDownMTV(linha);
            sut.Fechar();
        }

        [TestCase(1)]
        public void alterarProfundidadeMatrixGrid(int profundidade)
        {
            sut.alterarProfundidadeMatrixGrid(profundidade);
            sut.Fechar();
        }

        [TestCase(1, 2, 1)]
        [TestCase(2, 3, 1)]
        [TestCase(0, 0, 0)]
        public void selecionarCelulaMatrixGrid(int linha, int coluna, int profundidade)
        {
            sut.selecionarCelulaMatrixGrid(linha, coluna, profundidade);
            sut.Fechar();
        }

        [TestCase(0, 0, 0)]
        public void getCelulaMatrixGrid(int linha, int coluna, int profundidade)
        {
            sut.getCelulaMatrixGrid(linha, coluna, profundidade);
            sut.Fechar();
        }

        [TestCase(0, 0, 0, 222)]
        public void setCelulaMatrixGrid(int linha, int coluna, int profundidade, int valor)
        {
            sut.setCelulaMatrixGrid(linha, coluna, profundidade, valor);
            sut.Fechar();
        }
        #endregion

        #region Trend

        [Test]
        [Order(1)]
        public void DeveDarPause()
        {
            sut.PausarPlotter();
        }

        [Test]
        [Order(2)]
        public void DeveDarPlay()
        {
            sut.DarPlayNoPlotter();
        }
        
        [Test]
        [Order(3)]
        public void DeveExibirUmaUnicaEscalaVertical()
        {
            sut.ExibirUnicaEscalaVertical();
        }

        [Test]
        [Order(4)]
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

        [Test]
        [Order(5)]
        public void DeveDesativarDetalhesDasPenas()
        {
            sut.DesativarDetalhes();
            //Implementar Assert
        }

        [Test]
        [Order(6)]
        public void DeveAtivarDetalhesDasPenas()
        {
            sut.AtivarDetalhes();
            //Implementar Assert
        }

        [Test]
        [Order(7)]
        [Category("Ploter")]
        public void DeveAdicionarCursor()
        {
            sut.AdicionarCursor();
        }

        [Test]
        [Order(8)]
        [Category("Ploter")]
        public void DeveRemoverCursor()
        {
            sut.RemoverCursor();
        }

        [Test]
        [Category("Ploter")]
        public void DeveFazerFitToNow()
        {
            sut.FazerFitToNow();
        }

        [Test]
        [Category("Ploter")]
        public void DeveFazerFitScaleToView()
        {
            sut.FazerFitScaleToView();
        }

        [Test]
        [Category("Ploter")]
        public void DeveFazerScreenshot()
        {
            sut.FazerScreenshot();
        }

        [Test]
        [Category("Ploter")]
        public void DeveCopiarScreen()
        {
            sut.CopiarScreen();
        }

        [Test]
        [Category("Ploter")]
        public void DeveEnviarEmail()
        {
            sut.EnviarEmail();
        }
        #endregion
    }
}