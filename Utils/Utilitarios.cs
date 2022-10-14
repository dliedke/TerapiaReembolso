using System.Net;
using System.Threading;
using System.Diagnostics;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace TerapiaReembolso
{
    internal class Utilitarios
    {
        public static void ScrollAteElemento(ChromeDriver chromeDriver, IWebElement element)
        {
            try
            {
                if (element.Location.Y > 200)
                {
                    // Faz scroll na página até mostrar elemento
                    chromeDriver.ExecuteJavaScript($"window.scrollTo({0}, {element.Location.Y - 600})", null);
                }
            }
            catch { }
        }

        public static void AguardaSpinner(ChromeDriver chromeDriver, int timeoutSecs = 15)
        {
            // Aguarda X segundos enquanto spinner na página está ativo
            for (var i = 0; i < timeoutSecs; i++)
            {
                var ajaxIsComplete = !TentaEncontrarElemento(chromeDriver, By.ClassName("spinner"));
                if (ajaxIsComplete) return;
                Thread.Sleep(1000);
            }
        }

        public static bool TentaEncontrarElemento(ChromeDriver chromeDriver, By by)
        {
            // Verifica se elemento está sendo mostrado
            IWebElement element;
            try
            {
                element = chromeDriver.FindElement(by);
                bool getelement = element.Displayed;
                if (getelement)
                {
                    ScrollAteElemento(chromeDriver, element);

                }
                return getelement;
            }
            catch
            {
                return false;
            }
        }

        public static void CloseChromeDriver(ChromeDriver chromeDriver)
        {
            if (chromeDriver != null)
            {
                try
                {
                    chromeDriver.Quit();
                }
                catch { }
            }
            if (Process.GetProcessesByName("chromedriver").Length > 0)
            {
                foreach(var process in Process.GetProcessesByName("chromedriver"))
                {
                    process.Kill();
                }
            }
        }

        public static bool NecessitaProxy()
        {
            try
            {
                string proxyUrl = "proxy";
                IPAddress[] addresslist = Dns.GetHostAddresses(proxyUrl);
                return true;
            }
            catch
            {
            }

            return false;
        }
    }
}
