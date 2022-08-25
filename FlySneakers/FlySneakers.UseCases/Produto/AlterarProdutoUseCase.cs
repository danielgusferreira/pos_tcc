using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class AlterarProdutoUseCase : IAlterarProdutoUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public AlterarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public int Execute(Produtos produto)
        {
            int result;
            try
            {
                result = produtoRepository.AtualizarProduto(produto);
            }
            catch (Exception e)
            {
                var a = e;
                throw e;
            }

            return result;
        }
    }
}
