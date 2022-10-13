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
            this.dtDataConsulta1 = new System.Windows.Forms.DateTimePicker();
            this.txtValorConsulta = new System.Windows.Forms.MaskedTextBox();
            this.lblNomeDoPaciente = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblReferenteA = new System.Windows.Forms.Label();
            this.lblReciboAssinado = new System.Windows.Forms.Label();
            this.btnSelecionarPDFRecibo = new System.Windows.Forms.Button();
            this.dialogoPDF = new System.Windows.Forms.OpenFileDialog();
            this.lblCPFPaciente = new System.Windows.Forms.Label();
            this.txtCPFPaciente = new System.Windows.Forms.TextBox();
            this.lblNomeReciboPDF = new System.Windows.Forms.Label();
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
            this.dtDataConsulta10 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta9 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta8 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta7 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta6 = new System.Windows.Forms.DateTimePicker();
            this.btnSalvarConsultas = new System.Windows.Forms.Button();
            this.lblNumeroDeConsultas = new System.Windows.Forms.Label();
            this.numNumeroConsultas = new System.Windows.Forms.NumericUpDown();
            this.lblSelecioneDataConsultas = new System.Windows.Forms.Label();
            this.dtDataConsulta4 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta3 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta5 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta2 = new System.Windows.Forms.DateTimePicker();
            this.pnlRecibo = new System.Windows.Forms.Panel();
            this.pnlDadosTerapeuta = new System.Windows.Forms.Panel();
            this.lbDadosTerapeuta = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.lblTituloGeracaoRecibo = new System.Windows.Forms.Label();
            this.pnlDadosPaciente = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluirPaciente = new System.Windows.Forms.Button();
            this.btnSalvarPaciente = new System.Windows.Forms.Button();
            this.cmbNomePaciente = new System.Windows.Forms.ComboBox();
            this.lbDadosPaciente = new System.Windows.Forms.Label();
            this.pnlReembolso = new System.Windows.Forms.Panel();
            this.lnkUnimedLogin = new System.Windows.Forms.LinkLabel();
            this.pnlDadosReembolso = new System.Windows.Forms.Panel();
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
            this.lblTituloSolicitacaoReembolso = new System.Windows.Forms.Label();
            this.txtGerarSolicitacaoReembolso = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSobre = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFecharSobre = new System.Windows.Forms.Button();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblNomeAplicao = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.pnlConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroConsultas)).BeginInit();
            this.pnlRecibo.SuspendLayout();
            this.pnlDadosTerapeuta.SuspendLayout();
            this.pnlDadosPaciente.SuspendLayout();
            this.pnlReembolso.SuspendLayout();
            this.pnlDadosReembolso.SuspendLayout();
            this.grbTipoAtendimento.SuspendLayout();
            this.pnlDadosBancarios.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlSobre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGerarRecibo
            // 
            this.btnGerarRecibo.Location = new System.Drawing.Point(130, 539);
            this.btnGerarRecibo.Name = "btnGerarRecibo";
            this.btnGerarRecibo.Size = new System.Drawing.Size(134, 34);
            this.btnGerarRecibo.TabIndex = 11;
            this.btnGerarRecibo.Text = "Gerar Recibo";
            this.btnGerarRecibo.UseVisualStyleBackColor = true;
            this.btnGerarRecibo.Click += new System.EventHandler(this.btnGerarRecibo_Click);
            // 
            // dtDataConsulta1
            // 
            this.dtDataConsulta1.Location = new System.Drawing.Point(89, 121);
            this.dtDataConsulta1.Name = "dtDataConsulta1";
            this.dtDataConsulta1.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta1.TabIndex = 3;
            // 
            // txtValorConsulta
            // 
            this.txtValorConsulta.Location = new System.Drawing.Point(132, 66);
            this.txtValorConsulta.Name = "txtValorConsulta";
            this.txtValorConsulta.Size = new System.Drawing.Size(48, 20);
            this.txtValorConsulta.TabIndex = 4;
            this.txtValorConsulta.ValidatingType = typeof(int);
            this.txtValorConsulta.TextChanged += new System.EventHandler(this.txtValorConsulta_TextChanged);
            // 
            // lblNomeDoPaciente
            // 
            this.lblNomeDoPaciente.Location = new System.Drawing.Point(87, 35);
            this.lblNomeDoPaciente.Name = "lblNomeDoPaciente";
            this.lblNomeDoPaciente.Size = new System.Drawing.Size(43, 24);
            this.lblNomeDoPaciente.TabIndex = 4;
            this.lblNomeDoPaciente.Text = "Nome:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(48, 68);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(78, 13);
            this.lblValorTotal.TabIndex = 5;
            this.lblValorTotal.Text = "Valor Consulta:";
            // 
            // lblReferenteA
            // 
            this.lblReferenteA.AutoSize = true;
            this.lblReferenteA.Location = new System.Drawing.Point(57, 127);
            this.lblReferenteA.Name = "lblReferenteA";
            this.lblReferenteA.Size = new System.Drawing.Size(66, 13);
            this.lblReferenteA.TabIndex = 6;
            this.lblReferenteA.Text = "Referente à:";
            this.lblReferenteA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReciboAssinado
            // 
            this.lblReciboAssinado.AutoSize = true;
            this.lblReciboAssinado.Location = new System.Drawing.Point(22, 125);
            this.lblReciboAssinado.Name = "lblReciboAssinado";
            this.lblReciboAssinado.Size = new System.Drawing.Size(90, 13);
            this.lblReciboAssinado.TabIndex = 7;
            this.lblReciboAssinado.Text = "Recibo Assinado:";
            // 
            // btnSelecionarPDFRecibo
            // 
            this.btnSelecionarPDFRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarPDFRecibo.Location = new System.Drawing.Point(119, 120);
            this.btnSelecionarPDFRecibo.Name = "btnSelecionarPDFRecibo";
            this.btnSelecionarPDFRecibo.Size = new System.Drawing.Size(127, 23);
            this.btnSelecionarPDFRecibo.TabIndex = 2;
            this.btnSelecionarPDFRecibo.Text = "Selecionar PDF Recibo";
            this.btnSelecionarPDFRecibo.UseVisualStyleBackColor = true;
            this.btnSelecionarPDFRecibo.Click += new System.EventHandler(this.btnSelectPDF_Click);
            // 
            // dialogoPDF
            // 
            this.dialogoPDF.Filter = "PDF files|*.pdf";
            // 
            // lblCPFPaciente
            // 
            this.lblCPFPaciente.AutoSize = true;
            this.lblCPFPaciente.Location = new System.Drawing.Point(92, 97);
            this.lblCPFPaciente.Name = "lblCPFPaciente";
            this.lblCPFPaciente.Size = new System.Drawing.Size(30, 13);
            this.lblCPFPaciente.TabIndex = 10;
            this.lblCPFPaciente.Text = "CPF:";
            // 
            // txtCPFPaciente
            // 
            this.txtCPFPaciente.Location = new System.Drawing.Point(132, 97);
            this.txtCPFPaciente.MaxLength = 16;
            this.txtCPFPaciente.Name = "txtCPFPaciente";
            this.txtCPFPaciente.Size = new System.Drawing.Size(221, 20);
            this.txtCPFPaciente.TabIndex = 5;
            this.txtCPFPaciente.TextChanged += new System.EventHandler(this.txtCPFPaciente_TextChanged);
            // 
            // lblNomeReciboPDF
            // 
            this.lblNomeReciboPDF.AutoSize = true;
            this.lblNomeReciboPDF.Location = new System.Drawing.Point(256, 122);
            this.lblNomeReciboPDF.Name = "lblNomeReciboPDF";
            this.lblNomeReciboPDF.Size = new System.Drawing.Size(0, 13);
            this.lblNomeReciboPDF.TabIndex = 11;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 623);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip.Size = new System.Drawing.Size(816, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 12;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatus.Text = "Idle.";
            // 
            // lnkAssinarPDF
            // 
            this.lnkAssinarPDF.AutoSize = true;
            this.lnkAssinarPDF.Location = new System.Drawing.Point(321, 7);
            this.lnkAssinarPDF.Name = "lnkAssinarPDF";
            this.lnkAssinarPDF.Size = new System.Drawing.Size(65, 13);
            this.lnkAssinarPDF.TabIndex = 24;
            this.lnkAssinarPDF.TabStop = true;
            this.lnkAssinarPDF.Text = "Assinar PDF";
            this.lnkAssinarPDF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAssinarPDF_LinkClicked);
            // 
            // txtReferenteA
            // 
            this.txtReferenteA.Location = new System.Drawing.Point(130, 127);
            this.txtReferenteA.MaxLength = 32;
            this.txtReferenteA.Name = "txtReferenteA";
            this.txtReferenteA.Size = new System.Drawing.Size(223, 20);
            this.txtReferenteA.TabIndex = 6;
            // 
            // lblNomeDoTerapeuta
            // 
            this.lblNomeDoTerapeuta.AutoSize = true;
            this.lblNomeDoTerapeuta.Location = new System.Drawing.Point(75, 64);
            this.lblNomeDoTerapeuta.Name = "lblNomeDoTerapeuta";
            this.lblNomeDoTerapeuta.Size = new System.Drawing.Size(38, 13);
            this.lblNomeDoTerapeuta.TabIndex = 27;
            this.lblNomeDoTerapeuta.Text = "Nome:";
            // 
            // txtNomeDoTerapeuta
            // 
            this.txtNomeDoTerapeuta.Location = new System.Drawing.Point(125, 64);
            this.txtNomeDoTerapeuta.MaxLength = 32;
            this.txtNomeDoTerapeuta.Name = "txtNomeDoTerapeuta";
            this.txtNomeDoTerapeuta.Size = new System.Drawing.Size(228, 20);
            this.txtNomeDoTerapeuta.TabIndex = 1;
            // 
            // lblCPFTerapeuta
            // 
            this.lblCPFTerapeuta.AutoSize = true;
            this.lblCPFTerapeuta.Location = new System.Drawing.Point(82, 97);
            this.lblCPFTerapeuta.Name = "lblCPFTerapeuta";
            this.lblCPFTerapeuta.Size = new System.Drawing.Size(30, 13);
            this.lblCPFTerapeuta.TabIndex = 29;
            this.lblCPFTerapeuta.Text = "CPF:";
            // 
            // txtCPFTerapeuta
            // 
            this.txtCPFTerapeuta.Location = new System.Drawing.Point(125, 97);
            this.txtCPFTerapeuta.MaxLength = 16;
            this.txtCPFTerapeuta.Name = "txtCPFTerapeuta";
            this.txtCPFTerapeuta.Size = new System.Drawing.Size(228, 20);
            this.txtCPFTerapeuta.TabIndex = 2;
            this.txtCPFTerapeuta.TextChanged += new System.EventHandler(this.txtCPFTerapeuta_TextChanged);
            // 
            // lblEnderecoTerapeuta
            // 
            this.lblEnderecoTerapeuta.AutoSize = true;
            this.lblEnderecoTerapeuta.Location = new System.Drawing.Point(57, 192);
            this.lblEnderecoTerapeuta.Name = "lblEnderecoTerapeuta";
            this.lblEnderecoTerapeuta.Size = new System.Drawing.Size(56, 13);
            this.lblEnderecoTerapeuta.TabIndex = 31;
            this.lblEnderecoTerapeuta.Text = "Endereço:";
            // 
            // txtEnderecoTerapeuta
            // 
            this.txtEnderecoTerapeuta.Location = new System.Drawing.Point(127, 190);
            this.txtEnderecoTerapeuta.Multiline = true;
            this.txtEnderecoTerapeuta.Name = "txtEnderecoTerapeuta";
            this.txtEnderecoTerapeuta.Size = new System.Drawing.Size(227, 67);
            this.txtEnderecoTerapeuta.TabIndex = 5;
            // 
            // lblCRP
            // 
            this.lblCRP.AutoSize = true;
            this.lblCRP.Location = new System.Drawing.Point(26, 128);
            this.lblCRP.Name = "lblCRP";
            this.lblCRP.Size = new System.Drawing.Size(87, 13);
            this.lblCRP.TabIndex = 33;
            this.lblCRP.Text = "Número do CRP:";
            // 
            // txtCRP
            // 
            this.txtCRP.Location = new System.Drawing.Point(126, 128);
            this.txtCRP.MaxLength = 20;
            this.txtCRP.Name = "txtCRP";
            this.txtCRP.Size = new System.Drawing.Size(227, 20);
            this.txtCRP.TabIndex = 3;
            this.txtCRP.TextChanged += new System.EventHandler(this.txtCRP_TextChanged);
            // 
            // btnSelecionarConsultas
            // 
            this.btnSelecionarConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarConsultas.Location = new System.Drawing.Point(132, 158);
            this.btnSelecionarConsultas.Name = "btnSelecionarConsultas";
            this.btnSelecionarConsultas.Size = new System.Drawing.Size(134, 29);
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
            this.pnlConsultas.Location = new System.Drawing.Point(414, 27);
            this.pnlConsultas.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlConsultas.Name = "pnlConsultas";
            this.pnlConsultas.Size = new System.Drawing.Size(382, 587);
            this.pnlConsultas.TabIndex = 35;
            this.pnlConsultas.Visible = false;
            // 
            // lbDiaSemana
            // 
            this.lbDiaSemana.AutoSize = true;
            this.lbDiaSemana.Location = new System.Drawing.Point(164, 12);
            this.lbDiaSemana.Name = "lbDiaSemana";
            this.lbDiaSemana.Size = new System.Drawing.Size(83, 13);
            this.lbDiaSemana.TabIndex = 48;
            this.lbDiaSemana.Text = "Dia da Semana:";
            // 
            // lbMes
            // 
            this.lbMes.AutoSize = true;
            this.lbMes.Location = new System.Drawing.Point(10, 12);
            this.lbMes.Name = "lbMes";
            this.lbMes.Size = new System.Drawing.Size(30, 13);
            this.lbMes.TabIndex = 47;
            this.lbMes.Text = "Mes:";
            // 
            // cmbDiaSemana
            // 
            this.cmbDiaSemana.DisplayMember = "Name";
            this.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaSemana.FormattingEnabled = true;
            this.cmbDiaSemana.Location = new System.Drawing.Point(251, 10);
            this.cmbDiaSemana.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDiaSemana.Name = "cmbDiaSemana";
            this.cmbDiaSemana.Size = new System.Drawing.Size(121, 21);
            this.cmbDiaSemana.TabIndex = 1;
            this.cmbDiaSemana.ValueMember = "Value";
            this.cmbDiaSemana.SelectedIndexChanged += new System.EventHandler(this.cmbDiaSemana_SelectedIndexChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.DisplayMember = "Name";
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(44, 10);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(114, 21);
            this.cmbMes.TabIndex = 0;
            this.cmbMes.ValueMember = "Value";
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // dtDataConsulta10
            // 
            this.dtDataConsulta10.Location = new System.Drawing.Point(89, 442);
            this.dtDataConsulta10.Name = "dtDataConsulta10";
            this.dtDataConsulta10.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta10.TabIndex = 12;
            // 
            // dtDataConsulta9
            // 
            this.dtDataConsulta9.Location = new System.Drawing.Point(89, 411);
            this.dtDataConsulta9.Name = "dtDataConsulta9";
            this.dtDataConsulta9.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta9.TabIndex = 11;
            // 
            // dtDataConsulta8
            // 
            this.dtDataConsulta8.Location = new System.Drawing.Point(89, 377);
            this.dtDataConsulta8.Name = "dtDataConsulta8";
            this.dtDataConsulta8.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta8.TabIndex = 10;
            // 
            // dtDataConsulta7
            // 
            this.dtDataConsulta7.Location = new System.Drawing.Point(89, 343);
            this.dtDataConsulta7.Name = "dtDataConsulta7";
            this.dtDataConsulta7.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta7.TabIndex = 9;
            // 
            // dtDataConsulta6
            // 
            this.dtDataConsulta6.Location = new System.Drawing.Point(89, 307);
            this.dtDataConsulta6.Name = "dtDataConsulta6";
            this.dtDataConsulta6.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta6.TabIndex = 8;
            // 
            // btnSalvarConsultas
            // 
            this.btnSalvarConsultas.Location = new System.Drawing.Point(116, 480);
            this.btnSalvarConsultas.Name = "btnSalvarConsultas";
            this.btnSalvarConsultas.Size = new System.Drawing.Size(134, 29);
            this.btnSalvarConsultas.TabIndex = 13;
            this.btnSalvarConsultas.Text = "Salvar";
            this.btnSalvarConsultas.UseVisualStyleBackColor = true;
            this.btnSalvarConsultas.Click += new System.EventHandler(this.btnSalvarConsultas_Click);
            // 
            // lblNumeroDeConsultas
            // 
            this.lblNumeroDeConsultas.AutoSize = true;
            this.lblNumeroDeConsultas.Location = new System.Drawing.Point(128, 53);
            this.lblNumeroDeConsultas.Name = "lblNumeroDeConsultas";
            this.lblNumeroDeConsultas.Size = new System.Drawing.Size(111, 13);
            this.lblNumeroDeConsultas.TabIndex = 39;
            this.lblNumeroDeConsultas.Text = "Número de Consultas:";
            // 
            // numNumeroConsultas
            // 
            this.numNumeroConsultas.Location = new System.Drawing.Point(242, 53);
            this.numNumeroConsultas.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.numNumeroConsultas.Size = new System.Drawing.Size(45, 20);
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
            this.lblSelecioneDataConsultas.Location = new System.Drawing.Point(130, 92);
            this.lblSelecioneDataConsultas.Name = "lblSelecioneDataConsultas";
            this.lblSelecioneDataConsultas.Size = new System.Drawing.Size(154, 13);
            this.lblSelecioneDataConsultas.TabIndex = 37;
            this.lblSelecioneDataConsultas.Text = "Selecione datas das consultas:";
            // 
            // dtDataConsulta4
            // 
            this.dtDataConsulta4.Location = new System.Drawing.Point(89, 232);
            this.dtDataConsulta4.Name = "dtDataConsulta4";
            this.dtDataConsulta4.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta4.TabIndex = 6;
            // 
            // dtDataConsulta3
            // 
            this.dtDataConsulta3.Location = new System.Drawing.Point(89, 194);
            this.dtDataConsulta3.Name = "dtDataConsulta3";
            this.dtDataConsulta3.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta3.TabIndex = 5;
            // 
            // dtDataConsulta5
            // 
            this.dtDataConsulta5.Location = new System.Drawing.Point(89, 269);
            this.dtDataConsulta5.Name = "dtDataConsulta5";
            this.dtDataConsulta5.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta5.TabIndex = 7;
            // 
            // dtDataConsulta2
            // 
            this.dtDataConsulta2.Location = new System.Drawing.Point(89, 158);
            this.dtDataConsulta2.Name = "dtDataConsulta2";
            this.dtDataConsulta2.Size = new System.Drawing.Size(230, 20);
            this.dtDataConsulta2.TabIndex = 4;
            // 
            // pnlRecibo
            // 
            this.pnlRecibo.Controls.Add(this.pnlDadosTerapeuta);
            this.pnlRecibo.Controls.Add(this.lblTituloGeracaoRecibo);
            this.pnlRecibo.Controls.Add(this.lnkAssinarPDF);
            this.pnlRecibo.Controls.Add(this.btnGerarRecibo);
            this.pnlRecibo.Controls.Add(this.pnlDadosPaciente);
            this.pnlRecibo.Location = new System.Drawing.Point(4, 27);
            this.pnlRecibo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlRecibo.Name = "pnlRecibo";
            this.pnlRecibo.Size = new System.Drawing.Size(401, 585);
            this.pnlRecibo.TabIndex = 36;
            // 
            // pnlDadosTerapeuta
            // 
            this.pnlDadosTerapeuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.pnlDadosTerapeuta.Location = new System.Drawing.Point(13, 248);
            this.pnlDadosTerapeuta.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosTerapeuta.Name = "pnlDadosTerapeuta";
            this.pnlDadosTerapeuta.Size = new System.Drawing.Size(380, 277);
            this.pnlDadosTerapeuta.TabIndex = 1;
            // 
            // lbDadosTerapeuta
            // 
            this.lbDadosTerapeuta.AutoSize = true;
            this.lbDadosTerapeuta.Location = new System.Drawing.Point(6, 6);
            this.lbDadosTerapeuta.Name = "lbDadosTerapeuta";
            this.lbDadosTerapeuta.Size = new System.Drawing.Size(93, 13);
            this.lbDadosTerapeuta.TabIndex = 43;
            this.lbDadosTerapeuta.Text = "Dados Terapeuta:";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(69, 33);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(43, 13);
            this.lblCidade.TabIndex = 14;
            this.lblCidade.Text = "Cidade:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(127, 31);
            this.txtCidade.MaxLength = 32;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(224, 20);
            this.txtCidade.TabIndex = 0;
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(81, 160);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(31, 13);
            this.lblCEP.TabIndex = 36;
            this.lblCEP.Text = "CEP:";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(125, 160);
            this.txtCEP.MaxLength = 12;
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(227, 20);
            this.txtCEP.TabIndex = 4;
            this.txtCEP.TextChanged += new System.EventHandler(this.txtCEP_TextChanged);
            // 
            // lblTituloGeracaoRecibo
            // 
            this.lblTituloGeracaoRecibo.AutoSize = true;
            this.lblTituloGeracaoRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGeracaoRecibo.Location = new System.Drawing.Point(128, 7);
            this.lblTituloGeracaoRecibo.Name = "lblTituloGeracaoRecibo";
            this.lblTituloGeracaoRecibo.Size = new System.Drawing.Size(164, 13);
            this.lblTituloGeracaoRecibo.TabIndex = 44;
            this.lblTituloGeracaoRecibo.Text = "Geração de Recibo Terapia";
            // 
            // pnlDadosPaciente
            // 
            this.pnlDadosPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDadosPaciente.Controls.Add(this.btnNovo);
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
            this.pnlDadosPaciente.Location = new System.Drawing.Point(13, 30);
            this.pnlDadosPaciente.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosPaciente.Name = "pnlDadosPaciente";
            this.pnlDadosPaciente.Size = new System.Drawing.Size(377, 203);
            this.pnlDadosPaciente.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Location = new System.Drawing.Point(196, 58);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(1);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(47, 28);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluirPaciente
            // 
            this.btnExcluirPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirPaciente.Location = new System.Drawing.Point(296, 58);
            this.btnExcluirPaciente.Margin = new System.Windows.Forms.Padding(1);
            this.btnExcluirPaciente.Name = "btnExcluirPaciente";
            this.btnExcluirPaciente.Size = new System.Drawing.Size(54, 28);
            this.btnExcluirPaciente.TabIndex = 3;
            this.btnExcluirPaciente.Text = "Excluir";
            this.btnExcluirPaciente.UseVisualStyleBackColor = true;
            this.btnExcluirPaciente.Click += new System.EventHandler(this.btnExcluirPaciente_Click);
            // 
            // btnSalvarPaciente
            // 
            this.btnSalvarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarPaciente.Location = new System.Drawing.Point(246, 58);
            this.btnSalvarPaciente.Margin = new System.Windows.Forms.Padding(1);
            this.btnSalvarPaciente.Name = "btnSalvarPaciente";
            this.btnSalvarPaciente.Size = new System.Drawing.Size(48, 28);
            this.btnSalvarPaciente.TabIndex = 2;
            this.btnSalvarPaciente.Text = "Salvar";
            this.btnSalvarPaciente.UseVisualStyleBackColor = true;
            this.btnSalvarPaciente.Click += new System.EventHandler(this.btnSalvarPaciente_Click);
            // 
            // cmbNomePaciente
            // 
            this.cmbNomePaciente.FormattingEnabled = true;
            this.cmbNomePaciente.Location = new System.Drawing.Point(130, 35);
            this.cmbNomePaciente.Margin = new System.Windows.Forms.Padding(1);
            this.cmbNomePaciente.Name = "cmbNomePaciente";
            this.cmbNomePaciente.Size = new System.Drawing.Size(220, 21);
            this.cmbNomePaciente.TabIndex = 0;
            this.cmbNomePaciente.SelectedIndexChanged += new System.EventHandler(this.cmbNomePaciente_SelectedIndexChanged);
            this.cmbNomePaciente.TextChanged += new System.EventHandler(this.cmbNomePaciente_TextChanged);
            this.cmbNomePaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbNomePaciente_KeyPress);
            // 
            // lbDadosPaciente
            // 
            this.lbDadosPaciente.AutoSize = true;
            this.lbDadosPaciente.Location = new System.Drawing.Point(6, 7);
            this.lbDadosPaciente.Name = "lbDadosPaciente";
            this.lbDadosPaciente.Size = new System.Drawing.Size(86, 13);
            this.lbDadosPaciente.TabIndex = 44;
            this.lbDadosPaciente.Text = "Dados Paciente:";
            // 
            // pnlReembolso
            // 
            this.pnlReembolso.Controls.Add(this.lnkUnimedLogin);
            this.pnlReembolso.Controls.Add(this.pnlDadosReembolso);
            this.pnlReembolso.Controls.Add(this.pnlDadosBancarios);
            this.pnlReembolso.Controls.Add(this.lblTituloSolicitacaoReembolso);
            this.pnlReembolso.Controls.Add(this.txtGerarSolicitacaoReembolso);
            this.pnlReembolso.Location = new System.Drawing.Point(414, 27);
            this.pnlReembolso.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnlReembolso.Name = "pnlReembolso";
            this.pnlReembolso.Size = new System.Drawing.Size(381, 585);
            this.pnlReembolso.TabIndex = 37;
            // 
            // lnkUnimedLogin
            // 
            this.lnkUnimedLogin.Location = new System.Drawing.Point(331, 7);
            this.lnkUnimedLogin.Name = "lnkUnimedLogin";
            this.lnkUnimedLogin.Size = new System.Drawing.Size(37, 19);
            this.lnkUnimedLogin.TabIndex = 50;
            this.lnkUnimedLogin.TabStop = true;
            this.lnkUnimedLogin.Text = "Login";
            this.lnkUnimedLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUnimedLogin_LinkClicked);
            // 
            // pnlDadosReembolso
            // 
            this.pnlDadosReembolso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDadosReembolso.Controls.Add(this.lbDadosReembolso);
            this.pnlDadosReembolso.Controls.Add(this.lblLoginUnimed);
            this.pnlDadosReembolso.Controls.Add(this.btnSelecionarPDFRecibo);
            this.pnlDadosReembolso.Controls.Add(this.lblReciboAssinado);
            this.pnlDadosReembolso.Controls.Add(this.txtLoginUnimed);
            this.pnlDadosReembolso.Controls.Add(this.grbTipoAtendimento);
            this.pnlDadosReembolso.Controls.Add(this.lblNomeReciboPDF);
            this.pnlDadosReembolso.Controls.Add(this.txtSenhaUnimed);
            this.pnlDadosReembolso.Controls.Add(this.lblSenhaUnimed);
            this.pnlDadosReembolso.Location = new System.Drawing.Point(15, 30);
            this.pnlDadosReembolso.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosReembolso.Name = "pnlDadosReembolso";
            this.pnlDadosReembolso.Size = new System.Drawing.Size(353, 275);
            this.pnlDadosReembolso.TabIndex = 0;
            // 
            // lbDadosReembolso
            // 
            this.lbDadosReembolso.AutoSize = true;
            this.lbDadosReembolso.Location = new System.Drawing.Point(8, 7);
            this.lbDadosReembolso.Name = "lbDadosReembolso";
            this.lbDadosReembolso.Size = new System.Drawing.Size(97, 13);
            this.lbDadosReembolso.TabIndex = 48;
            this.lbDadosReembolso.Text = "Dados Reembolso:";
            // 
            // lblLoginUnimed
            // 
            this.lblLoginUnimed.AutoSize = true;
            this.lblLoginUnimed.Location = new System.Drawing.Point(10, 48);
            this.lblLoginUnimed.Name = "lblLoginUnimed";
            this.lblLoginUnimed.Size = new System.Drawing.Size(104, 13);
            this.lblLoginUnimed.TabIndex = 47;
            this.lblLoginUnimed.Text = "Login Unimed (CPF):";
            // 
            // txtLoginUnimed
            // 
            this.txtLoginUnimed.Location = new System.Drawing.Point(119, 48);
            this.txtLoginUnimed.MaxLength = 16;
            this.txtLoginUnimed.Name = "txtLoginUnimed";
            this.txtLoginUnimed.Size = new System.Drawing.Size(212, 20);
            this.txtLoginUnimed.TabIndex = 0;
            this.txtLoginUnimed.TextChanged += new System.EventHandler(this.txtLoginUnimed_TextChanged);
            // 
            // grbTipoAtendimento
            // 
            this.grbTipoAtendimento.Controls.Add(this.rbPresencial);
            this.grbTipoAtendimento.Controls.Add(this.rbTelemedicina);
            this.grbTipoAtendimento.Location = new System.Drawing.Point(18, 164);
            this.grbTipoAtendimento.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.grbTipoAtendimento.Name = "grbTipoAtendimento";
            this.grbTipoAtendimento.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.grbTipoAtendimento.Size = new System.Drawing.Size(138, 82);
            this.grbTipoAtendimento.TabIndex = 42;
            this.grbTipoAtendimento.TabStop = false;
            this.grbTipoAtendimento.Text = "Tipo de Atendimento:";
            // 
            // rbPresencial
            // 
            this.rbPresencial.AutoSize = true;
            this.rbPresencial.Location = new System.Drawing.Point(16, 24);
            this.rbPresencial.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rbPresencial.Name = "rbPresencial";
            this.rbPresencial.Size = new System.Drawing.Size(74, 17);
            this.rbPresencial.TabIndex = 0;
            this.rbPresencial.Text = "Presencial";
            this.rbPresencial.UseVisualStyleBackColor = true;
            // 
            // rbTelemedicina
            // 
            this.rbTelemedicina.AutoSize = true;
            this.rbTelemedicina.Checked = true;
            this.rbTelemedicina.Location = new System.Drawing.Point(16, 50);
            this.rbTelemedicina.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rbTelemedicina.Name = "rbTelemedicina";
            this.rbTelemedicina.Size = new System.Drawing.Size(88, 17);
            this.rbTelemedicina.TabIndex = 1;
            this.rbTelemedicina.TabStop = true;
            this.rbTelemedicina.Text = "Telemedicina";
            this.rbTelemedicina.UseVisualStyleBackColor = true;
            // 
            // txtSenhaUnimed
            // 
            this.txtSenhaUnimed.Location = new System.Drawing.Point(119, 82);
            this.txtSenhaUnimed.MaxLength = 32;
            this.txtSenhaUnimed.Name = "txtSenhaUnimed";
            this.txtSenhaUnimed.PasswordChar = '*';
            this.txtSenhaUnimed.Size = new System.Drawing.Size(212, 20);
            this.txtSenhaUnimed.TabIndex = 1;
            // 
            // lblSenhaUnimed
            // 
            this.lblSenhaUnimed.AutoSize = true;
            this.lblSenhaUnimed.Location = new System.Drawing.Point(30, 83);
            this.lblSenhaUnimed.Name = "lblSenhaUnimed";
            this.lblSenhaUnimed.Size = new System.Drawing.Size(80, 13);
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
            this.pnlDadosBancarios.Location = new System.Drawing.Point(15, 321);
            this.pnlDadosBancarios.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDadosBancarios.Name = "pnlDadosBancarios";
            this.pnlDadosBancarios.Size = new System.Drawing.Size(353, 204);
            this.pnlDadosBancarios.TabIndex = 1;
            // 
            // lbDadosBancarios
            // 
            this.lbDadosBancarios.AutoSize = true;
            this.lbDadosBancarios.Location = new System.Drawing.Point(6, 10);
            this.lbDadosBancarios.Name = "lbDadosBancarios";
            this.lbDadosBancarios.Size = new System.Drawing.Size(91, 13);
            this.lbDadosBancarios.TabIndex = 42;
            this.lbDadosBancarios.Text = "Dados Bancários:";
            // 
            // lblNomeDoBanco
            // 
            this.lblNomeDoBanco.AutoSize = true;
            this.lblNomeDoBanco.Location = new System.Drawing.Point(24, 55);
            this.lblNomeDoBanco.Name = "lblNomeDoBanco";
            this.lblNomeDoBanco.Size = new System.Drawing.Size(87, 13);
            this.lblNomeDoBanco.TabIndex = 35;
            this.lblNomeDoBanco.Text = "Nome do Banco:";
            // 
            // lblDigitoDaConta
            // 
            this.lblDigitoDaConta.AutoSize = true;
            this.lblDigitoDaConta.Location = new System.Drawing.Point(26, 157);
            this.lblDigitoDaConta.Name = "lblDigitoDaConta";
            this.lblDigitoDaConta.Size = new System.Drawing.Size(84, 13);
            this.lblDigitoDaConta.TabIndex = 41;
            this.lblDigitoDaConta.Text = "Dígito da conta:";
            // 
            // txtNomeDoBanco
            // 
            this.txtNomeDoBanco.Location = new System.Drawing.Point(114, 53);
            this.txtNomeDoBanco.MaxLength = 32;
            this.txtNomeDoBanco.Name = "txtNomeDoBanco";
            this.txtNomeDoBanco.Size = new System.Drawing.Size(212, 20);
            this.txtNomeDoBanco.TabIndex = 0;
            // 
            // txtDigitoDaConta
            // 
            this.txtDigitoDaConta.Location = new System.Drawing.Point(115, 157);
            this.txtDigitoDaConta.MaxLength = 32;
            this.txtDigitoDaConta.Name = "txtDigitoDaConta";
            this.txtDigitoDaConta.Size = new System.Drawing.Size(212, 20);
            this.txtDigitoDaConta.TabIndex = 3;
            this.txtDigitoDaConta.TextChanged += new System.EventHandler(this.txtDigitoDaConta_TextChanged);
            // 
            // txtAgenciaSemDigito
            // 
            this.txtAgenciaSemDigito.Location = new System.Drawing.Point(115, 88);
            this.txtAgenciaSemDigito.MaxLength = 32;
            this.txtAgenciaSemDigito.Name = "txtAgenciaSemDigito";
            this.txtAgenciaSemDigito.Size = new System.Drawing.Size(212, 20);
            this.txtAgenciaSemDigito.TabIndex = 1;
            this.txtAgenciaSemDigito.TextChanged += new System.EventHandler(this.txtAgenciaSemDigito_TextChanged);
            // 
            // lblContaSemDigito
            // 
            this.lblContaSemDigito.AutoSize = true;
            this.lblContaSemDigito.Location = new System.Drawing.Point(16, 125);
            this.lblContaSemDigito.Name = "lblContaSemDigito";
            this.lblContaSemDigito.Size = new System.Drawing.Size(90, 13);
            this.lblContaSemDigito.TabIndex = 39;
            this.lblContaSemDigito.Text = "Conta sem dígito:";
            // 
            // txtContaSemDigito
            // 
            this.txtContaSemDigito.Location = new System.Drawing.Point(114, 122);
            this.txtContaSemDigito.MaxLength = 32;
            this.txtContaSemDigito.Name = "txtContaSemDigito";
            this.txtContaSemDigito.Size = new System.Drawing.Size(212, 20);
            this.txtContaSemDigito.TabIndex = 2;
            this.txtContaSemDigito.TextChanged += new System.EventHandler(this.txtContaSemDigito_TextChanged);
            // 
            // lblAgenciaSemDigito
            // 
            this.lblAgenciaSemDigito.AutoSize = true;
            this.lblAgenciaSemDigito.Location = new System.Drawing.Point(11, 88);
            this.lblAgenciaSemDigito.Name = "lblAgenciaSemDigito";
            this.lblAgenciaSemDigito.Size = new System.Drawing.Size(101, 13);
            this.lblAgenciaSemDigito.TabIndex = 37;
            this.lblAgenciaSemDigito.Text = "Agência sem dígito:";
            // 
            // lblTituloSolicitacaoReembolso
            // 
            this.lblTituloSolicitacaoReembolso.AutoSize = true;
            this.lblTituloSolicitacaoReembolso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSolicitacaoReembolso.Location = new System.Drawing.Point(96, 7);
            this.lblTituloSolicitacaoReembolso.Name = "lblTituloSolicitacaoReembolso";
            this.lblTituloSolicitacaoReembolso.Size = new System.Drawing.Size(200, 13);
            this.lblTituloSolicitacaoReembolso.TabIndex = 43;
            this.lblTituloSolicitacaoReembolso.Text = "Solicitação de Reembolso Unimed";
            // 
            // txtGerarSolicitacaoReembolso
            // 
            this.txtGerarSolicitacaoReembolso.Location = new System.Drawing.Point(118, 539);
            this.txtGerarSolicitacaoReembolso.Name = "txtGerarSolicitacaoReembolso";
            this.txtGerarSolicitacaoReembolso.Size = new System.Drawing.Size(134, 41);
            this.txtGerarSolicitacaoReembolso.TabIndex = 6;
            this.txtGerarSolicitacaoReembolso.Text = "Gerar solicitação de reembolso";
            this.txtGerarSolicitacaoReembolso.UseVisualStyleBackColor = true;
            this.txtGerarSolicitacaoReembolso.Click += new System.EventHandler(this.btnGerarSolicitacaoReembolso_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 22);
            this.sairToolStripMenuItem.Text = "Sa&ir";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.sobreToolStripMenuItem.Text = "&Sobre...";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // pnlSobre
            // 
            this.pnlSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSobre.Controls.Add(this.pictureBox1);
            this.pnlSobre.Controls.Add(this.btnFecharSobre);
            this.pnlSobre.Controls.Add(this.lblCopyright);
            this.pnlSobre.Controls.Add(this.lblNomeAplicao);
            this.pnlSobre.Location = new System.Drawing.Point(284, 212);
            this.pnlSobre.Margin = new System.Windows.Forms.Padding(1);
            this.pnlSobre.Name = "pnlSobre";
            this.pnlSobre.Size = new System.Drawing.Size(292, 181);
            this.pnlSobre.TabIndex = 45;
            this.pnlSobre.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TerapiaReembolso.Properties.Resources.App;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(250, 39);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 27);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnFecharSobre
            // 
            this.btnFecharSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharSobre.Location = new System.Drawing.Point(114, 127);
            this.btnFecharSobre.Margin = new System.Windows.Forms.Padding(1);
            this.btnFecharSobre.Name = "btnFecharSobre";
            this.btnFecharSobre.Size = new System.Drawing.Size(61, 33);
            this.btnFecharSobre.TabIndex = 2;
            this.btnFecharSobre.Text = "Fechar";
            this.btnFecharSobre.UseVisualStyleBackColor = true;
            this.btnFecharSobre.Click += new System.EventHandler(this.btnFecharSobre_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(59, 84);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(158, 13);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "Copyright © Daniel Liedke 2022";
            // 
            // lblNomeAplicao
            // 
            this.lblNomeAplicao.AutoSize = true;
            this.lblNomeAplicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeAplicao.Location = new System.Drawing.Point(40, 39);
            this.lblNomeAplicao.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNomeAplicao.Name = "lblNomeAplicao";
            this.lblNomeAplicao.Size = new System.Drawing.Size(202, 20);
            this.lblNomeAplicao.TabIndex = 0;
            this.lblNomeAplicao.Text = "Terapia Reembolso v2.3";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 645);
            this.Controls.Add(this.pnlSobre);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlReembolso);
            this.Controls.Add(this.pnlConsultas);
            this.Controls.Add(this.pnlRecibo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSobre.ResumeLayout(false);
            this.pnlSobre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerarRecibo;
        private System.Windows.Forms.DateTimePicker dtDataConsulta1;
        private System.Windows.Forms.MaskedTextBox txtValorConsulta;
        private System.Windows.Forms.Label lblNomeDoPaciente;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblReferenteA;
        private System.Windows.Forms.Label lblReciboAssinado;
        private System.Windows.Forms.Button btnSelecionarPDFRecibo;
        private System.Windows.Forms.OpenFileDialog dialogoPDF;
        private System.Windows.Forms.Label lblCPFPaciente;
        private System.Windows.Forms.TextBox txtCPFPaciente;
        private System.Windows.Forms.Label lblNomeReciboPDF;
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
        private System.Windows.Forms.DateTimePicker dtDataConsulta4;
        private System.Windows.Forms.DateTimePicker dtDataConsulta3;
        private System.Windows.Forms.DateTimePicker dtDataConsulta5;
        private System.Windows.Forms.DateTimePicker dtDataConsulta2;
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
        private System.Windows.Forms.Button txtGerarSolicitacaoReembolso;
        private System.Windows.Forms.Label lblSenhaUnimed;
        private System.Windows.Forms.TextBox txtSenhaUnimed;
        private System.Windows.Forms.Label lblLoginUnimed;
        private System.Windows.Forms.TextBox txtLoginUnimed;
        private System.Windows.Forms.DateTimePicker dtDataConsulta10;
        private System.Windows.Forms.DateTimePicker dtDataConsulta9;
        private System.Windows.Forms.DateTimePicker dtDataConsulta8;
        private System.Windows.Forms.DateTimePicker dtDataConsulta7;
        private System.Windows.Forms.DateTimePicker dtDataConsulta6;
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
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSobre;
        private System.Windows.Forms.Button btnFecharSobre;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblNomeAplicao;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

