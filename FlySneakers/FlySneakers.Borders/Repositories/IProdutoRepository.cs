using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlySneakers.Borders.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produtos> ObterListaProdutos();
        IEnumerable<ProdutoSku> ObterListaProdutosDados(int codigoProduto);
        IEnumerable<ProdutoPagInicialDto> ObterProdutosPagInicial(int codigoCategoria, int codigoMarca);
        ProdutoDetalhesDto ObterProdutoDetalhes(int codigo);
        IEnumerable<EstoqueDto> ObterEstoque(int codigo);
        int CadastrarProduto(Produtos produto);
        int CadastrarProdutoDados(ProdutoSku produto);
        int AtualizarProdutoDados(ProdutoSku produto);
        int AtualizarProduto(Produtos produto);
        int RemoverProdutoDados(int codigo);
        int RemoverProduto(int codigo);
    }
}
