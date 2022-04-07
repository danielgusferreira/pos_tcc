using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FlySneakers.Repositories.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository //Informando que a classe tem uma interface
    {

        private string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public CarrinhoRepository()
        {
        }

        public IEnumerable<DadosCarrinhoDto> ObterCarrinho(int codUsuario)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"select
                                   c.codigo as Codigo,
                                   p.codigo as CodigoDadosProduto,
	                               p.nome as Nome,
	                               c.quantidade as Quantidade, 
	                               pd.tamanho as Tamanho,
	                               p.foto1 as Foto,
	                               pd.valor as Valor
                               from
                                    carrinho c

                                    inner join produto_dados pd on
                                        pd.codigo = c.codigo_produto_dados

                                    inner join produto p on
                                        p.codigo = pd.codigo_produto
                                where 
                                    c.usuario_codigo = @usuario";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("usuario", codUsuario, DbType.Int32);

                var result = connection.Query<DadosCarrinhoDto>(sql, parameters);

                return result;
            }
        }

        public int CadastrarProduto(CadastrarCarrinhoDto carrinho)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"INSERT INTO carrinho([quantidade], [codigo_produto_dados], [usuario_codigo]) 
                               VALUES(@quantidade, @codigo_produto_dados, @usuario_codigo);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("quantidade", carrinho.Quantidade, DbType.Int32);
                parameters.Add("codigo_produto_dados", carrinho.CodigoProdutoDados, DbType.Int32);
                parameters.Add("usuario_codigo", carrinho.UsuarioCodigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverItemCarrinhoProduto(int codCarrinho)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"DELETE FROM carrinho WHERE codigo = @codCarrinho";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codCarrinho", codCarrinho, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }
    }
}
