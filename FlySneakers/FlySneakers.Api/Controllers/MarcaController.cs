using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/marca")]
    public class MarcaController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public MarcaController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter as marcas cadastradas
        /// </summary>
        /// <response code="200">Marcas retornadas</response>
        /// <response code="400">Marcas não cadastradas</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<Marca>> ObterMarcas()
        {
            var listaMarca = new List<Marca>
            {
                new Marca { Codigo = 1, Nome = "Nike", Descricao = "Marca de artigos Nike" },
                new Marca { Codigo = 2, Nome = "Adidas", Descricao = "Marca de artigos Adidas" },
                new Marca { Codigo = 3, Nome = "Rebook", Descricao = "Marca de artigos Rebook" },
                new Marca { Codigo = 3, Nome = "Vans", Descricao = "Marca de artigos Vans" }
            };

            return Ok(listaMarca);
        }

        /// <summary>
        /// Obter a marca a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado a marca</remarks>
        /// <response code="200">Marca retornada</response>
        /// <response code="400">Marca não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idMarca}")]
        public ActionResult<Marca> ObterMarca(int idMarca)
        {
            return idMarca switch
            {
                1 => Ok(new Marca { Codigo = 1, Nome = "Nike", Descricao = "Marca roupas Nike" }),
                2 => Ok(new Marca { Codigo = 2, Nome = "Adidas", Descricao = "Marca roupas Adidas" }),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Cadastrar marca
        /// </summary>
        /// <response code="200">Marca cadastrada</response>
        /// <response code="400">Marca não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Marca> CadastrarMarca([FromBody] Marca marca)
        {
            marca.Codigo = 3;
            return Ok(marca);
        }

        /// <summary>
        /// Alterar marca a partir do ID informado
        /// </summary>
        /// <response code="200">Marca alterada</response>
        /// <response code="400">Marca não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idMarca}")]
        public ActionResult<Marca> AlterarMarca(int idMarca, [FromBody] Marca marca)
        {
            return Ok(marca);
        }

        /// <summary>
        /// Remover marca
        /// </summary>
        /// <response code="200">Marca removida</response>
        /// <response code="400">Marca não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idMarca}")]
        public ActionResult RemoverMarca(int idMarca)
        {
            return Ok(idMarca);
        }

    }
}
