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
    [Route("api/carrinho")]
    public class CarrinhoController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;
        private readonly IAdicionarItemCarrinhoUseCase adicionarItemCarrinhoUseCase;
        private readonly IObterCarrinhoUsuarioUseCase obterCarrinhoUsuarioUseCase;


        public CarrinhoController(IActionResultConverter actionResultConverter, 
            IAdicionarItemCarrinhoUseCase adicionarItemCarrinhoUseCase, 
            IObterCarrinhoUsuarioUseCase obterCarrinhoUsuarioUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.adicionarItemCarrinhoUseCase = adicionarItemCarrinhoUseCase;
            this.obterCarrinhoUsuarioUseCase = obterCarrinhoUsuarioUseCase;
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
            var result = obterCarrinhoUsuarioUseCase.Execute(idUsuario);

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        /// <summary>
        /// Cria carrinho para o usuario informado
        /// </summary>
        /// <response code="200">Carrinho criado</response>
        /// <response code="400">Usuario não encontrando</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public IActionResult CadastrarCarrinho([FromBody] CadastrarCarrinhoDto Carrinho)
        {
            int result = adicionarItemCarrinhoUseCase.Execute(Carrinho);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        /// <summary>
        /// Remove item carrinho
        /// </summary>
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
