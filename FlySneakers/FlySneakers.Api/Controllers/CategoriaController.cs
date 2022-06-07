using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;
        private readonly IObterCategoriaUseCase obterCategoriaUseCase;
        private readonly ICadastarCategoriaUseCase cadastarCategoriaUseCase;
        private readonly IEditarCategoriaUseCase editarCategoriaUseCase;
        private readonly IRemoverCategoriaUseCase removerCategoriaUseCase;

        public CategoriaController(IActionResultConverter actionResultConverter,
            IObterCategoriaUseCase obterCategoriaUseCase,
            ICadastarCategoriaUseCase cadastarCategoriaUseCase,
            IEditarCategoriaUseCase editarCategoriaUseCase, 
            IRemoverCategoriaUseCase removerCategoriaUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.obterCategoriaUseCase = obterCategoriaUseCase;
            this.cadastarCategoriaUseCase = cadastarCategoriaUseCase;
            this.editarCategoriaUseCase = editarCategoriaUseCase;
            this.removerCategoriaUseCase = removerCategoriaUseCase;
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
            var listaCategoria = obterCategoriaUseCase.Execute();

            return Ok(listaCategoria);
        }

        #region
        ///// <summary>
        ///// Obter a categoria informada pelo ID
        ///// </summary>
        ///// <remarks>Ao informar os IDs 1 e 2 será retornado a categoria</remarks>
        ///// <response code="200">Categoria retornada</response>
        ///// <response code="400">Categoria não encontrada</response>
        ///// <response code="500">Erro inesperado</response>
        //[HttpGet("{idCategoria}")]
        //public ActionResult<Categoria> ObterCategoria(int idCategoria)
        //{
        //    return idCategoria switch
        //    {
        //        1 => Ok(new Categoria { Codigo = 1, Nome = "Tênis", Descricao = "Categoria responsavel por listas os tênis disponiveis no site." }),
        //        2 => Ok(new Categoria { Codigo = 2, Nome = "Feminino", Descricao = "Categoria responsavel por listas itens femininos." }),
        //        _ => NotFound(),
        //    };
        //}
        #endregion

        /// <summary>
        /// Criar nova categoria
        /// </summary>
        /// <response code="200">Categoria cadastrada</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<Categoria> CadastrarCategoria([FromBody] Categoria categoria)
        {
            var result = cadastarCategoriaUseCase.Execute(categoria);

            if(result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
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
            categoria.Codigo = idCategoria;
            var result = editarCategoriaUseCase.Execute(categoria);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
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
            var result = removerCategoriaUseCase.Execute(idCategoria);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

    }
}
