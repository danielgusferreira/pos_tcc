using System.Text.Json.Serialization;

namespace FlySneakers.Borders.Models
{
    public class Carrinho : BaseModel
    {
        public int CodigoUsuario { get; set; }
        public int Quantidade { get; set; }
        public int CodigoProdutoSku { get; set; }

        [JsonIgnore]
        public ProdutoSku ProdutoSku { get; set; }

        [JsonIgnore]
        public Produto Produto { get; set; }
    }
}
