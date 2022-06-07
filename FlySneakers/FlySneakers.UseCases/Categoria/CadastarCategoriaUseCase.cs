using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class CadastarCategoriaUseCase : ICadastarCategoriaUseCase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CadastarCategoriaUseCase(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public int Execute(Categoria categoria)
        {
            int result = 0;
            try
            {
                result = this.categoriaRepository.CadastrarCategoria(categoria);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
