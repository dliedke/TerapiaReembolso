using System;

namespace TerapiaReembolso
{
    [Serializable]
    public class PacienteAcre
    {
        public string CarteirinhaUnimed { get; set; }
        public string NomeBanco { get; set; }
        public string EnderecoRua { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string PDFCarteirinhaRequisicao { get; set; }
        public string PDFIdentidade { get; set; }
        public string DataRecibo { get; set; }

        public string Observacoes { get; set; }
    }
}
