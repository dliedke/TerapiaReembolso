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

// Selenium/Protractor para automação web
using Protractor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Pacote para baixar automaticamente último ChormeDriver da Internet
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Text;

namespace TerapiaReembolso
{
    public class SolicitacaoReembolsoUnimedAcre
    {
        private static ChromeDriver _chromeDriver;
        private static IWebElement _element;

        public static void GerarSolicitacaoReembolso()
        {
            AbreUnimedAcre();
            LoginUnimedAcre();
            SubmeteSolicitaoReembolso();
        }

        public static void AbreUnimedAcre()
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

        public static void LoginUnimedAcre()
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
                    emailText.SendKeys(TelaPrincipal.PegaPacienteAcre().CarteirinhaUnimed);

                    // Seta senha para logar
                    var passwordText = _chromeDriver.FindElement(By.Id("password"));
                    passwordText.Clear();
                    passwordText.SendKeys(TelaPrincipal.PegaPacienteAcre().CarteirinhaUnimed);

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
            arrows[2].Click();
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath($"//div[contains(text(),'{TelaPrincipal.PegaPacienteAcre().NomeBanco}')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath($"//div[contains(text(),'{TelaPrincipal.PegaPacienteAcre().NomeBanco}')]"));
            _element.Click();

            // Seta agencia
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nr_agencia"), 15);
            _element = _chromeDriver.FindElement(By.Name("nr_agencia"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().Agencia);

            // Seta conta e dígito
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nr_conta"), 15);
            _element = _chromeDriver.FindElement(By.Name("nr_conta"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().Conta + TelaPrincipal.PegaClienteAtual().Digito);

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

            // Seta nome do psicologo sem acentos
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nmprestador"), 15);
            _element = _chromeDriver.FindElement(By.Name("nmprestador"));
            _element.SendKeys(Utilitarios.RemoveAcentos(TelaPrincipal.PegaClienteAtual().NomeTerapeuta));

            // Seta cpf nome do psicologo
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nrcpfcnpj"), 15);
            _element = _chromeDriver.FindElement(By.Name("nrcpfcnpj"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().CPFTerapeuta);

            // Seta data do atendimento
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dtatendimento"), 15);
            _element = _chromeDriver.FindElement(By.Name("dtatendimento"));
            _element.SendKeys(TelaPrincipal.PacienteAtual.DataConsultaLista[0].ToString("dd/MM/yyyy"));

            // Seta cep
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nrcep"), 15);
            _element = _chromeDriver.FindElement(By.Name("nrcep"));
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().CEP);
            Thread.Sleep(2000);

            // Seta endereço
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("endereco"), 15);
            _element = _chromeDriver.FindElement(By.Name("endereco"));
            _element.Clear();
            _element.SendKeys(TelaPrincipal.PegaPacienteAcre().EnderecoRua);

            // Seta número do endereço
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("nrendereco"), 15);
            _element = _chromeDriver.FindElement(By.Name("nrendereco"));
            _element.SendKeys(TelaPrincipal.PegaPacienteAcre().EnderecoNumero);

            // Seta complemento do endereço
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dscomplemento"), 15);
            _element = _chromeDriver.FindElement(By.Name("dscomplemento"));
            _element.SendKeys(TelaPrincipal.PegaPacienteAcre().EnderecoComplemento);

            // Seta bairro
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dsbairro"), 15);
            _element = _chromeDriver.FindElement(By.Name("dsbairro"));
            _element.Clear();
            _element.SendKeys(TelaPrincipal.PegaPacienteAcre().Bairro);
                        
            // Seta a cidade
            _element = _chromeDriver.FindElement(By.Name("nmcidade"));
            _element.Clear();
            _element.SendKeys(TelaPrincipal.PegaClienteAtual().Cidade);

            // Busca todas flechinas dos dropdowns
            var arrows = _chromeDriver.FindElements(By.XPath("//span[@class='select2-arrow']"));

            // Seleciona estado
            arrows[2].Click();
            WaitExtension.WaitUntilElement(_chromeDriver, By.XPath($"//div[contains(text(),'{TelaPrincipal.PegaPacienteAcre().Estado}')]"), 15);
            _element = _chromeDriver.FindElement(By.XPath($"//div[contains(text(),'{TelaPrincipal.PegaPacienteAcre().Estado}')]"));
            _element.Click();

            // Submete o form
            _element = _chromeDriver.FindElement(By.Name("nmcidade"));
            _element.Submit();

            // Espera os spinners todos da página
            Thread.Sleep(1000);
            Utilitarios.AguardaSpinner(_chromeDriver);
        }

        private static void SetaProcedimentos()
        {
            // Cria descrição com as datas das consultas
            StringBuilder sbDescricao; 

            if (TelaPrincipal.PacienteAtual.NumeroConsultas==1)
            {
                sbDescricao = new StringBuilder("Consulta na data: ");
            }
            else
            {
                sbDescricao = new StringBuilder("Consultas nas datas: ");
            }

            for (int f = 0; f < TelaPrincipal.PacienteAtual.NumeroConsultas; f++)
            {
                sbDescricao.Append(TelaPrincipal.PacienteAtual.DataConsultaLista[f].ToString("dd/MM/yyyy") + ", ");
            }

            string descricao = sbDescricao.ToString().Trim().TrimEnd(',');

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

            // Double click no TD com o primeiro resultado (Angular usando NgWebDriver)
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
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dtrealizacao"), 15);
            _element = _chromeDriver.FindElement(By.Name("dtrealizacao"));
            _element.SendKeys(TelaPrincipal.PacienteAtual.DataConsultaLista[0].ToString("dd/MM/yyyy"));

            // Seta data do recibo
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dtreceita"), 15);
            _element = _chromeDriver.FindElement(By.Name("dtreceita"));
            _element.SendKeys(TelaPrincipal.PegaPacienteAcre().DataRecibo);

            // Seta quantidade
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("quantidade"), 15);
            _element = _chromeDriver.FindElement(By.Name("quantidade"));
            _element.SendKeys(TelaPrincipal.PacienteAtual.NumeroConsultas.ToString());

            // Seta valor da consulta
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("vlcobrado"), 15);
            _element = _chromeDriver.FindElement(By.Name("vlcobrado"));
            _element.SendKeys(TelaPrincipal.PacienteAtual.Valor);

            // Seta descricao com as datas das consultas
            WaitExtension.WaitUntilElement(_chromeDriver, By.Name("dsadicional"), 15);
            _element = _chromeDriver.FindElement(By.Name("dsadicional"));
            _element.SendKeys(descricao);

            // Espera um pouco para usuário poder verificar os campos
            Thread.Sleep(5000);

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
            // Busca todos elementos input type=file
            var inputFiles = _chromeDriver.FindElements(By.XPath("//input[@type='file']"));

            // Carrega arquivo da carteirinha e pedido médico
            inputFiles[0].SendKeys(TelaPrincipal.PegaPacienteAcre().PDFCarteirinhaRequisicao);
            Thread.Sleep(8000);

            // Carrega arquivo da identidade
            inputFiles[0].SendKeys(TelaPrincipal.PegaPacienteAcre().PDFIdentidade);
            Thread.Sleep(8000);

            // Carrega arquivo do recibo
            inputFiles[0].SendKeys(TelaPrincipal.PegaClienteAtual().PDFRecibo);
            Thread.Sleep(8000);
        }
    }
}
