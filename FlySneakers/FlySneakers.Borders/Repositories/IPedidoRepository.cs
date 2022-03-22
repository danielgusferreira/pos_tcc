using FlySneakers.Borders.Dto;

namespace FlySneakers.Borders.Repositories
{
    public interface IPedidoRepository
    {
        UsuarioLogadoDto ObterPedidos(CadastrarCarrinhoDto login);
        int CadastrarPedido(CadastrarCarrinhoDto carrinho);
    }
}

