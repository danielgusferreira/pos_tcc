using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase.Produto;
using System;
using System.Collections.Generic;

namespace FlySneakers.UseCases
{
    public class ObterProdutoDadosCriacaoUseCase : IObterProdutoDadosCriacaoUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public ObterProdutoDadosCriacaoUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoSku> Execute(int codigoProduto)
        {
            IEnumerable<ProdutoSku> result;
            try
            {
                result = this.produtoRepository.ObterListaProdutosDados(codigoProduto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
