using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class MarcasDto : BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Marcas> Marcas { get; set; }
    }
}
