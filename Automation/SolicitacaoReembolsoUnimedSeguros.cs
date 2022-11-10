/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Automatizar solicitações de reembolso para terapia no Unimed Seguros
 *           
 * *******************************************************************************************************************/

using System;

// Selenium para automação web
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Pacote para baixar automaticamente último ChormeDriver da Internet
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TerapiaReembolso
{
    public class SolicitacaoReembolsoUnimedSeguros
    {
        private static ChromeDriver _chromeDriver;
        private static IWebElement _element;

        public static void GerarSolicitacaoReembolso()
        {
            AbreSegurosUnimedCliente();
            LoginUnimed();
            SubmeteSolicitaoReembolso();
        }

        public static void AbreSegurosUnimedCliente()
        {
            // Inicia o Chrome maximizado
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
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

            int contadorRetry = 0;

        retryLoad:

            try
            {
                // Erro ao carregar (já tentou 3 vezes)
                if (contadorRetry == 3)
                {
                    throw new ApplicationException("Erro ao carregar site da Unimed Seguros!");
                }

                // Navega para Seguros Unimed Login Cliente
                _chromeDriver.Navigate().GoToUrl("https://www.segurosunimed.com.br/login-cliente");
                _chromeDriver.Manage().Window.Maximize();

                // Verifica se elemento loginInput já está na página
                WaitExtension.WaitUntilElement(_chromeDriver, By.Id("loginInput"), 3);
            }
            catch
            {
                contadorRetry++;
                goto retryLoad;
            }

            // Espera carregar elemento
            WaitExtension.WaitUntilElement(_chromeDriver, By.Id("loginInput"));
            System.Threading.Thread.Sleep(1000);
        }

        public static void LoginUnimed()
        {
            // Caso se tenha um login e senha para entrar
            if (!string.IsNullOrEmpty(TelaPrincipal.PegaClienteAtual().LoginUnimed) && !string.IsNullOrEmpty(TelaPrincipal.PegaClienteAtual().SenhaUnimed))
            {
                int contadorRetry = 0;

            retryLogin:

                try
                {
                    // Erro ao carregar (já tentou 3 vezes)
                    if (contadorRetry == 3)
                    {
                        throw new ApplicationException("Erro ao logar no site da Unimed Seguros!");
                    }

                    // Seta CPF para logar
                    var emailText = _chromeDriver.FindElement(By.Id("loginInput"));
                    emailText.Clear();
                    emailText.SendKeys(TelaPrincipal.PegaClienteAtual().LoginUnimed);

                    // Seta senha para logar
                    var passwordText = _chromeDriver.FindElement(By.Id("senhaInput"));
                    passwordText.Clear();
                    passwordText.SendKeys(TelaPrincipal.PegaClienteAtual().SenhaUnimed);

                    // Submete o formulário
                    emailText.Submit();
                    System.Threading.Thread.Sleep(2000);

                    // Espera aparecer o botão de "Reembolsos e Prévias"
                    WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//div[.=' Reembolsos e Prévias ']"), 5);
                }
                catch
                {
                    contadorRetry++;
                    goto retryLogin;
                }
            }
        }

        public static void SubmeteSolicitaoReembolso()
        {
            VaiParaSolicitacaoReembolso();
            SelecionaPacienteTipoConsulta();
            SelecionaSessoes();
            SobeRecibo();
            SetaInformacoesPsicologo();
            SetaInformacoesBancarias();
        }

        public static void VaiParaSolicitacaoReembolso()
        {
            // Espera aparecer o botão de "Reembolsos e Prévias"
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//div[.=' Reembolsos e Prévias ']"), 30);

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(1000);

            // Espera os spinners todos da página
            Utilitarios.AguardaSpinner(_chromeDriver);

            // Clica em Reembolsos e Prévias
            var botaoReembolsosPrevias = _chromeDriver.FindElement(By.XPath("//div[.=' Reembolsos e Prévias ']"));
            botaoReembolsosPrevias.Click();

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(1000);

            // Espera os spinners todos da página
            Utilitarios.AguardaSpinner(_chromeDriver);

            // Espera botão "Nova solicitação de reembolso" e clica
            By novaSolicitacaoBy = By.XPath("//a[.='Nova solicitação de reembolso']");
            WaitExtension.WaitUntilElement(_chromeDriver, novaSolicitacaoBy);
            var botaoNovaSolicitacao = _chromeDriver.FindElement(novaSolicitacaoBy);
            botaoNovaSolicitacao.Click();

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(2500);

            try
            {
                // Ve se acha o botão de Tente Novamente e clica nele
                By tenteNovamenteBy = By.XPath($"//button[.=' Tente novamente ']");
                WaitExtension.WaitUntilElement(_chromeDriver, tenteNovamenteBy, 3);

                var botaoTenteNovamente = _chromeDriver.FindElement(tenteNovamenteBy);
                botaoTenteNovamente.Click();

                // Espera ainda mais um pouquinho 
                System.Threading.Thread.Sleep(2000);
            }
            catch
            {

            }

            // Espera elemento na página
            try
            {
                WaitExtension.WaitUntilElement(_chromeDriver, By.XPath($"//option[.='Psicólogo']"));
            }
            catch { }
        }

        public static void SelecionaPacienteTipoConsulta()
        {
            // Seleciona paciente
            try
            {
                _element = _chromeDriver.FindElement(By.XPath($"//option[.='{TelaPrincipal.PacienteAtual.Nome}']"));
                _element.Click();
            }
            catch { }

            // Seleciona psicólogo
            _element = _chromeDriver.FindElement(By.XPath($"//option[.='Psicólogo']"));
            _element.Click();

            // Seleciona Presencial se precisar
            if (TelaPrincipal.PegaClienteAtual().TipoAtendimento == "P")
            {
                _element = _chromeDriver.FindElement(By.Id("PRadio"));
                _element.Click();
            }

            // Seleciona Telemedicina se precisar
            if (TelaPrincipal.PegaClienteAtual().TipoAtendimento == "T")
            {
                _element = _chromeDriver.FindElement(By.Id("TRadio"));
                _element.Click();
            }

            // Seleciona checkbox "Não sei o CID"
            _element = _chromeDriver.FindElement(By.XPath($"//label[@for='trueCheckbox']"));
            _element.Click();
        }

        public static void SelecionaSessoes()
        {
            // Clica em "Sessões"
            var elements = _chromeDriver.FindElements(By.CssSelector(".form-control.no-btn.h-100"));
            elements[0].Click();

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(1000);

            // Apaga o 1 e seta quantidade de sessões
            _element = _chromeDriver.FindElement(By.Id("quantitySessionsInput"));
            _element.SendKeys(Keys.Backspace + TelaPrincipal.PacienteAtual.NumeroConsultas.ToString());

            // Seta as datas das sessões e valor da primeira que é replicado nas outras
            for (int i = 0; i < TelaPrincipal.PacienteAtual.NumeroConsultas; i++)
            {
                _element = _chromeDriver.FindElement(By.Id($"dateSessions{i}Input"));
                _element.SendKeys(TelaPrincipal.PacienteAtual.DataConsultaLista[i].ToString("dd/MM/yyyy"));

                if (i == 0)
                {
                    _element = _chromeDriver.FindElement(By.Id($"priceSessions{i}CurrencyInput"));
                    _element.SendKeys(TelaPrincipal.PacienteAtual.Valor);
                }
            }

            // Confirma as datas e valores das sessões
            _element = _chromeDriver.FindElement(By.XPath($"//button[.='Confirmar']"));
            _element.Click();

            // Mostra o valor total calculado
            _element = _chromeDriver.FindElement(By.Id("consultationValueCurrencyInput"));
            Utilitarios.ScrollAteElemento(_chromeDriver, _element);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(4000);
        }

        public static void SobeRecibo()
        {
            // Faz scroll até "Outros documentos"
            _element = _chromeDriver.FindElement(By.XPath($"//div[.=' Outros documentos ']"));
            Utilitarios.ScrollAteElemento(_chromeDriver, _element);

            // Encontra o input de arquivo
            _element = _chromeDriver.FindElement(By.XPath("(//input[@type='file'])[2]"));

            // Seleciona arquivo para envio
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().PDFRecibo);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(3000);
        }

        public static void SetaInformacoesPsicologo()
        {
            // Navega até o CEP
            Utilitarios.ScrollAteElemento(_chromeDriver, _chromeDriver.FindElement(By.Id("cepInput")));

            // Seta nome do psicólogo
            _element = _chromeDriver.FindElement(By.Id("providerNameInput"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().NomeTerapeuta);

            // Seta CPF psicólogo
            _element = _chromeDriver.FindElement(By.Id("inputCpfCnpjInput"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().CPFTerapeuta);

            // Seta número do CRP
            _element = _chromeDriver.FindElement(By.Id("councilNumberInput"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().CRP);

            // Seta número do CEP
            _element = _chromeDriver.FindElement(By.Id("cepInput"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().CEP);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(4000);
        }

        public static void SetaInformacoesBancarias()
        {
            // Seleciona paciente para conta bancária
            var elements = _chromeDriver.FindElements(By.XPath($"//option[.='{TelaPrincipal.PacienteAtual.Nome}']"));
            Utilitarios.ScrollAteElemento(_chromeDriver, elements[1]);
            elements[1].Click();

            // Seta "Transferência em conta corrente"
            _element = _chromeDriver.FindElement(By.XPath($"//option[.='Transferência em conta corrente']"));
            _element.Click();

            // Seta nome do banco
            _element = _chromeDriver.FindElement(By.XPath($"//option[.='{TelaPrincipal.PegaClienteAtual().NomeBanco}']"));
            _element.Click();

            // Seta número da agência
            _element = _chromeDriver.FindElement(By.Id("numberAgencyInput"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().Agencia);

            // Seta número da conta
            _element = _chromeDriver.FindElement(By.Id("bankAccountInput"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().Conta);

            // Seta dígito da conta
            _element = _chromeDriver.FindElement(By.Id("numberAccountInput"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().Digito);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(4000);
        }
    }
}
