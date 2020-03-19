using BLL.Interfaces;
using BLL.Validators;
using Common;
using Common.Extensions;
using DAO.Interfaces;
using DTO;
using FluentValidation.Results;
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

        public async Task<UsuarioDTO> Authenticate(string email, string password)
        {
            return await _usuariorepository.Authenticate(email, password);
        }

        public async Task Create(UsuarioDTO usuario)
        {
            ValidationResult result = new UsuarioValidator().Validate(usuario);
            result.ThrowExceptionIfFail();

            await _usuariorepository.Create(usuario);
        }

        public async Task Delete(UsuarioDTO usuario)
        {
            await _usuariorepository.Delete(usuario);
        }

        public async Task<UsuarioDTO> GetUserForEmail(string email)
        {
            return await _usuariorepository.GetUserForEmail(email);
        }

        public Task Update(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public string VerificaEmail(string email)
        {
            return _usuariorepository.VerificaEmail(email);
        }

        public string VerificaSenha(string senha)
        {
            return _usuariorepository.VerificaSenha(senha);
        }
    }
}
