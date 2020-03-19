using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Create(UsuarioDTO usuario);
        Task Update(UsuarioDTO usuario);
        Task Delete(UsuarioDTO usuario);
        Task<UsuarioDTO> Authenticate(string email, string password);
        Task<UsuarioDTO> GetUserForEmail(string email);
        string VerificaEmail(string email);
        string VerificaSenha(string senha);

    }
}
