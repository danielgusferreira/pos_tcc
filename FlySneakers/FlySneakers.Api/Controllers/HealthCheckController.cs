using FlySneakers.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/healthcheck")]
    public class HealthCheckController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public HealthCheckController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Verificar saúde da API
        /// </summary>
        /// <remarks>EndPoint utilizado para verificar a saúde da API, se a mesma está sendo executada corretamente sem nenhum problema.</remarks>
        /// <response code="200">API com status OK</response>
        /// <response code="500">Erro inesperado na API</response>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok();
        }

    }
}
