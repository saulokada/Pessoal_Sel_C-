using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace SeleniumTestProject.PageObjects
{
    public class Tab
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public Tab(IWebDriver driver)
        {
            _driver = driver;
        }

        public void alterarAba(string nomeTab, int tab)
        {
            IWebElement tabObject = _driver.FindElement(By.Id("Tab1"));

            IList<IWebElement> tabHeader = tabObject.FindElements(By.XPath("//div[@id='Tab1']/ul/li"));

            tabHeader[tab].Click();
        }
    }
}
