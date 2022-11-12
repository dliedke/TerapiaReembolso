/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Todas validações de dados para gerar recibo, solicitação reembolso Unimed Seguros e Unimed Acre
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
        #region Validações dos Campos

        private bool ValidaDadosParaRecibo()
        {
            // Valida nome do paciente
            if (string.IsNullOrEmpty(cmbNomePaciente.Text))
            {
                MessageBox.Show("Favor entrar nome do paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNomePaciente.Focus();
                cmbNomePaciente.SelectAll();
                return false;
            }

            // Valida formato do valor
            var formatinfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = ""
            };

            if (string.IsNullOrEmpty(txtValorConsulta.Text) || float.TryParse(txtValorConsulta.Text, NumberStyles.Float, formatinfo, out float amount) == false)
            {
                MessageBox.Show("Favor entrar o valor com dois dígitos depois da virgula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorConsulta.Focus();
                txtValorConsulta.SelectAll();
                return false;
            }

            // Valida valor maior que zero
            if (amount <= 0)
            {
                MessageBox.Show("Valor deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorConsulta.Focus();
                txtValorConsulta.SelectAll();
                return false;
            }

            // Valida valor com dois digitos depois da virgual
            if (!Regex.IsMatch(Regex.Escape(txtValorConsulta.Text), @"^[0-9]+\,[0-9]{2}$"))
            {
                MessageBox.Show("Favor entrar o valor com dois dígitos depois da virgula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorConsulta.Focus();
                txtValorConsulta.SelectAll();
                return false;
            }

            // Valida CPF do paciente
            if (string.IsNullOrEmpty(txtCPFPaciente.Text))
            {
                MessageBox.Show("Favor entrar CPF do paciente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFPaciente.Focus();
                txtCPFPaciente.SelectAll();
                return false;
            }

            if (!ValidaCPF.ValidaCPFFormato(txtCPFPaciente.Text))
            {
                MessageBox.Show("Favor entrar CPF do paciente somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFPaciente.Focus();
                txtCPFPaciente.SelectAll();
                return false;
            }

            if (!ValidaCPF.ValidaCPFValor(txtCPFPaciente.Text))
            {
                MessageBox.Show("Favor entrar CPF do paciente válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFPaciente.Focus();
                txtCPFPaciente.SelectAll();
                return false;
            }

            // Valida Referente A
            if (string.IsNullOrEmpty(txtReferenteA.Text))
            {
                MessageBox.Show("Favor entrar Referente A.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReferenteA.Focus();
                txtReferenteA.SelectAll();
                return false;
            }

            // Valida Cidade
            if (string.IsNullOrEmpty(txtCidade.Text))
            {
                MessageBox.Show("Favor entrar cidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCidade.Focus();
                txtCidade.SelectAll();
                return false;
            }

            // Valida Nome do terapeuta
            if (string.IsNullOrEmpty(txtNomeDoTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar nome do terapeuta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeDoTerapeuta.Focus();
                txtNomeDoTerapeuta.SelectAll();
                return false;
            }

            // Valida CPF do terapeuta
            if (string.IsNullOrEmpty(txtCPFTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar CPF do terapeuta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPFTerapeuta.Focus();
                txtCPFTerapeuta.SelectAll();
                return false;
            }

            if (rbFisica.Checked)
            {
                // Valida CPF só números
                if (!ValidaCPF.ValidaCPFFormato(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CPF do terapeuta somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }

                // Valida CPF correto
                if (!ValidaCPF.ValidaCPFValor(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CPF do terapeuta válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }
            }
            else
            {
                // Valida CNPJ só números
                if (!ValidaCNPJ.ValidaCNPJFormato(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CNPJ da empresa somente 14 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }

                // Valida CNPJ correto
                if (!ValidaCNPJ.ValidaCNPJValor(txtCPFTerapeuta.Text))
                {
                    MessageBox.Show("Favor entrar CNPJ da empresa válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCPFTerapeuta.Focus();
                    txtCPFTerapeuta.SelectAll();
                    return false;
                }
            }

            // Valida CRP
            if (string.IsNullOrEmpty(txtCRP.Text))
            {
                MessageBox.Show("Favor entrar CRP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCRP.Focus();
                txtCRP.SelectAll();
                return false;
            }

            // Valida CRP só números
            if (!Regex.IsMatch(txtCRP.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar somente números para o CRP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCRP.Focus();
                txtCRP.SelectAll();
                return false;
            }

            // Valida CEP
            if (string.IsNullOrEmpty(txtCEP.Text))
            {
                MessageBox.Show("Favor entrar CEP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCEP.Focus();
                txtCEP.SelectAll();
                return false;
            }

            // Valida CEP só números
            if (!Regex.IsMatch(txtCEP.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar somente números para o CEP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCEP.Focus();
                txtCEP.SelectAll();
                return false;
            }

            // Valida Endereço do Terapeuta
            if (string.IsNullOrEmpty(txtEnderecoTerapeuta.Text))
            {
                MessageBox.Show("Favor entrar Endereço do Terapeuta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoTerapeuta.Focus();
                txtEnderecoTerapeuta.SelectAll();
                return false;
            }

            return true;
        }

        private bool ValidaDadosParaReembolso()
        {
            // Valida Login Unimed
            if (string.IsNullOrEmpty(txtLoginUnimed.Text))
            {
                MessageBox.Show("Favor entrar Login Unimed.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimed.Focus();
                txtLoginUnimed.SelectAll();
                return false;
            }

            // Valida Login Unimed CPF só números
            if (!ValidaCPF.ValidaCPFFormato(txtLoginUnimed.Text))
            {
                MessageBox.Show("Favor entrar Login Unimed CPF somente 11 números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimed.Focus();
                txtLoginUnimed.SelectAll();
                return false;
            }

            // Valida Login Unimed CPF correto
            if (!ValidaCPF.ValidaCPFValor(txtLoginUnimed.Text))
            {
                MessageBox.Show("Favor entrar Login Unimed CPF válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimed.Focus();
                txtLoginUnimed.SelectAll();
                return false;
            }

            // Valida Senha Unimed
            if (string.IsNullOrEmpty(txtSenhaUnimed.Text))
            {
                MessageBox.Show("Favor entrar Senha Unimed.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenhaUnimed.Focus();
                txtSenhaUnimed.SelectAll();
                return false;
            }

            // Valida Nome do Banco
            if (string.IsNullOrEmpty(txtNomeDoBanco.Text))
            {
                MessageBox.Show("Favor entrar Nome do Banco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeDoBanco.Focus();
                txtNomeDoBanco.SelectAll();
                return false;
            }

            // Valida Agencia
            if (string.IsNullOrEmpty(txtAgenciaSemDigito.Text))
            {
                MessageBox.Show("Favor entrar Agencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgenciaSemDigito.Focus();
                txtAgenciaSemDigito.SelectAll();
                return false;
            }

            // Valida Agencia só números
            if (!Regex.IsMatch(txtAgenciaSemDigito.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar Agencia somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgenciaSemDigito.Focus();
                txtAgenciaSemDigito.SelectAll();
                return false;
            }

            // Valida Conta
            if (string.IsNullOrEmpty(txtContaSemDigito.Text))
            {
                MessageBox.Show("Favor entrar Conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContaSemDigito.Focus();
                txtContaSemDigito.SelectAll();
                return false;
            }

            // Valida Conta só números
            if (!Regex.IsMatch(txtContaSemDigito.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar Conta somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContaSemDigito.Focus();
                txtContaSemDigito.SelectAll();
                return false;
            }

            // Valida Dígito da Conta
            if (string.IsNullOrEmpty(txtDigitoDaConta.Text))
            {
                MessageBox.Show("Favor entrar Dígito da Conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDigitoDaConta.Focus();
                txtDigitoDaConta.SelectAll();
                return false;
            }

            // Valida Dígito da Conta só números
            if (!Regex.IsMatch(txtDigitoDaConta.Text, @"^\d+$"))
            {
                MessageBox.Show("Favor entrar Dígito da Conta somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDigitoDaConta.Focus();
                txtDigitoDaConta.SelectAll();
                return false;
            }

            if (rbFisica.Checked)
            {
                // Valida PDF do recibo
                if (string.IsNullOrEmpty(dialogoPDFRecibo.FileName))
                {
                    MessageBox.Show("Favor selecionar PDF do recibo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSelecionarPDFRecibo.Focus();
                    return false;
                }
            }
            else
            {
                // Valida PDF do recibo
                if (string.IsNullOrEmpty(dialogoPDFRecibo.FileName))
                {
                    MessageBox.Show("Favor selecionar PDF da nota fiscal.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSelecionarPDFRecibo.Focus();
                    return false;
                }
            }

            return true;
        }


        private bool ValidaDadosParaReembolsoAcre()
        {
            // Valida Número Carteirinha
            if (string.IsNullOrEmpty(txtLoginUnimedAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor Número Carteirinha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUnimedAcre.Focus();
                txtLoginUnimedAcre.SelectAll();
                return false;
            }

            // Valida Número Carteirinha só números
            if (!Regex.IsMatch(txtLoginUnimedAcre.Text, @"^\d+$"))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Número Carteirinha somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgenciaSemDigito.Focus();
                txtAgenciaSemDigito.SelectAll();
                return false;
            }

            // Valida nome do banco
            if (string.IsNullOrEmpty(txtNomeBancoAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor nome do banco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeBancoAcre.Focus();
                txtNomeBancoAcre.SelectAll();
                return false;
            }

            // Valida Endereço (Rua)
            if (string.IsNullOrEmpty(txtEnderecoRuaAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Endereço (Rua).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoRuaAcre.Focus();
                txtEnderecoRuaAcre.SelectAll();
                return false;
            }

            // Valida Dígito da Conta só números
            if (!Regex.IsMatch(txtDigitoDaConta.Text, @"^\d+$"))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Dígito da Conta somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDigitoDaConta.Focus();
                txtDigitoDaConta.SelectAll();
                return false;
            }

            // Valida Número
            if (string.IsNullOrEmpty(txtEnderecoNumeroAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Número.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoNumeroAcre.Focus();
                txtEnderecoNumeroAcre.SelectAll();
                return false;
            }

            // Valida campo Número só números
            if (!Regex.IsMatch(txtEnderecoNumeroAcre.Text, @"^\d+$"))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar no campo Número somente números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoNumeroAcre.Focus();
                txtEnderecoNumeroAcre.SelectAll();
                return false;
            }

            // Valida Complemento
            if (string.IsNullOrEmpty(txtEnderecoComplementoAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Complemento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoComplementoAcre.Focus();
                txtEnderecoComplementoAcre.SelectAll();
                return false;
            }

            // Valida Bairro
            if (string.IsNullOrEmpty(txtEnderecoBairroAcre.Text))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor entrar Bairro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoBairroAcre.Focus();
                txtEnderecoBairroAcre.SelectAll();
                return false;
            }

            // Valida PDF da carteirinha
            if (string.IsNullOrEmpty(dialogoPDFCarteirinha.FileName))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor selecionar PDF da cateirinha/requisição médica.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSelecionarPDFCarteirinha.Focus();
                return false;
            }

            // Valida PDF da identidade
            if (string.IsNullOrEmpty(dialogoPDFIdentidade.FileName))
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor selecionar PDF da identidade.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSelecionarPDFIdentidade.Focus();
                return false;
            }

            if (dtDataRecibo.Value == DateTime.Now.AddDays(1).Date)
            {
                MostraDadosUnimedAcre();
                MessageBox.Show("Favor selecionar data do recibo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtDataRecibo.Focus();
                return false;
            }

            // Valida se todos arquivos PDF são diferentes
            if ((Path.GetFileName(dialogoPDFIdentidade.FileName) == Path.GetFileName(dialogoPDFCarteirinha.FileName)) ||
                (Path.GetFileName(dialogoPDFIdentidade.FileName) == Path.GetFileName(dialogoPDFRecibo.FileName)) ||
                (Path.GetFileName(dialogoPDFCarteirinha.FileName) == Path.GetFileName(dialogoPDFRecibo.FileName)))
            {
                MessageBox.Show("Favor selecionar diferentes arquivos para identidade, carteirinha e recibo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region Remove Acentos do Nome do Paciente

        private string _strAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";

        private void cmbNomePaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_strAcentos.IndexOf(e.KeyChar) > 0)
            {
                e.Handled = true;
            }
        }

        private void cmbNomePaciente_TextChanged(object sender, EventArgs e)
        {
            cmbNomePaciente.Text = Utilitarios.RemoveAcentos(cmbNomePaciente.Text);
        }

        #endregion


        #region Somente dígitos para campos de CPF/CEP/CRP/Valor/Dados bancários

        private void txtCPFPaciente_TextChanged(object sender, EventArgs e)
        {
            txtCPFPaciente.Text = Regex.Replace(txtCPFPaciente.Text, @"[^\d]", "");
        }

        private void txtCPFTerapeuta_TextChanged(object sender, EventArgs e)
        {
            txtCPFTerapeuta.Text = Regex.Replace(txtCPFTerapeuta.Text, @"[^\d]", "");
        }

        private void txtLoginUnimed_TextChanged(object sender, EventArgs e)
        {
            txtLoginUnimed.Text = Regex.Replace(txtLoginUnimed.Text, @"[^\d]", "");
        }

        private void txtCRP_TextChanged(object sender, EventArgs e)
        {
            txtCRP.Text = Regex.Replace(txtCRP.Text, @"[^\d]", "");
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            txtCEP.Text = Regex.Replace(txtCEP.Text, @"[^\d]", "");
        }

        private void txtAgenciaSemDigito_TextChanged(object sender, EventArgs e)
        {
            txtAgenciaSemDigito.Text = Regex.Replace(txtAgenciaSemDigito.Text, @"[^\d]", "");
        }

        private void txtContaSemDigito_TextChanged(object sender, EventArgs e)
        {
            txtContaSemDigito.Text = Regex.Replace(txtContaSemDigito.Text, @"[^\d]", "");
        }

        private void txtDigitoDaConta_TextChanged(object sender, EventArgs e)
        {
            txtDigitoDaConta.Text = Regex.Replace(txtDigitoDaConta.Text, @"[^\d]", "");
        }

        private void txtValorConsulta_TextChanged(object sender, EventArgs e)
        {
            txtValorConsulta.Text = Regex.Replace(txtValorConsulta.Text, @"[^\d,]", "");
        }

        #endregion
    }
}
