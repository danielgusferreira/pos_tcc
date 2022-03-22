using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Linq;

namespace FlySneakers.UseCases
{
    public class AdicionarItemCarrinhoUseCase : IAdicionarItemCarrinhoUseCase
    {
        //Instancio variaveis que estão sendo utilizadas
        private readonly ICarrinhoRepository carrinhoRepository;

        //Criando construtor passando o repositorio e o validador
        public AdicionarItemCarrinhoUseCase(ICarrinhoRepository carrinhoRepository)
        {
            this.carrinhoRepository = carrinhoRepository;
        }

        public int Execute(CadastrarCarrinhoDto request)
        {
            int result = 0;
            try
            {
                result = this.carrinhoRepository.CadastrarProduto(request);
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
