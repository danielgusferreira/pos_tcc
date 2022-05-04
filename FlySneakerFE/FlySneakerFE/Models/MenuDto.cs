using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class MenuDto
    {
        public IEnumerable<Categorias> Categorias { get; set; }
        public IEnumerable<Marcas> Marcas { get; set; }
    }
}
