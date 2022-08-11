using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class GraficosPedidosUseCase : IGraficosPedidosUseCase
    {
        //Instancio variaveis que estão sendo utilizadas
        private readonly IPedidoRepository pedidoRepository;

        //Criando construtor passando o repositorio e o validador
        public GraficosPedidosUseCase(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public GraficoDto Execute()
        {
            try
            {
                var result = this.pedidoRepository.ObterGraficosPedidos();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
