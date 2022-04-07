using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Dto
{
    public class DadosConcluirPedidoDto  
    {
        public UsuarioDados DadosUsuario { get; set; }

        public IEnumerable<DadosCarrinhoDto> Carrinho { get; set; }
    }
}
