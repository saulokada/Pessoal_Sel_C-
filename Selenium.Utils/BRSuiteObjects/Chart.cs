using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Selenium.Utils.BRSuiteObjects
{
    class Chart
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public Chart(IWebDriver driver)
        {
            _driver = driver;
        }


    }
}

