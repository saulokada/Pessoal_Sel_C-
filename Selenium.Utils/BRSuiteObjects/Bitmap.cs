using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium.Utils.BRSuiteObjects
{
    public class Bitmap
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public Bitmap(IWebDriver driver)
        {
            _driver = driver;
        }

        public void visibleBitmap(string nomeBitmap)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeBitmap));
            Assert.AreEqual(true, objGetObject.Displayed);
        }

        public void enableBitmap(string nomeBitmap)
        {
            IWebElement objGetObject = _driver.FindElement(By.Id(nomeBitmap));
            Assert.AreEqual(true, objGetObject.Enabled);
        }
    }
}
