using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IDesenvolvedorRepository
    {
        Task Create(DesenvolvedorDTO desenvolvedor);
        Task Update(DesenvolvedorDTO desenvolvedor);
        Task Delete(DesenvolvedorDTO desenvolvedor);
        Task<List<DesenvolvedorDTO>> GetDesenvolvedores();
        Task<string> GetDesenvolvedorById(int desebvolvedorId);
    }
}
