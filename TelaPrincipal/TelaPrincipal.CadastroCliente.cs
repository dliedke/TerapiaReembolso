/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Cadastro de novos clientes para reembolso
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Windows.Forms;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
        #region Cadastro de Clientes

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
    }
}
