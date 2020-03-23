using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Create(JogoDTO jogo)
        {
            try
            {
                _context.Jogos.Add(jogo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco de dados");
            }
        }

        public async Task Delete(JogoDTO jogo)
        {
            JogoDTO DbJ = await _context.Jogos.FirstOrDefaultAsync(j => j.ID == jogo.ID);
            if (DbJ != null)
            {
                _context.Jogos.Remove(jogo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<JogoDTO>> GetJogos()
        {
            return await _context.Jogos.ToListAsync();
        }

        public async Task<List<JogoDTO>> GetJogosByGenero(int generoID)
        {
            return await _context.Jogos.Where(j => j.GeneroDTOID == generoID).ToListAsync();
        }

        public async Task<List<JogoDTO>> GetJogosByDesenvolvedor(int desenvolvedorID)
        {
            return await _context.Jogos.Where(j => j.DesenvolvedorDTOID == desenvolvedorID).ToListAsync();
        }

        public Task Update(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }
    }
}
