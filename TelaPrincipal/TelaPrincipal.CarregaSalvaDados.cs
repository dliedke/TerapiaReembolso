/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Salva e carrega dados em memória e no disco
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
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

                    // Se não existe os arquivos na máquina, já exclui os nomes de arquivos
                    if (!File.Exists(_pacienteAcre.PDFIdentidade))
                    {
                        _pacienteAcre.PDFIdentidade = string.Empty;
                    }

                    if (!File.Exists(_pacienteAcre.PDFCarteirinhaRequisicao))
                    {
                        _pacienteAcre.PDFCarteirinhaRequisicao = string.Empty;
                    }
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

                // Não salva o PDF do recibo e data do recibo
                string pdfRecibo = TelaPrincipal.PegaClienteAtual().PDFRecibo;
                string dataRecibo = TelaPrincipal.PegaPacienteAcre().DataRecibo;
                TelaPrincipal.PegaClienteAtual().PDFRecibo = string.Empty;
                TelaPrincipal.PegaPacienteAcre().DataRecibo = string.Empty;

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

                // Mantem em memoria o pdf do recibo e data do recibo
                TelaPrincipal.PegaClienteAtual().PDFRecibo = pdfRecibo;
                TelaPrincipal.PegaPacienteAcre().DataRecibo = dataRecibo;
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
    }
}
