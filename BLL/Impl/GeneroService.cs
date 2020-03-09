using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class GeneroService : IGeneroService
    {
        private IGeneroRepository _generorepository;

        public GeneroService(IGeneroRepository generorepository)
        {
            this._generorepository = generorepository;
        }

        public async Task Create(GeneroDTO genero)
        {
            await _generorepository.Create(genero);
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
