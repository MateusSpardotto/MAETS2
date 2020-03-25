using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; private set; }
        public string CPF { get; set; }
        public Paises Pais { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public virtual ICollection<UsuarioDTO_JogoDTO> Jogos { get; set; }
        public double Carteira { get; private set; }
    }
}
