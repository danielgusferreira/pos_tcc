using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class CadastarFormaPagamentoUseCase : ICadastarFormaPagamentoUseCase
    {
        private readonly IFormaPagamentoRepository FormaPagamentoRepository;

        public CadastarFormaPagamentoUseCase(IFormaPagamentoRepository formaPagamentoRepository)
        {
            this.FormaPagamentoRepository = formaPagamentoRepository;
        }

        public int Execute(MeioPagamento formaPagamento)
        {
            int result = 0;
            try
            {
                result = this.FormaPagamentoRepository.CadastrarFormaPagamento(formaPagamento);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
