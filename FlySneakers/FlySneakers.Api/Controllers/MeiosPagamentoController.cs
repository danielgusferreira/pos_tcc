using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/meio-pagamento")]
    public class MeiosPagamentoController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;
        private readonly IObterFormaPagamentoUseCase obterFormaPagamentoUseCase;
        private readonly ICadastarFormaPagamentoUseCase cadastarFormaPagamentoUseCase;
        private readonly IEditarFormaPagamentoUseCase editarFormaPagamentoUseCase;
        private readonly IRemoverFormaPagamentoUseCase removerFormaPagamentoUseCase;

        public MeiosPagamentoController(IActionResultConverter actionResultConverter, IObterFormaPagamentoUseCase obterFormaPagamentoUseCase, ICadastarFormaPagamentoUseCase cadastarFormaPagamentoUseCase, IEditarFormaPagamentoUseCase editarFormaPagamentoUseCase, IRemoverFormaPagamentoUseCase removerFormaPagamentoUseCase)
        {
            this.actionResultConverter = actionResultConverter;
            this.obterFormaPagamentoUseCase = obterFormaPagamentoUseCase;
            this.cadastarFormaPagamentoUseCase = cadastarFormaPagamentoUseCase;
            this.editarFormaPagamentoUseCase = editarFormaPagamentoUseCase;
            this.removerFormaPagamentoUseCase = removerFormaPagamentoUseCase;
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
            var listaCategoria = obterFormaPagamentoUseCase.Execute();

            return Ok(listaCategoria);
        }

        #region
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
        #endregion

        /// <summary>
        /// Cadastrar meio de pagamento
        /// </summary>
        /// <response code="200">Meio de pagamento cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<IEnumerable<string>> CadastrarMeioPagamento([FromBody] MeioPagamento MeioPagamento)
        {
            var result = cadastarFormaPagamentoUseCase.Execute(MeioPagamento);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
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
            MeioPagamento.Codigo = idMeioPagamento;
            var result = editarFormaPagamentoUseCase.Execute(MeioPagamento);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
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
            var result = removerFormaPagamentoUseCase.Execute(idMeioPagamento);

            if (result == 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

    }
}
