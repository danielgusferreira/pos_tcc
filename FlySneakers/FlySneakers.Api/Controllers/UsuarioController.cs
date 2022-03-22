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
    [Route("api/usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;
        private readonly ILogarUseCase logarUseCase;
        private readonly ICadastrarUsuarioUseCase cadastrarUsuarioUseCase;

        public UsuarioController(IActionResultConverter actionResultConverter, ILogarUseCase logarUseCase, ICadastrarUsuarioUseCase cadastrarUsuarioUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.logarUseCase = logarUseCase;
            this.cadastrarUsuarioUseCase = cadastrarUsuarioUseCase;
        }

        /// <summary>
        /// Obter usuarios
        /// </summary>
        /// <response code="200">Usuarios retornados</response>
        /// <response code="400">Usuarios não encontrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> ObterUsuarios()
        {
            var listaUsuarios = new List<Usuario>
            {
                new Usuario { Codigo = 1, Nome = "Usuario 1", Email = "teste1@gmail.com", DataCriacao = DateTime.Now },
                new Usuario { Codigo = 2, Nome = "Usuario 2", Email = "teste2@gmail.com", DataCriacao = DateTime.Now },
                new Usuario { Codigo = 2, Nome = "Usuario 3", Email = "teste3@gmail.com", DataCriacao = DateTime.Now }
            };

            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Realizar login usuario
        /// </summary>
        /// <remarks>Ao informar o email: teste1@gmail.com e senha: 1234 será retornado OK</remarks>
        /// <response code="200">Usuario logado</response>
        /// <response code="404">Usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost("login")]
        public IActionResult Logar([FromBody] LoginDto login)
        {
            var result = logarUseCase.Execute(login);

            if (result == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(result);
        }

        /// <summary>
        /// Cadastrar usuario
        /// </summary>
        /// <response code="200">Usuario cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Usuario> CadastrarUsuario([FromBody] Usuario usuario)
        {
            var result = cadastrarUsuarioUseCase.Execute(usuario);

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        /// <summary>
        /// Alterar usuario a partir do ID informado
        /// </summary>
        /// <response code="200">Usuario alterado</response>
        /// <response code="400">Usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idUsuario}")]
        public ActionResult<Usuario> AlterarUsuario(int idUsuario, [FromBody] Usuario usuario)
        {
            return Ok(usuario);
        }

        /// <summary>
        /// Remover usuario a partir do ID informado
        /// </summary>
        /// <response code="200">Usuario removido</response>
        /// <response code="400">Usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idUsuario}")]
        public ActionResult<int> RemoverUsuario(int idUsuario)
        {
            return Ok(idUsuario);
        }

    }
}
