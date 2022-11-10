/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Automatizar solicitações de reembolso para terapia no Unimed Acre
 *           
 * *******************************************************************************************************************/

using System;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using AngleSharp.Dom;

// Selenium/Protractor para automação web
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using Protractor;

// Pacote para baixar automaticamente último ChormeDriver da Internet
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TerapiaReembolso
{
    public class SolicitacaoReembolsoUnimedAcre
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
                    throw new ApplicationException("Erro ao carregar site da Unimed Acre!");
                }

                // Navega para Seguros Unimed Login Cliente
                _chromeDriver.Navigate().GoToUrl("http://beneficiario.unimedrb.com.br/mvsaudeweb/#/login/beneficiario");
                _chromeDriver.Manage().Window.Maximize();

                // Verifica se elemento carteira1 já está na página
                WaitExtension.WaitUntilElement(_chromeDriver, By.Id("carteira1"), 3);
            }
            catch
            {
                contadorRetry++;
                goto retryLoad;
            }

            // Espera carregar elemento
            WaitExtension.WaitUntilElement(_chromeDriver, By.Id("carteira1"));
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

                    // Seta número da carteirinha para logar
                    var emailText = _chromeDriver.FindElement(By.Id("carteira1"));
                    emailText.Clear();
                    emailText.SendKeys(TelaPrincipal.PegaClienteAtual().LoginUnimed);

                    // Seta senha para logar
                    var passwordText = _chromeDriver.FindElement(By.Id("password"));
                    passwordText.Clear();
                    passwordText.SendKeys(TelaPrincipal.PegaClienteAtual().SenhaUnimed);

                    // Submete o formulário
                    emailText.Submit();
                    System.Threading.Thread.Sleep(2000);

                    // Espera aparecer o menu "Solicitar"
                    WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//span[contains(text(),'Reembolso')]"), 15);
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
            SetaInformacoesIniciais();
            SetaPrestador();
            SetaProcedimentos();
            SetaDocumentos();
        }
               
        public static void VaiParaSolicitacaoReembolso()
        {
            // Vai para solicitar reembolso
            _chromeDriver.Url="http://beneficiario.unimedrb.com.br/mvsaudeweb/#/beneficiario/reembolso/solicitar/informacoes-iniciais";

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(3000);

            // Espera elemento na página
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//span[@class='select2-arrow']"));

            // Espera os spinners todos da página
            Utilitarios.AguardaSpinner(_chromeDriver);
        }

        private static void SetaInformacoesIniciais()
        {
            // Busca todas flechinas dos dropdowns
            var arrows = _chromeDriver.FindElements(By.XPath("//span[@class='select2-arrow']"));

            // Seleciona tipo de atendimento
            arrows[0].Click();
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//div[contains(text(),'CONSULTA')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath("//div[contains(text(),'CONSULTA')]"));
            _element.Click();

            // Seleciona especialidade
            arrows[1].Click();
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//div[contains(text(),'PSICOLOGO CLINICO')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath("//div[contains(text(),'PSICOLOGO CLINICO')]"));
            _element.Click();

            // Seleciona banco
            //TODO: buscar dinamico valor
            arrows[2].Click();
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//div[contains(text(),'260-BANCO NUBANK ( NUCONTA )')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath("//div[contains(text(),'260-BANCO NUBANK ( NUCONTA )')]"));
            _element.Click();

            // Seta agencia
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nr_agencia"), 15);
            _element = _chromeDriver.FindElement(By.Name("nr_agencia"));
            _element.SendKeys("0001");

            // Seta conta
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nr_conta"), 15);
            _element = _chromeDriver.FindElement(By.Name("nr_conta"));
            _element.SendKeys("5325235");

            // Submete e vai para próxima etapa
            _element.Submit();

            // Espera os spinners todos da página
            Thread.Sleep(1000);
            Utilitarios.AguardaSpinner(_chromeDriver);

            // Espera carregar a página
            WaitExtension.WaitUntilElement(_chromeDriver, By.Id("tppessoa"), 15);
        }

        private static void SetaPrestador()
        {
            // Seta pessoa física
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//option[contains(text(),'Física')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath("//option[contains(text(),'Física')]"));
            _element.Click();

            // Seta nome do psicologo
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nmprestador"), 15);
            _element = _chromeDriver.FindElement(By.Name("nmprestador"));
            _element.SendKeys("psicologo nome");

            // Seta cpf nome do psicologo
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nrcpfcnpj"), 15);
            _element = _chromeDriver.FindElement(By.Name("nrcpfcnpj"));
            _element.SendKeys("82002851034");

            // Seta data do atendimento
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dtatendimento"), 15);
            _element = _chromeDriver.FindElement(By.Name("dtatendimento"));
            _element.SendKeys("07/11/2022");

            // Seta cep
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nrcep"), 15);
            _element = _chromeDriver.FindElement(By.Name("nrcep"));
            _element.SendKeys("91330291");
            Thread.Sleep(2000);

            // Seta endereço
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("endereco"), 15);
            _element = _chromeDriver.FindElement(By.Name("endereco"));
            _element.Clear();
            _element.SendKeys("Matias Jose Bins");

            // Seta número do endereço
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nrendereco"), 15);
            _element = _chromeDriver.FindElement(By.Name("nrendereco"));
            _element.SendKeys("1578");

            // Seta complemento do endereço
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dscomplemento"), 15);
            _element = _chromeDriver.FindElement(By.Name("dscomplemento"));
            _element.SendKeys("sala 8");

            // Seta bairro
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dsbairro"), 15);
            _element = _chromeDriver.FindElement(By.Name("dsbairro"));
            _element.Clear();
            _element.SendKeys("Chacara das pedras");
                        
            // Submete o form
            _element = _chromeDriver.FindElement(By.Name("nmcidade"));
            _element.Submit();

            // Espera os spinners todos da página
            Thread.Sleep(1000);
            Utilitarios.AguardaSpinner(_chromeDriver);
        }

        private static void SetaProcedimentos()
        {
            // Clica botao Buscar procedimento
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//button[contains(text(),'Buscar procedimento')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath("//button[contains(text(),'Buscar procedimento')]"));
            _element.Click();

            // Espera os spinners todos da página
            Thread.Sleep(1000);
            Utilitarios.AguardaSpinner(_chromeDriver);

            // Digita código da terapia
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//input[@placeholder='Pesquisar']"));
            _element = _chromeDriver.FindElement(By.XPath("//input[@placeholder='Pesquisar']"));
            _element.SendKeys("20104219" + Keys.Enter);

            // Espera os spinners todos da página
            Thread.Sleep(2000);
            Utilitarios.AguardaSpinner(_chromeDriver);

            // Double click no TD com o primeiro resultado (Angular)
            var ngDriver = new NgWebDriver(_chromeDriver);
            ngDriver.WaitForAngular();
            var elements = ngDriver.FindElements(NgBy.Repeater("data in options.data"));
            elements[0].Click();
            elements[0].Click();

            // Clica no botão Confirmar
            _element = _chromeDriver.FindElement(By.XPath("//span[contains(text(),'Confirmar')]"));
            var parent = _element.FindElement(By.XPath("./.."));
            parent.Click();

            // Espera os spinners todos da página
            Thread.Sleep(2000);
            Utilitarios.AguardaSpinner(_chromeDriver);

            // Seta data do atendimento
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dtrealizacao"), 15);
            _element = _chromeDriver.FindElement(By.Name("dtrealizacao"));
            _element.SendKeys("07/11/2022");

            // Seta quantidade
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("quantidade"), 15);
            _element = _chromeDriver.FindElement(By.Name("quantidade"));
            _element.SendKeys("1");

            // Seta valor da consulta
            //TODO: buscar dinamico valor
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("vlcobrado"), 15);
            _element = _chromeDriver.FindElement(By.Name("vlcobrado"));
            _element.SendKeys("120,00");

            // Clica no botão adicionar
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//button[contains(text(),'Adicionar')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath("//button[contains(text(),'Adicionar')]"));
            _element.Click();

            // Espera os spinners todos da página
            Thread.Sleep(1000);
            Utilitarios.AguardaSpinner(_chromeDriver);

            // Clica no botão Próximo
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath("//button[contains(text(),'Próximo')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath("//button[contains(text(),'Próximo')]"));
            _element.Click();

            // Espera os spinners todos da página
            Thread.Sleep(1000);
            Utilitarios.AguardaSpinner(_chromeDriver);
        }

        private static void SetaDocumentos()
        {
            // Busca todos input type=file
            var inputFiles = _chromeDriver.FindElements(By.XPath("//input[@type='file']"));

            // Seta carteirinha e pedido médico
            //TODO: buscar dinamico valor
            inputFiles[0].SendKeys(@"C:\temp\Dimitri\Carteirinha Unimed Dimitri e Pedido Medico Terapia Dimitri.pdf");
            Thread.Sleep(8000);

            // Seta identidade
            //TODO: buscar dinamico valor
            inputFiles[0].SendKeys(@"C:\temp\Dimitri\Identidade Dimitri.pdf");
            Thread.Sleep(8000);

            // Seta recibo
            //TODO: buscar dinamico valor
            inputFiles[0].SendKeys(@"C:\temp\Dimitri\Recibo Consulta Dimitri 07 de Novembro Novo.pdf");
            Thread.Sleep(8000);
        }
    }
}
