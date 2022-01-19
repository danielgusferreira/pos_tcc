namespace FlySneakers.Borders.Models
{
    public class Comentario : BaseModel
    {
        public string Descricao { get; set; }
        public int Nota { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoProdutoSku { get; set; }
    }
}
