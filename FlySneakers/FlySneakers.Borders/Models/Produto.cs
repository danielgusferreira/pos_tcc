using System;

namespace FlySneakers.Borders.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoMarca { get; set; }
        public string LinkFoto1 { get; set; }
        public string LinkFoto2 { get; set; }
        public string LinkFoto3 { get; set; }
        public string LinkFoto4 { get; set; }
    }
}
