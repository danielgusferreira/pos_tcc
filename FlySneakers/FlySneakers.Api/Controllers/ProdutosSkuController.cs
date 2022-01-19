using FlySneakers.Api.Models;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/produto-dados")]
    public class ProdutoSkusSkuController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public ProdutoSkusSkuController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter todas as informações dos produtos
        /// </summary>
        /// <response code="200">Produtos retornados</response>
        /// <response code="400">Produtos não encontrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("dados-produtos")]
        public ActionResult<IEnumerable<DadosProdutoDto>> ObterInformacoesProdutos()
        {
            var listaProduto = new List<DadosProdutoDto>
            {
                new DadosProdutoDto { CodigoSku = 1, CodigoProduto = 1, Valor = 100, Estoque = 400, Tamanho = "39", Marca = "Nike", Nome = "Air Force 1", Categorias = new List<Categoria>{ new Categoria {Codigo = 1, Nome = "Tênis" } } },
                new DadosProdutoDto { CodigoSku = 1, CodigoProduto = 2, Valor = 200, Estoque = 500, Tamanho = "40", Marca = "Adidas", Nome = "SuperStar", Categorias = new List<Categoria>{ new Categoria {Codigo = 1, Nome = "Tênis" } } }
            };

            return Ok(listaProduto);
        }

        /// <summary>
        /// Obter todas as informações do produto a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado todos os dados do produto</remarks>
        /// <response code="200">Produto retornado</response>
        /// <response code="400">Produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("dados-produto/{idProdutoSku}")]
        public ActionResult<DadosProdutoDto> ObterInformacoesProduto(int idProdutoSku)
        {
            return idProdutoSku switch
            {
                1 => Ok(new DadosProdutoDto { CodigoSku = 1, CodigoProduto = 1, Valor = 100, Estoque = 400, Tamanho = "39", Marca = "Nike", Nome = "Air Force 1", Categorias = new List<Categoria> { new Categoria { Codigo = 1, Nome = "Tênis" } } }),
                2 => Ok(new DadosProdutoDto { CodigoSku = 1, CodigoProduto = 2, Valor = 200, Estoque = 500, Tamanho = "40", Marca = "Adidas", Nome = "SuperStar", Categorias = new List<Categoria> { new Categoria { Codigo = 1, Nome = "Tênis" } } }),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Obter dados dos produtos
        /// </summary>
        /// <response code="200">Dados produtos retornados</response>
        /// <response code="400">Dados produtos não encontrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoSku>> ObterProdutoSku()
        {
            var listaProdutoSku = new List<ProdutoSku>
            {
                new ProdutoSku { Codigo = 1, ProdutoCodigo = 1, Valor = 100, Estoque = 400, Tamanho = "39" },
                new ProdutoSku { Codigo = 2, ProdutoCodigo = 2, Valor = 200, Estoque = 500, Tamanho = "40" }
            };

            return Ok(listaProdutoSku);
        }

        /// <summary>
        /// Obter dados produto a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado o dados produto</remarks>
        /// <response code="200">Dados produto retornado</response>
        /// <response code="400">Dados produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idProdutoSku}")]
        public ActionResult<ProdutoSku> ObterProdutoSku(int idProdutoSku)
        {
            return idProdutoSku switch
            {
                1 => Ok(new ProdutoSku { Codigo = 1, ProdutoCodigo = 1, Valor = 100, Estoque = 400, Tamanho = "39" }),
                2 => Ok(new ProdutoSku { Codigo = 2, ProdutoCodigo = 2, Valor = 200, Estoque = 500, Tamanho = "40" }),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Cadastrar dados produto
        /// </summary>
        /// <response code="200">Produto cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<ProdutoSku> CadastrarProdutoSku([FromBody] ProdutoSku ProdutoSku)
        {
            ProdutoSku.Codigo = 3;
            return Ok(ProdutoSku);
        }

        /// <summary>
        /// Alterar dados produto a partir do ID informado
        /// </summary>
        /// <response code="200">Dados produto alterado</response>
        /// <response code="400">Dados produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idProdutoSku}")]
        public ActionResult<ProdutoSku> AlterarDadosProdutoSku(int idProdutoSku, [FromBody] ProdutoSku ProdutoSku)
        {
            return Ok(ProdutoSku);
        }

        /// <summary>
        /// Alterar estoque produto a partir do ID informado
        /// </summary>
        /// <response code="200">Estoque alterado</response>
        /// <response code="400">Dados produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idProdutoSku}/estoque")]
        public ActionResult<EstoqueDto> AlterarEstoque(int idProdutoSku, [FromBody] EstoqueDto estoqueDto)
        {
            return Ok(estoqueDto);
        }

        /// <summary>
        /// Remover dados produto a partir do ID informado
        /// </summary>
        /// <response code="200">Dados produto removido</response>
        /// <response code="400">Dados produto não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idProdutoSku}")]
        public ActionResult<int> RemoverProdutoSku(int idProdutoSku)
        {
            return Ok(idProdutoSku);
        }
    }
}
