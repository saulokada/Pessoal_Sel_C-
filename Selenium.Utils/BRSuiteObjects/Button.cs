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
using System.Threading;

namespace SeleniumTestProject.PageObjects
{
    public class Button
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public Button(IWebDriver driver)
        {
            _driver = driver;
        }

        public void clicarBotao(string nomeButton)
        {
            IWebElement btnButton = _driver.FindElement(By.Id(nomeButton));
            btnButton.Click();
        }

        public void mouseWhile(string nomeButton, int valor)
        {
            IWebElement btnButton = _driver.FindElement(By.Id(nomeButton));
            Actions actionProvider = new Actions(_driver);
            actionProvider.ClickAndHold(btnButton).Perform();
            Thread.Sleep(valor*500);
            actionProvider.Release(btnButton).Perform();
            Thread.Sleep(100);
        }

        public void doubleClick(string nomeButton)
        {
            IWebElement btnButton = _driver.FindElement(By.Id(nomeButton));
            Actions actionProvider = new Actions(_driver);
            actionProvider.DoubleClick(btnButton).Perform();
        }

        public void rightClick(string nomeButton)
        {
            IWebElement btnButton = _driver.FindElement(By.Id(nomeButton));
            Actions actionProvider = new Actions(_driver);
            actionProvider.ContextClick(btnButton).Perform();
        }

        public void botaoSelecionarItemMenuDeContexto(string nomeButton, double valor)
        {
            Actions actionProvider = new Actions(_driver);
            IWebElement btnButton = _driver.FindElement(By.Id(nomeButton));
            actionProvider.ContextClick(btnButton).Perform();
            for (int i = 0; i < valor; i++)
                actionProvider.SendKeys(Keys.ArrowDown);
            actionProvider.SendKeys(Keys.Enter).Perform();
        }
    }

}