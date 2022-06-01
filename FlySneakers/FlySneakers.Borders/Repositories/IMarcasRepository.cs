using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlySneakers.Borders.Repositories
{
    public interface IMarcasRepository
    {
        Task<IEnumerable<Marca>> ObterMarcas();
        int CadastrarMarca(Marca marca);
        int AtualizarMarca(Marca marca);
        int RemoverMarca(int codigo);
    }
}
