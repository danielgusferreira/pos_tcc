using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;
using System.Collections.Generic;

namespace FlySneakers.UseCases
{
    public class ObterCategoriaUseCase : IObterCategoriaUseCase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public ObterCategoriaUseCase(ICategoriaRepository carrinhoRepository)
        {
            this.categoriaRepository = carrinhoRepository;
        }

        public IEnumerable<Categoria> Execute()
        {
            IEnumerable<Categoria> result = null;
            try
            {
                result = this.categoriaRepository.ObterCategorias();
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
