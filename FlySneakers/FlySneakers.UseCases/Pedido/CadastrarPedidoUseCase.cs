﻿using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Linq;

namespace FlySneakers.UseCases
{
    public class CadastrarPedidoUseCase : ICadastrarPedidoUseCase
    {
        //Instancio variaveis que estão sendo utilizadas
        private readonly IPedidoRepository pedidoRepository;

        //Criando construtor passando o repositorio e o validador
        public CadastrarPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public int Execute(CadastrarCarrinhoDto request)
        {
            int result = 0;
            try
            {
                result = this.pedidoRepository.CadastrarPedido(request); 
            }
            catch (Exception e)
            {
                ErrorMessage errMsg = new ErrorMessage("00.01", "Error ao criar pedido");
                var errorData = e.Data?.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            }

            return result;
        }
    }
}
