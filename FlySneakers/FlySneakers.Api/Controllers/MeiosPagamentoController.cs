using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/meio-pagamento")]
    public class MeiosPagamentoController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public MeiosPagamentoController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter os meios de pagamentos
        /// </summary>
        /// <response code="200">Meios de pagamentos retornados</response>
        /// <response code="400">Meios de pagamentos não cadastrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<MeioPagamento>> ObterMeioPagamentos()
        {
            var listaMeio = new List<MeioPagamento>
            {
                new MeioPagamento { Codigo = 1, Nome = "Boleto", Descricao = "Opção de pagamento via Boleto" },
                new MeioPagamento { Codigo = 2, Nome = "Pix", Descricao = "Opção de pgamento via Pix" }
            };

            return Ok(listaMeio);
        }

        /// <summary>
        /// Obter meio de pagamento a partir do ID informado
        /// </summary>
        /// <remarks>Ao informar os IDs 1 e 2 será retornado o meio de pagamento</remarks>
        /// <response code="200">Meio de pagamento retornado</response>
        /// <response code="400">Meio de pagamento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet("{idMeioPagamento}")]
        public ActionResult<MeioPagamento> ObterMeioPagamento(int idMeioPagamento)
        {
            return idMeioPagamento switch
            {
                1 => Ok(new MeioPagamento { Codigo = 1, Nome = "Boleto", Descricao = "Opção de pagamento via Boleto" }),
                2 => Ok(new MeioPagamento { Codigo = 2, Nome = "Pix", Descricao = "Opção de pgamento via Pix" }),
                _ => NotFound(),
            };
        }

        /// <summary>
        /// Cadastrar meio de pagamento
        /// </summary>
        /// <response code="200">Meio de pagamento cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<IEnumerable<string>> CadastrarMeioPagamento([FromBody] MeioPagamento MeioPagamento)
        {
            MeioPagamento.Codigo = 3;
            return Ok(MeioPagamento);
        }

        /// <summary>
        /// Alterar meio de pagamento a partir do ID informado
        /// </summary>
        /// <response code="200">Meio de pagamento alterado</response>
        /// <response code="400">Meio de pagamento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idMeioPagamento}")]
        public ActionResult<MeioPagamento> AlterarMeioPagamento(int idMeioPagamento, [FromBody] MeioPagamento MeioPagamento)
        {
            return Ok(MeioPagamento);
        }

        /// <summary>
        /// Remover meio de pagamento a partir do ID informado
        /// </summary>
        /// <response code="200">Meio de pagamento removido</response>
        /// <response code="400">Meio de pagamento não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("idMeioPagamento")]
        public ActionResult RemoverMeioPagamento(int idMeioPagamento)
        {
            return Ok(idMeioPagamento);
        }

    }
}
