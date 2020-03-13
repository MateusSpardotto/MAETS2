using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class DesenvolvedorMapConfig : IEntityTypeConfiguration<DesenvolvedorDTO>
    {
        public void Configure(EntityTypeBuilder<DesenvolvedorDTO> builder)
        {
            builder.ToTable("DESENVOLVEDORES");
            builder.Property(d => d.Nome)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
