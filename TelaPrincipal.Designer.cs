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
            this.btnGerarRecibo.Location = new System.Drawing.Point(347, 1285);
            this.btnGerarRecibo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnGerarRecibo.Name = "btnGerarRecibo";
            this.btnGerarRecibo.Size = new System.Drawing.Size(357, 81);
            this.btnGerarRecibo.TabIndex = 11;
            this.btnGerarRecibo.Text = "Gerar Recibo";
            this.btnGerarRecibo.UseVisualStyleBackColor = true;
            this.btnGerarRecibo.Click += new System.EventHandler(this.btnGerarRecibo_Click);
            // 
            // dtDataConsulta1
            // 
            this.dtDataConsulta1.Location = new System.Drawing.Point(237, 289);
            this.dtDataConsulta1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta1.Name = "dtDataConsulta1";
            this.dtDataConsulta1.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta1.TabIndex = 3;
            // 
            // txtValorConsulta
            // 
            this.txtValorConsulta.Location = new System.Drawing.Point(352, 157);
            this.txtValorConsulta.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtValorConsulta.Name = "txtValorConsulta";
            this.txtValorConsulta.Size = new System.Drawing.Size(121, 38);
            this.txtValorConsulta.TabIndex = 4;
            this.txtValorConsulta.ValidatingType = typeof(int);
            this.txtValorConsulta.TextChanged += new System.EventHandler(this.txtValorConsulta_TextChanged);
            // 
            // lblNomeDoPaciente
            // 
            this.lblNomeDoPaciente.Location = new System.Drawing.Point(232, 83);
            this.lblNomeDoPaciente.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNomeDoPaciente.Name = "lblNomeDoPaciente";
            this.lblNomeDoPaciente.Size = new System.Drawing.Size(115, 57);
            this.lblNomeDoPaciente.TabIndex = 4;
            this.lblNomeDoPaciente.Text = "Nome:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(128, 162);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(209, 32);
            this.lblValorTotal.TabIndex = 5;
            this.lblValorTotal.Text = "Valor Consulta:";
            // 
            // lblReferenteA
            // 
            this.lblReferenteA.AutoSize = true;
            this.lblReferenteA.Location = new System.Drawing.Point(152, 303);
            this.lblReferenteA.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblReferenteA.Name = "lblReferenteA";
            this.lblReferenteA.Size = new System.Drawing.Size(170, 32);
            this.lblReferenteA.TabIndex = 6;
            this.lblReferenteA.Text = "Referente à:";
            this.lblReferenteA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReciboAssinado
            // 
            this.lblReciboAssinado.AutoSize = true;
            this.lblReciboAssinado.Location = new System.Drawing.Point(59, 298);
            this.lblReciboAssinado.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblReciboAssinado.Name = "lblReciboAssinado";
            this.lblReciboAssinado.Size = new System.Drawing.Size(236, 32);
            this.lblReciboAssinado.TabIndex = 7;
            this.lblReciboAssinado.Text = "Recibo Assinado:";
            // 
            // btnSelecionarPDFRecibo
            // 
            this.btnSelecionarPDFRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarPDFRecibo.Location = new System.Drawing.Point(317, 286);
            this.btnSelecionarPDFRecibo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSelecionarPDFRecibo.Name = "btnSelecionarPDFRecibo";
            this.btnSelecionarPDFRecibo.Size = new System.Drawing.Size(339, 55);
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
            this.lblCPFPaciente.Location = new System.Drawing.Point(245, 231);
            this.lblCPFPaciente.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCPFPaciente.Name = "lblCPFPaciente";
            this.lblCPFPaciente.Size = new System.Drawing.Size(78, 32);
            this.lblCPFPaciente.TabIndex = 10;
            this.lblCPFPaciente.Text = "CPF:";
            // 
            // txtCPFPaciente
            // 
            this.txtCPFPaciente.Location = new System.Drawing.Point(352, 231);
            this.txtCPFPaciente.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCPFPaciente.MaxLength = 16;
            this.txtCPFPaciente.Name = "txtCPFPaciente";
            this.txtCPFPaciente.Size = new System.Drawing.Size(583, 38);
            this.txtCPFPaciente.TabIndex = 5;
            this.txtCPFPaciente.TextChanged += new System.EventHandler(this.txtCPFPaciente_TextChanged);
            // 
            // lblNomeReciboPDF
            // 
            this.lblNomeReciboPDF.AutoSize = true;
            this.lblNomeReciboPDF.Location = new System.Drawing.Point(683, 291);
            this.lblNomeReciboPDF.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNomeReciboPDF.Name = "lblNomeReciboPDF";
            this.lblNomeReciboPDF.Size = new System.Drawing.Size(0, 32);
            this.lblNomeReciboPDF.TabIndex = 11;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 1484);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(5, 0, 37, 0);
            this.statusStrip.Size = new System.Drawing.Size(2176, 54);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 12;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(74, 41);
            this.toolStripStatus.Text = "Idle.";
            // 
            // lnkAssinarPDF
            // 
            this.lnkAssinarPDF.AutoSize = true;
            this.lnkAssinarPDF.Location = new System.Drawing.Point(856, 17);
            this.lnkAssinarPDF.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lnkAssinarPDF.Name = "lnkAssinarPDF";
            this.lnkAssinarPDF.Size = new System.Drawing.Size(172, 32);
            this.lnkAssinarPDF.TabIndex = 24;
            this.lnkAssinarPDF.TabStop = true;
            this.lnkAssinarPDF.Text = "Assinar PDF";
            this.lnkAssinarPDF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAssinarPDF_LinkClicked);
            // 
            // txtReferenteA
            // 
            this.txtReferenteA.Location = new System.Drawing.Point(347, 303);
            this.txtReferenteA.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtReferenteA.MaxLength = 32;
            this.txtReferenteA.Name = "txtReferenteA";
            this.txtReferenteA.Size = new System.Drawing.Size(588, 38);
            this.txtReferenteA.TabIndex = 6;
            // 
            // lblNomeDoTerapeuta
            // 
            this.lblNomeDoTerapeuta.AutoSize = true;
            this.lblNomeDoTerapeuta.Location = new System.Drawing.Point(200, 153);
            this.lblNomeDoTerapeuta.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNomeDoTerapeuta.Name = "lblNomeDoTerapeuta";
            this.lblNomeDoTerapeuta.Size = new System.Drawing.Size(97, 32);
            this.lblNomeDoTerapeuta.TabIndex = 27;
            this.lblNomeDoTerapeuta.Text = "Nome:";
            // 
            // txtNomeDoTerapeuta
            // 
            this.txtNomeDoTerapeuta.Location = new System.Drawing.Point(339, 154);
            this.txtNomeDoTerapeuta.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtNomeDoTerapeuta.MaxLength = 32;
            this.txtNomeDoTerapeuta.Name = "txtNomeDoTerapeuta";
            this.txtNomeDoTerapeuta.Size = new System.Drawing.Size(601, 38);
            this.txtNomeDoTerapeuta.TabIndex = 1;
            // 
            // lblCPFTerapeuta
            // 
            this.lblCPFTerapeuta.AutoSize = true;
            this.lblCPFTerapeuta.Location = new System.Drawing.Point(219, 231);
            this.lblCPFTerapeuta.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCPFTerapeuta.Name = "lblCPFTerapeuta";
            this.lblCPFTerapeuta.Size = new System.Drawing.Size(78, 32);
            this.lblCPFTerapeuta.TabIndex = 29;
            this.lblCPFTerapeuta.Text = "CPF:";
            // 
            // txtCPFTerapeuta
            // 
            this.txtCPFTerapeuta.Location = new System.Drawing.Point(339, 233);
            this.txtCPFTerapeuta.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCPFTerapeuta.MaxLength = 16;
            this.txtCPFTerapeuta.Name = "txtCPFTerapeuta";
            this.txtCPFTerapeuta.Size = new System.Drawing.Size(601, 38);
            this.txtCPFTerapeuta.TabIndex = 2;
            this.txtCPFTerapeuta.TextChanged += new System.EventHandler(this.txtCPFTerapeuta_TextChanged);
            // 
            // lblEnderecoTerapeuta
            // 
            this.lblEnderecoTerapeuta.AutoSize = true;
            this.lblEnderecoTerapeuta.Location = new System.Drawing.Point(152, 458);
            this.lblEnderecoTerapeuta.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblEnderecoTerapeuta.Name = "lblEnderecoTerapeuta";
            this.lblEnderecoTerapeuta.Size = new System.Drawing.Size(144, 32);
            this.lblEnderecoTerapeuta.TabIndex = 31;
            this.lblEnderecoTerapeuta.Text = "Endereço:";
            // 
            // txtEnderecoTerapeuta
            // 
            this.txtEnderecoTerapeuta.Location = new System.Drawing.Point(339, 453);
            this.txtEnderecoTerapeuta.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtEnderecoTerapeuta.Multiline = true;
            this.txtEnderecoTerapeuta.Name = "txtEnderecoTerapeuta";
            this.txtEnderecoTerapeuta.Size = new System.Drawing.Size(599, 154);
            this.txtEnderecoTerapeuta.TabIndex = 5;
            // 
            // lblCRP
            // 
            this.lblCRP.AutoSize = true;
            this.lblCRP.Location = new System.Drawing.Point(69, 305);
            this.lblCRP.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCRP.Name = "lblCRP";
            this.lblCRP.Size = new System.Drawing.Size(227, 32);
            this.lblCRP.TabIndex = 33;
            this.lblCRP.Text = "Número do CRP:";
            // 
            // txtCRP
            // 
            this.txtCRP.Location = new System.Drawing.Point(339, 305);
            this.txtCRP.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCRP.MaxLength = 20;
            this.txtCRP.Name = "txtCRP";
            this.txtCRP.Size = new System.Drawing.Size(599, 38);
            this.txtCRP.TabIndex = 3;
            this.txtCRP.TextChanged += new System.EventHandler(this.txtCRP_TextChanged);
            // 
            // btnSelecionarConsultas
            // 
            this.btnSelecionarConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarConsultas.Location = new System.Drawing.Point(352, 377);
            this.btnSelecionarConsultas.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSelecionarConsultas.Name = "btnSelecionarConsultas";
            this.btnSelecionarConsultas.Size = new System.Drawing.Size(357, 69);
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
            this.pnlConsultas.Location = new System.Drawing.Point(1104, 64);
            this.pnlConsultas.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.pnlConsultas.Name = "pnlConsultas";
            this.pnlConsultas.Size = new System.Drawing.Size(1015, 1397);
            this.pnlConsultas.TabIndex = 35;
            this.pnlConsultas.Visible = false;
            // 
            // lbDiaSemana
            // 
            this.lbDiaSemana.AutoSize = true;
            this.lbDiaSemana.Location = new System.Drawing.Point(437, 29);
            this.lbDiaSemana.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbDiaSemana.Name = "lbDiaSemana";
            this.lbDiaSemana.Size = new System.Drawing.Size(217, 32);
            this.lbDiaSemana.TabIndex = 48;
            this.lbDiaSemana.Text = "Dia da Semana:";
            // 
            // lbMes
            // 
            this.lbMes.AutoSize = true;
            this.lbMes.Location = new System.Drawing.Point(27, 29);
            this.lbMes.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbMes.Name = "lbMes";
            this.lbMes.Size = new System.Drawing.Size(75, 32);
            this.lbMes.TabIndex = 47;
            this.lbMes.Text = "Mes:";
            // 
            // cmbDiaSemana
            // 
            this.cmbDiaSemana.DisplayMember = "Name";
            this.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaSemana.FormattingEnabled = true;
            this.cmbDiaSemana.Location = new System.Drawing.Point(669, 24);
            this.cmbDiaSemana.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbDiaSemana.Name = "cmbDiaSemana";
            this.cmbDiaSemana.Size = new System.Drawing.Size(316, 39);
            this.cmbDiaSemana.TabIndex = 1;
            this.cmbDiaSemana.ValueMember = "Value";
            this.cmbDiaSemana.SelectedIndexChanged += new System.EventHandler(this.cmbDiaSemana_SelectedIndexChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.DisplayMember = "Name";
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(117, 24);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(297, 39);
            this.cmbMes.TabIndex = 0;
            this.cmbMes.ValueMember = "Value";
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // dtDataConsulta10
            // 
            this.dtDataConsulta10.Location = new System.Drawing.Point(237, 1054);
            this.dtDataConsulta10.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta10.Name = "dtDataConsulta10";
            this.dtDataConsulta10.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta10.TabIndex = 12;
            // 
            // dtDataConsulta9
            // 
            this.dtDataConsulta9.Location = new System.Drawing.Point(237, 980);
            this.dtDataConsulta9.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta9.Name = "dtDataConsulta9";
            this.dtDataConsulta9.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta9.TabIndex = 11;
            // 
            // dtDataConsulta8
            // 
            this.dtDataConsulta8.Location = new System.Drawing.Point(237, 899);
            this.dtDataConsulta8.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta8.Name = "dtDataConsulta8";
            this.dtDataConsulta8.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta8.TabIndex = 10;
            // 
            // dtDataConsulta7
            // 
            this.dtDataConsulta7.Location = new System.Drawing.Point(237, 818);
            this.dtDataConsulta7.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta7.Name = "dtDataConsulta7";
            this.dtDataConsulta7.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta7.TabIndex = 9;
            // 
            // dtDataConsulta6
            // 
            this.dtDataConsulta6.Location = new System.Drawing.Point(237, 732);
            this.dtDataConsulta6.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta6.Name = "dtDataConsulta6";
            this.dtDataConsulta6.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta6.TabIndex = 8;
            // 
            // btnSalvarConsultas
            // 
            this.btnSalvarConsultas.Location = new System.Drawing.Point(309, 1145);
            this.btnSalvarConsultas.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSalvarConsultas.Name = "btnSalvarConsultas";
            this.btnSalvarConsultas.Size = new System.Drawing.Size(357, 69);
            this.btnSalvarConsultas.TabIndex = 13;
            this.btnSalvarConsultas.Text = "Salvar";
            this.btnSalvarConsultas.UseVisualStyleBackColor = true;
            this.btnSalvarConsultas.Click += new System.EventHandler(this.btnSalvarConsultas_Click);
            // 
            // lblNumeroDeConsultas
            // 
            this.lblNumeroDeConsultas.AutoSize = true;
            this.lblNumeroDeConsultas.Location = new System.Drawing.Point(341, 126);
            this.lblNumeroDeConsultas.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNumeroDeConsultas.Name = "lblNumeroDeConsultas";
            this.lblNumeroDeConsultas.Size = new System.Drawing.Size(295, 32);
            this.lblNumeroDeConsultas.TabIndex = 39;
            this.lblNumeroDeConsultas.Text = "Número de Consultas:";
            // 
            // numNumeroConsultas
            // 
            this.numNumeroConsultas.Location = new System.Drawing.Point(645, 126);
            this.numNumeroConsultas.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
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
            this.numNumeroConsultas.Size = new System.Drawing.Size(120, 38);
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
            this.lblSelecioneDataConsultas.Location = new System.Drawing.Point(347, 219);
            this.lblSelecioneDataConsultas.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblSelecioneDataConsultas.Name = "lblSelecioneDataConsultas";
            this.lblSelecioneDataConsultas.Size = new System.Drawing.Size(407, 32);
            this.lblSelecioneDataConsultas.TabIndex = 37;
            this.lblSelecioneDataConsultas.Text = "Selecione datas das consultas:";
            // 
            // dtDataConsulta4
            // 
            this.dtDataConsulta4.Location = new System.Drawing.Point(237, 553);
            this.dtDataConsulta4.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta4.Name = "dtDataConsulta4";
            this.dtDataConsulta4.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta4.TabIndex = 6;
            // 
            // dtDataConsulta3
            // 
            this.dtDataConsulta3.Location = new System.Drawing.Point(237, 463);
            this.dtDataConsulta3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta3.Name = "dtDataConsulta3";
            this.dtDataConsulta3.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta3.TabIndex = 5;
            // 
            // dtDataConsulta5
            // 
            this.dtDataConsulta5.Location = new System.Drawing.Point(237, 641);
            this.dtDataConsulta5.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta5.Name = "dtDataConsulta5";
            this.dtDataConsulta5.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta5.TabIndex = 7;
            // 
            // dtDataConsulta2
            // 
            this.dtDataConsulta2.Location = new System.Drawing.Point(237, 377);
            this.dtDataConsulta2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtDataConsulta2.Name = "dtDataConsulta2";
            this.dtDataConsulta2.Size = new System.Drawing.Size(607, 38);
            this.dtDataConsulta2.TabIndex = 4;
            // 
            // pnlRecibo
            // 
            this.pnlRecibo.Controls.Add(this.pnlDadosTerapeuta);
            this.pnlRecibo.Controls.Add(this.lblTituloGeracaoRecibo);
            this.pnlRecibo.Controls.Add(this.lnkAssinarPDF);
            this.pnlRecibo.Controls.Add(this.btnGerarRecibo);
            this.pnlRecibo.Controls.Add(this.pnlDadosPaciente);
            this.pnlRecibo.Location = new System.Drawing.Point(11, 64);
            this.pnlRecibo.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.pnlRecibo.Name = "pnlRecibo";
            this.pnlRecibo.Size = new System.Drawing.Size(1069, 1395);
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
            this.pnlDadosTerapeuta.Location = new System.Drawing.Point(35, 591);
            this.pnlDadosTerapeuta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDadosTerapeuta.Name = "pnlDadosTerapeuta";
            this.pnlDadosTerapeuta.Size = new System.Drawing.Size(1010, 658);
            this.pnlDadosTerapeuta.TabIndex = 1;
            // 
            // lbDadosTerapeuta
            // 
            this.lbDadosTerapeuta.AutoSize = true;
            this.lbDadosTerapeuta.Location = new System.Drawing.Point(16, 14);
            this.lbDadosTerapeuta.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbDadosTerapeuta.Name = "lbDadosTerapeuta";
            this.lbDadosTerapeuta.Size = new System.Drawing.Size(241, 32);
            this.lbDadosTerapeuta.TabIndex = 43;
            this.lbDadosTerapeuta.Text = "Dados Terapeuta:";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(184, 79);
            this.lblCidade.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(113, 32);
            this.lblCidade.TabIndex = 14;
            this.lblCidade.Text = "Cidade:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(339, 74);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCidade.MaxLength = 32;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(591, 38);
            this.txtCidade.TabIndex = 0;
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(216, 382);
            this.lblCEP.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(80, 32);
            this.lblCEP.TabIndex = 36;
            this.lblCEP.Text = "CEP:";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(339, 381);
            this.txtCEP.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCEP.MaxLength = 12;
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(599, 38);
            this.txtCEP.TabIndex = 4;
            this.txtCEP.TextChanged += new System.EventHandler(this.txtCEP_TextChanged);
            // 
            // lblTituloGeracaoRecibo
            // 
            this.lblTituloGeracaoRecibo.AutoSize = true;
            this.lblTituloGeracaoRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGeracaoRecibo.Location = new System.Drawing.Point(341, 17);
            this.lblTituloGeracaoRecibo.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTituloGeracaoRecibo.Name = "lblTituloGeracaoRecibo";
            this.lblTituloGeracaoRecibo.Size = new System.Drawing.Size(387, 32);
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
            this.pnlDadosPaciente.Location = new System.Drawing.Point(35, 72);
            this.pnlDadosPaciente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDadosPaciente.Name = "pnlDadosPaciente";
            this.pnlDadosPaciente.Size = new System.Drawing.Size(1002, 481);
            this.pnlDadosPaciente.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Location = new System.Drawing.Point(523, 138);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(125, 67);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluirPaciente
            // 
            this.btnExcluirPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirPaciente.Location = new System.Drawing.Point(789, 138);
            this.btnExcluirPaciente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcluirPaciente.Name = "btnExcluirPaciente";
            this.btnExcluirPaciente.Size = new System.Drawing.Size(144, 67);
            this.btnExcluirPaciente.TabIndex = 3;
            this.btnExcluirPaciente.Text = "Excluir";
            this.btnExcluirPaciente.UseVisualStyleBackColor = true;
            this.btnExcluirPaciente.Click += new System.EventHandler(this.btnExcluirPaciente_Click);
            // 
            // btnSalvarPaciente
            // 
            this.btnSalvarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarPaciente.Location = new System.Drawing.Point(656, 138);
            this.btnSalvarPaciente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvarPaciente.Name = "btnSalvarPaciente";
            this.btnSalvarPaciente.Size = new System.Drawing.Size(128, 67);
            this.btnSalvarPaciente.TabIndex = 2;
            this.btnSalvarPaciente.Text = "Salvar";
            this.btnSalvarPaciente.UseVisualStyleBackColor = true;
            this.btnSalvarPaciente.Click += new System.EventHandler(this.btnSalvarPaciente_Click);
            // 
            // cmbNomePaciente
            // 
            this.cmbNomePaciente.FormattingEnabled = true;
            this.cmbNomePaciente.Location = new System.Drawing.Point(347, 83);
            this.cmbNomePaciente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNomePaciente.Name = "cmbNomePaciente";
            this.cmbNomePaciente.Size = new System.Drawing.Size(580, 39);
            this.cmbNomePaciente.TabIndex = 0;
            this.cmbNomePaciente.SelectedIndexChanged += new System.EventHandler(this.cmbNomePaciente_SelectedIndexChanged);
            this.cmbNomePaciente.TextChanged += new System.EventHandler(this.cmbNomePaciente_TextChanged);
            this.cmbNomePaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbNomePaciente_KeyPress);
            // 
            // lbDadosPaciente
            // 
            this.lbDadosPaciente.AutoSize = true;
            this.lbDadosPaciente.Location = new System.Drawing.Point(16, 17);
            this.lbDadosPaciente.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbDadosPaciente.Name = "lbDadosPaciente";
            this.lbDadosPaciente.Size = new System.Drawing.Size(223, 32);
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
            this.pnlReembolso.Location = new System.Drawing.Point(1104, 64);
            this.pnlReembolso.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.pnlReembolso.Name = "pnlReembolso";
            this.pnlReembolso.Size = new System.Drawing.Size(1016, 1395);
            this.pnlReembolso.TabIndex = 37;
            // 
            // lnkUnimedLogin
            // 
            this.lnkUnimedLogin.Location = new System.Drawing.Point(883, 17);
            this.lnkUnimedLogin.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lnkUnimedLogin.Name = "lnkUnimedLogin";
            this.lnkUnimedLogin.Size = new System.Drawing.Size(99, 45);
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
            this.pnlDadosReembolso.Location = new System.Drawing.Point(40, 72);
            this.pnlDadosReembolso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDadosReembolso.Name = "pnlDadosReembolso";
            this.pnlDadosReembolso.Size = new System.Drawing.Size(938, 653);
            this.pnlDadosReembolso.TabIndex = 0;
            // 
            // lbDadosReembolso
            // 
            this.lbDadosReembolso.AutoSize = true;
            this.lbDadosReembolso.Location = new System.Drawing.Point(21, 17);
            this.lbDadosReembolso.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbDadosReembolso.Name = "lbDadosReembolso";
            this.lbDadosReembolso.Size = new System.Drawing.Size(255, 32);
            this.lbDadosReembolso.TabIndex = 48;
            this.lbDadosReembolso.Text = "Dados Reembolso:";
            // 
            // lblLoginUnimed
            // 
            this.lblLoginUnimed.AutoSize = true;
            this.lblLoginUnimed.Location = new System.Drawing.Point(27, 114);
            this.lblLoginUnimed.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLoginUnimed.Name = "lblLoginUnimed";
            this.lblLoginUnimed.Size = new System.Drawing.Size(279, 32);
            this.lblLoginUnimed.TabIndex = 47;
            this.lblLoginUnimed.Text = "Login Unimed (CPF):";
            // 
            // txtLoginUnimed
            // 
            this.txtLoginUnimed.Location = new System.Drawing.Point(317, 114);
            this.txtLoginUnimed.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtLoginUnimed.MaxLength = 16;
            this.txtLoginUnimed.Name = "txtLoginUnimed";
            this.txtLoginUnimed.Size = new System.Drawing.Size(559, 38);
            this.txtLoginUnimed.TabIndex = 0;
            this.txtLoginUnimed.TextChanged += new System.EventHandler(this.txtLoginUnimed_TextChanged);
            // 
            // grbTipoAtendimento
            // 
            this.grbTipoAtendimento.Controls.Add(this.rbPresencial);
            this.grbTipoAtendimento.Controls.Add(this.rbTelemedicina);
            this.grbTipoAtendimento.Location = new System.Drawing.Point(48, 391);
            this.grbTipoAtendimento.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.grbTipoAtendimento.Name = "grbTipoAtendimento";
            this.grbTipoAtendimento.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.grbTipoAtendimento.Size = new System.Drawing.Size(368, 196);
            this.grbTipoAtendimento.TabIndex = 42;
            this.grbTipoAtendimento.TabStop = false;
            this.grbTipoAtendimento.Text = "Tipo de Atendimento:";
            // 
            // rbPresencial
            // 
            this.rbPresencial.AutoSize = true;
            this.rbPresencial.Location = new System.Drawing.Point(43, 57);
            this.rbPresencial.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.rbPresencial.Name = "rbPresencial";
            this.rbPresencial.Size = new System.Drawing.Size(185, 36);
            this.rbPresencial.TabIndex = 0;
            this.rbPresencial.Text = "Presencial";
            this.rbPresencial.UseVisualStyleBackColor = true;
            // 
            // rbTelemedicina
            // 
            this.rbTelemedicina.AutoSize = true;
            this.rbTelemedicina.Checked = true;
            this.rbTelemedicina.Location = new System.Drawing.Point(43, 119);
            this.rbTelemedicina.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.rbTelemedicina.Name = "rbTelemedicina";
            this.rbTelemedicina.Size = new System.Drawing.Size(222, 36);
            this.rbTelemedicina.TabIndex = 1;
            this.rbTelemedicina.TabStop = true;
            this.rbTelemedicina.Text = "Telemedicina";
            this.rbTelemedicina.UseVisualStyleBackColor = true;
            // 
            // txtSenhaUnimed
            // 
            this.txtSenhaUnimed.Location = new System.Drawing.Point(317, 196);
            this.txtSenhaUnimed.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtSenhaUnimed.MaxLength = 32;
            this.txtSenhaUnimed.Name = "txtSenhaUnimed";
            this.txtSenhaUnimed.PasswordChar = '*';
            this.txtSenhaUnimed.Size = new System.Drawing.Size(559, 38);
            this.txtSenhaUnimed.TabIndex = 1;
            // 
            // lblSenhaUnimed
            // 
            this.lblSenhaUnimed.AutoSize = true;
            this.lblSenhaUnimed.Location = new System.Drawing.Point(80, 198);
            this.lblSenhaUnimed.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblSenhaUnimed.Name = "lblSenhaUnimed";
            this.lblSenhaUnimed.Size = new System.Drawing.Size(210, 32);
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
            this.pnlDadosBancarios.Location = new System.Drawing.Point(40, 765);
            this.pnlDadosBancarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDadosBancarios.Name = "pnlDadosBancarios";
            this.pnlDadosBancarios.Size = new System.Drawing.Size(938, 484);
            this.pnlDadosBancarios.TabIndex = 1;
            // 
            // lbDadosBancarios
            // 
            this.lbDadosBancarios.AutoSize = true;
            this.lbDadosBancarios.Location = new System.Drawing.Point(16, 24);
            this.lbDadosBancarios.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbDadosBancarios.Name = "lbDadosBancarios";
            this.lbDadosBancarios.Size = new System.Drawing.Size(238, 32);
            this.lbDadosBancarios.TabIndex = 42;
            this.lbDadosBancarios.Text = "Dados Bancários:";
            // 
            // lblNomeDoBanco
            // 
            this.lblNomeDoBanco.AutoSize = true;
            this.lblNomeDoBanco.Location = new System.Drawing.Point(64, 131);
            this.lblNomeDoBanco.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblNomeDoBanco.Name = "lblNomeDoBanco";
            this.lblNomeDoBanco.Size = new System.Drawing.Size(224, 32);
            this.lblNomeDoBanco.TabIndex = 35;
            this.lblNomeDoBanco.Text = "Nome do Banco:";
            // 
            // lblDigitoDaConta
            // 
            this.lblDigitoDaConta.AutoSize = true;
            this.lblDigitoDaConta.Location = new System.Drawing.Point(69, 374);
            this.lblDigitoDaConta.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDigitoDaConta.Name = "lblDigitoDaConta";
            this.lblDigitoDaConta.Size = new System.Drawing.Size(212, 32);
            this.lblDigitoDaConta.TabIndex = 41;
            this.lblDigitoDaConta.Text = "Dígito da conta:";
            // 
            // txtNomeDoBanco
            // 
            this.txtNomeDoBanco.Location = new System.Drawing.Point(304, 126);
            this.txtNomeDoBanco.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtNomeDoBanco.MaxLength = 32;
            this.txtNomeDoBanco.Name = "txtNomeDoBanco";
            this.txtNomeDoBanco.Size = new System.Drawing.Size(559, 38);
            this.txtNomeDoBanco.TabIndex = 0;
            // 
            // txtDigitoDaConta
            // 
            this.txtDigitoDaConta.Location = new System.Drawing.Point(307, 374);
            this.txtDigitoDaConta.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtDigitoDaConta.MaxLength = 32;
            this.txtDigitoDaConta.Name = "txtDigitoDaConta";
            this.txtDigitoDaConta.Size = new System.Drawing.Size(559, 38);
            this.txtDigitoDaConta.TabIndex = 3;
            this.txtDigitoDaConta.TextChanged += new System.EventHandler(this.txtDigitoDaConta_TextChanged);
            // 
            // txtAgenciaSemDigito
            // 
            this.txtAgenciaSemDigito.Location = new System.Drawing.Point(307, 210);
            this.txtAgenciaSemDigito.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtAgenciaSemDigito.MaxLength = 32;
            this.txtAgenciaSemDigito.Name = "txtAgenciaSemDigito";
            this.txtAgenciaSemDigito.Size = new System.Drawing.Size(559, 38);
            this.txtAgenciaSemDigito.TabIndex = 1;
            this.txtAgenciaSemDigito.TextChanged += new System.EventHandler(this.txtAgenciaSemDigito_TextChanged);
            // 
            // lblContaSemDigito
            // 
            this.lblContaSemDigito.AutoSize = true;
            this.lblContaSemDigito.Location = new System.Drawing.Point(43, 298);
            this.lblContaSemDigito.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblContaSemDigito.Name = "lblContaSemDigito";
            this.lblContaSemDigito.Size = new System.Drawing.Size(235, 32);
            this.lblContaSemDigito.TabIndex = 39;
            this.lblContaSemDigito.Text = "Conta sem dígito:";
            // 
            // txtContaSemDigito
            // 
            this.txtContaSemDigito.Location = new System.Drawing.Point(304, 291);
            this.txtContaSemDigito.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtContaSemDigito.MaxLength = 32;
            this.txtContaSemDigito.Name = "txtContaSemDigito";
            this.txtContaSemDigito.Size = new System.Drawing.Size(559, 38);
            this.txtContaSemDigito.TabIndex = 2;
            this.txtContaSemDigito.TextChanged += new System.EventHandler(this.txtContaSemDigito_TextChanged);
            // 
            // lblAgenciaSemDigito
            // 
            this.lblAgenciaSemDigito.AutoSize = true;
            this.lblAgenciaSemDigito.Location = new System.Drawing.Point(29, 210);
            this.lblAgenciaSemDigito.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAgenciaSemDigito.Name = "lblAgenciaSemDigito";
            this.lblAgenciaSemDigito.Size = new System.Drawing.Size(263, 32);
            this.lblAgenciaSemDigito.TabIndex = 37;
            this.lblAgenciaSemDigito.Text = "Agência sem dígito:";
            // 
            // lblTituloSolicitacaoReembolso
            // 
            this.lblTituloSolicitacaoReembolso.AutoSize = true;
            this.lblTituloSolicitacaoReembolso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSolicitacaoReembolso.Location = new System.Drawing.Point(256, 17);
            this.lblTituloSolicitacaoReembolso.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblTituloSolicitacaoReembolso.Name = "lblTituloSolicitacaoReembolso";
            this.lblTituloSolicitacaoReembolso.Size = new System.Drawing.Size(480, 32);
            this.lblTituloSolicitacaoReembolso.TabIndex = 43;
            this.lblTituloSolicitacaoReembolso.Text = "Solicitação de Reembolso Unimed";
            // 
            // txtGerarSolicitacaoReembolso
            // 
            this.txtGerarSolicitacaoReembolso.Location = new System.Drawing.Point(315, 1285);
            this.txtGerarSolicitacaoReembolso.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtGerarSolicitacaoReembolso.Name = "txtGerarSolicitacaoReembolso";
            this.txtGerarSolicitacaoReembolso.Size = new System.Drawing.Size(357, 98);
            this.txtGerarSolicitacaoReembolso.TabIndex = 6;
            this.txtGerarSolicitacaoReembolso.Text = "Gerar solicitação de reembolso";
            this.txtGerarSolicitacaoReembolso.UseVisualStyleBackColor = true;
            this.txtGerarSolicitacaoReembolso.Click += new System.EventHandler(this.btnGerarSolicitacaoReembolso_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2176, 49);
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(90, 45);
            this.sairToolStripMenuItem.Text = "Sa&ir";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(141, 45);
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
            this.pnlSobre.Location = new System.Drawing.Point(757, 506);
            this.pnlSobre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSobre.Name = "pnlSobre";
            this.pnlSobre.Size = new System.Drawing.Size(775, 429);
            this.pnlSobre.TabIndex = 45;
            this.pnlSobre.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TerapiaReembolso.Properties.Resources.App;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(667, 93);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnFecharSobre
            // 
            this.btnFecharSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharSobre.Location = new System.Drawing.Point(304, 303);
            this.btnFecharSobre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFecharSobre.Name = "btnFecharSobre";
            this.btnFecharSobre.Size = new System.Drawing.Size(163, 79);
            this.btnFecharSobre.TabIndex = 2;
            this.btnFecharSobre.Text = "Fechar";
            this.btnFecharSobre.UseVisualStyleBackColor = true;
            this.btnFecharSobre.Click += new System.EventHandler(this.btnFecharSobre_Click);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(157, 200);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(416, 32);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "Copyright © Daniel Liedke 2022";
            // 
            // lblNomeAplicao
            // 
            this.lblNomeAplicao.AutoSize = true;
            this.lblNomeAplicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeAplicao.Location = new System.Drawing.Point(107, 93);
            this.lblNomeAplicao.Name = "lblNomeAplicao";
            this.lblNomeAplicao.Size = new System.Drawing.Size(475, 46);
            this.lblNomeAplicao.TabIndex = 0;
            this.lblNomeAplicao.Text = "Terapia Reembolso v2.3";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2176, 1538);
            this.Controls.Add(this.pnlSobre);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlReembolso);
            this.Controls.Add(this.pnlConsultas);
            this.Controls.Add(this.pnlRecibo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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

