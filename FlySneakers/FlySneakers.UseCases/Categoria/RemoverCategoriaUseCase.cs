using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class RemoverCategoriaUseCase : IRemoverCategoriaUseCase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public RemoverCategoriaUseCase(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public int Execute(int codigo)
        {
            int result;
            try
            {
                result = this.categoriaRepository.RemoverCategoria(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
