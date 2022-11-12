/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Gerenciamento das datas das consultas para o paciente
 *           
 * *******************************************************************************************************************/

using System;
using System.Linq;
using System.Windows.Forms;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
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
    }
}
