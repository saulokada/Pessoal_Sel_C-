using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium.Utils.BRSuiteObjects
{
    public class CheckBox
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public CheckBox(IWebDriver driver)
        {
            _driver = driver;
        }

        public void clicarCheckBox(string nomeCheckBox)
        {
            IWebElement chkCheckBox = _driver.FindElement(By.Id(nomeCheckBox));
            chkCheckBox.Click();
        }

        public bool checkedCheckBox(string nomeCheckBox)
        {
            IWebElement chkCheckBox = _driver.FindElement(By.Id(nomeCheckBox));
            return chkCheckBox.Selected;
        }
    }
}