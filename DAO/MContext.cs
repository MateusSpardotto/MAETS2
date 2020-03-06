using DTO;
using Microsoft.EntityFrameworkCore;
using System;


namespace DAO
{
    public class MContext : DbContext
    {
        public MContext(DbContextOptions<MContext> options):base(options)
        {

        }

        public DbSet<GeneroDTO> Generos { get; set; }
        public DbSet<JogoDTO> Jogos { get; set; }
        public DbSet<DesenvolvedorDTO> Desenvolvedoras { get; set; }
        public DbSet<UsuarioDTO> Usuarios { get; set; }


    }
}
