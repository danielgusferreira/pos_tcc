using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class ConfirmarPedidoDto
    {
        public IEnumerable<int> Codigos { get; set; }
        public UsuarioDados UsuarioDados { get; set; }
        public IEnumerable<MeioPagamento> MeioPagamento { get; set; }
        public decimal ValorPedido { get; set; }
    }
}
