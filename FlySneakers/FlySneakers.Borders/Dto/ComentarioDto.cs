namespace FlySneakers.Borders.Models
{
    public class ComentarioDto : BaseModel
    {
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public int CodigoProduto { get; set; }
        public int Nota { get; set; }
        public string Descricao { get; set; }
    }
}
