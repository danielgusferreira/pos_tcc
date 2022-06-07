using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;
using System.Collections.Generic;

namespace FlySneakers.UseCases
{
    public class ObterComentarioUseCase : IObterComentarioUseCase
    {
        private readonly IComentarioRepository ComentarioRepository;

        public ObterComentarioUseCase(IComentarioRepository comentarioRepository)
        {
            this.ComentarioRepository = comentarioRepository;
        }

        public IEnumerable<Comentario> Execute(int codigo)
        {
            IEnumerable<Comentario> result;
            try
            {
                result = this.ComentarioRepository.ObterComentarios(codigo);
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
