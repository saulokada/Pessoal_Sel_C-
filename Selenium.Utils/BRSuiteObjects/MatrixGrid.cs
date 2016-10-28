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
    public class MatrixGrid
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public MatrixGrid(IWebDriver driver)
        {
            _driver = driver;
        }

        public void takeScreenshot(string path)
        {
            ITakesScreenshot screenshotDriver = _driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(path, ImageFormat.Png);
        }

        public int getProfundidadeMatrixGrid(string nomeMxg)
        {
            IWebElement mxgControl = _driver.FindElement(By.XPath("//input[@name='index']"));

            return Convert.ToInt32(mxgControl.GetAttribute("value"));
        }

        public void alterarProfundidadeMatrixGrid(string nomeMxg, int profundidade)
        {
            IWebElement mxgControl = _driver.FindElement(By.XPath("//input[@name='index']"));

            mxgControl.Click();
            mxgControl.SendKeys(Keys.Delete);
            mxgControl.SendKeys(profundidade.ToString());
            mxgControl.SendKeys(Keys.Enter);

            Assert.AreEqual(getProfundidadeMatrixGrid(nomeMxg), profundidade.ToString());
        }

        public void avancarProfundidadeMatrixGrid(string nomeMxg)
        {
            IWebElement mxgControl = _driver.FindElement(By.XPath("//button[@name='foward']"));

            mxgControl.Click();
        }

        public void retrocederProfundidadeMatrixGrid(string nomeMxg)
        {
            IWebElement mxgControl = _driver.FindElement(By.XPath("//button[@name='back']"));

            mxgControl.Click();
        }

        public void inicioProfundidadeMatrixGrid(string nomeMxg)
        {
            IWebElement mxgControl = _driver.FindElement(By.XPath("//button[@name='begin']"));

            mxgControl.Click();
        }

        public void fimProfundidadeMatrixGrid(string nomeMxg)
        {
            IWebElement mxgControl = _driver.FindElement(By.XPath("//button[@name='end']"));

            mxgControl.Click();
        }

        public void selecionarCelulaMatrixGrid(string nomeMxg, int linha, int coluna, int profundidade)
        {
            //IList<IWebElement> tableRows = mxg.FindElements(By.XPath("//table[@id='tblMatrixGrid1']/tbody/tr"));
            //IList<IWebElement> tableRows = mxg.FindElements(By.Id("tblMatrixGrid1"));

            if (profundidade == 0)
                alterarProfundidadeMatrixGrid(nomeMxg, 0);
            else if (profundidade == 1)
                alterarProfundidadeMatrixGrid(nomeMxg, 1);
            else if (profundidade == 2)
                alterarProfundidadeMatrixGrid(nomeMxg, 2);

            string xpath = "//table[@id='tblMatrixGrid1']/tbody/tr[" + (linha+1) + "]/td[" + (coluna+2) + "]";
            //string xpath = "//td[@tag='mxgDataSource[" + coluna + "," + linha + "," + profundidade + "];0";

            IWebElement mxg = _driver.FindElement(By.Id(nomeMxg));
            IWebElement tableCel = mxg.FindElement(By.XPath(xpath));
            tableCel.Click();
        }

        public string getCelulaMatrixGrid(string nomeMxg, int linha, int coluna, int profundidade)
        {
            if (profundidade == 0)
                alterarProfundidadeMatrixGrid(nomeMxg, 0);
            else if (profundidade == 1)
                alterarProfundidadeMatrixGrid(nomeMxg, 1);
            else if (profundidade == 2)
                alterarProfundidadeMatrixGrid(nomeMxg, 2);

            string xpath = "//table[@id='tblMatrixGrid1']/tbody/tr[" + (linha + 1) + "]/td[" + (coluna + 2) + "]/div/input";

            IWebElement mxg = _driver.FindElement(By.Id(nomeMxg));
            IWebElement tableCel = mxg.FindElement(By.XPath(xpath));

            return tableCel.GetAttribute("value");
        }

        public void setCelulaMatrixGrid(string nomeMxg, int linha, int coluna, int profundidade, int valor)
        {
            if (profundidade == 0)
                alterarProfundidadeMatrixGrid(nomeMxg, 0);
            else if (profundidade == 1)
                alterarProfundidadeMatrixGrid(nomeMxg, 1);
            else if (profundidade == 2)
                alterarProfundidadeMatrixGrid(nomeMxg, 2);

            string xpath = "//table[@id='tblMatrixGrid1']/tbody/tr[" + (linha + 1) + "]/td[" + (coluna + 2) + "]/div/input";

            IWebElement mxg = _driver.FindElement(By.Id(nomeMxg));
            IWebElement tableCel = mxg.FindElement(By.XPath(xpath));
            Actions actionProvider = new Actions(_driver);

            //actionProvider.Click(tableCel).Perform();
            actionProvider.MoveToElement(tableCel,15,0).Click().Perform();
            tableCel.Clear();
            tableCel.SendKeys(valor.ToString());
            tableCel.SendKeys(Keys.Enter);

            Assert.AreEqual(getCelulaMatrixGrid(nomeMxg, linha, coluna, profundidade), valor.ToString());
        }
    }
}