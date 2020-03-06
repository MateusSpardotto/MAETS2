using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuariorepository;
        public UsuarioService(IUsuarioRepository usuariorepository)
        {
            this._usuariorepository = usuariorepository;
        }

        public Task<UsuarioDTO> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Create(UsuarioDTO usuario)
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
