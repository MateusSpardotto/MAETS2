using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UsuarioDTO_JogoDTO
    {
        public UsuarioDTO UsuarioDTO { get; set; }
        public int UsuarioDTOID { get; set; }
        public JogoDTO JogoDTO { get; set; }
        public int JogoDTOID { get; set; }
    }
}
