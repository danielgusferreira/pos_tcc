using System;
using System.Collections.Generic;

namespace FlySneakers.Borders.Models
{
    public class Pedido : BaseModel
    {
        public DateTime DataPedido { get; set; }

        public DateTime DataEnvio { get; set; }
        public string CodigoRastreio { get; set; }
        public int Status { get; set; }
        public int CodigoPagamento { get; set; }
        public IEnumerable<Carrinho> Carrinho { get; set; }
    }
}
