using System;
using System.Text.Json.Serialization;

namespace FlySneakers.Borders.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
        [JsonIgnore]
        public DateTime DataCriacao { get; set; }
    }
}
