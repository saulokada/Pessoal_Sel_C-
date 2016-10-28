using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;
using System;
using System.Configuration;
using System.Threading;
using Selenium.Utils.BRSuiteObjects;

namespace SeleniumTestProject.PageObjects
{
    class BasicObjects
    {
        //Armazenar qual o browser que será utilizado
        private Browser _browser;
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;
        //Armazenar qual o path do browser
        private string _caminhoDriver;

        #region Funções Basicas (Construtor, CarregarPagina e Fechar)

        public BasicObjects(Browser browser)
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
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["UrlTelaBasicObjects"]);
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
        #endregion

        #region DynamicImage

        public void alterarDynamicImage(double valor)
        {
            TextBox txtDynamicImage = new TextBox(_driver);
            txtDynamicImage.clearTextBox("txtDynamicImage");
            txtDynamicImage.setTextBoxValue("txtDynamicImage", valor);
            //txtDynamicImage.enviarEnterTextBox("txtDynamicImage");
        }

        public void verificarDynamicImage(double valor, string imageSource)
        {
            Label lblDynamicImageSrc = new Label(_driver);
            TextBox txtDynamicImage = new TextBox(_driver);

            try
            {
                txtDynamicImage.validarValorTextBox("txtDynamicImage", valor.ToString());
            }
            catch(AssertionException e)
            {
                Assert.Fail("Uma condição inválida foi encontrada antes da execução do Assert da função");
            }
            
            Assert.AreEqual(imageSource, lblDynamicImageSrc.getLabelValue("lblDynamicImageSrc"));
        }

        #endregion

        #region CheckBox

        public void alterarCheckBox()
        {
            CheckBox chkCheckBox = new CheckBox(_driver);
            chkCheckBox.clicarCheckBox("chkTesteSelecao");
        }

        public void alterarCheckBoxThreeStates()
        {
            CheckBox chkCheckBox = new CheckBox(_driver);
            chkCheckBox.clicarCheckBox("chkTesteSelecao");
        }

        public void alterarCheckBoxViaBotao()
        {
            Button btnTesteSelecao = new Button(_driver);
            btnTesteSelecao.clicarBotao("btnTesteSelecao");
        }

        public void alterarCheckBoxThreeStatesViaBotao()
        {
            Button btnTesteSelecao = new Button(_driver);
            btnTesteSelecao.clicarBotao("btnThreeStates");
        }

        public void alterarCheckBoxViaTag(double valor)
        {
            TextBox txtTesteSelecao = new TextBox(_driver);
            txtTesteSelecao.setTextBoxValue("txtTesteSelecao", valor);
        }

        public void alterarCheckBoxThreeStatesViaTag(double valor)
        {
            TextBox txtThreeStates = new TextBox(_driver);
            txtThreeStates.setTextBoxValue("txtThreeStates", valor);
        }

        public bool validarCheckBox()
        {
            CheckBox chkTesteSelecao = new CheckBox(_driver);
            return chkTesteSelecao.checkedCheckBox("chkTesteSelecao");
        }

        public bool validarCheckBoxThreeStates()
        {
            CheckBox chkThreeStates = new CheckBox(_driver);
            return chkThreeStates.checkedCheckBox("chkThreeStates");
        }

        #endregion

        #region Button

        public void zerarTextBoxScriptsMouseDown()
        {
            TextBox txtMouseDown = new TextBox(_driver);

            txtMouseDown.clearTextBox("txtScriptsMouseDown");
            txtMouseDown.setTextBoxValue("txtScriptsMouseDown", 0);            
            //txtMouseDown.enviarEnterTextBox("txtScriptsMouseDown");       
        }

        public void zerarTextBoxScriptsMouseWhile()
        {
            TextBox txtMouseWhile = new TextBox(_driver);

            txtMouseWhile.clearTextBox("txtScriptsMouseWhile");
            txtMouseWhile.setTextBoxValue("txtScriptsMouseWhile", 0);
            //txtMouseWhile.enviarEnterTextBox("txtScriptsMouseWhile");
        }

        public void zerarTextBoxScriptsMouseUp()
        {
            TextBox txtMouseUp = new TextBox(_driver);

            txtMouseUp.clearTextBox("txtScriptsMouseUp");
            txtMouseUp.setTextBoxValue("txtScriptsMouseUp", 0);
            //txtMouseUp.enviarEnterTextBox("txtScriptsMouseUp");
        }

        public void zerarTextBoxScriptsMouseDoubleClick()
        {
            TextBox txtMouseDoubleClick = new TextBox(_driver);

            txtMouseDoubleClick.clearTextBox("txtScriptsMouseDoubleClick");
            txtMouseDoubleClick.setTextBoxValue("txtScriptsMouseDoubleClick", 0);
            //txtMouseDoubleClick.enviarEnterTextBox("txtScriptsMouseDoubleClick");
        }

        public void zerarTextBoxScriptsMouseRightDown()
        {
            TextBox txtMouseRightDown = new TextBox(_driver);

            txtMouseRightDown.clearTextBox("txtScriptsMouseRightDown");
            txtMouseRightDown.setTextBoxValue("txtScriptsMouseRightDown", 0);
            //txtMouseRightDown.enviarEnterTextBox("txtScriptsMouseRightDown");
        }

        public void zerarTextBoxScriptsMouseRightUp()
        {
            TextBox txtMouseRightUp = new TextBox(_driver);
            txtMouseRightUp.clearTextBox("txtScriptsMouseRightUp");
            txtMouseRightUp.setTextBoxValue("txtScriptsMouseRightUp", 0);
            //txtMouseRightUp.enviarEnterTextBox("txtScriptsMouseRightUp");
        }

        public void mouseWhile(int valor)
        {
            TextBox txtMouseWhile = new TextBox(_driver);
            Button btnMouseWhile = new Button(_driver);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnScripts")));

            zerarTextBoxScriptsMouseDown();
            zerarTextBoxScriptsMouseWhile();
            zerarTextBoxScriptsMouseUp();

            btnMouseWhile.mouseWhile("btnScripts", valor);
            txtMouseWhile.validarValorTextBox("txtScriptsMouseDown", "1");
            txtMouseWhile.validarValorTextBox("txtScriptsMouseWhile", valor.ToString());
            txtMouseWhile.validarValorTextBox("txtScriptsMouseUp", "1");
        }

        public void doubleClick()
        {
            TextBox txtMouseDoubleClick = new TextBox(_driver);
            Button btnMouseDoubleClick = new Button(_driver);

            zerarTextBoxScriptsMouseDoubleClick();

            btnMouseDoubleClick.doubleClick("btnScripts");
            txtMouseDoubleClick.validarValorTextBox("txtScriptsMouseDoubleClick", "1");
        }

        public void rightClick()
        {
            TextBox txtMouseRight = new TextBox(_driver);
            Button btnMouseWhile = new Button(_driver);

            zerarTextBoxScriptsMouseRightDown();
            zerarTextBoxScriptsMouseRightUp();

            btnMouseWhile.rightClick("btnScripts");
            txtMouseRight.validarValorTextBox("txtScriptsMouseRightDown", "1");
            txtMouseRight.validarValorTextBox("txtScriptsMouseRightUp", "1");
        }

        #endregion

        #region Combo-Box
        
        public void zerarComboBox()
        {
            TextBox txtComboBox = new TextBox(_driver);

            txtComboBox.clearTextBox("txtComboBoxSelectedIndex");
            txtComboBox.setTextBoxValue("txtComboBoxSelectedIndex", 0);
            //txtComboBox.enviarEnterTextBox("txtComboBoxSelectedIndex");
        }

        public void zerarComboBoxSelectionChanged()
        {
            TextBox txtComboBoxSelectionChanged = new TextBox(_driver);

            txtComboBoxSelectionChanged.clearTextBox("txtComboBoxSelectionChanged");
            txtComboBoxSelectionChanged.setTextBoxValue("txtComboBoxSelectionChanged", 0);
            //txtComboBoxSelectionChanged.enviarEnterTextBox("txtComboBoxSelectionChanged");
        }

        public void selecionarItemComboBox(int valor)
        {
            ComboBox cboComboBox = new ComboBox(_driver);
            TextBox txtComboBox = new TextBox(_driver);

            zerarComboBox();
            zerarComboBoxSelectionChanged();
            try
            {
                cboComboBox.selecionarItemComboBox("cboComboBox", valor);
                //txtComboBox.validarValorTextBox("txtComboBoxSelectionChanged", "1");
                txtComboBox.validarValorTextBox("txtComboBoxSelectedIndex", (valor).ToString());
            }
            catch(NoSuchElementException e1){
                Assert.Pass("Item não existe");
            }
        }
        #endregion

        #region Radio-Button

        public void selecionarRadioButton(int posicaoRadioButton)
        {
            RadioButton rboRadioButton = new RadioButton(_driver);
            TextBox txtRadioButton = new TextBox(_driver);

            rboRadioButton.selecionarRadioButton("rboRadioButton" + posicaoRadioButton);
            Thread.Sleep(750);
            txtRadioButton.validarValorTextBox("txtRadioButton", (posicaoRadioButton - 1).ToString());
        }

        public void selecionarRadioButtonViaTag(int valor)
        {
            RadioButton rboRadioButton = new RadioButton(_driver);
            TextBox txtRadioButton = new TextBox(_driver);

            txtRadioButton.clearTextBox("txtRadioButton");
            txtRadioButton.setTextBoxValue("txtRadioButton", valor);
            //txtRadioButton.enviarEnterTextBox("txtRadioButton");
            Thread.Sleep(750);
            rboRadioButton.validarSelecaoRadioButton("rboRadioButton" + (valor + 1));
        }


        #endregion
    }
}
