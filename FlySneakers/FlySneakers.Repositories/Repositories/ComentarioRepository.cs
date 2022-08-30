using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlySneakers.Repositories.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public ComentarioRepository()
        {
        }

        public IEnumerable<ComentarioDto> ObterComentarios(int codigoProduto)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT
                                c.codigo,
	                            c.codigo_usuario as CodigoUsuario, 
	                            usu.nome,
	                            c.codigo_produto as CodigoProduto, 
	                            c.nota, 
	                            c.descricao
                            FROM
                                comentario c

                                inner join usuario usu ON
                                    usu.codigo = c.codigo_usuario
                            WHERE
                                codigo_produto = @codigoProduto;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigoProduto", codigoProduto, DbType.Int32);

                var result = connection.Query<ComentarioDto>(sql, parameters);

                return result;
            }
        }

        public bool VerificarExistenciaComentario(int codigoUsuario, int codigoProduto)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT DISTINCT
                                co.codigo_produto,
	                            co.codigo_usuario,
	                            co.descricao
                            FROM
                                pedido p

                                INNER JOIN carrinho c ON
                                    c.codigo = p.codigo_carrinho

                                INNER JOIN produto_dados pd ON
                                    PD.codigo = c.codigo_produto_dados

                                INNER JOIN produto pr ON
                                    pr.codigo = pd.codigo_produto

                                LEFT JOIN comentario co ON
                                    co.codigo_usuario = c.usuario_codigo AND
                                    co.codigo_produto = pr.codigo
                            WHERE
                                c.usuario_codigo = @codigoUsuario AND
                                pr.codigo = @codigoProduto; ";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigoUsuario", codigoUsuario, DbType.Int32);
                parameters.Add("codigoProduto", codigoProduto, DbType.Int32);

                var result = connection.QueryFirstOrDefault<int>(sql, parameters);

                return result == 1;
            }
        }

        public int CadastrarComentario(Comentario comentario)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"INSERT INTO comentario(codigo_usuario, codigo_produto, nota, descricao) VALUES (@codigo_usuario, @codigo_produto, @nota, @descricao);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo_usuario", comentario.CodigoUsuario, DbType.String);
                parameters.Add("codigo_produto", comentario.CodigoProduto, DbType.String);
                parameters.Add("nota", comentario.Nota, DbType.String);
                parameters.Add("descricao", comentario.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int AtualizarComentario(Comentario comentario)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE comentario SET nota = @nota, descricao = @descricao WHERE codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", comentario.Codigo, DbType.Int32);
                parameters.Add("nota", comentario.Nota, DbType.String);
                parameters.Add("descricao", comentario.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverComentario(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "DELETE comentario WHERE codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }
    }
}
