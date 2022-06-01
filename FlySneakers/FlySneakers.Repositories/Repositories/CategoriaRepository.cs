using Dapper;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FlySneakers.Repositories.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public CategoriaRepository()
        {
        }

        public IEnumerable<Categoria> ObterCategorias()
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT codigo, nome, descricao FROM produto_categoria;";

                var result = connection.Query<Categoria>(sql);

                return result;
            }
        }

        public int CadastrarCategoria(Categoria categoria)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"INSERT INTO produto_categoria(nome, descricao) VALUES(@nome, @descricao);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("nome", categoria.Nome, DbType.String);
                parameters.Add("descricao", categoria.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int AtualizarCategoria(Categoria categoria)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE produto_categoria SET nome = @nome, descricao = @descricao  WHERE codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", categoria.Codigo, DbType.Int32);
                parameters.Add("nome", categoria.Nome, DbType.String);
                parameters.Add("descricao", categoria.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverCategoria(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "DELETE produto_categoria WHERE codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }
    }
}
