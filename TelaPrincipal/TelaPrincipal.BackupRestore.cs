/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Backup e restore de todos dados salvos pela aplicação
 *           
 * *******************************************************************************************************************/

using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using Aspose.Zip;

namespace TerapiaReembolso
{
    public partial class TelaPrincipal : Form
    {
        #region Backup/Restaurar

        private void restaurarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Pede nome do arquivo zip para restaurar backup
                DialogResult dialogResult = dialogoRestaurarBackup.ShowDialog();

                // Se arquivo foi selecionado
                if (dialogResult == DialogResult.OK)
                {
                    // Verifica extensão do arquivo
                    if (Path.GetExtension(dialogoRestaurarBackup.FileName).ToLower() != ".zip")
                    {
                        MessageBox.Show("Favor selecionar um arquivo ZIP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dialogoPDFRecibo.FileName = "";
                        return;
                    }
                    else
                    {
                        // Confirma com usuário restauração do backup apagando os dados atuais
                        DialogResult verificacaoUsuario = MessageBox.Show("ATENÇÃO!!!!! Os dados atuais serão sobreescritos por este backup e não poderão ser restaurados.\r\nDeseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        if (verificacaoUsuario != DialogResult.Yes)
                        {
                            return;
                        }

                        // Abre zip com backup
                        using (FileStream zipFile = File.Open(dialogoRestaurarBackup.FileName, FileMode.Open))
                        {
                            using (var archive = new Archive(zipFile))
                            {
                                // Descompacta os arquivos na pasta
                                archive.ExtractToDirectory(_caminhoConfiguracoes);

                                // Recarrega tudo
                                CarregaDadosSalvos();

                                // Seleciona primeiro paciente se existir algum cadastrado
                                if (cmbNomePaciente.Items.Count > 0)
                                {
                                    cmbNomePaciente.SelectedIndex = 0;
                                }

                                // Mostra mensagem de sucesso
                                MessageBox.Show($"Backup restaurado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Restaurar Backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fazerBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria nome padrão de arquivo para backup
                dialogoSalvarBackup.FileName = $"TerapiaReembolsoBackup_{DateTime.Now.ToString("dd.MM.yyyy")}.zip";

                // Pede nome do arquivo zip para criar backup
                DialogResult dialogResult = dialogoSalvarBackup.ShowDialog();

                // Se arquivo foi selecionado
                if (dialogResult == DialogResult.OK)
                {
                    // Verifica extensão do arquivo
                    if (Path.GetExtension(dialogoSalvarBackup.FileName).ToLower() != ".zip")
                    {
                        MessageBox.Show("Favor selecionar um arquivo ZIP.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dialogoPDFRecibo.FileName = "";
                        return;
                    }
                    else
                    {
                        // Salva dados antes de fazer o backup
                        SalvaDadosAtuais();

                        List<FileInfo> listaArquvosParaBackup = new List<FileInfo>();

                        // Pega informação do arquivos de pacientes
                        string arquivoPacientes = Path.Combine(_caminhoConfiguracoes, "pacientes.bin");
                        if (File.Exists(arquivoPacientes))
                        {
                            FileInfo fileInfo = new FileInfo(arquivoPacientes);
                            listaArquvosParaBackup.Add(fileInfo);
                        }

                        // Pega informação do arquivos de paciente acre
                        string arquivoPacienteAcre = Path.Combine(_caminhoConfiguracoes, "pacienteacre.bin");
                        if (File.Exists(arquivoPacienteAcre))
                        {
                            FileInfo fileInfo = new FileInfo(arquivoPacienteAcre);
                            listaArquvosParaBackup.Add(fileInfo);
                        }

                        // Pega informação de todos arquivos de clientes
                        for (int i = 0; i < 100; i++)
                        {
                            string arquivoConfiguracao = Path.Combine(_caminhoConfiguracoes, $"config_{i}.bin");
                            if (File.Exists(arquivoConfiguracao))
                            {
                                FileInfo fileInfo = new FileInfo(arquivoConfiguracao);
                                listaArquvosParaBackup.Add(fileInfo);
                            }
                        }

                        // Cria FileStream para gerar o backup como arquivo zip
                        using (FileStream zipFile = File.Open(dialogoSalvarBackup.FileName, FileMode.Create))
                        {
                            using (var archive = new Archive())
                            {
                                // Adiciona arquivos ao zip
                                foreach (FileInfo fileInfo in listaArquvosParaBackup)
                                {
                                    archive.CreateEntry(fileInfo.Name, fileInfo);
                                }

                                // Cria arquivo zip
                                archive.Save(zipFile);

                                // Mostra mensagem de sucesso
                                MessageBox.Show($"Backup criado e salvo em:\r\n\r\n{dialogoSalvarBackup.FileName}\r\n\r\nGuarde o arquivo na Internet (ex: OneDrive ou Google Drive) para evitar perda de dados.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Realizar Backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
