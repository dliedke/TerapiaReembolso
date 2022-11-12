/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Cadastro de novos pacientes para geração de recibo e reembolso
 *           
 * *******************************************************************************************************************/

using System;
using System.Windows.Forms;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
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
    }
}
