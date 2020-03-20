using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task Create(UsuarioDTO usuario);
        Task Update(UsuarioDTO usuario);
        Task Delete(UsuarioDTO usuario);
        Task<UsuarioDTO> Authenticate(string email, string password);

        string VerificaEmail(string email);
        string VerificaSenha(string senha);
    }
}
