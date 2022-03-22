using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FlySneakers.UseCases
{
    public class ObterCarrinhoUsuarioUseCase : IObterCarrinhoUsuarioUseCase
    {
        private readonly ICarrinhoRepository carrinhoRepository;

        public ObterCarrinhoUsuarioUseCase(ICarrinhoRepository carrinhoRepository)
        {
            this.carrinhoRepository = carrinhoRepository;
        }

        public IEnumerable<DadosCarrinhoDto> Execute(int request)
        {
            IEnumerable<DadosCarrinhoDto> result = null;
            try
            {
                result = this.carrinhoRepository.ObterCarrinho(request);
            }
            catch (Exception e)
            {
                ErrorMessage errMsg = new ErrorMessage("00.01", "Error ao adicionar produto ao carrinho");
                var errorData = e.Data?.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            }

            return result;
        }
    }
}
