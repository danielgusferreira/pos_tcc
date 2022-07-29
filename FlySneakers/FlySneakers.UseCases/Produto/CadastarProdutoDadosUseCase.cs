using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class CadastrarProdutoDadosUseCase : ICadastarProdutoDadosUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public CadastrarProdutoDadosUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public int Execute(ProdutoSku produtoSku)
        {
            int result;
            try
            {
                result = produtoRepository.CadastrarProdutoDados(produtoSku);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
