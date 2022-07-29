using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class ProdutosCreateDto : BaseModel
    {
        public Produto Produto { get; set; }
        public IEnumerable<Produto> ProdutoList { get; set; }
        public ProdutoDados ProdutoDados { get; set; }
        public IEnumerable<ProdutoDados> ProdutoDadosList { get; set; }
        public IEnumerable<Marcas> Marcas { get; set; }
        public IEnumerable<Categorias> Categorias { get; set; }
    }
}
