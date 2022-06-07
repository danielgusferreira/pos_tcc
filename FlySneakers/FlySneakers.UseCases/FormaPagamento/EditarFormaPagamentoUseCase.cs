using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class EditarFormaPagamentoUseCase : IEditarFormaPagamentoUseCase
    {
        private readonly IFormaPagamentoRepository MeioPagamentoRepository;

        public EditarFormaPagamentoUseCase(IFormaPagamentoRepository MeioPagamentoRepository)
        {
            this.MeioPagamentoRepository = MeioPagamentoRepository;
        }

        public int Execute(MeioPagamento meioPagamento)
        {
            int result;
            try
            {
                result = this.MeioPagamentoRepository.AtualizarFormaPagamento(meioPagamento);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
