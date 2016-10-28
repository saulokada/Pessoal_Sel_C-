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
    public class MultiTagViewer
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public MultiTagViewer(IWebDriver driver)
        {
            _driver = driver;
        }

        //WebElement tableRow = baseTable.findElement(By.XPath("//tr[2]")); //should be the third row
        //webElement cellIneed = tableRow.findElement(By.XPath("//td[2]")); //should be the cell itself

        public void takeScreenshot(string path)
        {
            ITakesScreenshot screenshotDriver = _driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(path, ImageFormat.Png);
        }

        public void selecionarLinhaMTV(string nomeMTV, int linha)
        {
            IWebElement mtv = _driver.FindElement(By.Id(nomeMTV));
            IList<IWebElement> tableRows = mtv.FindElements(By.Id("MultiTagViewer1Value"));
            //foreach (var item in tableRows)
            //{
            //    Console.WriteLine(item.GetAttribute("value"));
            //item.Click();
            tableRows[linha].Click();
            //}
        }

        public string getColumnNameMTV(string nomeMTV, int linha)
        {
            IWebElement mtv = _driver.FindElement(By.Id(nomeMTV));
            IList<IWebElement> tableRows = mtv.FindElements(By.XPath("//td[@id='MultiTagViewer1Name']/div/input"));

            return tableRows[linha].GetAttribute("value");
        }

        public string getColumnValueMTV(string nomeMTV, int linha)
        {
            IWebElement mtv = _driver.FindElement(By.Id(nomeMTV));
            IList<IWebElement> tableRows = mtv.FindElements(By.XPath("//td[@id='MultiTagViewer1Value']/div/input"));
            
            return tableRows[linha].GetAttribute("value");
        }

        public void setColumnValueMTV(string nomeMTV, int linha, int valor)
        {
            IWebElement mtv = _driver.FindElement(By.Id(nomeMTV));
            IList<IWebElement> tableRows = mtv.FindElements(By.XPath("//td[@id='MultiTagViewer1Value']/div/input"));

            tableRows[linha].Click();
            tableRows[linha].SendKeys(valor.ToString());
            tableRows[linha].SendKeys(Keys.Enter);
        }

        public void moveUpMTV(string nomeMTV, int linha)
        {
            IWebElement mtv = _driver.FindElement(By.Id(nomeMTV));
            IList<IWebElement> tableRows = mtv.FindElements(By.Id("MultiTagViewer1Name"));
            Actions actionProvider = new Actions(_driver);

            actionProvider.ContextClick(tableRows[linha]).Perform();
            Thread.Sleep(1000);
            actionProvider.SendKeys(Keys.ArrowDown);
            actionProvider.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(750);
        }

        public void moveDownMTV(string nomeMTV, int linha)
        {
            IWebElement mtv = _driver.FindElement(By.Id(nomeMTV));
            IList<IWebElement> tableRows = mtv.FindElements(By.Id("MultiTagViewer1Name"));
            Actions actionProvider = new Actions(_driver);

            actionProvider.ContextClick(tableRows[linha]).Perform();
            Thread.Sleep(1000);
            actionProvider.SendKeys(Keys.ArrowDown).SendKeys(Keys.ArrowDown);
            actionProvider.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(750);
        }
    }
}