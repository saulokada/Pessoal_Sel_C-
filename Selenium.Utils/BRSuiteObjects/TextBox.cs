using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium.Utils.BRSuiteObjects
{
    public class TextBox
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;
 
        public TextBox(IWebDriver driver)
        {
            _driver = driver;
        }

        public void setTextBoxValue(string nomeTextBox, double valor)
        {
            IWebElement objSetObjectValue = _driver.FindElement(By.Id(nomeTextBox));
            objSetObjectValue.SendKeys(valor.ToString());
            objSetObjectValue.SendKeys(Keys.Enter);
        }

        public void setTextBoxValue(string nomeTextBox, int valor)
        {
            IWebElement objSetObjectValue = _driver.FindElement(By.Id(nomeTextBox));
            objSetObjectValue.SendKeys(valor.ToString());
            objSetObjectValue.SendKeys(Keys.Enter);
        }

        public void setTextBoxValue(string nomeTextBox, string valor)
        {
            IWebElement objSetObjectValue = _driver.FindElement(By.Id(nomeTextBox));
            objSetObjectValue.SendKeys(valor.ToString());
            objSetObjectValue.SendKeys(Keys.Enter);
        }

        public string getTextBoxValue(string nomeTextBox)
        {
            IWebElement objGetObjectValue = _driver.FindElement(By.Id(nomeTextBox));
            return objGetObjectValue.GetAttribute("value");
        }

        public void validarValorTextBox(string nomeTextBox, string valor)
        {
            IWebElement objGetObjectValue = _driver.FindElement(By.Id(nomeTextBox));
            Assert.AreEqual(valor, objGetObjectValue.GetAttribute("value"));

        }

        public void visibleTextBox(string nomeTextBox)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeTextBox));
            Assert.AreEqual(true, objGetObject.Displayed);
        }

        public void enableTextBox(string nomeTextBox)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeTextBox));
            Assert.AreEqual(true, objGetObject.Enabled);
        }

        public void clearTextBox(string nomeTextBox)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeTextBox));
            objGetObject.Clear();
        }

        public void enviarEnterTextBox(string nomeTextBox)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeTextBox));
            objGetObject.SendKeys(Keys.Enter);
        }
    }
}
