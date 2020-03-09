using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IGeneroService
    {
        Task Create(GeneroDTO genero);
        Task Update(GeneroDTO genero);
        Task Delete(GeneroDTO genero);
        Task<List<GeneroDTO>> GetGeneros();
    }
}
