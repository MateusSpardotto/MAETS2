using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
                entityType.GetProperties().Where(c => c.ClrType == typeof(string)).ToList()
                    .ForEach(p => p.SetIsUnicode(false));
            }

            modelBuilder.Entity<UsuarioDTO_JogoDTO>()
               .HasKey(si => new { si.UsuarioDTOID, si.JogoDTOID });
            modelBuilder.Entity<UsuarioDTO_JogoDTO>()
                .HasOne(si => si.UsuarioDTO)
                .WithMany(i => i.Jogos)
                .HasForeignKey(si => si.UsuarioDTOID);
            modelBuilder.Entity<UsuarioDTO_JogoDTO>()
                .HasOne(si => si.JogoDTO)
                .WithMany(s => s.Usuarios)
                .HasForeignKey(si => si.JogoDTOID);
        } 
    }
}
