using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class CadastarProdutoUseCase : ICadastarProdutoUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public CadastarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public int Execute(Produtos produto)
        {
            int result;
            try
            {
                result = produtoRepository.CadastrarProduto(produto);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
