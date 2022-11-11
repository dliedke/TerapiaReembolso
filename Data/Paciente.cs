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
