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
        private readonly ICadastrarDadosUsuarioUseCase cadastrarDadosUsuarioUseCase;
        private readonly IObterUsuarioDadosUseCase obterUsuarioDadosUseCase;
        private readonly IVerificarCadastroUsuarioUseCase verificarCadastroUsuarioUseCase;
        private readonly IObterUsuariosUseCase obterUsuariosUseCase;
        private readonly IRemoverUsuarioUseCase removerUsuarioUseCase;
        private readonly IEditarUsuarioUseCase editarUsuarioUseCase;

        public UsuarioController(IActionResultConverter actionResultConverter,
            ILogarUseCase logarUseCase,
            ICadastrarUsuarioUseCase cadastrarUsuarioUseCase,
            ICadastrarDadosUsuarioUseCase cadastrarDadosUsuarioUseCase,
            IObterUsuarioDadosUseCase obterUsuarioDadosUseCase,
            IVerificarCadastroUsuarioUseCase verificarCadastroUsuarioUseCase,
            IObterUsuariosUseCase obterUsuariosUseCase,
            IRemoverUsuarioUseCase removerUsuarioUseCase, 
            IEditarUsuarioUseCase editarUsuarioUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.logarUseCase = logarUseCase;
            this.cadastrarUsuarioUseCase = cadastrarUsuarioUseCase;
            this.cadastrarDadosUsuarioUseCase = cadastrarDadosUsuarioUseCase;
            this.obterUsuarioDadosUseCase = obterUsuarioDadosUseCase;
            this.verificarCadastroUsuarioUseCase = verificarCadastroUsuarioUseCase;
            this.obterUsuariosUseCase = obterUsuariosUseCase;
            this.removerUsuarioUseCase = removerUsuarioUseCase;
            this.editarUsuarioUseCase = editarUsuarioUseCase;
        }

        /// <summary>
        /// Obter usuarios
        /// </summary>
        /// <response code="200">Usuarios retornados</response>
        /// <response code="400">Usuarios não encontrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost("obter")]
        public ActionResult<IEnumerable<UsuariosDto>> ObterUsuarios(ObterUsuariosDto obterUsuariosDto)
        {
            var result = obterUsuariosUseCase.Execute(obterUsuariosDto);

            return Ok(result);
        }

        /// <summary>
        /// Obter usuarios
        /// </summary>
        /// <response code="200">Usuarios retornados</response>
        /// <response code="400">Usuarios não encontrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("dados/{idUsuario}")]
        public ActionResult<UsuarioDados> ObterUsuarioDados(int idUsuario)
        {
            var result = obterUsuarioDadosUseCase.Execute(idUsuario);

            return Ok(result);
        }

        /// <summary>
        /// Obter usuarios
        /// </summary>
        /// <response code="200">Retorna resultado da busca</response>
        [HttpGet("verificarCadastro/{email}")]
        public ActionResult<UsuarioDados> VerificarCadastroUsuario(string email)
        {
            var result = verificarCadastroUsuarioUseCase.Execute(email);

            return Ok(result);
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
        /// Cadastrar dados usuario
        /// </summary>
        /// <response code="200">Dados usuario cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost("dados")]
        public ActionResult<UsuarioDados> CadastrarUsuarioDados([FromBody] UsuarioDados UsuarioDados)
        {
            var result = cadastrarDadosUsuarioUseCase.Execute(UsuarioDados);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }

        /// <summary>
        /// Alterar usuario a partir do ID informado
        /// </summary>
        /// <response code="200">Usuario alterado</response>
        /// <response code="400">Usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idUsuario}")]
        public ActionResult<Usuario> AlterarUsuario(int idUsuario, [FromBody] UsuariosDto usuario)
        {
            usuario.Codigo = idUsuario;
            var result = editarUsuarioUseCase.Execute(usuario);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);    
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
            var result = removerUsuarioUseCase.Execute(idUsuario);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

    }
}
