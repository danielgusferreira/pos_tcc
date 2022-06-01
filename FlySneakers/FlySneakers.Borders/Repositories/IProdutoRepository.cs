using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<ProdutoPagInicialDto> ObterProdutosPagInicial(int codigoCategoria, int codigoMarca);
        ProdutoDetalhesDto ObterProdutoDetalhes(int codigo);
        IEnumerable<EstoqueDto> ObterEstoque(int codigo);
        int CadastrarProduto(Produto produto);
        int CadastrarProdutoDados(Produto produto);
        int AtualizarProdutoDados(Produto produto);
        int AtualizarProduto(Produto produto);
        int RemoverProdutoDados(int codigo);
        int RemoverProduto(int codigo);
    }
}
