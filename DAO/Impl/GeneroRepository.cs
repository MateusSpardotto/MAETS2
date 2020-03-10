using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly MContext _context;

        public GeneroRepository(MContext context)
        {
            this._context = context;
        }

        public async Task Create(GeneroDTO genero)
        {
            try
            {
                _context.Generos.Add(genero);
                await _context.SaveChangesAsync();
             }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco de dados");
            }

        }

        public async Task Delete(GeneroDTO genero)
        {
            GeneroDTO DbG = await _context.Generos.FirstOrDefaultAsync(g => g.ID == genero.ID);
            if (DbG != null)
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GeneroDTO>> GetGeneros()
        {
            return await _context.Generos.ToListAsync();
        }

        public Task Update(GeneroDTO genero)
        {
            throw new NotImplementedException();
        }
    }
}
