using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/usuario-perfil")]
    public class UsuarioPerfilController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public UsuarioPerfilController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter perfis usuarios
        /// </summary>
        /// <response code="200">Perfil usuario retornados</response>
        /// <response code="400">Perfil usuario não encontrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioPerfil>> ObterUsuarioPerfis()
        {
            var listaUsuarioPerfil = new List<UsuarioPerfil>
            {
                new UsuarioPerfil { Codigo = 1, Nome = "Administrador" },
                new UsuarioPerfil { Codigo = 2, Nome = "Funcionario" },
                new UsuarioPerfil { Codigo = 2, Nome = "Usuario comum" }
            };

            return Ok(listaUsuarioPerfil);
        }

        /// <summary>
        /// Cadastrar perfil usuario
        /// </summary>
        /// <response code="200">Perfil usuario cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<UsuarioPerfil> CadastrarUsuarioPerfil([FromBody] UsuarioPerfil UsuarioPerfil)
        {
            UsuarioPerfil.Codigo = 3;
            return Ok(UsuarioPerfil);
        }

        /// <summary>
        /// Alterar perfil usuario a partir do ID informado
        /// </summary>
        /// <response code="200">Perfil usuario alterado</response>
        /// <response code="400">Perfil usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idUsuarioPerfil}")]
        public ActionResult<UsuarioPerfil> AlterarUsuarioPerfil(int idUsuarioPerfil, [FromBody] UsuarioPerfil UsuarioPerfil)
        {
            return Ok(UsuarioPerfil);
        }

        /// <summary>
        /// Remover perfil usuario a partir do ID informado
        /// </summary>
        /// <response code="200">Perfil usuario removido</response>
        /// <response code="400">Perfil usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("idPerfilUsuario")]
        public ActionResult<int> RemoverUsuarioPerfil(int idPerfilUsuario)
        {
            return Ok(idPerfilUsuario);
        }

    }
}
