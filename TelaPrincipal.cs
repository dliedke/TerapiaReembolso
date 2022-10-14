/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Automatizar geração de recibos e solicitações de reembolso para terapia no Unimed Seguros
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
        #region Variáveis de Classe e Inicialização da Aplicação

        public static Configuracao Config = new Configuracao();
        public static Paciente PacienteAtual;

        private DateTimePicker[] _datasConsultasControles;
        private Dictionary<string, Paciente> _listaPacientes = new Dictionary<string, Paciente>();

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // Seta lista de controles de datas e atualiza a tela
            _datasConsultasControles = new DateTimePicker[] { dtDataConsulta1, dtDataConsulta2, dtDataConsulta3, dtDataConsulta4, dtDataConsulta5, dtDataConsulta6, dtDataConsulta7, dtDataConsulta8, dtDataConsulta9, dtDataConsulta10 };
            numNumeroConsultas_ValueChanged(null, EventArgs.Empty);

            PopulaMesesEDiasDaSemana();
            MostraVersaoAplicacao();
            MostraMensagemDeBoasVindas();
            CarregaDadosSalvos();

            // Seleciona primeiro paciente se existir algum cadastrado
            if (cmbNomePaciente.Items.Count > 0)
            {
                cmbNomePaciente.SelectedIndex = 0;
            }
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

            // Seta o mes passado no dropdown
            cmbMes.SelectedIndex = DateTime.Now.AddMonths(-1).Month-1;
        }

        private void MostraVersaoAplicacao()
        {
            string windowTitle = "Terapia Reembolso";

            // Mostra versão da aplicação no título da janela
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
            // Pede arquivo PDF do recibo pro usuário
            DialogResult dialogResult = dialogoPDF.ShowDialog();

            // Se arquivo foi selecionado
            if (dialogResult == DialogResult.OK)
            {
                // Verifica extensão do arquivo
                if (Path.GetExtension(dialogoPDF.FileName).ToLower() != ".pdf")
                {
                    MessageBox.Show("Favor selecionar um arquivo PDF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dialogoPDF.FileName = "";
                }
                else
                {
                    Config.PDFRecibo = dialogoPDF.FileName;
                }

                // Mostra nome do PDF na tela
                lblNomeReciboPDF.Text = Path.GetFileName(dialogoPDF.FileName);
            }
        }

        private bool ValidaDadosParaRecibo()
        {
            // Valida nome do paciente
            if (string.IsNullOrEmpty(cmbNomePaciente.Text))
            {
                MessageBox.Show("Favor entrar nome do paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNomePaciente.Focus();
                cmbNomePaciente.SelectAll();
                return false;
            }

            // Valida formato do valor
            var formatinfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = ""
            };

            if (string.IsNullOrEmpty(txtValorConsulta.Text) || float.TryParse(txtValorConsulta.Text, NumberStyles.Float, formatinfo, out float amount) == false)
            {
                MessageBox.Show("Favor entrar o valor com dois dígitos depois da virgula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorConsulta.Focus();
                txtValorConsulta.SelectAll();
                return false;
            }

            // Valida valor maior que zero
            if (amount <= 0)
            {
                MessageBox.Show("Valor deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorConsulta.Focus();
                txtValorConsulta.SelectAll();
                return false;
            }

            // Valida valor com dois digitos depois da virgual
            if (!Regex.IsMatch(Regex.Escape(txtValorConsulta.Text), @"^[0-9]+\,[0-9]{2}$"))
            {
                MessageBox.Show("Favor entrar o valor com dois dígitos depois da virgula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorConsulta.Focus();
                txtValorConsulta.SelectAll();
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

            // Valida Nome do terapeuta
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
            if (string.IsNullOrEmpty(dialogoPDF.FileName))
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
                string caminhoConfiguracoes = Environment.ExpandEnvironmentVariables("%APPDATA%\\..\\Local\\TerapiaReembolso");

                // Carrega dados dos pacientes de arquivo binario criptografado
                string arquivoPacientes = Path.Combine(caminhoConfiguracoes, "pacientes.bin");
                if (File.Exists(arquivoPacientes))
                {
                    _listaPacientes = CryptoSerializer.DeSerialize<Dictionary<string, Paciente>>(arquivoPacientes);
                 
                    // Seta dropdown com os pacientes
                    cmbNomePaciente.Items.AddRange(_listaPacientes.Keys.ToArray<string>());
                }
                
                // Carrega dados de configuração de arquivo binario criptografado
                string arquivoConfiguracao = Path.Combine(caminhoConfiguracoes, "config.bin");
                if (File.Exists(arquivoConfiguracao))
                {
                    Config = CryptoSerializer.DeSerialize<Configuracao>(arquivoConfiguracao);
                             
                    // Atualiza tela com configuração carregada
                    txtCidade.Text = Config.Cidade;
                    txtNomeDoTerapeuta.Text = Config.NomeTerapeuta;
                    txtCPFTerapeuta.Text = Config.CPFTerapeuta;
                    txtCRP.Text = Config.CRP;
                    txtCEP.Text = Config.CEP;
                    txtEnderecoTerapeuta.Text = Config.EnderecoTerapeuta;

                    rbTelemedicina.Checked = Config.TipoAtendimento == "T";
                    rbPresencial.Checked = Config.TipoAtendimento == "P";

                    txtNomeDoBanco.Text = Config.NomeBanco;
                    txtAgenciaSemDigito.Text = Config.Agencia;
                    txtContaSemDigito.Text = Config.Conta;
                    txtDigitoDaConta.Text = Config.Digito;
                    txtLoginUnimed.Text = Config.LoginUnimed;
                    txtSenhaUnimed.Text = Config.SenhaUnimed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Carregando Dados: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalvaDadosAtuais()
        {
            // Salva todos dados da tela em classe Configuracao
            CarregaDadosTelaEmMemoria();

            // Não salva o PDF do recibo
            string pdfRecibo = Config.PDFRecibo;
            Config.PDFRecibo = string.Empty;

            // Caminho dos arquvos criptogrados de configuração
            string caminhoConfiguracoes = Environment.ExpandEnvironmentVariables("%APPDATA%\\..\\Local\\TerapiaReembolso");

            // Salva configuracao em arquivo binário criptografado
            string arquivoConfiguracao = Path.Combine(caminhoConfiguracoes, "config.bin");
            CryptoSerializer.Serialize<Configuracao>(arquivoConfiguracao, Config);

            // Salva lista de pacientes em arquivo binário criptografado
            string arquivoPacientes = Path.Combine(caminhoConfiguracoes, "pacientes.bin");
            CryptoSerializer.Serialize<Dictionary<string,Paciente>>(arquivoPacientes, _listaPacientes);

            // Mantem em memoria o pdf do recibo
            Config.PDFRecibo = pdfRecibo;
        }

        private void CarregaDadosTelaEmMemoria()
        {
            // Salva todos dados da tela em classe Configuracao
            Config.Cidade = txtCidade.Text;
            Config.NomeTerapeuta = txtNomeDoTerapeuta.Text;
            Config.CPFTerapeuta = txtCPFTerapeuta.Text;
            Config.CRP = txtCRP.Text;
            Config.CEP = txtCEP.Text;
            Config.EnderecoTerapeuta = txtEnderecoTerapeuta.Text;
            Config.TipoAtendimento = rbTelemedicina.Checked ? "T" : "P";
            Config.NomeBanco = txtNomeDoBanco.Text;
            Config.Agencia = txtAgenciaSemDigito.Text;
            Config.Conta = txtContaSemDigito.Text;
            Config.Digito = txtDigitoDaConta.Text;
            Config.SenhaUnimed = txtSenhaUnimed.Text;
            Config.LoginUnimed = txtLoginUnimed.Text;

            PegaPacienteAtual();
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Salva dados na tela quando fecha a aplicação
            SalvaDadosAtuais();

            // Fecha Chrome Driver
            Utilitarios.CloseChromeDriver(null);
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
                    CarregaDadosTelaEmMemoria();

                    Action action = (Action)GeracaoRecibo.GerarRecibo;
                    RodaAutomacao(action);
                    toolStripStatus.Text = "Recibo gerado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                Utilitarios.CloseChromeDriver(null);

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

        private void EnableDisableControls(bool enable)
        {
            pnlConsultas.Enabled = enable;
            pnlRecibo.Enabled = enable;
            pnlReembolso.Enabled = enable;
        }

        #endregion

        #region Gerar Solicitação Reembolso

        private void btnGerarSolicitacaoReembolso_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida os dados do recibo e reembolso 
                // (muitos campso do recibo são necessário para pedir o reembolso)
                if (ValidaDadosParaRecibo() && ValidaDadosParaReembolso())
                {
                    CarregaDadosTelaEmMemoria();

                    Action action = (Action)SolicitacaoReembolso.GerarSolicitacaoReembolso;
                    RodaAutomacao(action);

                    // Mostra mensagem de sucesso
                    this.TopMost = true;
                    string msg = "Solicitação de reembolso preenchida, favor revisar formulário e submeter!";
                    MessageBox.Show(msg, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatus.Text = msg;
                    this.TopMost = false;
                }
            }
            catch (Exception ex)
            {
                Utilitarios.CloseChromeDriver(null);

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


        #endregion

        #region Link para Assinar PDF e Login Unimed

        private void lnkAssinarPDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abre link do sejda para assinar PDF
            Process.Start("https://www.sejda.com/pt/sign-pdf");
        }

        private void lnkUnimedLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CarregaDadosTelaEmMemoria();
            SolicitacaoReembolso.AbreSegurosUnimedCliente();
            SolicitacaoReembolso.LoginUnimed();
        }

        #endregion

        #region Selecionar Consultas

        private void btnSelecionarConsultas_Click(object sender, EventArgs e)
        {
            // Não deixa selecionar datas das consultas sem nome do paciente
            if (pnlConsultas.Visible == false &&
                cmbNomePaciente.Text == string.Empty)
            {
                MessageBox.Show("Favor informar o nome do paciente primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNomePaciente.Focus();
                return;
            }

            // Mostra tabs corretas
            pnlConsultas.BringToFront();
            pnlConsultas.Visible = !pnlConsultas.Visible;
            pnlDadosReembolso.Visible = !pnlDadosReembolso.Visible;

            // Se necessário já salva os dados do paciente
            if (!pnlConsultas.Visible)
            {
                SalvaDadosPaciente();
                btnGerarRecibo.Enabled = true;
            }
            else
            {
                btnGerarRecibo.Enabled = false;
            }
        }

        private void btnSalvarConsultas_Click(object sender, EventArgs e)
        {
            // Salva dados do paciente e fecha panel das consultas
            pnlConsultas.Visible = false;
            pnlDadosReembolso.Visible = true;
            SalvaDadosPaciente();
            btnGerarRecibo.Enabled = true;
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
            MostraDatasPorMesEDiaDaSemana();
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostraDatasPorMesEDiaDaSemana();
        }

        private void MostraDatasPorMesEDiaDaSemana()
        {
            // Se não tem dados que chegue, não processa
            if (cmbMes.SelectedIndex == -1 || cmbDiaSemana.SelectedIndex == -1)
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

        #region Somente dígitos para campos de CPF/CEP/CRP/Valor/Dados bancários

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

        private void txtCRP_TextChanged(object sender, EventArgs e)
        {
            txtCRP.Text = Regex.Replace(txtCRP.Text, @"[^\d]", "");
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            txtCEP.Text = Regex.Replace(txtCEP.Text, @"[^\d]", "");
        }

        private void txtAgenciaSemDigito_TextChanged(object sender, EventArgs e)
        {
            txtAgenciaSemDigito.Text = Regex.Replace(txtAgenciaSemDigito.Text, @"[^\d]", "");
        }

        private void txtContaSemDigito_TextChanged(object sender, EventArgs e)
        {
            txtContaSemDigito.Text = Regex.Replace(txtContaSemDigito.Text, @"[^\d]", "");
        }

        private void txtDigitoDaConta_TextChanged(object sender, EventArgs e)
        {
            txtDigitoDaConta.Text = Regex.Replace(txtDigitoDaConta.Text, @"[^\d]", "");
        }

        private void txtValorConsulta_TextChanged(object sender, EventArgs e)
        {
            txtValorConsulta.Text = Regex.Replace(txtValorConsulta.Text, @"[^\d,]", "");
        }

        #endregion

        #region Gerenciamento de dados dos pacientes

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // Limpa tudo 
            cmbNomePaciente.Text = string.Empty;
            txtValorConsulta.Text = string.Empty;
            txtCPFPaciente.Text = string.Empty;
            txtReferenteA.Text = string.Empty;

            // Seta todas consultas pro dia de hoje
            foreach (var controle in _datasConsultasControles)
            {
                controle.Value = DateTime.Now;
            }

            // Seleciona segunda-feira
            cmbDiaSemana.SelectedIndex = 0;

            // Uma consulta
            numNumeroConsultas.Value = 1;

            // Fecha panel de consultas
            pnlConsultas.Visible = false;
            pnlDadosReembolso.Visible = true;
        }

        private void btnSalvarPaciente_Click(object sender, EventArgs e)
        {
            // Nome do paciente necessário para salvar
            if (cmbNomePaciente.Text == string.Empty)
            {
                MessageBox.Show("Favor informar o nome do paciente primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNomePaciente.Focus();
                return;
            }

            SalvaDadosPaciente();
        }

        private void SalvaDadosPaciente()
        {
            // Pega nome do paciente e cria nova classe com dados atualizados
            string nomePaciente = cmbNomePaciente.Text;
            Paciente pacienteAtualizado = new Paciente(nomePaciente,
                                                       txtValorConsulta.Text,
                                                       txtCPFPaciente.Text,
                                                       txtReferenteA.Text,
                                                       cmbDiaSemana.Text,
                                                       (int)numNumeroConsultas.Value,
                                                       _datasConsultasControles);

            if (!cmbNomePaciente.Items.Contains(nomePaciente))
            {
                // Adiciona novo paciente na lista e no dropdown
                _listaPacientes.Add(nomePaciente, pacienteAtualizado);
                cmbNomePaciente.Items.Add(cmbNomePaciente.Text);
            }
            else
            {
                // Atualiza dados do paciente
                _listaPacientes[nomePaciente] = pacienteAtualizado;
            }

            // Mostra status da operação
            toolStripStatus.Text = $"Paciente \"{nomePaciente}\" salvo!";
        }

        private void cmbNomePaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Carrega dados do paciente selecionado
            string nomePaciente = cmbNomePaciente.Text;
            if (_listaPacientes.ContainsKey(nomePaciente))
            {
                Paciente paciente = _listaPacientes[nomePaciente];
                txtValorConsulta.Text = paciente.Valor;
                txtCPFPaciente.Text = paciente.CPF;
                txtReferenteA.Text = paciente.ReferenteA;
                cmbDiaSemana.Text = paciente.DiaSemana;

                // Carrega número datas das consultas se tiver
                if (paciente.NumeroConsultas > 0)
                {
                    numNumeroConsultas.Value = (decimal)paciente.NumeroConsultas;

                    int count = 0;
                    foreach (DateTime data in paciente.DataConsultaLista)
                    {
                        _datasConsultasControles[count].Value = data;
                        if (count + 1 > numNumeroConsultas.Value)
                        {
                            break;
                        }
                        count++;
                    }
                }
            }
        }


        private void btnExcluirPaciente_Click(object sender, EventArgs e)
        {
            // Pede confirmação para exclusão
            string nomePaciente = cmbNomePaciente.Text;

            if (!string.IsNullOrEmpty(nomePaciente))
            {
                DialogResult resultadoPergunta = MessageBox.Show($"Deseja excluir o(a) paciente \"{nomePaciente}\"?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                // Usuário confirmou
                if (resultadoPergunta == DialogResult.Yes)
                {
                    // Algum paciente está selecionado
                    if (cmbNomePaciente.SelectedIndex != -1)
                    {
                        // Remove da lista e do dropdown
                        _listaPacientes.Remove(nomePaciente);
                        cmbNomePaciente.Items.RemoveAt(cmbNomePaciente.SelectedIndex);
                    }

                    // Limpa tudo
                    btnNovo_Click(sender, e);

                    // Mostra status da operação
                    toolStripStatus.Text = $"Paciente \"{nomePaciente}\" excluído!";
                }
            }
        }

        public void PegaPacienteAtual()
        {
            string nomePaciente = cmbNomePaciente.Text;
            if (_listaPacientes.ContainsKey(nomePaciente))
            {
                PacienteAtual = _listaPacientes[nomePaciente];
            }
            else
            {
                PacienteAtual = null;
            }
        }

        #endregion

        #region Remove Acentos do Nome do Paciente

        private string strAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";

        private void cmbNomePaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (strAcentos.IndexOf(e.KeyChar) > 0)
            {
                e.Handled = true;
            }
        }

        public static string RemoveAcentos(string text)
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

        private void cmbNomePaciente_TextChanged(object sender, EventArgs e)
        {
            cmbNomePaciente.Text = RemoveAcentos(cmbNomePaciente.Text);
        }

        #endregion

        #region Tela de Sobre...

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fecha aplicação
            Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostra panel de sobre... com ano atual
            pnlSobre.Visible = true;
            pnlConsultas.Visible = false;
            pnlReembolso.Visible = false;
            pnlRecibo.Visible = false;
            lblCopyright.Text = $"Copyright © Daniel Liedke {DateTime.Now.Year}";
            lblNomeAplicao.Text = this.Text;
        }

        private void btnFecharSobre_Click(object sender, EventArgs e)
        {
            // Fecha panel de sobre...
            pnlSobre.Visible = false;
            pnlConsultas.Visible = true;
            pnlReembolso.Visible = true;
            pnlRecibo.Visible = true;
        }

        #endregion
    }
}
