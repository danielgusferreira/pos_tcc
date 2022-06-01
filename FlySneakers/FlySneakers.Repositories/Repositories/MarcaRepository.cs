using Dapper;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlySneakers.Repositories.Repositories
{
    public class MarcaRepository : IMarcasRepository 
    {
        private readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public MarcaRepository()
        {
        }

        public Task<IEnumerable<Marca>> ObterMarcas()
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT codigo, nome, descricao FROM marca_produto;";

                var result = connection.QueryAsync<Marca>(sql);

                return result;
            }
        }

        public int CadastrarMarca(Marca marca)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"INSERT INTO marca_produto(nome, descricao) VALUES(@nome, @descricao);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("nome", marca.Nome, DbType.String);
                parameters.Add("descricao", marca.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int AtualizarMarca(Marca marca)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE marca_produto SET nome = @nome, descricao = @descricao FROM marca_produto where codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", marca.Codigo, DbType.Int32);
                parameters.Add("nome", marca.Nome, DbType.String);
                parameters.Add("descricao", marca.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverMarca(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "DELETE marca_produto WHERE codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }
    }
}
