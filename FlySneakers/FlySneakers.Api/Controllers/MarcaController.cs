using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/marca")]
    public class MarcaController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;
        private readonly IObterMarcaUseCase obterMarcaUseCase;
        private readonly ICadastarMarcaUseCase cadastarMarcaUseCase;
        private readonly IEditarMarcaUseCase editarMarcaUseCase;
        private readonly IRemoverMarcaUseCase removerMarcaUseCase;

        public MarcaController(IActionResultConverter actionResultConverter, IObterMarcaUseCase obterMarcaUseCase, ICadastarMarcaUseCase cadastarMarcaUseCase, IEditarMarcaUseCase editarMarcaUseCase, IRemoverMarcaUseCase removerMarcaUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.obterMarcaUseCase = obterMarcaUseCase;
            this.cadastarMarcaUseCase = cadastarMarcaUseCase;
            this.editarMarcaUseCase = editarMarcaUseCase;
            this.removerMarcaUseCase = removerMarcaUseCase;
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
            var ListaMarcas = obterMarcaUseCase.Execute();

            return Ok(ListaMarcas);
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
            var result = cadastarMarcaUseCase.Execute(marca);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
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
            marca.Codigo = idMarca;
            var result = editarMarcaUseCase.Execute(marca);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
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
            var result = removerMarcaUseCase.Execute(idMarca);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

    }
}
