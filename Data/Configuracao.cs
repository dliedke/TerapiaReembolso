using System;

namespace TerapiaReembolso
{
    [Serializable]
    public class Configuracao
    {
        public string TipoPessoaTerapeuta { get; set; } 
        public string Cidade {get; set;}
        public string NomeTerapeuta {get; set;}
        public string CPFTerapeuta {get; set;}
        public string CRP {get; set;}
        public string CEP {get; set;}
        public string EnderecoTerapeuta {get; set;}
        public string TipoAtendimento {get; set;}
        public string NomeBanco {get; set;}
        public string Agencia {get; set;}
        public string Conta {get; set;}
        public string Digito {get; set;}
        public string LoginUnimed {get; set;}
        public string SenhaUnimed { get; set; }
        public string PDFRecibo { get; set;}
    }
}
