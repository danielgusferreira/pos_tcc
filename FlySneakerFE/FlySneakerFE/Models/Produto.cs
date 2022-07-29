using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LinkFoto1 { get; set; }
        public string LinkFoto2 { get; set; }
        public string LinkFoto3 { get; set; }
        public string LinkFoto4 { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoMarca { get; set; }
    }
}
