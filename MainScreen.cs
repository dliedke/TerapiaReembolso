/* *******************************************************************************************************************
 * Application: TerapiaReembolso
 * 
 * Author:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Purpose: Automate receipt generation and refund for therapy
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

using Keys = OpenQA.Selenium.Keys;
using System.Net;

namespace TerapiaReembolso
{
    public partial class MainScreen : Form
    {
        #region Inicialização da Aplicação

        private IWebDriver chromeDriver;
        private IWebElement element;

        private string _NomePaciente;
        private string _ValorConsulta;
        private string _CPFPaciente;
        private string _ReferenteA;
        private string _Cidade;
        private string _NomeTerapeuta;
        private string _CPFTerapeuta;
        private string _CRP;
        private string _CEP;
        private string _EnderecoTerapeuta;
        private string _TipoAtendimento;
        private string _NomeBanco;
        private string _Agencia;
        private string _Conta;
        private string _Digito;
        private int _NumeroConsultas;
        private DateTime _DataConsulta1;
        private DateTime _DataConsulta2;
        private DateTime _DataConsulta3;
        private DateTime _DataConsulta4;
        private DateTime _DataConsulta5;
        private string _SenhaUnimed;
        private string _PDFRecibo;
        private DateTimePicker[] datasConsultasControles;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // Copia configurações da versão anterior se for preciso
            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
            }

            // Seta controles de datas e atualiza a tela
            datasConsultasControles = new DateTimePicker[] { dtDataConsulta1, dtDataConsulta2, dtDataConsulta3, dtDataConsulta4, dtDataConsulta5 };
            numNumeroConsultas_ValueChanged(null, EventArgs.Empty);

            MostraVersaoAplicacao();
            MostraBoasVindas();
            CarregaDadosSalvos();
        }

        private void MostraVersaoAplicacao()
        {
            string windowTitle = "Terapia Reembolso";

            // Sets the application version in the windows title
            Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            windowTitle = windowTitle + " v" + ver.Major + "." + ver.Minor;
            this.Text = windowTitle;
        }

        private void MostraBoasVindas()
        {
            if (DateTime.Now.Hour <= 12)
            {
                toolStripStatus.Text = "Bom dia!";
            }
            else if (DateTime.Now.Hour <= 18)
            {
                toolStripStatus.Text = "Boa Tarde!";
            } 
            else
            {
                toolStripStatus.Text = "Boa Noite!";
            }
        }

        #endregion

        #region Selecionar Recibo PDF e Validação de Dados

        private void btnSelectPDF_Click(object sender, EventArgs e)
        {
            // Pede PDF pro usuário
            DialogResult dialogResult = dialogPDF.ShowDialog();

            // Se arquivo foi selecionado
            if (dialogResult == DialogResult.OK)
            {
                // Verifica extensão do arquivo
                if (Path.GetExtension(dialogPDF.FileName).ToLower() != ".pdf")
                {
                    MessageBox.Show("Favor selecionar um arquivo PDF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dialogPDF.FileName = "";
                }
                else
                {
                    _PDFRecibo = dialogPDF.FileName;
                }

                // Mostra nome do PDF na tela
                lblNomeReciboPDF.Text = Path.GetFileName(dialogPDF.FileName);
            }
        }

        private bool ValidaDadosParaRecibo()
        {
            // Valida nome do paciente
            if (string.IsNullOrEmpty(txtNomeDoPaciente.Text))
            {
                MessageBox.Show("Favor entrar nome do paciente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeDoPaciente.Focus();
                txtNomeDoPaciente.SelectAll();
                return false;
            }

            // Valida formato do valor
            var formatinfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = ""
            };

            if (string.IsNullOrEmpty(txtValorTotal.Text) || float.TryParse(txtValorTotal.Text, NumberStyles.Float, formatinfo, out float amount) == false)
            {
                MessageBox.Show("Favor entrar o valor com dois dígitos depois da virgula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorTotal.Focus();
                txtValorTotal.SelectAll();
                return false;
            }

            // Valida valor maior que zero
            if (amount <= 0)
            {
                MessageBox.Show("Valor deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorTotal.Focus();
                txtValorTotal.SelectAll();
                return false;
            }

            // Valida valor com dois digitos depois da virgual
            if (!Regex.IsMatch(Regex.Escape(txtValorTotal.Text), @"^[0-9]+\,[0-9]{2}$"))
            {
                MessageBox.Show("Favor entrar o valor com dois dígitos depois da virgula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorTotal.Focus();
                txtValorTotal.SelectAll();
                return false;
            }

            // Valida CPF do paciente
            if (string.IsNullOrEmpty(txtCPFPaciente.Text))
            {
                MessageBox.Show("Favor entrar CPF do paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFPaciente.Focus();
                txtCPFPaciente.SelectAll();
                return false;
            }

            if (!ValidaDigitoCPF.ValidaCPFFormato(txtCPFPaciente.Text))
            {
                MessageBox.Show("Favor entrar CPF do paciente somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFPaciente.Focus();
                txtCPFPaciente.SelectAll();
                return false;
            }

            if (!ValidaDigitoCPF.ValidaCPFValor(txtCPFPaciente.Text))
            {
                MessageBox.Show("Favor entrar CPF do paciente válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFPaciente.Focus();
                txtCPFPaciente.SelectAll();
                return false;
            }

            // Valida Referente A
            if (string.IsNullOrEmpty(txtReferenteA.Text))
            {
                MessageBox.Show("Favor entrar Referente A.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReferenteA.Focus();
                txtReferenteA.SelectAll();
                return false;
            }

            // Valida Cidade
            if (string.IsNullOrEmpty(txtCidade.Text))
            {
                MessageBox.Show("Favor entrar cidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCidade.Focus();
                txtCidade.SelectAll();
                return false;
            }

            // Valida nome do terapeuta
            if (string.IsNullOrEmpty(txtNomeDoTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar nome do terapeuta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeDoTerapeuta.Focus();
                txtNomeDoTerapeuta.SelectAll();
                return false;
            }

            // Valida CPF do terapeuta
            if (string.IsNullOrEmpty(txtCPFTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar CPF do terapeuta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFTerapeuta.Focus();
                txtCPFTerapeuta.SelectAll();
                return false;
            }

            if (!ValidaDigitoCPF.ValidaCPFFormato(txtCPFTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar CPF do terapeuta somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFTerapeuta.Focus();
                txtCPFTerapeuta.SelectAll();
                return false;
            }

            if (!ValidaDigitoCPF.ValidaCPFValor(txtCPFTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar CPF do terapeuta válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFTerapeuta.Focus();
                txtCPFTerapeuta.SelectAll();
                return false;
            }

            // Valida CRP
            if (string.IsNullOrEmpty(txtCRP.Text))
            {
                MessageBox.Show("Favor entrar CRP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCRP.Focus();
                txtCRP.SelectAll();
                return false;
            }

            // Valida CEP
            if (string.IsNullOrEmpty(txtCEP.Text))
            {
                MessageBox.Show("Favor entrar CEP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCEP.Focus();
                txtCEP.SelectAll();
                return false;
            }

            // Valida Endereço do Terapeuta
            if (string.IsNullOrEmpty(txtEnderecoTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar Endereço do Terapeuta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoTerapeuta.Focus();
                txtEnderecoTerapeuta.SelectAll();
                return false;
            }

            return true;
        }

        private bool ValidaDadosParaReembolso()
        {
            // Valida Senha Unimed
            if (string.IsNullOrEmpty(txtSenhaUnimed.Text))
            {
                MessageBox.Show("Favor entrar Senha Unimed.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenhaUnimed.Focus();
                txtSenhaUnimed.SelectAll();
                return false;
            }

            // Valida Nome do Banco
            if (string.IsNullOrEmpty(txtNomeDoBanco.Text))
            {
                MessageBox.Show("Favor entrar Nome do Banco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeDoBanco.Focus();
                txtNomeDoBanco.SelectAll();
                return false;
            }

            // Valida Agencia
            if (string.IsNullOrEmpty(txtAgenciaSemDigito.Text))
            {
                MessageBox.Show("Favor entrar Agencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgenciaSemDigito.Focus();
                txtAgenciaSemDigito.SelectAll();
                return false;
            }

            // Valida Conta
            if (string.IsNullOrEmpty(txtContaSemDigito.Text))
            {
                MessageBox.Show("Favor entrar Conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContaSemDigito.Focus();
                txtContaSemDigito.SelectAll();
                return false;
            }

            // Valida Dígito da Conta
            if (string.IsNullOrEmpty(txtDigitoDaConta.Text))
            {
                MessageBox.Show("Favor entrar Dígito da Conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDigitoDaConta.Focus();
                txtDigitoDaConta.SelectAll();
                return false;
            }

            // Validate the PDF receipt
            if (string.IsNullOrEmpty(dialogPDF.FileName))
            {
                MessageBox.Show("Favor selecionar PDF do recibo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSelecionarPDFRecibo.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Carrega/Salva Dados

        private void CarregaDadosSalvos()
        {
            try
            { 
                txtNomeDoPaciente.Text = Properties.Settings.Default["NomePaciente"].ToString();
                txtValorTotal.Text = Properties.Settings.Default["ValorTotal"].ToString();
                txtCPFPaciente.Text = Properties.Settings.Default["CPFPaciente"].ToString();
                txtReferenteA.Text = Properties.Settings.Default["ReferenteA"].ToString();
                txtCidade.Text = Properties.Settings.Default["Cidade"].ToString();
                txtNomeDoTerapeuta.Text = Properties.Settings.Default["NomeTerapeuta"].ToString();
                txtCPFTerapeuta.Text = Properties.Settings.Default["CPFTerapeuta"].ToString();
                txtCRP.Text = Properties.Settings.Default["CRP"].ToString();
                txtCEP.Text = Properties.Settings.Default["CEP"].ToString();
                txtEnderecoTerapeuta.Text = Properties.Settings.Default["EnderecoTerapeuta"].ToString();
                rbTelemedicina.Checked = Properties.Settings.Default["TipoAtendimento"].ToString() == "T";
                rbPresencial.Checked = Properties.Settings.Default["TipoAtendimento"].ToString() == "P";
                txtNomeDoBanco.Text = Properties.Settings.Default["NomeBanco"].ToString();
                txtAgenciaSemDigito.Text = Properties.Settings.Default["Agencia"].ToString();
                txtContaSemDigito.Text = Properties.Settings.Default["Conta"].ToString();
                txtDigitoDaConta.Text = Properties.Settings.Default["Digito"].ToString();
                txtSenhaUnimed.Text = Encryption.DecryptString(Properties.Settings.Default["SenhaUnimed"].ToString());
                numNumeroConsultas.Value = decimal.Parse(Properties.Settings.Default["NumeroConsultas"].ToString());

                // Carrega datas se tiver alguma salva
                if (DateTime.TryParse(Properties.Settings.Default["DataConsulta1"].ToString(), out DateTime dateTime1))
                {
                    if (dateTime1.Year > 1)
                    {
                        dtDataConsulta1.Value = (DateTime)Properties.Settings.Default["DataConsulta1"];
                    }
                }

                if (DateTime.TryParse(Properties.Settings.Default["DataConsulta2"].ToString(), out DateTime dateTime2))
                {
                    if (dateTime2.Year > 1)
                    {
                        dtDataConsulta2.Value = (DateTime)Properties.Settings.Default["DataConsulta2"];
                    }
                }

                if (DateTime.TryParse(Properties.Settings.Default["DataConsulta3"].ToString(), out DateTime dateTime3))
                {
                    if (dateTime3.Year > 1)
                    {
                        dtDataConsulta3.Value = (DateTime)Properties.Settings.Default["DataConsulta3"];
                    }
                }

                if (DateTime.TryParse(Properties.Settings.Default["DataConsulta4"].ToString(), out DateTime dateTime4))
                {
                    if (dateTime4.Year > 1)
                    {
                        dtDataConsulta4.Value = (DateTime)Properties.Settings.Default["DataConsulta4"];
                    }
                }

                if (DateTime.TryParse(Properties.Settings.Default["DataConsulta5"].ToString(), out DateTime dateTime5))
                {
                    if (dateTime5.Year > 1)
                    {
                        dtDataConsulta5.Value = (DateTime)Properties.Settings.Default["DataConsulta5"];
                    }
                }
            }
            catch
            {

            }
        }

        private void SalvaDadosAtuais()
        {
            _NomePaciente = txtNomeDoPaciente.Text;
            Properties.Settings.Default["NomePaciente"] = _NomePaciente;

            _ValorConsulta = txtValorTotal.Text;
            Properties.Settings.Default["ValorTotal"] = _ValorConsulta;

            _CPFPaciente = txtCPFPaciente.Text;
            Properties.Settings.Default["CPFPaciente"] = _CPFPaciente;

            _ReferenteA = txtReferenteA.Text;
            Properties.Settings.Default["ReferenteA"] = _ReferenteA;

            _Cidade = txtCidade.Text;
            Properties.Settings.Default["Cidade"] = _Cidade;

            _NomeTerapeuta = txtNomeDoTerapeuta.Text;
            Properties.Settings.Default["NomeTerapeuta"] = _NomeTerapeuta;

            _CPFTerapeuta = txtCPFTerapeuta.Text;
            Properties.Settings.Default["CPFTerapeuta"] = _CPFTerapeuta;

            _CRP = txtCRP.Text;
            Properties.Settings.Default["CRP"] = _CRP;

            _CEP = txtCEP.Text;
            Properties.Settings.Default["CEP"] = _CEP;

            _EnderecoTerapeuta = txtEnderecoTerapeuta.Text;
            Properties.Settings.Default["EnderecoTerapeuta"] = _EnderecoTerapeuta;

            _TipoAtendimento = rbTelemedicina.Checked ? "T" : "P";
            Properties.Settings.Default["TipoAtendimento"] = _TipoAtendimento;

            _NomeBanco = txtNomeDoBanco.Text;
            Properties.Settings.Default["NomeBanco"] = _NomeBanco;

            _Agencia = txtAgenciaSemDigito.Text;
            Properties.Settings.Default["Agencia"] = _Agencia;

            _Conta = txtContaSemDigito.Text;
            Properties.Settings.Default["Conta"] = _Conta;

            _Digito = txtDigitoDaConta.Text;
            Properties.Settings.Default["Digito"] = _Digito;

            _NumeroConsultas = (int)numNumeroConsultas.Value;
            Properties.Settings.Default["NumeroConsultas"] = _NumeroConsultas;

            _DataConsulta1 = dtDataConsulta1.Value;
            Properties.Settings.Default["DataConsulta1"] = _DataConsulta1;

            _DataConsulta2 = dtDataConsulta2.Value;
            Properties.Settings.Default["DataConsulta2"] = _DataConsulta2;

            _DataConsulta3 = dtDataConsulta3.Value;
            Properties.Settings.Default["DataConsulta3"] = _DataConsulta3;

            _DataConsulta4 = dtDataConsulta4.Value;
            Properties.Settings.Default["DataConsulta4"] = _DataConsulta4;

            _DataConsulta5 = dtDataConsulta5.Value;
            Properties.Settings.Default["DataConsulta5"] = _DataConsulta5;

            _SenhaUnimed = txtSenhaUnimed.Text;
            Properties.Settings.Default["SenhaUnimed"] = Encryption.EncryptString(_SenhaUnimed);

            _PDFRecibo = dialogPDF.FileName;

            // Saves settings in application configuration file
            Properties.Settings.Default.Save();
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the data from the screen when closing
            SalvaDadosAtuais();

            // Close Chrome Driver
            CloseChromeDriver();
        }

        #endregion

        #region Gerar Recibo

        private void btnGerarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida os dados do recibo
                if (ValidaDadosParaRecibo())
                {
                    Action action = (Action)GerarRecibo;
                    RodaAutomacao(action);
                    toolStripStatus.Text = "Recibo gerado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                CloseChromeDriver();

                if (ex.Message.Contains("This version of ChromeDriver only supports Chrome version"))
                {
                    MessageBox.Show("Erro interno na aplicação: " + ex.Message + "\r\n\r\nAbra o Chrome manualmente, clique nos 3 pontos no canto superior direito, vá para \"Ajuda\", depois em \"Sobre o Google Chrome\" e atualize seu navegador Chrome para a versão mais recente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro interno na aplicação: " + ex.Message + "\r\n\r\nFavor tentar de novo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                toolStripStatus.Text = "Aguardando";
            }
            finally
            {
                EnableDisableControls(true);
            }
        }

        private void RodaAutomacao(Action action)
        {
            toolStripStatus.Text = "Rodando automação (feche o Chrome se quiser abortar). Por favor, espere...";
            EnableDisableControls(false);
            Application.DoEvents();

            // Salva tudo
            SalvaDadosAtuais();

            // Gera recibo em uma nova tarefa
            Task task = Task.Run(action);

            // Aguarda a tarefa completar sem trancar a UI
            while (!task.IsCompleted)
            {
                System.Threading.Thread.Sleep(500);
                Application.DoEvents();
            }

            // Se a tarefa não completar lançar a excessão interna da tarefa
            if (task.IsFaulted)
            {
                if (task.Exception?.InnerException != null)
                {
                    throw task.Exception.InnerException;
                }
                if (task.Exception != null)
                {
                    throw task.Exception;
                }
            }
        }

        private void GerarRecibo()
        {
            AbreReciboOnline();
            CriaNovoRecibo();
        }

        private void EnableDisableControls(bool enable)
        {
            pnlConsultas.Enabled = enable;
            pnlRecibo.Enabled = enable;
            pnlReembolso.Enabled = enable;
        }

        private void CloseChromeDriver()
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
                Process.GetProcessesByName("chromedriver")[0].Kill();
            }
        }

        private bool NecessitaProxy()
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
        private void AbreReciboOnline()
        {
            // Inicia o Chrome maximizado
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("no-sandbox");

            // Baixa ultimo ChromeDriver usando proxy se necessário e usa ele
            if (NecessitaProxy())
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
            chromeDriver = new ChromeDriver(options);

            // Navega para recibo online
            chromeDriver.Navigate().GoToUrl("https://www.reciboonline.com.br/recibo-de-pagamento");

            // Espera carregar elemento
            WaitExtension.WaitUntilElement(chromeDriver, By.Id("valor"));
            System.Threading.Thread.Sleep(500);
        }

        private void CriaNovoRecibo()
        {
            // Calcula valor total do recibo conforme número de consultas
            decimal valorRecibo = decimal.Parse(_ValorConsulta) * numNumeroConsultas.Value;

            // Setar valor
            element = chromeDriver.FindElement(By.Name("valor"));
            element.SendKeys(valorRecibo.ToString());

            // Seta nome do pagador
            element = chromeDriver.FindElement(By.Name("pagador"));
            element.SendKeys(_NomePaciente);

            // Seta CPF do pagador
            element = chromeDriver.FindElement(By.Name("cpfCnpjPagador"));
            element.SendKeys(_CPFPaciente);

            // Seta Referente A
            element = chromeDriver.FindElement(By.Name("referente"));
            element.SendKeys(_ReferenteA);

            // Seta cidade
            element = chromeDriver.FindElement(By.Name("cidade"));
            element.SendKeys(_Cidade);

            // Seta nome do emissor
            element = chromeDriver.FindElement(By.Name("emissor"));
            element.SendKeys(_NomeTerapeuta);

            // Seta CPF do emissor
            element = chromeDriver.FindElement(By.Name("cpfCnpjEmissor"));
            element.SendKeys(_CPFTerapeuta);
            
            // Cria string com data das consultas
            string dias = string.Empty;
            for (int f = 1; f <= numNumeroConsultas.Value; f++)
            {
                dias += datasConsultasControles[f-1].Value.ToString("dd/MM/yyyy, ");
            }
            dias = dias.TrimEnd().TrimEnd(',');

            // Cria observacoes com dias das consultas, endereço, CEP e CRP
            string observacoes = $"Sessões de Psicoterapia nos dias {dias}.\n\nEndereço: {txtEnderecoTerapeuta.Text}\n\nCEP: {txtCEP.Text}\n\nCRP: {txtCRP.Text}";

            // Seta as observacoes e submete formulario
            element = chromeDriver.FindElement(By.Name("observacoes"));
            element.SendKeys(observacoes);
            element.Submit();

            // Aguarda um pouco geração do recibo
            System.Threading.Thread.Sleep(1000);

            // Aguarda elemento e manda imprimir PDF
            By spanImprimirBy = By.XPath("//span[text()='IMPRIMIR']");
            WaitExtension.WaitUntilElement(chromeDriver, spanImprimirBy);
            element = chromeDriver.FindElement(spanImprimirBy);
            element.Click();
        }

        #endregion

        #region Gerar Solicitação Reembolso

        private void btnGerarSolicitacaoReembolso_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida os dados do reembolso
                if (ValidaDadosParaReembolso())
                {
                    Action action = (Action)GerarSolicitacaoReembolso;
                    RodaAutomacao(action);

                    string msg = "Solicitação de reembolso preenchida, favor revisar formulário e submeter!";
                    MessageBox.Show(msg, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatus.Text = msg;
                }
            }
            catch (Exception ex)
            {
                CloseChromeDriver();

                if (ex.Message.Contains("This version of ChromeDriver only supports Chrome version"))
                {
                    MessageBox.Show("Erro interno na aplicação: " + ex.Message + "\r\n\r\nAbra o Chrome manualmente, clique nos 3 pontos no canto superior direito, vá para \"Ajuda\", depois em \"Sobre o Google Chrome\" e atualize seu navegador Chrome para a versão mais recente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro interno na aplicação: " + ex.Message + "\r\n\r\nFavor tentar de novo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                toolStripStatus.Text = "Aguardando";
            }
            finally
            {
                EnableDisableControls(true);
            }
        }

        private void GerarSolicitacaoReembolso()
        {
            AbreSegurosUnimedClient();
            LoginUnimed();
            SubmeteSolicitaoReembolso();
        }

        private void AbreSegurosUnimedClient()
        {
            // Inicia o Chrome maximizado
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("no-sandbox");

            // Baixa ultimo ChromeDriver usando proxy se necessário e usa ele
            if (NecessitaProxy())
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
            chromeDriver = new ChromeDriver(options);

            // Navega para Seguros Unimed Login Cliente
            chromeDriver.Navigate().GoToUrl("https://www.segurosunimed.com.br/login-cliente");

            // Espera carregar elemento
            WaitExtension.WaitUntilElement(chromeDriver, By.Id("loginInput"));
            System.Threading.Thread.Sleep(1000);
        }

        private void LoginUnimed()
        {
            // Seta CPF para logar
            var emailText = chromeDriver.FindElement(By.Id("loginInput"));
            emailText.SendKeys(_CPFPaciente);

            // Seta senha para logar
            var passwordText = chromeDriver.FindElement(By.Id("senhaInput"));
            passwordText.SendKeys(_SenhaUnimed);

            // Submete o formulário
            passwordText.Submit();
            System.Threading.Thread.Sleep(1500);

            // Espera aparecer o botão de "Reembolsos e Prévias"
            WaitExtension.WaitUntilElement(chromeDriver, By.XPath("//div[.=' Reembolsos e Prévias ']"), 30);

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(1000);

            // Espera os spinners todos da página
            AguardaSpinner(30);
        }

        private void SubmeteSolicitaoReembolso()
        {
            VaiParaSolicitacaoReembolso();
            SelecionaPacienteTipoConsulta();
            SelecionaSessoes();
            SobeRecibo();
            SetaInformacoesPsicologo();
            SetaInformacoesBancarias();
        }

        private void VaiParaSolicitacaoReembolso()
        {
            // Clica em Reembolsos e Prévias
            var botaoReembolsosPrevias = chromeDriver.FindElement(By.XPath("//div[.=' Reembolsos e Prévias ']"));
            botaoReembolsosPrevias.Click();

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(1000);

            // Espera os spinners todos da página
            AguardaSpinner(30);

            // Espera botão "Nova solicitação de reembolso" e clica
            By novaSolicitacaoBy = By.XPath("//a[.='Nova solicitação de reembolso']");
            WaitExtension.WaitUntilElement(chromeDriver, novaSolicitacaoBy);
            var botaoNovaSolicitacao = chromeDriver.FindElement(novaSolicitacaoBy);
            botaoNovaSolicitacao.Click();

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(2500);

            // Espera elemento na página
            WaitExtension.WaitUntilElement(chromeDriver, By.Id("patientInput"));
        }

        private void SelecionaPacienteTipoConsulta()
        {
            // Seleciona paciente
            element = chromeDriver.FindElement(By.XPath($"//option[.='{_NomePaciente}']"));
            element.Click();

            // Seleciona psicólogo
            element = chromeDriver.FindElement(By.XPath($"//option[.='Psicólogo']"));
            element.Click();

            // Seleciona Presencial se precisar
            if (rbPresencial.Checked)
            {
                element = chromeDriver.FindElement(By.Id("PRadio"));
                element.Click();
            }

            // Seleciona Telemedicina se precisar
            if (rbTelemedicina.Checked)
            {
                element = chromeDriver.FindElement(By.Id("TRadio"));
                element.Click();
            }

            // Seleciona checkbox "Não sei o CID"
            element = chromeDriver.FindElement(By.XPath($"//label[@for='trueCheckbox']"));
            element.Click();
        }

        private void SelecionaSessoes()
        {
            // Clica em "Sessões"
            var elements = chromeDriver.FindElements(By.CssSelector(".form-control.no-btn.h-100"));
            elements[0].Click();

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(1000);

            // Apaga o 1 e seta quantidade de sessões
            element = chromeDriver.FindElement(By.Id("quantitySessionsInput"));
            element.SendKeys(Keys.Backspace + numNumeroConsultas.Value.ToString());

            // Seta as datas das sessões e valor da primeira que é replicado nas outras
            for (int i = 0; i < numNumeroConsultas.Value; i++)
            {
                element = chromeDriver.FindElement(By.Id($"dateSessions{i}Input"));
                element.SendKeys(datasConsultasControles[i].Value.ToString("dd/MM/yyyy"));

                if (i == 0)
                {
                    element = chromeDriver.FindElement(By.Id($"priceSessions{i}CurrencyInput"));
                    element.SendKeys(_ValorConsulta);
                }
            }

            // Confirma as datas e valores das sessões
            element = chromeDriver.FindElement(By.XPath($"//button[.='Confirmar']"));
            element.Click();

            // Mostra o valor total calculado
            element = chromeDriver.FindElement(By.Id("consultationValueCurrencyInput"));
            ScrollAteElemento(element);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(4000);
        }

        private void SobeRecibo()
        {
            // Faz scroll até "Outros documentos"
            element = chromeDriver.FindElement(By.XPath($"//div[.=' Outros documentos ']"));
            ScrollAteElemento(element);

            // Encontra o input de arquivo
            element = chromeDriver.FindElement(By.XPath("(//input[@type='file'])[2]"));

            // Seleciona arquivo para envio
            element.SendKeys(_PDFRecibo);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(3000);
        }

        private void SetaInformacoesPsicologo()
        {
            // Seta nome do psicólogo
            element = chromeDriver.FindElement(By.Id("providerNameInput"));
            ScrollAteElemento(element);
            element.SendKeys(_NomeTerapeuta);

            // Seta CPF psicólogo
            element = chromeDriver.FindElement(By.Id("inputCpfCnpjInput"));
            element.SendKeys(_CPFTerapeuta);

            // Seta número do CRP
            element = chromeDriver.FindElement(By.Id("councilNumberInput"));
            element.SendKeys(_CRP);

            // Seta número do CEP
            element = chromeDriver.FindElement(By.Id("cepInput"));
            element.SendKeys(_CEP);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(4000);
        }

        private void SetaInformacoesBancarias()
        {
            // Seleciona paciente para conta bancária
            var elements = chromeDriver.FindElements(By.XPath($"//option[.='{_NomePaciente}']"));
            ScrollAteElemento(elements[1]);
            elements[1].Click();

            // Seta "Transferência em conta corrente"
            element = chromeDriver.FindElement(By.XPath($"//option[.='Transferência em conta corrente']"));
            element.Click();

            // Seta nome do banco
            element = chromeDriver.FindElement(By.XPath($"//option[.='{_NomeBanco}']"));
            element.Click();

            // Seta número da agência
            element = chromeDriver.FindElement(By.Id("numberAgencyInput"));
            element.SendKeys(_Agencia);

            // Seta número da conta
            element = chromeDriver.FindElement(By.Id("bankAccountInput"));
            element.SendKeys(_Conta);

            // Seta dígito da conta
            element = chromeDriver.FindElement(By.Id("numberAccountInput"));
            element.SendKeys(_Digito);

            // Espera para usuário verificar como ficou
            System.Threading.Thread.Sleep(4000);

            // Submete formulário
            //element = chromeDriver.FindElement(By.XPath($"//button[.='Enviar solicitação']"));
            //element.Click();
        }

        public void ScrollAteElemento(IWebElement element)
        {
            try
            {
                if (element.Location.Y > 200)
                {
                    // Faz scroll na página até mostrar elemento
                    chromeDriver.ExecuteJavaScript($"window.scrollTo({0}, {element.Location.Y - 600})");
                }
            }
            catch { }
        }

        public void AguardaSpinner(int timeoutSecs = 10)
        {
            // Aguarda X segundos enquanto spinner está ativo
            for (var i = 0; i < timeoutSecs; i++)
            {
                var ajaxIsComplete = !TentaEncontrarElemento(By.ClassName("spinner"));
                if (ajaxIsComplete) return;
                Thread.Sleep(1000);
            }
        }

        public bool TentaEncontrarElemento(By by)
        {
            // Verifica se elemento está sendo mostrado
            IWebElement element;
            try
            {
                element = chromeDriver.FindElement(by);
                bool getelement = element.Displayed;
                if (getelement)
                {
                    ScrollAteElemento(element);

                }
                return getelement;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Link para Assinar PDF

        private void lnkAssinarPDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abre link do sejda para assinar PDF
            Process.Start("https://www.sejda.com/pt/sign-pdf");
        }

        #endregion

        #region Selecionar Consultas

        private void btnSelecionarConsultas_Click(object sender, EventArgs e)
        {
            pnlRecibo.Visible = false;
            pnlConsultas.Visible = true;
        }

        private void btnFecharConsultas_Click(object sender, EventArgs e)
        {
            pnlRecibo.Visible = true;
            pnlConsultas.Visible = false;
        }

        private void numNumeroConsultas_ValueChanged(object sender, EventArgs e)
        {
            // Mostra/Esconde datas quando troca número de consultas
            for (int f = 0; f < 5; f++)
            {
                if (f + 1 <= numNumeroConsultas.Value)
                {
                    datasConsultasControles[f].Visible = true;
                }
                else
                {
                    datasConsultasControles[f].Visible = false;
                }
            }
        }

        #endregion
    }
}
