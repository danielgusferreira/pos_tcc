using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Dto
{
    public class DadosProdutoDto
    {
        public int CodigoSku { get; set; }
        public int CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tamanho { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
        public string Marca { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
