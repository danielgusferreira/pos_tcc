using FlySneakers.Borders.Dto;

namespace FlySneakers.Borders.Repositories
{
    public interface IPedidoRepository
    {
        UsuarioLogadoDto ObterDadosConcluirPedido(CadastrarCarrinhoDto login);
        UsuarioLogadoDto ObterPedidos(CadastrarCarrinhoDto login);
        int CadastrarPedido(CadastrarPedidoDto pedido);
    }
}
