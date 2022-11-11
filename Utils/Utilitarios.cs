using System.Net;
using System.Threading;
using System.Diagnostics;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System;

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
            // Aguarda X segundos enquanto spinner na página ainda está ativo
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
            // Fecha o ChromeDriver atual e outros processos
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
            // Verifica se necessita usar proxy
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


        public static string RemoveAcentos(string text)
        {
            try
            {
                // Remove todos acentos do nome do paciente
                StringBuilder sbReturn = new StringBuilder();
                var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
                foreach (char letter in arrayText)
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                        sbReturn.Append(letter);
                }
                return sbReturn.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Remover Acenteos: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return text;
            }
        }
    }
}
