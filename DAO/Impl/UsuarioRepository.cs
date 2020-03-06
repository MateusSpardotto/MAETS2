using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly MContext _context;

        public UsuarioRepository(MContext context)
        {
            this._context = context;
        }


        public async Task<UsuarioDTO> Authenticate(string email, string password)
        {

            throw new Exception();
        }

        public async Task Create(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public Task Update(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
