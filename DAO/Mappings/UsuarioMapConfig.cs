using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class UsuarioMapConfig : IEntityTypeConfiguration<UsuarioDTO>
    {
        public void Configure(EntityTypeBuilder<UsuarioDTO> builder)
        {
            builder.ToTable("USUARIOS");
            
            builder.Property(u => u.Nome)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();
            builder.HasIndex(u => u.Email)
                .IsUnique(true)
                .HasName("UQ_USUARIO_EMAIL");

            builder.Property(u => u.Senha)
                .HasMaxLength(16)
                .IsRequired();
            builder.HasIndex(u => u.Senha)
                .GetHashCode();

            builder.Property(u => u.CPF)
                .IsFixedLength()
                .HasMaxLength(14)
                .IsRequired();
            builder.HasIndex(u => u.CPF)
                .IsUnique(true)
                .HasName("UQ_USUARIO_CPF");

            builder.Property(u => u.DataNascimento)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
