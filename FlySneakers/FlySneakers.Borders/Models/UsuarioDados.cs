using System;

namespace FlySneakers.Borders.Models
{
    public class UsuarioDados : BaseModel
    {
        public int CodigoUsuario { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
