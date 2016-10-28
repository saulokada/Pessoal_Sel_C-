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

namespace SeleniumTestProject.PageObjects
{
    public class RadioButton
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public RadioButton(IWebDriver driver)
        {
            _driver = driver;
        }

        public void selecionarRadioButton(string nomeRadioButton)
        {
            IWebElement rboRadioButton = _driver.FindElement(By.Id(nomeRadioButton));
            rboRadioButton.Click();
        }

        public void validarSelecaoRadioButton(string nomeRadioButton)
        {
            IWebElement rboRadioButton = _driver.FindElement(By.Id(nomeRadioButton));
            Assert.IsTrue(rboRadioButton.Selected);
        }
    }
}