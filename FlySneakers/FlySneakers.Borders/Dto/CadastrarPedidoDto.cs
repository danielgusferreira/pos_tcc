using System.Collections.Generic;

namespace FlySneakers.Borders.Dto
{
    public class CadastrarPedidoDto
    {
        public int CodPagamento { get; set; }
        public IEnumerable<int> CodCarrinhos { get; set; }
    }
}
