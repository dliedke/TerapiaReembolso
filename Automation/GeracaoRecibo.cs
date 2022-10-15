/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Automatizar geração de recibos para terapia
 *           
 * *******************************************************************************************************************/

using System;
using System.Globalization;

// Selenium para automação web
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Pacote para baixar automaticamente último ChormeDriver da Internet
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TerapiaReembolso
{
    public class GeracaoRecibo
    {
        private static IWebDriver _chromeDriver;
        private static IWebElement _element;

        public static void GerarRecibo()
        {
            AbreReciboOnline();
            CriaNovoRecibo();
        }

        private static void AbreReciboOnline()
        {
            // Inicia o Chrome maximizado
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--ignore-ssl-errors");
            options.AddArgument("no-sandbox");

            // Baixa ultimo ChromeDriver usando proxy se necessário e usa ele
            if (Utilitarios.NecessitaProxy())
            {
                System.Net.WebProxy proxy = new System.Net.WebProxy
                {
                    UseDefaultCredentials = true,
                    Address = new Uri("http://proxy")
                };
                new DriverManager().WithProxy(proxy).SetUpDriver(new ChromeConfig());
            }
            else
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
            }
            _chromeDriver = new ChromeDriver(options);

            // Navega para recibo online
            _chromeDriver.Navigate().GoToUrl("https://www.google.com.br");
            System.Threading.Thread.Sleep(1000);
            _chromeDriver.Navigate().GoToUrl("https://www.reciboonline.com.br/recibo-de-pagamento");

            // Espera carregar elemento
            WaitExtension.WaitUntilElement(_chromeDriver, By.Id("valor"));
            System.Threading.Thread.Sleep(500);
        }

        private static void CriaNovoRecibo()
        {
            // Calcula valor total do recibo conforme número de consultas
            decimal valorRecibo = decimal.Parse(TelaPrincipal.PacienteAtual.Valor.Replace(",","."), CultureInfo.InvariantCulture) * TelaPrincipal.PacienteAtual.NumeroConsultas;

            // Setar valor
            _element = _chromeDriver.FindElement(By.Name("valor"));
            _element.SendKeys(valorRecibo.ToString());

            // Seta nome do pagador
            _element = _chromeDriver.FindElement(By.Name("pagador"));
            _element.SendKeys(TelaPrincipal.PacienteAtual.Nome);

            // Seta CPF do pagador
            _element = _chromeDriver.FindElement(By.Name("cpfCnpjPagador"));
            _element.SendKeys(TelaPrincipal.PacienteAtual.CPF);

            // Seta Referente A
            _element = _chromeDriver.FindElement(By.Name("referente"));
            _element.SendKeys(TelaPrincipal.PacienteAtual.ReferenteA);

            // Seta cidade
            _element = _chromeDriver.FindElement(By.Name("cidade"));
            _element.SendKeys(TelaPrincipal.Config.Cidade);

            // Seta nome do emissor
            _element = _chromeDriver.FindElement(By.Name("emissor"));
            _element.SendKeys(TelaPrincipal.Config.NomeTerapeuta);

            // Seta CPF do emissor
            _element = _chromeDriver.FindElement(By.Name("cpfCnpjEmissor"));
            _element.SendKeys(TelaPrincipal.Config.CPFTerapeuta);

            // Cria string com data das consultas
            string dias = string.Empty;
            int total = 1;
            foreach(DateTime data in TelaPrincipal.PacienteAtual.DataConsultaLista)
            {
                dias += data.ToString("dd/MM/yyyy, ");

                total++;
                if (total > TelaPrincipal.PacienteAtual.NumeroConsultas)
                {
                    break;
                }
            }
            dias = dias.TrimEnd().TrimEnd(',');

            // Cria observacoes com dias das consultas, endereço, CEP e CRP
            string observacoes = $"Sessões de Psicoterapia nos dias {dias}.\n\nEndereço: {TelaPrincipal.Config.EnderecoTerapeuta}\n\nCEP: {TelaPrincipal.Config.CEP}\n\nCRP: {TelaPrincipal.Config.CRP}";

            // Seta as observacoes e submete formulario
            _element = _chromeDriver.FindElement(By.Name("observacoes"));
            _element.SendKeys(observacoes);
            _element.Submit();

            // Aguarda um pouco geração do recibo
            System.Threading.Thread.Sleep(1000);

            // Aguarda elemento e manda imprimir PDF
            By spanImprimirBy = By.XPath("//span[text()='IMPRIMIR']");
            WaitExtension.WaitUntilElement(_chromeDriver, spanImprimirBy);
            _element = _chromeDriver.FindElement(spanImprimirBy);
            _element.Click();
        }
    }
}
