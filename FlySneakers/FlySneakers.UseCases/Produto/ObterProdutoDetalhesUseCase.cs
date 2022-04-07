using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase.Produto;
using System;
using System.Collections.Generic;

namespace FlySneakers.UseCases
{
    public class ObterProdutoDetalhesUseCase : IObterProdutoDetalhesUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public ObterProdutoDetalhesUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public ProdutoDetalhesDto Execute(int codigo)
        {
            ProdutoDetalhesDto result;
            try
            {
                result = this.produtoRepository.ObterProdutoDetalhes(codigo);

                IEnumerable<EstoqueDto> resultEstoque = this.produtoRepository.ObterEstoque(codigo);
                result.Estoque = resultEstoque;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
