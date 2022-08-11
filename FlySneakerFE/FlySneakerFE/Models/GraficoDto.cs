using System.Collections.Generic;

namespace FlySneakerFE.Models
{
    public class GraficoDto
    {
        public IEnumerable<GraficoVendasAnual> ListaGraficoVendasAnual { get; set; }
        public IEnumerable<GraficoVendasPorMarca> ListaGraficoVendasPorMarca { get; set; }
        public IEnumerable<GraficoVendasPorCategoria> ListaGraficoVendasPorCategoria { get; set; }
        public IEnumerable<GraficoQuantidadeVendasPorMes> ListaGraficoQuantidadeVendasPorMes { get; set; }
    }

    public class GraficoVendasAnual
    {
        public string Mes { get; set; }
        public decimal Valor { get; set; }
    }

    public class GraficoQuantidadeVendasPorMes
    {
        public string Mes { get; set; }
        public decimal Quantidade { get; set; }
    }

    public class GraficoVendasPorMarca
    {
        public string Marca { get; set; }
        public decimal Quantidade { get; set; }
    }

    public class GraficoVendasPorCategoria
    {
        public string Categoria { get; set; }
        public decimal Quantidade { get; set; }
    }
}
