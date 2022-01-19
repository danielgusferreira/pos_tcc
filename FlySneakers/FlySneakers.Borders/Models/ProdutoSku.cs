using System;

namespace FlySneakers.Borders.Models
{
    public class ProdutoSku : BaseModel
    {
        public int ProdutoCodigo { get; set; }

        public string Tamanho { get; set; }
        public decimal Valor { get; set; }

        public DateTime DataCriacao { get; set; }
        public int Estoque { get; set; }
    }
}
