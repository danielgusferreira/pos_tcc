using FlySneakers.Borders.Dto;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface ICarrinhoRepository
    {
        IEnumerable<DadosCarrinhoDto> ObterCarrinho(int codUsuario);
        int CadastrarProduto(CadastrarCarrinhoDto carrinho);
    }
}
