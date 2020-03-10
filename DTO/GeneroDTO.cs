using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class GeneroDTO
    {
        public int ID{ get; set; }
        public string Nome { get; set; }
        public virtual ICollection<JogoDTO> Jogos { get; set; }
    }
}
