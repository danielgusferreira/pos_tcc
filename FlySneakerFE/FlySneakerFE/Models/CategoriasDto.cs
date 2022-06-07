using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class CategoriasDto : BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Categorias> Categorias { get; set; }
    }
}
