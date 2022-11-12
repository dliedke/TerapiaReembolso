/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Paciente mais genérico usado para gerar recibo e solicitar reembolso
 *           
 * *******************************************************************************************************************/

using System;
using System.Linq;
using System.Collections.Generic;

namespace TerapiaReembolso
{
    [Serializable]
    public class Paciente 
    {
        public string Nome { get; set; }

        public string Valor { get; set; }

        public string CPF { get; set; }

        public string ReferenteA { get; set; }

        public string DiaSemana { get; set; }

        public int NumeroConsultas { get; set; }

        public List<DateTime> DataConsultaLista { get; set; }

        public Paciente(string nome,
                        string valor,
                        string cpf,
                        string referentea,
                        string diaSemana,
                        int numeroConsultas,
                        DateTimePickerWithBackColor[] datasConsultasControles)
        {
            Nome = nome;
            Valor = valor;
            CPF = cpf;
            ReferenteA = referentea;
            DiaSemana = diaSemana;
            NumeroConsultas = numeroConsultas;
            DataConsultaLista = new List<DateTime>();
            DataConsultaLista.AddRange(datasConsultasControles.Select(c => c.Value).ToList());
        }
    }
}
