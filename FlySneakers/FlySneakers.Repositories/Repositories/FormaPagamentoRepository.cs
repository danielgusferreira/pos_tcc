using Dapper;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlySneakers.Repositories.Repositories
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public FormaPagamentoRepository()
        {
        }

        public IEnumerable<MeioPagamento> ObterFormaPagamentos()
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT codigo, nome, descricao FROM meio_pagamento;";

                var result = connection.Query<MeioPagamento>(sql);

                return result;
            }
        }

        public int CadastrarFormaPagamento(MeioPagamento formaPagamento)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"INSERT INTO meio_pagamento(nome, descricao) VALUES(@nome, @descricao);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("nome", formaPagamento.Nome, DbType.String);
                parameters.Add("descricao", formaPagamento.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int AtualizarFormaPagamento(MeioPagamento formaPagamento)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE meio_pagamento SET nome = @nome,	descricao = @descricao  WHERE codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", formaPagamento.Codigo, DbType.Int32);
                parameters.Add("nome", formaPagamento.Nome, DbType.String);
                parameters.Add("descricao", formaPagamento.Descricao, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverFormaPagamento(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "DELETE meio_pagamento WHERE codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }
    }
}
