using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class EditarCategoriaUseCase : IEditarCategoriaUseCase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public EditarCategoriaUseCase(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public int Execute(Categoria categoria)
        {
            int result;
            try
            {
                result = this.categoriaRepository.AtualizarCategoria(categoria);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
