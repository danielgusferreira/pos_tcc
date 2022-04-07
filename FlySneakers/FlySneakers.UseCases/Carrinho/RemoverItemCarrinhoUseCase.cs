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
    public class RemoverItemCarrinhoUseCase : IRemoverItemCarrinhoUseCase
    {
        private readonly ICarrinhoRepository carrinhoRepository;

        public RemoverItemCarrinhoUseCase(ICarrinhoRepository carrinhoRepository)
        {
            this.carrinhoRepository = carrinhoRepository;
        }

        public int Execute(int request)
        {
            int result = 0;
            try
            {
                result = this.carrinhoRepository.RemoverItemCarrinhoProduto(request);
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
