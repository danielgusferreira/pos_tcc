using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlySneakers.Borders.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> ObterCategorias();
        int CadastrarCategoria(Categoria marca);
        int AtualizarCategoria(Categoria marca);
        int RemoverCategoria(int codigo);
    }
}
