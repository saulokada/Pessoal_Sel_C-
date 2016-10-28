using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium.Utils.BRSuiteObjects
{
    public class Label
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public Label(IWebDriver driver)
        {
            _driver = driver;
        }

        public string getLabelValue(string nomeLabel)
        {
            IWebElement objGetObjectValue = _driver.FindElement(By.Id(nomeLabel));
            return objGetObjectValue.GetAttribute("value");
        }

        public void visibleLabel(string nomeLabel)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeLabel));
            Assert.AreEqual(true, objGetObject.Displayed);
        }

        public void enableLabel(string nomeLabel)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeLabel));
            Assert.AreEqual(true, objGetObject.Enabled);
        }
    }
}
