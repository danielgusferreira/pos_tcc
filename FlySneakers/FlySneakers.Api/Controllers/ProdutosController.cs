using FlySneakers.Api.Models;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.UseCase;
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
        private readonly ICadastarProdutoUseCase cadastarProdutoUseCase;
        private readonly ICadastarProdutoDadosUseCase cadastarProdutoDadosUseCase;
        private readonly IAlterarProdutoUseCase alterarProdutoUseCase;
        private readonly IAlterarProdutoDadosUseCase alterarProdutoDadosUseCase;
        private readonly IObterProdutoCriacaoUseCase obterProdutoCriacaoUseCase;
        private readonly IObterProdutoDadosCriacaoUseCase obterProdutoDadosCriacaoUseCase;
        private readonly IRemoverProdutoUseCase removerProdutoUseCase;
        private readonly IRemoverProdutoDadosUseCase removerProdutoDadosUseCase;

        public ProdutosController(IActionResultConverter actionResultConverter,
            IObterProdutoPagInicialUseCase obterProdutoPagInicialUseCase,
            IObterProdutoDetalhesUseCase obterProdutoDetalheUseCase,
            ICadastarProdutoUseCase cadastarProdutoUseCase,
            ICadastarProdutoDadosUseCase cadastarProdutoDadosUseCase,
            IAlterarProdutoUseCase alterarProdutoUseCase,
            IAlterarProdutoDadosUseCase alterarProdutoDadosUseCase,
            IObterProdutoCriacaoUseCase obterProdutoCriacaoUseCase,
            IObterProdutoDadosCriacaoUseCase obterProdutoDadosCriacaoUseCase, IRemoverProdutoUseCase removerProdutoUseCase, IRemoverProdutoDadosUseCase removerProdutoDadosUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.obterProdutoPagInicialUseCase = obterProdutoPagInicialUseCase;
            this.obterProdutoDetalheUseCase = obterProdutoDetalheUseCase;
            this.cadastarProdutoUseCase = cadastarProdutoUseCase;
            this.cadastarProdutoDadosUseCase = cadastarProdutoDadosUseCase;
            this.alterarProdutoUseCase = alterarProdutoUseCase;
            this.alterarProdutoDadosUseCase = alterarProdutoDadosUseCase;
            this.obterProdutoCriacaoUseCase = obterProdutoCriacaoUseCase;
            this.obterProdutoDadosCriacaoUseCase = obterProdutoDadosCriacaoUseCase;
            this.removerProdutoUseCase = removerProdutoUseCase;
            this.removerProdutoDadosUseCase = removerProdutoDadosUseCase;
        }


        /// <summary>
        /// Obter produtos cadastrados
        /// </summary>
        /// <response code="200">Produtos retornados</response>
        /// <response code="400">Produtos não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("criacao")]
        public ActionResult<IEnumerable<Produtos>> ObterProdutosCriacao()
        {
            var result = obterProdutoCriacaoUseCase.Execute();

            if (result == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(result);
        }

        /// <summary>
        /// Obter produtos cadastrados
        /// </summary>
        /// <response code="200">Produtos retornados</response>
        /// <response code="400">Produtos não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("criacao-dados")]
        public ActionResult<IEnumerable<ProdutoSku>> ObterProdutosDadosCriacao([FromQuery] int codigoProduto)
        {
            var result = obterProdutoDadosCriacaoUseCase.Execute(codigoProduto);

            if (result == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(result);
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
        public ActionResult<Produto> CadastrarProdutos([FromBody] Produtos produto)
        {
            var result = cadastarProdutoUseCase.Execute(produto);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        /// <summary>
        /// Cadastrar produto dados
        /// </summary>
        /// <response code="200">Produto cadatrado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost("dados")]
        public ActionResult<Produto> CadastrarProdutosDados([FromBody] ProdutoSku produtoSku)
        {
            var result = cadastarProdutoDadosUseCase.Execute(produtoSku);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        /// <summary>
        /// Alterar produto a partir do ID informado
        /// </summary>
        /// <response code="200">Produto alterado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idProduto}")]
        public ActionResult<Produto> AlterarInformacoesProduto(int idProduto, [FromBody] Produtos produto)
        {
            produto.Codigo = idProduto;
            var result = alterarProdutoUseCase.Execute(produto);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        } 

        /// <summary>
        /// Alterar produto a partir do ID informado
        /// </summary>
        /// <response code="200">Produto alterado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idProduto}/dados")]
        public ActionResult<Produto> AlterarInformacoesProdutoDados(int idProduto, [FromBody] ProdutoSku produto)
        {
            produto.Codigo = idProduto;
            var result = alterarProdutoDadosUseCase.Execute(produto);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
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
            var result = removerProdutoUseCase.Execute(idProduto);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }


        /// <summary>
        /// Remover marca
        /// </summary>
        /// <response code="200">Marca removida</response>
        /// <response code="400">Marca não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idProduto}/dados")]
        public ActionResult RemoverProdutoDados(int idProduto)
        {
            var result = removerProdutoDadosUseCase.Execute(idProduto);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }
    }
}
