/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Automatizar geração de recibos e solicitações de reembolso para terapia no Unimed Seguros e Unimed Acre
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Aspose.Zip;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
        #region Variáveis de Classe e Inicialização da Aplicação

        private static int _indiceClienteAtual = 0;
        private static List<Configuracao> _listaConfiguracoesClientes = new List<Configuracao>();
        private DateTimePickerWithBackColor[] _datasConsultasControles;
        private Dictionary<string, Paciente> _listaPacientes = new Dictionary<string, Paciente>();
        private static PacienteAcre _pacienteAcre = new PacienteAcre();

        public static Paciente PacienteAtual;

        // Path onde serão serializados as configurações de clientes e pacientes
        private string _caminhoConfiguracoes = Environment.ExpandEnvironmentVariables(@"%APPDATA%\..\Local\TerapiaReembolso");
        
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            try
            {
                // Copia configurações da versão anterior caso necessário
                if (Properties.Settings.Default.UpdateSettings)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.UpdateSettings = false;
                    Properties.Settings.Default.Save();
                }

                // Se tiver dados salvos do tamanho já restaura tamanho e posição da janela
                if (!(Properties.Settings.Default.F1Size.Width == 0 && Properties.Settings.Default.F1Size.Height == 0))
                {
                    this.WindowState = Properties.Settings.Default.F1State;

                    // Sem janela minimizada na inicialização
                    if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                    this.Location = Properties.Settings.Default.F1Location;
                    this.Size = Properties.Settings.Default.F1Size;
                }

                // Seta lista de controles de datas e atualiza a tela
                _datasConsultasControles = new DateTimePickerWithBackColor[] { dtDataConsulta1, dtDataConsulta2, dtDataConsulta3, dtDataConsulta4, dtDataConsulta5, dtDataConsulta6, dtDataConsulta7, dtDataConsulta8, dtDataConsulta9, dtDataConsulta10 };
                numNumeroConsultas_ValueChanged(null, EventArgs.Empty);

                // Migra config antigo para novo padrão se precisar
                string arquivoConfig = Path.Combine(_caminhoConfiguracoes, "config.bin");
                if (File.Exists(arquivoConfig))
                {
                    File.Move(arquivoConfig, Path.Combine(_caminhoConfiguracoes, "config_0.bin"));
                }

                // Faz o processamento inicial
                PopulaMesesEDiasDaSemana();
                MostraVersaoAplicacao();
                MostraMensagemDeBoasVindas();
                CarregaDadosSalvos();

                // Seleciona primeiro paciente se existir algum cadastrado
                if (cmbNomePaciente.Items.Count > 0)
                {
                    cmbNomePaciente.SelectedIndex = 0;
                }

                // Se não tem nada salvo, cria um cliente padrão
                CriaClientePadraoSeNaoExistir();

                // Configura cor dos controles
                SetaEstilos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Inicializando a Aplicação: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetaEstilos()
        {
            // Seta cor da barra de status
            statusStrip.BackColor = this.BackColor;
            statusStrip.ForeColor = this.ForeColor;

            // Seta cor dos calendários
            foreach (var controle in _datasConsultasControles)
            {
                controle.BackColor = Color.FromArgb(74, 74, 74);
                controle.ForeColor = Color.White;
                controle.CalendarForeColor = Color.White;
                controle.CalendarMonthBackground = Color.FromArgb(74, 74, 74);
                controle.CalendarTitleBackColor = Color.FromArgb(160, 160, 255);
                controle.CalendarTitleForeColor = Color.White;
                controle.CalendarTrailingForeColor = Color.White;
                controle.BackDisabledColor = Color.FromArgb(74, 74, 74);
                controle.ForeDisabledColor = Color.FromArgb(103, 109, 103);
                controle.Refresh();
            }

            dtDataRecibo.Value = DateTime.Now.AddDays(1).Date;
            dtDataRecibo.BackColor = _datasConsultasControles[0].BackColor;
            dtDataRecibo.ForeColor = _datasConsultasControles[0].ForeColor;
            dtDataRecibo.CalendarForeColor = _datasConsultasControles[0].CalendarForeColor;
            dtDataRecibo.CalendarMonthBackground = _datasConsultasControles[0].CalendarMonthBackground;
            dtDataRecibo.CalendarTitleBackColor = _datasConsultasControles[0].CalendarTitleBackColor;
            dtDataRecibo.CalendarTitleForeColor = _datasConsultasControles[0].CalendarTitleForeColor;
            dtDataRecibo.CalendarTrailingForeColor = _datasConsultasControles[0].CalendarTrailingForeColor;
            dtDataRecibo.BackDisabledColor = _datasConsultasControles[0].BackDisabledColor;
            dtDataRecibo.ForeDisabledColor = _datasConsultasControles[0].ForeDisabledColor;
            dtDataRecibo.Refresh();
        }

        private static void CriaClientePadraoSeNaoExistir()
        {
            // Se não tem nada salvo, cria um cliente padrão para não explodir tudo
            if (_listaConfiguracoesClientes.Count == 0)
            {
                Configuracao configuracao = new Configuracao
                {
                    NomeCliente = "Cliente 1"
                };
                _listaConfiguracoesClientes.Add(configuracao);
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
            cmbMes.SelectedIndex = DateTime.Now.AddMonths(-1).Month - 1;
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
            try
            {
                // Pede arquivo PDF do recibo pro usuário
                DialogResult dialogResult = dialogoPDFRecibo.ShowDialog();

                // Se arquivo foi selecionado
                if (dialogResult == DialogResult.OK)
                {
                    // Verifica extensão do arquivo
                    if (Path.GetExtension(dialogoPDFRecibo.FileName).ToLower() != ".pdf")
                    {
                        MessageBox.Show("Favor selecionar um arquivo PDF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dialogoPDFRecibo.FileName = "";
                    }
                    else
                    {
                        TelaPrincipal.PegaClienteAtual().PDFRecibo = dialogoPDFRecibo.FileName;
                    }

                    // Mostra nome do PDF na tela
                    lblNomeArquivoRecibo.Text = Path.GetFileName(dialogoPDFRecibo.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro selecionando PDF: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!ValidaCPF.ValidaCPFFormato(txtCPFPaciente.Text))
            {
                MessageBox.Show("Favor entrar CPF do paciente somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFPaciente.Focus();
                txtCPFPaciente.SelectAll();
                return false;
            }

            if (!ValidaCPF.ValidaCPFValor(txtCPFPaciente.Text))
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

            if (rbFisica.Checked)
            {
                // Valida CPF só números
                if (!ValidaCPF.ValidaCPFFormato(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CPF do terapeuta somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }

                // Valida CPF correto
                if (!ValidaCPF.ValidaCPFValor(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CPF do terapeuta válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }
            }
            else
            {
                // Valida CNPJ só números
                if (!ValidaCNPJ.ValidaCNPJFormato(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CNPJ da empresa somente 14 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }

                // Valida CNPJ correto
                if (!ValidaCNPJ.ValidaCNPJValor(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CNPJ da empresa válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }
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
            if (!ValidaCPF.ValidaCPFFormato(txtLoginUnimed.Text))
            {
                MessageBox.Show("Favor entrar Login Unimed CPF somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimed.Focus();
                txtLoginUnimed.SelectAll();
                return false;
            }

            // Valida Login Unimed CPF correto
            if (!ValidaCPF.ValidaCPFValor(txtLoginUnimed.Text))
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

            if (rbFisica.Checked)
            {
                // Valida PDF do recibo
                if (string.IsNullOrEmpty(dialogoPDFRecibo.FileName))
                {
                    MessageBox.Show("Favor selecionar PDF do recibo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSelecionarPDFRecibo.Focus();
                    return false;
                }
            }
            else
            {
                // Valida PDF do recibo
                if (string.IsNullOrEmpty(dialogoPDFRecibo.FileName))
                {
                    MessageBox.Show("Favor selecionar PDF da nota fiscal.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSelecionarPDFRecibo.Focus();
                    return false;
                }
            }

            return true;
        }

        
        #endregion

        #region Carrega/Salva Dados

        private void CarregaDadosSalvos()
        {
            try
            {
                // Limpa tudo
                _listaConfiguracoesClientes = new List<Configuracao>();
                _listaPacientes = new Dictionary<string, Paciente>();
                _indiceClienteAtual = 0;
                cmbNomePaciente.Items.Clear();
                cmbNomeCliente.Items.Clear();
                for (int i = clientesToolStripMenuItem.DropDownItems.Count - 1; i >= 2; i--)
                {
                    clientesToolStripMenuItem.DropDownItems.RemoveAt(i);
                }

                // Cria caminho para os arquivos de configuração se não existir
                if (!Directory.Exists(_caminhoConfiguracoes))
                {
                    Directory.CreateDirectory(_caminhoConfiguracoes);
                }

                // Carrega dados dos pacientes de arquivo binario criptografado
                string arquivoPacientes = Path.Combine(_caminhoConfiguracoes, "pacientes.bin");
                if (File.Exists(arquivoPacientes))
                {
                    _listaPacientes = CryptoSerializer.DeSerialize<Dictionary<string, Paciente>>(arquivoPacientes);

                    // Seta dropdown com os pacientes
                    cmbNomePaciente.Items.AddRange(_listaPacientes.Keys.ToArray<string>());
                    cmbNomePaciente.SelectedIndex = 0;
                }

                // Busca todos arquivos de configuração existentes
                _listaConfiguracoesClientes.Clear();
                _indiceClienteAtual = 0;
                cmbNomeCliente.Items.Clear();
                for (int i = 0; i < 100; i++)
                {
                    // Carrega dados de configuração de arquivo binario criptografado
                    string arquivoConfiguracao = Path.Combine(_caminhoConfiguracoes, $"config_{i}.bin");
                    if (File.Exists(arquivoConfiguracao))
                    {
                        Configuracao configuracao = CryptoSerializer.DeSerialize<Configuracao>(arquivoConfiguracao);

                        // Se ainda não temos nome do cliente tenta pegar da lista de pacientes,
                        // se não cria um nome padrão
                        if (string.IsNullOrEmpty(configuracao.NomeCliente))
                        {
                            configuracao.NomeCliente = cmbNomePaciente.Text;
                        }
                        if (string.IsNullOrEmpty(configuracao.NomeCliente))
                        {
                            configuracao.NomeCliente = "Cliente 1";
                        }

                        // Adiciona o novo cliente no menu e no dropdown de clientes
                        AdicionaClienteMenu(configuracao.NomeCliente, i);
                        cmbNomeCliente.Items.Add(configuracao.NomeCliente);
                        _listaConfiguracoesClientes.Add(configuracao);
                    }
                    else
                    {
                        break;
                    }
                }

                // Se tem algum cliente carregado
                if (_listaConfiguracoesClientes.Count > 0)
                {
                    // Clica no primeiro cliente
                    nomeClienteMenu_Click(clientesToolStripMenuItem.DropDownItems[2], EventArgs.Empty);
                }

                // Carrega dados do PacienteAcre de arquivo binario criptografado
                string arquivoPacienteAcre = Path.Combine(_caminhoConfiguracoes, "pacienteacre.bin");
                if (File.Exists(arquivoPacienteAcre))
                {
                    _pacienteAcre = CryptoSerializer.DeSerialize<PacienteAcre>(arquivoPacienteAcre);
                }

                AtualizaTelaComConfiguracaoAtual();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Carregando Dados: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizaTelaComConfiguracaoAtual()
        {
            // Atualiza tela com configuração carregada
            rbFisica.Checked = TelaPrincipal.PegaClienteAtual().TipoPessoaTerapeuta == "F";
            rbJuridica.Checked = TelaPrincipal.PegaClienteAtual().TipoPessoaTerapeuta == "J";

            // Padrão é pessoa física
            if (string.IsNullOrEmpty(TelaPrincipal.PegaClienteAtual().TipoPessoaTerapeuta))
            {
                rbFisica.Checked = true;
            }

            // Mostra dados do cliente atual
            txtCidade.Text = TelaPrincipal.PegaClienteAtual().Cidade;
            txtNomeDoTerapeuta.Text = TelaPrincipal.PegaClienteAtual().NomeTerapeuta;
            txtCPFTerapeuta.Text = TelaPrincipal.PegaClienteAtual().CPFTerapeuta;
            txtCRP.Text = TelaPrincipal.PegaClienteAtual().CRP;
            txtCEP.Text = TelaPrincipal.PegaClienteAtual().CEP;
            txtEnderecoTerapeuta.Text = TelaPrincipal.PegaClienteAtual().EnderecoTerapeuta;

            rbTelemedicina.Checked = TelaPrincipal.PegaClienteAtual().TipoAtendimento == "T";
            rbPresencial.Checked = TelaPrincipal.PegaClienteAtual().TipoAtendimento == "P";

            // Padrão é telemedicina
            if (string.IsNullOrEmpty(TelaPrincipal.PegaClienteAtual().TipoAtendimento))
            {
                rbTelemedicina.Checked = true;
            }

            // Mostra dados do cliente atual
            txtNomeDoBanco.Text = TelaPrincipal.PegaClienteAtual().NomeBanco;
            txtAgenciaSemDigito.Text = TelaPrincipal.PegaClienteAtual().Agencia;
            txtContaSemDigito.Text = TelaPrincipal.PegaClienteAtual().Conta;
            txtDigitoDaConta.Text = TelaPrincipal.PegaClienteAtual().Digito;
            txtLoginUnimed.Text = TelaPrincipal.PegaClienteAtual().LoginUnimed;
            txtSenhaUnimed.Text = TelaPrincipal.PegaClienteAtual().SenhaUnimed;

            // Mostra na tela os dados da Unimed Acre
            txtLoginUnimedAcre.Text = _pacienteAcre.CarteirinhaUnimed;
            txtNomeBancoAcre.Text = _pacienteAcre.NomeBanco;
            dialogoPDFCarteirinha.FileName = _pacienteAcre.PDFCarteirinhaRequisicao;
            lblNomeArquivoCarteirinha.Text = Path.GetFileName(_pacienteAcre.PDFCarteirinhaRequisicao);
            dialogoPDFIdentidade.FileName = _pacienteAcre.PDFIdentidade;
            lblNomeArquivoIdentidade.Text = Path.GetFileName(_pacienteAcre.PDFIdentidade);
            txtEnderecoBairroAcre.Text = _pacienteAcre.Bairro;
            txtEstadoAcre.Text = _pacienteAcre.Estado;
            txtEnderecoComplementoAcre.Text = _pacienteAcre.EnderecoComplemento;
            txtEnderecoRuaAcre.Text = _pacienteAcre.EnderecoRua;
            txtEnderecoNumeroAcre.Text = _pacienteAcre.EnderecoNumero;
            txtObservacoes.Text = _pacienteAcre.Observacoes;
        }

        private void SalvaDadosAtuais()
        {
            try
            {
                // Salva todos dados da tela em classe Configuracao
                CarregaDadosTelaEmMemoria();

                // Não salva o PDF do recibo
                string pdfRecibo = TelaPrincipal.PegaClienteAtual().PDFRecibo;
                TelaPrincipal.PegaClienteAtual().PDFRecibo = string.Empty;

                // Cria diretório para os arquivos de configuração se não existir
                string caminhoConfiguracoes = Environment.ExpandEnvironmentVariables(@"%APPDATA%\..\Local\TerapiaReembolso");
                if (!Directory.Exists(caminhoConfiguracoes))
                {
                    Directory.CreateDirectory(caminhoConfiguracoes);
                }

                // Salva configurações de todos clientes em arquivos binários criptografados
                for (int i = 0; i < _listaConfiguracoesClientes.Count(); i++)
                {
                    string arquivoConfiguracao = Path.Combine(caminhoConfiguracoes, $"config_{i}.bin");
                    CryptoSerializer.Serialize<Configuracao>(arquivoConfiguracao, _listaConfiguracoesClientes[i]);
                }

                // Salva lista de pacientes em arquivo binário criptografado se tiver dados
                if (_listaPacientes.Count > 0)
                {
                    string arquivoPacientes = Path.Combine(caminhoConfiguracoes, "pacientes.bin");
                    CryptoSerializer.Serialize<Dictionary<string, Paciente>>(arquivoPacientes, _listaPacientes);
                }

                // Salva paciente acre em arquivo binário criptografado se tiver dados
                if (!string.IsNullOrEmpty(_pacienteAcre.CarteirinhaUnimed))
                {
                    string arquivoPacienteAcre = Path.Combine(caminhoConfiguracoes, "pacienteacre.bin");
                    CryptoSerializer.Serialize<PacienteAcre>(arquivoPacienteAcre, _pacienteAcre);
                }

                // Mantem em memoria o pdf do recibo
                TelaPrincipal.PegaClienteAtual().PDFRecibo = pdfRecibo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Salvando Dados Atuais: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaDadosTelaEmMemoria()
        {
            // Salva todos dados da tela em classe Configuracao
            TelaPrincipal.PegaClienteAtual().TipoPessoaTerapeuta = rbFisica.Checked ? "F" : "J";
            TelaPrincipal.PegaClienteAtual().Cidade = txtCidade.Text;
            TelaPrincipal.PegaClienteAtual().NomeTerapeuta = txtNomeDoTerapeuta.Text;
            TelaPrincipal.PegaClienteAtual().CPFTerapeuta = txtCPFTerapeuta.Text;
            TelaPrincipal.PegaClienteAtual().CRP = txtCRP.Text;
            TelaPrincipal.PegaClienteAtual().CEP = txtCEP.Text;
            TelaPrincipal.PegaClienteAtual().EnderecoTerapeuta = txtEnderecoTerapeuta.Text;
            TelaPrincipal.PegaClienteAtual().TipoAtendimento = rbTelemedicina.Checked ? "T" : "P";

            TelaPrincipal.PegaClienteAtual().NomeBanco = txtNomeDoBanco.Text;
            TelaPrincipal.PegaClienteAtual().Agencia = txtAgenciaSemDigito.Text;
            TelaPrincipal.PegaClienteAtual().Conta = txtContaSemDigito.Text;
            TelaPrincipal.PegaClienteAtual().Digito = txtDigitoDaConta.Text;
            TelaPrincipal.PegaClienteAtual().SenhaUnimed = txtSenhaUnimed.Text;
            TelaPrincipal.PegaClienteAtual().LoginUnimed = txtLoginUnimed.Text;

            PegaPacienteAtual();

            _pacienteAcre.CarteirinhaUnimed = txtLoginUnimedAcre.Text;
            _pacienteAcre.NomeBanco = txtNomeBancoAcre.Text;
            _pacienteAcre.PDFCarteirinhaRequisicao = dialogoPDFCarteirinha.FileName;
            _pacienteAcre.PDFIdentidade = dialogoPDFIdentidade.FileName;
            _pacienteAcre.Bairro = txtEnderecoBairroAcre.Text;
            _pacienteAcre.Estado = txtEstadoAcre.Text;
            _pacienteAcre.EnderecoComplemento = txtEnderecoComplementoAcre.Text;
            _pacienteAcre.EnderecoRua = txtEnderecoRuaAcre.Text;
            _pacienteAcre.EnderecoNumero = txtEnderecoNumeroAcre.Text;
            _pacienteAcre.DataRecibo = dtDataRecibo.Value.ToString("dd/MM/yyyy");
            _pacienteAcre.Observacoes = txtObservacoes.Text;
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Salva dados na tela quando fecha a aplicação
                SalvaDadosAtuais();

                // Fecha Chrome Driver
                Utilitarios.CloseChromeDriver(null);

                // Salvo posição e tamanho da janela
                Properties.Settings.Default.F1State = this.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.F1Location = this.Location;
                    Properties.Settings.Default.F1Size = this.Size;
                }
                else
                {
                    Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                    Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Fechar a Aplicação: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    MessageBox.Show($"Erro ao Rodar Automação (Chrome Desatualizado): {ex.Message}\r\n\r\nAbra o Chrome manualmente, clique nos 3 pontos no canto superior direito, vá para \"Ajuda\", depois em \"Sobre o Google Chrome\" e atualize seu navegador Chrome para a versão mais recente. Então tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao Rodar Automação: {ex.Message}\r\n\r\nFavor tentar de novo o mesmo processo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                toolStripStatus.Text = "Aguardando.";
            }
            finally
            {
                HabilitaDesabilitaControles(true);
            }
        }

        private void RodaAutomacao(Action action)
        {
            toolStripStatus.Text = "Rodando automação (feche o Chrome se quiser abortar). Por favor, espere... Primeira vez que rodar demora um pouco mais.";
            HabilitaDesabilitaControles(false);
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

        private void HabilitaDesabilitaControles(bool habilitado)
        {
            btnExcluirCliente.Enabled = habilitado;
            btnExcluirPaciente.Enabled = habilitado;
            btnFecharDadosCliente.Enabled = habilitado;
            btnFecharSobre.Enabled = habilitado;
            btnGerarRecibo.Enabled = habilitado;
            btnGerarSolicitacaoReembolso.Enabled = habilitado;
            btnNovoCliente.Enabled = habilitado;
            btnNovoPaciente.Enabled = habilitado;
            btnSalvarConsultas.Enabled = habilitado;
            btnSalvarPaciente.Enabled = habilitado;
            btnSelecionarConsultas.Enabled = habilitado;
            btnSelecionarPDFRecibo.Enabled = habilitado;
            btnMostraDadosUnimedAcre.Enabled = habilitado;

            rbFisica.Enabled = habilitado;
            rbJuridica.Enabled = habilitado;
            rbPresencial.Enabled = habilitado;
            rbTelemedicina.Enabled = habilitado;

            txtAgenciaSemDigito.Enabled = habilitado;
            txtCEP.Enabled = habilitado;
            txtCidade.Enabled = habilitado;
            txtContaSemDigito.Enabled = habilitado;
            txtCPFPaciente.Enabled = habilitado;
            txtCPFTerapeuta.Enabled = habilitado;
            txtCRP.Enabled = habilitado;
            txtDigitoDaConta.Enabled = habilitado;
            txtEnderecoTerapeuta.Enabled = habilitado;
            txtLoginUnimed.Enabled = habilitado;
            txtNomeDoBanco.Enabled = habilitado;
            txtNomeDoTerapeuta.Enabled = habilitado;
            txtReferenteA.Enabled = habilitado;
            txtSenhaUnimed.Enabled = habilitado;
            txtValorConsulta.Enabled = habilitado;

            cmbDiaSemana.Enabled = habilitado;
            cmbMes.Enabled = habilitado;
            cmbNomeCliente.Enabled = habilitado;
            cmbNomePaciente.Enabled = habilitado;

            lnkUnimedLogin.Enabled = habilitado;
            lnkAssinarPDF.Enabled = habilitado;
        }

        #endregion

        #region Gerar Solicitação Reembolso Unimed

        private void btnGerarSolicitacaoReembolso_Click(object sender, EventArgs e)
        {
            // Caso seja reembolso Unimed Acre, valida mais dados
            if (VerificaReembolsoAcre() && !ValidaDadosParaReembolsoAcre())
            {
                return;
            }

            try
            {
                // Valida os dados do recibo e reembolso 
                // (muitos campso do recibo são necessário para pedir o reembolso)
                if (ValidaDadosParaRecibo() && ValidaDadosParaReembolso())
                {
                    CarregaDadosTelaEmMemoria();

                    Action action = null;

                    if (!VerificaReembolsoAcre())
                    {
                        action = (Action)SolicitacaoReembolsoUnimedSeguros.GerarSolicitacaoReembolso;
                    }
                    else
                    {
                        action = (Action)SolicitacaoReembolsoUnimedAcre.GerarSolicitacaoReembolso;
                    }

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
                    MessageBox.Show($"Erro ao Rodar Automação (Chrome Desatualizado): {ex.Message}\r\n\r\nAbra o Chrome manualmente, clique nos 3 pontos no canto superior direito, vá para \"Ajuda\", depois em \"Sobre o Google Chrome\" e atualize seu navegador Chrome para a versão mais recente. Então tente de novo o processo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao Rodar Automação: {ex.Message}\r\n\r\nFavor tentar de novo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                toolStripStatus.Text = "Aguardando.";
            }
            finally
            {
                HabilitaDesabilitaControles(true);
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
            try
            {
                if (!VerificaReembolsoAcre())
                {
                    if (ValidaDadosParaReembolso())
                    {
                        CarregaDadosTelaEmMemoria();
                        SolicitacaoReembolsoUnimedSeguros.AbreSegurosUnimedCliente();
                        SolicitacaoReembolsoUnimedSeguros.LoginUnimed();
                    }
                }
                else
                {
                    if (ValidaDadosParaReembolsoAcre())
                    {
                        CarregaDadosTelaEmMemoria();
                        SolicitacaoReembolsoUnimedAcre.AbreUnimedAcre();
                        SolicitacaoReembolsoUnimedAcre.LoginUnimedAcre();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Logar na Unimed: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Selecionar Consultas

        private void btnSelecionarConsultas_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Selecionar Consultas: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarConsultas_Click(object sender, EventArgs e)
        {
            // Salva dados do paciente e fecha panel das consultas
            pnlConsultas.Visible = false;
            pnlDadosReembolso.Visible = true;
            SalvaDadosPaciente();
            SalvaDadosAtuais();
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Calcular Datas das Consultas: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnNovoPaciente_Click(object sender, EventArgs e)
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
            SalvaDadosAtuais();
        }

        private void SalvaDadosPaciente()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar Dados do Paciente: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNomePaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Pega nome do paciente selecionado
                string nomePaciente = cmbNomePaciente.Text;

                // Mostra botão de dados da Unimed Acre somente para o Dimitri
                btnMostraDadosUnimedAcre.Visible = VerificaReembolsoAcre();

                // Carrega dados do paciente selecionado
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar Dados do Paciente: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirPaciente_Click(object sender, EventArgs e)
        {
            try
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
                        btnNovoPaciente_Click(sender, e);

                        // Mostra status da operação
                        toolStripStatus.Text = $"Paciente \"{nomePaciente}\" excluído!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir Paciente: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void cmbNomePaciente_TextChanged(object sender, EventArgs e)
        {
            cmbNomePaciente.Text = Utilitarios.RemoveAcentos(cmbNomePaciente.Text);
        }

        #endregion

        #region Pessoal Física e Jurídica

        private void rbFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFisica.Checked)
            {
                lblNomeDoTerapeuta.Visible = true;
                lbNomeEmpresa.Visible = false;
                lblCPFTerapeuta.Visible = true;
                lblCNPJTerapeuta.Visible = false;
                lblReciboConsulta.Text = "Recibo Assinado:";
                btnSelecionarPDFRecibo.Text = "Selecionar PDF Recibo";
            }
        }

        private void rbJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJuridica.Checked)
            {
                lblNomeDoTerapeuta.Visible = false;
                lbNomeEmpresa.Visible = true;
                lblCPFTerapeuta.Visible = false;
                lblCNPJTerapeuta.Visible = true;
                lblReciboConsulta.Text = "Nota Fiscal PDF:";
                btnSelecionarPDFRecibo.Text = "Selecionar Nota Fiscal";
            }
        }

        #endregion

        #region Cadastro de Clientes

        public static Configuracao PegaClienteAtual()
        {
            // Se não tem nada salvo, cria um cliente padrão
            CriaClientePadraoSeNaoExistir();

            return _listaConfiguracoesClientes[_indiceClienteAtual];
        }

        private void adicionarExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostra panel de cadastro de clientes
            pnlSobre.Visible = false;
            pnlConsultas.Visible = false;
            pnlReembolso.Visible = false;
            pnlRecibo.Visible = false;
            pnlCadastroCliente.Visible = true;
            cmbNomeCliente.Focus();
        }

        private void btnFecharDadosCliente_Click(object sender, EventArgs e)
        {
            // Esconde painel de cadastro de clientes
            pnlSobre.Visible = false;
            pnlConsultas.Visible = false;
            pnlReembolso.Visible = true;
            pnlRecibo.Visible = true;
            pnlCadastroCliente.Visible = false;
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Nome do paciente necessário para salvar
                if (cmbNomeCliente.Text == string.Empty)
                {
                    MessageBox.Show("Favor informar o nome do cliente primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNomeCliente.Focus();
                    return;
                }

                // Busca nome do novo cliente
                string nomeClienteNovo = cmbNomeCliente.Text;

                // Verifica se cliente foi preenchido e não existe ainda
                if (!string.IsNullOrEmpty(nomeClienteNovo) && cmbNomeCliente.FindStringExact(nomeClienteNovo) == -1)
                {
                    // Limpa todos campos que não são do paciente
                    LimpaCamposCliente();

                    // Adiciona novo cliente na lista e seta indice para novo cliente
                    Configuracao configuracao = new Configuracao
                    {
                        NomeCliente = nomeClienteNovo
                    };
                    _listaConfiguracoesClientes.Add(configuracao);

                    int indiceNovoCliente = _listaConfiguracoesClientes.Count - 1;

                    // Adiciona o novo cliente no menu
                    AdicionaClienteMenu(nomeClienteNovo, indiceNovoCliente);

                    // Clica no cliente criado
                    nomeClienteMenu_Click(clientesToolStripMenuItem.DropDownItems[2 + indiceNovoCliente], EventArgs.Empty);

                    // Seta nome do paciente igual ao nome do cliente criado
                    cmbNomePaciente.Text = nomeClienteNovo;

                    // Fecha o panel
                    btnFecharDadosCliente_Click(null, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Criar Novo Cliente: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpaCamposCliente()
        {
            // Limpa todos campos do cliente quando cria um novo
            rbFisica.Checked = true;
            rbTelemedicina.Checked = true;
            txtNomeDoTerapeuta.Text = string.Empty;
            txtCPFTerapeuta.Text = string.Empty;
            txtCRP.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEnderecoTerapeuta.Text = string.Empty;
            txtNomeDoBanco.Text = string.Empty;
            txtAgenciaSemDigito.Text = string.Empty;
            txtContaSemDigito.Text = string.Empty;
            txtDigitoDaConta.Text = string.Empty;
        }

        private void AdicionaClienteMenu(string nomeClienteNovo, int indice)
        {
            // Adiciona o novo cliente no menu
            ToolStripMenuItem nomeClienteMenu = new ToolStripMenuItem();
            nomeClienteMenu.Text = nomeClienteNovo;
            nomeClienteMenu.Click += nomeClienteMenu_Click;
            nomeClienteMenu.Tag = indice;
            clientesToolStripMenuItem.DropDownItems.Add(nomeClienteMenu);
        }

        private void RemoveClienteMenu(int indice)
        {
            // Remove cliente excluido do menu
            clientesToolStripMenuItem.DropDownItems.RemoveAt(indice + 2);
        }

        private void nomeClienteMenu_Click(object sender, EventArgs e)
        {
            try
            {
                // Remove flecha da seleção anterior
                if (clientesToolStripMenuItem.DropDownItems[_indiceClienteAtual + 2].Text.StartsWith("→ "))
                {
                    clientesToolStripMenuItem.DropDownItems[_indiceClienteAtual + 2].Text = clientesToolStripMenuItem.DropDownItems[_indiceClienteAtual + 2].Text.Substring(2);
                }

                ToolStripMenuItem menu = (ToolStripMenuItem)sender;

                // Tenta achar o nome do paciente igual se tiver e já seleciona
                int indicePaciente = cmbNomePaciente.FindStringExact(menu.Text);
                if (indicePaciente >= 0)
                {
                    cmbNomePaciente.SelectedIndex = indicePaciente;
                }

                // Adiciona flecha na seleção atual
                menu.Text = "→ " + menu.Text;

                // Pega o índice do cliente selecionado
                int indice = (int)menu.Tag;
                _indiceClienteAtual = indice;

                // Limpa o recibo
                dialogoPDFRecibo.FileName = string.Empty;
                lblNomeArquivoRecibo.Text = string.Empty;

                // Mostra toda configuração do cliente selecionado na tela
                AtualizaTelaComConfiguracaoAtual();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Carregando Dados do Cliente: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbNomeCliente.Text))
                {
                    return;
                }

                // Busca o cliente selecionado
                for (int i = 0; i < _listaConfiguracoesClientes.Count; i++)
                {
                    // Caso encontre pelo nome
                    if (cmbNomeCliente.Text == _listaConfiguracoesClientes[i].NomeCliente)
                    {
                        // Remove cliente da lista, do menu e seta indice 0
                        _listaConfiguracoesClientes.RemoveAt(i);
                        RemoveClienteMenu(i);
                        _indiceClienteAtual = 0;

                        if (_listaConfiguracoesClientes.Count > 0)
                        {
                            // Refaz os indices dos clientes no menu
                            for (int f = 2; f < clientesToolStripMenuItem.DropDownItems.Count; f++)
                            {
                                clientesToolStripMenuItem.DropDownItems[f].Tag = f - 2;
                            }

                            // Clica no primeiro cliente
                            nomeClienteMenu_Click(clientesToolStripMenuItem.DropDownItems[2], EventArgs.Empty);
                        }
                        else
                        {
                            LimpaCamposCliente();
                        }

                        // Remove do dropdown
                        cmbNomeCliente.Items.RemoveAt(cmbNomeCliente.FindStringExact(cmbNomeCliente.Text));
                        cmbNomeCliente.Text = String.Empty;
                        cmbNomeCliente.SelectedIndex = -1;

                        // Remove arquivo com configuração
                        string arquivoConfiguracao = Path.Combine(_caminhoConfiguracoes, $"config_{i}.bin");
                        if (File.Exists(arquivoConfiguracao))
                        {
                            File.Delete(arquivoConfiguracao);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir Cliente: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Backup/Restaurar

        private void restaurarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Pede nome do arquivo zip para restaurar backup
                DialogResult dialogResult = dialogoRestaurarBackup.ShowDialog();

                // Se arquivo foi selecionado
                if (dialogResult == DialogResult.OK)
                {
                    // Verifica extensão do arquivo
                    if (Path.GetExtension(dialogoRestaurarBackup.FileName).ToLower() != ".zip")
                    {
                        MessageBox.Show("Favor selecionar um arquivo ZIP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dialogoPDFRecibo.FileName = "";
                        return;
                    }
                    else
                    {
                        // Confirma com usuário restauração do backup apagando os dados atuais
                        DialogResult verificacaoUsuario = MessageBox.Show("ATENÇÃO!!!!! Os dados atuais serão sobreescritos por este backup e não poderão ser restaurados.\r\nDeseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        if (verificacaoUsuario != DialogResult.Yes)
                        {
                            return;
                        }

                        // Abre zip com backup
                        using (FileStream zipFile = File.Open(dialogoRestaurarBackup.FileName, FileMode.Open))
                        {
                            using (var archive = new Archive(zipFile))
                            {
                                // Descompacta os arquivos na pasta
                                archive.ExtractToDirectory(_caminhoConfiguracoes);

                                // Recarrega tudo
                                CarregaDadosSalvos();

                                // Seleciona primeiro paciente se existir algum cadastrado
                                if (cmbNomePaciente.Items.Count > 0)
                                {
                                    cmbNomePaciente.SelectedIndex = 0;
                                }

                                // Mostra mensagem de sucesso
                                MessageBox.Show($"Backup restaurado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Restaurar Backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fazerBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria nome padrão de arquivo para backup
                dialogoSalvarBackup.FileName = $"TerapiaReembolsoBackup_{DateTime.Now.ToString("dd.MM.yyyy")}.zip";

                // Pede nome do arquivo zip para criar backup
                DialogResult dialogResult = dialogoSalvarBackup.ShowDialog();

                // Se arquivo foi selecionado
                if (dialogResult == DialogResult.OK)
                {
                    // Verifica extensão do arquivo
                    if (Path.GetExtension(dialogoSalvarBackup.FileName).ToLower() != ".zip")
                    {
                        MessageBox.Show("Favor selecionar um arquivo ZIP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dialogoPDFRecibo.FileName = "";
                        return;
                    }
                    else
                    {
                        // Salva dados antes de fazer o backup
                        SalvaDadosAtuais();

                        List<FileInfo> listaArquvosParaBackup = new List<FileInfo>();

                        // Pega informação do arquivos de pacientes
                        string arquivoPacientes = Path.Combine(_caminhoConfiguracoes, "pacientes.bin");
                        if (File.Exists(arquivoPacientes))
                        {
                            FileInfo fileInfo = new FileInfo(arquivoPacientes);
                            listaArquvosParaBackup.Add(fileInfo);
                        }

                        // Pega informação de todos arquivos de clientes
                        for (int i = 0; i < 100; i++)
                        {
                            string arquivoConfiguracao = Path.Combine(_caminhoConfiguracoes, $"config_{i}.bin");
                            if (File.Exists(arquivoConfiguracao))
                            {
                                FileInfo fileInfo = new FileInfo(arquivoConfiguracao);
                                listaArquvosParaBackup.Add(fileInfo);
                            }
                        }

                        // Cria FileStream para gerar o backup como arquivo zip
                        using (FileStream zipFile = File.Open(dialogoSalvarBackup.FileName, FileMode.Create))
                        {
                            using (var archive = new Archive())
                            {
                                // Adiciona arquivos ao zip
                                foreach (FileInfo fileInfo in listaArquvosParaBackup)
                                {
                                    archive.CreateEntry(fileInfo.Name, fileInfo);
                                }

                                // Cria arquivo zip
                                archive.Save(zipFile);

                                // Mostra mensagem de sucesso
                                MessageBox.Show($"Backup criado e salvo em:\r\n\r\n{dialogoSalvarBackup.FileName}\r\n\r\nGuarde o arquivo na Internet (ex: OneDrive ou Google Drive) para evitar perda de dados.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Realizar Backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Reembolso Unimed Acre

        private bool VerificaReembolsoAcre()
        {
            // Pega nome do paciente selecionado
            string nomePaciente = cmbNomePaciente.Text;

            // Reembolso Unimed Acre somente para o Dimitri Melo Dourado
            return (nomePaciente == "Dimitri Melo Dourado");
        }

        public static PacienteAcre PegaPacienteAcre()
        {
            return _pacienteAcre;
        }

        private void btnMostraDadosUnimedAcre_Click(object sender, EventArgs e)
        {
            MostraDadosUnimedAcre();
        }

        private void MostraDadosUnimedAcre()
        {
            pnlUnimedAcre.Visible = true;
            pnlUnimedAcre.BringToFront();
            btnGerarRecibo.Enabled = false;
            btnGerarSolicitacaoReembolso.Enabled = false;
        }

        private void btnSalvarDadosAcre_Click(object sender, EventArgs e)
        {
            if (!ValidaDadosParaReembolsoAcre())
                return;

            pnlUnimedAcre.Visible = false;

            SalvaDadosAtuais();

            btnGerarRecibo.Enabled = true;
            btnGerarSolicitacaoReembolso.Enabled = true;
        }

        private bool ValidaDadosParaReembolsoAcre()
        {
            // Valida Número Carteirinha
            if (string.IsNullOrEmpty(txtLoginUnimedAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor Número Carteirinha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimedAcre.Focus();
                txtLoginUnimedAcre.SelectAll();
                return false;
            }

            // Valida Número Carteirinha só números
            if (!Regex.IsMatch(txtLoginUnimedAcre.Text, @"^\d+$"))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Número Carteirinha somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgenciaSemDigito.Focus();
                txtAgenciaSemDigito.SelectAll();
                return false;
            }

            // Valida nome do banco
            if (string.IsNullOrEmpty(txtNomeBancoAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor nome do banco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeBancoAcre.Focus();
                txtNomeBancoAcre.SelectAll();
                return false;
            }

            // Valida Endereço (Rua)
            if (string.IsNullOrEmpty(txtEnderecoRuaAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Endereço (Rua).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoRuaAcre.Focus();
                txtEnderecoRuaAcre.SelectAll();
                return false;
            }

            // Valida Dígito da Conta só números
            if (!Regex.IsMatch(txtDigitoDaConta.Text, @"^\d+$"))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Dígito da Conta somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDigitoDaConta.Focus();
                txtDigitoDaConta.SelectAll();
                return false;
            }

            // Valida Número
            if (string.IsNullOrEmpty(txtEnderecoNumeroAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Número.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoNumeroAcre.Focus();
                txtEnderecoNumeroAcre.SelectAll();
                return false;
            }

            // Valida campo Número só números
            if (!Regex.IsMatch(txtEnderecoNumeroAcre.Text, @"^\d+$"))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar no campo Número somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoNumeroAcre.Focus();
                txtEnderecoNumeroAcre.SelectAll();
                return false;
            }

            // Valida Complemento
            if (string.IsNullOrEmpty(txtEnderecoComplementoAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Complemento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoComplementoAcre.Focus();
                txtEnderecoComplementoAcre.SelectAll();
                return false;
            }

            // Valida Bairro
            if (string.IsNullOrEmpty(txtEnderecoBairroAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Bairro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoBairroAcre.Focus();
                txtEnderecoBairroAcre.SelectAll();
                return false;
            }

            // Valida PDF da carteirinha
            if (string.IsNullOrEmpty(dialogoPDFCarteirinha.FileName))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor selecionar PDF da cateirinha/requisição médica.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSelecionarPDFCarteirinha.Focus();
                return false;
            }

            // Valida PDF da identidade
            if (string.IsNullOrEmpty(dialogoPDFIdentidade.FileName))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor selecionar PDF da identidade.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSelecionarPDFIdentidade.Focus();
                return false;
            }

            if (dtDataRecibo.Value == DateTime.Now.AddDays(1).Date)
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor selecionar data do recibo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtDataRecibo.Focus();
                return false;
            }

            return true;
        }

        private void btnSelecionarPDFCarteirinha_Click(object sender, EventArgs e)
        {
            try
            {
                // Pede arquivo PDF da carteirinha pro usuário
                DialogResult dialogResult = dialogoPDFCarteirinha.ShowDialog();

                // Se arquivo foi selecionado
                if (dialogResult == DialogResult.OK)
                {
                    // Verifica extensão do arquivo
                    if (Path.GetExtension(dialogoPDFCarteirinha.FileName).ToLower() != ".pdf")
                    {
                        MessageBox.Show("Favor selecionar um arquivo PDF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dialogoPDFCarteirinha.FileName = "";
                    }
                    else
                    {
                        TelaPrincipal.PegaPacienteAcre().PDFCarteirinhaRequisicao = dialogoPDFCarteirinha.FileName;
                    }

                    // Mostra nome do PDF na tela
                    lblNomeArquivoCarteirinha.Text = Path.GetFileName(dialogoPDFCarteirinha.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro selecionando PDF: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelecionarPDFIdentidade_Click(object sender, EventArgs e)
        {
            try
            {
                // Pede arquivo PDF da identidade pro usuário
                DialogResult dialogResult = dialogoPDFIdentidade.ShowDialog();

                // Se arquivo foi selecionado
                if (dialogResult == DialogResult.OK)
                {
                    // Verifica extensão do arquivo
                    if (Path.GetExtension(dialogoPDFIdentidade.FileName).ToLower() != ".pdf")
                    {
                        MessageBox.Show("Favor selecionar um arquivo PDF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dialogoPDFRecibo.FileName = "";
                    }
                    else
                    {
                        TelaPrincipal.PegaPacienteAcre().PDFIdentidade = dialogoPDFIdentidade.FileName;
                    }

                    // Mostra nome do PDF na tela
                    lblNomeArquivoIdentidade.Text = Path.GetFileName(dialogoPDFIdentidade.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro selecionando PDF: " + ex.Message + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Tela de Sobre...

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fecha aplicação toda e salva os dados
            Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostra panel de Sobre... com ajuda e ano atual atualizado
            pnlSobre.Visible = true;
            pnlConsultas.Visible = false;
            pnlReembolso.Visible = false;
            pnlRecibo.Visible = false;
            pnlCadastroCliente.Visible = false;
            lblCopyright.Text = $"Copyright © Daniel Liedke {DateTime.Now.Year}";
            lblNomeAplicao.Text = this.Text;
        }

        private void btnFecharSobre_Click(object sender, EventArgs e)
        {
            // Fecha panel de Sobre...
            pnlSobre.Visible = false;
            pnlConsultas.Visible = false;
            pnlReembolso.Visible = true;
            pnlReembolso.BringToFront();
            pnlRecibo.Visible = true;
        }

        #endregion
    }
}
