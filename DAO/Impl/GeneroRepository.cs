using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly MContext _context;

        public GeneroRepository(MContext context)
        {
            this._context = context;
        }

        public Task Create(GeneroDTO genero)
        {
            throw new NotImplementedException();
        }

        public Task Delete(GeneroDTO genero)
        {
            throw new NotImplementedException();
        }

        public Task<List<GeneroDTO>> GetGeneros()
        {
            throw new NotImplementedException();
        }

        public Task Update(GeneroDTO genero)
        {
            throw new NotImplementedException();
        }
    }
}
