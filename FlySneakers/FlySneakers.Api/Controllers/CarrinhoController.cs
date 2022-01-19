using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/carrinho")]
    public class CarrinhoController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public CarrinhoController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter o carrinho do cliente informado pelo ID
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 serão retornados os carrinhos do usuario</remarks>
        /// <response code="200">Carrinho retornado</response>
        /// <response code="400">Carrinho não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idUsuario}")]
        public ActionResult<IEnumerable<Carrinho>> ObterCarrinhos(int idUsuario)
        {
            var listaUsuario1 = new List<Carrinho>
            {
                new Carrinho
                {
                    Codigo = 1,
                    CodigoUsuario = 1,
                    ProdutoSku = new ProdutoSku { Codigo = 1, ProdutoCodigo = 1, Valor = 100, Estoque = 400, Tamanho = "39" },
                    Produto = new Produto { Codigo = 1, Nome = "Adidas SuperStar", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 1, CodigoMarca = 1},
                    Quantidade = 2
                },

                new Carrinho
                {
                    Codigo = 2,
                    CodigoUsuario = 1,
                    ProdutoSku = new ProdutoSku { Codigo = 2, ProdutoCodigo = 2, Valor = 200, Estoque = 500, Tamanho = "40" },
                    Produto = new Produto { Codigo = 2, Nome = "Nike Air Force 1", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 2, CodigoMarca = 2},
                    Quantidade = 2
                }
            };

            var listaUsuario2 = new List<Carrinho>
            {
                new Carrinho
                {
                    Codigo = 3,
                    CodigoUsuario = 2,
                    ProdutoSku = new ProdutoSku { Codigo = 1, ProdutoCodigo = 1, Valor = 100, Estoque = 400, Tamanho = "39" },
                    Produto = new Produto { Codigo = 1, Nome = "Adidas SuperStar", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 1, CodigoMarca = 1},
                    Quantidade = 5
                },

                new Carrinho
                {
                    Codigo = 4,
                    CodigoUsuario = 2,
                    ProdutoSku = new ProdutoSku { Codigo = 2, ProdutoCodigo = 2, Valor = 200, Estoque = 500, Tamanho = "40" },
                    Produto = new Produto { Codigo = 2, Nome = "Nike Air Force 1", Descricao = "Descrição tenis", DataCriacao = DateTime.Now, CodigoCategoria = 2, CodigoMarca = 2},
                    Quantidade = 2
                }
            };

            return idUsuario switch
            {
                1 => Ok(listaUsuario1),
                2 => Ok(listaUsuario2),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Cria carrinho para o usuario informado
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Carrinho criado</response>
        /// <response code="400">Usuario não encontrando</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Carrinho> CadastrarCarrinho([FromBody] Carrinho Carrinho)
        {
            Carrinho.Codigo = 3;
            return Ok(Carrinho);
        }

        /// <summary>
        /// Remove item carrinho
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Carrinho removido</response>
        /// <response code="400">Carrinho não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idUsuario}/carrinho/{idCarrinho}")]
        public ActionResult<int> RemoverCarrinho(int idCarrinho)
        {
            return Ok(idCarrinho);
        }

    }
}
