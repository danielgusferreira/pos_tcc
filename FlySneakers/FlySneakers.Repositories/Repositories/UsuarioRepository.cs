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
        private readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public UsuarioRepository()
        {
        }

        public UsuarioLogadoDto VerificarLogin(LoginDto usuario)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT codigo, nome, email, codigo_perfil as Perfil from usuario where email = @email AND senha = @senha";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("email", usuario.Email, DbType.String);
                parameters.Add("senha", usuario.Senha, DbType.String);

                var result = connection.QueryFirstOrDefault<UsuarioLogadoDto>(sql, parameters);

                return result;
            }
        }

        public int CadastrarUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(Connection))
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

        public int CadastrarDadosUsuario(UsuarioDados usuario)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"INSERT INTO usuario_dados([codigo_usuario], [cpf],[data_nascimento],[telefone],[cep] ,[endereco] ,[numero],[complemento] ,[bairro],[cidade],[uf] ,[data_criacao]) 
	                           VALUES(@codigo_usuario, @cpf, @data_nascimento, @telefone, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @uf, getdate());";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo_usuario", usuario.CodigoUsuario, DbType.Int32);
                parameters.Add("cpf", usuario.Cpf, DbType.String);
                parameters.Add("data_nascimento", usuario.DataNascimento, DbType.DateTime);
                parameters.Add("telefone", usuario.Telefone, DbType.String);
                parameters.Add("cep", usuario.Cep, DbType.String);
                parameters.Add("endereco", usuario.Endereco, DbType.String);
                parameters.Add("numero", usuario.Numero, DbType.String);
                parameters.Add("complemento", usuario.Complemento, DbType.String);
                parameters.Add("bairro", usuario.Bairro, DbType.String);
                parameters.Add("cidade", usuario.Cidade, DbType.String);
                parameters.Add("uf", usuario.Uf, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public bool VerificarCadastroUsuario(string email)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT codigo from usuario where email = @email";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("email", email, DbType.String);

                var result = connection.QueryFirstOrDefault<int>(sql, parameters);

                return result != 0;
            }
        }
    }
}
