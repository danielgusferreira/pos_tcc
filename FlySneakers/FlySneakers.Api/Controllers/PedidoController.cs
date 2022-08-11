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
        private readonly IGraficosPedidosUseCase graficosPedidosUseCase;

        public PedidoController(IActionResultConverter actionResultConverter, ICadastrarPedidoUseCase cadastrarPedidoUseCase, IGraficosPedidosUseCase graficosPedidosUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.cadastrarPedidoUseCase = cadastrarPedidoUseCase;
            this.graficosPedidosUseCase = graficosPedidosUseCase;
        }

        /// <summary>
        /// Obter dados de pedidos para gerar graficos.
        /// </summary>
        /// <response code="200">graficos retornado</response>
        /// <response code="400">graficos não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("graficos")]
        public ActionResult<GraficoDto> ObterGraficos()
        {
            var result = graficosPedidosUseCase.Execute();

            return Ok(result);
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

            return Ok(result);
        }
    }
}
