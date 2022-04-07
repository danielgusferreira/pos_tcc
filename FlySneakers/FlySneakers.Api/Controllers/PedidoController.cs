using FlySneakers.Api.Models;
using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;
        private readonly ICadastrarPedidoUseCase cadastrarPedidoUseCase;

        public PedidoController(IActionResultConverter actionResultConverter, ICadastrarPedidoUseCase cadastrarPedidoUseCase = null)
        {
            this.actionResultConverter = actionResultConverter;
            this.cadastrarPedidoUseCase = cadastrarPedidoUseCase;
        }

        /// <summary>
        /// Obter pedido a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado o pedido</remarks>
        /// <response code="200">Pedido retornado</response>
        /// <response code="400">Pedido não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idUsuario}/pedido/{idPedido}")]
        public ActionResult<IEnumerable<Pedido>> ObterPedido(int idUsuario, int idPedido)
        {

            var listaCarrinho = new List<Carrinho>
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

            return idUsuario switch
            {
                1 => Ok(new Pedido { Codigo = 1, CodigoPagamento = 1,  CodigoRastreio = "GE34212", DataEnvio = DateTime.Now, DataPedido = DateTime.Now, Status = 1, Carrinho = listaCarrinho }),
                2 => Ok(new Pedido { Codigo = 2, CodigoPagamento = 2, CodigoRastreio = "GE34212", DataEnvio = DateTime.Now, DataPedido = DateTime.Now, Status = 2, Carrinho = listaCarrinho }),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Obter pedidos a partir do ID do usuario
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado os pedidos do usuário</remarks>
        /// <response code="200">Pedido retornado</response>
        /// <response code="400">Pedido não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idUsuario}")]
        public ActionResult<IEnumerable<Pedido>> ObterPedidos(int idUsuario)
        {
            var listaCarrinho = new List<Carrinho>
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

            var listaPedidos1 = new List<Pedido>
            {
                new Pedido { Codigo = 1, CodigoPagamento = 1,  CodigoRastreio = "GE34212", DataEnvio = DateTime.Now, DataPedido = DateTime.Now, Status = 1, Carrinho = listaCarrinho },
                new Pedido { Codigo = 1, CodigoPagamento = 1,  CodigoRastreio = "GE34212", DataEnvio = DateTime.Now, DataPedido = DateTime.Now, Status = 1, Carrinho = listaCarrinho }
            };

            var listaPedidos2 = new List<Pedido>
            {
                new Pedido { Codigo = 2, CodigoPagamento = 2,  CodigoRastreio = "GE34212", DataEnvio = DateTime.Now, DataPedido = DateTime.Now, Status = 1, Carrinho = listaCarrinho },
                new Pedido { Codigo = 2, CodigoPagamento = 2,  CodigoRastreio = "GE34212", DataEnvio = DateTime.Now, DataPedido = DateTime.Now, Status = 1, Carrinho = listaCarrinho }
            };

            return idUsuario switch
            {
                1 => Ok(listaPedidos1),
                2 => Ok(listaPedidos2),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Cadastrar pedido
        /// </summary>
        /// <response code="200">Pedido criado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<int> CadastrarPedido([FromBody] CadastrarPedidoDto pedido)
        {
            int result = cadastrarPedidoUseCase.Execute(pedido);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        /// <summary>
        /// Alterar dados pedido
        /// </summary>
        /// <response code="200">Pedido alterado</response>
        /// <response code="400">Pedido não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idUsuario}/Pedido/{idPedido}")]
        public ActionResult<int> AlterarPedido(int idUsuario, int idPedido)
        {
            return Ok(idPedido);
        }

    }
}
