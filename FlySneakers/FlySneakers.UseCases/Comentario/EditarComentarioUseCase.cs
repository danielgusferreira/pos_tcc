using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class EditarComentarioUseCase : IEditarComentarioUseCase
    {
        private readonly IComentarioRepository ComentarioRepository;

        public EditarComentarioUseCase(IComentarioRepository comentarioRepository)
        {
            this.ComentarioRepository = comentarioRepository;
        }

        public int Execute(Comentario comentario)
        {
            int result;
            try
            {
                result = this.ComentarioRepository.AtualizarComentario(comentario);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
