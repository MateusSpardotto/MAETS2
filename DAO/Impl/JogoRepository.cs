using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class JogoRepository : IJogoRepository
    {
        private readonly MContext _context;

        public JogoRepository(MContext context)
        {
            this._context = context;
        }

        public Task Create(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }

        public Task Delete(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }

        public Task<List<JogoDTO>> GetJogos()
        {
            throw new NotImplementedException();
        }

        public Task Update(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }
    }
}
