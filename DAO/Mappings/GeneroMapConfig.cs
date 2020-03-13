using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class GeneroMapConfig : IEntityTypeConfiguration<GeneroDTO>
    {
        public void Configure(EntityTypeBuilder<GeneroDTO> builder)
        {
            builder.ToTable("GENEROS");
            builder.Property(g => g.Nome)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
