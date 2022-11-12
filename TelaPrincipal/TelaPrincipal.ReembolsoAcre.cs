/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Gerenciamento de dados para solicitação de reembolso Unimed Acre
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Windows.Forms;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
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
    }
}
