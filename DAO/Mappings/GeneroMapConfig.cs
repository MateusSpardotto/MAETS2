using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class GeneroMapConfig : EntityTypeConfiguration<GeneroDTO>
    {
        public GeneroMapConfig()
        {
            this.ToTable("GENEROS");
            this.Property(g => g.Nome)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
