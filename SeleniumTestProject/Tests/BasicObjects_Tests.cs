using NUnit.Framework;
using Selenium.Utils;
using SeleniumTestProject.PageObjects;

namespace SeleniumTestProject.Tests
{
    [TestFixture]
    public class BasicObjects_Tests
    {
        private BasicObjects sut;

        [OneTimeSetUp]
        public void Inicializar()
        {
            sut = new BasicObjects(Browser.PhantomJS);
            sut.CarregarPagina();
        }

        [OneTimeTearDown]
        public void Finalizar()
        {
            sut.Fechar();
        }

        
        [TestCase(1, "phi.png")]
        [TestCase(0.5, "NotFound.png")]
        [Ignore("aguardar correção do Label")]
        public void alterarDynamicImage(double valorInserido, string sourceDaImage)
        {
            sut.alterarDynamicImage(valorInserido);
            sut.verificarDynamicImage(valorInserido, sourceDaImage);            
        }

        [TestCase()]
        public void alterarCheckBox()
        {
            sut.alterarCheckBox();
        }

        [TestCase()]
        public void alterarCheckBoxThreeStates()
        {
            sut.alterarCheckBoxThreeStates();
            
        }

        [TestCase()]
        public void alterarCheckBoxViaBotao()
        {
            sut.alterarCheckBoxViaBotao();
        }

        [TestCase()]
        public void alterarCheckBoxThreeStatesViaBotao()
        {
            sut.alterarCheckBoxThreeStatesViaBotao();
        }

        [TestCase(1)]
        public void alterarCheckBoxViaTag(double valor)
        {
            sut.alterarCheckBoxViaTag(valor);
        }

        [TestCase(-1)]
        public void alterarCheckBoxThreeStatesViaTag(double valor)
        {
            sut.alterarCheckBoxThreeStatesViaTag(valor);
        }

        [TestCase(true)]
        public void checkarSelecaoCheckBox(bool valor)
        {
            Assert.AreEqual(valor, sut.validarCheckBox());
        }

        [TestCase(true)]
        public void checkarSelecaoCheckBoxThreeStates(bool valor)
        {
            Assert.AreEqual(valor, sut.validarCheckBoxThreeStates());
        }

        [TestCase(3)]
        [TestCase(5)]
        public void buttonMouseWhile(int valor)
        {
            sut.mouseWhile(valor);
        }

        [TestCase()]
        public void buttonDoubleClick()
        {
            sut.doubleClick();
        }

        [TestCase()]
        public void buttonRightClick()
        {
            sut.rightClick();
        }

        [TestCase(2)]
        [TestCase(5)]
        public void selecionarItemComboBox(int valor)
        {
            sut.selecionarItemComboBox(valor);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void selecionarRadioButton(int posicaoRadioButton)
        {
            sut.selecionarRadioButton(posicaoRadioButton);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void selecionarRadioButtonViaTag(int posicaoRadioButton)
        {
            sut.selecionarRadioButtonViaTag(posicaoRadioButton);
        }
    }
}
