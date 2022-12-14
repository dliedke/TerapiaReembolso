namespace TerapiaReembolso
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.btnGerarRecibo = new System.Windows.Forms.Button();
            this.txtValorConsulta = new System.Windows.Forms.MaskedTextBox();
            this.lblNomeDoPaciente = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblReferenteA = new System.Windows.Forms.Label();
            this.lblReciboConsulta = new System.Windows.Forms.Label();
            this.btnSelecionarPDFRecibo = new System.Windows.Forms.Button();
            this.dialogoPDFRecibo = new System.Windows.Forms.OpenFileDialog();
            this.lblCPFPaciente = new System.Windows.Forms.Label();
            this.txtCPFPaciente = new System.Windows.Forms.TextBox();
            this.lblNomeArquivoRecibo = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lnkAssinarPDF = new System.Windows.Forms.LinkLabel();
            this.txtReferenteA = new System.Windows.Forms.TextBox();
            this.lblNomeDoTerapeuta = new System.Windows.Forms.Label();
            this.txtNomeDoTerapeuta = new System.Windows.Forms.TextBox();
            this.lblCPFTerapeuta = new System.Windows.Forms.Label();
            this.txtCPFTerapeuta = new System.Windows.Forms.TextBox();
            this.lblEnderecoTerapeuta = new System.Windows.Forms.Label();
            this.txtEnderecoTerapeuta = new System.Windows.Forms.TextBox();
            this.lblCRP = new System.Windows.Forms.Label();
            this.txtCRP = new System.Windows.Forms.TextBox();
            this.btnSelecionarConsultas = new System.Windows.Forms.Button();
            this.pnlConsultas = new System.Windows.Forms.Panel();
            this.lbDiaSemana = new System.Windows.Forms.Label();
            this.lbMes = new System.Windows.Forms.Label();
            this.cmbDiaSemana = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.btnSalvarConsultas = new System.Windows.Forms.Button();
            this.lblNumeroDeConsultas = new System.Windows.Forms.Label();
            this.numNumeroConsultas = new System.Windows.Forms.NumericUpDown();
            this.lblSelecioneDataConsultas = new System.Windows.Forms.Label();
            this.pnlRecibo = new System.Windows.Forms.Panel();
            this.pnlDadosTerapeuta = new System.Windows.Forms.Panel();
            this.lblCNPJTerapeuta = new System.Windows.Forms.Label();
            this.lbNomeEmpresa = new System.Windows.Forms.Label();
            this.gbTipoPessoa = new System.Windows.Forms.GroupBox();
            this.rbFisica = new System.Windows.Forms.RadioButton();
            this.rbJuridica = new System.Windows.Forms.RadioButton();
            this.lbDadosTerapeuta = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.lblTituloGeracaoRecibo = new System.Windows.Forms.Label();
            this.pnlDadosPaciente = new System.Windows.Forms.Panel();
            this.btnNovoPaciente = new System.Windows.Forms.Button();
            this.btnExcluirPaciente = new System.Windows.Forms.Button();
            this.btnSalvarPaciente = new System.Windows.Forms.Button();
            this.cmbNomePaciente = new System.Windows.Forms.ComboBox();
            this.lbDadosPaciente = new System.Windows.Forms.Label();
            this.pnlReembolso = new System.Windows.Forms.Panel();
            this.lnkUnimedLogin = new System.Windows.Forms.LinkLabel();
            this.lblTituloSolicitacaoReembolso = new System.Windows.Forms.Label();
            this.btnGerarSolicitacaoReembolso = new System.Windows.Forms.Button();
            this.pnlDadosReembolso = new System.Windows.Forms.Panel();
            this.btnMostraDadosUnimedAcre = new System.Windows.Forms.Button();
            this.lbDadosReembolso = new System.Windows.Forms.Label();
            this.lblLoginUnimed = new System.Windows.Forms.Label();
            this.txtLoginUnimed = new System.Windows.Forms.TextBox();
            this.grbTipoAtendimento = new System.Windows.Forms.GroupBox();
            this.rbPresencial = new System.Windows.Forms.RadioButton();
            this.rbTelemedicina = new System.Windows.Forms.RadioButton();
            this.txtSenhaUnimed = new System.Windows.Forms.TextBox();
            this.lblSenhaUnimed = new System.Windows.Forms.Label();
            this.pnlDadosBancarios = new System.Windows.Forms.Panel();
            this.lbDadosBancarios = new System.Windows.Forms.Label();
            this.lblNomeDoBanco = new System.Windows.Forms.Label();
            this.lblDigitoDaConta = new System.Windows.Forms.Label();
            this.txtNomeDoBanco = new System.Windows.Forms.TextBox();
            this.txtDigitoDaConta = new System.Windows.Forms.TextBox();
            this.txtAgenciaSemDigito = new System.Windows.Forms.TextBox();
            this.lblContaSemDigito = new System.Windows.Forms.Label();
            this.txtContaSemDigito = new System.Windows.Forms.TextBox();
            this.lblAgenciaSemDigito = new System.Windows.Forms.Label();
            this.pnlUnimedAcre = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.lbDataRecibo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstadoAcre = new System.Windows.Forms.TextBox();
            this.lblNomeArquivoIdentidade = new System.Windows.Forms.Label();
            this.lblNomeArquivoCarteirinha = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtEnderecoBairroAcre = new System.Windows.Forms.TextBox();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.txtEnderecoComplementoAcre = new System.Windows.Forms.TextBox();
            this.btnSalvarDadosAcre = new System.Windows.Forms.Button();
            this.btnSelecionarPDFIdentidade = new System.Windows.Forms.Button();
            this.lblIdentidade = new System.Windows.Forms.Label();
            this.btnSelecionarPDFCarteirinha = new System.Windows.Forms.Button();
            this.lblCarteirinha = new System.Windows.Forms.Label();
            this.lblDadosUnimedAcre = new System.Windows.Forms.Label();
            this.lblNumeroCarteirinha = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtLoginUnimedAcre = new System.Windows.Forms.TextBox();
            this.txtEnderecoNumeroAcre = new System.Windows.Forms.TextBox();
            this.txtNomeBancoAcre = new System.Windows.Forms.TextBox();
            this.lblRua = new System.Windows.Forms.Label();
            this.txtEnderecoRuaAcre = new System.Windows.Forms.TextBox();
            this.lblNomeBancoAcre = new System.Windows.Forms.Label();
            this.menuAplicacao = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fazerBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarExcluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLinha1 = new System.Windows.Forms.ToolStripSeparator();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSobre = new System.Windows.Forms.Panel();
            this.lblAjuda = new System.Windows.Forms.Label();
            this.picIconeSobre = new System.Windows.Forms.PictureBox();
            this.btnFecharAjuda = new System.Windows.Forms.Button();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblNomeAplicao = new System.Windows.Forms.Label();
            this.pnlCadastroCliente = new System.Windows.Forms.Panel();
            this.lbInstrucoesClientes = new System.Windows.Forms.Label();
            this.btnNovoCliente = new System.Windows.Forms.Button();
            this.btnExcluirCliente = new System.Windows.Forms.Button();
            this.cmbNomeCliente = new System.Windows.Forms.ComboBox();
            this.lbCliente = new System.Windows.Forms.Label();
            this.lbNomeCliente = new System.Windows.Forms.Label();
            this.btnFecharDadosCliente = new System.Windows.Forms.Button();
            this.dialogoSalvarBackup = new System.Windows.Forms.SaveFileDialog();
            this.dialogoRestaurarBackup = new System.Windows.Forms.OpenFileDialog();
            this.dialogoPDFCarteirinha = new System.Windows.Forms.OpenFileDialog();
            this.dialogoPDFIdentidade = new System.Windows.Forms.OpenFileDialog();
            this.dtDataConsulta10 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta9 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta8 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta7 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta6 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta4 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta3 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta5 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta2 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataConsulta1 = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.dtDataRecibo = new TerapiaReembolso.DateTimePickerWithBackColor();
            this.statusStrip.SuspendLayout();
            this.pnlConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroConsultas)).BeginInit();
            this.pnlRecibo.SuspendLayout();
            this.pnlDadosTerapeuta.SuspendLayout();
            this.gbTipoPessoa.SuspendLayout();
            this.pnlDadosPaciente.SuspendLayout();
            this.pnlReembolso.SuspendLayout();
            this.pnlDadosReembolso.SuspendLayout();
            this.grbTipoAtendimento.SuspendLayout();
            this.pnlDadosBancarios.SuspendLayout();
            this.pnlUnimedAcre.SuspendLayout();
            this.menuAplicacao.SuspendLayout();
            this.pnlSobre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconeSobre)).BeginInit();
            this.pnlCadastroCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerarRecibo
            // 
            this.btnGerarRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarRecibo.ForeColor = System.Drawing.Color.White;
            this.btnGerarRecibo.Location = new System.Drawing.Point(195, 829);
            this.btnGerarRecibo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGerarRecibo.Name = "btnGerarRecibo";
            this.btnGerarRecibo.Size = new System.Drawing.Size(201, 62);
            this.btnGerarRecibo.TabIndex = 3;
            this.btnGerarRecibo.Text = "Gerar Recibo";
            this.btnGerarRecibo.UseVisualStyleBackColor = true;
            this.btnGerarRecibo.Click += new System.EventHandler(this.btnGerarRecibo_Click);
            // 
            // txtValorConsulta
            // 
            this.txtValorConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtValorConsulta.ForeColor = System.Drawing.Color.White;
            this.txtValorConsulta.Location = new System.Drawing.Point(198, 101);
            this.txtValorConsulta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValorConsulta.Name = "txtValorConsulta";
            this.txtValorConsulta.Size = new System.Drawing.Size(70, 26);
            this.txtValorConsulta.TabIndex = 1;
            this.txtValorConsulta.ValidatingType = typeof(int);
            this.txtValorConsulta.TextChanged += new System.EventHandler(this.txtValorConsulta_TextChanged);
            // 
            // lblNomeDoPaciente
            // 
            this.lblNomeDoPaciente.ForeColor = System.Drawing.Color.White;
            this.lblNomeDoPaciente.Location = new System.Drawing.Point(130, 54);
            this.lblNomeDoPaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeDoPaciente.Name = "lblNomeDoPaciente";
            this.lblNomeDoPaciente.Size = new System.Drawing.Size(64, 38);
            this.lblNomeDoPaciente.TabIndex = 4;
            this.lblNomeDoPaciente.Text = "Nome:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.ForeColor = System.Drawing.Color.White;
            this.lblValorTotal.Location = new System.Drawing.Point(72, 105);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(117, 20);
            this.lblValorTotal.TabIndex = 5;
            this.lblValorTotal.Text = "Valor Consulta:";
            // 
            // lblReferenteA
            // 
            this.lblReferenteA.AutoSize = true;
            this.lblReferenteA.ForeColor = System.Drawing.Color.White;
            this.lblReferenteA.Location = new System.Drawing.Point(86, 195);
            this.lblReferenteA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReferenteA.Name = "lblReferenteA";
            this.lblReferenteA.Size = new System.Drawing.Size(98, 20);
            this.lblReferenteA.TabIndex = 6;
            this.lblReferenteA.Text = "Referente à:";
            this.lblReferenteA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReciboConsulta
            // 
            this.lblReciboConsulta.AutoSize = true;
            this.lblReciboConsulta.ForeColor = System.Drawing.Color.White;
            this.lblReciboConsulta.Location = new System.Drawing.Point(33, 192);
            this.lblReciboConsulta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReciboConsulta.Name = "lblReciboConsulta";
            this.lblReciboConsulta.Size = new System.Drawing.Size(130, 20);
            this.lblReciboConsulta.TabIndex = 7;
            this.lblReciboConsulta.Text = "Recibo Consulta:";
            // 
            // btnSelecionarPDFRecibo
            // 
            this.btnSelecionarPDFRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarPDFRecibo.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarPDFRecibo.Location = new System.Drawing.Point(179, 185);
            this.btnSelecionarPDFRecibo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelecionarPDFRecibo.Name = "btnSelecionarPDFRecibo";
            this.btnSelecionarPDFRecibo.Size = new System.Drawing.Size(224, 35);
            this.btnSelecionarPDFRecibo.TabIndex = 2;
            this.btnSelecionarPDFRecibo.Text = "Selecionar PDF Recibo";
            this.btnSelecionarPDFRecibo.UseVisualStyleBackColor = true;
            this.btnSelecionarPDFRecibo.Click += new System.EventHandler(this.btnSelectPDF_Click);
            // 
            // dialogoPDFRecibo
            // 
            this.dialogoPDFRecibo.Filter = "PDF files|*.pdf";
            // 
            // lblCPFPaciente
            // 
            this.lblCPFPaciente.AutoSize = true;
            this.lblCPFPaciente.ForeColor = System.Drawing.Color.White;
            this.lblCPFPaciente.Location = new System.Drawing.Point(138, 149);
            this.lblCPFPaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCPFPaciente.Name = "lblCPFPaciente";
            this.lblCPFPaciente.Size = new System.Drawing.Size(44, 20);
            this.lblCPFPaciente.TabIndex = 10;
            this.lblCPFPaciente.Text = "CPF:";
            // 
            // txtCPFPaciente
            // 
            this.txtCPFPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtCPFPaciente.ForeColor = System.Drawing.Color.White;
            this.txtCPFPaciente.Location = new System.Drawing.Point(198, 149);
            this.txtCPFPaciente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCPFPaciente.MaxLength = 16;
            this.txtCPFPaciente.Name = "txtCPFPaciente";
            this.txtCPFPaciente.Size = new System.Drawing.Size(329, 26);
            this.txtCPFPaciente.TabIndex = 5;
            this.txtCPFPaciente.TextChanged += new System.EventHandler(this.txtCPFPaciente_TextChanged);
            // 
            // lblNomeArquivoRecibo
            // 
            this.lblNomeArquivoRecibo.AutoEllipsis = true;
            this.lblNomeArquivoRecibo.ForeColor = System.Drawing.Color.White;
            this.lblNomeArquivoRecibo.Location = new System.Drawing.Point(176, 225);
            this.lblNomeArquivoRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeArquivoRecibo.Name = "lblNomeArquivoRecibo";
            this.lblNomeArquivoRecibo.Size = new System.Drawing.Size(328, 26);
            this.lblNomeArquivoRecibo.TabIndex = 11;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 962);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(3, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1204, 32);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 12;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.ForeColor = System.Drawing.Color.White;
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(45, 25);
            this.toolStripStatus.Text = "Idle.";
            // 
            // lnkAssinarPDF
            // 
            this.lnkAssinarPDF.AutoSize = true;
            this.lnkAssinarPDF.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lnkAssinarPDF.Location = new System.Drawing.Point(489, 11);
            this.lnkAssinarPDF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAssinarPDF.Name = "lnkAssinarPDF";
            this.lnkAssinarPDF.Size = new System.Drawing.Size(98, 20);
            this.lnkAssinarPDF.TabIndex = 24;
            this.lnkAssinarPDF.TabStop = true;
            this.lnkAssinarPDF.Text = "Assinar PDF";
            this.lnkAssinarPDF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAssinarPDF_LinkClicked);
            // 
            // txtReferenteA
            // 
            this.txtReferenteA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtReferenteA.ForeColor = System.Drawing.Color.White;
            this.txtReferenteA.Location = new System.Drawing.Point(195, 195);
            this.txtReferenteA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReferenteA.MaxLength = 32;
            this.txtReferenteA.Name = "txtReferenteA";
            this.txtReferenteA.Size = new System.Drawing.Size(332, 26);
            this.txtReferenteA.TabIndex = 6;
            // 
            // lblNomeDoTerapeuta
            // 
            this.lblNomeDoTerapeuta.AutoSize = true;
            this.lblNomeDoTerapeuta.ForeColor = System.Drawing.Color.White;
            this.lblNomeDoTerapeuta.Location = new System.Drawing.Point(120, 91);
            this.lblNomeDoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeDoTerapeuta.Name = "lblNomeDoTerapeuta";
            this.lblNomeDoTerapeuta.Size = new System.Drawing.Size(55, 20);
            this.lblNomeDoTerapeuta.TabIndex = 27;
            this.lblNomeDoTerapeuta.Text = "Nome:";
            // 
            // txtNomeDoTerapeuta
            // 
            this.txtNomeDoTerapeuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtNomeDoTerapeuta.ForeColor = System.Drawing.Color.White;
            this.txtNomeDoTerapeuta.Location = new System.Drawing.Point(190, 92);
            this.txtNomeDoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeDoTerapeuta.MaxLength = 32;
            this.txtNomeDoTerapeuta.Name = "txtNomeDoTerapeuta";
            this.txtNomeDoTerapeuta.Size = new System.Drawing.Size(340, 26);
            this.txtNomeDoTerapeuta.TabIndex = 1;
            // 
            // lblCPFTerapeuta
            // 
            this.lblCPFTerapeuta.AutoSize = true;
            this.lblCPFTerapeuta.ForeColor = System.Drawing.Color.White;
            this.lblCPFTerapeuta.Location = new System.Drawing.Point(130, 135);
            this.lblCPFTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCPFTerapeuta.Name = "lblCPFTerapeuta";
            this.lblCPFTerapeuta.Size = new System.Drawing.Size(44, 20);
            this.lblCPFTerapeuta.TabIndex = 29;
            this.lblCPFTerapeuta.Text = "CPF:";
            // 
            // txtCPFTerapeuta
            // 
            this.txtCPFTerapeuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtCPFTerapeuta.ForeColor = System.Drawing.Color.White;
            this.txtCPFTerapeuta.Location = new System.Drawing.Point(190, 135);
            this.txtCPFTerapeuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCPFTerapeuta.MaxLength = 20;
            this.txtCPFTerapeuta.Name = "txtCPFTerapeuta";
            this.txtCPFTerapeuta.Size = new System.Drawing.Size(340, 26);
            this.txtCPFTerapeuta.TabIndex = 2;
            this.txtCPFTerapeuta.TextChanged += new System.EventHandler(this.txtCPFTerapeuta_TextChanged);
            // 
            // lblEnderecoTerapeuta
            // 
            this.lblEnderecoTerapeuta.AutoSize = true;
            this.lblEnderecoTerapeuta.ForeColor = System.Drawing.Color.White;
            this.lblEnderecoTerapeuta.Location = new System.Drawing.Point(94, 318);
            this.lblEnderecoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnderecoTerapeuta.Name = "lblEnderecoTerapeuta";
            this.lblEnderecoTerapeuta.Size = new System.Drawing.Size(82, 20);
            this.lblEnderecoTerapeuta.TabIndex = 31;
            this.lblEnderecoTerapeuta.Text = "Endereço:";
            // 
            // txtEnderecoTerapeuta
            // 
            this.txtEnderecoTerapeuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtEnderecoTerapeuta.ForeColor = System.Drawing.Color.White;
            this.txtEnderecoTerapeuta.Location = new System.Drawing.Point(190, 315);
            this.txtEnderecoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnderecoTerapeuta.Multiline = true;
            this.txtEnderecoTerapeuta.Name = "txtEnderecoTerapeuta";
            this.txtEnderecoTerapeuta.Size = new System.Drawing.Size(340, 78);
            this.txtEnderecoTerapeuta.TabIndex = 6;
            // 
            // lblCRP
            // 
            this.lblCRP.AutoSize = true;
            this.lblCRP.ForeColor = System.Drawing.Color.White;
            this.lblCRP.Location = new System.Drawing.Point(129, 180);
            this.lblCRP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCRP.Name = "lblCRP";
            this.lblCRP.Size = new System.Drawing.Size(46, 20);
            this.lblCRP.TabIndex = 33;
            this.lblCRP.Text = "CRP:";
            // 
            // txtCRP
            // 
            this.txtCRP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtCRP.ForeColor = System.Drawing.Color.White;
            this.txtCRP.Location = new System.Drawing.Point(190, 179);
            this.txtCRP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCRP.MaxLength = 20;
            this.txtCRP.Name = "txtCRP";
            this.txtCRP.Size = new System.Drawing.Size(338, 26);
            this.txtCRP.TabIndex = 3;
            this.txtCRP.TextChanged += new System.EventHandler(this.txtCRP_TextChanged);
            // 
            // btnSelecionarConsultas
            // 
            this.btnSelecionarConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarConsultas.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarConsultas.Location = new System.Drawing.Point(198, 242);
            this.btnSelecionarConsultas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelecionarConsultas.Name = "btnSelecionarConsultas";
            this.btnSelecionarConsultas.Size = new System.Drawing.Size(201, 45);
            this.btnSelecionarConsultas.TabIndex = 7;
            this.btnSelecionarConsultas.Text = "Selecionar Consultas";
            this.btnSelecionarConsultas.UseVisualStyleBackColor = true;
            this.btnSelecionarConsultas.Click += new System.EventHandler(this.btnSelecionarConsultas_Click);
            // 
            // pnlConsultas
            // 
            this.pnlConsultas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConsultas.Controls.Add(this.lbDiaSemana);
            this.pnlConsultas.Controls.Add(this.lbMes);
            this.pnlConsultas.Controls.Add(this.cmbDiaSemana);
            this.pnlConsultas.Controls.Add(this.cmbMes);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta10);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta9);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta8);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta7);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta6);
            this.pnlConsultas.Controls.Add(this.btnSalvarConsultas);
            this.pnlConsultas.Controls.Add(this.lblNumeroDeConsultas);
            this.pnlConsultas.Controls.Add(this.numNumeroConsultas);
            this.pnlConsultas.Controls.Add(this.lblSelecioneDataConsultas);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta4);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta3);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta5);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta2);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta1);
            this.pnlConsultas.Location = new System.Drawing.Point(621, 45);
            this.pnlConsultas.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pnlConsultas.Name = "pnlConsultas";
            this.pnlConsultas.Size = new System.Drawing.Size(572, 902);
            this.pnlConsultas.TabIndex = 35;
            this.pnlConsultas.Visible = false;
            // 
            // lbDiaSemana
            // 
            this.lbDiaSemana.AutoSize = true;
            this.lbDiaSemana.ForeColor = System.Drawing.Color.White;
            this.lbDiaSemana.Location = new System.Drawing.Point(246, 19);
            this.lbDiaSemana.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDiaSemana.Name = "lbDiaSemana";
            this.lbDiaSemana.Size = new System.Drawing.Size(123, 20);
            this.lbDiaSemana.TabIndex = 48;
            this.lbDiaSemana.Text = "Dia da Semana:";
            // 
            // lbMes
            // 
            this.lbMes.AutoSize = true;
            this.lbMes.ForeColor = System.Drawing.Color.White;
            this.lbMes.Location = new System.Drawing.Point(15, 19);
            this.lbMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMes.Name = "lbMes";
            this.lbMes.Size = new System.Drawing.Size(43, 20);
            this.lbMes.TabIndex = 47;
            this.lbMes.Text = "Mes:";
            // 
            // cmbDiaSemana
            // 
            this.cmbDiaSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.cmbDiaSemana.DisplayMember = "Name";
            this.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaSemana.ForeColor = System.Drawing.Color.White;
            this.cmbDiaSemana.FormattingEnabled = true;
            this.cmbDiaSemana.Location = new System.Drawing.Point(377, 15);
            this.cmbDiaSemana.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDiaSemana.Name = "cmbDiaSemana";
            this.cmbDiaSemana.Size = new System.Drawing.Size(180, 28);
            this.cmbDiaSemana.TabIndex = 1;
            this.cmbDiaSemana.ValueMember = "Value";
            this.cmbDiaSemana.SelectedIndexChanged += new System.EventHandler(this.cmbDiaSemana_SelectedIndexChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.cmbMes.DisplayMember = "Name";
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.ForeColor = System.Drawing.Color.White;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(66, 15);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(169, 28);
            this.cmbMes.TabIndex = 0;
            this.cmbMes.ValueMember = "Value";
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // btnSalvarConsultas
            // 
            this.btnSalvarConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarConsultas.ForeColor = System.Drawing.Color.White;
            this.btnSalvarConsultas.Location = new System.Drawing.Point(174, 739);
            this.btnSalvarConsultas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvarConsultas.Name = "btnSalvarConsultas";
            this.btnSalvarConsultas.Size = new System.Drawing.Size(201, 45);
            this.btnSalvarConsultas.TabIndex = 13;
            this.btnSalvarConsultas.Text = "Salvar";
            this.btnSalvarConsultas.UseVisualStyleBackColor = true;
            this.btnSalvarConsultas.Click += new System.EventHandler(this.btnSalvarConsultas_Click);
            // 
            // lblNumeroDeConsultas
            // 
            this.lblNumeroDeConsultas.AutoSize = true;
            this.lblNumeroDeConsultas.ForeColor = System.Drawing.Color.White;
            this.lblNumeroDeConsultas.Location = new System.Drawing.Point(192, 81);
            this.lblNumeroDeConsultas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroDeConsultas.Name = "lblNumeroDeConsultas";
            this.lblNumeroDeConsultas.Size = new System.Drawing.Size(166, 20);
            this.lblNumeroDeConsultas.TabIndex = 39;
            this.lblNumeroDeConsultas.Text = "Número de Consultas:";
            // 
            // numNumeroConsultas
            // 
            this.numNumeroConsultas.Location = new System.Drawing.Point(363, 81);
            this.numNumeroConsultas.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.numNumeroConsultas.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNumeroConsultas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumeroConsultas.Name = "numNumeroConsultas";
            this.numNumeroConsultas.Size = new System.Drawing.Size(68, 26);
            this.numNumeroConsultas.TabIndex = 2;
            this.numNumeroConsultas.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNumeroConsultas.ValueChanged += new System.EventHandler(this.numNumeroConsultas_ValueChanged);
            // 
            // lblSelecioneDataConsultas
            // 
            this.lblSelecioneDataConsultas.AutoSize = true;
            this.lblSelecioneDataConsultas.ForeColor = System.Drawing.Color.White;
            this.lblSelecioneDataConsultas.Location = new System.Drawing.Point(195, 141);
            this.lblSelecioneDataConsultas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelecioneDataConsultas.Name = "lblSelecioneDataConsultas";
            this.lblSelecioneDataConsultas.Size = new System.Drawing.Size(229, 20);
            this.lblSelecioneDataConsultas.TabIndex = 37;
            this.lblSelecioneDataConsultas.Text = "Selecione datas das consultas:";
            // 
            // pnlRecibo
            // 
            this.pnlRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnlRecibo.Controls.Add(this.pnlDadosTerapeuta);
            this.pnlRecibo.Controls.Add(this.lblTituloGeracaoRecibo);
            this.pnlRecibo.Controls.Add(this.lnkAssinarPDF);
            this.pnlRecibo.Controls.Add(this.btnGerarRecibo);
            this.pnlRecibo.Controls.Add(this.pnlDadosPaciente);
            this.pnlRecibo.Location = new System.Drawing.Point(6, 45);
            this.pnlRecibo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pnlRecibo.Name = "pnlRecibo";
            this.pnlRecibo.Size = new System.Drawing.Size(602, 900);
            this.pnlRecibo.TabIndex = 36;
            // 
            // pnlDadosTerapeuta
            // 
            this.pnlDadosTerapeuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDadosTerapeuta.Controls.Add(this.lblCNPJTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.lbNomeEmpresa);
            this.pnlDadosTerapeuta.Controls.Add(this.gbTipoPessoa);
            this.pnlDadosTerapeuta.Controls.Add(this.lbDadosTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.lblCidade);
            this.pnlDadosTerapeuta.Controls.Add(this.txtCidade);
            this.pnlDadosTerapeuta.Controls.Add(this.lblCEP);
            this.pnlDadosTerapeuta.Controls.Add(this.txtNomeDoTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.txtCEP);
            this.pnlDadosTerapeuta.Controls.Add(this.lblNomeDoTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.txtCPFTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.lblCPFTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.txtEnderecoTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.lblEnderecoTerapeuta);
            this.pnlDadosTerapeuta.Controls.Add(this.lblCRP);
            this.pnlDadosTerapeuta.Controls.Add(this.txtCRP);
            this.pnlDadosTerapeuta.Location = new System.Drawing.Point(19, 381);
            this.pnlDadosTerapeuta.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosTerapeuta.Name = "pnlDadosTerapeuta";
            this.pnlDadosTerapeuta.Size = new System.Drawing.Size(569, 424);
            this.pnlDadosTerapeuta.TabIndex = 2;
            // 
            // lblCNPJTerapeuta
            // 
            this.lblCNPJTerapeuta.AutoSize = true;
            this.lblCNPJTerapeuta.ForeColor = System.Drawing.Color.White;
            this.lblCNPJTerapeuta.Location = new System.Drawing.Point(120, 139);
            this.lblCNPJTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCNPJTerapeuta.Name = "lblCNPJTerapeuta";
            this.lblCNPJTerapeuta.Size = new System.Drawing.Size(53, 20);
            this.lblCNPJTerapeuta.TabIndex = 46;
            this.lblCNPJTerapeuta.Text = "CNPJ:";
            this.lblCNPJTerapeuta.Visible = false;
            // 
            // lbNomeEmpresa
            // 
            this.lbNomeEmpresa.AutoSize = true;
            this.lbNomeEmpresa.ForeColor = System.Drawing.Color.White;
            this.lbNomeEmpresa.Location = new System.Drawing.Point(53, 92);
            this.lbNomeEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNomeEmpresa.Name = "lbNomeEmpresa";
            this.lbNomeEmpresa.Size = new System.Drawing.Size(123, 20);
            this.lbNomeEmpresa.TabIndex = 45;
            this.lbNomeEmpresa.Text = "Nome Empresa:";
            this.lbNomeEmpresa.Visible = false;
            // 
            // gbTipoPessoa
            // 
            this.gbTipoPessoa.Controls.Add(this.rbFisica);
            this.gbTipoPessoa.Controls.Add(this.rbJuridica);
            this.gbTipoPessoa.ForeColor = System.Drawing.Color.White;
            this.gbTipoPessoa.Location = new System.Drawing.Point(190, 9);
            this.gbTipoPessoa.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gbTipoPessoa.Name = "gbTipoPessoa";
            this.gbTipoPessoa.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.gbTipoPessoa.Size = new System.Drawing.Size(240, 69);
            this.gbTipoPessoa.TabIndex = 0;
            this.gbTipoPessoa.TabStop = false;
            this.gbTipoPessoa.Text = "Tipo de Pessoa:";
            // 
            // rbFisica
            // 
            this.rbFisica.AutoSize = true;
            this.rbFisica.Checked = true;
            this.rbFisica.ForeColor = System.Drawing.Color.White;
            this.rbFisica.Location = new System.Drawing.Point(24, 32);
            this.rbFisica.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.rbFisica.Name = "rbFisica";
            this.rbFisica.Size = new System.Drawing.Size(75, 24);
            this.rbFisica.TabIndex = 0;
            this.rbFisica.TabStop = true;
            this.rbFisica.Text = "Física";
            this.rbFisica.UseVisualStyleBackColor = true;
            this.rbFisica.CheckedChanged += new System.EventHandler(this.rbFisica_CheckedChanged);
            // 
            // rbJuridica
            // 
            this.rbJuridica.AutoSize = true;
            this.rbJuridica.ForeColor = System.Drawing.Color.White;
            this.rbJuridica.Location = new System.Drawing.Point(105, 32);
            this.rbJuridica.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.rbJuridica.Name = "rbJuridica";
            this.rbJuridica.Size = new System.Drawing.Size(88, 24);
            this.rbJuridica.TabIndex = 1;
            this.rbJuridica.Text = "Juridica";
            this.rbJuridica.UseVisualStyleBackColor = true;
            this.rbJuridica.CheckedChanged += new System.EventHandler(this.rbJuridica_CheckedChanged);
            // 
            // lbDadosTerapeuta
            // 
            this.lbDadosTerapeuta.AutoSize = true;
            this.lbDadosTerapeuta.ForeColor = System.Drawing.Color.White;
            this.lbDadosTerapeuta.Location = new System.Drawing.Point(9, 9);
            this.lbDadosTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDadosTerapeuta.Name = "lbDadosTerapeuta";
            this.lbDadosTerapeuta.Size = new System.Drawing.Size(137, 20);
            this.lbDadosTerapeuta.TabIndex = 43;
            this.lbDadosTerapeuta.Text = "Dados Terapeuta:";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.ForeColor = System.Drawing.Color.White;
            this.lblCidade.Location = new System.Drawing.Point(111, 268);
            this.lblCidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(63, 20);
            this.lblCidade.TabIndex = 14;
            this.lblCidade.Text = "Cidade:";
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtCidade.ForeColor = System.Drawing.Color.White;
            this.txtCidade.Location = new System.Drawing.Point(189, 268);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCidade.MaxLength = 32;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(342, 26);
            this.txtCidade.TabIndex = 5;
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.ForeColor = System.Drawing.Color.White;
            this.lblCEP.Location = new System.Drawing.Point(129, 225);
            this.lblCEP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(45, 20);
            this.lblCEP.TabIndex = 36;
            this.lblCEP.Text = "CEP:";
            // 
            // txtCEP
            // 
            this.txtCEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtCEP.ForeColor = System.Drawing.Color.White;
            this.txtCEP.Location = new System.Drawing.Point(190, 225);
            this.txtCEP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCEP.MaxLength = 12;
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(338, 26);
            this.txtCEP.TabIndex = 4;
            this.txtCEP.TextChanged += new System.EventHandler(this.txtCEP_TextChanged);
            // 
            // lblTituloGeracaoRecibo
            // 
            this.lblTituloGeracaoRecibo.AutoSize = true;
            this.lblTituloGeracaoRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGeracaoRecibo.ForeColor = System.Drawing.Color.White;
            this.lblTituloGeracaoRecibo.Location = new System.Drawing.Point(192, 11);
            this.lblTituloGeracaoRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloGeracaoRecibo.Name = "lblTituloGeracaoRecibo";
            this.lblTituloGeracaoRecibo.Size = new System.Drawing.Size(239, 20);
            this.lblTituloGeracaoRecibo.TabIndex = 44;
            this.lblTituloGeracaoRecibo.Text = "Geração de Recibo Terapia";
            // 
            // pnlDadosPaciente
            // 
            this.pnlDadosPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDadosPaciente.Controls.Add(this.btnNovoPaciente);
            this.pnlDadosPaciente.Controls.Add(this.btnExcluirPaciente);
            this.pnlDadosPaciente.Controls.Add(this.btnSalvarPaciente);
            this.pnlDadosPaciente.Controls.Add(this.cmbNomePaciente);
            this.pnlDadosPaciente.Controls.Add(this.lbDadosPaciente);
            this.pnlDadosPaciente.Controls.Add(this.lblNomeDoPaciente);
            this.pnlDadosPaciente.Controls.Add(this.txtReferenteA);
            this.pnlDadosPaciente.Controls.Add(this.lblCPFPaciente);
            this.pnlDadosPaciente.Controls.Add(this.txtCPFPaciente);
            this.pnlDadosPaciente.Controls.Add(this.btnSelecionarConsultas);
            this.pnlDadosPaciente.Controls.Add(this.lblReferenteA);
            this.pnlDadosPaciente.Controls.Add(this.lblValorTotal);
            this.pnlDadosPaciente.Controls.Add(this.txtValorConsulta);
            this.pnlDadosPaciente.Location = new System.Drawing.Point(19, 46);
            this.pnlDadosPaciente.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosPaciente.Name = "pnlDadosPaciente";
            this.pnlDadosPaciente.Size = new System.Drawing.Size(564, 311);
            this.pnlDadosPaciente.TabIndex = 1;
            // 
            // btnNovoPaciente
            // 
            this.btnNovoPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoPaciente.ForeColor = System.Drawing.Color.White;
            this.btnNovoPaciente.Location = new System.Drawing.Point(294, 89);
            this.btnNovoPaciente.Margin = new System.Windows.Forms.Padding(1);
            this.btnNovoPaciente.Name = "btnNovoPaciente";
            this.btnNovoPaciente.Size = new System.Drawing.Size(71, 42);
            this.btnNovoPaciente.TabIndex = 2;
            this.btnNovoPaciente.Text = "Novo";
            this.btnNovoPaciente.UseVisualStyleBackColor = true;
            this.btnNovoPaciente.Click += new System.EventHandler(this.btnNovoPaciente_Click);
            // 
            // btnExcluirPaciente
            // 
            this.btnExcluirPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirPaciente.ForeColor = System.Drawing.Color.White;
            this.btnExcluirPaciente.Location = new System.Drawing.Point(444, 89);
            this.btnExcluirPaciente.Margin = new System.Windows.Forms.Padding(1);
            this.btnExcluirPaciente.Name = "btnExcluirPaciente";
            this.btnExcluirPaciente.Size = new System.Drawing.Size(81, 42);
            this.btnExcluirPaciente.TabIndex = 4;
            this.btnExcluirPaciente.Text = "Excluir";
            this.btnExcluirPaciente.UseVisualStyleBackColor = true;
            this.btnExcluirPaciente.Click += new System.EventHandler(this.btnExcluirPaciente_Click);
            // 
            // btnSalvarPaciente
            // 
            this.btnSalvarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarPaciente.ForeColor = System.Drawing.Color.White;
            this.btnSalvarPaciente.Location = new System.Drawing.Point(369, 89);
            this.btnSalvarPaciente.Margin = new System.Windows.Forms.Padding(1);
            this.btnSalvarPaciente.Name = "btnSalvarPaciente";
            this.btnSalvarPaciente.Size = new System.Drawing.Size(72, 42);
            this.btnSalvarPaciente.TabIndex = 3;
            this.btnSalvarPaciente.Text = "Salvar";
            this.btnSalvarPaciente.UseVisualStyleBackColor = true;
            this.btnSalvarPaciente.Click += new System.EventHandler(this.btnSalvarPaciente_Click);
            // 
            // cmbNomePaciente
            // 
            this.cmbNomePaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.cmbNomePaciente.ForeColor = System.Drawing.Color.White;
            this.cmbNomePaciente.FormattingEnabled = true;
            this.cmbNomePaciente.Location = new System.Drawing.Point(195, 54);
            this.cmbNomePaciente.Margin = new System.Windows.Forms.Padding(1);
            this.cmbNomePaciente.Name = "cmbNomePaciente";
            this.cmbNomePaciente.Size = new System.Drawing.Size(328, 28);
            this.cmbNomePaciente.TabIndex = 0;
            this.cmbNomePaciente.SelectedIndexChanged += new System.EventHandler(this.cmbNomePaciente_SelectedIndexChanged);
            this.cmbNomePaciente.TextChanged += new System.EventHandler(this.cmbNomePaciente_TextChanged);
            this.cmbNomePaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbNomePaciente_KeyPress);
            // 
            // lbDadosPaciente
            // 
            this.lbDadosPaciente.AutoSize = true;
            this.lbDadosPaciente.ForeColor = System.Drawing.Color.White;
            this.lbDadosPaciente.Location = new System.Drawing.Point(9, 11);
            this.lbDadosPaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDadosPaciente.Name = "lbDadosPaciente";
            this.lbDadosPaciente.Size = new System.Drawing.Size(122, 20);
            this.lbDadosPaciente.TabIndex = 44;
            this.lbDadosPaciente.Text = "Dados Paciente";
            // 
            // pnlReembolso
            // 
            this.pnlReembolso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnlReembolso.Controls.Add(this.lnkUnimedLogin);
            this.pnlReembolso.Controls.Add(this.lblTituloSolicitacaoReembolso);
            this.pnlReembolso.Controls.Add(this.btnGerarSolicitacaoReembolso);
            this.pnlReembolso.Controls.Add(this.pnlDadosReembolso);
            this.pnlReembolso.Controls.Add(this.pnlDadosBancarios);
            this.pnlReembolso.Location = new System.Drawing.Point(621, 45);
            this.pnlReembolso.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pnlReembolso.Name = "pnlReembolso";
            this.pnlReembolso.Size = new System.Drawing.Size(572, 900);
            this.pnlReembolso.TabIndex = 37;
            // 
            // lnkUnimedLogin
            // 
            this.lnkUnimedLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lnkUnimedLogin.Location = new System.Drawing.Point(505, 11);
            this.lnkUnimedLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkUnimedLogin.Name = "lnkUnimedLogin";
            this.lnkUnimedLogin.Size = new System.Drawing.Size(55, 29);
            this.lnkUnimedLogin.TabIndex = 50;
            this.lnkUnimedLogin.TabStop = true;
            this.lnkUnimedLogin.Text = "Login";
            this.lnkUnimedLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUnimedLogin_LinkClicked);
            // 
            // lblTituloSolicitacaoReembolso
            // 
            this.lblTituloSolicitacaoReembolso.AutoSize = true;
            this.lblTituloSolicitacaoReembolso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSolicitacaoReembolso.ForeColor = System.Drawing.Color.White;
            this.lblTituloSolicitacaoReembolso.Location = new System.Drawing.Point(144, 11);
            this.lblTituloSolicitacaoReembolso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloSolicitacaoReembolso.Name = "lblTituloSolicitacaoReembolso";
            this.lblTituloSolicitacaoReembolso.Size = new System.Drawing.Size(296, 20);
            this.lblTituloSolicitacaoReembolso.TabIndex = 43;
            this.lblTituloSolicitacaoReembolso.Text = "Solicitação de Reembolso Unimed";
            // 
            // btnGerarSolicitacaoReembolso
            // 
            this.btnGerarSolicitacaoReembolso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarSolicitacaoReembolso.ForeColor = System.Drawing.Color.White;
            this.btnGerarSolicitacaoReembolso.Location = new System.Drawing.Point(177, 829);
            this.btnGerarSolicitacaoReembolso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGerarSolicitacaoReembolso.Name = "btnGerarSolicitacaoReembolso";
            this.btnGerarSolicitacaoReembolso.Size = new System.Drawing.Size(201, 62);
            this.btnGerarSolicitacaoReembolso.TabIndex = 3;
            this.btnGerarSolicitacaoReembolso.Text = "Gerar solicitação de reembolso";
            this.btnGerarSolicitacaoReembolso.UseVisualStyleBackColor = true;
            this.btnGerarSolicitacaoReembolso.Click += new System.EventHandler(this.btnGerarSolicitacaoReembolso_Click);
            // 
            // pnlDadosReembolso
            // 
            this.pnlDadosReembolso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnlDadosReembolso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDadosReembolso.Controls.Add(this.btnMostraDadosUnimedAcre);
            this.pnlDadosReembolso.Controls.Add(this.lbDadosReembolso);
            this.pnlDadosReembolso.Controls.Add(this.lblLoginUnimed);
            this.pnlDadosReembolso.Controls.Add(this.btnSelecionarPDFRecibo);
            this.pnlDadosReembolso.Controls.Add(this.lblReciboConsulta);
            this.pnlDadosReembolso.Controls.Add(this.txtLoginUnimed);
            this.pnlDadosReembolso.Controls.Add(this.grbTipoAtendimento);
            this.pnlDadosReembolso.Controls.Add(this.lblNomeArquivoRecibo);
            this.pnlDadosReembolso.Controls.Add(this.txtSenhaUnimed);
            this.pnlDadosReembolso.Controls.Add(this.lblSenhaUnimed);
            this.pnlDadosReembolso.Location = new System.Drawing.Point(22, 46);
            this.pnlDadosReembolso.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosReembolso.Name = "pnlDadosReembolso";
            this.pnlDadosReembolso.Size = new System.Drawing.Size(528, 422);
            this.pnlDadosReembolso.TabIndex = 1;
            // 
            // btnMostraDadosUnimedAcre
            // 
            this.btnMostraDadosUnimedAcre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostraDadosUnimedAcre.ForeColor = System.Drawing.Color.White;
            this.btnMostraDadosUnimedAcre.Location = new System.Drawing.Point(271, 310);
            this.btnMostraDadosUnimedAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMostraDadosUnimedAcre.Name = "btnMostraDadosUnimedAcre";
            this.btnMostraDadosUnimedAcre.Size = new System.Drawing.Size(201, 45);
            this.btnMostraDadosUnimedAcre.TabIndex = 49;
            this.btnMostraDadosUnimedAcre.Text = "Dados Unimed Acre";
            this.btnMostraDadosUnimedAcre.UseVisualStyleBackColor = true;
            this.btnMostraDadosUnimedAcre.Click += new System.EventHandler(this.btnMostraDadosUnimedAcre_Click);
            // 
            // lbDadosReembolso
            // 
            this.lbDadosReembolso.AutoSize = true;
            this.lbDadosReembolso.ForeColor = System.Drawing.Color.White;
            this.lbDadosReembolso.Location = new System.Drawing.Point(12, 11);
            this.lbDadosReembolso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDadosReembolso.Name = "lbDadosReembolso";
            this.lbDadosReembolso.Size = new System.Drawing.Size(145, 20);
            this.lbDadosReembolso.TabIndex = 48;
            this.lbDadosReembolso.Text = "Dados Reembolso:";
            // 
            // lblLoginUnimed
            // 
            this.lblLoginUnimed.AutoSize = true;
            this.lblLoginUnimed.ForeColor = System.Drawing.Color.White;
            this.lblLoginUnimed.Location = new System.Drawing.Point(15, 74);
            this.lblLoginUnimed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoginUnimed.Name = "lblLoginUnimed";
            this.lblLoginUnimed.Size = new System.Drawing.Size(156, 20);
            this.lblLoginUnimed.TabIndex = 47;
            this.lblLoginUnimed.Text = "Login Unimed (CPF):";
            // 
            // txtLoginUnimed
            // 
            this.txtLoginUnimed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtLoginUnimed.ForeColor = System.Drawing.Color.White;
            this.txtLoginUnimed.Location = new System.Drawing.Point(179, 74);
            this.txtLoginUnimed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLoginUnimed.MaxLength = 16;
            this.txtLoginUnimed.Name = "txtLoginUnimed";
            this.txtLoginUnimed.Size = new System.Drawing.Size(316, 26);
            this.txtLoginUnimed.TabIndex = 0;
            this.txtLoginUnimed.TextChanged += new System.EventHandler(this.txtLoginUnimed_TextChanged);
            // 
            // grbTipoAtendimento
            // 
            this.grbTipoAtendimento.Controls.Add(this.rbPresencial);
            this.grbTipoAtendimento.Controls.Add(this.rbTelemedicina);
            this.grbTipoAtendimento.ForeColor = System.Drawing.Color.White;
            this.grbTipoAtendimento.Location = new System.Drawing.Point(27, 266);
            this.grbTipoAtendimento.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.grbTipoAtendimento.Name = "grbTipoAtendimento";
            this.grbTipoAtendimento.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.grbTipoAtendimento.Size = new System.Drawing.Size(207, 126);
            this.grbTipoAtendimento.TabIndex = 42;
            this.grbTipoAtendimento.TabStop = false;
            this.grbTipoAtendimento.Text = "Tipo de Atendimento:";
            // 
            // rbPresencial
            // 
            this.rbPresencial.AutoSize = true;
            this.rbPresencial.ForeColor = System.Drawing.Color.White;
            this.rbPresencial.Location = new System.Drawing.Point(24, 38);
            this.rbPresencial.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.rbPresencial.Name = "rbPresencial";
            this.rbPresencial.Size = new System.Drawing.Size(107, 24);
            this.rbPresencial.TabIndex = 0;
            this.rbPresencial.Text = "Presencial";
            this.rbPresencial.UseVisualStyleBackColor = true;
            // 
            // rbTelemedicina
            // 
            this.rbTelemedicina.AutoSize = true;
            this.rbTelemedicina.Checked = true;
            this.rbTelemedicina.ForeColor = System.Drawing.Color.White;
            this.rbTelemedicina.Location = new System.Drawing.Point(24, 78);
            this.rbTelemedicina.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.rbTelemedicina.Name = "rbTelemedicina";
            this.rbTelemedicina.Size = new System.Drawing.Size(127, 24);
            this.rbTelemedicina.TabIndex = 1;
            this.rbTelemedicina.TabStop = true;
            this.rbTelemedicina.Text = "Telemedicina";
            this.rbTelemedicina.UseVisualStyleBackColor = true;
            // 
            // txtSenhaUnimed
            // 
            this.txtSenhaUnimed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtSenhaUnimed.ForeColor = System.Drawing.Color.White;
            this.txtSenhaUnimed.Location = new System.Drawing.Point(179, 126);
            this.txtSenhaUnimed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSenhaUnimed.MaxLength = 32;
            this.txtSenhaUnimed.Name = "txtSenhaUnimed";
            this.txtSenhaUnimed.PasswordChar = '*';
            this.txtSenhaUnimed.Size = new System.Drawing.Size(316, 26);
            this.txtSenhaUnimed.TabIndex = 1;
            // 
            // lblSenhaUnimed
            // 
            this.lblSenhaUnimed.AutoSize = true;
            this.lblSenhaUnimed.ForeColor = System.Drawing.Color.White;
            this.lblSenhaUnimed.Location = new System.Drawing.Point(45, 128);
            this.lblSenhaUnimed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenhaUnimed.Name = "lblSenhaUnimed";
            this.lblSenhaUnimed.Size = new System.Drawing.Size(119, 20);
            this.lblSenhaUnimed.TabIndex = 45;
            this.lblSenhaUnimed.Text = "Senha Unimed:";
            // 
            // pnlDadosBancarios
            // 
            this.pnlDadosBancarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDadosBancarios.Controls.Add(this.lbDadosBancarios);
            this.pnlDadosBancarios.Controls.Add(this.lblNomeDoBanco);
            this.pnlDadosBancarios.Controls.Add(this.lblDigitoDaConta);
            this.pnlDadosBancarios.Controls.Add(this.txtNomeDoBanco);
            this.pnlDadosBancarios.Controls.Add(this.txtDigitoDaConta);
            this.pnlDadosBancarios.Controls.Add(this.txtAgenciaSemDigito);
            this.pnlDadosBancarios.Controls.Add(this.lblContaSemDigito);
            this.pnlDadosBancarios.Controls.Add(this.txtContaSemDigito);
            this.pnlDadosBancarios.Controls.Add(this.lblAgenciaSemDigito);
            this.pnlDadosBancarios.Location = new System.Drawing.Point(22, 494);
            this.pnlDadosBancarios.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosBancarios.Name = "pnlDadosBancarios";
            this.pnlDadosBancarios.Size = new System.Drawing.Size(528, 313);
            this.pnlDadosBancarios.TabIndex = 2;
            // 
            // lbDadosBancarios
            // 
            this.lbDadosBancarios.AutoSize = true;
            this.lbDadosBancarios.ForeColor = System.Drawing.Color.White;
            this.lbDadosBancarios.Location = new System.Drawing.Point(9, 15);
            this.lbDadosBancarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDadosBancarios.Name = "lbDadosBancarios";
            this.lbDadosBancarios.Size = new System.Drawing.Size(135, 20);
            this.lbDadosBancarios.TabIndex = 42;
            this.lbDadosBancarios.Text = "Dados Bancários:";
            // 
            // lblNomeDoBanco
            // 
            this.lblNomeDoBanco.AutoSize = true;
            this.lblNomeDoBanco.ForeColor = System.Drawing.Color.White;
            this.lblNomeDoBanco.Location = new System.Drawing.Point(36, 85);
            this.lblNomeDoBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeDoBanco.Name = "lblNomeDoBanco";
            this.lblNomeDoBanco.Size = new System.Drawing.Size(127, 20);
            this.lblNomeDoBanco.TabIndex = 35;
            this.lblNomeDoBanco.Text = "Nome do Banco:";
            // 
            // lblDigitoDaConta
            // 
            this.lblDigitoDaConta.AutoSize = true;
            this.lblDigitoDaConta.ForeColor = System.Drawing.Color.White;
            this.lblDigitoDaConta.Location = new System.Drawing.Point(45, 241);
            this.lblDigitoDaConta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDigitoDaConta.Name = "lblDigitoDaConta";
            this.lblDigitoDaConta.Size = new System.Drawing.Size(120, 20);
            this.lblDigitoDaConta.TabIndex = 41;
            this.lblDigitoDaConta.Text = "Dígito da conta:";
            // 
            // txtNomeDoBanco
            // 
            this.txtNomeDoBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtNomeDoBanco.ForeColor = System.Drawing.Color.White;
            this.txtNomeDoBanco.Location = new System.Drawing.Point(171, 81);
            this.txtNomeDoBanco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeDoBanco.MaxLength = 32;
            this.txtNomeDoBanco.Name = "txtNomeDoBanco";
            this.txtNomeDoBanco.Size = new System.Drawing.Size(316, 26);
            this.txtNomeDoBanco.TabIndex = 0;
            // 
            // txtDigitoDaConta
            // 
            this.txtDigitoDaConta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtDigitoDaConta.ForeColor = System.Drawing.Color.White;
            this.txtDigitoDaConta.Location = new System.Drawing.Point(172, 241);
            this.txtDigitoDaConta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDigitoDaConta.MaxLength = 32;
            this.txtDigitoDaConta.Name = "txtDigitoDaConta";
            this.txtDigitoDaConta.Size = new System.Drawing.Size(316, 26);
            this.txtDigitoDaConta.TabIndex = 3;
            this.txtDigitoDaConta.TextChanged += new System.EventHandler(this.txtDigitoDaConta_TextChanged);
            // 
            // txtAgenciaSemDigito
            // 
            this.txtAgenciaSemDigito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtAgenciaSemDigito.ForeColor = System.Drawing.Color.White;
            this.txtAgenciaSemDigito.Location = new System.Drawing.Point(172, 135);
            this.txtAgenciaSemDigito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAgenciaSemDigito.MaxLength = 32;
            this.txtAgenciaSemDigito.Name = "txtAgenciaSemDigito";
            this.txtAgenciaSemDigito.Size = new System.Drawing.Size(316, 26);
            this.txtAgenciaSemDigito.TabIndex = 1;
            this.txtAgenciaSemDigito.TextChanged += new System.EventHandler(this.txtAgenciaSemDigito_TextChanged);
            // 
            // lblContaSemDigito
            // 
            this.lblContaSemDigito.AutoSize = true;
            this.lblContaSemDigito.ForeColor = System.Drawing.Color.White;
            this.lblContaSemDigito.Location = new System.Drawing.Point(34, 192);
            this.lblContaSemDigito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContaSemDigito.Name = "lblContaSemDigito";
            this.lblContaSemDigito.Size = new System.Drawing.Size(132, 20);
            this.lblContaSemDigito.TabIndex = 39;
            this.lblContaSemDigito.Text = "Conta sem dígito:";
            // 
            // txtContaSemDigito
            // 
            this.txtContaSemDigito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtContaSemDigito.ForeColor = System.Drawing.Color.White;
            this.txtContaSemDigito.Location = new System.Drawing.Point(171, 188);
            this.txtContaSemDigito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContaSemDigito.MaxLength = 32;
            this.txtContaSemDigito.Name = "txtContaSemDigito";
            this.txtContaSemDigito.Size = new System.Drawing.Size(316, 26);
            this.txtContaSemDigito.TabIndex = 2;
            this.txtContaSemDigito.TextChanged += new System.EventHandler(this.txtContaSemDigito_TextChanged);
            // 
            // lblAgenciaSemDigito
            // 
            this.lblAgenciaSemDigito.AutoSize = true;
            this.lblAgenciaSemDigito.ForeColor = System.Drawing.Color.White;
            this.lblAgenciaSemDigito.Location = new System.Drawing.Point(17, 135);
            this.lblAgenciaSemDigito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgenciaSemDigito.Name = "lblAgenciaSemDigito";
            this.lblAgenciaSemDigito.Size = new System.Drawing.Size(147, 20);
            this.lblAgenciaSemDigito.TabIndex = 37;
            this.lblAgenciaSemDigito.Text = "Agência sem dígito:";
            // 
            // pnlUnimedAcre
            // 
            this.pnlUnimedAcre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUnimedAcre.Controls.Add(this.label1);
            this.pnlUnimedAcre.Controls.Add(this.txtObservacoes);
            this.pnlUnimedAcre.Controls.Add(this.lbDataRecibo);
            this.pnlUnimedAcre.Controls.Add(this.dtDataRecibo);
            this.pnlUnimedAcre.Controls.Add(this.lblEstado);
            this.pnlUnimedAcre.Controls.Add(this.txtEstadoAcre);
            this.pnlUnimedAcre.Controls.Add(this.lblNomeArquivoIdentidade);
            this.pnlUnimedAcre.Controls.Add(this.lblNomeArquivoCarteirinha);
            this.pnlUnimedAcre.Controls.Add(this.lblBairro);
            this.pnlUnimedAcre.Controls.Add(this.txtEnderecoBairroAcre);
            this.pnlUnimedAcre.Controls.Add(this.lblComplemento);
            this.pnlUnimedAcre.Controls.Add(this.txtEnderecoComplementoAcre);
            this.pnlUnimedAcre.Controls.Add(this.btnSalvarDadosAcre);
            this.pnlUnimedAcre.Controls.Add(this.btnSelecionarPDFIdentidade);
            this.pnlUnimedAcre.Controls.Add(this.lblIdentidade);
            this.pnlUnimedAcre.Controls.Add(this.btnSelecionarPDFCarteirinha);
            this.pnlUnimedAcre.Controls.Add(this.lblCarteirinha);
            this.pnlUnimedAcre.Controls.Add(this.lblDadosUnimedAcre);
            this.pnlUnimedAcre.Controls.Add(this.lblNumeroCarteirinha);
            this.pnlUnimedAcre.Controls.Add(this.lblNumero);
            this.pnlUnimedAcre.Controls.Add(this.txtLoginUnimedAcre);
            this.pnlUnimedAcre.Controls.Add(this.txtEnderecoNumeroAcre);
            this.pnlUnimedAcre.Controls.Add(this.txtNomeBancoAcre);
            this.pnlUnimedAcre.Controls.Add(this.lblRua);
            this.pnlUnimedAcre.Controls.Add(this.txtEnderecoRuaAcre);
            this.pnlUnimedAcre.Controls.Add(this.lblNomeBancoAcre);
            this.pnlUnimedAcre.Location = new System.Drawing.Point(25, 45);
            this.pnlUnimedAcre.Margin = new System.Windows.Forms.Padding(1);
            this.pnlUnimedAcre.Name = "pnlUnimedAcre";
            this.pnlUnimedAcre.Size = new System.Drawing.Size(1168, 900);
            this.pnlUnimedAcre.TabIndex = 43;
            this.pnlUnimedAcre.Visible = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(210, 558);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 56);
            this.label1.TabIndex = 61;
            this.label1.Text = "Observações / Justificativa:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtObservacoes.ForeColor = System.Drawing.Color.White;
            this.txtObservacoes.Location = new System.Drawing.Point(418, 558);
            this.txtObservacoes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtObservacoes.MaxLength = 2000;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(641, 142);
            this.txtObservacoes.TabIndex = 60;
            // 
            // lbDataRecibo
            // 
            this.lbDataRecibo.AutoSize = true;
            this.lbDataRecibo.ForeColor = System.Drawing.Color.White;
            this.lbDataRecibo.Location = new System.Drawing.Point(62, 198);
            this.lbDataRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDataRecibo.Name = "lbDataRecibo";
            this.lbDataRecibo.Size = new System.Drawing.Size(102, 20);
            this.lbDataRecibo.TabIndex = 59;
            this.lbDataRecibo.Text = "Data Recibo:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(665, 312);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 20);
            this.lblEstado.TabIndex = 57;
            this.lblEstado.Text = "Estado:";
            // 
            // txtEstadoAcre
            // 
            this.txtEstadoAcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtEstadoAcre.ForeColor = System.Drawing.Color.White;
            this.txtEstadoAcre.Location = new System.Drawing.Point(742, 315);
            this.txtEstadoAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEstadoAcre.MaxLength = 32;
            this.txtEstadoAcre.Name = "txtEstadoAcre";
            this.txtEstadoAcre.Size = new System.Drawing.Size(316, 26);
            this.txtEstadoAcre.TabIndex = 56;
            // 
            // lblNomeArquivoIdentidade
            // 
            this.lblNomeArquivoIdentidade.AutoEllipsis = true;
            this.lblNomeArquivoIdentidade.ForeColor = System.Drawing.Color.White;
            this.lblNomeArquivoIdentidade.Location = new System.Drawing.Point(264, 486);
            this.lblNomeArquivoIdentidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeArquivoIdentidade.Name = "lblNomeArquivoIdentidade";
            this.lblNomeArquivoIdentidade.Size = new System.Drawing.Size(809, 24);
            this.lblNomeArquivoIdentidade.TabIndex = 53;
            // 
            // lblNomeArquivoCarteirinha
            // 
            this.lblNomeArquivoCarteirinha.AutoEllipsis = true;
            this.lblNomeArquivoCarteirinha.ForeColor = System.Drawing.Color.White;
            this.lblNomeArquivoCarteirinha.Location = new System.Drawing.Point(264, 382);
            this.lblNomeArquivoCarteirinha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeArquivoCarteirinha.Name = "lblNomeArquivoCarteirinha";
            this.lblNomeArquivoCarteirinha.Size = new System.Drawing.Size(795, 24);
            this.lblNomeArquivoCarteirinha.TabIndex = 52;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.ForeColor = System.Drawing.Color.White;
            this.lblBairro.Location = new System.Drawing.Point(680, 249);
            this.lblBairro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(55, 20);
            this.lblBairro.TabIndex = 51;
            this.lblBairro.Text = "Bairro:";
            // 
            // txtEnderecoBairroAcre
            // 
            this.txtEnderecoBairroAcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtEnderecoBairroAcre.ForeColor = System.Drawing.Color.White;
            this.txtEnderecoBairroAcre.Location = new System.Drawing.Point(742, 252);
            this.txtEnderecoBairroAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnderecoBairroAcre.MaxLength = 32;
            this.txtEnderecoBairroAcre.Name = "txtEnderecoBairroAcre";
            this.txtEnderecoBairroAcre.Size = new System.Drawing.Size(316, 26);
            this.txtEnderecoBairroAcre.TabIndex = 5;
            // 
            // lblComplemento
            // 
            this.lblComplemento.AutoSize = true;
            this.lblComplemento.ForeColor = System.Drawing.Color.White;
            this.lblComplemento.Location = new System.Drawing.Point(623, 191);
            this.lblComplemento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(112, 20);
            this.lblComplemento.TabIndex = 49;
            this.lblComplemento.Text = "Complemento:";
            // 
            // txtEnderecoComplementoAcre
            // 
            this.txtEnderecoComplementoAcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtEnderecoComplementoAcre.ForeColor = System.Drawing.Color.White;
            this.txtEnderecoComplementoAcre.Location = new System.Drawing.Point(742, 192);
            this.txtEnderecoComplementoAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnderecoComplementoAcre.MaxLength = 32;
            this.txtEnderecoComplementoAcre.Name = "txtEnderecoComplementoAcre";
            this.txtEnderecoComplementoAcre.Size = new System.Drawing.Size(316, 26);
            this.txtEnderecoComplementoAcre.TabIndex = 4;
            // 
            // btnSalvarDadosAcre
            // 
            this.btnSalvarDadosAcre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarDadosAcre.ForeColor = System.Drawing.Color.White;
            this.btnSalvarDadosAcre.Location = new System.Drawing.Point(461, 786);
            this.btnSalvarDadosAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvarDadosAcre.Name = "btnSalvarDadosAcre";
            this.btnSalvarDadosAcre.Size = new System.Drawing.Size(201, 45);
            this.btnSalvarDadosAcre.TabIndex = 8;
            this.btnSalvarDadosAcre.Text = "Salvar";
            this.btnSalvarDadosAcre.UseVisualStyleBackColor = true;
            this.btnSalvarDadosAcre.Click += new System.EventHandler(this.btnSalvarDadosAcre_Click);
            // 
            // btnSelecionarPDFIdentidade
            // 
            this.btnSelecionarPDFIdentidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarPDFIdentidade.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarPDFIdentidade.Location = new System.Drawing.Point(264, 438);
            this.btnSelecionarPDFIdentidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelecionarPDFIdentidade.Name = "btnSelecionarPDFIdentidade";
            this.btnSelecionarPDFIdentidade.Size = new System.Drawing.Size(224, 35);
            this.btnSelecionarPDFIdentidade.TabIndex = 7;
            this.btnSelecionarPDFIdentidade.Text = "Selecionar PDF Identidade";
            this.btnSelecionarPDFIdentidade.UseVisualStyleBackColor = true;
            this.btnSelecionarPDFIdentidade.Click += new System.EventHandler(this.btnSelecionarPDFIdentidade_Click);
            // 
            // lblIdentidade
            // 
            this.lblIdentidade.AutoSize = true;
            this.lblIdentidade.ForeColor = System.Drawing.Color.White;
            this.lblIdentidade.Location = new System.Drawing.Point(152, 444);
            this.lblIdentidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdentidade.Name = "lblIdentidade";
            this.lblIdentidade.Size = new System.Drawing.Size(89, 20);
            this.lblIdentidade.TabIndex = 46;
            this.lblIdentidade.Text = "Identidade:";
            // 
            // btnSelecionarPDFCarteirinha
            // 
            this.btnSelecionarPDFCarteirinha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarPDFCarteirinha.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarPDFCarteirinha.Location = new System.Drawing.Point(264, 331);
            this.btnSelecionarPDFCarteirinha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelecionarPDFCarteirinha.Name = "btnSelecionarPDFCarteirinha";
            this.btnSelecionarPDFCarteirinha.Size = new System.Drawing.Size(224, 35);
            this.btnSelecionarPDFCarteirinha.TabIndex = 6;
            this.btnSelecionarPDFCarteirinha.Text = "Selecionar PDF Carteirinha";
            this.btnSelecionarPDFCarteirinha.UseVisualStyleBackColor = true;
            this.btnSelecionarPDFCarteirinha.Click += new System.EventHandler(this.btnSelecionarPDFCarteirinha_Click);
            // 
            // lblCarteirinha
            // 
            this.lblCarteirinha.ForeColor = System.Drawing.Color.White;
            this.lblCarteirinha.Location = new System.Drawing.Point(88, 331);
            this.lblCarteirinha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarteirinha.Name = "lblCarteirinha";
            this.lblCarteirinha.Size = new System.Drawing.Size(168, 46);
            this.lblCarteirinha.TabIndex = 44;
            this.lblCarteirinha.Text = "Carteirinha e Requisição Médica:";
            // 
            // lblDadosUnimedAcre
            // 
            this.lblDadosUnimedAcre.AutoSize = true;
            this.lblDadosUnimedAcre.ForeColor = System.Drawing.Color.White;
            this.lblDadosUnimedAcre.Location = new System.Drawing.Point(9, 15);
            this.lblDadosUnimedAcre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDadosUnimedAcre.Name = "lblDadosUnimedAcre";
            this.lblDadosUnimedAcre.Size = new System.Drawing.Size(156, 20);
            this.lblDadosUnimedAcre.TabIndex = 42;
            this.lblDadosUnimedAcre.Text = "Dados Unimed Acre:";
            // 
            // lblNumeroCarteirinha
            // 
            this.lblNumeroCarteirinha.ForeColor = System.Drawing.Color.White;
            this.lblNumeroCarteirinha.Location = new System.Drawing.Point(14, 72);
            this.lblNumeroCarteirinha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroCarteirinha.Name = "lblNumeroCarteirinha";
            this.lblNumeroCarteirinha.Size = new System.Drawing.Size(151, 30);
            this.lblNumeroCarteirinha.TabIndex = 35;
            this.lblNumeroCarteirinha.Text = "Número Carteirinha:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(665, 134);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(69, 20);
            this.lblNumero.TabIndex = 41;
            this.lblNumero.Text = "Número:";
            // 
            // txtLoginUnimedAcre
            // 
            this.txtLoginUnimedAcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtLoginUnimedAcre.ForeColor = System.Drawing.Color.White;
            this.txtLoginUnimedAcre.Location = new System.Drawing.Point(172, 78);
            this.txtLoginUnimedAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLoginUnimedAcre.MaxLength = 32;
            this.txtLoginUnimedAcre.Name = "txtLoginUnimedAcre";
            this.txtLoginUnimedAcre.Size = new System.Drawing.Size(316, 26);
            this.txtLoginUnimedAcre.TabIndex = 0;
            // 
            // txtEnderecoNumeroAcre
            // 
            this.txtEnderecoNumeroAcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtEnderecoNumeroAcre.ForeColor = System.Drawing.Color.White;
            this.txtEnderecoNumeroAcre.Location = new System.Drawing.Point(742, 134);
            this.txtEnderecoNumeroAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnderecoNumeroAcre.MaxLength = 32;
            this.txtEnderecoNumeroAcre.Name = "txtEnderecoNumeroAcre";
            this.txtEnderecoNumeroAcre.Size = new System.Drawing.Size(316, 26);
            this.txtEnderecoNumeroAcre.TabIndex = 3;
            // 
            // txtNomeBancoAcre
            // 
            this.txtNomeBancoAcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtNomeBancoAcre.ForeColor = System.Drawing.Color.White;
            this.txtNomeBancoAcre.Location = new System.Drawing.Point(172, 136);
            this.txtNomeBancoAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeBancoAcre.MaxLength = 32;
            this.txtNomeBancoAcre.Name = "txtNomeBancoAcre";
            this.txtNomeBancoAcre.Size = new System.Drawing.Size(316, 26);
            this.txtNomeBancoAcre.TabIndex = 1;
            // 
            // lblRua
            // 
            this.lblRua.AutoSize = true;
            this.lblRua.ForeColor = System.Drawing.Color.White;
            this.lblRua.Location = new System.Drawing.Point(611, 76);
            this.lblRua.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRua.Name = "lblRua";
            this.lblRua.Size = new System.Drawing.Size(126, 20);
            this.lblRua.TabIndex = 39;
            this.lblRua.Text = "Endereço (Rua):";
            // 
            // txtEnderecoRuaAcre
            // 
            this.txtEnderecoRuaAcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.txtEnderecoRuaAcre.ForeColor = System.Drawing.Color.White;
            this.txtEnderecoRuaAcre.Location = new System.Drawing.Point(742, 76);
            this.txtEnderecoRuaAcre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnderecoRuaAcre.MaxLength = 32;
            this.txtEnderecoRuaAcre.Name = "txtEnderecoRuaAcre";
            this.txtEnderecoRuaAcre.Size = new System.Drawing.Size(316, 26);
            this.txtEnderecoRuaAcre.TabIndex = 2;
            // 
            // lblNomeBancoAcre
            // 
            this.lblNomeBancoAcre.AutoSize = true;
            this.lblNomeBancoAcre.ForeColor = System.Drawing.Color.White;
            this.lblNomeBancoAcre.Location = new System.Drawing.Point(38, 135);
            this.lblNomeBancoAcre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeBancoAcre.Name = "lblNomeBancoAcre";
            this.lblNomeBancoAcre.Size = new System.Drawing.Size(127, 20);
            this.lblNomeBancoAcre.TabIndex = 37;
            this.lblNomeBancoAcre.Text = "Nome do Banco:";
            // 
            // menuAplicacao
            // 
            this.menuAplicacao.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuAplicacao.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuAplicacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuAplicacao.Location = new System.Drawing.Point(0, 0);
            this.menuAplicacao.Name = "menuAplicacao";
            this.menuAplicacao.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuAplicacao.Size = new System.Drawing.Size(1204, 31);
            this.menuAplicacao.TabIndex = 46;
            this.menuAplicacao.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restaurarBackupToolStripMenuItem,
            this.fazerBackupToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem1});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // restaurarBackupToolStripMenuItem
            // 
            this.restaurarBackupToolStripMenuItem.Name = "restaurarBackupToolStripMenuItem";
            this.restaurarBackupToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.restaurarBackupToolStripMenuItem.Text = "&Abrir Backup...";
            this.restaurarBackupToolStripMenuItem.Click += new System.EventHandler(this.restaurarBackupToolStripMenuItem_Click);
            // 
            // fazerBackupToolStripMenuItem
            // 
            this.fazerBackupToolStripMenuItem.Name = "fazerBackupToolStripMenuItem";
            this.fazerBackupToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.fazerBackupToolStripMenuItem.Text = "&Salvar Backup...";
            this.fazerBackupToolStripMenuItem.Click += new System.EventHandler(this.fazerBackupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // sairToolStripMenuItem1
            // 
            this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
            this.sairToolStripMenuItem1.Size = new System.Drawing.Size(235, 34);
            this.sairToolStripMenuItem1.Text = "&Sair";
            this.sairToolStripMenuItem1.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarExcluirToolStripMenuItem,
            this.toolStripMenuItemLinha1});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // adicionarExcluirToolStripMenuItem
            // 
            this.adicionarExcluirToolStripMenuItem.Name = "adicionarExcluirToolStripMenuItem";
            this.adicionarExcluirToolStripMenuItem.Size = new System.Drawing.Size(255, 34);
            this.adicionarExcluirToolStripMenuItem.Text = "&Adicionar / Excluir";
            this.adicionarExcluirToolStripMenuItem.Click += new System.EventHandler(this.adicionarExcluirToolStripMenuItem_Click);
            // 
            // toolStripMenuItemLinha1
            // 
            this.toolStripMenuItemLinha1.Name = "toolStripMenuItemLinha1";
            this.toolStripMenuItemLinha1.Size = new System.Drawing.Size(252, 6);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.ajudaToolStripMenuItem.Text = "&Ajuda";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // pnlSobre
            // 
            this.pnlSobre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.pnlSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSobre.Controls.Add(this.lblAjuda);
            this.pnlSobre.Controls.Add(this.picIconeSobre);
            this.pnlSobre.Controls.Add(this.btnFecharAjuda);
            this.pnlSobre.Controls.Add(this.lblCopyright);
            this.pnlSobre.Controls.Add(this.lblNomeAplicao);
            this.pnlSobre.ForeColor = System.Drawing.Color.White;
            this.pnlSobre.Location = new System.Drawing.Point(6, 41);
            this.pnlSobre.Margin = new System.Windows.Forms.Padding(1);
            this.pnlSobre.Name = "pnlSobre";
            this.pnlSobre.Size = new System.Drawing.Size(1188, 906);
            this.pnlSobre.TabIndex = 45;
            this.pnlSobre.Visible = false;
            // 
            // lblAjuda
            // 
            this.lblAjuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAjuda.Location = new System.Drawing.Point(84, 158);
            this.lblAjuda.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblAjuda.Name = "lblAjuda";
            this.lblAjuda.Size = new System.Drawing.Size(1025, 615);
            this.lblAjuda.TabIndex = 4;
            this.lblAjuda.Text = resources.GetString("lblAjuda.Text");
            // 
            // picIconeSobre
            // 
            this.picIconeSobre.BackgroundImage = global::TerapiaReembolso.Properties.Resources.App;
            this.picIconeSobre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIconeSobre.Location = new System.Drawing.Point(878, 52);
            this.picIconeSobre.Margin = new System.Windows.Forms.Padding(1);
            this.picIconeSobre.Name = "picIconeSobre";
            this.picIconeSobre.Size = new System.Drawing.Size(36, 41);
            this.picIconeSobre.TabIndex = 3;
            this.picIconeSobre.TabStop = false;
            // 
            // btnFecharAjuda
            // 
            this.btnFecharAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharAjuda.Location = new System.Drawing.Point(469, 814);
            this.btnFecharAjuda.Margin = new System.Windows.Forms.Padding(1);
            this.btnFecharAjuda.Name = "btnFecharAjuda";
            this.btnFecharAjuda.Size = new System.Drawing.Size(201, 62);
            this.btnFecharAjuda.TabIndex = 2;
            this.btnFecharAjuda.Text = "Fechar";
            this.btnFecharAjuda.UseVisualStyleBackColor = true;
            this.btnFecharAjuda.Click += new System.EventHandler(this.btnFecharAjuda_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(493, 103);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(288, 25);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "Copyright © Daniel Liedke 2022";
            // 
            // lblNomeAplicao
            // 
            this.lblNomeAplicao.AutoSize = true;
            this.lblNomeAplicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeAplicao.Location = new System.Drawing.Point(346, 45);
            this.lblNomeAplicao.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNomeAplicao.Name = "lblNomeAplicao";
            this.lblNomeAplicao.Size = new System.Drawing.Size(519, 52);
            this.lblNomeAplicao.TabIndex = 0;
            this.lblNomeAplicao.Text = "Terapia Reembolso v9.2";
            // 
            // pnlCadastroCliente
            // 
            this.pnlCadastroCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCadastroCliente.Controls.Add(this.lbInstrucoesClientes);
            this.pnlCadastroCliente.Controls.Add(this.btnNovoCliente);
            this.pnlCadastroCliente.Controls.Add(this.btnExcluirCliente);
            this.pnlCadastroCliente.Controls.Add(this.cmbNomeCliente);
            this.pnlCadastroCliente.Controls.Add(this.lbCliente);
            this.pnlCadastroCliente.Controls.Add(this.lbNomeCliente);
            this.pnlCadastroCliente.Controls.Add(this.btnFecharDadosCliente);
            this.pnlCadastroCliente.Location = new System.Drawing.Point(377, 314);
            this.pnlCadastroCliente.Margin = new System.Windows.Forms.Padding(1);
            this.pnlCadastroCliente.Name = "pnlCadastroCliente";
            this.pnlCadastroCliente.Size = new System.Drawing.Size(560, 311);
            this.pnlCadastroCliente.TabIndex = 45;
            this.pnlCadastroCliente.Visible = false;
            // 
            // lbInstrucoesClientes
            // 
            this.lbInstrucoesClientes.AutoSize = true;
            this.lbInstrucoesClientes.ForeColor = System.Drawing.Color.White;
            this.lbInstrucoesClientes.Location = new System.Drawing.Point(58, 54);
            this.lbInstrucoesClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInstrucoesClientes.Name = "lbInstrucoesClientes";
            this.lbInstrucoesClientes.Size = new System.Drawing.Size(364, 40);
            this.lbInstrucoesClientes.TabIndex = 45;
            this.lbInstrucoesClientes.Text = "Cada cliente pode ter diferente terapeuta e\r\nconta para reembolso (ex: plano de s" +
    "aúde familiar)";
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoCliente.ForeColor = System.Drawing.Color.White;
            this.btnNovoCliente.Location = new System.Drawing.Point(345, 165);
            this.btnNovoCliente.Margin = new System.Windows.Forms.Padding(1);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(71, 42);
            this.btnNovoCliente.TabIndex = 1;
            this.btnNovoCliente.Text = "Novo";
            this.btnNovoCliente.UseVisualStyleBackColor = true;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // btnExcluirCliente
            // 
            this.btnExcluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirCliente.ForeColor = System.Drawing.Color.White;
            this.btnExcluirCliente.Location = new System.Drawing.Point(428, 165);
            this.btnExcluirCliente.Margin = new System.Windows.Forms.Padding(1);
            this.btnExcluirCliente.Name = "btnExcluirCliente";
            this.btnExcluirCliente.Size = new System.Drawing.Size(81, 42);
            this.btnExcluirCliente.TabIndex = 3;
            this.btnExcluirCliente.Text = "Excluir";
            this.btnExcluirCliente.UseVisualStyleBackColor = true;
            this.btnExcluirCliente.Click += new System.EventHandler(this.btnExcluirCliente_Click);
            // 
            // cmbNomeCliente
            // 
            this.cmbNomeCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.cmbNomeCliente.ForeColor = System.Drawing.Color.White;
            this.cmbNomeCliente.FormattingEnabled = true;
            this.cmbNomeCliente.Location = new System.Drawing.Point(179, 121);
            this.cmbNomeCliente.Margin = new System.Windows.Forms.Padding(1);
            this.cmbNomeCliente.Name = "cmbNomeCliente";
            this.cmbNomeCliente.Size = new System.Drawing.Size(328, 28);
            this.cmbNomeCliente.TabIndex = 0;
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.ForeColor = System.Drawing.Color.White;
            this.lbCliente.Location = new System.Drawing.Point(9, 11);
            this.lbCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(245, 20);
            this.lbCliente.TabIndex = 44;
            this.lbCliente.Text = "Dados Cliente (Para Reembolso):";
            // 
            // lbNomeCliente
            // 
            this.lbNomeCliente.ForeColor = System.Drawing.Color.White;
            this.lbNomeCliente.Location = new System.Drawing.Point(58, 121);
            this.lbNomeCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNomeCliente.Name = "lbNomeCliente";
            this.lbNomeCliente.Size = new System.Drawing.Size(120, 38);
            this.lbNomeCliente.TabIndex = 4;
            this.lbNomeCliente.Text = "Nome Cliente:";
            // 
            // btnFecharDadosCliente
            // 
            this.btnFecharDadosCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharDadosCliente.ForeColor = System.Drawing.Color.White;
            this.btnFecharDadosCliente.Location = new System.Drawing.Point(186, 242);
            this.btnFecharDadosCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFecharDadosCliente.Name = "btnFecharDadosCliente";
            this.btnFecharDadosCliente.Size = new System.Drawing.Size(201, 45);
            this.btnFecharDadosCliente.TabIndex = 7;
            this.btnFecharDadosCliente.Text = "Fechar";
            this.btnFecharDadosCliente.UseVisualStyleBackColor = true;
            this.btnFecharDadosCliente.Click += new System.EventHandler(this.btnFecharDadosCliente_Click);
            // 
            // dialogoSalvarBackup
            // 
            this.dialogoSalvarBackup.Filter = "ZIP files|*.zip";
            // 
            // dialogoRestaurarBackup
            // 
            this.dialogoRestaurarBackup.Filter = "ZIP files|*.zip";
            // 
            // dialogoPDFCarteirinha
            // 
            this.dialogoPDFCarteirinha.Filter = "PDF files|*.pdf";
            // 
            // dialogoPDFIdentidade
            // 
            this.dialogoPDFIdentidade.Filter = "PDF files|*.pdf";
            // 
            // dtDataConsulta10
            // 
            this.dtDataConsulta10.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta10.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta10.Location = new System.Drawing.Point(134, 680);
            this.dtDataConsulta10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta10.Name = "dtDataConsulta10";
            this.dtDataConsulta10.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta10.TabIndex = 12;
            // 
            // dtDataConsulta9
            // 
            this.dtDataConsulta9.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta9.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta9.Location = new System.Drawing.Point(134, 632);
            this.dtDataConsulta9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta9.Name = "dtDataConsulta9";
            this.dtDataConsulta9.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta9.TabIndex = 11;
            // 
            // dtDataConsulta8
            // 
            this.dtDataConsulta8.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta8.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta8.Location = new System.Drawing.Point(134, 580);
            this.dtDataConsulta8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta8.Name = "dtDataConsulta8";
            this.dtDataConsulta8.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta8.TabIndex = 10;
            // 
            // dtDataConsulta7
            // 
            this.dtDataConsulta7.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta7.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta7.Location = new System.Drawing.Point(134, 528);
            this.dtDataConsulta7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta7.Name = "dtDataConsulta7";
            this.dtDataConsulta7.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta7.TabIndex = 9;
            // 
            // dtDataConsulta6
            // 
            this.dtDataConsulta6.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta6.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta6.Location = new System.Drawing.Point(134, 472);
            this.dtDataConsulta6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta6.Name = "dtDataConsulta6";
            this.dtDataConsulta6.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta6.TabIndex = 8;
            // 
            // dtDataConsulta4
            // 
            this.dtDataConsulta4.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta4.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta4.Location = new System.Drawing.Point(134, 358);
            this.dtDataConsulta4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta4.Name = "dtDataConsulta4";
            this.dtDataConsulta4.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta4.TabIndex = 6;
            // 
            // dtDataConsulta3
            // 
            this.dtDataConsulta3.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta3.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta3.Location = new System.Drawing.Point(134, 299);
            this.dtDataConsulta3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta3.Name = "dtDataConsulta3";
            this.dtDataConsulta3.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta3.TabIndex = 5;
            // 
            // dtDataConsulta5
            // 
            this.dtDataConsulta5.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta5.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta5.Location = new System.Drawing.Point(134, 414);
            this.dtDataConsulta5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta5.Name = "dtDataConsulta5";
            this.dtDataConsulta5.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta5.TabIndex = 7;
            // 
            // dtDataConsulta2
            // 
            this.dtDataConsulta2.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta2.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta2.Location = new System.Drawing.Point(134, 242);
            this.dtDataConsulta2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta2.Name = "dtDataConsulta2";
            this.dtDataConsulta2.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta2.TabIndex = 4;
            // 
            // dtDataConsulta1
            // 
            this.dtDataConsulta1.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataConsulta1.CalendarForeColor = System.Drawing.Color.White;
            this.dtDataConsulta1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.dtDataConsulta1.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataConsulta1.Location = new System.Drawing.Point(134, 186);
            this.dtDataConsulta1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta1.Name = "dtDataConsulta1";
            this.dtDataConsulta1.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta1.TabIndex = 3;
            // 
            // dtDataRecibo
            // 
            this.dtDataRecibo.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.dtDataRecibo.CalendarForeColor = System.Drawing.Color.White;
            this.dtDataRecibo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.dtDataRecibo.ForeDisabledColor = System.Drawing.Color.Empty;
            this.dtDataRecibo.Location = new System.Drawing.Point(172, 201);
            this.dtDataRecibo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataRecibo.Name = "dtDataRecibo";
            this.dtDataRecibo.Size = new System.Drawing.Size(316, 26);
            this.dtDataRecibo.TabIndex = 58;
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1204, 994);
            this.Controls.Add(this.pnlSobre);
            this.Controls.Add(this.menuAplicacao);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlRecibo);
            this.Controls.Add(this.pnlReembolso);
            this.Controls.Add(this.pnlConsultas);
            this.Controls.Add(this.pnlCadastroCliente);
            this.Controls.Add(this.pnlUnimedAcre);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terapia Reembolso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlConsultas.ResumeLayout(false);
            this.pnlConsultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroConsultas)).EndInit();
            this.pnlRecibo.ResumeLayout(false);
            this.pnlRecibo.PerformLayout();
            this.pnlDadosTerapeuta.ResumeLayout(false);
            this.pnlDadosTerapeuta.PerformLayout();
            this.gbTipoPessoa.ResumeLayout(false);
            this.gbTipoPessoa.PerformLayout();
            this.pnlDadosPaciente.ResumeLayout(false);
            this.pnlDadosPaciente.PerformLayout();
            this.pnlReembolso.ResumeLayout(false);
            this.pnlReembolso.PerformLayout();
            this.pnlDadosReembolso.ResumeLayout(false);
            this.pnlDadosReembolso.PerformLayout();
            this.grbTipoAtendimento.ResumeLayout(false);
            this.grbTipoAtendimento.PerformLayout();
            this.pnlDadosBancarios.ResumeLayout(false);
            this.pnlDadosBancarios.PerformLayout();
            this.pnlUnimedAcre.ResumeLayout(false);
            this.pnlUnimedAcre.PerformLayout();
            this.menuAplicacao.ResumeLayout(false);
            this.menuAplicacao.PerformLayout();
            this.pnlSobre.ResumeLayout(false);
            this.pnlSobre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconeSobre)).EndInit();
            this.pnlCadastroCliente.ResumeLayout(false);
            this.pnlCadastroCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerarRecibo;
        private DateTimePickerWithBackColor dtDataConsulta1;
        private System.Windows.Forms.MaskedTextBox txtValorConsulta;
        private System.Windows.Forms.Label lblNomeDoPaciente;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblReferenteA;
        private System.Windows.Forms.Label lblReciboConsulta;
        private System.Windows.Forms.Button btnSelecionarPDFRecibo;
        private System.Windows.Forms.OpenFileDialog dialogoPDFRecibo;
        private System.Windows.Forms.Label lblCPFPaciente;
        private System.Windows.Forms.TextBox txtCPFPaciente;
        private System.Windows.Forms.Label lblNomeArquivoRecibo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.LinkLabel lnkAssinarPDF;
        private System.Windows.Forms.TextBox txtReferenteA;
        private System.Windows.Forms.Label lblNomeDoTerapeuta;
        private System.Windows.Forms.TextBox txtNomeDoTerapeuta;
        private System.Windows.Forms.Label lblCPFTerapeuta;
        private System.Windows.Forms.TextBox txtCPFTerapeuta;
        private System.Windows.Forms.Label lblEnderecoTerapeuta;
        private System.Windows.Forms.TextBox txtEnderecoTerapeuta;
        private System.Windows.Forms.Label lblCRP;
        private System.Windows.Forms.TextBox txtCRP;
        private System.Windows.Forms.Button btnSelecionarConsultas;
        private System.Windows.Forms.Panel pnlConsultas;
        private System.Windows.Forms.Panel pnlRecibo;
        private System.Windows.Forms.Button btnSalvarConsultas;
        private System.Windows.Forms.Label lblNumeroDeConsultas;
        private System.Windows.Forms.NumericUpDown numNumeroConsultas;
        private System.Windows.Forms.Label lblSelecioneDataConsultas;
        private DateTimePickerWithBackColor dtDataConsulta4;
        private DateTimePickerWithBackColor dtDataConsulta3;
        private DateTimePickerWithBackColor dtDataConsulta5;
        private DateTimePickerWithBackColor dtDataConsulta2;
        private System.Windows.Forms.Label lblTituloGeracaoRecibo;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Panel pnlReembolso;
        private System.Windows.Forms.Label lblTituloSolicitacaoReembolso;
        private System.Windows.Forms.GroupBox grbTipoAtendimento;
        private System.Windows.Forms.RadioButton rbPresencial;
        private System.Windows.Forms.RadioButton rbTelemedicina;
        private System.Windows.Forms.Label lblDigitoDaConta;
        private System.Windows.Forms.TextBox txtDigitoDaConta;
        private System.Windows.Forms.Label lblContaSemDigito;
        private System.Windows.Forms.TextBox txtContaSemDigito;
        private System.Windows.Forms.Label lblAgenciaSemDigito;
        private System.Windows.Forms.TextBox txtAgenciaSemDigito;
        private System.Windows.Forms.Label lblNomeDoBanco;
        private System.Windows.Forms.TextBox txtNomeDoBanco;
        private System.Windows.Forms.Button btnGerarSolicitacaoReembolso;
        private System.Windows.Forms.Label lblSenhaUnimed;
        private System.Windows.Forms.TextBox txtSenhaUnimed;
        private System.Windows.Forms.Label lblLoginUnimed;
        private System.Windows.Forms.TextBox txtLoginUnimed;
        private DateTimePickerWithBackColor dtDataConsulta10;
        private DateTimePickerWithBackColor dtDataConsulta9;
        private DateTimePickerWithBackColor dtDataConsulta8;
        private DateTimePickerWithBackColor dtDataConsulta7;
        private DateTimePickerWithBackColor dtDataConsulta6;
        private System.Windows.Forms.ComboBox cmbDiaSemana;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lbDiaSemana;
        private System.Windows.Forms.Label lbMes;
        private System.Windows.Forms.Panel pnlDadosPaciente;
        private System.Windows.Forms.Label lbDadosPaciente;
        private System.Windows.Forms.Panel pnlDadosTerapeuta;
        private System.Windows.Forms.Label lbDadosTerapeuta;
        private System.Windows.Forms.Panel pnlDadosReembolso;
        private System.Windows.Forms.Label lbDadosReembolso;
        private System.Windows.Forms.Panel pnlDadosBancarios;
        private System.Windows.Forms.Label lbDadosBancarios;
        private System.Windows.Forms.LinkLabel lnkUnimedLogin;
        private System.Windows.Forms.ComboBox cmbNomePaciente;
        private System.Windows.Forms.Button btnExcluirPaciente;
        private System.Windows.Forms.Button btnSalvarPaciente;
        private System.Windows.Forms.Button btnNovoPaciente;
        private System.Windows.Forms.MenuStrip menuAplicacao;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSobre;
        private System.Windows.Forms.Button btnFecharAjuda;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblNomeAplicao;
        private System.Windows.Forms.PictureBox picIconeSobre;
        private System.Windows.Forms.GroupBox gbTipoPessoa;
        private System.Windows.Forms.RadioButton rbFisica;
        private System.Windows.Forms.RadioButton rbJuridica;
        private System.Windows.Forms.Label lbNomeEmpresa;
        private System.Windows.Forms.Label lblCNPJTerapeuta;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarExcluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemLinha1;
        private System.Windows.Forms.Panel pnlCadastroCliente;
        private System.Windows.Forms.Label lbInstrucoesClientes;
        private System.Windows.Forms.Button btnNovoCliente;
        private System.Windows.Forms.Button btnExcluirCliente;
        private System.Windows.Forms.ComboBox cmbNomeCliente;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.Label lbNomeCliente;
        private System.Windows.Forms.Button btnFecharDadosCliente;
        private System.Windows.Forms.Label lblAjuda;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fazerBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog dialogoSalvarBackup;
        private System.Windows.Forms.OpenFileDialog dialogoRestaurarBackup;
        private System.Windows.Forms.Panel pnlUnimedAcre;
        private System.Windows.Forms.Label lblDadosUnimedAcre;
        private System.Windows.Forms.Label lblNumeroCarteirinha;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtLoginUnimedAcre;
        private System.Windows.Forms.TextBox txtEnderecoNumeroAcre;
        private System.Windows.Forms.TextBox txtNomeBancoAcre;
        private System.Windows.Forms.Label lblRua;
        private System.Windows.Forms.TextBox txtEnderecoRuaAcre;
        private System.Windows.Forms.Label lblNomeBancoAcre;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox txtEnderecoBairroAcre;
        private System.Windows.Forms.Label lblComplemento;
        private System.Windows.Forms.TextBox txtEnderecoComplementoAcre;
        private System.Windows.Forms.Button btnSalvarDadosAcre;
        private System.Windows.Forms.Button btnSelecionarPDFIdentidade;
        private System.Windows.Forms.Label lblIdentidade;
        private System.Windows.Forms.Button btnSelecionarPDFCarteirinha;
        private System.Windows.Forms.Label lblCarteirinha;
        private System.Windows.Forms.Button btnMostraDadosUnimedAcre;
        private System.Windows.Forms.Label lblNomeArquivoIdentidade;
        private System.Windows.Forms.Label lblNomeArquivoCarteirinha;
        private System.Windows.Forms.OpenFileDialog dialogoPDFCarteirinha;
        private System.Windows.Forms.OpenFileDialog dialogoPDFIdentidade;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstadoAcre;
        private System.Windows.Forms.Label lbDataRecibo;
        private DateTimePickerWithBackColor dtDataRecibo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservacoes;
    }
}

