using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Selenium.Utils.BRSuiteObjects
{
    public class ComboBox
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public ComboBox(IWebDriver driver)
        {
            _driver = driver;
        }

        public void selecionarItemComboBox(string nomeComboBox, int valor)
        {
            IWebElement cboComboBox = _driver.FindElement(By.Id(nomeComboBox));
            SelectElement selector = new SelectElement(cboComboBox);
            selector.SelectByIndex(valor);    
        }
    }
}
