using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Selenium.Utils.BRSuiteObjects
{
    public class Alarm
    {
        //Fará a ponte com o navegador que será utilizado nos testes
        private IWebDriver _driver;

        public Alarm(IWebDriver driver)
        {
            _driver = driver;
        }

        public void selecionarLinhaAlarme(string nomeAlarme, int linha)
        {
            IWebElement alarme = _driver.FindElement(By.Id(nomeAlarme));
            IList<IWebElement> alarmeRows = alarme.FindElements(By.XPath("//table[@id='tblAlarm1']/tbody/tr"));
            IWebElement txtSelectedGridIndex = _driver.FindElement(By.Id("txtAlmSelectedGridIndex"));

            alarmeRows[linha].Click();
            Assert.AreEqual(txtSelectedGridIndex.GetAttribute("value"), linha);
        }

        public string estadoAlarme(string nomeAlarme, int linha)
        {
            IWebElement alarme = _driver.FindElement(By.Id(nomeAlarme));
            IList<IWebElement> alarmeRows = alarme.FindElements(By.XPath("//table[@id='tblAlarm1']/tbody/tr"));

            string color = alarmeRows[linha].GetCssValue("color");    //GetAttribute("color");

            //string js = "window.document.defaultView.getComputedStyle(window.document.getElementById('outercontainer'), null).getPropertyValue('background-color');";
            //string res = selenium.GetEval(js);

            if (color == "rgba(255, 0, 0, 1)")
                return "alarmado";
            else if (color == "rgba(0, 0, 255, 1)")
                return "retornado";
            else if (color == "rgba(0, 128, 0, 1)")
                return "ack";
            else return "failed";
        }

        public void ackAlarme(string nomeAlarme, int linha)
        {
            IWebElement alarme = _driver.FindElement(By.Id(nomeAlarme));
            IList<IWebElement> alarmeRows = alarme.FindElements(By.XPath("//table[@id='tblAlarm1']/tbody/tr"));
            Actions actionProvider = new Actions(_driver);

            actionProvider.DoubleClick(alarmeRows[linha]).Perform();

            Thread.Sleep(750);
            string color = alarmeRows[linha].GetCssValue("color");       
            Assert.AreEqual(color, "rgba(0, 128, 0, 1)");
        }

        public void ackAlarme(string nomeAlarme, int linha, string tipoAlarme)
        {
            IWebElement alarme = _driver.FindElement(By.Id(nomeAlarme));
            IList<IWebElement> alarmeRows = alarme.FindElements(By.XPath("//table[@id='tblAlarm1']/tbody/tr"));
            Actions actionProvider = new Actions(_driver);

            actionProvider.DoubleClick(alarmeRows[linha]).Perform();

            Thread.Sleep(750);
            if (tipoAlarme != "Freeze" || tipoAlarme != "WatchDog")
            {
                Assert.IsFalse(existeAlarme(nomeAlarme, tipoAlarme));
            }
            else
            {
                string color = alarmeRows[linha].GetCssValue("color");
                Assert.AreEqual(color, "rgba(0, 128, 0, 1)");
            }
        }

        public int encontrarLinhaAlarme(string nomeAlarme, string tipoAlarme)
        {
            IWebElement alarme = _driver.FindElement(By.Id(nomeAlarme));
            IList<IWebElement> alarmeRows = alarme.FindElements(By.XPath("//table[@id='tblAlarm1']/tbody/tr"));
            int linha = 0;

            foreach (var item in alarmeRows)
            {
                if (item.GetAttribute("alarmType") == tipoAlarme)
                    return linha;
                linha++;
            }
            return -1;
        }

        public bool existeAlarme(string nomeAlarme, string tipoAlarme)
        {
            IWebElement alarme = _driver.FindElement(By.Id(nomeAlarme));
            IList<IWebElement> alarmeRows = alarme.FindElements(By.XPath("//table[@id='tblAlarm1']/tbody/tr"));

            foreach( var item in alarmeRows)
            {
                if (item.GetAttribute("alarmType") == tipoAlarme)
                    return true;
            }
            return false;
        }

        public int contarAlarmes(string nomeAlarme, string tipoAlarme)
        {
            IWebElement alarme = _driver.FindElement(By.Id(nomeAlarme));
            IList<IWebElement> alarmeRows = alarme.FindElements(By.XPath("//table[@id='tblAlarm1']/tbody/tr"));
            int count = 0;

            foreach( var item in alarmeRows)
                if (item.GetAttribute("alarmType") == tipoAlarme)
                    count++;

            if (tipoAlarme == "LoLo")
                Assert.AreEqual(count, 3);
            else if (tipoAlarme == "Lo")
                Assert.AreEqual(count, 0);
            else if (tipoAlarme == "Hi")
                Assert.AreEqual(count, 3);
            else if (tipoAlarme == "HiHi")
                Assert.AreEqual(count, 3);
            else if (tipoAlarme == "Deviation")
                Assert.AreEqual(count, 5);
            else if (tipoAlarme == "Freeze")
                Assert.AreEqual(count, 6);
            else if (tipoAlarme == "WatchDog")
                Assert.AreEqual(count, 7);

            return count;
        }
    }
}
