using NUnit.Framework;
using Selenium.Utils;
using SeleniumTestProject.PageObjects;

namespace ExemploMatematica.Testes
{
    [TestFixture]
    public class InterfaceObjects_Tests
    {
        private InterfaceObjects sut;

        [SetUp]
        public void Inicializar()
        {
            sut = new InterfaceObjects(Browser.Chrome);
            sut.CarregarPagina();
        }

        [TestCase(2)]
        public void alterarScreen(int screen)
        {
            sut.alterarScreen(screen);
            sut.Fechar();
        }

        [TestCase(2)] //pos[0] = 'Graphic1', pos[1] = 'Graphic2' e pos[2] = 'Graphic3'
        public void alterarTab(int tab)
        {
            sut.alterarTab(tab);
            sut.Fechar();
        }
    }
}
