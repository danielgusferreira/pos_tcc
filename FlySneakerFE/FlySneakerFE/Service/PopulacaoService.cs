using FlySneakerFE.Models;
using System.Collections.Generic;

namespace FlySneakerFE.Service
{
    public class PopulacaoService
    {
        public static List<PopulacaoModel> GetPopulacaoPorEstado()
        {
            var lista = new List<PopulacaoModel>();
            lista.Add(new PopulacaoModel { Cidade = "São Paulo", Populacao2017 = 45094, Populacao2010 = 39585 });
            lista.Add(new PopulacaoModel { Cidade = "Minas Gerais", Populacao2017 = 21119, Populacao2010 = 16715 });
            lista.Add(new PopulacaoModel { Cidade = "Rio de Janeiro", Populacao2017 = 16718, Populacao2010 = 15464 });
            lista.Add(new PopulacaoModel { Cidade = "Bahia", Populacao2017 = 15344, Populacao2010 = 10120 });
            lista.Add(new PopulacaoModel { Cidade = "Parana", Populacao2017 = 11320, Populacao2010 = 8912 });
            return lista;
        }

        public static List<PopulacaoModel> GetPopulacaoPorEstado(IEnumerable<GraficoVendasAnual> Dados)
        {
            var lista = new List<PopulacaoModel>();
            foreach (var item in Dados)
            {
                lista.Add(new PopulacaoModel { Cidade = item.Mes, Populacao2017 = item.Valor, Populacao2010 = item.Valor });
            }

            return lista;
        }

        public static List<PopulacaoModel> GetPopulacaoPorEstado(IEnumerable<GraficoVendasPorMarca> Dados)
        {
            var lista = new List<PopulacaoModel>();
            foreach (var item in Dados)
            {
                lista.Add(new PopulacaoModel { Cidade = item.Marca, Populacao2017 = item.Quantidade, Populacao2010 = item.Quantidade });
            }

            return lista;
        }

        public static List<PopulacaoModel> GetPopulacaoPorEstado(IEnumerable<GraficoVendasPorCategoria> Dados)
        {
            var lista = new List<PopulacaoModel>();
            foreach (var item in Dados)
            {
                lista.Add(new PopulacaoModel { Cidade = item.Categoria, Populacao2017 = item.Quantidade, Populacao2010 = item.Quantidade });
            }

            return lista;
        }

        public static List<PopulacaoModel> GetPopulacaoPorEstado(IEnumerable<GraficoQuantidadeVendasPorMes> Dados)
        {
            var lista = new List<PopulacaoModel>();
            foreach (var item in Dados)
            {
                lista.Add(new PopulacaoModel { Cidade = item.Mes, Populacao2017 = item.Quantidade, Populacao2010 = item.Quantidade });
            }

            return lista;
        }
    }
}
