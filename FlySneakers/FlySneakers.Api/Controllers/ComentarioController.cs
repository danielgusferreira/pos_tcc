using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
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

        public ComentarioController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter os comentarios do produto a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado os comentarios dos produtos</remarks>
        /// <response code="200">Comentario retornada</response>
        /// <response code="400">Comentario não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idProduto}", Order = 1)]
        public ActionResult<IEnumerable<Comentario>> ObterComentarioProduto(int idProduto)
        {
            var listaComentarioProduto1 = new List<Comentario>
            {
                new Comentario { Codigo = 1, Nota = 5, Descricao = "Comentario produto1", CodigoProdutoSku = 1, CodigoUsuario = 1 },
                new Comentario { Codigo = 2, Nota = 4, Descricao = "Comentario produto1", CodigoProdutoSku = 1, CodigoUsuario = 1 }
            };

            var listaComentarioProduto2 = new List<Comentario>
            {
                new Comentario { Codigo = 2, Nota = 5, Descricao = "Comentario produto2", CodigoProdutoSku = 2, CodigoUsuario = 2 },
                new Comentario { Codigo = 3, Nota = 4, Descricao = "Comentario produto2", CodigoProdutoSku = 2, CodigoUsuario = 2 }
            };

            return idProduto switch
            {
                1 => Ok(listaComentarioProduto1),
                2 => Ok(listaComentarioProduto2),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Cadastrar comentario
        /// </summary>
        /// <response code="200">Comentario criado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Comentario> CadastrarComentario([FromBody] Comentario Comentario)
        {
            Comentario.Codigo = 3;
            return Ok(Comentario);
        }

        /// <summary>
        /// Alterar comentario a partir do ID informado
        /// </summary>
        /// <response code="200">Comentario alterado</response>
        /// <response code="400">Comentario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idComentario}")]
        public ActionResult<Comentario> AlterarComentario(int idComentario, [FromBody] Comentario Comentario)
        {
            return Ok(Comentario);
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
            return Ok(idComentario);
        }

    }
}
