using FlySneakers.Api.Models;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.UseCase.Produto;
using FlySneakers.UseCases;
using Microsoft.AspNetCore.Http;
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
        private readonly IObterProdutoPagInicialUseCase obterProdutoPagInicialUseCase;
        private readonly IObterProdutoDetalhesUseCase obterProdutoDetalheUseCase;

        public ProdutosController(IActionResultConverter actionResultConverter, IObterProdutoPagInicialUseCase obterProdutoPagInicialUseCase,
            IObterProdutoDetalhesUseCase obterProdutoDetalheUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.obterProdutoPagInicialUseCase = obterProdutoPagInicialUseCase;
            this.obterProdutoDetalheUseCase = obterProdutoDetalheUseCase;
        }

        /// <summary>
        /// Obter produtos cadastrados
        /// </summary>
        /// <response code="200">Produtos retornados</response>
        /// <response code="400">Produtos não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoPagInicialDto>> ObterProdutos([FromQuery] int codigoCategoria = 0, int codigoMarca = 0)
        {
            var result = obterProdutoPagInicialUseCase.Execute(codigoCategoria, codigoMarca);

            if (result == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(result);
        }

        /// <summary>
        /// Obter produto a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado o produto</remarks>
        /// <response code="200">Produto retornado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{codigo}")]
        public ActionResult<ProdutoDetalhesDto> ObterProdutoDetalhe(int codigo)
        {
            var result = obterProdutoDetalheUseCase.Execute(codigo);

            if (result == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(result);
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
