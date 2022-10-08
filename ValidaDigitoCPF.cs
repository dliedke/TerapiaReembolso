using System;
using System.Text.RegularExpressions;
/* 
* Valida e Calcula digito verificador de um CPF.
* 
* Visite nossa página http://www.codigoexpresso.com.br
* 
* by Antonio Azevedo
*  
* public static Boolean ValidaCPF(cpf)
*        Valida se o digito do CPF é valido
*        Pode-se informar um valor inteiro ou uma string com o numero completo do CPF contendo o Digito 
*        Exemplo '123.456.789-10' 
*
* public static string CalculaDigCPF(cpf)
*        Calcula o digito do CPF informado
*        Pode-se informar um valor inteiro ou uma string com o numero do CPF sem o Digito 
*        Exemplo '123.456.789' 
* 
*/

namespace TerapiaReembolso
{
    public static class ValidaDigitoCPF
    {
        public static Boolean ValidaCPFFormato(string cpf)
        {
            return Regex.IsMatch(cpf, @"^(\d{11})$");
        }

        /// <summary>
        /// Informar um CPF completo para validação do digito verificador
        /// </summary>
        /// <param name="cpf">string com o numero CPF completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CPF Valido</returns>
        public static Boolean ValidaCPFValor(string cpf)
        {
            // Declara variaveis para uso
            string new_cpf = "";

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigito(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CPF para 11 digitos considerando o digito verificador e completando com zeros a esquerda
            new_cpf = Convert.ToInt64(new_cpf).ToString("D11");

            // Verifica se o cpf informado tem os 11 digitos 
            if (new_cpf.Length > 11)
            {
                return false;
            }

            // Calcula o digito do CPF e compara com o digito informado
            if (CalculaDigCPF(new_cpf.Substring(0, 9)) == new_cpf.Substring(9, 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">int64 com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        public static string CalculaDigCPF(Int64 cpf)
        {
            return CalculaDigCPF(cpf.ToString("D9"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">string com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        public static string CalculaDigCPF(string cpf)
        {
            // Declara variaveis para uso
            string new_cpf = "";
            string digito = "";
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigito(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CPF para 9 digitos completando com zeros a esquerda
            new_cpf = Convert.ToInt64(new_cpf).ToString("D9");

            // Caso o tamanho do CPF informado for maior que 9 digitos retorna nulo
            if (new_cpf.Length > 9)
            {
                return null;
            }

            // Calcula o primeiro digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o primeiro digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            // Adiciona o primeiro digito ao final do CPF para calculo do segundo digito
            new_cpf += digito;

            // Calcula o segundo digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o segundo digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            return digito;
        }

        /// <summary>
        /// Verifica se um digito informado é um numero
        /// </summary>
        /// <param name="digito">string com um caracter para verificar se é um numero</param>
        /// <returns>Boolean True/False</returns>
        private static Boolean isDigito(string digito)
        {
            int n;
            return Int32.TryParse(digito, out n);
        }
    }
}
