using System.Collections.Generic;

namespace FlySneakers.Borders.Dto
{
    public class ProdutoDetalhesDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto1 { get; set; }
        public string Foto2 { get; set; }
        public string Foto3 { get; set; }
        public string Foto4 { get; set; }
        public IEnumerable<EstoqueDto> Estoque { get; set; }
    }
}
