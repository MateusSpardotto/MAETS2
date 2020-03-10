﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace DAO.Mappings
{
    public class JogoMapConfig : EntityTypeConfiguration<JogoDTO>
    {
        public JogoMapConfig()
        {
            this.ToTable("JOGOS");

            this.Property(j => j.Nome)
                .HasMaxLength(150)
                .IsRequired()
                .IsUnicode();

            this.Property(j => j.Especificacoes)
                .HasMaxLength(450)
                .IsRequired()
                .IsUnicode();
        }
    }
}