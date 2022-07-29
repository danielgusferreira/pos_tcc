using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class RemoverProdutoDadosUseCase : IRemoverProdutoDadosUseCase
    {
        private readonly IProdutoRepository produtoRepository;

        public RemoverProdutoDadosUseCase(IProdutoRepository MarcaRepository)
        {
            this.produtoRepository = MarcaRepository;
        }

        public int Execute(int codigo)
        {
            int result;
            try
            {
                result = this.produtoRepository.RemoverProdutoDados(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
