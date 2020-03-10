using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DesenvolvedorRepository : IDesenvolvedorRepository
    {
        private readonly MContext _context;

        public DesenvolvedorRepository(MContext context)
        {
            this._context = context;
        }

        public async Task Create(DesenvolvedorDTO desenvolvedor)
        {
            try
            {
                _context.Desenvolvedoras.Add(desenvolvedor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco de dados");
            }
        }

        public async Task Delete(DesenvolvedorDTO desenvolvedor)
        {
            DesenvolvedorDTO DbD = await _context.Desenvolvedoras.FirstOrDefaultAsync(u => u.ID == desenvolvedor.ID);
            if (DbD != null)
            {
                _context.Desenvolvedoras.Remove(desenvolvedor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DesenvolvedorDTO>> GetDesenvolvedores()
        {
            return await _context.Desenvolvedoras.ToListAsync();
        }

        public Task Update(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }
    }
}
