using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class CadastrarPedidoDto
    {
        public int CodPagamento { get; set; }
        public IEnumerable<int> CodCarrinhos { get; set; }
    }
}
