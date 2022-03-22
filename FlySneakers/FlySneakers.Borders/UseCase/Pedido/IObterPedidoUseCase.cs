using FlySneakers.Borders.Dto;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterPedidoUseCase
    {
        int Execute(CadastrarCarrinhoDto carrinho);
    }
}
