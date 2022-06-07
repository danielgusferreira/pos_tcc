using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class RemoverFormaPagamentoUseCase : IRemoverFormaPagamentoUseCase
    {
        private readonly IFormaPagamentoRepository formaPagamentoRepository;

        public RemoverFormaPagamentoUseCase(IFormaPagamentoRepository formaPagamentoRepository)
        {
            this.formaPagamentoRepository = formaPagamentoRepository;
        }

        public int Execute(int codigo)
        {
            int result;
            try
            {
                result = this.formaPagamentoRepository.RemoverFormaPagamento(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
