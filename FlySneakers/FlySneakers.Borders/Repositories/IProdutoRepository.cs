using FlySneakers.Borders.Dto;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<ProdutoPagInicialDto> ObterProdutosPagInicial();
        ProdutoDetalhesDto ObterProdutoDetalhes(int codigo);
        IEnumerable<EstoqueDto> ObterEstoque(int codigo);
    }
}
