using FlySneakers.Borders.Dto;

namespace FlySneakers.Borders.UseCase
{
    public interface IAdicionarItemCarrinhoUseCase
    {
        int Execute(CadastrarCarrinhoDto carrinho);
    }
}
