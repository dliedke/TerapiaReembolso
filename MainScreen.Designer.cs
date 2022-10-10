namespace TerapiaReembolso
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.btnGerarRecibo = new System.Windows.Forms.Button();
            this.dtDataConsulta1 = new System.Windows.Forms.DateTimePicker();
            this.txtValorTotal = new System.Windows.Forms.MaskedTextBox();
            this.txtNomeDoPaciente = new System.Windows.Forms.TextBox();
            this.lblNomeDoPaciente = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblReferenteA = new System.Windows.Forms.Label();
            this.lblReciboAssinado = new System.Windows.Forms.Label();
            this.btnSelecionarPDFRecibo = new System.Windows.Forms.Button();
            this.dialogPDF = new System.Windows.Forms.OpenFileDialog();
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
            this.btnFecharConsultas = new System.Windows.Forms.Button();
            this.lblNumeroDeConsultas = new System.Windows.Forms.Label();
            this.numNumeroConsultas = new System.Windows.Forms.NumericUpDown();
            this.lblSelecioneDataConsultas = new System.Windows.Forms.Label();
            this.dtDataConsulta4 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta3 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta5 = new System.Windows.Forms.DateTimePicker();
            this.dtDataConsulta2 = new System.Windows.Forms.DateTimePicker();
            this.pnlRecibo = new System.Windows.Forms.Panel();
            this.lblTituloGeracaoRecibo = new System.Windows.Forms.Label();
            this.lblCEP = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.pnlReembolso = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoginUnimed = new System.Windows.Forms.TextBox();
            this.lblSenhaUnimed = new System.Windows.Forms.Label();
            this.txtSenhaUnimed = new System.Windows.Forms.TextBox();
            this.lblTituloSolicitacaoReembolso = new System.Windows.Forms.Label();
            this.grbTipoAtendimento = new System.Windows.Forms.GroupBox();
            this.rbPresencial = new System.Windows.Forms.RadioButton();
            this.rbTelemedicina = new System.Windows.Forms.RadioButton();
            this.lblDigitoDaConta = new System.Windows.Forms.Label();
            this.txtDigitoDaConta = new System.Windows.Forms.TextBox();
            this.lblContaSemDigito = new System.Windows.Forms.Label();
            this.txtContaSemDigito = new System.Windows.Forms.TextBox();
            this.lblAgenciaSemDigito = new System.Windows.Forms.Label();
            this.txtAgenciaSemDigito = new System.Windows.Forms.TextBox();
            this.lblNomeDoBanco = new System.Windows.Forms.Label();
            this.txtNomeDoBanco = new System.Windows.Forms.TextBox();
            this.txtGerarSolicitacaoReembolso = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.pnlConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroConsultas)).BeginInit();
            this.pnlRecibo.SuspendLayout();
            this.pnlReembolso.SuspendLayout();
            this.grbTipoAtendimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerarRecibo
            // 
            this.btnGerarRecibo.Location = new System.Drawing.Point(224, 738);
            this.btnGerarRecibo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGerarRecibo.Name = "btnGerarRecibo";
            this.btnGerarRecibo.Size = new System.Drawing.Size(201, 45);
            this.btnGerarRecibo.TabIndex = 11;
            this.btnGerarRecibo.Text = "Gerar Recibo";
            this.btnGerarRecibo.UseVisualStyleBackColor = true;
            this.btnGerarRecibo.Click += new System.EventHandler(this.btnGerarRecibo_Click);
            // 
            // dtDataConsulta1
            // 
            this.dtDataConsulta1.Location = new System.Drawing.Point(134, 186);
            this.dtDataConsulta1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta1.Name = "dtDataConsulta1";
            this.dtDataConsulta1.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta1.TabIndex = 1;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(210, 131);
            this.txtValorTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(70, 26);
            this.txtValorTotal.TabIndex = 1;
            this.txtValorTotal.ValidatingType = typeof(int);
            // 
            // txtNomeDoPaciente
            // 
            this.txtNomeDoPaciente.Location = new System.Drawing.Point(209, 79);
            this.txtNomeDoPaciente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeDoPaciente.MaxLength = 32;
            this.txtNomeDoPaciente.Name = "txtNomeDoPaciente";
            this.txtNomeDoPaciente.Size = new System.Drawing.Size(333, 26);
            this.txtNomeDoPaciente.TabIndex = 0;
            // 
            // lblNomeDoPaciente
            // 
            this.lblNomeDoPaciente.AutoSize = true;
            this.lblNomeDoPaciente.Location = new System.Drawing.Point(53, 79);
            this.lblNomeDoPaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeDoPaciente.Name = "lblNomeDoPaciente";
            this.lblNomeDoPaciente.Size = new System.Drawing.Size(143, 40);
            this.lblNomeDoPaciente.TabIndex = 4;
            this.lblNomeDoPaciente.Text = "Nome do Paciente:\r\n    (Sem Acentos)";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(92, 135);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(89, 20);
            this.lblValorTotal.TabIndex = 5;
            this.lblValorTotal.Text = "Valor Total:";
            // 
            // lblReferenteA
            // 
            this.lblReferenteA.AutoSize = true;
            this.lblReferenteA.Location = new System.Drawing.Point(88, 233);
            this.lblReferenteA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReferenteA.Name = "lblReferenteA";
            this.lblReferenteA.Size = new System.Drawing.Size(98, 20);
            this.lblReferenteA.TabIndex = 6;
            this.lblReferenteA.Text = "Referente à:";
            this.lblReferenteA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReciboAssinado
            // 
            this.lblReciboAssinado.AutoSize = true;
            this.lblReciboAssinado.Location = new System.Drawing.Point(32, 186);
            this.lblReciboAssinado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReciboAssinado.Name = "lblReciboAssinado";
            this.lblReciboAssinado.Size = new System.Drawing.Size(133, 20);
            this.lblReciboAssinado.TabIndex = 7;
            this.lblReciboAssinado.Text = "Recibo Assinado:";
            // 
            // btnSelecionarPDFRecibo
            // 
            this.btnSelecionarPDFRecibo.Location = new System.Drawing.Point(178, 178);
            this.btnSelecionarPDFRecibo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelecionarPDFRecibo.Name = "btnSelecionarPDFRecibo";
            this.btnSelecionarPDFRecibo.Size = new System.Drawing.Size(190, 35);
            this.btnSelecionarPDFRecibo.TabIndex = 1;
            this.btnSelecionarPDFRecibo.Text = "Selecionar PDF Recibo";
            this.btnSelecionarPDFRecibo.UseVisualStyleBackColor = true;
            this.btnSelecionarPDFRecibo.Click += new System.EventHandler(this.btnSelectPDF_Click);
            // 
            // dialogPDF
            // 
            this.dialogPDF.Filter = "PDF files|*.pdf";
            // 
            // lblCPFPaciente
            // 
            this.lblCPFPaciente.AutoSize = true;
            this.lblCPFPaciente.Location = new System.Drawing.Point(74, 184);
            this.lblCPFPaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCPFPaciente.Name = "lblCPFPaciente";
            this.lblCPFPaciente.Size = new System.Drawing.Size(110, 20);
            this.lblCPFPaciente.TabIndex = 10;
            this.lblCPFPaciente.Text = "CPF Paciente:";
            // 
            // txtCPFPaciente
            // 
            this.txtCPFPaciente.Location = new System.Drawing.Point(206, 180);
            this.txtCPFPaciente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCPFPaciente.MaxLength = 11;
            this.txtCPFPaciente.Name = "txtCPFPaciente";
            this.txtCPFPaciente.Size = new System.Drawing.Size(334, 26);
            this.txtCPFPaciente.TabIndex = 2;
            this.txtCPFPaciente.TextChanged += new System.EventHandler(this.txtCPFPaciente_TextChanged);
            // 
            // lblNomeReciboPDF
            // 
            this.lblNomeReciboPDF.AutoSize = true;
            this.lblNomeReciboPDF.Location = new System.Drawing.Point(384, 182);
            this.lblNomeReciboPDF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeReciboPDF.Name = "lblNomeReciboPDF";
            this.lblNomeReciboPDF.Size = new System.Drawing.Size(0, 20);
            this.lblNomeReciboPDF.TabIndex = 11;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 834);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1214, 32);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 12;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(45, 25);
            this.toolStripStatus.Text = "Idle.";
            // 
            // lnkAssinarPDF
            // 
            this.lnkAssinarPDF.AutoSize = true;
            this.lnkAssinarPDF.Location = new System.Drawing.Point(496, 4);
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
            this.txtReferenteA.Location = new System.Drawing.Point(206, 233);
            this.txtReferenteA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReferenteA.MaxLength = 32;
            this.txtReferenteA.Name = "txtReferenteA";
            this.txtReferenteA.Size = new System.Drawing.Size(333, 26);
            this.txtReferenteA.TabIndex = 3;
            // 
            // lblNomeDoTerapeuta
            // 
            this.lblNomeDoTerapeuta.AutoSize = true;
            this.lblNomeDoTerapeuta.Location = new System.Drawing.Point(29, 349);
            this.lblNomeDoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeDoTerapeuta.Name = "lblNomeDoTerapeuta";
            this.lblNomeDoTerapeuta.Size = new System.Drawing.Size(154, 20);
            this.lblNomeDoTerapeuta.TabIndex = 27;
            this.lblNomeDoTerapeuta.Text = "Nome do Terapeuta:";
            // 
            // txtNomeDoTerapeuta
            // 
            this.txtNomeDoTerapeuta.Location = new System.Drawing.Point(202, 347);
            this.txtNomeDoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeDoTerapeuta.MaxLength = 32;
            this.txtNomeDoTerapeuta.Name = "txtNomeDoTerapeuta";
            this.txtNomeDoTerapeuta.Size = new System.Drawing.Size(339, 26);
            this.txtNomeDoTerapeuta.TabIndex = 5;
            // 
            // lblCPFTerapeuta
            // 
            this.lblCPFTerapeuta.AutoSize = true;
            this.lblCPFTerapeuta.Location = new System.Drawing.Point(64, 399);
            this.lblCPFTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCPFTerapeuta.Name = "lblCPFTerapeuta";
            this.lblCPFTerapeuta.Size = new System.Drawing.Size(121, 20);
            this.lblCPFTerapeuta.TabIndex = 29;
            this.lblCPFTerapeuta.Text = "CPF Terapeuta:";
            // 
            // txtCPFTerapeuta
            // 
            this.txtCPFTerapeuta.Location = new System.Drawing.Point(202, 399);
            this.txtCPFTerapeuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCPFTerapeuta.MaxLength = 11;
            this.txtCPFTerapeuta.Name = "txtCPFTerapeuta";
            this.txtCPFTerapeuta.Size = new System.Drawing.Size(339, 26);
            this.txtCPFTerapeuta.TabIndex = 6;
            this.txtCPFTerapeuta.TextChanged += new System.EventHandler(this.txtCPFTerapeuta_TextChanged);
            // 
            // lblEnderecoTerapeuta
            // 
            this.lblEnderecoTerapeuta.AutoSize = true;
            this.lblEnderecoTerapeuta.Location = new System.Drawing.Point(32, 544);
            this.lblEnderecoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnderecoTerapeuta.Name = "lblEnderecoTerapeuta";
            this.lblEnderecoTerapeuta.Size = new System.Drawing.Size(159, 20);
            this.lblEnderecoTerapeuta.TabIndex = 31;
            this.lblEnderecoTerapeuta.Text = "Endereço Terapeuta:";
            // 
            // txtEnderecoTerapeuta
            // 
            this.txtEnderecoTerapeuta.Location = new System.Drawing.Point(204, 542);
            this.txtEnderecoTerapeuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnderecoTerapeuta.Multiline = true;
            this.txtEnderecoTerapeuta.Name = "txtEnderecoTerapeuta";
            this.txtEnderecoTerapeuta.Size = new System.Drawing.Size(338, 101);
            this.txtEnderecoTerapeuta.TabIndex = 9;
            // 
            // lblCRP
            // 
            this.lblCRP.AutoSize = true;
            this.lblCRP.Location = new System.Drawing.Point(53, 446);
            this.lblCRP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCRP.Name = "lblCRP";
            this.lblCRP.Size = new System.Drawing.Size(128, 20);
            this.lblCRP.TabIndex = 33;
            this.lblCRP.Text = "Número do CRP:";
            // 
            // txtCRP
            // 
            this.txtCRP.Location = new System.Drawing.Point(203, 446);
            this.txtCRP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCRP.MaxLength = 32;
            this.txtCRP.Name = "txtCRP";
            this.txtCRP.Size = new System.Drawing.Size(338, 26);
            this.txtCRP.TabIndex = 7;
            // 
            // btnSelecionarConsultas
            // 
            this.btnSelecionarConsultas.Location = new System.Drawing.Point(224, 666);
            this.btnSelecionarConsultas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelecionarConsultas.Name = "btnSelecionarConsultas";
            this.btnSelecionarConsultas.Size = new System.Drawing.Size(201, 45);
            this.btnSelecionarConsultas.TabIndex = 10;
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
            this.pnlConsultas.Controls.Add(this.btnFecharConsultas);
            this.pnlConsultas.Controls.Add(this.lblNumeroDeConsultas);
            this.pnlConsultas.Controls.Add(this.numNumeroConsultas);
            this.pnlConsultas.Controls.Add(this.lblSelecioneDataConsultas);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta4);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta3);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta5);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta2);
            this.pnlConsultas.Controls.Add(this.dtDataConsulta1);
            this.pnlConsultas.Location = new System.Drawing.Point(7, 8);
            this.pnlConsultas.Margin = new System.Windows.Forms.Padding(2);
            this.pnlConsultas.Name = "pnlConsultas";
            this.pnlConsultas.Size = new System.Drawing.Size(602, 801);
            this.pnlConsultas.TabIndex = 35;
            // 
            // lbDiaSemana
            // 
            this.lbDiaSemana.AutoSize = true;
            this.lbDiaSemana.Location = new System.Drawing.Point(252, 19);
            this.lbDiaSemana.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDiaSemana.Name = "lbDiaSemana";
            this.lbDiaSemana.Size = new System.Drawing.Size(123, 20);
            this.lbDiaSemana.TabIndex = 48;
            this.lbDiaSemana.Text = "Dia da Semana:";
            // 
            // lbMes
            // 
            this.lbMes.AutoSize = true;
            this.lbMes.Location = new System.Drawing.Point(16, 19);
            this.lbMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMes.Name = "lbMes";
            this.lbMes.Size = new System.Drawing.Size(43, 20);
            this.lbMes.TabIndex = 47;
            this.lbMes.Text = "Mes:";
            // 
            // cmbDiaSemana
            // 
            this.cmbDiaSemana.DisplayMember = "Name";
            this.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaSemana.FormattingEnabled = true;
            this.cmbDiaSemana.Location = new System.Drawing.Point(382, 16);
            this.cmbDiaSemana.Name = "cmbDiaSemana";
            this.cmbDiaSemana.Size = new System.Drawing.Size(180, 28);
            this.cmbDiaSemana.TabIndex = 46;
            this.cmbDiaSemana.ValueMember = "Value";
            this.cmbDiaSemana.SelectedIndexChanged += new System.EventHandler(this.cmbDiaSemana_SelectedIndexChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.DisplayMember = "Name";
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(65, 16);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(169, 28);
            this.cmbMes.TabIndex = 45;
            this.cmbMes.ValueMember = "Value";
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // dtDataConsulta10
            // 
            this.dtDataConsulta10.Location = new System.Drawing.Point(134, 680);
            this.dtDataConsulta10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta10.Name = "dtDataConsulta10";
            this.dtDataConsulta10.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta10.TabIndex = 44;
            // 
            // dtDataConsulta9
            // 
            this.dtDataConsulta9.Location = new System.Drawing.Point(134, 632);
            this.dtDataConsulta9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta9.Name = "dtDataConsulta9";
            this.dtDataConsulta9.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta9.TabIndex = 43;
            // 
            // dtDataConsulta8
            // 
            this.dtDataConsulta8.Location = new System.Drawing.Point(134, 580);
            this.dtDataConsulta8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta8.Name = "dtDataConsulta8";
            this.dtDataConsulta8.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta8.TabIndex = 42;
            // 
            // dtDataConsulta7
            // 
            this.dtDataConsulta7.Location = new System.Drawing.Point(134, 527);
            this.dtDataConsulta7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta7.Name = "dtDataConsulta7";
            this.dtDataConsulta7.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta7.TabIndex = 41;
            // 
            // dtDataConsulta6
            // 
            this.dtDataConsulta6.Location = new System.Drawing.Point(134, 473);
            this.dtDataConsulta6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta6.Name = "dtDataConsulta6";
            this.dtDataConsulta6.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta6.TabIndex = 40;
            // 
            // btnFecharConsultas
            // 
            this.btnFecharConsultas.Location = new System.Drawing.Point(174, 738);
            this.btnFecharConsultas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFecharConsultas.Name = "btnFecharConsultas";
            this.btnFecharConsultas.Size = new System.Drawing.Size(201, 45);
            this.btnFecharConsultas.TabIndex = 6;
            this.btnFecharConsultas.Text = "Fechar";
            this.btnFecharConsultas.UseVisualStyleBackColor = true;
            this.btnFecharConsultas.Click += new System.EventHandler(this.btnFecharConsultas_Click);
            // 
            // lblNumeroDeConsultas
            // 
            this.lblNumeroDeConsultas.AutoSize = true;
            this.lblNumeroDeConsultas.Location = new System.Drawing.Point(192, 82);
            this.lblNumeroDeConsultas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroDeConsultas.Name = "lblNumeroDeConsultas";
            this.lblNumeroDeConsultas.Size = new System.Drawing.Size(166, 20);
            this.lblNumeroDeConsultas.TabIndex = 39;
            this.lblNumeroDeConsultas.Text = "Número de Consultas:";
            // 
            // numNumeroConsultas
            // 
            this.numNumeroConsultas.Location = new System.Drawing.Point(363, 82);
            this.numNumeroConsultas.Margin = new System.Windows.Forms.Padding(2);
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
            this.numNumeroConsultas.TabIndex = 0;
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
            this.lblSelecioneDataConsultas.Location = new System.Drawing.Point(196, 141);
            this.lblSelecioneDataConsultas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelecioneDataConsultas.Name = "lblSelecioneDataConsultas";
            this.lblSelecioneDataConsultas.Size = new System.Drawing.Size(229, 20);
            this.lblSelecioneDataConsultas.TabIndex = 37;
            this.lblSelecioneDataConsultas.Text = "Selecione datas das consultas:";
            // 
            // dtDataConsulta4
            // 
            this.dtDataConsulta4.Location = new System.Drawing.Point(134, 357);
            this.dtDataConsulta4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta4.Name = "dtDataConsulta4";
            this.dtDataConsulta4.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta4.TabIndex = 4;
            // 
            // dtDataConsulta3
            // 
            this.dtDataConsulta3.Location = new System.Drawing.Point(134, 299);
            this.dtDataConsulta3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta3.Name = "dtDataConsulta3";
            this.dtDataConsulta3.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta3.TabIndex = 3;
            // 
            // dtDataConsulta5
            // 
            this.dtDataConsulta5.Location = new System.Drawing.Point(134, 414);
            this.dtDataConsulta5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta5.Name = "dtDataConsulta5";
            this.dtDataConsulta5.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta5.TabIndex = 5;
            // 
            // dtDataConsulta2
            // 
            this.dtDataConsulta2.Location = new System.Drawing.Point(134, 243);
            this.dtDataConsulta2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDataConsulta2.Name = "dtDataConsulta2";
            this.dtDataConsulta2.Size = new System.Drawing.Size(343, 26);
            this.dtDataConsulta2.TabIndex = 2;
            // 
            // pnlRecibo
            // 
            this.pnlRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRecibo.Controls.Add(this.lblTituloGeracaoRecibo);
            this.pnlRecibo.Controls.Add(this.lblCEP);
            this.pnlRecibo.Controls.Add(this.txtCEP);
            this.pnlRecibo.Controls.Add(this.lnkAssinarPDF);
            this.pnlRecibo.Controls.Add(this.btnGerarRecibo);
            this.pnlRecibo.Controls.Add(this.btnSelecionarConsultas);
            this.pnlRecibo.Controls.Add(this.txtValorTotal);
            this.pnlRecibo.Controls.Add(this.lblCRP);
            this.pnlRecibo.Controls.Add(this.txtNomeDoPaciente);
            this.pnlRecibo.Controls.Add(this.txtCRP);
            this.pnlRecibo.Controls.Add(this.lblNomeDoPaciente);
            this.pnlRecibo.Controls.Add(this.lblEnderecoTerapeuta);
            this.pnlRecibo.Controls.Add(this.lblValorTotal);
            this.pnlRecibo.Controls.Add(this.txtEnderecoTerapeuta);
            this.pnlRecibo.Controls.Add(this.lblReferenteA);
            this.pnlRecibo.Controls.Add(this.lblCPFTerapeuta);
            this.pnlRecibo.Controls.Add(this.txtCPFPaciente);
            this.pnlRecibo.Controls.Add(this.txtCPFTerapeuta);
            this.pnlRecibo.Controls.Add(this.lblCPFPaciente);
            this.pnlRecibo.Controls.Add(this.lblNomeDoTerapeuta);
            this.pnlRecibo.Controls.Add(this.txtNomeDoTerapeuta);
            this.pnlRecibo.Controls.Add(this.txtCidade);
            this.pnlRecibo.Controls.Add(this.txtReferenteA);
            this.pnlRecibo.Controls.Add(this.lblCidade);
            this.pnlRecibo.Location = new System.Drawing.Point(7, 8);
            this.pnlRecibo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRecibo.Name = "pnlRecibo";
            this.pnlRecibo.Size = new System.Drawing.Size(600, 801);
            this.pnlRecibo.TabIndex = 36;
            // 
            // lblTituloGeracaoRecibo
            // 
            this.lblTituloGeracaoRecibo.AutoSize = true;
            this.lblTituloGeracaoRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGeracaoRecibo.Location = new System.Drawing.Point(192, 22);
            this.lblTituloGeracaoRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloGeracaoRecibo.Name = "lblTituloGeracaoRecibo";
            this.lblTituloGeracaoRecibo.Size = new System.Drawing.Size(239, 20);
            this.lblTituloGeracaoRecibo.TabIndex = 44;
            this.lblTituloGeracaoRecibo.Text = "Geração de Recibo Terapia";
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(61, 495);
            this.lblCEP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(122, 20);
            this.lblCEP.TabIndex = 36;
            this.lblCEP.Text = "CEP Terapeuta:";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(202, 495);
            this.txtCEP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCEP.MaxLength = 8;
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(338, 26);
            this.txtCEP.TabIndex = 8;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(205, 286);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCidade.MaxLength = 32;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(335, 26);
            this.txtCidade.TabIndex = 4;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(118, 289);
            this.lblCidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(63, 20);
            this.lblCidade.TabIndex = 14;
            this.lblCidade.Text = "Cidade:";
            // 
            // pnlReembolso
            // 
            this.pnlReembolso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReembolso.Controls.Add(this.label1);
            this.pnlReembolso.Controls.Add(this.txtLoginUnimed);
            this.pnlReembolso.Controls.Add(this.lblNomeReciboPDF);
            this.pnlReembolso.Controls.Add(this.lblSenhaUnimed);
            this.pnlReembolso.Controls.Add(this.txtSenhaUnimed);
            this.pnlReembolso.Controls.Add(this.lblTituloSolicitacaoReembolso);
            this.pnlReembolso.Controls.Add(this.grbTipoAtendimento);
            this.pnlReembolso.Controls.Add(this.lblDigitoDaConta);
            this.pnlReembolso.Controls.Add(this.txtDigitoDaConta);
            this.pnlReembolso.Controls.Add(this.lblContaSemDigito);
            this.pnlReembolso.Controls.Add(this.txtContaSemDigito);
            this.pnlReembolso.Controls.Add(this.lblAgenciaSemDigito);
            this.pnlReembolso.Controls.Add(this.txtAgenciaSemDigito);
            this.pnlReembolso.Controls.Add(this.lblNomeDoBanco);
            this.pnlReembolso.Controls.Add(this.txtNomeDoBanco);
            this.pnlReembolso.Controls.Add(this.txtGerarSolicitacaoReembolso);
            this.pnlReembolso.Controls.Add(this.lblReciboAssinado);
            this.pnlReembolso.Controls.Add(this.btnSelecionarPDFRecibo);
            this.pnlReembolso.Location = new System.Drawing.Point(621, 8);
            this.pnlReembolso.Margin = new System.Windows.Forms.Padding(2);
            this.pnlReembolso.Name = "pnlReembolso";
            this.pnlReembolso.Size = new System.Drawing.Size(581, 801);
            this.pnlReembolso.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Login Unimed (CPF):";
            // 
            // txtLoginUnimed
            // 
            this.txtLoginUnimed.Location = new System.Drawing.Point(178, 68);
            this.txtLoginUnimed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLoginUnimed.MaxLength = 11;
            this.txtLoginUnimed.Name = "txtLoginUnimed";
            this.txtLoginUnimed.Size = new System.Drawing.Size(338, 26);
            this.txtLoginUnimed.TabIndex = 46;
            this.txtLoginUnimed.TextChanged += new System.EventHandler(this.txtLoginUnimed_TextChanged);
            // 
            // lblSenhaUnimed
            // 
            this.lblSenhaUnimed.AutoSize = true;
            this.lblSenhaUnimed.Location = new System.Drawing.Point(44, 122);
            this.lblSenhaUnimed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenhaUnimed.Name = "lblSenhaUnimed";
            this.lblSenhaUnimed.Size = new System.Drawing.Size(119, 20);
            this.lblSenhaUnimed.TabIndex = 45;
            this.lblSenhaUnimed.Text = "Senha Unimed:";
            // 
            // txtSenhaUnimed
            // 
            this.txtSenhaUnimed.Location = new System.Drawing.Point(178, 120);
            this.txtSenhaUnimed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSenhaUnimed.MaxLength = 32;
            this.txtSenhaUnimed.Name = "txtSenhaUnimed";
            this.txtSenhaUnimed.PasswordChar = '*';
            this.txtSenhaUnimed.Size = new System.Drawing.Size(338, 26);
            this.txtSenhaUnimed.TabIndex = 0;
            // 
            // lblTituloSolicitacaoReembolso
            // 
            this.lblTituloSolicitacaoReembolso.AutoSize = true;
            this.lblTituloSolicitacaoReembolso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSolicitacaoReembolso.Location = new System.Drawing.Point(159, 22);
            this.lblTituloSolicitacaoReembolso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloSolicitacaoReembolso.Name = "lblTituloSolicitacaoReembolso";
            this.lblTituloSolicitacaoReembolso.Size = new System.Drawing.Size(296, 20);
            this.lblTituloSolicitacaoReembolso.TabIndex = 43;
            this.lblTituloSolicitacaoReembolso.Text = "Solicitação de Reembolso Unimed";
            // 
            // grbTipoAtendimento
            // 
            this.grbTipoAtendimento.Controls.Add(this.rbPresencial);
            this.grbTipoAtendimento.Controls.Add(this.rbTelemedicina);
            this.grbTipoAtendimento.Location = new System.Drawing.Point(27, 243);
            this.grbTipoAtendimento.Margin = new System.Windows.Forms.Padding(2);
            this.grbTipoAtendimento.Name = "grbTipoAtendimento";
            this.grbTipoAtendimento.Padding = new System.Windows.Forms.Padding(2);
            this.grbTipoAtendimento.Size = new System.Drawing.Size(173, 126);
            this.grbTipoAtendimento.TabIndex = 42;
            this.grbTipoAtendimento.TabStop = false;
            this.grbTipoAtendimento.Text = "Tipo de Atendimento";
            // 
            // rbPresencial
            // 
            this.rbPresencial.AutoSize = true;
            this.rbPresencial.Location = new System.Drawing.Point(24, 37);
            this.rbPresencial.Margin = new System.Windows.Forms.Padding(2);
            this.rbPresencial.Name = "rbPresencial";
            this.rbPresencial.Size = new System.Drawing.Size(107, 24);
            this.rbPresencial.TabIndex = 0;
            this.rbPresencial.TabStop = true;
            this.rbPresencial.Text = "Presencial";
            this.rbPresencial.UseVisualStyleBackColor = true;
            // 
            // rbTelemedicina
            // 
            this.rbTelemedicina.AutoSize = true;
            this.rbTelemedicina.Location = new System.Drawing.Point(24, 77);
            this.rbTelemedicina.Margin = new System.Windows.Forms.Padding(2);
            this.rbTelemedicina.Name = "rbTelemedicina";
            this.rbTelemedicina.Size = new System.Drawing.Size(127, 24);
            this.rbTelemedicina.TabIndex = 1;
            this.rbTelemedicina.TabStop = true;
            this.rbTelemedicina.Text = "Telemedicina";
            this.rbTelemedicina.UseVisualStyleBackColor = true;
            // 
            // lblDigitoDaConta
            // 
            this.lblDigitoDaConta.AutoSize = true;
            this.lblDigitoDaConta.Location = new System.Drawing.Point(45, 570);
            this.lblDigitoDaConta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDigitoDaConta.Name = "lblDigitoDaConta";
            this.lblDigitoDaConta.Size = new System.Drawing.Size(120, 20);
            this.lblDigitoDaConta.TabIndex = 41;
            this.lblDigitoDaConta.Text = "Dígito da conta:";
            // 
            // txtDigitoDaConta
            // 
            this.txtDigitoDaConta.Location = new System.Drawing.Point(179, 570);
            this.txtDigitoDaConta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDigitoDaConta.MaxLength = 32;
            this.txtDigitoDaConta.Name = "txtDigitoDaConta";
            this.txtDigitoDaConta.Size = new System.Drawing.Size(338, 26);
            this.txtDigitoDaConta.TabIndex = 5;
            // 
            // lblContaSemDigito
            // 
            this.lblContaSemDigito.AutoSize = true;
            this.lblContaSemDigito.Location = new System.Drawing.Point(31, 521);
            this.lblContaSemDigito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContaSemDigito.Name = "lblContaSemDigito";
            this.lblContaSemDigito.Size = new System.Drawing.Size(132, 20);
            this.lblContaSemDigito.TabIndex = 39;
            this.lblContaSemDigito.Text = "Conta sem dígito:";
            // 
            // txtContaSemDigito
            // 
            this.txtContaSemDigito.Location = new System.Drawing.Point(178, 517);
            this.txtContaSemDigito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContaSemDigito.MaxLength = 32;
            this.txtContaSemDigito.Name = "txtContaSemDigito";
            this.txtContaSemDigito.Size = new System.Drawing.Size(338, 26);
            this.txtContaSemDigito.TabIndex = 4;
            // 
            // lblAgenciaSemDigito
            // 
            this.lblAgenciaSemDigito.AutoSize = true;
            this.lblAgenciaSemDigito.Location = new System.Drawing.Point(23, 464);
            this.lblAgenciaSemDigito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgenciaSemDigito.Name = "lblAgenciaSemDigito";
            this.lblAgenciaSemDigito.Size = new System.Drawing.Size(147, 20);
            this.lblAgenciaSemDigito.TabIndex = 37;
            this.lblAgenciaSemDigito.Text = "Agência sem dígito:";
            // 
            // txtAgenciaSemDigito
            // 
            this.txtAgenciaSemDigito.Location = new System.Drawing.Point(179, 464);
            this.txtAgenciaSemDigito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAgenciaSemDigito.MaxLength = 32;
            this.txtAgenciaSemDigito.Name = "txtAgenciaSemDigito";
            this.txtAgenciaSemDigito.Size = new System.Drawing.Size(338, 26);
            this.txtAgenciaSemDigito.TabIndex = 3;
            // 
            // lblNomeDoBanco
            // 
            this.lblNomeDoBanco.AutoSize = true;
            this.lblNomeDoBanco.Location = new System.Drawing.Point(43, 413);
            this.lblNomeDoBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeDoBanco.Name = "lblNomeDoBanco";
            this.lblNomeDoBanco.Size = new System.Drawing.Size(127, 20);
            this.lblNomeDoBanco.TabIndex = 35;
            this.lblNomeDoBanco.Text = "Nome do Banco:";
            // 
            // txtNomeDoBanco
            // 
            this.txtNomeDoBanco.Location = new System.Drawing.Point(177, 411);
            this.txtNomeDoBanco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeDoBanco.MaxLength = 32;
            this.txtNomeDoBanco.Name = "txtNomeDoBanco";
            this.txtNomeDoBanco.Size = new System.Drawing.Size(338, 26);
            this.txtNomeDoBanco.TabIndex = 2;
            // 
            // txtGerarSolicitacaoReembolso
            // 
            this.txtGerarSolicitacaoReembolso.Location = new System.Drawing.Point(177, 711);
            this.txtGerarSolicitacaoReembolso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGerarSolicitacaoReembolso.Name = "txtGerarSolicitacaoReembolso";
            this.txtGerarSolicitacaoReembolso.Size = new System.Drawing.Size(201, 72);
            this.txtGerarSolicitacaoReembolso.TabIndex = 6;
            this.txtGerarSolicitacaoReembolso.Text = "Gerar solicitação de reembolso";
            this.txtGerarSolicitacaoReembolso.UseVisualStyleBackColor = true;
            this.txtGerarSolicitacaoReembolso.Click += new System.EventHandler(this.btnGerarSolicitacaoReembolso_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 866);
            this.Controls.Add(this.pnlReembolso);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlRecibo);
            this.Controls.Add(this.pnlConsultas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainScreen";
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
            this.pnlReembolso.ResumeLayout(false);
            this.pnlReembolso.PerformLayout();
            this.grbTipoAtendimento.ResumeLayout(false);
            this.grbTipoAtendimento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerarRecibo;
        private System.Windows.Forms.DateTimePicker dtDataConsulta1;
        private System.Windows.Forms.MaskedTextBox txtValorTotal;
        private System.Windows.Forms.TextBox txtNomeDoPaciente;
        private System.Windows.Forms.Label lblNomeDoPaciente;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblReferenteA;
        private System.Windows.Forms.Label lblReciboAssinado;
        private System.Windows.Forms.Button btnSelecionarPDFRecibo;
        private System.Windows.Forms.OpenFileDialog dialogPDF;
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
        private System.Windows.Forms.Button btnFecharConsultas;
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
        private System.Windows.Forms.Label label1;
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
    }
}

