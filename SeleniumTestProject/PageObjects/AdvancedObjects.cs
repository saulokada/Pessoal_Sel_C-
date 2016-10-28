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
    class AdvancedObjects
    {
        //Armazenar qual o browser que será utilizado
        private Browser _browser;
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;
        //Armazenar qual o path do browser
        private string _caminhoDriver;

        private Trend _areaPlotter;

        public AdvancedObjects(Browser browser)
        {
            
            _browser = browser;

            //Tell, don't ask
            _caminhoDriver = CaminhoDoBrowser.PegaCaminho(_browser.ToString());

            //Tell, don't ask
            _driver = WebDriveFactory.ObterWebDriver(_browser, _caminhoDriver);

            _areaPlotter = new Trend(_driver);
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(40));
            //testando tela Trend
            //_driver.Navigate().GoToUrl("http://localhost/selenium_phisuite/trend.html");
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlTelaAdvancedObjects"]);

        }

        public void ArmazenarPlotter()
        {
            _areaPlotter.ArmazenarPlotter();
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }

        #region MultiTagViewer

        public void selecionarLinhaMTV(int linha)
        {
            MultiTagViewer mtv = new MultiTagViewer(_driver);
            TextBox txtMTV = new TextBox(_driver);

            mtv.selecionarLinhaMTV("tblMultiTagViewer1", linha);
            txtMTV.validarValorTextBox("txtMTVSelectedIndex", linha.ToString());
        }

        public void getColumnNameMTV(int linha)
        {
            MultiTagViewer mtv = new MultiTagViewer(_driver);

            string aux = mtv.getColumnNameMTV("tblMultiTagViewer1", linha);
        }

        public void getColumnValueMTV(int linha)
        {
            MultiTagViewer mtv = new MultiTagViewer(_driver);

            string aux = mtv.getColumnNameMTV("tblMultiTagViewer1", linha);
        }

        public void setColumnValueMTV(int linha, int valor)
        {
            MultiTagViewer mtv = new MultiTagViewer(_driver);

            mtv.setColumnValueMTV("tblMultiTagViewer1", linha, valor);
            Assert.AreEqual(mtv.getColumnValueMTV("tblMultiTagViewer1", linha), valor);
        }

        public void moveUpMTV(int linha)
        {
            MultiTagViewer mtv = new MultiTagViewer(_driver);

            mtv.moveUpMTV("tblMultiTagViewer1", linha);
        }

        public void moveDownMTV(int linha)
        {
            MultiTagViewer mtv = new MultiTagViewer(_driver);

            mtv.moveDownMTV("tblMultiTagViewer1", linha);
        }

        #endregion

        #region MatrixGrid

        public void alterarProfundidadeMatrixGrid(int profundidade)
        {
            MatrixGrid mxg = new MatrixGrid(_driver);

            mxg.alterarProfundidadeMatrixGrid("controlMatrixGrid1", profundidade);
        }

        public void selecionarCelulaMatrixGrid(int linha, int coluna, int profundidade)
        {
            MatrixGrid mxg = new MatrixGrid(_driver);

            mxg.selecionarCelulaMatrixGrid("tblMatrixGrid1", linha, coluna, profundidade);
        }

        public void getCelulaMatrixGrid(int linha, int coluna, int profundidade)
        {
            MatrixGrid mxg = new MatrixGrid(_driver);

            mxg.getCelulaMatrixGrid("tblMatrixGrid1", linha, coluna, profundidade);
        }

        public void setCelulaMatrixGrid(int linha, int coluna, int profundidade, int valor)
        {
            MatrixGrid mxg = new MatrixGrid(_driver);

            mxg.setCelulaMatrixGrid("tblMatrixGrid1", linha, coluna, profundidade, valor);
        }

        #endregion

        #region Trend
        public void PausarPlotter()
        {
            Trend trdPause = new Trend(_driver);
            trdPause.PausarPlotter();
        }

        public void DarPlayNoPlotter()
        {
            Trend trdPlay = new Trend(_driver);
            trdPlay.DarPlayNoPlotter();
        }

        public void ExibirUnicaEscalaVertical()
        {
            Trend trdEscalaUnicaVertical = new Trend(_driver);
            trdEscalaUnicaVertical.ExibirUnicaEscalaVertical();
        }

        public void ExibirMultiplaEscalaVertical()
        {
            Trend trdEscalaMultiplaVertical = new Trend(_driver);
            trdEscalaMultiplaVertical.ExibirMultiplaEscalaVertical();
        }

        public void FazerAutoScale()
        {
            Trend trdAutoScale = new Trend(_driver);
            trdAutoScale.FazerAutoScale();
        }

        public void DesativarDetalhes()
        {
            Trend trdDesativerDetalhes = new Trend(_driver);
            trdDesativerDetalhes.DesativarDetalhes();
        }

        public void AtivarDetalhes()
        {
            Trend trdAtivarDetalhes = new Trend(_driver);
            trdAtivarDetalhes.AtivarDetalhes();
        }

        public void FazerFitToNow()
        {
            _areaPlotter.FazerFitToNow();
        }

        public void FazerFitScaleToView()
        {
            _areaPlotter.FazerFitScaleToView();
        }

        public void FazerScreenshot()
        {
            _areaPlotter.FazerScreenshot();
        }

        public void CopiarScreen()
        {
            _areaPlotter.CopiarScreen();
        }

        public void EnviarEmail()
        {
            _areaPlotter.EnviarEmail();
        }

        public void AdicionarCursor()
        {
            _areaPlotter.AdicionarCursor();
        }

        public void RemoverCursor()
        {
            _areaPlotter.RemoverCursor();
        }
        #endregion
    }
}