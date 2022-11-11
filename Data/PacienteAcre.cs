using System;

namespace TerapiaReembolso
{
    [Serializable]
    public class PacienteAcre
    {
        public string CarteirinhaUnimed { get; set; }
        public string NomeBanco { get; set; }
        public string EnderecoSemNumero { get; set; }
        public string NumeroEndereco { get; set; }
        public string ComplementoEndereco { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string PDFCarteirinhaRequisicao { get; set; }
        public string PDFIdentidade { get; set; }
    }
}
