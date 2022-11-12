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
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
        #region Variáveis Estáticas e Inicialização da Aplicação

        private static int _indiceClienteAtual = 0;
        private static List<Configuracao> _listaConfiguracoesClientes = new List<Configuracao>();
        private static DateTimePickerWithBackColor[] _datasConsultasControles;
        private static Dictionary<string, Paciente> _listaPacientes = new Dictionary<string, Paciente>();
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
                MostraMensagemBoasVindas();
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

        private void MostraMensagemBoasVindas()
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

        #region Selecionar Recibo PDF

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

        #endregion

        #region Gerar Recibo Consulta em PDF e Solicitação Reembolso Unimed

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
            btnFecharAjuda.Enabled = habilitado;
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

        #region Link para Assinar PDF e Login Unimed Seguros/Acre

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

        #region Seleção Pessoa Física e Jurídica

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

        #region Gerenciamento da Tela Ajuda

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fecha aplicação toda e salva os dados
            Close();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostra panel de ajuda e ano atual atualizado
            pnlSobre.Visible = true;
            pnlConsultas.Visible = false;
            pnlReembolso.Visible = false;
            pnlRecibo.Visible = false;
            pnlCadastroCliente.Visible = false;
            lblCopyright.Text = $"Copyright © Daniel Liedke {DateTime.Now.Year}";
            lblNomeAplicao.Text = this.Text;
        }

        private void btnFecharAjuda_Click(object sender, EventArgs e)
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
