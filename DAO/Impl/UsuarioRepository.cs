using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
            UsuarioDTO user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == password); //Tio Celo flw sobre o ConfigureAwait(false);
            if (user == null)
            {
                throw new Exception("Email e/ou senha inválidos");
            }
            return user;
        }

        public async Task Create(UsuarioDTO usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco de dados");
            }
        }

        public async Task Delete(UsuarioDTO usuario)
        {
            UsuarioDTO user = await _context.Usuarios.FirstOrDefaultAsync(u => u.ID == usuario.ID);
            if(user != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UsuarioDTO> GetUserForEmail(string email)
        {
            UsuarioDTO user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            return user;
        }

        public Task Update(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public string VerificaEmail(string email)
        {
            var user = _context.Usuarios.FirstAsync(p => p.Email == email);
            if (user == null)
            {
                return "Email inexistente e/ou incorreto na base de dados.";
            }
            return string.Empty;
        }

        public string VerificaSenha(string senha)
        {
            var user = _context.Usuarios.FirstOrDefault(p => p.Senha == senha);
            if (user == null)
            {
                return "Senha inexistente e/ou inválida na base de dados.";
            }
            return string.Empty;
        }
    }
}
