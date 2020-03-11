using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class UsuarioMapConfig : EntityTypeConfiguration<UsuarioDTO>
    {
        public UsuarioMapConfig()
        {
            this.ToTable("USUARIOS");

            this.Property(u => u.Nome)
                .HasMaxLength(60)
                .IsRequired();

            this.Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();
            this.HasIndex(u => u.Email)
                .IsUnique(true)
                .HasName("UQ_USUARIO_EMAIL");

            this.Property(u => u.Senha)
                .HasMaxLength(16)
                .IsRequired();
            this.HasIndex(u => u.Senha)
                .GetHashCode();

            this.Property(u => u.CPF)
                .IsFixedLength()
                .HasMaxLength(14)
                .IsRequired();
            this.HasIndex(u => u.CPF)
                .IsUnique(true)
                .HasName("UQ_USUARIO_CPF");

            this.Property(u => u.DataNascimento)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
