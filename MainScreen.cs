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
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Text.RegularExpressions;

namespace TerapiaReembolso
{
    public partial class MainScreen : Form
    {
        #region Inicialização da Aplicação

        private IWebDriver chromeDriver;
        private IWebElement element;

        private string _NomePaciente;
        private string _ValorTotal;
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

            _ValorTotal = txtValorTotal.Text;
            Properties.Settings.Default["ValorTotal"] = _ValorTotal;

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
                    toolStripStatus.Text = "Recibo gerado, favor imprimir como PDF para salvar arquivo e fechar janela do chromedriver.";
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

                toolStripStatus.Text = "Aguardando.";
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

        private void AbreReciboOnline()
        {
            // Inicia o Chrome maximizado
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("no-sandbox");

            // Baixa ultimo ChromeDriver usando proxy e usa ele
            //System.Net.WebProxy proxy = new System.Net.WebProxy
            //{
            //    UseDefaultCredentials = true,
            //    Address = new Uri("http://proxy")
            //};
            //new DriverManager().WithProxy(proxy).SetUpDriver(new ChromeConfig());
            new DriverManager().SetUpDriver(new ChromeConfig());
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
            decimal valorRecibo = decimal.Parse(_ValorTotal) * numNumeroConsultas.Value;

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

        private void txtGerarSolicitacaoReembolso_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida os dados do reembolso
                if (ValidaDadosParaReembolso())
                {
                    Action action = (Action)GerarSolicitacaoReembolso;
                    RodaAutomacao(action);
                    toolStripStatus.Text = "Solicitação de reembolso gerada, favor fechar janela do chromedriver.";
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

                toolStripStatus.Text = "Aguardando.";
            }
            finally
            {
                EnableDisableControls(true);
            }
        }

        private void GerarSolicitacaoReembolso()
        {

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
