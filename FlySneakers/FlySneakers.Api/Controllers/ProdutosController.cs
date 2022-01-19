using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public ProdutosController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter produtos cadastrados
        /// </summary>
        /// <response code="200">Produtos retornados</response>
        /// <response code="400">Produtos não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> ObterProdutos()
        {
            var listaProdutos = new List<Produto>
            {
                new Produto { Codigo = 1, Nome = "Adidas SuperStar", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 1, CodigoMarca = 1 },
                new Produto { Codigo = 2, Nome = "Nike Air Force 1", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 2, CodigoMarca = 2 }
            };

            return Ok(listaProdutos);
        }

        /// <summary>
        /// Obter produto a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado o produto</remarks>
        /// <response code="200">Produto retornado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idProduto}")]
        public ActionResult<IEnumerable<string>> ObterProduto(int idProduto)
        {
            return idProduto switch
            {
                1 => Ok(new Produto { Codigo = 1, Nome = "Adidas SuperStar", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 1, CodigoMarca = 1 }),
                2 => Ok(new Produto { Codigo = 2, Nome = "Nike Air Force 1", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 2, CodigoMarca = 2 }),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Cadastrar produto
        /// </summary>
        /// <response code="200">Produto cadatrado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Produto> CadastrarProdutos([FromBody] Produto produto)
        {
            produto.Codigo = 3;
            return Ok(produto);
        }

        /// <summary>
        /// Alterar produto a partir do ID informado
        /// </summary>
        /// <response code="200">Produto alterado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idProduto}")]
        public ActionResult<Produto> AlterarDadosProduto(int idProduto, [FromBody] Produto produto)
        {
            return Ok(produto);
        }

        /// <summary>
        /// Remover produto a partir do ID informado
        /// </summary>
        /// <response code="200">Produto removido</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idProduto}")]
        public ActionResult<int> RemoverProduto(int idProduto)
        {
            return Ok(idProduto);
        }
    }
}
