using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class FormaPagamentosDto : BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<MeioPagamento> MeioPagamento { get; set; }
    }
}
