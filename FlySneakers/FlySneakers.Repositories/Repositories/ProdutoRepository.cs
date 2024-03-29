﻿using Dapper;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlySneakers.Repositories.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        public readonly string Connection = "Server=tcp:flysneakerstcc.database.windows.net,1433;Initial Catalog=flysneakersdb;Persist Security Info=False;User ID=flysneakeradm;Password=Futebol101112@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public ProdutoRepository()
        {
        }

        public IEnumerable<Produtos> ObterListaProdutos()
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"select 	
                                    codigo,
	                                nome,
	                                descricao,
	                                data_criacao as DataCriacao,
	                                codigo_categoria as CodigoCategoria,
	                                codigo_marca as CodigoMarca,
	                                foto1 as LinkFoto1,
	                                foto2 as LinkFoto2,
	                                foto3 as LinkFoto3,
	                                foto4 as LinkFoto4
                                from
                                    produto; ";

                var result = connection.Query<Produtos>(sql);

                return result;
            }
        }

        public IEnumerable<ProdutoSku> ObterListaProdutosDados(int codigoProduto)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT
                                    codigo,
                                    codigo_produto AS ProdutoCodigo,
                                    tamanho,
                                    valor,
                                    data_criacao AS DataCriacao,
                                    estoque
                                FROM
                                    produto_dados
                                WHERE
                                    codigo_produto = @codigoProduto; ";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigoProduto", codigoProduto, DbType.Int32);

                var result = connection.Query<ProdutoSku>(sql, parameters);

                return result;
            }
        }

        public Task<IEnumerable<Produto>> ObterProdutosCompletos()
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "SELECT * FROM produto p INNER JOIN produto_dados pd ON PD.codigo_produto = P.codigo;";

                var result = connection.QueryAsync<Produto>(sql);

                return result;
            }
        }

        public IEnumerable<ProdutoPagInicialDto> ObterProdutosPagInicial(int codigoCategoria, int codigoMarca)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT
                                p.codigo as codigo,
	                            p.nome as nome,
	                            p.foto1 as foto,
	                            (SELECT MIN(pd.valor) FROM produto_dados pd WHERE pd.codigo_produto = p.codigo) as valor,
	                            p.codigo_categoria as CodigoCategoria,
	                            p.codigo_marca as CodigoMarca
                            FROM
	                            produto p

	                            INNER JOIN produto_categoria c ON
		                            c.codigo = p.codigo_categoria

	                            INNER JOIN marca_produto m ON
		                            m.codigo = p.codigo_marca ";

                DynamicParameters parameters = new DynamicParameters();

                if (codigoCategoria != 0)
                {
                    sql += "WHERE c.codigo = @codigoCategoria";

                    parameters.Add("codigoCategoria", codigoCategoria, DbType.Int32);
                }

                if (codigoMarca != 0)
                {
                    sql += "WHERE m.codigo = @codigoMarca";

                    parameters.Add("codigoMarca", codigoMarca, DbType.Int32);
                }

                var result = connection.Query<ProdutoPagInicialDto>(sql, parameters);

                return result;
            }
        }

        public ProdutoDetalhesDto ObterProdutoDetalhes(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"SELECT 
                                    CODIGO, 
                                    NOME, 
                                    DESCRICAO, 
                                    FOTO1, 
                                    FOTO2, 
                                    FOTO3, 
                                    FOTO4
                                FROM
                                    produto 
                                WHERE 
                                    CODIGO = @codigo";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.QueryFirstOrDefault<ProdutoDetalhesDto>(sql, parameters);

                return result;
            }
        }

        public IEnumerable<EstoqueDto> ObterEstoque(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"select
	                            codigo,
	                            codigo_produto as CodigoProduto,
	                            tamanho,
	                            estoque,
	                            (SELECT MIN(pd2.valor) FROM produto_dados pd2 WHERE pd2.codigo_produto = pd.codigo_produto) as Valor
                            from
	                            produto_dados pd
                            where
	                            codigo_produto = @codigo";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Query<EstoqueDto>(sql, parameters);

                return result;
            }
        }

        public int CadastrarProduto(Produtos produto)
        {
            using (var connection = new SqlConnection(Connection))
            {

                string sql = @"INSERT INTO produto(nome, descricao, data_criacao, codigo_categoria, codigo_marca, foto1, foto2, foto3, foto4) 
	                            VALUES(@nome, @descricao, @data_criacao, @codigo_categoria, @codigo_marca, @foto1, @foto2, @foto3, @foto4);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("nome", produto.Nome, DbType.String);
                parameters.Add("descricao", produto.Descricao, DbType.String);
                parameters.Add("data_criacao", DateTime.Now, DbType.DateTime);
                parameters.Add("codigo_categoria", produto.CodigoCategoria, DbType.Int32);
                parameters.Add("codigo_marca", produto.CodigoMarca, DbType.Int32);
                parameters.Add("foto1", produto.LinkFoto1, DbType.String);
                parameters.Add("foto2", produto.LinkFoto2, DbType.String);
                parameters.Add("foto3", produto.LinkFoto3, DbType.String);
                parameters.Add("foto4", produto.LinkFoto4, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int CadastrarProdutoDados(ProdutoSku produto)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"INSERT INTO produto_dados(codigo_produto,tamanho,valor,data_criacao,estoque)
                                VALUES(@codigo_produto, @tamanho, @valor, @data_criacao, @estoque);";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo_produto", produto.ProdutoCodigo, DbType.Int32);
                parameters.Add("tamanho", produto.Tamanho, DbType.String);
                parameters.Add("valor", produto.Valor, DbType.Decimal);
                parameters.Add("data_criacao", DateTime.Now, DbType.DateTime);
                parameters.Add("estoque", produto.Estoque, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int AtualizarProdutoDados(ProdutoSku produto)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE
	                                produto_dados
                                SET
	                                tamanho	= @tamanho,
	                                valor = @valor,
	                                estoque	 = @estoque
                                WHERE
	                                codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", produto.Codigo, DbType.Int32);
                parameters.Add("tamanho", produto.Tamanho, DbType.String);
                parameters.Add("valor", produto.Valor, DbType.Decimal);
                parameters.Add("estoque", produto.Estoque, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            } 
        }

        public int AtualizarProduto(Produtos produto)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = @"UPDATE
	                                produto
                                SET
	                                nome =	@nome,			
	                                descricao =	@descricao,		
	                                codigo_categoria =	@codigo_categoria,
	                                codigo_marca =	@codigo_marca,
	                                foto1 =	@foto1,			
	                                foto2 =	@foto2,			
	                                foto3 =	@foto3,			
	                                foto4 =	@foto4			
                                WHERE
	                                codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", produto.Codigo, DbType.Int32);
                parameters.Add("nome", produto.Nome, DbType.String);
                parameters.Add("descricao", produto.Descricao, DbType.String);
                parameters.Add("codigo_categoria", produto.CodigoCategoria, DbType.Int32);
                parameters.Add("codigo_marca", produto.CodigoMarca, DbType.Int32);
                parameters.Add("foto1", produto.LinkFoto1, DbType.String);
                parameters.Add("foto2", produto.LinkFoto2, DbType.String);
                parameters.Add("foto3", produto.LinkFoto3, DbType.String);
                parameters.Add("foto4", produto.LinkFoto4, DbType.String);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverProdutoDados(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "DELETE FROM produto_dados where codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }
        }

        public int RemoverProduto(int codigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string sql = "DELETE FROM produto where codigo = @codigo;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo, DbType.Int32);

                var result = connection.Execute(sql, parameters);

                return result;
            }

        }

    }
} 
