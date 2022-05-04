using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FlySneakers.Repositories.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        public readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public ProdutoRepository()
        {
        }

        public IEnumerable<ProdutoPagInicialDto> ObterProdutosPagInicial(int codigoCategoria, int codigoMarca)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT
                                p.codigo as codigo,
	                            p.nome as nome,
	                            p.foto1 as foto,
	                            (SELECT MIN(pd.valor) FROM produto_dados pd WHERE pd.codigo_produto = p.codigo) as valor,
	                            p.codigo_categoria as CodigoCategoria,
	                            p.codigo_marca as CodigoMarca
                            FROM
	                            produto p

	                            INNER JOIN produto_categoria c ON
		                            c.codigo = p.codigo_categoria

	                            INNER JOIN marca_produto m ON
		                            m.codigo = p.codigo_marca ";

                DynamicParameters parameters = new DynamicParameters();

                if (codigoCategoria != 0)
                {
                    sql += "WHERE c.codigo = @codigoCategoria";

                    parameters.Add("codigoCategoria", codigoCategoria, DbType.Int32);
                }

                if (codigoMarca != 0)
                {
                    sql += "WHERE m.codigo = @codigoMarca";

                    parameters.Add("codigoMarca", codigoMarca, DbType.Int32);
                }

                var result = connection.Query<ProdutoPagInicialDto>(sql, parameters);

                return result;
            }
        }

        public ProdutoDetalhesDto ObterProdutoDetalhes(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT CODIGO, NOME, DESCRICAO, FOTO1, FOTO2, FOTO3, FOTO4
                                FROM produto WHERE CODIGO = @codigo";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.QueryFirstOrDefault<ProdutoDetalhesDto>(sql, parameters);

                return result;
            }
        }

        public IEnumerable<EstoqueDto> ObterEstoque(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"select
	                            codigo,
	                            codigo_produto as CodigoProduto,
	                            tamanho,
	                            estoque,
	                            valor
                            from
	                            produto_dados
                            where
	                            codigo_produto = @codigo";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Query<EstoqueDto>(sql, parameters);

                return result;
            }
        }
    }
}
