using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
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

        public UsuarioController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
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
        /// <response code="400">Usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost("login")]
        public ActionResult<Usuario> Logar([FromBody] Usuario usuario)
        {
            if (usuario.Email == "teste1@gmail.com")
            {
                return Ok();
            }

            return NotFound();
        }

        /// <summary>
        /// Cadastrar usuario
        /// </summary>
        /// <response code="200">Usuario cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Usuario> CadastrarUsuario([FromBody] Usuario usuario)
        {
            usuario.Codigo = 3;
            return Ok(usuario);
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
