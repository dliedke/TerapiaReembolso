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
using System.Linq;

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
        private string _LoginUnimed;
        private string _SenhaUnimed;
        private string _PDFRecibo;
        private int _NumeroConsultas;

        private string _Mes;
        private string _DiaDaSemana;
        private DateTime[] _DataConsultaLista = new DateTime[10];
        private DateTimePicker[] _datasConsultasControles;

        private bool _previneAtualizacaoDatas = false;

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
            _datasConsultasControles = new DateTimePicker[] { dtDataConsulta1, dtDataConsulta2, dtDataConsulta3, dtDataConsulta4, dtDataConsulta5, dtDataConsulta6, dtDataConsulta7, dtDataConsulta8, dtDataConsulta9, dtDataConsulta10 };
            numNumeroConsultas_ValueChanged(null, EventArgs.Empty);

            PopulaMesesEDiasDaSemana();
            MostraVersaoAplicacao();
            MostraMensagemDeBoasVindas();
            CarregaDadosSalvos();
        }

        private void PopulaMesesEDiasDaSemana()
        {
            // Popula todos meses
            cmbMes.Items.Add(new Item("Janeiro", 1));
            cmbMes.Items.Add(new Item("Fevereiro", 2));
            cmbMes.Items.Add(new Item("Março", 3));
            cmbMes.Items.Add(new Item("Abril", 4));
            cmbMes.Items.Add(new Item("Maio", 5));
            cmbMes.Items.Add(new Item("Junho", 6));
            cmbMes.Items.Add(new Item("Julho", 7));
            cmbMes.Items.Add(new Item("Agosto", 8));
            cmbMes.Items.Add(new Item("Setembro", 9));
            cmbMes.Items.Add(new Item("Outubro", 10));
            cmbMes.Items.Add(new Item("Novembro", 11));
            cmbMes.Items.Add(new Item("Dezembro", 12));

            // Popula todos dias da semana
            cmbDiaSemana.Items.Add(new Item("Segunda-Feira", 2));
            cmbDiaSemana.Items.Add(new Item("Terça-Feira", 3));
            cmbDiaSemana.Items.Add(new Item("Quarta-Feira", 4));
            cmbDiaSemana.Items.Add(new Item("Quinta-Feira", 5));
            cmbDiaSemana.Items.Add(new Item("Sexta-Feira", 6));
            cmbDiaSemana.Items.Add(new Item("Sábado", 7));
            cmbDiaSemana.Items.Add(new Item("Domingo", 1));

            // Seta o mes atual no dropdown
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void MostraVersaoAplicacao()
        {
            string windowTitle = "Terapia Reembolso";

            // Sets the application version in the windows title
            Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            windowTitle = windowTitle + " v" + ver.Major + "." + ver.Minor;
            this.Text = windowTitle;
        }

        private void MostraMensagemDeBoasVindas()
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
                MessageBox.Show("Favor entrar nome do paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Valida CPF só números
            if (!ValidaDigitoCPF.ValidaCPFFormato(txtCPFTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar CPF do terapeuta somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFTerapeuta.Focus();
                txtCPFTerapeuta.SelectAll();
                return false;
            }

            // Valida CPF correto
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

            // Valida CRP só números
            if (!Regex.IsMatch(txtCRP.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar somente números para o CRP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Valida CEP só números
            if (!Regex.IsMatch(txtCEP.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar somente números para o CEP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Valida Login Unimed
            if (string.IsNullOrEmpty(txtLoginUnimed.Text))
            {
                MessageBox.Show("Favor entrar Login Unimed.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimed.Focus();
                txtLoginUnimed.SelectAll();
                return false;
            }

            // Valida Login Unimed CPF só números
            if (!ValidaDigitoCPF.ValidaCPFFormato(txtLoginUnimed.Text))
            {
                MessageBox.Show("Favor entrar Login Unimed CPF somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimed.Focus();
                txtLoginUnimed.SelectAll();
                return false;
            }

            // Valida Login Unimed CPF correto
            if (!ValidaDigitoCPF.ValidaCPFValor(txtLoginUnimed.Text))
            {
                MessageBox.Show("Favor entrar Login Unimed CPF válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimed.Focus();
                txtLoginUnimed.SelectAll();
                return false;
            }

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

            // Valida Agencia só números
            if (!Regex.IsMatch(txtAgenciaSemDigito.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar Agencia somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Valida Conta só números
            if (!Regex.IsMatch(txtContaSemDigito.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar Conta somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Valida Dígito da Conta só números
            if (!Regex.IsMatch(txtDigitoDaConta.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar Dígito da Conta somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDigitoDaConta.Focus();
                txtDigitoDaConta.SelectAll();
                return false;
            }

            // Validate the PDF receipt
            if (string.IsNullOrEmpty(dialogPDF.FileName))
            {
                MessageBox.Show("Favor selecionar PDF do recibo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                txtNomeDoPaciente.Text = Encryption.DecryptString(Properties.Settings.Default["NomePaciente"].ToString());
                txtValorTotal.Text = Encryption.DecryptString(Properties.Settings.Default["ValorTotal"].ToString());
                txtCPFPaciente.Text = Encryption.DecryptString(Properties.Settings.Default["CPFPaciente"].ToString());
                txtReferenteA.Text = Encryption.DecryptString(Properties.Settings.Default["ReferenteA"].ToString());
                txtCidade.Text = Encryption.DecryptString(Properties.Settings.Default["Cidade"].ToString());
                txtNomeDoTerapeuta.Text = Encryption.DecryptString(Properties.Settings.Default["NomeTerapeuta"].ToString());
                txtCPFTerapeuta.Text = Encryption.DecryptString(Properties.Settings.Default["CPFTerapeuta"].ToString());
                txtCRP.Text = Encryption.DecryptString(Properties.Settings.Default["CRP"].ToString());
                txtCEP.Text = Encryption.DecryptString(Properties.Settings.Default["CEP"].ToString());
                txtEnderecoTerapeuta.Text = Encryption.DecryptString(Properties.Settings.Default["EnderecoTerapeuta"].ToString());
                if (!string.IsNullOrEmpty(Properties.Settings.Default["TipoAtendimento"].ToString()))
                {
                    rbTelemedicina.Checked = Encryption.DecryptString(Properties.Settings.Default["TipoAtendimento"].ToString()) == "T";
                    rbPresencial.Checked = Encryption.DecryptString(Properties.Settings.Default["TipoAtendimento"].ToString()) == "P";
                }
                txtNomeDoBanco.Text = Encryption.DecryptString(Properties.Settings.Default["NomeBanco"].ToString());
                txtAgenciaSemDigito.Text = Encryption.DecryptString(Properties.Settings.Default["Agencia"].ToString());
                txtContaSemDigito.Text = Encryption.DecryptString(Properties.Settings.Default["Conta"].ToString());
                txtDigitoDaConta.Text = Encryption.DecryptString(Properties.Settings.Default["Digito"].ToString());
                txtLoginUnimed.Text = Encryption.DecryptString(Properties.Settings.Default["LoginUnimed"].ToString());
                txtSenhaUnimed.Text = Encryption.DecryptString(Properties.Settings.Default["SenhaUnimed"].ToString());
                numNumeroConsultas.Value = decimal.Parse(Properties.Settings.Default["NumeroConsultas"].ToString());

                _Mes = Encryption.DecryptString(Properties.Settings.Default["Mes"].ToString());
                _DiaDaSemana = Encryption.DecryptString(Properties.Settings.Default["DiaDaSemana"].ToString());

                _previneAtualizacaoDatas = true;

                if (cmbMes.FindStringExact(_Mes) != -1)
                {
                    cmbMes.SelectedIndex = cmbMes.FindString(_Mes);
                }

                if (cmbDiaSemana.FindStringExact(_DiaDaSemana) != -1)
                {
                    cmbDiaSemana.SelectedIndex = cmbDiaSemana.FindString(_DiaDaSemana);
                }

                _previneAtualizacaoDatas = false;

                for (int f = 0; f < 10; f++)
                {
                    // Carrega datas das consultas se tiver alguma salva
                    if (DateTime.TryParse(Properties.Settings.Default[$"DataConsulta{f+1}"].ToString(), out DateTime dateTime1))
                    {
                        if (dateTime1.Year > 1)
                        {
                            _datasConsultasControles[f].Value = (DateTime)Properties.Settings.Default[$"DataConsulta{f+1}"];
                        }
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
            Properties.Settings.Default["NomePaciente"] = Encryption.EncryptString(_NomePaciente);

            _ValorConsulta = txtValorTotal.Text;
            Properties.Settings.Default["ValorTotal"] = Encryption.EncryptString(_ValorConsulta);

            _CPFPaciente = txtCPFPaciente.Text;
            Properties.Settings.Default["CPFPaciente"] = Encryption.EncryptString(_CPFPaciente);

            _ReferenteA = txtReferenteA.Text;
            Properties.Settings.Default["ReferenteA"] = Encryption.EncryptString(_ReferenteA);

            _Cidade = txtCidade.Text;
            Properties.Settings.Default["Cidade"] = Encryption.EncryptString(_Cidade);

            _NomeTerapeuta = txtNomeDoTerapeuta.Text;
            Properties.Settings.Default["NomeTerapeuta"] = Encryption.EncryptString(_NomeTerapeuta);

            _CPFTerapeuta = txtCPFTerapeuta.Text;
            Properties.Settings.Default["CPFTerapeuta"] = Encryption.EncryptString(_CPFTerapeuta);

            _CRP = txtCRP.Text;
            Properties.Settings.Default["CRP"] = Encryption.EncryptString(_CRP);

            _CEP = txtCEP.Text;
            Properties.Settings.Default["CEP"] = Encryption.EncryptString(_CEP);

            _EnderecoTerapeuta = txtEnderecoTerapeuta.Text;
            Properties.Settings.Default["EnderecoTerapeuta"] = Encryption.EncryptString(_EnderecoTerapeuta);

            _TipoAtendimento = rbTelemedicina.Checked ? "T" : "P";
            Properties.Settings.Default["TipoAtendimento"] = Encryption.EncryptString(_TipoAtendimento);

            _NomeBanco = txtNomeDoBanco.Text;
            Properties.Settings.Default["NomeBanco"] = Encryption.EncryptString(_NomeBanco);

            _Agencia = txtAgenciaSemDigito.Text;
            Properties.Settings.Default["Agencia"] = Encryption.EncryptString(_Agencia);

            _Conta = txtContaSemDigito.Text;
            Properties.Settings.Default["Conta"] = Encryption.EncryptString(_Conta);

            _Digito = txtDigitoDaConta.Text;
            Properties.Settings.Default["Digito"] = Encryption.EncryptString(_Digito);

            _NumeroConsultas = (int)numNumeroConsultas.Value;
            Properties.Settings.Default["NumeroConsultas"] = _NumeroConsultas;

            for (int f = 0; f < 10; f++)
            {
                _DataConsultaLista[f] = _datasConsultasControles[f].Value;
                Properties.Settings.Default[$"DataConsulta{f+1}"] = _DataConsultaLista[f];
            }

            _SenhaUnimed = txtSenhaUnimed.Text;
            Properties.Settings.Default["SenhaUnimed"] = Encryption.EncryptString(_SenhaUnimed);

            _LoginUnimed = txtLoginUnimed.Text;
            Properties.Settings.Default["LoginUnimed"] = Encryption.EncryptString(_LoginUnimed);

            _DiaDaSemana = cmbDiaSemana.Text;
            Properties.Settings.Default["DiaDaSemana"] = Encryption.EncryptString(_DiaDaSemana);

            _Mes = cmbMes.Text;
            Properties.Settings.Default["Mes"] = Encryption.EncryptString(_Mes);

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
                    MessageBox.Show("Erro interno na aplicação: " + ex.Message + "\r\n\r\nAbra o Chrome manualmente, clique nos 3 pontos no canto superior direito, vá para \"Ajuda\", depois em \"Sobre o Google Chrome\" e atualize seu navegador Chrome para a versão mais recente. Então tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro interno na aplicação: " + ex.Message + "\r\n\r\nFavor tentar de novo o mesmo processo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            toolStripStatus.Text = "Rodando automação (feche o Chrome se quiser abortar). Por favor, espere... Primeira vez que rodar demora um pouco mais.";
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
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--ignore-ssl-errors");
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
                dias += _datasConsultasControles[f-1].Value.ToString("dd/MM/yyyy, ");
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

                    this.TopMost = true;
                    string msg = "Solicitação de reembolso preenchida, favor revisar formulário e submeter!";
                    MessageBox.Show(msg, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatus.Text = msg;
                    this.TopMost = false;
                }
            }
            catch (Exception ex)
            {
                CloseChromeDriver();

                if (ex.Message.Contains("This version of ChromeDriver only supports Chrome version"))
                {
                    MessageBox.Show("Erro interno na aplicação: " + ex.Message + "\r\n\r\nAbra o Chrome manualmente, clique nos 3 pontos no canto superior direito, vá para \"Ajuda\", depois em \"Sobre o Google Chrome\" e atualize seu navegador Chrome para a versão mais recente. Então tente de novo o processo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--ignore-ssl-errors");
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
            emailText.SendKeys(_LoginUnimed);

            // Seta senha para logar
            var passwordText = chromeDriver.FindElement(By.Id("senhaInput"));
            passwordText.SendKeys(_SenhaUnimed);

            // Submete o formulário
            System.Threading.Thread.Sleep(500);
            passwordText.Submit();
            System.Threading.Thread.Sleep(1500);

            // Espera aparecer o botão de "Reembolsos e Prévias"
            WaitExtension.WaitUntilElement(chromeDriver, By.XPath("//div[.=' Reembolsos e Prévias ']"), 30);

            // Espera ainda mais um pouquinho 
            System.Threading.Thread.Sleep(1000);

            // Espera os spinners todos da página
            AguardaSpinner();
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
            AguardaSpinner();

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
                element.SendKeys(_datasConsultasControles[i].Value.ToString("dd/MM/yyyy"));

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
            // Navega até o CEP
            ScrollAteElemento(chromeDriver.FindElement(By.Id("cepInput")));

            // Seta nome do psicólogo
            element = chromeDriver.FindElement(By.Id("providerNameInput"));
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

        public void AguardaSpinner(int timeoutSecs = 5)
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
            for (int f = 0; f < 10; f++)
            {
                if (f + 1 <= numNumeroConsultas.Value)
                {
                    _datasConsultasControles[f].Visible = true;
                }
                else
                {
                    _datasConsultasControles[f].Visible = false;
                }
            }
        }

        #endregion

        #region Cálculo Automático dos dias das Consultas por mês/dia da semana

        private void cmbDiaSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DiaDaSemana = cmbDiaSemana.SelectedText;
            MostraDatasPorMesEDiaDaSemana();
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mes = cmbMes.SelectedText;
            MostraDatasPorMesEDiaDaSemana();
        }

        private void MostraDatasPorMesEDiaDaSemana()
        {
            // Se não tem dados que chegue, não processa
            if (cmbMes.SelectedIndex == -1 || cmbDiaSemana.SelectedIndex == -1 || _previneAtualizacaoDatas)
                return;

            // Pega o mes e dia da semana selecionado, além do ano atual
            Item mesSelecionado = (Item)cmbMes.Items[cmbMes.SelectedIndex];
            Item diaDaSemanaSelecionado = (Item)cmbDiaSemana.Items[cmbDiaSemana.SelectedIndex];
            int ano = DateTime.Now.Year;
            int mes = mesSelecionado.Value;

            // Calcula inicio e final do mes
            var dataInicio = new DateTime(ano, mes, 1);
            var dataFim = dataInicio.AddMonths(1).AddDays(-1);

            // Calcula total de dias no mes
            int numeroDeDias = dataFim.Subtract(dataInicio).Days + 1;

            // Filtro do dia da semana
            var diasDaSemana = new[] { (DayOfWeek)diaDaSemanaSelecionado.Value - 1 };

            // Seleciona dias filtrado por dia da semana
            var datasFiltradas = Enumerable.Range(0, numeroDeDias)
                                  .Select(i => dataInicio.AddDays(i))
                                  .Where(d => diasDaSemana.Contains(d.DayOfWeek));

            // Atualiza total de consultas
            numNumeroConsultas.Value = datasFiltradas.Count();

            // Mostra as datas filtradas
            int count = 0;
            foreach (var date in datasFiltradas)
            {
                _datasConsultasControles[count].Value = date;
                count++;
            }
        }

        #endregion

        #region Suporte a copiar CPF para campos e deixar só dígitos

        private void txtCPFPaciente_TextChanged(object sender, EventArgs e)
        {
            txtCPFPaciente.Text = Regex.Replace(txtCPFPaciente.Text, @"[^\d]", "");
        }

        private void txtCPFTerapeuta_TextChanged(object sender, EventArgs e)
        {
            txtCPFTerapeuta.Text = Regex.Replace(txtCPFTerapeuta.Text, @"[^\d]", "");
        }

        private void txtLoginUnimed_TextChanged(object sender, EventArgs e)
        {
            txtLoginUnimed.Text = Regex.Replace(txtLoginUnimed.Text, @"[^\d]", "");
        }

        #endregion
    }

    #region Item Class

    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Item(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }

    #endregion
}
