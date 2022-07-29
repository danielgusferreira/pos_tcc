using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase.Produto;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FlySneakers.UseCases
{
    public class ObterProdutoCriacaoUseCase : IObterProdutoCriacaoUseCase
    {
        //Instancio variaveis que estão sendo utilizadas
        private readonly IProdutoRepository produtoRepository;

        //Criando construtor passando o repositorio e o validador
        public ObterProdutoCriacaoUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IEnumerable<Produtos> Execute()
        {
            IEnumerable<Produtos> result = null;
            try
            {
                result = this.produtoRepository.ObterListaProdutos();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
