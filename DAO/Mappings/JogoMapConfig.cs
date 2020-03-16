using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class JogoMapConfig : IEntityTypeConfiguration<JogoDTO>
    {
        public void Configure(EntityTypeBuilder<JogoDTO> builder)
        {
            builder.ToTable("JOGOS");
            builder.Property(j => j.Nome)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(j => j.DataLancamento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(j => j.Especificacoes)
                .HasMaxLength(450)
                .IsRequired();

            throw new NotImplementedException();
        }
    }
}
