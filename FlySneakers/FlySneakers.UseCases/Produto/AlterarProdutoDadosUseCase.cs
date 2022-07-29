using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class AlterarProdutoDadosUseCase : IAlterarProdutoDadosUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public AlterarProdutoDadosUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public int Execute(ProdutoSku produtoSku)
        {
            int result;
            try
            {
                result = produtoRepository.AtualizarProdutoDados(produtoSku);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
