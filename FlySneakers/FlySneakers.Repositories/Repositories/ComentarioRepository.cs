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

        public IEnumerable<Comentario> ObterComentarios(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT codigo, codigo_usuario, codigo_produto_dados, nota, descricao FROM comentario WHERE codigo_produto_dados = @codigoProdutoDados;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo_produto_dados", codigo, DbType.Int32);

                var result = connection.Query<Comentario>(sql, parameters);

                return result;
            }
        }

        public int CadastrarComentario(Comentario comentario)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"INSERT INTO comentario(codigo_usuario, codigo_produto_dados, nota, descricao) VALUES (@codigo_usuario, @codigo_produto_dados, @nota, @descricao);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo_usuario", comentario.CodigoUsuario, DbType.String);
                parameters.Add("codigo_produto_dados", comentario.CodigoProdutoSku, DbType.String);
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
                string sql = @"UPDATE comentario SET nota = @nota, descricao = @descricao;";

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
