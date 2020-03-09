using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DesenvolvedorRepository : IDesenvolvedorRepository
    {
        private readonly MContext _context;

        public DesenvolvedorRepository(MContext context)
        {
            this._context = context;
        }

        public Task Create(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }

        public Task<List<DesenvolvedorDTO>> GetDesenvolvedores()
        {
            throw new NotImplementedException();
        }

        public Task Update(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }
    }
}
