using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FlySneakers.Repositories.Repositories
{
    public class UsuarioRepository : IUsuarioRepository //Informando que a classe tem uma interface
    {
        private readonly IConfiguration _config;

        public UsuarioRepository(IConfiguration config)
        {
            _config = config;
        }

        public UsuarioLogadoDto VerificarLogin(LoginDto usuario)
        {
            using (var connection = new SqlConnection("Server=tcp:flysneakers.database.windows.net,1433;Initial Catalog=flySneakersDB;Persist Security Info=False;User ID=danielgusferreira;Password=Futebol11@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                string sql = "SELECT nome, email, codigo_perfil as perfil from usuario where email = @email AND senha = @senha";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("email", usuario.Email, DbType.String);
                parameters.Add("senha", usuario.Senha, DbType.String);

                var result = connection.QueryFirstOrDefault<UsuarioLogadoDto>(sql, parameters);

                return result;
            }
        }

        public int CadastrarUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection("Server=tcp:flysneakers.database.windows.net,1433;Initial Catalog=flySneakersDB;Persist Security Info=False;User ID=danielgusferreira;Password=Futebol11@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {

                string sql = @"INSERT INTO usuario([codigo_perfil], [nome], [email], [senha], [data_criacao]) 
                               VALUES(@tipoUsuario, @nome, @email, @senha, GETDATE());";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("tipoUsuario", usuario.Tipo == 0 ? 3 : usuario.Tipo, DbType.Int32);
                parameters.Add("nome", usuario.Nome, DbType.String);
                parameters.Add("email", usuario.Email, DbType.String);
                parameters.Add("senha", usuario.Senha, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }
    }
}
