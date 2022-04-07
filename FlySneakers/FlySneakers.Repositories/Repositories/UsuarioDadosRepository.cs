using Dapper;
using FlySneakers.Borders.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace FlySneakers.Repositories.Repositories
{
    public class UsuarioDadosRepository : IUsuarioDadosRepository //Informando que a classe tem uma interface
    {
        private readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public UsuarioDadosRepository()
        {
        }

        public int VerificarDados(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "select codigo from usuario_dados where codigo_usuario = @codigo";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.String);

                var result = connection.QueryFirstOrDefault(sql, parameters);

                return result != null ? 1 : 0;
            }
        }
    }
}
