﻿using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DesenvolvedorDTO
    {
        public int ID { get; set; }
        public string Nome{ get; set; }
        public Paises PaisOrigem { get; set; }
        public virtual ICollection<JogoDTO> Jogos { get; set; }
    }
}
