using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/comentario")]
    public class ComentarioController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;
        private readonly IObterComentarioUseCase obterComentarioUseCase;
        private readonly ICadastarComentarioUseCase cadastarComentarioUseCase;
        private readonly IEditarComentarioUseCase editarComentarioUseCase;
        private readonly IRemoverComentarioUseCase removerComentarioUseCase;
        private readonly IVerificarExistenciaComentarioUseCase verificarExistenciaComentarioUseCase;

        public ComentarioController(IActionResultConverter actionResultConverter, IObterComentarioUseCase obterComentarioUseCase, ICadastarComentarioUseCase cadastarComentarioUseCase, IEditarComentarioUseCase editarComentarioUseCase, IRemoverComentarioUseCase removerComentarioUseCase, IVerificarExistenciaComentarioUseCase verificarExistenciaComentarioUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.obterComentarioUseCase = obterComentarioUseCase;
            this.cadastarComentarioUseCase = cadastarComentarioUseCase;
            this.editarComentarioUseCase = editarComentarioUseCase;
            this.removerComentarioUseCase = removerComentarioUseCase;
            this.verificarExistenciaComentarioUseCase = verificarExistenciaComentarioUseCase;
        }

        /// <summary>
        /// Obter os comentarios do produto a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado os comentarios dos produtos</remarks>
        /// <response code="200">Comentario retornada</response>
        /// <response code="400">Comentario não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idProduto}")]
        public ActionResult<IEnumerable<ComentarioDto>> ObterComentarioProduto(int idProduto)
        {
            var listaCategoria = obterComentarioUseCase.Execute(idProduto);

            return Ok(listaCategoria);
        }

        /// <summary>
        /// Obter os comentarios do produto a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado os comentarios dos produtos</remarks>
        /// <response code="200">Comentario retornada</response>
        /// <response code="400">Comentario não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idProduto}/verificar/{codigoUsuario}")]
        public ActionResult<Comentario> VerificarExistenciaComentario(int codigoUsuario, int idProduto)
        {
            var result = verificarExistenciaComentarioUseCase.Execute(codigoUsuario, idProduto);

            return Ok(result);
        }

        /// <summary>
        /// Cadastrar comentario
        /// </summary>
        /// <response code="200">Comentario criado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Comentario> CadastrarComentario([FromBody] Comentario comentario)
        {
            var result = cadastarComentarioUseCase.Execute(comentario);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        /// <summary>
        /// Alterar comentario a partir do ID informado
        /// </summary>
        /// <response code="200">Comentario alterado</response>
        /// <response code="400">Comentario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idComentario}")]
        public ActionResult<Comentario> AlterarComentario(int idComentario, [FromBody] Comentario comentario)
        {
            comentario.Codigo = idComentario;
            var result = editarComentarioUseCase.Execute(comentario);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        /// <summary>
        /// Remover comentario a partir do ID informado
        /// </summary>
        /// <response code="200">Comentario removido</response>
        /// <response code="400">Comentario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idComentario}")]
        public ActionResult<int> RemoverComentario(int idComentario)
        {
            var result = removerComentarioUseCase.Execute(idComentario);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

    }
}
