using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class RemoverProdutoUseCase : IRemoverProdutoUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public RemoverProdutoUseCase(IProdutoRepository ProdutoRepository)
        {
            this.produtoRepository = ProdutoRepository;
        }

        public int Execute(int codigo)
        {
            int result;
            try
            {
                result = this.produtoRepository.RemoverProduto(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
