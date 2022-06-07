using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;
using System.Collections.Generic;

namespace FlySneakers.UseCases
{
    public class ObterFormaPagamentoUseCase : IObterFormaPagamentoUseCase
    {
        private readonly IFormaPagamentoRepository formaPagamentoRepository;

        public ObterFormaPagamentoUseCase(IFormaPagamentoRepository formaPagamentoRepository)
        {
            this.formaPagamentoRepository = formaPagamentoRepository;
        }

        public IEnumerable<MeioPagamento> Execute()
        {
            IEnumerable<MeioPagamento> result = null;
            try
            {
                result = this.formaPagamentoRepository.ObterFormaPagamentos();
            }
            catch (Exception e)
            {
                var a = e;
                throw e;
            }

            return result;
        }
    }
}
