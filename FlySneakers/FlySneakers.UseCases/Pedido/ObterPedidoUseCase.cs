using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Linq;

namespace FlySneakers.UseCases
{
    public class ObterPedidoUseCase : IObterPedidoUseCase
    {
        //Instancio variaveis que estão sendo utilizadas
        private readonly IPedidoRepository pedidoRepository;

        //Criando construtor passando o repositorio e o validador
        public ObterPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public int Execute(CadastrarCarrinhoDto request)
        {
            var result = new UsuarioLogadoDto { };
            try
            {
                result = this.pedidoRepository.ObterPedidos(request);
            }
            catch (Exception e)
            {
                ErrorMessage errMsg = new ErrorMessage("00.01", "Error ao adicionar produto ao carrinho");
                var errorData = e.Data?.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            }

            return 0;
        }
    }
}
