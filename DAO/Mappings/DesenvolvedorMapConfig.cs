using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class DesenvolvedorMapConfig : EntityTypeConfiguration<DesenvolvedorDTO>
    {
        public DesenvolvedorMapConfig()
        {
            this.ToTable("DESENVOLVEDORES");

            this.Property(d => d.Nome)
                .HasMaxLength(150)
                .IsRequired();


                this.Property(d => d.PaisOrigem)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
