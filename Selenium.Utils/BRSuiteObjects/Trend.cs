using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium.Utils.BRSuiteObjects
{
    public class Trend
    {
        private IWebDriver _driver;
        private IWebElement _areaPlotter;
        private IWebElement _menuContexto;


        public Trend(IWebDriver driver)
        {
            _driver = driver;
        }

        private int _maxXPlotter { get; set; }
        private int _maxYPlotter { get; set; }

        public void ArmazenarPlotter()
        {
            _areaPlotter = _driver.FindElement(By.CssSelector("#Trend1_Chart > canvas.flot-base"));
            _maxXPlotter = _areaPlotter.Size.Width;
            _maxYPlotter = _areaPlotter.Size.Height;
        }

        public void PausarPlotter()
        {
            IWebElement btnPauseTrend = _driver.FindElement(By.Id("Trend1_Pause"));
            Assert.AreEqual(true, btnPauseTrend.Enabled);
            btnPauseTrend.Click();
        }

        public void DarPlayNoPlotter()
        {
            IWebElement btnPlayTrend = _driver.FindElement(By.Id("Trend1_Play"));
            Assert.AreEqual(true, btnPlayTrend.Enabled);
            btnPlayTrend.Click();
        }

        public void ExibirUnicaEscalaVertical()
        {
            IWebElement btnExibirUnicaEscalaVertical = _driver.FindElement(By.Id("Trend1_showYAxis"));

            //background-image: url("./htmlImages/SingleScale.png")
            string backGroundImageSource = btnExibirUnicaEscalaVertical.GetCssValue("background-image").ToLowerInvariant();
            bool backGroundImageCheck = backGroundImageSource.Contains("singlescale.png");
                        
            Assert.AreEqual(true, backGroundImageCheck);
            btnExibirUnicaEscalaVertical.Click();
        }

        public void ExibirMultiplaEscalaVertical()
        {
            IWebElement btnExibirMultiplaEscalaVertical = _driver.FindElement(By.Id("Trend1_showYAxis"));

            //background-image: url("./htmlImages/MultiScales.png")
            string backGroundImageSource = btnExibirMultiplaEscalaVertical.GetCssValue("background-image").ToLowerInvariant();
            bool backGroundImageCheck = backGroundImageSource.Contains("multiscales.png");

            Assert.AreEqual(true, backGroundImageCheck);
            btnExibirMultiplaEscalaVertical.Click();
        }

        public void FazerAutoScale()
        {
            IWebElement btnAutoScale = _driver.FindElement(By.Id("Trend1_autoScale"));
            btnAutoScale.Click();
        }

        public void DesativarDetalhes()
        {
            IWebElement btnDesativarDetalhes = _driver.FindElement(By.Id("Trend1_showDetails"));
            btnDesativarDetalhes.Click();
        }

        public void AtivarDetalhes()
        {
            IWebElement btnAtivarDetalhes = _driver.FindElement(By.Id("Trend1_showDetails"));
            btnAtivarDetalhes.Click();
        }
        
        protected void AtivarMenuDeContexto(int coordenadaX, int coordenadaY)
        {
            /* Firefox Driver
            No support for self-signed certificates
            No support for actions
            No support logging endpoint
            */
            Actions actionBuilder = new Actions(_driver);

            actionBuilder
                .MoveToElement(_areaPlotter,coordenadaX, coordenadaY)
                .ContextClick()
                .Perform();
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _menuContexto = wait.Until(ExpectedConditions.ElementIsVisible
                (By.CssSelector("ul[class ^= 'iw-contextMenu']")));
                
            /*
            _menuContexto = _driver.FindElement
            (By.CssSelector("ul[class ^= 'iw-contextMenu']"));
            */
        }

        public void FazerFitToNow()
        {
            AtivarMenuDeContexto(_maxXPlotter / 2, _maxYPlotter / 2);

            var fitToNow = _menuContexto.FindElement(
                (By.CssSelector("#" + _menuContexto.GetAttribute("id") + " > li:nth-child(1)")));
            fitToNow.Click();
        }

        public void FazerFitScaleToView()
        {
            AtivarMenuDeContexto(_maxXPlotter / 2, _maxYPlotter / 2);

            var fitScaleToViewer = _menuContexto.FindElement(
                (By.CssSelector("#" + _menuContexto.GetAttribute("id") + " > li:nth-child(2)")));
            fitScaleToViewer.Click();
        }

        public void FazerScreenshot()
        {
            AtivarMenuDeContexto(_maxXPlotter / 2, _maxYPlotter / 2);

            var screenshot = _menuContexto.FindElement(
                (By.CssSelector("#" + _menuContexto.GetAttribute("id") + " > li:nth-child(3)")));
            screenshot.Click();
        }

        public void CopiarScreen()
        {
            AtivarMenuDeContexto(_maxXPlotter / 2, _maxYPlotter / 2);

            var copiaScreen = _menuContexto.FindElement(
                (By.CssSelector("#" + _menuContexto.GetAttribute("id") + " > li:nth-child(4)")));
            copiaScreen.Click();
        }

        public void EnviarEmail()
        {
            AtivarMenuDeContexto(_maxXPlotter / 2, _maxYPlotter / 2);

            var enviaEmail = _menuContexto.FindElement(
                (By.CssSelector("#" + _menuContexto.GetAttribute("id") + " > li:nth-child(5)")));
            enviaEmail.Click();
        }

        public void AdicionarCursor()
        {
            AtivarMenuDeContexto(_maxXPlotter / 2, _maxYPlotter / 2);

            var acioneCursor = _menuContexto.FindElement(
             (By.CssSelector("#" + _menuContexto.GetAttribute("id") + " > li:nth-child(6)")));
            acioneCursor.Click();
        }

        public void RemoverCursor()
        {
            AtivarMenuDeContexto(_maxXPlotter / 2, _maxYPlotter / 2);

            var removeCursor = _menuContexto.FindElement(
                (By.CssSelector("#" + _menuContexto.GetAttribute("id") + " > li:nth-child(7)")));
            removeCursor.Click();
        }



    }
}
