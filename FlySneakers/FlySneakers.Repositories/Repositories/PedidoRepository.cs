using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FlySneakers.Repositories.Repositories
{
    public class PedidoRepository : IPedidoRepository //Informando que a classe tem uma interface
    {

        public readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
       
            public PedidoRepository()
        {
        }

        public UsuarioLogadoDto ObterPedidos(CadastrarCarrinhoDto usuario)
        {
            //using (var connection = new SqlConnection(Connection))
            //{
            //    string sql = "SELECT nome, email, codigo_perfil as perfil from usuario where email = @email AND senha = @senha";

            //    DynamicParameters parameters = new DynamicParameters();
            //    parameters.Add("email", usuario.Email, DbType.String);
            //    parameters.Add("senha", usuario.Senha, DbType.String);

            //    var result = connection.QueryFirstOrDefault<UsuarioLogadoDto>(sql, parameters);

            //    return result;
            //}
            return null;
        }

        public int CadastrarPedido(CadastrarPedidoDto pedido)
        {
            int result = 0;
            using (var connection = new SqlConnection(Connection))
            {

                foreach (var itemCarrinho in pedido.CodCarrinhos)
                {
                    string sql = @"INSERT INTO pedido([data_pedido], [status], [codigo_meio_pagamento], [codigo_carrinho]) 
                               VALUES(GETDATE(), 1, @codigo_meio_pagamento, @codigo_carrinho);";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("codigo_meio_pagamento", pedido.CodPagamento, DbType.Int32);
                    parameters.Add("codigo_carrinho", itemCarrinho, DbType.Int32);

                    result = connection.Execute(sql, parameters);
                }

                return result;
            }
        }

        public GraficoDto ObterGraficosPedidos()
        {
            GraficoDto result = new GraficoDto();
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT 
	                                DATENAME(MONTH, DATEADD(MONTH, MONTH(data_pedido), '2000-12-01')) as Mes,
	                                SUM(ca.quantidade) * sum(pd.valor) as Valor
                                FROM      
	                                pedido pe

	                                INNER JOIN carrinho ca on
		                                ca.codigo = pe.codigo_carrinho

	                                INNER JOIN produto_dados pd on
		                                pd.codigo = ca.codigo_produto_dados
                                WHERE     
	                                YEAR(data_pedido) = '2022' 
                                GROUP BY 
	                                MONTH(data_pedido);";

                result.ListaGraficoVendasAnual = connection.Query<GraficoVendasAnual>(sql);
            }

            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT
	                                mp.nome as Marca,
	                                COUNT(*) as Quantidade
                                FROM
	                                pedido pe

	                                INNER JOIN carrinho ca on
		                                ca.codigo = pe.codigo_carrinho

	                                INNER JOIN produto_dados pd on
		                                pd.codigo = ca.codigo_produto_dados
	
	                                INNER JOIN produto p on
		                                p.codigo = pd.codigo_produto
	
	                                INNER JOIN marca_produto mp on
		                                mp.codigo = p.codigo_marca
                                GROUP BY 
	                                mp.codigo,
	                                mp.nome;";

                result.ListaGraficoVendasPorMarca = connection.Query<GraficoVendasPorMarca>(sql);
            }

            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT
	                                pc.nome as Categoria,
	                                COUNT(*) as Quantidade
                                FROM
	                                pedido pe

	                                INNER JOIN carrinho ca on
		                                ca.codigo = pe.codigo_carrinho

	                                INNER JOIN produto_dados pd on
		                                pd.codigo = ca.codigo_produto_dados
	
	                                INNER JOIN produto p on
		                                p.codigo = pd.codigo_produto
	
	                                INNER JOIN produto_categoria pc on
		                                pc.codigo = p.codigo_marca
                                GROUP BY 
	                                pc.codigo,
	                                pc.nome;";

                result.ListaGraficoVendasPorCategoria = connection.Query<GraficoVendasPorCategoria>(sql);
            }

            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT 
	                                DATENAME(MONTH, DATEADD(MONTH, MONTH(data_pedido), '2000-12-01')) as Mes,
	                                COUNT(*) as Quantidade
                                FROM      
	                                pedido 
                                WHERE     
	                                YEAR(data_pedido) = '2022' 
                                GROUP BY 
	                                MONTH(data_pedido);";

                result.ListaGraficoQuantidadeVendasPorMes = connection.Query<GraficoQuantidadeVendasPorMes>(sql);
            }

            return result;
        }

        public UsuarioLogadoDto ObterDadosConcluirPedido(CadastrarCarrinhoDto login)
        {
            throw new System.NotImplementedException();
        }
    }
}
