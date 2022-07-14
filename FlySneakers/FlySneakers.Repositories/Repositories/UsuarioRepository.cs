using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlySneakers.Repositories.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public UsuarioRepository()
        {
        }


        public Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT * FROM usuario u INNER JOIN usuario_dados ud ON ud.codigo_usuario = u.codigo INNER JOIN usuario_perfil up ON up.codigo = u.codigo_perfil";

                var result = connection.QueryAsync<Usuario>(sql);

                return result;
            }
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

        public int AtualizarUsuario(UsuariosDto usuario)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE
	                                usuario
                                SET
	                                codigo_perfil = @codigoPerfil,
	                                nome = @Nome,
	                                email = @Email,
	                                senha = @Senha
                                WHERE
	                                codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigoPerfil", usuario.Tipo, DbType.Int32);
                parameters.Add("Nome", usuario.Nome, DbType.String);
                parameters.Add("Email", usuario.Email, DbType.String);
                parameters.Add("Senha", usuario.Senha, DbType.String);
                parameters.Add("codigo", usuario.Codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int AtualizarDadosUsuario(UsuariosDto usuario)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE
	                                usuario_dados
                                SET
	                                cpf = @cpf,
	                                data_nascimento	= @data_nascimento,
	                                telefone = @telefone,
	                                cep	= @cep,
	                                endereco = @endereco,
	                                numero = @numero,
	                                complemento	= @complemento,
	                                bairro	= @bairro,
	                                cidade = @cidade,
	                                uf = @uf
                                WHERE
	                                codigo_usuario = @codigo";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", usuario.Codigo, DbType.Int32);
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

        public int RemoverUsuario(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"DELETE FROM usuario where codigo = @codigoUsuario;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigoUsuario", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverDadosUsuario(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"DELETE FROM usuario_dados where codigo_usuario = @codigoUsuario;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigoUsuario", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public IEnumerable<UsuariosDto> ObterUsuarios(ObterUsuariosDto obterUsuariosDto)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT
	                                u.codigo,
	                                u.Nome, 
	                                u.Email, 
	                                u.Senha,
	                                u.codigo_perfil as Tipo,
	                                u.data_criacao as DataCriacao, 
	                                ud.codigo as CodigoUsuario, 
	                                ud.Cpf, 
	                                ud.data_nascimento as DataNascimento, 
	                                ud.Telefone, 
	                                ud.Cep, 
	                                ud.Endereco, 
	                                ud.Numero, 
	                                ud.Complemento, 
	                                ud.Bairro, 
	                                ud.Cidade, 
	                                ud.Uf 
                                FROM 
	                                usuario u 

	                                INNER JOIN usuario_dados ud ON 
		                                ud.codigo_usuario = u.codigo 
                                WHERE
	                                u.codigo_perfil IN @perfil";

                var result = connection.Query<UsuariosDto>(sql, new { perfil = obterUsuariosDto.TipoUsuario.ToArray() } );

                return result;
            }
        }
    }
}
