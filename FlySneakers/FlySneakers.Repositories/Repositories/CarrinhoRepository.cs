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
        private readonly IConfiguration _config;

        public CarrinhoRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<DadosCarrinhoDto> ObterCarrinho(int codUsuario)
        {
            using (var connection = new SqlConnection("Server=tcp:flysneakers.database.windows.net,1433;Initial Catalog=flySneakersDB;Persist Security Info=False;User ID=danielgusferreira;Password=Futebol11@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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
            using (var connection = new SqlConnection("Server=tcp:flysneakers.database.windows.net,1433;Initial Catalog=flySneakersDB;Persist Security Info=False;User ID=danielgusferreira;Password=Futebol11@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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
    }
}
