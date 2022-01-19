using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public CategoriaController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter todas as categorias cadastradas
        /// </summary>
        /// <response code="200">Categorias retornadas</response>
        /// <response code="400">Categorias não encontradas</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> ObterCategorias()
        {
            var listaCategoria = new List<Categoria>
            {
                new Categoria { Codigo = 1, Nome = "Tênis", Descricao = "Categoria responsavel por listas os tênis disponiveis no site." },
                new Categoria { Codigo = 2, Nome = "Feminino", Descricao = "Categoria responsavel por listas itens femininos." }
            };

            return Ok(listaCategoria);
        }

        /// <summary>
        /// Obter a categoria informada pelo ID
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado a categoria</remarks>
        /// <response code="200">Categoria retornada</response>
        /// <response code="400">Categoria não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idCategoria}")]
        public ActionResult<Categoria> ObterCategoria(int idCategoria)
        {
            return idCategoria switch
            {
                1 => Ok(new Categoria { Codigo = 1, Nome = "Tênis", Descricao = "Categoria responsavel por listas os tênis disponiveis no site." }),
                2 => Ok(new Categoria { Codigo = 2, Nome = "Feminino", Descricao = "Categoria responsavel por listas itens femininos." }),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Criar nova categoria
        /// </summary>
        /// <response code="200">Categoria cadastrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Categoria> CadastrarCategoria([FromBody] Categoria categoria)
        {
            categoria.Codigo = 3;
            return Ok(categoria);
        }

        /// <summary>
        /// Alterar dados categoria
        /// </summary>
        /// <response code="200">Categoria alterada</response>
        /// <response code="400">Categoria não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idCategoria}")]
        public ActionResult<IEnumerable<string>> AlterarCategoria(int idCategoria, [FromBody] Categoria categoria)
        {
            return Ok(categoria);
        }

        /// <summary>
        /// Remover categoria
        /// </summary>
        /// <response code="200">Categoria removida</response>
        /// <response code="400">Categoria não encontrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{idCategoria}")]
        public ActionResult<IEnumerable<string>> RemoverCategoria(int idCategoria)
        {
            return Ok(idCategoria);
        }

    }
}
