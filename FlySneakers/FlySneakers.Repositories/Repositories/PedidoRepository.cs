using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace FlySneakers.Repositories.Repositories
{
    public class PedidoRepository : IPedidoRepository //Informando que a classe tem uma interface
    {

        public PedidoRepository()
        {
        }

        public UsuarioLogadoDto ObterPedidos(CadastrarCarrinhoDto usuario)
        {
            //using (var connection = new SqlConnection("Server=tcp:flysneakers.database.windows.net,1433;Initial Catalog=flySneakersDB;Persist Security Info=False;User ID=danielgusferreira;Password=Futebol11@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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

        public int CadastrarPedido(CadastrarCarrinhoDto carrinho)
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
